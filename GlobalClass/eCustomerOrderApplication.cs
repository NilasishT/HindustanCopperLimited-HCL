using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


//using MV = Hindustancopperlimited.Models.ModelView;
using Hindustancopperlimited.GlobalClass;
using Hindustancopperlimited.Models;

using System.Data;
using System.Data.SqlClient;

public class eCustomerOrderApplication
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



    Vw_SpotbookingDetailscontext objSpotbookingDetails = new Vw_SpotbookingDetailscontext();
  
    
    public eCustomerOrderApplication()
    {
    }

    PdfContentByte cb;
    PdfTemplate headerTemplate, footerTemplate;
    BaseFont bf = null;
    DateTime PrintTime = DateTime.Now;
    public string Hcllogo;
    public string HeadLine1 { get; set; }
    public string HeadLine5 { get; set; }
    public string str_OrderStatus { get; set; }
    public string nameOfComapany { get; set; }
    public string dtDate1 { get; set; }
    public string dtDate2 { get; set; }
    public string Region { get; set; }


    public System.Data.DataSet DSForStudentDetails;
  
    
    public MemoryStream CreateChallan()
    {



        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        iTextSharp.text.Font font20 = iTextSharp.text.FontFactory.GetFont
        (iTextSharp.text.FontFactory.HELVETICA, 5);     
        var memStream = new MemoryStream();
        Document pdfDoc = new Document(PageSize.A4.Rotate(), 1f, 1f, 10f, 30f);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memStream);
        writer.PageEvent = new PDFFooter();        
        pdfDoc.Open();
        PdfPTable table = new PdfPTable(1);
        table.WidthPercentage = 100;
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
        wicell.BorderWidth = 0;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        imglogo.ScaleAbsolute(50, 45);
        wTable.AddCell(wicell);


        wicell = new PdfPCell(new Phrase(HeadLine1, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 3;
        wicell.BorderWidth = 0;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        wTable.AddCell(wicell);

        wicell = new PdfPCell(new Phrase(HeadLine5, new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 3;
        wicell.BorderWidth = 0;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        wTable.AddCell(wicell);

        
        innerCell.AddElement(wTable);
        innerTable.AddCell(innerCell);


        PdfPTable tabletabulationDetails = new PdfPTable(12);

        float[] widths = new float[] { 1.0f, 3.5f, 6f, 3.5f, 5f, 5.5f, 3.5f, 2f, 2.5f, 1.5f, 1.5f, 2f};

        tabletabulationDetails.SetWidths(widths);
        tabletabulationDetails.SpacingBefore = 0.5f;
        tabletabulationDetails.SpacingAfter = 0.5f;


    

        setAddTextToTable(tabletabulationDetails, true, 6f, "Sl No.", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Date Time", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Organisation Name", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Order Id", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Product", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Order Type", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Offer Time", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Booking option", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Lifting option", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Qty", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Amount", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Status", true, MINIMUMHEIGHT_2);
        

        var Order = objSpotbookingDetails.Vw_SpotbookingDetails.OrderByDescending(x => x.Pk_Registrationid).ToList();

        if (Region != "All")
        {
            Order = Order.Where(x => x.fk_region == Region).OrderByDescending(x => x.Pk_Registrationid).ToList();
        }      

        if (nameOfComapany != null && nameOfComapany != "")
        {
            Order = Order.Where(x => x.strOrganisationName == nameOfComapany).ToList();
        }

        if (str_OrderStatus != null && str_OrderStatus != "")
        {
            Order = Order.Where(x => x.str_OrderStatus == str_OrderStatus).ToList();
        }

        if (dtDate1 != "" && dtDate2 != "" && dtDate1 != null && dtDate2 != null)
        {

            var a = dtDate1;
            DateTime fromDate = Convert.ToDateTime(dtDate1);
            DateTime toDate = Convert.ToDateTime(dtDate2).AddHours(24);
            Order = Order.Where(x => x.tmRealBookingTime >= fromDate && x.tmRealBookingTime <= toDate).ToList();


        }


        int i = 1;

        foreach (var Order_List in Order)
        {
            setAddTextToTable(tabletabulationDetails, false, 6f, i.ToString(), true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.dtOrderDatetime.ToString(), true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.strOrganisationName, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.str_orderid, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.strProducts, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.strOrderType, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.tmRealBookingTime.ToString(), true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.strOrderOption, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.strLiftingOption, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.fltBookedQuantity.ToString(), true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.fltProductPrice.ToString(), true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, Order_List.str_OrderStatus, true, MINIMUMHEIGHT_2);
            i++;
        
        }

      
        

        tabletabulationDetails.HeaderRows = 1;
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
            string foo = "Page No : " + (writer.PageNumber).ToString() + "                    Date:" + (DateTime.Now).ToString();
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
