using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;

namespace BesPrinter
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        //窗口加载
        private void FormMain_Load(object sender, EventArgs e)
        {
            //注：该格式的顺序【必须】和 imageList 的元素一一对应
            formatSet.Add(".bmp");
            formatSet.Add(".png");
            formatSet.Add(".jpg");
            formatSet.Add(".jpeg");
            formatSet.Add(".svg");
            formatSet.Add(".emf");

            //初始化 toolTip
            toolTipDragDrop.SetToolTip(textBoxPath, "提示");
            toolTipDragDrop.SetToolTip(buttonSelectFile, "提示");
            toolTipDragDrop.SetToolTip(buttonSelectFloder, "提示");
        }

        //窗口关闭
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //删除所有可能产生的临时文件
            ImageHelper.ClearTempEmfFiles();
        }

        //选择单个文件
        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "image files (*.bmp,*.png,*jpg,*jpeg,*.svg,*.emf)|*.bmp;*.png;*jpg;*jpeg;*.svg;*.emf";
            openFileDialog.RestoreDirectory = true;
            DialogResult result = openFileDialog.ShowDialog();
            if (DialogResult.OK == result)
            {
                textBoxPath.Text = openFileDialog.FileName;
                loadImageListView(openFileDialog.FileName);
            }
        }

        //选择单个文件夹
        private void buttonSelectFloder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialog.SelectedPath;
                loadImageListView(folderBrowserDialog.SelectedPath);
            }
        }

        //从路径加载图片
        private void loadImageListView(string path)
        {
            //收集符合格式要求的文件，或文件夹下的文件
            listImagePath.Clear();
            if (Directory.Exists(path))
            {
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (FileInfo f in root.GetFiles())
                {
                    if(formatSet.Exists(t => t == f.Extension))
                        listImagePath.Add(f.FullName);
                }
            }
            else if(File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                if (formatSet.Exists(t => t == info.Extension))
                    listImagePath.Add(path);
            }

            //加载所有文件到 listView 中
            listViewImage.Items.Clear();
            for(int i = 0; i < listImagePath.Count; i++)
            {
                FileInfo finfo = new FileInfo(listImagePath[i]);

                int imageIndex = formatSet.IndexOf(finfo.Extension);
                if (imageIndex == -1) //该逻辑应该不会出现
                    imageIndex = formatSet.Count-1;

                ListViewItem item = new ListViewItem();
                item.Text = finfo.Name;
                item.Tag = i;
                item.ToolTipText = listImagePath[i];
                item.ImageIndex = imageIndex;
                
                listViewImage.Items.Add(item);
            }

            //更新打印需要的数据到打印存储队列中
            formPrintSetting.SetPrintingImage(listImagePath);
        }

        //拖拽事件：进入
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;                                                              //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }

        //拖拽事件：拖放
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();       //获得路径
            textBoxPath.Text = path;
            loadImageListView(path);
        }

        //列表项双击事件
        private void ListViewItemDoubleClick(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            var items = listView.SelectedItems;

            //获得第一个选中的 item 的图形下标 
            if (items.Count <= 0)
                return;

            int index = 0;
            foreach (ListViewItem i in items)
            {
                index = (int)i.Tag;
                break;
            }

            //弹框显示对应路径的图片
            //FormViewImage formViewImage = new FormViewImage();
            formViewImage.SetImageForView(listImagePath, index);
            formViewImage.ShowDialog();
        }

        //打印机设置按钮
        private void buttonPrintSetting_Click(object sender, EventArgs e)
        {
            formPrintSetting.ShowDialog();
        }

        //打印
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //预览和打印
            formPrintSetting.PreviewToPrint();
        }

        //保存图片路径
        private List<string> listImagePath = new List<string>();
        //支持的图片格式集合
        private List<string> formatSet = new List<string>();
        
        //窗口
        //查看图片窗口
        private FormViewImage formViewImage = new FormViewImage();
        //打印机设置窗口
        private FormPrintSetting formPrintSetting = new FormPrintSetting();

    }
}
