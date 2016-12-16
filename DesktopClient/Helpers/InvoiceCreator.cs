using System;
using System.Text;
using DomainModel.DataContracts;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;

namespace DesktopClient.Helpers
{
    internal class InvoiceCreator
    {
        private Document document;
        private TextFrame addressFrame;
        private Table table;

        private Color TableBorder = new Color(51, 102, 255);
        private Color TableBlue = new Color(77, 166, 255);
        private Color TableGray = new Color(194, 214, 214);

        public Document CreateDocument(CheckInDto checkIn, string managerName)
        {
            // Create a new MigraDoc document
            document = new Document();
            document.Info.Title = "Invoice";
            document.Info.Subject = "Hostel invoice.";
            document.Info.Author = managerName;


            DefineStyles();

            CreatePage();

            FillContent(checkIn, managerName);

            return document;
        }

        private void DefineStyles()
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal
            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        private void CreatePage()
        {
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();

            // Create footer
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("Hostel · Sample Street · Warsaw · Poland");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Create the text frame for the address
            addressFrame = section.AddTextFrame();
            addressFrame.Height = "3.0cm";
            addressFrame.Width = "7.0cm";
            addressFrame.Left = ShapePosition.Left;
            addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            addressFrame.Top = "5.0cm";
            addressFrame.RelativeVertical = RelativeVertical.Page;

            // Put sender in address frame
            paragraph = addressFrame.AddParagraph("Hostel · Sample Street  · Warsaw");
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 7;
            paragraph.Format.SpaceAfter = 3;

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("INVOICE", TextFormat.Bold);
            paragraph.AddTab();
            paragraph.AddText("Warsaw, ");
            paragraph.AddDateField("dd.MM.yyyy");

            // Create the item table
            table = section.AddTable();
            table.Style = "Table";
            table.Borders.Color = TableBorder;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            // Before you can add a row, you must define the columns
            Column column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = TableBlue;
            row.Cells[0].AddParagraph("Item");
            row.Cells[0].Format.Font.Bold = false;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].MergeDown = 1;
            row.Cells[1].AddParagraph("Guests");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].MergeRight = 3;
            row.Cells[7].AddParagraph("Price");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[7].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[7].MergeDown = 1;

            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = TableBlue;
            row.Cells[1].AddParagraph("Room number");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].AddParagraph("Bed type");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].AddParagraph("Bathroom type");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].AddParagraph("Room size");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[5].AddParagraph("Arriving date");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[6].AddParagraph("Depature date");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
        }


        private void FillContent(CheckInDto checkIn, String managerName)
        {
            // Fill address in address text frame

            Paragraph paragraph = addressFrame.AddParagraph();
            paragraph.AddText(managerName);
            paragraph.AddLineBreak();
            paragraph.AddText("Hostel · Sample Street");
            paragraph.AddLineBreak();
            paragraph.AddText("00-000" + " " + "Warsaw");

            string arrivingDate = checkIn.ArrivingDate.ToShortDateString();
            string departureDate = checkIn.DepartureDate.ToShortDateString();
            string bedroom = checkIn.Bedroom.Number.ToString();
            StringBuilder guestsStringBuilder = new StringBuilder();
            foreach (var guest in checkIn.Guests)
            {
                guestsStringBuilder.Append(guest.Name + " " + guest.Surname + "\n");
            }
            string guests = guestsStringBuilder.ToString();
            string size = checkIn.Bedroom.Size.ToString();
            string bathroomType = checkIn.Bedroom.BathroomType.Name;
            string bedType = checkIn.Bedroom.BedType.Name;
            string price = (checkIn.Bedroom.Price*(checkIn.DepartureDate - checkIn.ArrivingDate).Days).ToString();


            Row row1 = table.AddRow();
            Row row2 = table.AddRow();
            row1.TopPadding = 1.5;
            row1.Cells[0].Shading.Color = TableGray;
            row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row1.Cells[0].MergeDown = 1;
            row1.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row1.Cells[1].MergeRight = 3;
            row1.Cells[7].Shading.Color = TableGray;
            row1.Cells[7].MergeDown = 1;

            row1.Cells[0].AddParagraph("1");
            paragraph = row1.Cells[1].AddParagraph();
            paragraph.AddFormattedText(guests);
            row2.Cells[1].AddParagraph(bedroom);
            row2.Cells[2].AddParagraph(bedType);
            row2.Cells[3].AddParagraph(bathroomType);
            row2.Cells[4].AddParagraph(size);
            row2.Cells[5].AddParagraph(arrivingDate);
            row2.Cells[6].AddParagraph(departureDate);


            row1.Cells[7].AddParagraph(price + " €");
            row1.Cells[7].VerticalAlignment = VerticalAlignment.Bottom;

            // Add an invisible row as a space line to the table
            Row row = table.AddRow();
            row.Borders.Visible = false;

            // Add the total price row
            row = table.AddRow();
            row.Cells[0].Borders.Visible = false;
            row.Cells[0].AddParagraph("Total Price");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[0].MergeRight = 6;
            row.Cells[7].AddParagraph(price + " €");
        }
    }
}
