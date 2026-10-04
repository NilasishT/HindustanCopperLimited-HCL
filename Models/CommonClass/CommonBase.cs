
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hindustancopperlimited.Models.CommonClass
{
    public class CommonBase
    {
        public static bool IsAdvertisementActive(int? AdvId)
        {
            DateTime dt = DateTime.UtcNow.AddMinutes(330);
            tbl_employmentnoticecontext db = new tbl_employmentnoticecontext();
            var noticeDetails = db.tbl_employmentnotice.Where(x => x.Pk_employmentid == AdvId).FirstOrDefault();

            //  return noticeDetails != null && (dt >= Convert.ToDateTime(noticeDetails.dtstartdate) && dt <= Convert.ToDateTime(noticeDetails.dtclosedate));
            //  return noticeDetails != null && (dt.Date >= Convert.ToDateTime(noticeDetails.dtstartdate).Date && dt.Date <= Convert.ToDateTime(noticeDetails.dtclosedate).Date);
            return noticeDetails != null && (dt >= Convert.ToDateTime(noticeDetails.dtstartdate) && dt <= Convert.ToDateTime(noticeDetails.dtclosedate));
        }
        public static bool CheckCandidateCertificate(int CandidateId)
        {
            bool status = true;
            tbl_mst_CandidatePersonalDetailscontext objcanpersonaldetails = new tbl_mst_CandidatePersonalDetailscontext();
            var candi = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == CandidateId).FirstOrDefault();
            if (candi == null || (candi.fk_postid ?? 0) == 0)
            {
                return false;
            }
            List<Vw_Postdesiciplinedetails> postList = new Common().GetPostdesiciplinedetails(Convert.ToInt32(candi.fk_advertiseid));

            using (tbl_mst_CandidateCertificateDetailsContext ctx = new tbl_mst_CandidateCertificateDetailsContext())
            {
                var req = postList.Where(a => a.Pk_Postid == candi.fk_postid).FirstOrDefault();
                if (req == null)
                {
                    status = false;
                }
                else
                {
                    var newlist = ctx.tbl_mst_CandidateCertificateDetails.Where(a => a.fk_CandidateId == CandidateId).ToList();
                    if (req.Postname.ToLower() == "mining mate" || req.Postname.ToLower() == "blaster")
                    {
                        if (newlist.Count != 2)
                        {
                            status = false;
                        }
                    }
                    if (req.Postname.ToLower() == "www")
                    {
                        if (newlist.Count != 1)
                        {
                            status = false;
                        }
                    }
                }
            }
            return status;
        }
        public static decimal? CalculateOnlineFees(int AdvertiseId, string strCategory, bool IsPWD = false, bool IsInternal = false)
        {
            tblOnlineVacancyFees obCaste;
            tblOnlineVacancyFees obPWD;
            tblOnlineVacancyFees obInternal;

            using (tblOnlineVacancyFeeContext ctx = new tblOnlineVacancyFeeContext())
            {
                strCategory = strCategory ?? "";
                var list = (ctx.tblOnlineVacancyFees.Where(a => a.AdvertiseId == AdvertiseId).ToList());
                obPWD = IsPWD ? (list.Where(a => a.AdvertiseId == AdvertiseId && a.Caste.ToLower() == "PWD".ToLower()).FirstOrDefault()) : null;
                obCaste = (list.Where(a => a.AdvertiseId == AdvertiseId && a.Caste.ToLower().Trim() == strCategory.ToLower().Trim()).FirstOrDefault());
                obInternal = IsInternal ? (list.Where(a => a.AdvertiseId == AdvertiseId && (a.Caste.ToLower() == "Internal".ToLower() || a.Caste.ToLower() == "Internal Candidate".ToLower())).FirstOrDefault()) : null;
                if (IsPWD && obPWD != null && obPWD.Amount < 1)
                {
                    return obPWD.Amount;
                }
                if (IsInternal && obInternal != null && obInternal.Amount < 1)
                {
                    return obInternal.Amount;
                }
                if (obCaste != null && obCaste.Amount < 1)
                {
                    return obCaste.Amount;
                }
                if (IsPWD && IsInternal && obInternal != null && obPWD != null && obCaste != null)
                {
                    if (obCaste.Amount <= obInternal.Amount && obCaste.Amount <= obInternal.Amount)
                    {
                        return obCaste.Amount;
                    }
                    else if (obInternal.Amount <= obCaste.Amount && obInternal.Amount <= obPWD.Amount)
                    {
                        return obInternal.Amount;
                    }
                    else
                    {
                        return obPWD.Amount;
                    }
                }
                else if (IsPWD && obPWD != null && obCaste != null)
                {
                    if (obPWD.Amount <= obCaste.Amount)
                    {
                        return obPWD.Amount;
                    }
                }
                else if (IsInternal && obInternal != null && obCaste != null)
                {
                    if (obInternal.Amount <= obCaste.Amount)
                    {
                        return obInternal.Amount;
                    }
                }
                else if (obCaste != null)
                {
                    return obCaste.Amount;
                }
            }
            return null;
        }

        public static tbl_transactions GetTransaction(int? fk_CandidateId, int? Pk_int_CandidateRegistrationID, int fk_advertisementid)
        {
            tbl_transactions obj;
            using (Vw_Applicationdetailscontext objAcknowledgement = new Vw_Applicationdetailscontext())
            {
                obj = objAcknowledgement.tbl_transactions.Where(a => a.fkintApplicantId == fk_CandidateId && a.fk_CandidateRegistrationID == Pk_int_CandidateRegistrationID && a.fk_advertisementid == fk_advertisementid).FirstOrDefault();
            }
            return obj;
        }



        public static int AgeRelaxation(string strCategory, bool IsPWD = false, bool IsExService = false, bool IsSportsperson = false)
        {
            strCategory = strCategory ?? "";
            int AgeRelax = 0;
            if (strCategory == "SC" || strCategory == "ST")
            {
                AgeRelax = 5;
            }
            else if (strCategory.ToLower().Contains("OBC".ToLower()))
            {
                AgeRelax = 3;
            }
            if (IsPWD)
            {
                AgeRelax += 10;
            }
            if (IsSportsperson)
            {
                AgeRelax = 5;
                if (strCategory == "SC" || strCategory == "ST")
                {
                    AgeRelax = 10;
                }
            }
            if (IsExService)
            {
                AgeRelax += 3;
            }
            if (AgeRelax > 15)
            {
                AgeRelax = 15;
            }
            return AgeRelax;
        }




        public static bool IsAgeCriteriaNotMatch(DateTime? DOB, DateTime? compareDate, string minAge, string maxAge, string strCategory,
        bool IsPWD = false, bool IsExService = false, bool IsSportsperson = false, bool IsInternal = false)
        {
            DateTime date2 = Convert.ToDateTime(compareDate);
            DateTime date1 = Convert.ToDateTime(DOB);

            var QCal = CommonBase.CalculateAge(date1, date2);
            int Years = QCal.Years;

            // Check minimum age
            if (QCal.Years < Convert.ToInt32(minAge))
            {
                return true; // Too young
            }

            // Check maximum age with relaxation
            int effectiveMaxAge = Convert.ToInt32(maxAge);

            int AgeRelaxationValue = CommonBase.AgeRelaxation(strCategory, IsPWD, IsExService, IsSportsperson);

            if (AgeRelaxationValue == -1)
            {
                return true; // Post not available
            }

            // Add relaxation to max age instead of subtracting from candidate's age
            effectiveMaxAge = effectiveMaxAge + AgeRelaxationValue;

            // Candidate exceeds effective max age
            if (Years > effectiveMaxAge || (Years == effectiveMaxAge && (QCal.Months > 0 || QCal.Days > 0)))
            {
                return true; // Age criteria not met
            }

            return false;
        }

        public static int AgeRelaxationNew(string strCategory, bool IsPWD = false, bool IsExService = false, bool IsSportsperson = false, bool IsInternal = false)
        {
            strCategory = strCategory ?? "";
            int AgeRelax = 0;
            if (strCategory == "SC" || strCategory == "ST")
            {
                AgeRelax = 5;
            }
            else if (strCategory.ToLower().Contains("OBC (Non-Creamy Layer)".ToLower()))
            {
                AgeRelax = 3;
            }
            if (IsPWD)
            {
                if ((strCategory == "SC" || strCategory == "ST"))
                {
                    AgeRelax = 15;
                }
                else if (strCategory.ToLower().Contains("OBC (Non-Creamy Layer)".ToLower()))
                {
                    AgeRelax = 13;
                }
                else
                {
                    AgeRelax = 10;
                }
            }
            if (IsSportsperson)
            {
                //AgeRelax = 5;
                if (strCategory == "SC" || strCategory == "ST")
                {
                    if (10 > AgeRelax)
                        AgeRelax = 10;
                }
                else
                {
                    AgeRelax = 5;
                }
                //else if (5 > AgeRelax)
                //{
                //    AgeRelax = 5;
                //}
            }
            if (IsExService)
            {
                //  AgeRelax += 3;
                return AgeRelax;
            }
            if (IsInternal)
            {
                return AgeRelax;
            }
            if (AgeRelax > 15)
            {
                AgeRelax = 15;
            }
            return AgeRelax;
        }
        public static dynamic CalculateAge(DateTime DOB, DateTime TillDate)
        {
            //int days = (TillDate - DOB).Days;
            //int Years = days / 365;

            //if (TillDate.DayOfYear < DOB.DayOfYear)
            //{
            //    Years = Years--;
            //}
            //int RemMonths = days % 365;
            //int Months = RemMonths / 30;
            //int RemDays = RemMonths % 30;



            int months = TillDate.Month - DOB.Month;
            int years = TillDate.Year - DOB.Year;

            if (TillDate.Day < DOB.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (TillDate - DOB.AddMonths((years * 12) + months)).Days;

            return new { Years = years, Months = months, Days = days };
        }
        public static bool CheckGateQualification(int CandidateId)
        {
            bool IsTrue = true;
            tbl_transaction_Postcriteriacontext objpostcriteria = new tbl_transaction_Postcriteriacontext();
            tbl_mst_CandidatePersonalDetailscontext objcanpersonaldetails = new tbl_mst_CandidatePersonalDetailscontext();
            var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == CandidateId).FirstOrDefault();

            var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();

            if (postCaitareaDetails.IsGATERequired)
            {
                using (tblRecruitmentCandidateGATEDetailsContext db = new tblRecruitmentCandidateGATEDetailsContext())
                {
                    var d_gate_list = db.tblRecruitmentCandidateGATEDetails.Where(a => a.CandidateId == CandidateId && a.PostId == CandidatePersonalDetails.fk_advertiseid).ToList();
                    if (d_gate_list.Where(a => string.IsNullOrEmpty(a.str_GATEResult) == false).FirstOrDefault() == null)
                    {
                        IsTrue = false;
                    }

                }
            }
            return IsTrue;
        }

        public static List<JObject> ConvertToJObjectList(DataTable dataTable)
        {
            var list = new List<JObject>();

            foreach (DataRow row in dataTable.Rows)
            {
                var item = new JObject();

                foreach (DataColumn column in dataTable.Columns)
                {
                    item.Add(column.ColumnName, JToken.FromObject(row[column.ColumnName]));
                }

                list.Add(item);
            }

            return list;
        }






        public static int AgeRelaxation12(string strCategory, bool IsPWD = false, bool IsExService = false, bool IsSportsperson = false)
        {
            strCategory = strCategory ?? "";
            int AgeRelax = 0;
            if (strCategory == "SC" || strCategory == "ST")
            {
                AgeRelax = 5;
            }
            else if (strCategory.ToLower().Contains("OBC".ToLower()))
            {
                AgeRelax = 3;
            }
            if (IsPWD)
            {
                AgeRelax += 10;
            }
            if (IsSportsperson)
            {
                AgeRelax = 5;
                if (strCategory == "SC" || strCategory == "ST")
                {
                    AgeRelax = 10;
                }
            }
            if (IsExService)
            {
                AgeRelax += 3;
            }
            if (AgeRelax > 15)
            {
                AgeRelax = 15;
            }
            return AgeRelax;
        }












        public static int AgeRelaxationchange(string strCategory, int disciplineId = 0, string strGrade = "", bool IsPWD = false, bool IsExService = false, bool IsSportsperson = false)
        {
            strCategory = (strCategory ?? "").Trim().ToUpper();
            strGrade = (strGrade ?? "").Trim().ToUpper();


            int AgeRelax = 0;


            var disciplineGradeMap = new Dictionary<string, List<string>>
    {
        // Mining (ID=1)
        { "1|E-2",  new List<string> { "SC", "OBC (NON-CREAMY LAYER)", "EWS", "GENERAL" } },
        { "1|E-4",  new List<string> { "ST", "OBC (NON-CREAMY LAYER)", "EWS", "GENERAL" } },

        // Geology (ID=2)
        { "2|E-2",  new List<string> { "GENERAL" } },
        { "2|E-3",  new List<string> { "OBC (NON-CREAMY LAYER)", "GENERAL" } },

        // Environment Management (ID=14)
        { "14|E-2",  new List<string> { "OBC (NON-CREAMY LAYER)", "GENERAL" } },

        // Safety and Fire Services (ID=13)
        { "13|E-2",  new List<string> { "SC", "OBC (NON-CREAMY LAYER)", "EWS", "GENERAL" } },

        // Concentrator (ID=4)
        { "4|E-2",  new List<string> { "OBC (NON-CREAMY LAYER)", "GENERAL" } },

        //  Electrical (ID=28)
        { "28|E-2",  new List<string> {"SC", "OBC (NON-CREAMY LAYER)", "GENERAL" } },
        { "28|E-3", new List<string>    {"SC", "OBC (NON-CREAMY LAYER)", "EWS", "GENERAL" } },

        // Instrumentation (ID=30)
        { "30|E-3",  new List<string> { "OBC (NON-CREAMY LAYER)", "GENERAL" } },

        // Mechanical (ID=9)
        { "9|E-2",  new List<string> { "SC", "OBC (NON-CREAMY LAYER)", "GENERAL" } },
        {"9|E-3", new List<string> { "GENERAL" } },
        { "9|E-4",  new List<string> { "OBC (NON-CREAMY LAYER)",  "GENERAL" } },

        // Civil (ID=10)
        { "10|E-2",  new List<string> { "OBC (NON-CREAMY LAYER)", "GENERAL" } },
        //{ "9|E3",  new List<string> { "UR" } },
        //{ "9|E4",  new List<string> { "OBC", "UR" } },

        // Systems (ID=11)
        { "31|E-2", new List<string> { "GENERAL" } },


        // Medical & Health Services — add your ID
        { "42|E-3", new List<string> { "SC", "GENERAL" } },
        { "42|E-4", new List<string> { "GENERAL" } },

        // HR — add your ID
        { "15|E-4", new List<string> { "SC", "OBC (NON-CREAMY LAYER)", "EWS", "GENERAL" } },

        // Finance — add your ID
        { "18|E-2", new List<string> { "OBC (NON-CREAMY LAYER)", "EWS", "GENERAL" } },
        { "18|E-3", new List<string> { "OBC (NON-CREAMY LAYER)" } },
        { "18|E-4", new List<string> { "OBC (NON-CREAMY LAYER)", "GENERAL" } },

        // Corporate Communication — add your ID
        { "43|E-2", new List<string> { "GENERAL" } },

        // Materials & Contracts — add your ID
        { "37|E-2", new List<string> { "ST", "GENERAL" } },
        { "37|E-4", new List<string> { "OBC (NON-CREAMY LAYER)", "GENERAL" } },
    };

            string lookupKey = $"{disciplineId}|{strGrade}";

            if (disciplineGradeMap.TryGetValue(lookupKey, out List<string> allowedCategories))
            {

                bool isCategoryAllowed = allowedCategories.Contains(strCategory);


                System.Diagnostics.Debug.WriteLine("Category = [" + strCategory + "]");

                foreach (var item in allowedCategories)
                {
                    System.Diagnostics.Debug.WriteLine("Allowed = [" + item + "]");
                }

                if (isCategoryAllowed)
                {
                    if (strCategory == "SC" || strCategory == "ST" || strCategory == "BL")
                        AgeRelax = 5;
                    else if (strCategory.Contains("OBC"))
                        AgeRelax = 3;
                    else if (strCategory == "EWS" || strCategory == "General")
                        AgeRelax = 0;
                }
                else
                {
                    return -1; // Post not available for this category
                }
            }
            else
            {
                // Fallback original logic
                if (strCategory == "SC" || strCategory == "ST")
                    AgeRelax = 5;
                else if (strCategory.Contains("OBC"))
                    AgeRelax = 3;
            }

            if (IsPWD) AgeRelax += 10;
            if (IsSportsperson)
            {
                AgeRelax = 5;
                if (strCategory == "SC" || strCategory == "ST") AgeRelax = 10;
            }
            if (IsExService) AgeRelax += 3;
            if (AgeRelax > 15) AgeRelax = 15;

            return AgeRelax;
        }




        public static bool IsAgeCriteriaNotMatchchange(DateTime? DOB, DateTime? compareDate, string minAge, string maxAge, string strCategory,
                bool IsPWD = false, bool IsExService = false, bool IsSportsperson = false, bool IsInternal = false)
        {
            DateTime date2 = Convert.ToDateTime(compareDate);
            DateTime date1 = Convert.ToDateTime(DOB);

            TimeSpan diff = date2 - date1;
            int Years = (diff.Days / 366);

            DateTime workingDate = date1.AddYears(Years);
            while (workingDate.AddYears(1) <= date2)
            {
                workingDate = workingDate.AddYears(1);
                Years++;
            }
            //---------------------------------------------
            //months
            diff = date2 - workingDate;
            int Months = diff.Days / 31;
            workingDate = workingDate.AddMonths(Months);
            while (workingDate.AddMonths(1) <= date2)
            {
                workingDate = workingDate.AddMonths(1);
                Months++;
            }
            //---------------------------------------------
            //weeks and days
            diff = date2 - workingDate;
            int Days = diff.Days;

            int monthDay = Months * 30 + Days;

            var QCal = CommonBase.CalculateAge(date1, date2);
            Years = QCal.Years;

            if (Years > Convert.ToInt32(maxAge) || (Years == Convert.ToInt32(maxAge) && (QCal.Months > 0 || QCal.Days > 0)))
            {
                int AgeRelaxationValue = CommonBase.AgeRelaxation(
                                     strCategory,
                                     IsPWD,
                                     IsExService,
                                     IsSportsperson);




                if (AgeRelaxationValue == -1)
                {
                    return true; // Age criteria not met — post not available
                }




                //int AgeRelaxationValue = CommonBase.AgeRelaxationNew(strCategory, IsPWD, IsExService, IsSportsperson);
                if (AgeRelaxationValue > 0)
                {
                    Years = Years - AgeRelaxationValue;
                    if (Years > Convert.ToInt32(maxAge) || (Years == (Convert.ToInt32(maxAge)) && (QCal.Months > 0 || QCal.Days > 0)))
                    {
                        Years = Years - AgeRelaxationValue;
                    }
                }
            }





            // comment condition for age relaxation
            //if (((QCal.Years < Convert.ToInt32(minAge) || (Years > Convert.ToInt32(maxAge)) || ((Years == (Convert.ToInt32(maxAge)) && (QCal.Months > 0 || QCal.Days > 0)))) && !IsExService))
            //{
            //    return true;
            //}
            if (((QCal.Years < Convert.ToInt32(minAge) || (Years > Convert.ToInt32(maxAge)) || ((Years == (Convert.ToInt32(maxAge)) && (QCal.Months > 0 || QCal.Days > 0))))))
            {
                return true;
            }
            return false;
        }


    }
}