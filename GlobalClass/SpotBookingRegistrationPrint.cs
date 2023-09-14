using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

using Hindustancopperlimited.GlobalClass;
using Hindustancopperlimited.Models;

using System.Data;
using System.Data.SqlClient;
using iTextSharp.text.pdf.draw;




    public class SpotBookingRegistrationPrint
    {

        const string FONTNAME_NORMAL = BaseFont.HELVETICA;
        const string FONTNAME_BOLD = BaseFont.HELVETICA_BOLD;
        const int MINIMUMHEIGHT = 450;
        const int MINIMUMHEIGHT_2 = 10;

        const int MINIMUMHEIGHT_3 = 6;
        const int MINIMUMHEIGHT_4 = 10;

        const int MINIMUMHEIGHT_5 = 400;

        const int MINIMUMHEIGHT_Gap = 12;
        string headerImage;

        tbl_mst_SpotbookingOrdersContext objSpotbookingOrders = new tbl_mst_SpotbookingOrdersContext();


        public SpotBookingRegistrationPrint()
        {
        }

        PdfContentByte cb;
        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;
        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;
        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;
        public string Hcllogo;
        public string HeadLine1 { get; set; }
        public string HeadLine2 { get; set; }
        public string HeadLine3 { get; set; }
        public string HeadLine4 { get; set; }
        public string HeadLine5 { get; set; }
        public string HeadLine6 { get; set; }
        public string HeadLine7 { get; set; }
        public string HeadLine8 { get; set; }
        public string HeadLine9 { get; set; }
        public string HeadLine10 { get; set; }
        public string Orderid { get; set; }
 
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }

        public System.Data.DataSet DSForStudentDetails;



        public MemoryStream CreateChallan()
        {
            int id=Convert.ToInt32(Orderid);
            var chkDetails = objSpotbookingOrders.tbl_mst_SpotbookingOrders.Where(x => x.Pk_intOrderID == id).ToList();
            System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();



            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            iTextSharp.text.Font font20 = iTextSharp.text.FontFactory.GetFont
            (iTextSharp.text.FontFactory.HELVETICA, 5);


            // BaseFont bfTimes;
            // bfTimes = BaseFont.CreateFont(FONTNAME_NORMAL, BaseFont.CP1252, false);


            var memStream = new MemoryStream();

            //Document pdfDoc = new Document(PageSize.A4, 6f, 6f, 10f, 30f);
            
            Document pdfDoc = new Document(PageSize.A4.Rotate(), 1f, 1f, 10f, 30f);
            //Document pdfDoc = new Document(PageSize.A4,,);

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memStream);
            writer.PageEvent = new PDFFooter();

            //new
            //PdfWriter writer = PdfWriter.GetInstance(document, filestream);
            //writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5);
            //writer.CompressionLevel = PdfStream.BEST_COMPRESSION;
            //writer.SetFullCompression();
            //end new
            pdfDoc.Open();

            PdfPTable table = new PdfPTable(1);


            table.WidthPercentage = 100;
            //var colWidthPercentages = new[] { 33f};
            var colWidthPercentages = new[] { 33f };
            table.SetWidths(colWidthPercentages);


            PdfPCell cell = new PdfPCell();
            cell.BorderWidth = 0;



            PdfPTable innerTable = new PdfPTable(1);
            innerTable.WidthPercentage = 100;

            PdfPCell innerCell = new PdfPCell();
            innerCell.BorderWidth = 0;

            PdfPTable wTable = new PdfPTable(3);
            colWidthPercentages = new[] { 25f, 5f, 70f };
            wTable.WidthPercentage = 100;
            wTable.SetWidths(colWidthPercentages);


            string imageURLLogo = HttpContext.Current.Server.MapPath("~/Content/img/logo.png");

            iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);
            var wicell = new PdfPCell();
            wicell = new PdfPCell(imglogo);
            wicell.FixedHeight = 45;
            wicell.Colspan = 3;
            //  wicell.Rowspan = 3;
            wicell.BorderWidth = 0;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            imglogo.ScaleAbsolute(50, 45);

            wTable.AddCell(wicell);


            wicell = new PdfPCell(new Phrase(HeadLine1, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
            wicell.Colspan = 3;
            wicell.BorderWidth = 0;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            wTable.AddCell(wicell);

            wicell = new PdfPCell(new Phrase(HeadLine2, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
            wicell.Colspan = 3;
            wicell.BorderWidth = 0;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            wTable.AddCell(wicell);

            wicell = new PdfPCell(new Phrase(HeadLine3, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
            wicell.Colspan = 3;
            wicell.BorderWidth = 0;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            wTable.AddCell(wicell);

            //Add it

            wicell = new PdfPCell(new Phrase(HeadLine4, new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK)));
            wicell.Colspan = 3;
            wicell.BorderWidth = 0;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            wTable.AddCell(wicell);
            //end it

            wicell = new PdfPCell(new Phrase(HeadLine5, new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK)));
            wicell.Colspan = 3;
            wicell.BorderWidth = 0;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            wTable.AddCell(wicell);

            wicell = new PdfPCell(new Phrase(HeadLine6, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
            wicell.Colspan = 3;
            wicell.BorderWidth = 0;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            wTable.AddCell(wicell);


            wicell = new PdfPCell(new Phrase(HeadLine7, new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK)));
            wicell.Colspan = 3;
            wicell.BorderWidth = 0;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            wTable.AddCell(wicell);


            innerCell.AddElement(wTable);
            innerTable.AddCell(innerCell);


            //Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            
           

            PdfPTable tabletabulationDetails = new PdfPTable(3);

            float[] widths = new float[] { 35.5f,1f,35.5f };
           
            tabletabulationDetails.SetWidths(widths);
            tabletabulationDetails.SpacingBefore = 0.5f;
            tabletabulationDetails.SpacingAfter = 0.5f;


            //setAddTextToTable(tableHeadDetails, true, 10f, " ", true, MINIMUMHEIGHT_2);
            //setAddTextToTable(tableHeadDetails, true, 10f, "Order Details", true, MINIMUMHEIGHT_3);

            //setAddTextToTable(tableHeadDetails, true, 10f, " ", true, MINIMUMHEIGHT_2);

            setAddTextToTable(tabletabulationDetails, true, 10f, "Organisation Name", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);

            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["strOrganisationName"].ToString(), false, MINIMUMHEIGHT_2);



            setAddTextToTable(tabletabulationDetails, true, 10f, "Order Date", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);

            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["dtOrderDate"].ToString(), false, MINIMUMHEIGHT_2);



            setAddTextToTable(tabletabulationDetails, true, 10f, "Product", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["strProducts"].ToString(), false, MINIMUMHEIGHT_2);



            setAddTextToTable(tabletabulationDetails, true, 10f, "Order Type", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["strOrderType"].ToString(), false, MINIMUMHEIGHT_2);



            setAddTextToTable(tabletabulationDetails, true, 10f, "Booking Option", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["strOrderOption"].ToString(), false, MINIMUMHEIGHT_2);



            setAddTextToTable(tabletabulationDetails, true, 10f, "Lifting Option", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["strLiftingOption"].ToString(), false, MINIMUMHEIGHT_2);



            setAddTextToTable(tabletabulationDetails, true, 10f, "Real Time", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["tmRealBookingTime"].ToString(), false, MINIMUMHEIGHT_2);


            setAddTextToTable(tabletabulationDetails, true, 10f, "Product Price", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["fltProductPrice"].ToString(), false, MINIMUMHEIGHT_2);


            setAddTextToTable(tabletabulationDetails, true, 10f, "Booked Quantity", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["fltBookedQuantity"].ToString(), false, MINIMUMHEIGHT_2);


            setAddTextToTable(tabletabulationDetails, true, 10f, "Comments", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["strComments"].ToString(), false, MINIMUMHEIGHT_2);

            setAddTextToTable(tabletabulationDetails, true, 10f, "Booking/Basic Price", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["str_bookingbasicprice"].ToString(), false, MINIMUMHEIGHT_2);


            setAddTextToTable(tabletabulationDetails, true, 10f, "Product Accepted", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["str_bookingproductaccept"].ToString(), false, MINIMUMHEIGHT_2);

            setAddTextToTable(tabletabulationDetails, true, 10f, "Quantity Accepted MT", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["str_bookingquantityaccept"].ToString(), false, MINIMUMHEIGHT_2);


            setAddTextToTable(tabletabulationDetails, true, 10f, "Status", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["str_OrderStatus"].ToString(), false, MINIMUMHEIGHT_2);



            setAddTextToTable(tabletabulationDetails, true, 10f, "Remarks", false, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, true, 10f, "-", false, MINIMUMHEIGHT_3);
            setAddTextToTable(tabletabulationDetails, true, 10f, ApplicationReportInfo.Tables[0].Rows[0]["str_OrderStatusRemarks"].ToString(), false, MINIMUMHEIGHT_2);


            PdfPTable wTableForLineBreak = new PdfPTable(3);
            colWidthPercentages = new[] { 25f, 5f, 70f };
            wTableForLineBreak.WidthPercentage = 100;
            wTableForLineBreak.SetWidths(colWidthPercentages);
            setAddTextToTable(wTableForLineBreak, true, 10f, "", false, MINIMUMHEIGHT_Gap);
            setAddTextToTable(wTableForLineBreak, true, 10f, "", false, MINIMUMHEIGHT_Gap);
            setAddTextToTable(wTableForLineBreak, false, 10f, "", false, MINIMUMHEIGHT_Gap);


            cell.AddElement(wTable);
           
            cell.AddElement(wTableForLineBreak);
            cell.AddElement(tabletabulationDetails);
            
           
            
            cell.AddElement(wTableForLineBreak);

            table.AddCell(cell);
            pdfDoc.Add(table);
           
            pdfDoc.Close();
            return memStream;
        }



     public class PDFFooter : PdfPageEventHelper
    {

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }



        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 400F;
            string foo = "Page No : " + (writer.PageNumber).ToString() + "    Date:" + (DateTime.Now).ToString();
            cell = new PdfPCell(new Phrase(foo.ToString()));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }

    private void setAddTextToTable(PdfPTable table, bool isBold, float size, string text, int minHeight)
    {
        setAddTextToTable(table, isBold, size, text, true, minHeight);
    }



    private void setAddTextToTable(PdfPTable table, bool isBold, float size, string text, bool isBordered, int minHeight)
    {
        if (isBold)
        {
            PdfPCell cellLable = new PdfPCell(new Phrase(text, new Font(Font.FontFamily.HELVETICA, size, Font.BOLD, BaseColor.BLACK)));
            if (!isBordered)
                cellLable.BorderWidth = 0;

            cellLable.MinimumHeight = minHeight;
            table.AddCell(cellLable);
        }
        else
        {
            PdfPCell cellLable = new PdfPCell(new Phrase(text, new Font(Font.FontFamily.HELVETICA, size, Font.NORMAL, BaseColor.BLACK)));
            if (!isBordered)
                cellLable.BorderWidth = 0;

            cellLable.MinimumHeight = minHeight;
            table.AddCell(cellLable);
        }
    }


    }


