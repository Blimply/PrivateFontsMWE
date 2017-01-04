using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportLibrary2;
using Telerik.Reporting;
using Telerik.Reporting.Processing;



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ExportToPDF();
        }

        static void ExportToPDF()
        {
            var fontInstalled = false;

            ReportProcessor processor = new ReportProcessor();
            Report1 report = new Report1();
            System.Collections.Hashtable deviceInfo = new System.Collections.Hashtable();
            deviceInfo["FontEmbedding"] = "Full";
            RenderingResult result = processor.RenderReport("PDF", new InstanceReportSource { ReportDocument = report }, deviceInfo);
            string filePath = string.Format("C:\\ReportTest\\Report-{0}-FontInstalled-{1}.pdf", DateTime.Now.ToString("yyyy-MM-d--HH-mm-ss"),fontInstalled);
            using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
            }
        }

    }
}
