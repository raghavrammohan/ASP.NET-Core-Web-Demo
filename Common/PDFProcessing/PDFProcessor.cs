using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using Docnet.Core;
using Docnet.Core.Models;
using Docnet.Core.Converters;
using System.IO;

namespace Common.PDFProcessing
{
    public class PDFProcessor : IPDFProcessor
    {
        public void generatePDF()
        {
            string filename1 = "C:\\MicroservicesRaghav\\one.pdf";
            string filename2 = "C:\\MicroservicesRaghav\\two.pdf";
            // Open the input files
            PdfDocument inputDocument1 = PdfReader.Open(filename1, PdfDocumentOpenMode.Import);
            PdfDocument inputDocument2 = PdfReader.Open(filename2, PdfDocumentOpenMode.Import);

            // Create the output document
            PdfDocument outputDocument = new PdfDocument();

            // Show consecutive pages facing. Requires Acrobat 5 or higher.
            outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;

            XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Center;
            format.LineAlignment = XLineAlignment.Far;
            XGraphics gfx;
            XRect box;
            int count = Math.Max(inputDocument1.PageCount, inputDocument2.PageCount);
            for (int idx = 0; idx < count; idx++)
            {
                // Get page from 1st document
                PdfPage page1 = inputDocument1.PageCount > idx ?
                  inputDocument1.Pages[idx] : new PdfPage();

                // Get page from 2nd document
                PdfPage page2 = inputDocument2.PageCount > idx ?
                  inputDocument2.Pages[idx] : new PdfPage();

                // Add both pages to the output document
                page1 = outputDocument.AddPage(page1);
                page2 = outputDocument.AddPage(page2);

                // Write document file name and page number on each page
                gfx = XGraphics.FromPdfPage(page1);
                box = page1.MediaBox.ToXRect();
                box.Inflate(0, -10);
                gfx.DrawString(String.Format("{0} • {1}", filename1, idx + 1),
                  font, XBrushes.Red, box, format);

                gfx = XGraphics.FromPdfPage(page2);
                box = page2.MediaBox.ToXRect();
                box.Inflate(0, -10);
                gfx.DrawString(String.Format("{0} • {1}", filename2, idx + 1),
                  font, XBrushes.Red, box, format);
            }

            // Save the document...
            string fileName = "C:\\MicroservicesRaghav\\Temp\\combined.pdf";
            outputDocument.Save(fileName);
        }

        public void processPDF()
        {
            // Get a fresh copy of the sample PDF file
            const string filename = "C:\\MicroservicesRaghav\\multipage.pdf";
            File.Copy(filename, "C:\\MicroservicesRaghav\\Temp\\multipage.pdf", true);

            // Open the file
            PdfDocument inputDocument = PdfReader.Open(filename, PdfDocumentOpenMode.Import);

            string name = Path.GetFileNameWithoutExtension(filename);
            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                // Create new document
                string fileName = "C:\\MicroservicesRaghav\\Temp\\" + String.Format("{0} - Page {1}_tempfile.pdf", name, idx + 1);
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Version = inputDocument.Version;
                outputDocument.Info.Title =
                  String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
                outputDocument.Info.Creator = inputDocument.Info.Creator;

                // Add the page and save it
                outputDocument.AddPage(inputDocument.Pages[idx]);
                outputDocument.Save(fileName);

                PdfPage page = inputDocument.Pages[idx];
                //paths
                string pathPdf = "C:\\MicroservicesRaghav\\Temp\\" + String.Format("{0} - Page {1}_tempfile.pdf", name, idx + 1);
                string finalPathWithFileName = "C:\\MicroservicesRaghav\\Temp\\" + String.Format("{0} - Page {1}_tempfile.png", name, idx + 1);
                try {
                    //using docnet
                    using (var docReader = DocLib.Instance.GetDocReader(pathPdf, new PageDimensions(4)))
                    {
                        //open pdf file
                        using (var pageReader = docReader.GetPageReader(0))
                        {

                            var rawBytes = pageReader.GetImage(new NaiveTransparencyRemover(255,255,255));
                            var width = pageReader.GetPageWidth();
                            var height = pageReader.GetPageHeight();
                            var characters = pageReader.GetCharacters();
                            ////using bitmap to create a png image
                            using (var bmp = new Bitmap(width, height, PixelFormat.Format32bppRgb))
                            {
                                AddBytes(bmp, rawBytes);
                                using (var stream = new MemoryStream())
                                {

                                    bmp.Save(stream, ImageFormat.Png);
                                    //Bitmap resized = new Bitmap(bmp, new Size(bmp.Width / 4, bmp.Height / 4));
                                    //resized.Save(stream, ImageFormat.Png);
                                    File.WriteAllBytes(finalPathWithFileName, stream.ToArray());
                                };
                            };
                        };
                    };



                }
                catch (Exception e) { 
                }
                }

        }

        //extra methods
        private static void AddBytes(Bitmap bmp, byte[] rawBytes)
        {
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            var bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);
            var pNative = bmpData.Scan0;

            Marshal.Copy(rawBytes, 0, pNative, rawBytes.Length);
            bmp.UnlockBits(bmpData);
        }

    }
}
