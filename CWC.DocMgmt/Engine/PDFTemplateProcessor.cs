using CWC.DocMgmt.Repository;
using Docnet.Core.Converters;
using Docnet.Core.Models;
using Docnet.Core;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using Rectangle = System.Drawing.Rectangle;

namespace CWC.DocMgmt.Engine
{
    public class PDFTemplateProcessor
    {
        public JsonObject processTemplate(String pdfTemplateFileName)
        {
            IDocRepository docRepos = DocRepoFactory.getDocumentRepository();
            JsonObject templateInfo = new JsonObject();
            templateInfo.Add("pages", new JsonArray());

            // Open the file
            PdfDocument inputDocument = PdfReader.Open(pdfTemplateFileName, PdfDocumentOpenMode.Import);

            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                string pagePDFFileName = docRepos.getLocalTempFile();
                string pageImageFileName = docRepos.getLocalTempFile();

                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Version = inputDocument.Version;

                // Add the page and save it
                outputDocument.AddPage(inputDocument.Pages[idx]);
                outputDocument.Save(pagePDFFileName);

                //using docnet
                using (var docReader = DocLib.Instance.GetDocReader(pagePDFFileName, new PageDimensions(2.67)))
                {
                    //open pdf file
                    using (var pageReader = docReader.GetPageReader(0))
                    {

                        var rawBytes = pageReader.GetImage(new NaiveTransparencyRemover(255, 255, 255));
                        var width = pageReader.GetPageWidth();
                        var height = pageReader.GetPageHeight();
                        var characters = pageReader.GetCharacters();

                        JsonObject pageInfo = new JsonObject();
                        templateInfo["pages"] = pageInfo;

                        pageInfo.Add("pagePDFHandle", docRepos.putDocument(pagePDFFileName));
                        pageInfo.Add("pageImageHandle", docRepos.putDocument(pageImageFileName));
                        pageInfo.Add("pageWidth", width / 72.0f);
                        pageInfo.Add("pageHeight", height / 72.0f);

                        ////using bitmap to create a png image
                        using (var bmp = new Bitmap(width, height, PixelFormat.Format32bppRgb))
                        {
                            AddBytes(bmp, rawBytes);
                            using (var stream = new MemoryStream())
                            {
                                bmp.Save(stream, ImageFormat.Png);
                                File.WriteAllBytes(pageImageFileName, stream.ToArray());
                            }
                        };
                    };
                };

                File.Delete(pagePDFFileName);
                File.Delete(pageImageFileName);
            }

            return templateInfo;
        }

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
