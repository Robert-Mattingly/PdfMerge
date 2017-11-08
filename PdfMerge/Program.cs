using Newtonsoft.Json;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdfFiles = inputs.Select(path => PdfReader.Open(path, PdfDocumentOpenMode.Import));

            var outDoc = new PdfDocument();

            foreach (var doc in pdfFiles)
                outDoc = outDoc.WithPagesFrom(doc);

            outDoc.Save(output);
        }



        private static IEnumerable<string> inputs = new string[]
        {
            @"D:\Sandbox\Page1.pdf",
            @"D:\Sandbox\Page2.pdf",
            @"D:\Sandbox\Page3.pdf",
            @"D:\Sandbox\Page2.pdf"
        };
        private static string output = @"D:\Sandbox\Combined.pdf";
    }

    public static class PdfExtensions
    {
        public static PdfDocument WithPagesFrom(this PdfDocument doc, PdfDocument source)
        {
            foreach (PdfPage page in source.Pages)
                doc.AddPage(page);

            return doc;
        }
    }
}
