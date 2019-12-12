using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BesPrinter
{

    //用于储存和恢复 PrintDocument 配置
    class PrintDocumentSaver
    {
        /// <summary>
        /// 从 PrintDocument 提取要保存的数据
        /// </summary>
        public void SaveFromPrintDocument(PrintDocument d)
        {
            //public PageSettings DefaultPageSettings { get; set; }
            Color             = d.DefaultPageSettings.Color            ;
            Landscape         = d.DefaultPageSettings.Landscape        ;
            Margins           = d.DefaultPageSettings.Margins          ;
            PaperSize         = d.DefaultPageSettings.PaperSize        ;
            PaperSource       = d.DefaultPageSettings.PaperSource      ;
            PrinterResolution = d.DefaultPageSettings.PrinterResolution;

            //public PrinterSettings PrinterSettings { get; set; }
            Collate           = d.PrinterSettings.Collate      ;
            Copies            = d.PrinterSettings.Copies       ;
            Duplex            = d.PrinterSettings.Duplex       ;
            FromPage          = d.PrinterSettings.FromPage     ;
            MaximumPage       = d.PrinterSettings.MaximumPage  ;
            MinimumPage       = d.PrinterSettings.MinimumPage  ;
            PrinterName       = d.PrinterSettings.PrinterName  ;
            //PrintFileName     = d.PrinterSettings.PrintFileName;
            PrintRange        = d.PrinterSettings.PrintRange   ;
            PrintToFile       = d.PrinterSettings.PrintToFile  ;
            ToPage            = d.PrinterSettings.ToPage       ;
            
            DocumentName = d.DocumentName;
            OriginAtMargins = d.OriginAtMargins;

            //public PrinterSettings PrinterSettings { get; set; } //同上

            if(MarginsCustom == null)
                MarginsCustom = new Margins(2, 2, 2, 2);
        }

        /// <summary>
        /// 将数据恢复到 PrintDocument 中
        /// </summary>
        public void RestoreToPrintDocument(PrintDocument d)
        {
            //public PageSettings DefaultPageSettings { get; set; }
            d.DefaultPageSettings.Color             = Color             ;
            d.DefaultPageSettings.Landscape         = Landscape         ;
            d.DefaultPageSettings.Margins           = Margins           ;
            d.DefaultPageSettings.PaperSize         = PaperSize         ;
            d.DefaultPageSettings.PaperSource       = PaperSource       ;
            d.DefaultPageSettings.PrinterResolution = PrinterResolution ;
            
            //public PrinterSettings PrinterSettings { get; set; }
            d.DefaultPageSettings.PrinterSettings.Collate        = Collate      ;
            d.DefaultPageSettings.PrinterSettings.Copies         = Copies       ;
            d.DefaultPageSettings.PrinterSettings.Duplex         = Duplex       ;
            d.DefaultPageSettings.PrinterSettings.FromPage       = FromPage     ;
            d.DefaultPageSettings.PrinterSettings.MaximumPage    = MaximumPage  ;
            d.DefaultPageSettings.PrinterSettings.MinimumPage    = MinimumPage  ;
            d.DefaultPageSettings.PrinterSettings.PrinterName    = PrinterName  ;
            //d.DefaultPageSettings.PrinterSettings.PrintFileName  = PrintFileName;
            d.DefaultPageSettings.PrinterSettings.PrintRange     = PrintRange   ;
            d.DefaultPageSettings.PrinterSettings.PrintToFile    = PrintToFile  ;
            d.DefaultPageSettings.PrinterSettings.ToPage         = ToPage       ;
            
            d.DocumentName = DocumentName;
            d.OriginAtMargins = OriginAtMargins;

            //public PrinterSettings PrinterSettings { get; set; } //同上

            if (MarginsCustom == null)
                MarginsCustom = new Margins(2, 2, 2, 2);
        }
        
        //public PageSettings DefaultPageSettings { get; set; }
        public bool Color { get; set; }
        public bool Landscape { get; set; }
        public Margins Margins { get; set; }
        public PaperSize PaperSize { get; set; }
        public PaperSource PaperSource { get; set; }
        public PrinterResolution PrinterResolution { get; set; }

        //public PrinterSettings PrinterSettings { get; set; }
        public bool Collate { get; set; }
        public short Copies { get; set; }
        public Duplex Duplex { get; set; }
        public int FromPage { get; set; }
        public int MaximumPage { get; set; }
        public int MinimumPage { get; set; }
        public string PrinterName { get; set; }
        public string PrintFileName { get; set; }
        public PrintRange PrintRange { get; set; }
        public bool PrintToFile { get; set; }
        public int ToPage { get; set; }
        //end of PrinterSettings

        //end of PageSetting

        public string DocumentName { get; set; }
        public bool OriginAtMargins { get; set; }

        //public PrintController PrintController { get; set; } //没有可 get set 成员

        //public PrinterSettings PrinterSettings { get; set; } //同上

        //自定义的其他打印属性
        public Margins MarginsCustom { get; set; }    //自定义的4个边距
        public bool keepRatio { get; set; }           //是否源保持比例居中
    }
}
