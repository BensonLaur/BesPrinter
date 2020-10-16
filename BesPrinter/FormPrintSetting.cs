using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BesPrinter
{
    public partial class FormPrintSetting : Form
    {
        public FormPrintSetting()
        {
            InitializeComponent();

            //恢复 printDocument
            saver = JsonSerializer<PrintDocumentSaver>.Load();
            if (saver == null)
            {
                //读取失败 或者 初次初始化，使用 默认的 printDocument 初始化配置
                saver = new PrintDocumentSaver();
                saver.KeepRatio = true; //默认保持比例居中
                saver.SaveFromPrintDocument(printDocument);
            }
            else
            {
                //成功读取则恢复
                saver.RestoreToPrintDocument(printDocument);
            }
            
            //添加打印过程处理
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
        }

        /// <summary>
        /// 加载窗口
        /// </summary>
        private void FormPrintSetting_Load(object sender, EventArgs e)
        {
            //更新打印机界面数据
            UpdatePrinterControl();
        }

        /// <summary>
        /// 更新打印机控件显示
        /// </summary>
        private void UpdatePrinterControl()
        {
            //显示当前选中的打印机
            comboBoxPrinter.Items.Clear();
            string currentPrinterName = printDocument.PrinterSettings.PrinterName;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxPrinter.Items.Add(printer);

                if (printer.Equals(currentPrinterName))//把默认打印机设为缺省值
                {
                    comboBoxPrinter.SelectedIndex = comboBoxPrinter.Items.IndexOf(currentPrinterName);
                }
            }

            //显示打印使用的页面
            comboBoxPaper.Items.Clear();
            var selectedPaperSize = printDocument.DefaultPageSettings.PaperSize;
            foreach (PaperSize ps in printDocument.PrinterSettings.PaperSizes)
            {
                comboBoxPaper.Items.Add(ps.PaperName);
                if (selectedPaperSize.PaperName.Equals(ps.PaperName))
                {
                    comboBoxPaper.SelectedIndex = comboBoxPaper.Items.IndexOf(selectedPaperSize.PaperName);
                }
            }

            //显示距边设置数据
            textBoxMarginLeft.Text = $"{saver.MarginsCustom.Left}";
            textBoxMarginRight.Text = $"{saver.MarginsCustom.Right}";
            textBoxMarginTop.Text = $"{saver.MarginsCustom.Top}";
            textBoxMarginBottom.Text = $"{saver.MarginsCustom.Bottom}";

            //按比例缩放居中设置
            checkBoxKeepRadio.Checked = saver.KeepRatio;
        }

        /// <summary>
        /// 打印页面大小发生改变
        /// </summary>
        private void comboBoxPaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据当前选中的名称，更改设置
            string currentPaperName = (string)comboBoxPaper.SelectedItem;
            foreach (PaperSize ps in printDocument.PrinterSettings.PaperSizes)
            {
                if(ps.PaperName.Equals(currentPaperName))
                {
                    printDocument.DefaultPageSettings.PaperSize = ps;
                    break;
                }
            }

            SaveConfig();
        }

        /// <summary>
        /// 左边距设置发生改变
        /// </summary>
        private void textBoxMarginLeft_TextChanged(object sender, EventArgs e)
        {
            try
            {
                saver.MarginsCustom.Left = int.Parse(textBoxMarginLeft.Text);
            }
            catch (Exception)
            {
                saver.MarginsCustom.Left = 2;
            }
            SaveConfig();
        }

        /// <summary>
        /// 右边距设置发生改变
        /// </summary>
        private void textBoxMarginRight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                saver.MarginsCustom.Right = int.Parse(textBoxMarginRight.Text);
            }
            catch (Exception)
            {
                saver.MarginsCustom.Right = 2;
            }
            SaveConfig();
        }

        /// <summary>
        /// 上边距设置发生改变
        /// </summary>
        private void textBoxMarginTop_TextChanged(object sender, EventArgs e)
        {
            try
            {
                saver.MarginsCustom.Top = int.Parse(textBoxMarginTop.Text);
            }
            catch (Exception)
            {
                saver.MarginsCustom.Top = 2;
            }
            SaveConfig();
        }

        /// <summary>
        /// 下边距设置发生改变
        /// </summary>
        private void textBoxMarginBottom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                saver.MarginsCustom.Bottom = int.Parse(textBoxMarginBottom.Text);
            }
            catch (Exception)
            {
                saver.MarginsCustom.Bottom = 2;
            }
            SaveConfig();
        }

        /// <summary>
        /// 按比例缩放设置发生改变
        /// </summary>
        private void checkBoxKeepRadio_CheckedChanged(object sender, EventArgs e)
        {
            saver.KeepRatio = checkBoxKeepRadio.Checked;
            SaveConfig();
        }

        /// <summary>
        /// 保存打印机设置
        /// </summary>
        private void SaveConfig()
        {
            saver.SaveFromPrintDocument(printDocument);
            JsonSerializer<PrintDocumentSaver>.Save(saver);
        }

        /// <summary>
        /// 设置需要打印的图片
        /// </summary>
        public void SetPrintingImage(List<string> listImagePaths)
        {
            listImagePath = listImagePaths;
            indexPrinting = 0;
        }

        /// <summary>
        /// 预览和打印（弹出 “打印预览” 框）
        /// </summary>
        public void PreviewToPrint()
        {
            if (listImagePath == null || listImagePath.Count == 0)
            {
                MessageBox.Show(Trans.tr("NoPrintableFile"), Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();
            }
            catch
            {
                //根据反馈, 出现过如下异常
                //具体原因不明，不过通过正确设置打印机，解决该问题，所以在此提示 “请先正确设置打印机”
                /*
                    System.InvalidOperationException: Form that is already displayed modally cannot be displayed as a modal dialog box. Close the form before calling showDialog.
                       at System.Windows.Forms.Form.ShowDialog(IWin32Window owner)
                       at System.Windows.Forms.Form.ShowDialog()
                       at BesPrinter.FormPrintSetting.PreviewToPrint()
                       at BesPrinter.FormMain.buttonPrint_Click(Object sender, EventArgs e)
                */
                MessageBox.Show(Trans.tr("PleaseSettingPrinterFirst"), Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        /// <summary>
        /// 打印过程处理
        /// </summary>
        private void PrintPage(object sender, PrintPageEventArgs args)
        {
            //没有数据，直接返回
            if(listImagePath == null || listImagePath.Count == 0)
            {
                args.HasMorePages = false;
                return;
            }

            //处理当前页面数据
            Image pageImage = null;
            try
            {
                //获得需要打印的数据
                string fileName = listImagePath[indexPrinting];
                pageImage = ImageHelper.LoaderImage(fileName);
                
                //获得打印位置信息
                GraphicsUnit unit = GraphicsUnit.Millimeter;
                RectangleF rectImage = pageImage.GetBounds(ref unit);
                RectangleF rectContainer = args.PageBounds;
                RectangleF rectDraw = rectContainer; //初始值
                
                //根据是否缩放设置，获得对应的绘制区域
                if (saver.KeepRatio)
                {
                    rectDraw = ImageHelper.GetKeepRadioRect(rectImage, rectContainer,
                                            saver.MarginsCustom.Left, saver.MarginsCustom.Right,
                                            saver.MarginsCustom.Top, saver.MarginsCustom.Bottom);
                }
                else
                {
                    rectDraw = ImageHelper.GetContainerMarginRect(rectContainer,
                                            saver.MarginsCustom.Left, saver.MarginsCustom.Right,
                                            saver.MarginsCustom.Top, saver.MarginsCustom.Bottom);
                }
                
                //绘制
                args.Graphics.DrawImage(pageImage, rectDraw);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Trans.tr("Tip"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //调用 ImageHelper.LoaderImage(fileName) 后要求使用完立刻释放图片资源
                if (null != pageImage)
                    pageImage.Dispose();
            }

            //分析是否有下一页
            ++indexPrinting;
            if(indexPrinting == listImagePath.Count)
            {
                args.HasMorePages = false;
                indexPrinting = 0;
            }
            else
            {
                args.HasMorePages = true;
            }
        }

        /// <summary>
        /// 设置打印机（弹出 “打印” 框）
        /// </summary>
        private void buttonSettingPrinter_Click(object sender, EventArgs e)
        {
            printDialog.AllowSomePages = true;
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                //预览和打印
                PreviewToPrint();
                //printDocument.Print();
            }

            //弹框设置了参数后，需要更新界面显示的参数（更新过程一定会触发 combobox 改变，从而保存参数）
            UpdatePrinterControl();
        }


        //需要保存的配置
        private PrintDocumentSaver saver = null;
        //需要打印的图片路径
        private List<string> listImagePath = null;
        //标记当前打印的图片的对应下标
        private int indexPrinting = 0;
        
    }
}
