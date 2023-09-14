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


public class eRequirtmentForm
{
    const string FONTNAME_NORMAL = BaseFont.HELVETICA;
    const string FONTNAME_BOLD = BaseFont.HELVETICA_BOLD;
    const int MINIMUMHEIGHT = 450;
    const int MINIMUMHEIGHT_2 = 10;

    const int MINIMUMHEIGHT_3 = 16;
    const int MINIMUMHEIGHT_4 = 10;

    const int MINIMUMHEIGHT_5 = 400;

    const int MINIMUMHEIGHT_6 = 36;

    const int MINIMUMHEIGHT_New3 = 7;


    const int MINIMUMHEIGHT_Gap = 12;
    string headerImage;
    tbl_mst_CandidatePersonalDetailscontext objcanpersonaldetails = new tbl_mst_CandidatePersonalDetailscontext();
    tbl_mst_CandidateQualificationContext objCanQunification = new tbl_mst_CandidateQualificationContext();
    tbl_mst_CandidateExperienceContext objcanexperience = new tbl_mst_CandidateExperienceContext();
    tbl_mst_CandidateAwardScholarshipContext objcanaward = new tbl_mst_CandidateAwardScholarshipContext();
    tbl_mst_CandidatePublicationPaperPresentationContext objcanPaperPresentation = new tbl_mst_CandidatePublicationPaperPresentationContext();
    Vw_Postdesiciplinedetailscontext objpostdesicipline = new Vw_Postdesiciplinedetailscontext();
    tbl_mst_CandidateOtherDetailsContext objOtherDetailsContext = new tbl_mst_CandidateOtherDetailsContext();
    tbl_mst_CandidateDDDetailsContext objtbl_mst_CandidateDDDetailsContext = new tbl_mst_CandidateDDDetailsContext();
   
    public eRequirtmentForm()
    {
    }

    public string ApplicationNo { get; set; }
    public string HeadLine1 { get; set; }
    public string HeadLine2 { get; set; }
    public string HeadLine3 { get; set; }
    public string HeadLine4 { get; set; }
    public string HeadLine5 { get; set; }
    public string HeadLine6 { get; set; }
    public string HeadLine7 { get; set; }

    public string HCLLogo { get; set; }

    public string HCLPhoto { get; set; }

    public string SignPhoto { get; set; }
    public string decipline { get; set; }
    public string post { get; set; }
   
    public MemoryStream CreateRequirtment()
    {
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        iTextSharp.text.Font font20 = iTextSharp.text.FontFactory.GetFont
        (iTextSharp.text.FontFactory.HELVETICA, 5);
        var memStream = new MemoryStream();

        Document pdfDoc = new Document(PageSize.A4, 5f, 5f, 10f, 10f);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memStream);
        pdfDoc.Open();

        PdfPTable table = new PdfPTable(1);
        table.WidthPercentage = 100;
        var colWidthPercentages = new[] { 45f };
        table.SetWidths(colWidthPercentages);
        PdfPCell cell = new PdfPCell();
        cell.BorderWidth = 0;

        PdfPTable innerTable = new PdfPTable(1);
        innerTable.WidthPercentage = 100;

        PdfPCell innerCell = new PdfPCell();
        innerCell.BorderWidth = 0;

