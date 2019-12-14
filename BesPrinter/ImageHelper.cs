using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BesPrinter
{
    class ImageHelper
    {
        /// <summary>
        ///获得支持显示的图片格式
        /// </summary>
        static public List<string> GetSupportedFormat()
        {
            List<string> formatSet = new List<string>();

            //注：该格式的顺序【必须】和 imageList 的元素一一对应
            formatSet.Add("bmp");
            formatSet.Add("png");
            formatSet.Add("jpg");
            formatSet.Add("jpeg");
            formatSet.Add("svg");
            formatSet.Add("emf");

            return formatSet;
        }

        /// <summary>
        ///获得支持显示的图片后缀（包括符号 .）
        /// </summary>
        static public List<string> GetSupportedFormatExtension()
        {
            List<string> formatSet = GetSupportedFormat();

            List<string> extensionSet = new List<string>();
            foreach (string format in formatSet)
                extensionSet.Add("." + format);

            return extensionSet;
        }
        
        /// <summary>
        ///加载路径下的一张图片，读取失败或格式不支持返回一张默认图片
        /// </summary>
        /// 
        ///<note>
        ///外部使用完 Image 之后，必须明确调用 Image.Dipose() 立刻释放，因
        ///为 svg 文件会生成 emf 临时文件，需要释放资源才能删除
        ///</note>
        static public Image LoaderImage(string path)
        {
            Bitmap defaultBitmap = global::BesPrinter.Properties.Resources.unsupported_image;

            Image image = null;
            if(!File.Exists(path))
            {
                image = defaultBitmap;  //文件不存在，返回默认图片
            }
            else
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Extension == ".bmp"
                    || fileInfo.Extension == ".png"
                    || fileInfo.Extension == ".jpg"
                    || fileInfo.Extension == ".jpeg")
                {
                    image = Image.FromFile(path);
                }
                else if(fileInfo.Extension == ".svg")
                {
                    //临时创建一个 svg 转换而来的 emf 文件
                    string emfTempPath = Path.GetTempFileName();
                    try
                    {
                        SvgDocument svg = SvgDocument.Open(path);
                        using (Graphics bufferGraphics = Graphics.FromHwndInternal(IntPtr.Zero))
                        {
                            using (var metafile = new Metafile(emfTempPath, bufferGraphics.GetHdc()))
                            {
                                using (Graphics graphics = Graphics.FromImage(metafile))
                                {
                                    svg.Draw(graphics);
                                }
                            }

                            image = new Metafile(emfTempPath); //读取 emf 文件
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        //现在获得图片不能立刻删除文件，不然得到 image 也无法获得其中的数据
                        if (listTempEmfFiles == null)
                            listTempEmfFiles = new List<string>();
                        listTempEmfFiles.Add(emfTempPath);
                    }
                }
                else if (fileInfo.Extension == ".emf")
                {
                    image = new Metafile(path);
                }
                else
                {
                    image = defaultBitmap; //格式不支持不存在，返回默认图片
                }
            }
            
            if(image == null)
                image = defaultBitmap;  //如果存在读取失败的情况，使用默认图片返回

            return image;
        }

        /// <summary>
        ///根据当前图像的外接矩形和容器的外接矩形，以及提供的距边参数，计算得到按比例缩放的位置的外接矩形
        /// </summary>
        static public RectangleF GetKeepRadioRect(RectangleF rectImage, RectangleF rectContainer
            , float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            float marginVertical = marginTop + marginBottom;
            float marginHorizontal = marginLeft + marginRight;
            
            float WHRateRaw = rectImage.Height / rectImage.Width;
            float WHRateTarget = (rectContainer.Height - marginVertical) / (rectContainer.Width - marginHorizontal);

            float H = rectContainer.Height;
            float W = rectContainer.Width;
            float startX = 0.0f;
            float startY = 0.0f;

            if (WHRateRaw > WHRateTarget)
            {
                //源数据的高比较高，以上下为基准缩放
                H = rectContainer.Height - marginVertical;
                W = H / WHRateRaw;
                startX = (rectContainer.Width - W) / 2;
                startY = marginTop;
            }
            else
            {
                //以左右为基准缩放
                W = rectContainer.Width - marginHorizontal;
                H = W * WHRateRaw;
                startX = marginLeft;
                startY = (rectContainer.Height - H) / 2;
            }
            
            return new RectangleF(startX, startY, W, H);
        }

        /// <summary>
        ///根据容器的外接矩形，以及提供的距边参数，计算得到容器内缩边距后的外接矩形
        /// </summary>
        static public RectangleF GetContainerMarginRect(RectangleF rectContainer
            , float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            float marginVertical = marginTop + marginBottom;
            float marginHorizontal = marginLeft + marginRight;
            
            float H = rectContainer.Height - marginVertical;
            float W = rectContainer.Width - marginHorizontal;
            float startX = marginLeft;
            float startY = marginTop;

            return new RectangleF(startX, startY, W, H);
        }

        /// <summary>
        ///删除所有临时emf文件
        /// </summary>
        /// 
        ///<note>
        ///调用 ClearTempEmfFiles 之前，需要保证  
        ///外部使用完 LoaderImage 返回的 Image 之后，必须明确调用 Image.Dipose() 立刻释放，
        ///不然这里释放资源会崩溃，需要释放资源才能正常删除
        ///</note>
        static public void ClearTempEmfFiles()
        {
            if (listTempEmfFiles == null)
                return;

            try
            {
                foreach (string file in listTempEmfFiles)
                {
                    File.Delete(file);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 将文件或文件夹 path1 的图片文件转换为 文件或文件夹 path2 下的文件 
        /// </summary>
        static public int ConvertImageByPath(string path1, string path2, string format1, string format2)
        {
            if (!(File.Exists(path1) || Directory.Exists(path1) && Directory.Exists(path2)))
            {
                MessageBox.Show($"invalid path: from [{path1}] to [{path2}]\n\n when from-path is file, to-path can be directory or file \n\n when from-path is directory, to-path must be directory too",
                    Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else
            {
                List<string> ImagesFrom = new List<string>();
                List<string> ImagesTo = new List<string>();

                if (Directory.Exists(path2) && path2.LastIndexOf("\\") != path2.Length - 1)
                    path2 += "\\";

                FileInfo f1 = new FileInfo(path1);
                FileInfo f2 = new FileInfo(path2);
                
                //第一个路径是文件的情况
                if(File.Exists(path1) && Directory.Exists(f2.DirectoryName))
                {
                    //确认文件2的名称
                    string fileName2 = System.IO.Path.GetFileNameWithoutExtension(path2);
                    if (f2.Extension == null || f2.Extension.Equals("")) //没有后缀认为路径2为目录
                    {
                        fileName2 = System.IO.Path.GetFileNameWithoutExtension(path1);
                    }

                    //构建文件2的路径
                    string file2 = f2.DirectoryName + "\\" + fileName2 + "." + format2;

                    if (f1.Extension.Equals("." + format1)) //格式得符合的情况才转换
                    {
                        // ImagesFrom 和 ImagesTo 个数一致
                        ImagesFrom.Add(path1);
                        ImagesTo.Add(file2);
                    }
                }
                else if (Directory.Exists(path1) && Directory.Exists(path2))
                {
                    //收集符合格式要求的文件，或文件夹下的文件
                    
                    DirectoryInfo root = new DirectoryInfo(path1);
                    foreach (FileInfo f in root.GetFiles())
                    {
                        if (f.Extension.Equals("."+format1))
                            ImagesFrom.Add(f.FullName);
                    }

                    string directory2 = f2.Directory.FullName;
                    foreach (string f in ImagesFrom)
                    {
                        FileInfo info1 = new FileInfo(f);
                        string file1Name = System.IO.Path.GetFileNameWithoutExtension(f);
                        string file2 = directory2 + "\\" + file1Name + "." + format2;
                        ImagesTo.Add(file2);
                    }

                    // ImagesFrom 和 ImagesTo 个数一致
                }

                //将 ImagesFrom 和 ImagesTo 的文件对应进行装换
                for(int i = 0; i< ImagesFrom.Count; i++)
                {
                    if(!ConvertImage(ImagesFrom[i], ImagesTo[i])) //失败任意一个则退出
                        return -1;
                }

                return 0;
            }
        }

        /// <summary>
        /// 将文件或目录下的文件 从格式 format1 转为 format2 
        /// </summary>
        static public int ConvertImageByPath(string path, string format1, string  format2)
        {
            //收集来源
            List<string> ImagesFrom = new List<string>();
            if (Directory.Exists(path))
            {
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (FileInfo f in root.GetFiles())
                {
                    if (f.Extension.Equals("." + format1))
                        ImagesFrom.Add(f.FullName);
                }
            }
            else if(File.Exists(path))
            {
                FileInfo f = new FileInfo(path);

                if (f.Extension.Equals("." + format1)) //格式得符合的情况才转换
                {
                    ImagesFrom.Add(path);
                }
            }

            try
            {
                //逐个转换
                foreach (string f in ImagesFrom)
                {
                    FileInfo info = new FileInfo(f);
                    string file2 = info.Directory + "\\" + System.IO.Path.GetFileNameWithoutExtension(f) + "." + format2;

                    int nRet = ConvertImageByPath(f, file2, format1, format2);
                    if (nRet == 0)
                    {
                        File.Delete(f);
                    }
                    else
                        return -1;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 将 pathFrom 的图片文件转换为 pathTo 对应格式的图片文件 
        /// </summary>
        static public bool ConvertImage(string pathImageFrom, string pathImageTo)
        {
            FileInfo f1 = new FileInfo(pathImageFrom);
            FileInfo f2 = new FileInfo(pathImageTo);

            if(f1.Extension.Equals(".svg") && f2.Extension.Equals(".emf"))
            {
                try
                {
                    SvgDocument svg = SvgDocument.Open(pathImageFrom);
                    using (Graphics bufferGraphics = Graphics.FromHwndInternal(IntPtr.Zero))
                    {
                        using (var metafile = new Metafile(pathImageTo, bufferGraphics.GetHdc()))
                        {
                            using (Graphics graphics = Graphics.FromImage(metafile))
                            {
                                svg.Draw(graphics);
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message, Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"unsupported convert [{pathImageFrom}]->[{pathImageTo}]\n\nSupported convert [svg]->[emf]",
                    Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        ///存储临时 emf 文件的路径，后面关闭程序时删除
        static private List<string> listTempEmfFiles = null; 
    }
}
