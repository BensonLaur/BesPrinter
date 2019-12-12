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
                        MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        ///存储临时 emf 文件的路径，后面关闭程序时删除
        static private List<string> listTempEmfFiles = null; 
    }
}
