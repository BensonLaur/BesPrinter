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
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace BesPrinter
{
    public partial class FormMain : Form
    {
        public static ResourceManager resourceManager = new ResourceManager("BesPrinter.FormMain", typeof(FormMain).Assembly);
        public string tr(string name)
        {
            return resourceManager.GetString(name, AppConfig.config.GetCultrueInfo());
        }

        public FormMain(ExeModeManager exeMode)
        {
            InitializeComponent();

            //获得执行模式
            ExeMode = exeMode;

            supportedExtensions = ImageHelper.GetSupportedFormatExtension();

            UpdateBottomStatistics();
            formPrintSetting.SetLabelCurrentBatch(label_current_batch);
        }

        //窗口加载
        private void FormMain_Load(object sender, EventArgs e)
        {
            //toolTipFormMain.SetToolTip(buttonPrint, tr("buttonPrint.ToolTip"));

            //对运行模式做出响应
            //如果是初始路径模式，设定一个初始路径
            if (ExeMode.mode == EXE_MODE.MODE_INIT_PATH)
            {
                textBoxPath.Text = ExeMode.initPath;
                loadImageListView(ExeMode.initPath);

                //隐藏按钮等
                labelPath.Visible = false;
                textBoxPath.Visible = false;
                buttonSelectFile.Visible = false;
                buttonSelectFloder.Visible = false;
            }
            else if(ExeMode.mode == EXE_MODE.MODE_SINGLE_IMAGE)
            {
                textBoxPath.Text = ExeMode.singleImagePath;
                loadImageListView(ExeMode.singleImagePath);

                //直接弹框显示第一张图片的数据,然后关闭后退出
                ShowFirstListItemImageAndExist();
            }
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

                //先收集
                List<string> paths = new List<string>();
                foreach (FileInfo f in root.GetFiles())
                {
                    if (supportedExtensions.Exists(t => t == f.Extension))
                        paths.Add(f.FullName);
                }

                //obsolete:
                //后排序（为了数值字符串能够更好排序，先比较长度，再比较内容）
                //listImagePath = paths.OrderBy(p => p.Length).ThenBy(p => p).ToList();

                //直接按原来顺序排序即可，以免如下顺序被打乱：
                //02_01_1317649=1.emf
                //02_02_1317585.emf
                //02_03_1317775.emf
                listImagePath = paths;
            }
            else if(File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                if (supportedExtensions.Exists(t => t == info.Extension))
                    listImagePath.Add(path);
            }

            //加载所有文件到 listView 中
            listViewImage.Items.Clear();
            for(int i = 0; i < listImagePath.Count; i++)
            {
                FileInfo finfo = new FileInfo(listImagePath[i]);

                int imageIndex = supportedExtensions.IndexOf(finfo.Extension);
                if (imageIndex == -1) //该逻辑应该不会出现
                    imageIndex = supportedExtensions.Count-1;

                ListViewItem item = new ListViewItem();
                item.Text = finfo.Name;
                item.Tag = i;
                item.ToolTipText = listImagePath[i];
                item.ImageIndex = imageIndex;
                
                listViewImage.Items.Add(item);
            }

            //更新打印需要的数据到打印存储队列中
            formPrintSetting.SetPrintingImage(listImagePath);

            //更新底部统计信息
            UpdateBottomStatistics();
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
            formViewImage.SetImageForView(listImagePath, index, false);
            formViewImage.ShowDialog();
        }

        //直接弹框显示第一张图片的数据,然后关闭后退出
        private void ShowFirstListItemImageAndExist()
        {
            var items = listViewImage.Items;

            //获得第一个 item 的图形下标 
            if (items.Count <= 0)
                return;

            formViewImage.SetImageForView(listImagePath, 0, true);
            formViewImage.ShowDialog();
            this.Close();
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
        private List<string> supportedExtensions = new List<string>();
        
        //窗口
        //查看图片窗口
        private FormViewImage formViewImage = new FormViewImage();
        //打印机设置窗口
        private FormPrintSetting formPrintSetting = new FormPrintSetting();

        private ExeModeManager ExeMode = null;

        //刷新显示底部的统计
        private void UpdateBottomStatistics()
        {
            //textBox_count_once.Validating +=

            bool hasData = listImagePath.Count != 0;

            label_total_count_tip.Visible = hasData;
            label_total_count.Visible = hasData;
            checkBox_batch.Visible = hasData;
            label_count_once_tip.Visible = hasData;
            textBox_count_once.Visible = hasData;
            label_current_batch_tip.Visible = hasData;
            label_current_batch.Visible = hasData;
            
            if (hasData)
            {
                //显示总数
                label_total_count.Text = String.Format("{0:D}", listImagePath.Count);

                bool enableBatch = AppConfig.config.GetEnableBatch();
                int countInOneBatch = AppConfig.config.GetCountInOneBatch();

                checkBox_batch.Checked = enableBatch;
                textBox_count_once.Text = String.Format("{0:D}", countInOneBatch);

                int totalBatch = listImagePath.Count == 1 ? 1 : (listImagePath.Count / countInOneBatch + 1);
                label_current_batch.Text = String.Format("({0:D}/{1:D})", 1, totalBatch);

                //根据是否分批次显示更多设置
                label_count_once_tip.Visible = enableBatch;
                textBox_count_once.Visible = enableBatch;
                label_current_batch_tip.Visible = enableBatch;
                label_current_batch.Visible = enableBatch;
            }
        }

        //切换分批次
        private void checkBox_batch_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.config.SetEnableBatch(checkBox_batch.Checked);

            UpdateBottomStatistics();
        }
        //输入了每批次打印数量
        private void textBox_count_once_TextChanged(object sender, EventArgs e)
        {
            int countInOnceBatch = 1;
            try
            {
                countInOnceBatch = Convert.ToInt32(textBox_count_once.Text);
            }
            catch(Exception exception)
            {
                if(textBox_count_once.Text.Length >0)
                    MessageBox.Show(exception.Message, Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Console.WriteLine("exception: " + exception.Message);
            }
            if (countInOnceBatch <= 0)
                countInOnceBatch = 1;

            AppConfig.config.SetCountInOneBatch(countInOnceBatch);
            
            UpdateBottomStatistics();
        }
    }
}
