using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BesPrinter
{
    public partial class FormViewImage : Form
    {
        public FormViewImage()
        {
            InitializeComponent();
        }

        //设置用于显示的数据（外部设置）
        public void SetImageForView(List<string> filePaths, int index)
        {
            listImagePath = filePaths;
            currentIndex = index;

            //如果图片只有1张，上一个和下一个按钮就不显示
            buttonLastOne.Visible = !hasOnlyOne();
            buttonNextOne.Visible = !hasOnlyOne();

            //更新图片信息，包括标题和图片缓存（在下标的改变之后）
            UpdateImageInfo();
        }

        //只有一张图片
        private bool hasOnlyOne()
        {
            return (listImagePath == null || listImagePath.Count <= 1);
        }

        //显示窗口之后，触发一次重新布局
        private void FormViewImage_Shown(object sender, EventArgs e)
        {
            LayoutControl();

            //#TODO 第一次显示不了图片问题
            //尝试过在很多响应函数刷新图形的显示，即使是在非常靠后执行的 FormViewImage_Shown 中 触
            //发 RefleshImage()，还是显示不了第一次的图像
            //
            //实在没办法，决定定时器 100 mm 后触发刷新
            timerOnFirstRefresh.Start();
        }

        //为了第一次的刷新而设定的定时器
        private void timerOnFirstRefresh_Tick(object sender, EventArgs e)
        {
            //刷新图片显示
            RefleshImage();

            //只为了刷新一次，所以定时器立刻关闭
            timerOnFirstRefresh.Stop();
        }

        //尺寸改变事件
        private void FormViewImage_SizeChanged(object sender, EventArgs e)
        {
            LayoutControl();
        }

        //布局控件
        private void LayoutControl()
        {
            var bounds = this.Bounds;
            this.pictureBox.Size = new System.Drawing.Size(bounds.Width - 40, bounds.Height - 100);
            this.buttonLastOne.Location = new System.Drawing.Point(12 + pictureBox.Size.Width / 2 - 35, bounds.Height - 80);
            this.buttonNextOne.Location = new System.Drawing.Point(12 + pictureBox.Size.Width / 2 + 3, bounds.Height - 80);

            //修改布局之后
            //刷新图片显示
            RefleshImage();
        }

        //更新图片信息，包括标题和图片缓存（在下标的改变之后）
        private void UpdateImageInfo()
        {
            //更新标题
            UpdateTitle();

            //重新得到缓存图片
            RebufferImage();
        }

        //更新标题
        private void UpdateTitle()
        {
            int index = ValidatedIndex();
            if (index < 0)
                return;
            
            //更改标题
            FileInfo info = new FileInfo(listImagePath[index]);
            this.Text = hasOnlyOne() ? $"{info.Name}" : $"{info.Name} ({index + 1} / {listImagePath.Count})";
        }

        //刷新图片显示
        private void RefleshImage()
        {
            int index = ValidatedIndex();
            if (index < 0)
                return;

            //获得绘制的位置
            GraphicsUnit unit = GraphicsUnit.Millimeter;
            RectangleF rectImage = imageBuffer.GetBounds(ref unit);
            RectangleF rectContainer = pictureBox.Bounds;
            RectangleF rectDraw = ImageHelper.GetKeepRadioRect(rectImage, rectContainer, 10, 10, 10, 10);

            //绘制图片到 pictureBox 上
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.FromArgb(0XFF, 0XCC, 0XCC, 0XCC));
            g.DrawImage(imageBuffer, rectDraw);
        }

        //重新缓存图片
        private void RebufferImage()
        {
            //及时释放已有的从 ImageHelper.LoaderImage 得到的 imageBuffer，这样程序关闭时才能正常删除临时文件
            if (imageBuffer != null)
            {
                imageBuffer.Dispose();
                imageBuffer = null;
            }

            int index = ValidatedIndex();
            if (index < 0)
            {
                //无效，得到一个默认图片
                imageBuffer = ImageHelper.LoaderImage(null);
            }
            else
            {             
                //读取有效的图片数据
                imageBuffer = ImageHelper.LoaderImage(listImagePath[index]);
            }
        }

        //获得经过校验的下标 (大于等于0)，数据无效时返回 -1
        private int ValidatedIndex()
        {
            //校验数据
            if (listImagePath == null)
                return -1;

            if (currentIndex < 0 || currentIndex >= listImagePath.Count)
                currentIndex = 0;

            return currentIndex;
        }

        //查看上一张图片
        private void buttonLastOne_Click(object sender, EventArgs e)
        {
            //校验数据
            if (listImagePath == null)
                return;

            //得到上一张图片下标
            int preIndex = 0;
            if (currentIndex == 0)
                preIndex = listImagePath.Count - 1;
            else
                preIndex = currentIndex - 1;

            //如果下标改变，更新图片
            if (preIndex != currentIndex)
            {
                currentIndex = preIndex;

                //更新图片信息，包括标题和图片缓存（在下标的改变之后）
                UpdateImageInfo();
                
                //刷新显示
                RefleshImage();
            }
        }

        //查看下一张图片
        private void buttonNextOne_Click(object sender, EventArgs e)
        {
            //校验数据
            if (listImagePath == null)
                return;

            //得到下一张图片下标
            int nextIndex = 0;
            if (currentIndex + 1 == listImagePath.Count)
                nextIndex = 0;
            else
                nextIndex = currentIndex + 1;

            //如果下标改变，更新图片
            if(nextIndex != currentIndex)
            {
                currentIndex = nextIndex;

                //更新图片信息，包括标题和图片缓存（在下标的改变之后）
                UpdateImageInfo();
                
                //刷新显示
                RefleshImage();
            }
        }

        //关闭窗口前要释放从 ImageHelper.LoaderImage 得到的 imageBuffer，这样程序关闭时才能正常删除临时文件
        private void FormViewImage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imageBuffer != null)
            {
                imageBuffer.Dispose();
                imageBuffer = null;
            }
        }

        //查看的数据的信息
        private List<string> listImagePath = null;
        private int currentIndex = 0;
        private Image imageBuffer = null;

    }
}