        PdfPTable wTable = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 5f, 50f, 20f };
        wTable.WidthPercentage = 100;
        wTable.SetWidths(colWidthPercentages);

        PdfPCell wCell = new PdfPCell();
        wCell.BorderWidth = 0;
        wCell.Colspan = 4;

        //shoumya
        string applicationNo = Convert.ToString(this.ApplicationNo);
        //var applicationDetails = context.tbl_onlineApplocationForm.ToList();
        var chkDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.strApplicationNo == applicationNo).ToList();
        //int? id = chkDetails.FirstOrDefault().fk_CandidateId;
       
        var EducationDetails = objCanQunification.tbl_mst_CandidateQualification.Where(x => x.Application_No == applicationNo).ToList();
        var ExperienceDetails = objcanexperience.tbl_mst_CandidateExperience.Where(x => x.ApplicationNo == applicationNo).ToList();
        var ExperienceGradeDetails = objcanexperience.tbl_NextBelowGrade.Where(x => x.strApplicationNo == applicationNo).ToList();
        var awarddetails = objcanaward.tbl_mst_CandidateAwardScholarship.Where(x => x.Application_No == applicationNo).ToList();
        var publicationlist = objcanPaperPresentation.tbl_mst_CandidatePublicationPaperPresentation.Where(x => x.Application_No == applicationNo).ToList();
        var OtherDetails = objOtherDetailsContext.tbl_mst_CandidateOtherDetails.Where(x => x.strApplicationNo == applicationNo).FirstOrDefault();
        //var DDDetails = objtbl_mst_CandidateDDDetailsContext.tbl_mst_CandidateDDDetails.Where(x => x.strApplicationNo == applicationNo).FirstOrDefault();
        var BelowAge = objcanexperience.tbl_NextBelowGrade.Where(x => x.strApplicationNo == applicationNo).ToList();

        string totalExp = "0";
        if (ExperienceDetails != null)
        {
           

          decimal  dectotalExp=ExperienceDetails.Where(x=>x.str_noyears!="").Sum(x => Convert.ToInt32(x.str_noyears));

          var totalYears = Math.Truncate(dectotalExp / 365);
          var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
          var remainingDays = Math.Truncate((dectotalExp % 365) % 30);

          totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";


        }

        //var chkDetails = context.vw_onlineApplocationFormVolunteer.ToList();objcanexperience
        System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();

        System.Data.DataSet ApplicantEducation = EducationDetails.ToDataset();

        System.Data.DataSet ApplicantExperience = ExperienceDetails.ToDataset();
        System.Data.DataSet ApplicantExperienceGrade = ExperienceGradeDetails.ToDataset();
        System.Data.DataSet Applicantapplication = awarddetails.ToDataset();
        System.Data.DataSet Applicantpublication = publicationlist.ToDataset();
        System.Data.DataSet NextBelowGrade = BelowAge.ToDataset();

        string imageURLLogo = HttpContext.Current.Server.MapPath(this.HCLLogo);
        iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);
        ////PdfPTable tblLalbabaLogo = new PdfPTable(1);

        var wicellImage = new PdfPCell();

        wicellImage = new PdfPCell(imglogo);
        wicellImage.FixedHeight = 45;
        wicellImage.Colspan = 0;
        wicellImage.Rowspan = 3;
        wicellImage.BorderWidth = 0;
        wicellImage.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imglogo.ScaleAbsolute(30, 45);

        wTable.AddCell(wicellImage);


        var wicell = new PdfPCell(new Phrase(HeadLine1, new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.BorderWidth = 0;
        wicell.PaddingLeft = 70f;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
        wTable.AddCell(wicell);

        wicell = new PdfPCell(new Phrase(HeadLine2, new Font(Font.FontFamily.HELVETICA, 9f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.BorderWidth = 0;
        wicell.PaddingLeft = 85f;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
        wTable.AddCell(wicell);

        wicell = new PdfPCell(new Phrase(HeadLine3, new Font(Font.FontFamily.HELVETICA, 9f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.BorderWidth = 0;
        wicell.PaddingLeft = 110f;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
        wTable.AddCell(wicell);

        wicell = new PdfPCell(new Phrase(HeadLine4, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.BorderWidth = 0;
        wicell.PaddingLeft = 190f;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
        wTable.AddCell(wicell);

        innerCell.AddElement(wTable);
        innerTable.AddCell(innerCell);


        PdfPTable tbldecipline = new PdfPTable(3);
       
        colWidthPercentages = new[] { 25f, 52f, 23f };
        tbldecipline.WidthPercentage = 100;
        tbldecipline.SetWidths(colWidthPercentages);

        string DeciplineText = "Discipline";
        string NameOfThePostText = "Name of the Post Applied For";
        string NameText = "Name";
        string DOBText = "Date of Birth";
        string MotherNameText = "Mother's Full Name";
        string FatherNameText = "Father's Full Name";
        string SpouseNameText = "Spouse Name";
        string EmailIdText = "Email Id";
        string AlternateEmailIdText = "Alternate Email Id";
        string AdharcardText = "Adhar Card";
        string PanCardText = "PAN Card";
    

        string Decipline = decipline;
        string NameOfThePost = post;
        

        string imageURLPhoto = HttpContext.Current.Server.MapPath(this.HCLPhoto);


        iTextSharp.text.Image imgphoto = iTextSharp.text.Image.GetInstance(imageURLPhoto);
        ////PdfPTable tblLalbabaLogo = new PdfPTable(1);

        //wicell = new PdfPCell();

        //setAddTextToTable(tbldecipline, true, 7f, HeadLine4, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 7f, DeciplineText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, Decipline, true, MINIMUMHEIGHT_3);
      
        var wicellphoto = new PdfPCell(imgphoto);
        wicellphoto.FixedHeight = 90;
        wicellphoto.Colspan = 0;
      //  wicellphoto.Rowspan = 6;
        wicellphoto.Rowspan = 10;
        wicellphoto.PaddingLeft = 15f;
        wicellphoto.PaddingTop = 10f;
        //wicellphoto.BorderWidth = 0;
        wicellphoto.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imgphoto.ScaleAbsolute(100, 80);
        tbldecipline.AddCell(wicellphoto);


        var dob = ApplicationReportInfo.Tables[0].Rows[0]["dtDOB"].ToString();
        var _dob = dob.Substring(0, 10);
        setAddTextToTable(tbldecipline, false, 7f, NameOfThePostText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, NameOfThePost, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, NameText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tbldecipline, false, 7f, Name, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 9f, ApplicationReportInfo.Tables[0].Rows[0]["strApplicantName"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, DOBText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, _dob, true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, MotherNameText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tbldecipline, false, 7f, FatherName, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMotherName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, FatherNameText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tbldecipline, false, 7f, FatherName, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFatherName"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, SpouseNameText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tbldecipline, false, 7f, FatherName, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strSpouseName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, EmailIdText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tbldecipline, false, 7f, EmailId, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strEmail"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AlternateEmailIdText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tbldecipline, false, 7f, EmailId, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAlternate_EmaiID"].ToString(), true, MINIMUMHEIGHT_3);
        //GAP

        setAddTextToTable(tbldecipline, false, 7f, AdharcardText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tbldecipline, false, 7f, EmailId, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAadharNo"].ToString(), true, MINIMUMHEIGHT_3);
        //GAP


        setAddTextToTable(tbldecipline, false, 7f, PanCardText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tbldecipline, false, 7f, EmailId, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPANNo"].ToString(), true, MINIMUMHEIGHT_3);
        //GAP




        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        //setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        //End GAP

        PdfPTable tblpersonalInfo = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblpersonalInfo.WidthPercentage = 100;
        tblpersonalInfo.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Personal Information", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        //wicell.BorderWidth = 0;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string NationalityText = "Nationality";
       

        string DomicileText = "Domicile State";
        //string Domicile = "Jharkhand";

        setAddTextToTable(tblpersonalInfo, false, 7f, NationalityText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNationality"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, DomicileText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblpersonalInfo, false, 7f, Domicile, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strDomicilestate"].ToString(), true, MINIMUMHEIGHT_3);
        string GenderText = "Gender";
       

        string MaritialStatusText = "Marital Status";
       
        setAddTextToTable(tblpersonalInfo, false, 7f, GenderText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strGender"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, MaritialStatusText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMaritalStatus"].ToString(), true, MINIMUMHEIGHT_3);

        
        string CategoryText = "Category";
        string Category = ApplicationReportInfo.Tables[0].Rows[0]["strCategory"].ToString();

        setAddTextToTable(tblpersonalInfo, false, 7f, CategoryText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(Category, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
      
        wicell.Colspan = 3;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        if (Category != "UR")
        {
            //added by Roni
            string SubCasteText = "Sub-Caste";
            string CertNoText = "Certificate No.";
            setAddTextToTable(tblpersonalInfo, false, 7f, SubCasteText, true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strsubcaste"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblpersonalInfo, false, 7f, CertNoText, true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strcertificateno"].ToString(), true, MINIMUMHEIGHT_3);
            string CertIUssueDateText = "Certificate Issue Date";
            string IssueAuthorityText = "Issuing Authority";
            setAddTextToTable(tblpersonalInfo, false, 7f, CertIUssueDateText, true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["dt_certificateissuedate"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblpersonalInfo, false, 7f, IssueAuthorityText, true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strcertificateissue"].ToString(), true, MINIMUMHEIGHT_3);
            //added by Roni

        }


        string PwdText = "Pwd(40% or More Disability)";
        string Pwd = ApplicationReportInfo.Tables[0].Rows[0]["strPWD"].ToString();

        if (Pwd == "Yes")
        {
            Pwd = Pwd + " , PWD Type : " + ApplicationReportInfo.Tables[0].Rows[0]["strtypeofdisable"].ToString() + " , Cerfificate No. : " + ApplicationReportInfo.Tables[0].Rows[0]["strcertificateno1"].ToString() + " , Issue Date : " + ApplicationReportInfo.Tables[0].Rows[0]["dt_certificateissuedate1"].ToString() + " , Issuing Authority : " + ApplicationReportInfo.Tables[0].Rows[0]["strcertificateissue1"].ToString();
        }
        

        setAddTextToTable(tblpersonalInfo, false, 7f, PwdText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(Pwd, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 3;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);


        string ExServiceMenText = "Ex-Servicemen";
        string ExServiceMen = ApplicationReportInfo.Tables[0].Rows[0]["strExserviceMan"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, ExServiceMenText, true, MINIMUMHEIGHT_3);
        
       
        wicell = new PdfPCell(new Phrase(ExServiceMen, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 3;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string InternalCandidateText = "Internal Candidate";
        string InternalCandidate = ApplicationReportInfo.Tables[0].Rows[0]["strInternalCandidate"].ToString();

        setAddTextToTable(tblpersonalInfo, false, 7f, InternalCandidateText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(InternalCandidate, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 3;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);


        //string emp = ApplicationReportInfo.Tables[0].Rows[0]["strEmployedIn"].ToString();
        //string apply = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();

        string ApplyingThroughProperChannelText = "Applying Through Proper Channel also?";
        string ApplyingThroughProperChannel = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();

        //string label = "";//"In case employed in Govt. /Semi Govt. /PSU,whether through proper channel also?";
        //wicell = new PdfPCell(new Phrase(label+" "+emp+" "+apply, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplyingThroughProperChannelText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(ApplyingThroughProperChannel, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        //GAP
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);

        //END GAP

        PdfPTable tblAddress = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblAddress.WidthPercentage = 100;
        tblAddress.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Correspondence Address", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        //wicell.BorderWidth = 0;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAddress.AddCell(wicell);



        string AddressText = "Address";
        string Address = ApplicationReportInfo.Tables[0].Rows[0]["strCorrespondenceAddress"].ToString();

        setAddTextToTable(tblAddress, false, 7f, AddressText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(Address, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 3;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAddress.AddCell(wicell);


        string StateText = "State";
      
        string DistrictText = "District";
     

        setAddTextToTable(tblAddress, false, 7f, StateText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strState"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, DistrictText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strDistrict"].ToString(), true, MINIMUMHEIGHT_3);

        string NearPOText = "Nearest Post Office";
        

        string NearPSText = "Nearest Police Station";
       
        setAddTextToTable(tblAddress, false, 7f, NearPOText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestPostOffice"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, NearPSText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestPoliceStation"].ToString(), true, MINIMUMHEIGHT_3);

        //added by Roni
        string NearRailText = "Nearest Railway Station";
       
        string PinCodeText = "Pin Code";
       
        setAddTextToTable(tblAddress, false, 7f, NearRailText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestRailwaystation"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, PinCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPin"].ToString(), true, MINIMUMHEIGHT_3);
        //added by Roni

        string StdCodeText = "Telephone No. with STD Code";

        string MoblieText = "Mobile No.";
        

        setAddTextToTable(tblAddress, false, 7f, StdCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strTelephone"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, MoblieText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMobileNo"].ToString(), true, MINIMUMHEIGHT_3);



        //GAP
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);

        //END GAP
                
        PdfPTable tblQualification = new PdfPTable(9);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f, 7f };
        tblQualification.WidthPercentage = 100;
        tblQualification.SetWidths(colWidthPercentages);


       

        //added by Roni
        wicell = new PdfPCell(new Phrase("Educational Qualification Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAddress.AddCell(wicell);
        //added by Roni

        //setAddTextToTable(tblQualification, true, 7f, "Course Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Exam Pased", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Course Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Board/ University", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Stream/ Special Subject", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Date of Passing", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Duration of Couser(in Year)", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "(%) Marks", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Division/ Grade", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Remarks", true, MINIMUMHEIGHT_3);
        


        for (int i = 0; i < ApplicantEducation.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_exampassed"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_course"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_board"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_passingdetails"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_passingyear"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_duration"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_Marks"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_division"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["StrRemarks"].ToString(), true, MINIMUMHEIGHT_3);
            

        }       


        //GAP
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);

        //END GAP

        PdfPTable tblExperience = new PdfPTable(1);
        colWidthPercentages = new[] { 100f };
        tblExperience.WidthPercentage = 100;
        tblExperience.SetWidths(colWidthPercentages);

        //setAddTextToTable(tblExperience, true, 9f, "Experience", false, MINIMUMHEIGHT_3);

        wicell = new PdfPCell(new Phrase("Experience Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 6;
        //wicell.BorderWidth = 0;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblExperience.AddCell(wicell);

        //setAddTextToTable(tblExperience, false, 7f, "No Experience Details Avaliable", false, MINIMUMHEIGHT_3);

        PdfPTable tblExperienceImmediate = new PdfPTable(9);
        colWidthPercentages = new[] { 10f, 15f, 10f, 10f,7f,10f,7f,7f,10f };
        tblExperienceImmediate.WidthPercentage = 100;
        tblExperienceImmediate.SetWidths(colWidthPercentages);


        //wicell = new PdfPCell(new Phrase("Experience In Immediate next below Grade", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        //wicell.Colspan = 6;
        ////wicell.BorderWidth = 0;
        //wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //tblExperienceImmediate.AddCell(wicell);

        setAddTextToTable(tblExperienceImmediate, false, 7f, "Organisation Type", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "Present Status of Employment", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "Organisation Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "Designation", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "CTC", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "Scale of Pay", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "From Date", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "To Date", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "Total Days of Experience", true, MINIMUMHEIGHT_3);

        for (int i = 0; i < ApplicantExperience.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["str_organisationType"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["StrEmploymentPresentStatus"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["str_organisation"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["Str_designation"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["str_CTC"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["str_PayScale"].ToString(), true, MINIMUMHEIGHT_3);

            var fromdate = ApplicantExperience.Tables[0].Rows[i]["dt_fromdate"].ToString();
            var _fromdate = fromdate.Substring(0, 10);
            setAddTextToTable(tblExperienceImmediate, false, 7f, _fromdate, true, MINIMUMHEIGHT_3);
            //setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["dt_fromdate"].ToString(), true, MINIMUMHEIGHT_3);
            var todate = ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString();
            var _todate = todate.Substring(0, 10);
            setAddTextToTable(tblExperienceImmediate, false, 7f, _todate, true, MINIMUMHEIGHT_3);
            //setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString(), true, MINIMUMHEIGHT_3);
            if (ApplicantExperience.Tables[0].Rows[i]["str_noyears"] != null && ApplicantExperience.Tables[0].Rows[i]["str_noyears"].ToString() != "")
            {
                setAddTextToTable(tblExperienceImmediate, false, 7f, ApplicantExperience.Tables[0].Rows[i]["str_noyears"].ToString(), true, MINIMUMHEIGHT_3);
            }
            else
            {
                int totalDays = Convert.ToDateTime(ApplicantExperience.Tables[0].Rows[i]["dt_fromdate"]).Day - Convert.ToDateTime(ApplicantExperience.Tables[0].Rows[i]["dt_todate"]).Day;
            }
        }

        setAddTextToTable(tblExperienceImmediate, false, 7f, "Total Experience", true, MINIMUMHEIGHT_3, 5);
        setAddTextToTable(tblExperienceImmediate, false, 7f, totalExp , true, MINIMUMHEIGHT_3,4);


        //Experience in immediate next below Grade

        //GAP
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);

        //END GAP


        PdfPTable tblExperienceGrade1 = new PdfPTable(1);
        colWidthPercentages = new[] { 100f };
        tblExperienceGrade1.WidthPercentage = 100;
        tblExperienceGrade1.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Experience in immediate next below Grade", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 6;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblExperienceGrade1.AddCell(wicell);



        PdfPTable tblExperienceGrade = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 25f, 25f, 25f };
        tblExperienceGrade.WidthPercentage = 100;
        tblExperienceGrade.SetWidths(colWidthPercentages);


        setAddTextToTable(tblExperienceGrade, true, 7f, "Grade", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceGrade, true, 7f, "From Date", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceGrade, true, 7f, "To Date", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblExperienceGrade, true, 7f, "Duration of Experience", true, MINIMUMHEIGHT_3);




        for (int i = 0; i < ApplicantExperienceGrade.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tblExperienceGrade, false, 7f, ApplicantExperienceGrade.Tables[0].Rows[i]["strGrade"].ToString(), true, MINIMUMHEIGHT_3);
     
            var fromdate = ApplicantExperienceGrade.Tables[0].Rows[0]["dtFromDate"].ToString();
            if (fromdate != "")
            {
                var _fromdate = fromdate.Substring(0, 10);
                setAddTextToTable(tblExperienceGrade, false, 7f, _fromdate, true, MINIMUMHEIGHT_3);
            }
            else
            {
                setAddTextToTable(tblExperienceGrade, false, 7f, "", true, MINIMUMHEIGHT_3);
            }

            var todate = ApplicantExperienceGrade.Tables[0].Rows[0]["dtTodate"].ToString();
            if (todate != "")
            {
                var _todate = todate.Substring(0, 10);
                setAddTextToTable(tblExperienceGrade, false, 7f, _todate, true, MINIMUMHEIGHT_3);
            }
            else
            {
                setAddTextToTable(tblExperienceGrade, false, 7f, "", true, MINIMUMHEIGHT_3);
            }

            if (ApplicantExperienceGrade.Tables[0].Rows[i]["strYear"].ToString() != "")
            {
                decimal decTotal = Convert.ToInt32(ApplicantExperienceGrade.Tables[0].Rows[i]["strYear"].ToString());

                var totalYears = Math.Truncate(decTotal / 365);
                var totalMonths = Math.Truncate((decTotal % 365) / 30);
                var remainingDays = Math.Truncate((decTotal % 365) % 30);
                var totalExp1 = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
                setAddTextToTable(tblExperienceGrade, false, 7f, totalExp1.ToString(), true, MINIMUMHEIGHT_3);
            }
            else
            {
                setAddTextToTable(tblExperienceGrade, false, 7f, "", true, MINIMUMHEIGHT_3);
            }


        }

        //GAP
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceGrade, false, 7f, "", false, MINIMUMHEIGHT_New3);

        //END GAP

       // Experience in immediate next below Grade



        PdfPTable tblAwardPublication = new PdfPTable(3);
        colWidthPercentages = new[] { 49.2f, 0.6f, 49.2f };
        tblAwardPublication.WidthPercentage = 100;
        tblAwardPublication.SetWidths(colWidthPercentages);

        PdfPTable tblAward = new PdfPTable(1);
        colWidthPercentages = new[] { 45f };
        tblAward.WidthPercentage = 100;
        tblAward.SetWidths(colWidthPercentages);


        setAddTextToTable(tblAward, true, 7f, "Award & Scholarship", true, MINIMUMHEIGHT_3);
        for (int i = 0; i < Applicantapplication.Tables[0].Rows.Count; i++)
        {
            setAddTextToTable(tblAward, false, 7f, Applicantapplication.Tables[0].Rows[i]["straward"].ToString(), true, MINIMUMHEIGHT_3);
            //setAddTextToTable(tblAward, false, 7f, "NATIONAL LEVEL TECHNO PHILIATIB", true, MINIMUMHEIGHT_3);
            //setAddTextToTable(tblAward, false, 7f, "BEST IDEAL STUDENT IN SCHOOL 2009", true, MINIMUMHEIGHT_3);

            
        }
        tblAwardPublication.AddCell(tblAward);
        setAddTextToTable(tblAwardPublication, false, 7f, "", false, MINIMUMHEIGHT_New3);

        PdfPTable tblPublisher = new PdfPTable(1);
        tblPublisher.WidthPercentage = 100;

        setAddTextToTable(tblPublisher, true, 7f, "Publication & Paper Presentation", true, MINIMUMHEIGHT_3);
        for (int i = 0; i < Applicantpublication.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tblPublisher, false, 7f, Applicantpublication.Tables[0].Rows[i]["str_Publication_PaperPresentation"].ToString(), true, MINIMUMHEIGHT_3);
          

           
        }
        tblAwardPublication.AddCell(tblPublisher);
        //GAP
        setAddTextToTable(tblAwardPublication, false, 7f, "", false, 4);
        setAddTextToTable(tblAwardPublication, false, 7f, "", false, 4);
        setAddTextToTable(tblAwardPublication, false, 7f, "", false, 4);
        //END GAP

        PdfPTable tblProfessionalBodies = new PdfPTable(1);
        tblProfessionalBodies.WidthPercentage = 100;

        setAddTextToTable(tblProfessionalBodies, true, 7f, "Member of Professional Bodies : ", true, MINIMUMHEIGHT_3);

        if (OtherDetails != null)
        {
            setAddTextToTable(tblProfessionalBodies, false, 7f, OtherDetails.strProfessionalBodies, true, MINIMUMHEIGHT_3);
        }
        else
        {
            setAddTextToTable(tblProfessionalBodies, false, 7f, "", true, MINIMUMHEIGHT_3);
        }
        //GAP
        setAddTextToTable(tblProfessionalBodies, false, 7f, "", false, 4);

        //END GAP

        //by Roni
        //PdfPTable tblApplicatinFee = new PdfPTable(6);
        //colWidthPercentages = new[] { 15f, 20f, 15f, 20f, 10f, 20f };
        //tblApplicatinFee.WidthPercentage = 100;
        //tblApplicatinFee.SetWidths(colWidthPercentages);

        //wicell = new PdfPCell(new Phrase("Application Fee Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        //wicell.Colspan = 6;
        ////wicell.BorderWidth = 0;
        //wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //tblApplicatinFee.AddCell(wicell);

        //string DraftPayorderNoText = "Draft/ Pay Order No.";
        //string DraftPayorderNo = DDDetails.strOrderNo;
        //string IssuingBankText = "Issuing Bank Name";
        //string IssuingBank = DDDetails.strIssuingBankName;
        //string IssuingBranchText = "Issuing Branch Name";
        //string IssuingBranch = DDDetails.strIssuingBranch;

        //setAddTextToTable(tblApplicatinFee, false, 7f, DraftPayorderNoText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, DraftPayorderNo, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, IssuingBankText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, IssuingBank, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, IssuingBranchText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, IssuingBranch, true, MINIMUMHEIGHT_3);

        //string IssueDateText = "Issue Date";
        //string IssueDate = DDDetails.dtIssueDate.Value.ToString("dd/MM/yyyy");
        //string AmountText = "Amount";
        //string Amount = DDDetails.decAmount.ToString(); 

        //setAddTextToTable(tblApplicatinFee, false, 7f, IssueDateText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, IssueDate, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, AmountText, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, Amount, true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, "", true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblApplicatinFee, false, 7f, "", true, MINIMUMHEIGHT_3);

        //setAddTextToTable(tblApplicatinFee, false, 7f, "", false, 4);
        //setAddTextToTable(tblApplicatinFee, false, 7f, "", false, 4);
        //setAddTextToTable(tblApplicatinFee, false, 7f, "", false, 4);
        //setAddTextToTable(tblApplicatinFee, false, 7f, "", false, 4);
        //setAddTextToTable(tblApplicatinFee, false, 7f, "", false, 4);
        //setAddTextToTable(tblApplicatinFee, false, 7f, "", false, 4);
        //by Roni

        PdfPTable tblOtherDetails = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "In case of selection joining time required", true, MINIMUMHEIGHT_3);
        if (OtherDetails != null)
        {
            setAddTextToTable(tblOtherDetails, false, 7f, OtherDetails.strJoiningTimeReq, true, MINIMUMHEIGHT_3);
        }
        else
        {
            setAddTextToTable(tblOtherDetails, false, 7f, "", true, MINIMUMHEIGHT_3);
        }
        setAddTextToTable(tblOtherDetails, false, 7f, "Whether willing to join early", true, MINIMUMHEIGHT_6);
        if (OtherDetails != null)
        {
            setAddTextToTable(tblOtherDetails, false, 7f, OtherDetails.strJoinEarly, true, MINIMUMHEIGHT_6);
        }
        else
        {
            setAddTextToTable(tblOtherDetails, false, 7f, "", true, MINIMUMHEIGHT_6);
        }

        setAddTextToTable(tblOtherDetails, false, 7f, "Signature", true, 45);
        

        //new
        string imageSignUrl = HttpContext.Current.Server.MapPath(this.SignPhoto);
        iTextSharp.text.Image imgSign = iTextSharp.text.Image.GetInstance(imageSignUrl); 
        var wicellSign = new PdfPCell(imgSign);
        wicellSign.FixedHeight = 90;
        wicellSign.Colspan = 0;
        wicellSign.Rowspan = 6;
        wicellSign.PaddingTop = 5f;
        wicellSign.PaddingBottom = 5f;
        wicellSign.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        imgSign.ScaleAbsolute(280, 30);
        tblOtherDetails.AddCell(wicellSign);

       

        cell.AddElement(innerTable);
        cell.AddElement(tbldecipline);
        cell.AddElement(tblpersonalInfo);
        cell.AddElement(tblAddress);
        cell.AddElement(tblQualification);
        cell.AddElement(tblExperience);
        cell.AddElement(tblExperienceImmediate);
        cell.AddElement(tblExperienceGrade1);
        cell.AddElement(tblExperienceGrade);
        cell.AddElement(tblAwardPublication);
        cell.AddElement(tblProfessionalBodies);
        
        //cell.AddElement(tblApplicatinFee);
        cell.AddElement(tblOtherDetails);
        //
        table.AddCell(cell);

        pdfDoc.Add(table);

        pdfDoc.Close();

        return memStream;

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


    private void setAddTextToTable(PdfPTable table, bool isBold, float size, string text, bool isBordered, int minHeight,int colSpan)
    {
        if (isBold)
        {
            PdfPCell cellLable = new PdfPCell(new Phrase(text, new Font(Font.FontFamily.HELVETICA, size, Font.BOLD, BaseColor.BLACK)));
            if (!isBordered)
                cellLable.BorderWidth = 0;

            cellLable.MinimumHeight = minHeight;
            cellLable.Colspan = colSpan;
            table.AddCell(cellLable);
        }
        else
        {
            PdfPCell cellLable = new PdfPCell(new Phrase(text, new Font(Font.FontFamily.HELVETICA, size, Font.NORMAL, BaseColor.BLACK)));
            if (!isBordered)
                cellLable.BorderWidth = 0;
            cellLable.Colspan = colSpan;
            cellLable.MinimumHeight = minHeight;
            table.AddCell(cellLable);
        }
    }


    private void setAddTextToTableCenter(PdfPTable table, bool isBold, float size, string text, bool isBordered, int minHeight)
    {
        if (isBold)
        {
            PdfPCell cellLable = new PdfPCell(new Phrase(text, new Font(Font.FontFamily.HELVETICA, size, Font.BOLD, BaseColor.BLACK)));
            if (!isBordered)
                cellLable.BorderWidth = 0;
            cellLable.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellLable.MinimumHeight = minHeight;
            table.AddCell(cellLable);
        }
        else
        {
            PdfPCell cellLable = new PdfPCell(new Phrase(text, new Font(Font.FontFamily.HELVETICA, size, Font.NORMAL, BaseColor.BLACK)));
            if (!isBordered)
                cellLable.BorderWidth = 0;
            cellLable.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellLable.MinimumHeight = minHeight;
            table.AddCell(cellLable);
        }
    }

}
