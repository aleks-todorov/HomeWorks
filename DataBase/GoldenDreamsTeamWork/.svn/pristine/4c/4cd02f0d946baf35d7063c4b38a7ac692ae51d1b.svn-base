using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;

namespace PDFCreator.Classes
{
    public class PDFCreator
    {
        private decimal totalSum;
        private readonly Document doc = new Document();
        private PdfPTable table;
        private int tableColls;

        public string Path { get; set; }

        public PDFCreator(string path)
        {
            this.Path = path;
        }

        public void CreatePDF(string fileName)
        {
            PdfWriter.GetInstance(this.doc, new FileStream(this.Path + "/" + fileName + ".pdf", FileMode.Create));
            doc.Open();
        }

        public void CreateTable(int tableColls)
        {
            table = new PdfPTable(tableColls);
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            this.tableColls = tableColls;
            this.totalSum = 0;
        }

        public void AddNewParagraph(string text)
        {
            doc.Open();
            doc.Add(new Paragraph(text));
            doc.Close();
        }

        public void AddTableHeader(string text, int collSpan)
        {
            var cell = new PdfPCell(new Phrase(text));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(217, 217, 217, 0);
            cell.Colspan = collSpan;
            cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right 
            table.AddCell(cell);
        }

        public void AddColumnNames(string[] names)
        {

            foreach (var name in names)
            {

                var fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, iTextSharp.text.Font.BOLD);
                var titleChunk = new Chunk(name, fontBold);

                var phrase = new Phrase(titleChunk);
                var cell = new PdfPCell(phrase);
                cell.BackgroundColor = new iTextSharp.text.BaseColor(217, 217, 217, 0);
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);
            }
        }

        public void AddContent(string[] content)
        {
            decimal price = 0;
            decimal quantity = 0;

            for (int i = 0; i < content.Length; i++)
            {
                //Current possition of the Price cell
                if (i == 2)
                {
                    price = decimal.Parse(content[i]);
                }
                //Current possition of the Quantity cell
                else if (i == 3)
                {
                    string[] value = content[i].Split(new char[] { ' ' });
                    quantity = decimal.Parse(value[0]);
                }

                var cell = new PdfPCell(new Phrase(content[i]));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);
            }

            this.totalSum += price * quantity;
        }

        public void AddTotalSum()
        {
            var cell = new PdfPCell(new Phrase("Total Sum: "));
            cell.Colspan = tableColls - 1;
            cell.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right 
            this.table.AddCell(cell);

            var fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, iTextSharp.text.Font.BOLD);
            var titleChunk = new Chunk(totalSum.ToString("C2", CultureInfo.CurrentCulture), fontBold);
            var phrase = new Phrase(titleChunk);
            var totalSumCell = new PdfPCell(phrase);
            totalSumCell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right 
            this.table.AddCell(totalSumCell);
        }

        public void AddTable()
        {
            AddTotalSum();
            doc.Add(table);
        }

        public void CloseFile()
        {
            doc.Close();
        }
    }
}
