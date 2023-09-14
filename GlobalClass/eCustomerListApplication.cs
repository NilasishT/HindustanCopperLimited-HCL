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

public class eCustomerListApplication
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

    //private SpotbookingRegistrationdetailscontext context = Utility.GetContext();

    Spotbookingregistrationcontext context = new Spotbookingregistrationcontext();
    Vw_LME_CustomerListContext CustomerList = new Vw_LME_CustomerListContext();
    public eCustomerListApplication()
    {
    }

    PdfContentByte cb;
    // we will put the final number of pages in a template
    PdfTemplate headerTemplate, footerTemplate;
    // this is the BaseFont we are going to use for the header / footer
    BaseFont bf = null;
    // This keeps track of the creation time
    DateTime PrintTime = DateTime.Now;
  
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




    //public string ApplicantId { get; set; }
    //public string FullName { get; set; }
    //public string FatherName { get; set; }
    //public string MotherName { get; set; }
    //public string GurdianName { get; set; }
    //public string DateOfBirth { get; set; }
    //public string Gender { get; set; }
    //public string Phone { get; set; }
    //public string Caste { get; set; }
    //public string PH { get; set; }

    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string AddressLine4 { get; set; }

    public string Pin { get; set; }

    public string Board { get; set; }

    public string RollNo { get; set; }

    public string CompulsorySubject { get; set; }

    public string Top4Marks;
    public string AggregateMarks;

    public string picture;
    public string sign;

    public string PrintDate;

    public string Hcllogo;
    public string strfromApplicantId;
    public string strtoApplicantId;

    public System.Data.DataSet DSForStudentDetails;

  
    
    public MemoryStream CreateChallan()
    {



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
        var wicell6 = new PdfPCell();
        wicell6 = new PdfPCell(imglogo);
        wicell6.FixedHeight = 45;
        wicell6.Colspan = 3;
        //  wicell.Rowspan = 3;
        wicell6.BorderWidth = 0;
        wicell6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        imglogo.ScaleAbsolute(50, 45);

        wTable.AddCell(wicell6);



        var wicell = new PdfPCell(new Phrase(HeadLine1, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
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


        PdfPTable tabletabulationDetails = new PdfPTable(12);

        //float[] widths = new float[] { 0.5f, 2.4f, 0.5f, 0.5f, 0.7f, 0.7f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f };

        float[] widths = new float[] { 1.0f, 4.0f, 4.0f, 3.5f, 4.0f, 2.5f, 2.5f, 2.5f, 2.0f, 1.5f, 2.0f, 2.0f };
        tabletabulationDetails.SetWidths(widths);
        tabletabulationDetails.SpacingBefore = 0.5f;
        tabletabulationDetails.SpacingAfter = 0.5f;


    

        setAddTextToTable(tabletabulationDetails, true, 6f, "Sl No.", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Name", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Email", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Contact", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Address", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "PAN", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "GST", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Firm Name", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Code", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Customer Status", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Customer Date", true, MINIMUMHEIGHT_2);
        setAddTextToTable(tabletabulationDetails, true, 6f, "Remarks", true, MINIMUMHEIGHT_2);





        var Vw_LME_CustomerList = CustomerList.Vw_LME_CustomerList.ToList();
        int i = 1;


        foreach (var customer_List in Vw_LME_CustomerList)
        {




            setAddTextToTable(tabletabulationDetails, false, 6f, i.ToString(), true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.FullName, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.Email, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.ContactDetails, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.AddressDetails, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.PAN, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.GST, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.NameOfFirm, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.Code, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.CustomerStatus, true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.CustomerStatusDate.Value.ToString("yyyy/MM/dd"), true, MINIMUMHEIGHT_2);
            setAddTextToTable(tabletabulationDetails, false, 6f, customer_List.Remarks, true, MINIMUMHEIGHT_2);

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
