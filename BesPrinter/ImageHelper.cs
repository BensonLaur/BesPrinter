using Svg;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BesPrinter
{
    class ImageHelper
    {
        //加载路径下的一张图片，读取失败或格式不支持返回一张默认图片
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
                        }
                    }
                    finally
                    {
                        image = new Metafile(emfTempPath); //读取 emf 文件
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

        //根据当前图像的外接矩形和容器的外接矩形，以及提供的距边参数，计算得到按比例缩放的位置的外接矩形
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

    }
}
