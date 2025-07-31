
namespace PDFHelper
{
    public class IronPDF
    {
        public static string ReadPDF(string pdfFilePath)
        {
            // Load the PDF document
            var pdfDocument = PdfDocument.FromFile(pdfFilePath);

            // Extract all text from the PDF
            return pdfDocument.ExtractAllText();
        }

    }
}
