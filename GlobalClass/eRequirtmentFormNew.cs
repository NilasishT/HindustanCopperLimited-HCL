using DataAccessLayer;
using Hindustancopperlimited.GlobalClass;
using Hindustancopperlimited.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;


public class eRequirtmentFormNew
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
    Vw_Postdesiciplinedetailscontext objpostdesicipline = new Vw_Postdesiciplinedetailscontext();
    tbl_mst_CandidateRegistrationForRecruitmentContext objContext = new tbl_mst_CandidateRegistrationForRecruitmentContext();

    tbl_mst_CandidateQualificationAdditionalContext objAdditionalEducation =
        new tbl_mst_CandidateQualificationAdditionalContext();

    tbl_mst_CandidateCertificateDetailsContext objCertificateDetails =
        new tbl_mst_CandidateCertificateDetailsContext();

    tbl_mst_CandidateTransitionCertificateDetailsContext objtransition = new tbl_mst_CandidateTransitionCertificateDetailsContext();


    public eRequirtmentFormNew()
    {
    }
    public int? candidateid { get; set; }
    public string RTIAns { get; set; }
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

       
        
        var chkDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        var EducationDetails = objCanQunification.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        var ExperienceDetails = objcanexperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        string totalExp = "0";
        if (ExperienceDetails != null)
        {          

          decimal  dectotalExp=ExperienceDetails.Where(x=>x.str_noyears!="").Sum(x => Convert.ToInt32(x.str_noyears));
          var totalYears = Math.Truncate(dectotalExp / 365);
          var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
          var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
          totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
        }
       
        System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();
        System.Data.DataSet ApplicantEducation = EducationDetails.ToDataset();
        System.Data.DataSet ApplicantExperience = ExperienceDetails.ToDataset();
        string imageURLLogo = HttpContext.Current.Server.MapPath(this.HCLLogo);
        iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);

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
       
        colWidthPercentages = new[] { 26f, 37f, 37f };
        tbldecipline.WidthPercentage = 100;
        tbldecipline.SetWidths(colWidthPercentages);

        
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

        
      
        var wicellphoto = new PdfPCell(imgphoto);
        wicellphoto.FixedHeight = 90;
        wicellphoto.Colspan = 0;
        wicellphoto.Rowspan = 10;
        wicellphoto.PaddingLeft = 15f;
        wicellphoto.PaddingTop = 10f;
        wicellphoto.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imgphoto.ScaleAbsolute(100, 80);
        tbldecipline.AddCell(wicellphoto);


        var dob = ApplicationReportInfo.Tables[0].Rows[0]["dtDOB"].ToString();
        var _dob = dob.Substring(0, 10);
        setAddTextToTable(tbldecipline, false, 7f, NameOfThePostText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, NameOfThePost, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, NameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 9f, ApplicationReportInfo.Tables[0].Rows[0]["strApplicantName"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, DOBText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, _dob, true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, MotherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMotherName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, FatherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFatherName"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, SpouseNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strSpouseName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, EmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strEmail"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AlternateEmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAlternate_EmaiID"].ToString(), true, MINIMUMHEIGHT_3);
        

        setAddTextToTable(tbldecipline, false, 7f, AdharcardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAadharNo"].ToString(), true, MINIMUMHEIGHT_3);
        


        setAddTextToTable(tbldecipline, false, 7f, PanCardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPANNo"].ToString(), true, MINIMUMHEIGHT_3);
        




        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);

        PdfPTable tblpersonalInfo = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblpersonalInfo.WidthPercentage = 100;
        tblpersonalInfo.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Personal Information", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string NationalityText = "Nationality";
       

        string DomicileText = "Domicile State";

        setAddTextToTable(tblpersonalInfo, false, 7f, NationalityText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNationality"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, DomicileText, true, MINIMUMHEIGHT_3);
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

        if (Category != "General")
        {
            
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

        string ApplyingThroughProperChannelText = "Applying Through Proper Channel also?";
        string ApplyingThroughProperChannel = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplyingThroughProperChannelText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(ApplyingThroughProperChannel, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

      
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);


        PdfPTable tblAddress = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblAddress.WidthPercentage = 100;
        tblAddress.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Correspondence Address", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
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

       
        string NearRailText = "Nearest Railway Station";
       
        string PinCodeText = "Pin Code";
       
        setAddTextToTable(tblAddress, false, 7f, NearRailText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestRailwaystation"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, PinCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPin"].ToString(), true, MINIMUMHEIGHT_3);
       

        string StdCodeText = "Telephone No. with STD Code";

        string MoblieText = "Mobile No.";
        

        setAddTextToTable(tblAddress, false, 7f, StdCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strTelephone"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, MoblieText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMobileNo"].ToString(), true, MINIMUMHEIGHT_3);



        
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);

       
                
        PdfPTable tblQualification = new PdfPTable(9);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f, 7f };
        tblQualification.WidthPercentage = 100;
        tblQualification.SetWidths(colWidthPercentages);


       

        
        wicell = new PdfPCell(new Phrase("Educational Qualification Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAddress.AddCell(wicell);
        
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


       
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);

       

        PdfPTable tblExperience = new PdfPTable(1);
        colWidthPercentages = new[] { 100f };
        tblExperience.WidthPercentage = 100;
        tblExperience.SetWidths(colWidthPercentages);

        

        wicell = new PdfPCell(new Phrase("Experience Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 6;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblExperience.AddCell(wicell);

        PdfPTable tblExperienceImmediate = new PdfPTable(9);
        colWidthPercentages = new[] { 10f, 15f, 10f, 10f,7f,10f,7f,7f,10f };
        tblExperienceImmediate.WidthPercentage = 100;
        tblExperienceImmediate.SetWidths(colWidthPercentages);


      

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
            var todate = ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString();
            var _todate = todate.Substring(0, 10);
            setAddTextToTable(tblExperienceImmediate, false, 7f, _todate, true, MINIMUMHEIGHT_3);
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


       
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);     


        

        PdfPTable tblOtherDetails = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "I hereby opt an option for disclosure scheme provided under of Right to Information Act, 2005", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblOtherDetails, false, 7f, this.RTIAns, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tblOtherDetails, false, 7f, "Signature", true, 45);
        

        
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


    public MemoryStream CreateRequirtment120()
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


        
        //var chkDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        var chkDetails = PshCommon.DynamicSql<tbl_mst_CandidatePersonalDetails>("Select * from tbl_mst_CandidatePersonalDetails_120", null, null, false).data.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        //var EducationDetails = objCanQunification.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        var EducationDetails = PshCommon.DynamicSql<tbl_mst_CandidateQualification>("Select * from tbl_mst_CandidateQualification_120", null, null, false).data.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        //var ExperienceDetails = objcanexperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        var ExperienceDetails = PshCommon.DynamicSql<tbl_mst_CandidateExperience>("Select * from tbl_mst_CandidateExperience_120", null, null, false).data.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        string totalExp = "0";
        if (ExperienceDetails != null)
        {

            decimal dectotalExp = ExperienceDetails.Where(x => x.str_noyears != "").Sum(x => Convert.ToInt32(x.str_noyears));
            var totalYears = Math.Truncate(dectotalExp / 365);
            var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
            var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
            totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
        }

        System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();
        System.Data.DataSet ApplicantEducation = EducationDetails.ToDataset();
        System.Data.DataSet ApplicantExperience = ExperienceDetails.ToDataset();
        string imageURLLogo = HttpContext.Current.Server.MapPath(this.HCLLogo);
        iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);

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

        colWidthPercentages = new[] { 26f, 37f, 37f };
        tbldecipline.WidthPercentage = 100;
        tbldecipline.SetWidths(colWidthPercentages);


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



        var wicellphoto = new PdfPCell(imgphoto);
        wicellphoto.FixedHeight = 90;
        wicellphoto.Colspan = 0;
        wicellphoto.Rowspan = 10;
        wicellphoto.PaddingLeft = 15f;
        wicellphoto.PaddingTop = 10f;
        wicellphoto.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imgphoto.ScaleAbsolute(100, 80);
        tbldecipline.AddCell(wicellphoto);


        var dob = ApplicationReportInfo.Tables[0].Rows[0]["dtDOB"].ToString();
        var _dob = dob.Substring(0, 10);
        setAddTextToTable(tbldecipline, false, 7f, NameOfThePostText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, NameOfThePost, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, NameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 9f, ApplicationReportInfo.Tables[0].Rows[0]["strApplicantName"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, DOBText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, _dob, true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, MotherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMotherName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, FatherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFatherName"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, SpouseNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strSpouseName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, EmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strEmail"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AlternateEmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAlternate_EmaiID"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AdharcardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAadharNo"].ToString(), true, MINIMUMHEIGHT_3);



        setAddTextToTable(tbldecipline, false, 7f, PanCardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPANNo"].ToString(), true, MINIMUMHEIGHT_3);





        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);

        PdfPTable tblpersonalInfo = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblpersonalInfo.WidthPercentage = 100;
        tblpersonalInfo.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Personal Information", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string NationalityText = "Nationality";


        string DomicileText = "Domicile State";

        setAddTextToTable(tblpersonalInfo, false, 7f, NationalityText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNationality"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, DomicileText, true, MINIMUMHEIGHT_3);
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

        if (Category != "General")
        {

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

        string ApplyingThroughProperChannelText = "Applying Through Proper Channel also?";
        string ApplyingThroughProperChannel = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplyingThroughProperChannelText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(ApplyingThroughProperChannel, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);


        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);


        PdfPTable tblAddress = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblAddress.WidthPercentage = 100;
        tblAddress.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Correspondence Address", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
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


        string NearRailText = "Nearest Railway Station";

        string PinCodeText = "Pin Code";

        setAddTextToTable(tblAddress, false, 7f, NearRailText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestRailwaystation"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, PinCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPin"].ToString(), true, MINIMUMHEIGHT_3);


        string StdCodeText = "Telephone No. with STD Code";

        string MoblieText = "Mobile No.";


        setAddTextToTable(tblAddress, false, 7f, StdCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strTelephone"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, MoblieText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMobileNo"].ToString(), true, MINIMUMHEIGHT_3);




        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);



        PdfPTable tblQualification = new PdfPTable(9);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f, 7f };
        tblQualification.WidthPercentage = 100;
        tblQualification.SetWidths(colWidthPercentages);





        wicell = new PdfPCell(new Phrase("Educational Qualification Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAddress.AddCell(wicell);

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



        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);



        PdfPTable tblExperience = new PdfPTable(1);
        colWidthPercentages = new[] { 100f };
        tblExperience.WidthPercentage = 100;
        tblExperience.SetWidths(colWidthPercentages);



        wicell = new PdfPCell(new Phrase("Experience Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 6;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblExperience.AddCell(wicell);

        PdfPTable tblExperienceImmediate = new PdfPTable(9);
        colWidthPercentages = new[] { 10f, 15f, 10f, 10f, 7f, 10f, 7f, 7f, 10f };
        tblExperienceImmediate.WidthPercentage = 100;
        tblExperienceImmediate.SetWidths(colWidthPercentages);




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
            var todate = ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString();
            var _todate = todate.Substring(0, 10);
            setAddTextToTable(tblExperienceImmediate, false, 7f, _todate, true, MINIMUMHEIGHT_3);
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
        setAddTextToTable(tblExperienceImmediate, false, 7f, totalExp, true, MINIMUMHEIGHT_3, 4);



        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);




        PdfPTable tblOtherDetails = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "I hereby opt an option for disclosure scheme provided under of Right to Information Act, 2005", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblOtherDetails, false, 7f, this.RTIAns, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tblOtherDetails, false, 7f, "Signature", true, 45);



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
        cell.AddElement(tblOtherDetails);
        //
        table.AddCell(cell);

        pdfDoc.Add(table);

        pdfDoc.Close();

        return memStream;

    }
    public MemoryStream CreateRequirtment134()
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



        var chkDetails = PshCommon.DynamicSql<tbl_mst_CandidatePersonalDetails>("Select * from tbl_mst_CandidatePersonalDetails_134", null, null, false).data.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        var EducationDetails = PshCommon.DynamicSql<tbl_mst_CandidateQualification>("Select * from tbl_mst_CandidateQualification_134", null, null, false).data.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        var AdditionalEducationDetails = PshCommon.DynamicSql<tbl_mst_CandidateQualificationAdditional>("Select * from tbl_mst_CandidateQualificationAdditional_134", null, null, false).data.Where(x => x.CandidateId == this.candidateid).ToList();
        var ExperienceDetails = PshCommon.DynamicSql<tbl_mst_CandidateExperience>("Select * from tbl_mst_CandidateExperience_134", null, null, false).data.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        string totalExp = "0";
        if (ExperienceDetails != null)
        {

            decimal dectotalExp = ExperienceDetails.Where(x => x.str_noyears != "").Sum(x => Convert.ToInt32(x.str_noyears));
            var totalYears = Math.Truncate(dectotalExp / 365);
            var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
            var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
            totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
        }

        System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();
        System.Data.DataSet ApplicantEducation = EducationDetails.ToDataset();
        System.Data.DataSet ApplicantAdditionalEducation = AdditionalEducationDetails.ToDataset();
        System.Data.DataSet ApplicantExperience = ExperienceDetails.ToDataset();
        string imageURLLogo = HttpContext.Current.Server.MapPath(this.HCLLogo);
        iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);

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

        // Add by gaurav 

        var wicell1 = new PdfPCell(new Phrase(HeadLine5, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell1.Colspan = 4;
        wicell1.BorderWidth = 0;
        wicell1.PaddingLeft = 190f;
        wicell1.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
        wTable.AddCell(wicell1);

        innerCell.AddElement(wTable);
        innerTable.AddCell(innerCell);


        PdfPTable tbldecipline = new PdfPTable(3);

        colWidthPercentages = new[] { 26f, 37f, 37f };
        tbldecipline.WidthPercentage = 100;
        tbldecipline.SetWidths(colWidthPercentages);


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
        string NameOfThePost = post  + " (" + Decipline + ")"; ;


        string imageURLPhoto = HttpContext.Current.Server.MapPath(this.HCLPhoto);


        iTextSharp.text.Image imgphoto = iTextSharp.text.Image.GetInstance(imageURLPhoto);



        var wicellphoto = new PdfPCell(imgphoto);
        wicellphoto.FixedHeight = 90;
        wicellphoto.Colspan = 0;
        wicellphoto.Rowspan = 10;
        wicellphoto.PaddingLeft = 40f;
        wicellphoto.PaddingTop = 10f;
        wicellphoto.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imgphoto.ScaleAbsolute(100, 80);
        tbldecipline.AddCell(wicellphoto);


        var dob = ApplicationReportInfo.Tables[0].Rows[0]["dtDOB"].ToString();
        var _dob = dob.Substring(0, 10);
        setAddTextToTable(tbldecipline, false, 7f, NameOfThePostText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, NameOfThePost , true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, NameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 9f, ApplicationReportInfo.Tables[0].Rows[0]["strApplicantName"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, DOBText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, _dob, true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, MotherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMotherName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, FatherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFatherName"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, SpouseNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strSpouseName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, EmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strEmail"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AlternateEmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAlternate_EmaiID"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AdharcardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAadharNo"].ToString(), true, MINIMUMHEIGHT_3);



        setAddTextToTable(tbldecipline, false, 7f, PanCardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPANNo"].ToString(), true, MINIMUMHEIGHT_3);





        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);

        PdfPTable tblpersonalInfo = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblpersonalInfo.WidthPercentage = 100;
        tblpersonalInfo.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Personal Information", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string NationalityText = "Nationality";


        string DomicileText = "Domicile State";

        setAddTextToTable(tblpersonalInfo, false, 7f, NationalityText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNationality"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, DomicileText, true, MINIMUMHEIGHT_3);
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

        if (Category != "General")
        {

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


        }


        string PwdText = "Pwd(40% or More Disability)";
        string Pwd = ApplicationReportInfo.Tables[0].Rows[0]["strPWD"].ToString();

        if (Pwd == "Yes")
        {
            Pwd = Pwd + " , PWD Type : " + ApplicationReportInfo.Tables[0].Rows[0]["strtypeofdisable"].ToString() + " , Cerfificate No. : " + ApplicationReportInfo.Tables[0].Rows[0]["strcertificateno1"].ToString() + " , Issue Date : " + ApplicationReportInfo.Tables[0].Rows[0]["dt_certificateissuedate1"].ToString() + " , Issuing Authority : " + ApplicationReportInfo.Tables[0].Rows[0]["strcertificateissue1"].ToString()
                + ", Is Scribe Required in Written Test : " + ApplicationReportInfo.Tables[0].Rows[0]["strScribe"].ToString();
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

        string ApplyingThroughProperChannelText = "Applying Through Proper Channel also?";
        string ApplyingThroughProperChannel = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplyingThroughProperChannelText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(ApplyingThroughProperChannel, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        // Add cody by gaurav 

        string WrittenTestCityText = "Written Test City";
        string WrittenTestCity = ApplicationReportInfo.Tables[0].Rows[0]["strTestCity"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, WrittenTestCityText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(WrittenTestCity, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);





        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);


        PdfPTable tblAddress = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblAddress.WidthPercentage = 100;
        tblAddress.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Correspondence Address", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
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


        string NearRailText = "Nearest Railway Station";

        string PinCodeText = "Pin Code";

        setAddTextToTable(tblAddress, false, 7f, NearRailText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestRailwaystation"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, PinCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPin"].ToString(), true, MINIMUMHEIGHT_3);


        string StdCodeText = "Telephone No. with STD Code";

        string MoblieText = "Mobile No.";


        setAddTextToTable(tblAddress, false, 7f, StdCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strTelephone"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, MoblieText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMobileNo"].ToString(), true, MINIMUMHEIGHT_3);




        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);



        PdfPTable tblQualification = new PdfPTable(8);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f};
        tblQualification.WidthPercentage = 100;
        tblQualification.SetWidths(colWidthPercentages);





        wicell = new PdfPCell(new Phrase("Educational Qualification Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 9;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblQualification.AddCell(wicell);

        setAddTextToTable(tblQualification, true, 7f, "Exam Pased", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Course Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Board/ University", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Stream/ Special Subject", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Date of Passing", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Duration of Couser(in Year)", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "(%) Marks", true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblQualification, true, 7f, "Division/ Grade", true, MINIMUMHEIGHT_3);
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
            //setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_division"].ToString(), true, MINIMUMHEIGHT_3);
            if (ApplicantEducation.Tables[0].Rows[i]["Str_Marks"].ToString() != "")
            {
                setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["StrRemarks"].ToString(), true, MINIMUMHEIGHT_3);
            }
            else
            {
                setAddTextToTable(tblQualification, false, 7f, "", true, MINIMUMHEIGHT_3);
            }
            
        }



        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        //setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);


        


        // Additional Details 

        PdfPTable tblAdditionalQualification = new PdfPTable(8);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f };
        tblAdditionalQualification.WidthPercentage = 100;
        tblAdditionalQualification.SetWidths(colWidthPercentages);


        wicell1 = new PdfPCell(new Phrase("Details of other Qualification/Certificate", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell1.Colspan = 8;
        wicell1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAdditionalQualification.AddCell(wicell1);

        setAddTextToTable(tblAdditionalQualification, true, 7f, "Exam Pased", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Course Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Board/ University", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Stream/ Special Subject", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Date of Passing", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Duration of Couser(in Year)", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "(%) Marks", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Remarks", true, MINIMUMHEIGHT_3);

        for (int i = 0; i < ApplicantAdditionalEducation.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_exampassed"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_course"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_board"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_passingdetails"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_passingyear"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_duration"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_Marks"].ToString(), true, MINIMUMHEIGHT_3);
            //setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_division"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["StrRemarks"].ToString(), true, MINIMUMHEIGHT_3);


        }

        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        //setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);



        PdfPTable tblExperience = new PdfPTable(1);
        colWidthPercentages = new[] { 100f };
        tblExperience.WidthPercentage = 100;
        tblExperience.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Experience Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 6;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblExperience.AddCell(wicell);

        PdfPTable tblExperienceImmediate = new PdfPTable(9);
        colWidthPercentages = new[] { 10f, 15f, 10f, 10f, 7f, 10f, 7f, 7f, 10f };
        tblExperienceImmediate.WidthPercentage = 100;
        tblExperienceImmediate.SetWidths(colWidthPercentages);




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
            var todate = ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString();
            var _todate = todate.Substring(0, 10);
            setAddTextToTable(tblExperienceImmediate, false, 7f, _todate, true, MINIMUMHEIGHT_3);
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
        setAddTextToTable(tblExperienceImmediate, false, 7f, totalExp, true, MINIMUMHEIGHT_3, 4);



        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);




        PdfPTable tblOtherDetails = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "I hereby opt an option for disclosure scheme provided under of Right to Information Act, 2005", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblOtherDetails, false, 7f, this.RTIAns, true, MINIMUMHEIGHT_3);

        if (ApplicationReportInfo.Tables[0].Rows[0]["strFinalSubmit"].ToString() == "Yes")
        {
            PdfPTable tblOtherDetails1 = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails1.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "I hereby declare that all the statement made in this application is True, Complete and Correct to the best of my knowledge and belief. I understand that in the event of any information being found untrue or incorrect at any stage or I am not satisfying any of the eligibility criteria stipulated, and also in case of creating influence/undue pressure regarding recruitment shall tantamount to cancellation of my candidature", true, MINIMUMHEIGHT_3);
        
            setAddTextToTable(tblOtherDetails, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFinalSubmit"].ToString(), true, MINIMUMHEIGHT_3);
        }


        tblOtherDetails.SplitLate = false;
        tblOtherDetails.SplitRows = false;
        setAddTextToTable(tblOtherDetails, false, 7f, "Signature", true, 90);



        string imageSignUrl = HttpContext.Current.Server.MapPath(this.SignPhoto);
        iTextSharp.text.Image imgSign = iTextSharp.text.Image.GetInstance(imageSignUrl);
        var wicellSign = new PdfPCell(imgSign);
        wicellSign.FixedHeight = 90;
        wicellSign.Colspan = 0;
        //wicellSign.Rowspan = 6;
        wicellSign.PaddingTop = 8f;
        wicellSign.PaddingBottom = 8f;
        wicellSign.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        imgSign.ScaleAbsolute(280, 30);
        tblOtherDetails.AddCell(wicellSign);



        cell.AddElement(innerTable);
        cell.AddElement(tbldecipline);
        cell.AddElement(tblpersonalInfo);
        cell.AddElement(tblAddress);
        cell.AddElement(tblQualification);
        cell.AddElement(tblAdditionalQualification);
        cell.AddElement(tblExperience);
        cell.AddElement(tblExperienceImmediate);
        cell.AddElement(tblOtherDetails);
        //
        table.AddCell(cell);

        pdfDoc.Add(table);

        pdfDoc.Close();

        return memStream;

    }
    public MemoryStream CreateRequirtment34()
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



        var chkDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == this.candidateid).ToList();

        var CertificateDetails = objCertificateDetails.tbl_mst_CandidateCertificateDetails.Where(x => x.fk_CandidateId == this.candidateid).ToList();

        var EducationDetails = objCanQunification.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        var AdditionalEducationDetails = objAdditionalEducation.tbl_mst_CandidateQualificationAdditional.Where(x => x.CandidateId == this.candidateid).ToList();
        var ExperienceDetails = objcanexperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        var expDetails = ExperienceDetails.Count == 0 ? null : ExperienceDetails;

        string totalExp = "0";
        if (ExperienceDetails != null)
        {

            decimal dectotalExp = ExperienceDetails.Where(x => x.str_noyears != "").Sum(x => Convert.ToInt32(x.str_noyears));
            var totalYears = Math.Truncate(dectotalExp / 365);
            var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
            var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
            totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
        }

        System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();
        System.Data.DataSet ApplicantCertificate = CertificateDetails.ToDataset();
        System.Data.DataSet ApplicantEducation = EducationDetails.ToDataset();
        System.Data.DataSet ApplicantAdditionalEducation = AdditionalEducationDetails.ToDataset();
        System.Data.DataSet ApplicantExperience = ExperienceDetails.ToDataset();
        string imageURLLogo = HttpContext.Current.Server.MapPath(this.HCLLogo);
        iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);

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

        // Add by gaurav 

        var wicell1 = new PdfPCell(new Phrase(HeadLine5, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell1.Colspan = 4;
        wicell1.BorderWidth = 0;
        wicell1.PaddingLeft = 190f;
        wicell1.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
        wTable.AddCell(wicell1);

        innerCell.AddElement(wTable);
        innerTable.AddCell(innerCell);


        PdfPTable tbldecipline = new PdfPTable(3);

        colWidthPercentages = new[] { 26f, 37f, 37f };
        tbldecipline.WidthPercentage = 100;
        tbldecipline.SetWidths(colWidthPercentages);


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
        string NameOfThePost = post + " (" + Decipline + ")"; ;


        string imageURLPhoto = HttpContext.Current.Server.MapPath(this.HCLPhoto);


        iTextSharp.text.Image imgphoto = iTextSharp.text.Image.GetInstance(imageURLPhoto);



        var wicellphoto = new PdfPCell(imgphoto);
        wicellphoto.FixedHeight = 90;
        wicellphoto.Colspan = 0;
        wicellphoto.Rowspan = 10;
        wicellphoto.PaddingLeft = 40f;
        wicellphoto.PaddingTop = 10f;
        wicellphoto.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imgphoto.ScaleAbsolute(100, 80);
        tbldecipline.AddCell(wicellphoto);


        var dob = ApplicationReportInfo.Tables[0].Rows[0]["dtDOB"].ToString();
        var _dob = dob.Substring(0, 10);
        setAddTextToTable(tbldecipline, false, 7f, NameOfThePostText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, NameOfThePost, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, NameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 9f, ApplicationReportInfo.Tables[0].Rows[0]["strApplicantName"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, DOBText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, _dob, true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, MotherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMotherName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, FatherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFatherName"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, SpouseNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strSpouseName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, EmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strEmail"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AlternateEmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAlternate_EmaiID"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AdharcardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAadharNo"].ToString(), true, MINIMUMHEIGHT_3);



        setAddTextToTable(tbldecipline, false, 7f, PanCardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPANNo"].ToString(), true, MINIMUMHEIGHT_3);





        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);

        PdfPTable tblpersonalInfo = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblpersonalInfo.WidthPercentage = 100;
        tblpersonalInfo.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Personal Information", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string NationalityText = "Nationality";


        string DomicileText = "Domicile State";

        setAddTextToTable(tblpersonalInfo, false, 7f, NationalityText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNationality"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, DomicileText, true, MINIMUMHEIGHT_3);
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

        if (Category != "General")
        {

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


        }


        string PwdText = "Pwd(40% or More Disability)";
        string Pwd = ApplicationReportInfo.Tables[0].Rows[0]["strPWD"].ToString();

        if (Pwd == "Yes")
        {
            Pwd = Pwd + " , PWD Type : " + ApplicationReportInfo.Tables[0].Rows[0]["strtypeofdisable"].ToString() + " , Cerfificate No. : " + ApplicationReportInfo.Tables[0].Rows[0]["strcertificateno1"].ToString() + " , Issue Date : " + ApplicationReportInfo.Tables[0].Rows[0]["dt_certificateissuedate1"].ToString() + " , Issuing Authority : " + ApplicationReportInfo.Tables[0].Rows[0]["strcertificateissue1"].ToString()
                + ", Is Scribe Required in Written Test : " + ApplicationReportInfo.Tables[0].Rows[0]["strScribe"].ToString();
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

        string ApplyingThroughProperChannelText = "Applying Through Proper Channel also?";
        string ApplyingThroughProperChannel = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplyingThroughProperChannelText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(ApplyingThroughProperChannel, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        // Add cody by gaurav 

        string SportsPersonText = "Meritorious Sports person";
        string SportsPerson = ApplicationReportInfo.Tables[0].Rows[0]["strSportsperson"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, SportsPersonText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(SportsPerson, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);





        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);


        PdfPTable tblAddress = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblAddress.WidthPercentage = 100;
        tblAddress.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Correspondence Address", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
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


        string NearRailText = "Nearest Railway Station";

        string PinCodeText = "Pin Code";

        setAddTextToTable(tblAddress, false, 7f, NearRailText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestRailwaystation"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, PinCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPin"].ToString(), true, MINIMUMHEIGHT_3);


        string StdCodeText = "Telephone No. with STD Code";

        string MoblieText = "Mobile No.";


        setAddTextToTable(tblAddress, false, 7f, StdCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strTelephone"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, MoblieText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMobileNo"].ToString(), true, MINIMUMHEIGHT_3);




        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);


        // Add Certificate Details 


        PdfPTable tblCertificateDetails = new PdfPTable(4);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f };
        tblCertificateDetails.WidthPercentage = 100;
        tblCertificateDetails.SetWidths(colWidthPercentages);





        wicell = new PdfPCell(new Phrase("Certificate Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblCertificateDetails.AddCell(wicell);

        setAddTextToTable(tblCertificateDetails, true, 7f, "Certificate Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblCertificateDetails, true, 7f, "Certificate No", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblCertificateDetails, true, 7f, "Certificate Issue Date", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblCertificateDetails, true, 7f, "Issuing Authority", true, MINIMUMHEIGHT_3);


        for (int i = 0; i < ApplicantCertificate.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tblCertificateDetails, false, 7f, ApplicantCertificate.Tables[0].Rows[i]["CertificateName"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblCertificateDetails, false, 7f, ApplicantCertificate.Tables[0].Rows[i]["CertificateNo"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblCertificateDetails, false, 7f, ApplicantCertificate.Tables[0].Rows[i]["CertificateIssueDate"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblCertificateDetails, false, 7f, ApplicantCertificate.Tables[0].Rows[i]["IssuingAuthority"].ToString(), true, MINIMUMHEIGHT_3);
        }



        setAddTextToTable(tblCertificateDetails, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblCertificateDetails, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblCertificateDetails, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblCertificateDetails, false, 7f, "", false, MINIMUMHEIGHT_New3);




        PdfPTable tblQualification = new PdfPTable(8);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f };
        tblQualification.WidthPercentage = 100;
        tblQualification.SetWidths(colWidthPercentages);





        wicell = new PdfPCell(new Phrase("Educational Qualification Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 9;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblQualification.AddCell(wicell);

        setAddTextToTable(tblQualification, true, 7f, "Exam Pased", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Course Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Board/ University", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Stream/ Special Subject", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Date of Passing", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Duration of Couser(in Year)", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "(%) Marks", true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblQualification, true, 7f, "Division/ Grade", true, MINIMUMHEIGHT_3);
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
            //setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_division"].ToString(), true, MINIMUMHEIGHT_3);
            if (ApplicantEducation.Tables[0].Rows[i]["Str_Marks"].ToString() != "")
            {
                setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["StrRemarks"].ToString(), true, MINIMUMHEIGHT_3);
            }
            else
            {
                setAddTextToTable(tblQualification, false, 7f, "", true, MINIMUMHEIGHT_3);
            }

        }



        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        //setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);





        // Additional Details 

        PdfPTable tblAdditionalQualification = new PdfPTable(8);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f };
        tblAdditionalQualification.WidthPercentage = 100;
        tblAdditionalQualification.SetWidths(colWidthPercentages);


        wicell1 = new PdfPCell(new Phrase("Details of other Qualification/Certificate", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell1.Colspan = 8;
        wicell1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAdditionalQualification.AddCell(wicell1);

        setAddTextToTable(tblAdditionalQualification, true, 7f, "Exam Pased", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Course Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Board/ University", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Stream/ Special Subject", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Date of Passing", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Duration of Couser(in Year)", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "(%) Marks", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Remarks", true, MINIMUMHEIGHT_3);

        for (int i = 0; i < ApplicantAdditionalEducation.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_exampassed"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_course"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_board"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_passingdetails"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_passingyear"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_duration"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_Marks"].ToString(), true, MINIMUMHEIGHT_3);
            //setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_division"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["StrRemarks"].ToString(), true, MINIMUMHEIGHT_3);


        }

        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        //setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);


        

            PdfPTable tblExperience = new PdfPTable(1);
            colWidthPercentages = new[] { 100f };
            tblExperience.WidthPercentage = 100;
            tblExperience.SetWidths(colWidthPercentages);


        PdfPTable tblExperienceImmediate = new PdfPTable(9);
        colWidthPercentages = new[] { 10f, 15f, 10f, 10f, 7f, 10f, 7f, 7f, 10f };
        tblExperienceImmediate.WidthPercentage = 100;
        tblExperienceImmediate.SetWidths(colWidthPercentages);

        if (expDetails != null)
        {
            wicell = new PdfPCell(new Phrase("Experience Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
            wicell.Colspan = 6;
            wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            tblExperience.AddCell(wicell);

            




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
                var todate = ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString();
                var _todate = todate.Substring(0, 10);
                setAddTextToTable(tblExperienceImmediate, false, 7f, _todate, true, MINIMUMHEIGHT_3);
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
            setAddTextToTable(tblExperienceImmediate, false, 7f, totalExp, true, MINIMUMHEIGHT_3, 4);



            setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
            setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
            setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
            setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        }




        PdfPTable tblOtherDetails = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "I hereby opt an option for disclosure scheme provided under of Right to Information Act, 2005", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblOtherDetails, false, 7f, this.RTIAns, true, MINIMUMHEIGHT_3);

        if (ApplicationReportInfo.Tables[0].Rows[0]["strFinalSubmit"].ToString() == "Yes")
        {
            PdfPTable tblOtherDetails1 = new PdfPTable(2);
            colWidthPercentages = new[] { 20f, 70f };
            tblOtherDetails1.WidthPercentage = 100;
            setAddTextToTable(tblOtherDetails, false, 7f, "I hereby declare that all the statement made in this application is True, Complete and Correct to the best of my knowledge and belief. I understand that in the event of any information being found untrue or incorrect at any stage or I am not satisfying any of the eligibility criteria stipulated, and also in case of creating influence/undue pressure regarding recruitment shall tantamount to cancellation of my candidature", true, MINIMUMHEIGHT_3);

            setAddTextToTable(tblOtherDetails, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFinalSubmit"].ToString(), true, MINIMUMHEIGHT_3);
        }


        tblOtherDetails.SplitLate = false;
        tblOtherDetails.SplitRows = false;
        setAddTextToTable(tblOtherDetails, false, 7f, "Signature", true, 90);



        string imageSignUrl = HttpContext.Current.Server.MapPath(this.SignPhoto);
        iTextSharp.text.Image imgSign = iTextSharp.text.Image.GetInstance(imageSignUrl);
        var wicellSign = new PdfPCell(imgSign);
        wicellSign.FixedHeight = 90;
        wicellSign.Colspan = 0;
        //wicellSign.Rowspan = 6;
        wicellSign.PaddingTop = 8f;
        wicellSign.PaddingBottom = 8f;
        wicellSign.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        imgSign.ScaleAbsolute(280, 30);
        tblOtherDetails.AddCell(wicellSign);



        cell.AddElement(innerTable);
        cell.AddElement(tbldecipline);
        cell.AddElement(tblpersonalInfo);
        cell.AddElement(tblAddress);
        cell.AddElement(tblCertificateDetails);
        cell.AddElement(tblQualification);
        cell.AddElement(tblAdditionalQualification);
        cell.AddElement(tblExperience);
        cell.AddElement(tblExperienceImmediate);
        cell.AddElement(tblOtherDetails);
        //
        table.AddCell(cell);

        pdfDoc.Add(table);

        pdfDoc.Close();

        return memStream;

    }

    public MemoryStream CreateRequirtment129()
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



        //var chkDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        var chkDetails = PshCommon.DynamicSql<tbl_mst_CandidatePersonalDetails>("Select * from tbl_mst_CandidatePersonalDetails_129", null, null, false).data.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        //var EducationDetails = objCanQunification.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        var EducationDetails = PshCommon.DynamicSql<tbl_mst_CandidateQualification>("Select * from tbl_mst_CandidateQualification_129", null, null, false).data.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        //var ExperienceDetails = objcanexperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        var ExperienceDetails = PshCommon.DynamicSql<tbl_mst_CandidateExperience>("Select * from tbl_mst_CandidateExperience_129", null, null, false).data.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        string totalExp = "0";
        if (ExperienceDetails != null && ExperienceDetails.Count>0)
        {

            decimal dectotalExp = ExperienceDetails.Where(x => x.str_noyears != "").Sum(x => Convert.ToInt32(x.str_noyears));
            var totalYears = Math.Truncate(dectotalExp / 365);
            var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
            var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
            totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
        }

        System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();
        System.Data.DataSet ApplicantEducation = EducationDetails.ToDataset();
        System.Data.DataSet ApplicantExperience = ExperienceDetails.ToDataset();
        string imageURLLogo = HttpContext.Current.Server.MapPath(this.HCLLogo);
        iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);

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

        colWidthPercentages = new[] { 26f, 37f, 37f };
        tbldecipline.WidthPercentage = 100;
        tbldecipline.SetWidths(colWidthPercentages);


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



        var wicellphoto = new PdfPCell(imgphoto);
        wicellphoto.FixedHeight = 90;
        wicellphoto.Colspan = 0;
        wicellphoto.Rowspan = 10;
        wicellphoto.PaddingLeft = 15f;
        wicellphoto.PaddingTop = 10f;
        wicellphoto.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imgphoto.ScaleAbsolute(100, 80);
        tbldecipline.AddCell(wicellphoto);


        var dob = ApplicationReportInfo.Tables[0].Rows[0]["dtDOB"].ToString();
        var _dob = dob.Substring(0, 10);
        setAddTextToTable(tbldecipline, false, 7f, NameOfThePostText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, NameOfThePost, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, NameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 9f, ApplicationReportInfo.Tables[0].Rows[0]["strApplicantName"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, DOBText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, _dob, true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, MotherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMotherName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, FatherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFatherName"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, SpouseNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strSpouseName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, EmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strEmail"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AlternateEmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAlternate_EmaiID"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AdharcardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAadharNo"].ToString(), true, MINIMUMHEIGHT_3);



        setAddTextToTable(tbldecipline, false, 7f, PanCardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPANNo"].ToString(), true, MINIMUMHEIGHT_3);





        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);

        PdfPTable tblpersonalInfo = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblpersonalInfo.WidthPercentage = 100;
        tblpersonalInfo.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Personal Information", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string NationalityText = "Nationality";


        string DomicileText = "Domicile State";

        setAddTextToTable(tblpersonalInfo, false, 7f, NationalityText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNationality"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, DomicileText, true, MINIMUMHEIGHT_3);
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

        if (Category != "General")
        {

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

        string ApplyingThroughProperChannelText = "Applying Through Proper Channel also?";
        string ApplyingThroughProperChannel = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplyingThroughProperChannelText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(ApplyingThroughProperChannel, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);


        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);


        PdfPTable tblAddress = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblAddress.WidthPercentage = 100;
        tblAddress.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Correspondence Address", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
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


        string NearRailText = "Nearest Railway Station";

        string PinCodeText = "Pin Code";

        setAddTextToTable(tblAddress, false, 7f, NearRailText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestRailwaystation"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, PinCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPin"].ToString(), true, MINIMUMHEIGHT_3);


        string StdCodeText = "Telephone No. with STD Code";

        string MoblieText = "Mobile No.";


        setAddTextToTable(tblAddress, false, 7f, StdCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strTelephone"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, MoblieText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMobileNo"].ToString(), true, MINIMUMHEIGHT_3);




        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);



        PdfPTable tblQualification = new PdfPTable(9);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f, 7f };
        tblQualification.WidthPercentage = 100;
        tblQualification.SetWidths(colWidthPercentages);





        wicell = new PdfPCell(new Phrase("Educational Qualification Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAddress.AddCell(wicell);

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



        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);



        PdfPTable tblExperience = new PdfPTable(1);
        colWidthPercentages = new[] { 100f };
        tblExperience.WidthPercentage = 100;
        tblExperience.SetWidths(colWidthPercentages);



        wicell = new PdfPCell(new Phrase("Experience Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 6;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblExperience.AddCell(wicell);

        PdfPTable tblExperienceImmediate = new PdfPTable(9);
        colWidthPercentages = new[] { 10f, 15f, 10f, 10f, 7f, 10f, 7f, 7f, 10f };
        tblExperienceImmediate.WidthPercentage = 100;
        tblExperienceImmediate.SetWidths(colWidthPercentages);




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
            var todate = ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString();
            var _todate = todate.Substring(0, 10);
            setAddTextToTable(tblExperienceImmediate, false, 7f, _todate, true, MINIMUMHEIGHT_3);
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
        setAddTextToTable(tblExperienceImmediate, false, 7f, totalExp, true, MINIMUMHEIGHT_3, 4);



        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);




        PdfPTable tblOtherDetails = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "I hereby opt an option for disclosure scheme provided under of Right to Information Act, 2005", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblOtherDetails, false, 7f, this.RTIAns, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tblOtherDetails, false, 7f, "Signature", true, 45);



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
        cell.AddElement(tblOtherDetails);
        //
        table.AddCell(cell);

        pdfDoc.Add(table);

        pdfDoc.Close();

        return memStream;

    }

    public MemoryStream CreateRequirtment51()
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



        //var chkDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        var chkDetails = PshCommon.DynamicSql<tbl_mst_CandidatePersonalDetails>("Select * from tbl_mst_CandidatePersonalDetails_51", null, null, false).data.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        //var EducationDetails = objCanQunification.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        var EducationDetails = PshCommon.DynamicSql<tbl_mst_CandidateQualification>("Select * from tbl_mst_CandidateQualification_51", null, null, false).data.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        //var ExperienceDetails = objcanexperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        var ExperienceDetails = PshCommon.DynamicSql<tbl_mst_CandidateExperience>("Select * from tbl_mst_CandidateExperience_51", null, null, false).data.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();

        string totalExp = "0";
        if (ExperienceDetails != null && ExperienceDetails.Count > 0)
        {

            decimal dectotalExp = ExperienceDetails.Where(x => x.str_noyears != "").Sum(x => Convert.ToInt32(x.str_noyears));
            var totalYears = Math.Truncate(dectotalExp / 365);
            var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
            var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
            totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
        }

        System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();
        System.Data.DataSet ApplicantEducation = EducationDetails.ToDataset();
        System.Data.DataSet ApplicantExperience = ExperienceDetails.ToDataset();
        string imageURLLogo = HttpContext.Current.Server.MapPath(this.HCLLogo);
        iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);

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

        colWidthPercentages = new[] { 26f, 37f, 37f };
        tbldecipline.WidthPercentage = 100;
        tbldecipline.SetWidths(colWidthPercentages);


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



        var wicellphoto = new PdfPCell(imgphoto);
        wicellphoto.FixedHeight = 90;
        wicellphoto.Colspan = 0;
        wicellphoto.Rowspan = 10;
        wicellphoto.PaddingLeft = 15f;
        wicellphoto.PaddingTop = 10f;
        wicellphoto.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imgphoto.ScaleAbsolute(100, 80);
        tbldecipline.AddCell(wicellphoto);


        var dob = ApplicationReportInfo.Tables[0].Rows[0]["dtDOB"].ToString();
        var _dob = dob.Substring(0, 10);
        setAddTextToTable(tbldecipline, false, 7f, NameOfThePostText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, NameOfThePost, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, NameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 9f, ApplicationReportInfo.Tables[0].Rows[0]["strApplicantName"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, DOBText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, _dob, true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, MotherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMotherName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, FatherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFatherName"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, SpouseNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strSpouseName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, EmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strEmail"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AlternateEmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAlternate_EmaiID"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AdharcardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAadharNo"].ToString(), true, MINIMUMHEIGHT_3);



        setAddTextToTable(tbldecipline, false, 7f, PanCardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPANNo"].ToString(), true, MINIMUMHEIGHT_3);





        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);

        PdfPTable tblpersonalInfo = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblpersonalInfo.WidthPercentage = 100;
        tblpersonalInfo.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Personal Information", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string NationalityText = "Nationality";


        string DomicileText = "Domicile State";

        setAddTextToTable(tblpersonalInfo, false, 7f, NationalityText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNationality"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, DomicileText, true, MINIMUMHEIGHT_3);
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

        if (Category != "General")
        {

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

        string ApplyingThroughProperChannelText = "Applying Through Proper Channel also?";
        string ApplyingThroughProperChannel = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplyingThroughProperChannelText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(ApplyingThroughProperChannel, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);


        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);


        PdfPTable tblAddress = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblAddress.WidthPercentage = 100;
        tblAddress.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Correspondence Address", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
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


        string NearRailText = "Nearest Railway Station";

        string PinCodeText = "Pin Code";

        setAddTextToTable(tblAddress, false, 7f, NearRailText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestRailwaystation"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, PinCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPin"].ToString(), true, MINIMUMHEIGHT_3);


        string StdCodeText = "Telephone No. with STD Code";

        string MoblieText = "Mobile No.";


        setAddTextToTable(tblAddress, false, 7f, StdCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strTelephone"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, MoblieText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMobileNo"].ToString(), true, MINIMUMHEIGHT_3);




        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);



        PdfPTable tblQualification = new PdfPTable(9);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f, 7f };
        tblQualification.WidthPercentage = 100;
        tblQualification.SetWidths(colWidthPercentages);





        wicell = new PdfPCell(new Phrase("Educational Qualification Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAddress.AddCell(wicell);

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



        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);



        PdfPTable tblExperience = new PdfPTable(1);
        colWidthPercentages = new[] { 100f };
        tblExperience.WidthPercentage = 100;
        tblExperience.SetWidths(colWidthPercentages);



        wicell = new PdfPCell(new Phrase("Experience Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 6;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblExperience.AddCell(wicell);

        PdfPTable tblExperienceImmediate = new PdfPTable(9);
        colWidthPercentages = new[] { 10f, 15f, 10f, 10f, 7f, 10f, 7f, 7f, 10f };
        tblExperienceImmediate.WidthPercentage = 100;
        tblExperienceImmediate.SetWidths(colWidthPercentages);




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
            var todate = ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString();
            var _todate = todate.Substring(0, 10);
            setAddTextToTable(tblExperienceImmediate, false, 7f, _todate, true, MINIMUMHEIGHT_3);
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
        setAddTextToTable(tblExperienceImmediate, false, 7f, totalExp, true, MINIMUMHEIGHT_3, 4);



        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);




        PdfPTable tblOtherDetails = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "I hereby opt an option for disclosure scheme provided under of Right to Information Act, 2005", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblOtherDetails, false, 7f, this.RTIAns, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tblOtherDetails, false, 7f, "Signature", true, 45);



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
        cell.AddElement(tblOtherDetails);
        //
        table.AddCell(cell);

        pdfDoc.Add(table);

        pdfDoc.Close();

        return memStream;

    }

    public MemoryStream CreateRequirtment35()
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



        var chkDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == this.candidateid).ToList();
        var EducationDetails = objCanQunification.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == this.candidateid).ToList();
        var AdditionalEducationDetails = objAdditionalEducation.tbl_mst_CandidateQualificationAdditional.Where(x => x.CandidateId == this.candidateid).ToList();
        var ExperienceDetails = objcanexperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == this.candidateid).ToList();
        var TransitionCertificate = objtransition.tbl_mst_CandidateTransitionDetails.Where(x => x.fk_CandidateId == this.candidateid).ToList();

        string totalExp = "0";
        if (ExperienceDetails != null)
        {

            decimal dectotalExp = ExperienceDetails.Where(x => x.str_noyears != "").Sum(x => Convert.ToInt32(x.str_noyears));
            var totalYears = Math.Truncate(dectotalExp / 365);
            var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
            var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
            totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
        }

        System.Data.DataSet ApplicationReportInfo = chkDetails.ToDataset();
        System.Data.DataSet ApplicantEducation = EducationDetails.ToDataset();
        System.Data.DataSet ApplicantAdditionalEducation = AdditionalEducationDetails.ToDataset();
        System.Data.DataSet TransitionCertificateDetails = TransitionCertificate.ToDataset();
        System.Data.DataSet ApplicantExperience = ExperienceDetails.ToDataset();
        string imageURLLogo = HttpContext.Current.Server.MapPath(this.HCLLogo);
        iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(imageURLLogo);

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

        // Add by gaurav 

        var wicell1 = new PdfPCell(new Phrase(HeadLine5, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell1.Colspan = 4;
        wicell1.BorderWidth = 0;
        wicell1.PaddingLeft = 190f;
        wicell1.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
        wTable.AddCell(wicell1);

        innerCell.AddElement(wTable);
        innerTable.AddCell(innerCell);


        PdfPTable tbldecipline = new PdfPTable(3);

        colWidthPercentages = new[] { 26f, 37f, 37f };
        tbldecipline.WidthPercentage = 100;
        tbldecipline.SetWidths(colWidthPercentages);


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



        var wicellphoto = new PdfPCell(imgphoto);
        wicellphoto.FixedHeight = 90;
        wicellphoto.Colspan = 0;
        wicellphoto.Rowspan = 10;
        wicellphoto.PaddingLeft = 40f;
        wicellphoto.PaddingTop = 10f;
        wicellphoto.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        imgphoto.ScaleAbsolute(100, 80);
        tbldecipline.AddCell(wicellphoto);


        var dob = ApplicationReportInfo.Tables[0].Rows[0]["dtDOB"].ToString();
        var _dob = dob.Substring(0, 10);
        setAddTextToTable(tbldecipline, false, 7f, NameOfThePostText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 8f, NameOfThePost, true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, NameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, true, 9f, ApplicationReportInfo.Tables[0].Rows[0]["strApplicantName"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, DOBText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, _dob, true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, MotherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMotherName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, FatherNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFatherName"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, SpouseNameText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strSpouseName"].ToString(), true, MINIMUMHEIGHT_3);

        setAddTextToTable(tbldecipline, false, 7f, EmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strEmail"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AlternateEmailIdText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAlternate_EmaiID"].ToString(), true, MINIMUMHEIGHT_3);


        setAddTextToTable(tbldecipline, false, 7f, AdharcardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strAadharNo"].ToString(), true, MINIMUMHEIGHT_3);



        setAddTextToTable(tbldecipline, false, 7f, PanCardText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbldecipline, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPANNo"].ToString(), true, MINIMUMHEIGHT_3);





        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbldecipline, false, 7f, "", false, MINIMUMHEIGHT_New3);

        PdfPTable tblpersonalInfo = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblpersonalInfo.WidthPercentage = 100;
        tblpersonalInfo.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Personal Information", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);

        string NationalityText = "Nationality";


        string DomicileText = "Domicile State";

        setAddTextToTable(tblpersonalInfo, false, 7f, NationalityText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNationality"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblpersonalInfo, false, 7f, DomicileText, true, MINIMUMHEIGHT_3);
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

        if (Category != "General")
        {

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

        string ApplyingThroughProperChannelText = "Applying Through Proper Channel also?";
        string ApplyingThroughProperChannel = ApplicationReportInfo.Tables[0].Rows[0]["strapplyproper"].ToString();
        setAddTextToTable(tblpersonalInfo, false, 7f, ApplyingThroughProperChannelText, true, MINIMUMHEIGHT_3);
        wicell = new PdfPCell(new Phrase(ApplyingThroughProperChannel, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.BLACK)));
        wicell.Colspan = 4;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblpersonalInfo.AddCell(wicell);


        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblpersonalInfo, false, 7f, "", false, MINIMUMHEIGHT_New3);


        PdfPTable tblAddress = new PdfPTable(4);
        colWidthPercentages = new[] { 25f, 40f, 15f, 10f };
        tblAddress.WidthPercentage = 100;
        tblAddress.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Correspondence Address", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 4;
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


        string NearRailText = "Nearest Railway Station";

        string PinCodeText = "Pin Code";

        setAddTextToTable(tblAddress, false, 7f, NearRailText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strNearestRailwaystation"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, PinCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strPin"].ToString(), true, MINIMUMHEIGHT_3);


        string StdCodeText = "Telephone No. with STD Code";

        string MoblieText = "Mobile No.";


        setAddTextToTable(tblAddress, false, 7f, StdCodeText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strTelephone"].ToString(), true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, MoblieText, true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAddress, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strMobileNo"].ToString(), true, MINIMUMHEIGHT_3);




        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAddress, false, 7f, "", false, MINIMUMHEIGHT_New3);






        PdfPTable Transition = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        Transition.WidthPercentage = 100;
        setAddTextToTable(Transition, false, 7f, "Do you have recognized Diploma or Certificate Course in translation from Hindi to English & vice versa :", true, MINIMUMHEIGHT_3);
        setAddTextToTable(Transition, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["HasTransitionCertificate"].ToString(), true, MINIMUMHEIGHT_3);




        PdfPTable tbltransition = new PdfPTable(4);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f };
        tbltransition.WidthPercentage = 100;
        tbltransition.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Details of Translation Certificate", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 9;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tbltransition.AddCell(wicell);

        setAddTextToTable(tbltransition, true, 7f, "Diploma or Certificate Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbltransition, true, 7f, "Institute / University Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbltransition, true, 7f, "Date of Passing", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tbltransition, true, 7f, "Remark", true, MINIMUMHEIGHT_3);




        for (int i = 0; i < TransitionCertificateDetails.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tbltransition, false, 7f, TransitionCertificateDetails.Tables[0].Rows[i]["TransitionCertificateName"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tbltransition, false, 7f, TransitionCertificateDetails.Tables[0].Rows[i]["InstitueName"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tbltransition, false, 7f, TransitionCertificateDetails.Tables[0].Rows[i]["TransitionIssueDate"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tbltransition, false, 7f, TransitionCertificateDetails.Tables[0].Rows[i]["Remark"].ToString(), true, MINIMUMHEIGHT_3);
        }



        setAddTextToTable(tbltransition, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbltransition, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbltransition, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tbltransition, false, 7f, "", false, MINIMUMHEIGHT_New3);


        PdfPTable tblQualification = new PdfPTable(10);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f, 7f, 7f };
        tblQualification.WidthPercentage = 100;
        tblQualification.SetWidths(colWidthPercentages);

        wicell = new PdfPCell(new Phrase("Educational Qualification Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 10;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblQualification.AddCell(wicell);

        setAddTextToTable(tblQualification, true, 7f, "Exam Pased", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Course Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Board/ University", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Stream/ Special Subject", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Date of Passing", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Duration of Couser(in Year)", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "(%) Marks", true, MINIMUMHEIGHT_3);
        //setAddTextToTable(tblQualification, true, 7f, "Division/ Grade", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Medium Of Exam", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblQualification, true, 7f, "Elective/Compulsory Subject", true, MINIMUMHEIGHT_3);
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
            //setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_division"].ToString(), true, MINIMUMHEIGHT_3);

            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["StrExamMedium"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_electivesubject"].ToString(), true, MINIMUMHEIGHT_3);

            if (ApplicantEducation.Tables[0].Rows[i]["Str_Marks"].ToString() != "")
            {
                setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["StrRemarks"].ToString(), true, MINIMUMHEIGHT_3);
            }
            else
            {
                setAddTextToTable(tblQualification, false, 7f, "", true, MINIMUMHEIGHT_3);
            }

        }



        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        //setAddTextToTable(tblQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);





        // Additional Details 

        PdfPTable tblAdditionalQualification = new PdfPTable(8);
        colWidthPercentages = new[] { 15f, 12f, 15f, 15f, 10f, 12f, 7f, 7f };
        tblAdditionalQualification.WidthPercentage = 100;
        tblAdditionalQualification.SetWidths(colWidthPercentages);


        wicell1 = new PdfPCell(new Phrase("Details of other Qualification/Certificate", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell1.Colspan = 8;
        wicell1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblAdditionalQualification.AddCell(wicell1);

        setAddTextToTable(tblAdditionalQualification, true, 7f, "Exam Pased", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Course Name", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Board/ University", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Stream/ Special Subject", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Date of Passing", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Duration of Couser(in Year)", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "(%) Marks", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblAdditionalQualification, true, 7f, "Remarks", true, MINIMUMHEIGHT_3);

        for (int i = 0; i < ApplicantAdditionalEducation.Tables[0].Rows.Count; i++)
        {

            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_exampassed"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_course"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_board"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_passingdetails"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_passingyear"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_duration"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["Str_Marks"].ToString(), true, MINIMUMHEIGHT_3);
            //setAddTextToTable(tblQualification, false, 7f, ApplicantEducation.Tables[0].Rows[i]["Str_division"].ToString(), true, MINIMUMHEIGHT_3);
            setAddTextToTable(tblAdditionalQualification, false, 7f, ApplicantAdditionalEducation.Tables[0].Rows[i]["StrRemarks"].ToString(), true, MINIMUMHEIGHT_3);


        }

        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        //setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblAdditionalQualification, false, 7f, "", false, MINIMUMHEIGHT_New3);




        PdfPTable experiencetransition = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        experiencetransition.WidthPercentage = 100;
        setAddTextToTable(experiencetransition, false, 7f, "Do you have experience of translation work from Hindi to English and vice versa in Central or State Government Office, including Government of India Undertaking :", true, MINIMUMHEIGHT_3);
        setAddTextToTable(experiencetransition, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["HasExperience"].ToString(), true, MINIMUMHEIGHT_3);


        PdfPTable tblExperience = new PdfPTable(1);
        colWidthPercentages = new[] { 100f };
        tblExperience.WidthPercentage = 100;
        tblExperience.SetWidths(colWidthPercentages);


        wicell = new PdfPCell(new Phrase("Experience Details", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLACK)));
        wicell.Colspan = 6;
        wicell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        tblExperience.AddCell(wicell);

        PdfPTable tblExperienceImmediate = new PdfPTable(9);
        colWidthPercentages = new[] { 10f, 15f, 10f, 10f, 7f, 10f, 7f, 7f, 10f };
        tblExperienceImmediate.WidthPercentage = 100;
        tblExperienceImmediate.SetWidths(colWidthPercentages);




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
            var todate = ApplicantExperience.Tables[0].Rows[i]["dt_todate"].ToString();
            var _todate = todate.Substring(0, 10);
            setAddTextToTable(tblExperienceImmediate, false, 7f, _todate, true, MINIMUMHEIGHT_3);
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
        setAddTextToTable(tblExperienceImmediate, false, 7f, totalExp, true, MINIMUMHEIGHT_3, 4);



        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);
        setAddTextToTable(tblExperienceImmediate, false, 7f, "", false, MINIMUMHEIGHT_New3);




        PdfPTable tblOtherDetails = new PdfPTable(2);
        colWidthPercentages = new[] { 20f, 70f };
        tblOtherDetails.WidthPercentage = 100;
        setAddTextToTable(tblOtherDetails, false, 7f, "I hereby opt an option for disclosure scheme provided under of Right to Information Act, 2005", true, MINIMUMHEIGHT_3);
        setAddTextToTable(tblOtherDetails, false, 7f, this.RTIAns, true, MINIMUMHEIGHT_3);

        if (ApplicationReportInfo.Tables[0].Rows[0]["strFinalSubmit"].ToString() == "Yes")
        {
            PdfPTable tblOtherDetails1 = new PdfPTable(2);
            colWidthPercentages = new[] { 20f, 70f };
            tblOtherDetails1.WidthPercentage = 100;
            setAddTextToTable(tblOtherDetails, false, 7f, "I hereby declare that all the statement made in this application is True, Complete and Correct to the best of my knowledge and belief. I understand that in the event of any information being found untrue or incorrect at any stage or I am not satisfying any of the eligibility criteria stipulated, and also in case of creating influence/undue pressure regarding recruitment shall tantamount to cancellation of my candidature", true, MINIMUMHEIGHT_3);

            setAddTextToTable(tblOtherDetails, false, 7f, ApplicationReportInfo.Tables[0].Rows[0]["strFinalSubmit"].ToString(), true, MINIMUMHEIGHT_3);
        }


        tblOtherDetails.SplitLate = false;
        tblOtherDetails.SplitRows = false;
        setAddTextToTable(tblOtherDetails, false, 7f, "Signature", true, 90);



        string imageSignUrl = HttpContext.Current.Server.MapPath(this.SignPhoto);
        iTextSharp.text.Image imgSign = iTextSharp.text.Image.GetInstance(imageSignUrl);
        var wicellSign = new PdfPCell(imgSign);
        wicellSign.FixedHeight = 90;
        wicellSign.Colspan = 0;
        //wicellSign.Rowspan = 6;
        wicellSign.PaddingTop = 8f;
        wicellSign.PaddingBottom = 8f;
        wicellSign.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        imgSign.ScaleAbsolute(280, 30);
        tblOtherDetails.AddCell(wicellSign);



        cell.AddElement(innerTable);
        cell.AddElement(tbldecipline);
        cell.AddElement(tblpersonalInfo);
        cell.AddElement(tblAddress);
        cell.AddElement(tblQualification);
        cell.AddElement(Transition);
        cell.AddElement(tbltransition);
        cell.AddElement(tblAdditionalQualification);
        cell.AddElement(experiencetransition);
        cell.AddElement(tblExperience);
        cell.AddElement(tblExperienceImmediate);
        cell.AddElement(tblOtherDetails);
        //
        table.AddCell(cell);

        pdfDoc.Add(table);

        pdfDoc.Close();

        return memStream;

    }



}
