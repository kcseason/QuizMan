using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;

namespace PDFHelper
{
    public class iText
    {
        public static string ReadPDF(string pdfFilePath)
        {
            // Initialize a PdfReader instance
            using var pdfReader = new PdfReader(pdfFilePath);

            // Initialize a PdfDocument instance using the PdfReader
            using var pdfDoc = new PdfDocument(pdfReader);

            var extractedText = new StringBuilder();

            // Iterate through each page of the document
            for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
            {
                // Get the specific page
                PdfPage page = pdfDoc.GetPage(pageNum);

                // Extract text using PdfTextExtractor and a text extraction strategy
                string pageText = PdfTextExtractor.GetTextFromPage(page, new LocationTextExtractionStrategy());
                extractedText.AppendLine(pageText);
            }

            // Access the extracted text
            return extractedText.ToString();
        }

    }
}
