
function getAge(birthDate, ageAtDate) {
    var daysInMonth = 30.436875; // Days in a month on average.
    var dob = birthDate;
    var aad;
    if (ageAtDate == undefined || ageAtDate == null) aad = new Date();
    else aad = ageAtDate;
    var yearAad = aad.getFullYear();
    var yearDob = dob.getFullYear();
    var years = yearAad - yearDob; // Get age in years.
    dob.setFullYear(yearAad); // Set birthday for this year.
    var aadMillis = aad.getTime();
    var dobMillis = dob.getTime();
    if (aadMillis < dobMillis) {
        //--years;
        dob.setFullYear(yearAad - 1); // Set to previous year's birthday
        dobMillis = dob.getTime();
    }

    var days = (aadMillis - dobMillis) / 86400000;
    var monthsDec = days / daysInMonth; // Months with remainder.
    var months = Math.floor(monthsDec); // Remove fraction from month.
    days = Math.floor(daysInMonth * (monthsDec - months));
    if (months > 0 || days > 0) {
        years = years - 1;
    }
    return { years: years, months: months, days: days };
}
function CalulateAge() {
    if ($('#dtDOB').val() != '') {
        var tdt = new Date(new Date().getFullYear() + '-09-01');
        //var today = new Date(tdt);
        var dob = new Date($('#dtDOB').val().split('-').reverse().join('-'));

        var q = getAge(dob, tdt);
        var strDate = !isNaN(q.years) ? ' ' + q.years + ' years' : '';
        strDate += !isNaN(q.months) ? ' ' + q.months + ' months' : '';
        strDate += !isNaN(q.days) ? ' ' + q.days + ' days' : '';
        $('#bAgeCal').text(strDate + ' old');
    }
    else {
        $('#bAgeCal').text('');
    }
}

//$("#dt_certificateissuedate").change(function () {
//    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#dt_certificateissuedate").val() != "") {
//        date1 = $("#dt_certificateissuedate").val();
//        date2 = "01-04-2022";
//        var d1 = new Date(date1.split("-").reverse().join("/"));
//        var dd1 = d1.getDate();
//        var mm1 = d1.getMonth() + 1;
//        var yy1 = d1.getFullYear();
//        var newdate1 = yy1 + "/" + mm1 + "/" + dd1;
//        var d2 = new Date(date2.split("-").reverse().join("/"));
//        var dd2 = d2.getDate();
//        var mm2 = d2.getMonth() + 1;
//        var yy2 = d2.getFullYear();
//        var newdate2 = yy2 + "/" + mm2 + "/" + dd2;
//        console.log(newdate1, newdate2);
      
//        if (new Date(newdate1) <= new Date(newdate2)) {

//            alert("Date should be greater than or equal to 1/04/2022")
//            $("#dt_certificateissuedate").val("");
//        }
      

//    }
//});
$('#dtDOB').on('change', function () {
    CalulateAge()
});

$("#other").hide();
$("#strAadharNo").ForceNumericOnly();
$("#fk_postid").change(function () {
    var PostID = $("#fk_postid").val();
    var AddID = $("#fk_advertiseid").val();

    if (PostID == "") {
        alert("Please Select Post.");
    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Recruitment/FillQualification',
            data: { 'postId': PostID, 'addId': AddID },
            success: function (result) {
              
                $('#strGender').empty();
                $('#strCategory').empty();

                if (result.GenderAll.length > 0) {
                    $('#strGender').append($('<option/>').attr('value', " ").text("Select"));
                    $.each(result.GenderAll, function (e, text) {
                        if (text != '') {
                            $('#strGender').append($('<option/>').attr('value', text).text(text));
                        }
                    });
                }
                if (result.castAll.length > 0) {
                    $('#strCategory').append($('<option/>').attr('value', " ").text("Select"));
                    $.each(result.castAll, function (e, text) {
                        if (text != '') {
                            $('#strCategory').append($('<option/>').attr('value', text).text(text));
                        }
                    });
                }
            


            }
        });
    }
});


$("#strEmployedIn").change(function () {
    $("#other").val('');
    if (this.value == "Other(Govt.)") {
        $("#other").show();
    }
    else {
        $("#other").hide();
        if (this.value == "Private" || this.value == "Not Applicable") {
            if (!$('#select-box').find("option:contains('Not Applicable')").length) {
                $("#strapplyproper option[value='Not Applicable']").remove();
            }
            $('#strapplyproper').append(new Option('Not Applicable', 'Not Applicable'));
            $("#strapplyproper").val('Not Applicable');

        }
        else {

            $("#strapplyproper option[value='Not Applicable']").remove();

        }

    }
});


function stringToDate(_date, _format, _delimiter) {
    if (_date != null && _date != 'undefiend') {

        var from = _date.split("-")
        return new Date(from[2], from[1] - 1, from[0])
    }
}


function DateDiff(date1, date2) {
    var DMY = date1.split('/'); //splits the date string by '/' and stores in a array.
    var DMY1 = date2.split('/');

    var day = DMY[0];
    var month = DMY[1];
    var year = DMY[2];

    var day1 = DMY1[0];
    var month1 = DMY1[1];
    var year1 = DMY1[2];

    var dateTemp1 = new Date(year, (parseInt(month) - 1), day);
    var dateTemp2 = new Date(year1, (parseInt(month1) - 1), day1);
    var Days = Math.ceil(((dateTemp2.getTime() - dateTemp1.getTime()) / (1000 * 60 * 60 * 24)));
    return Days + 1;

}


//     $("#strgrade").change(function () {
//         var gradevalu = $("#strgrade").val();
//         $.ajax({

//             type: 'POST',
//             dataType: 'json',
//             url: '/Recruitment/PostbyDesignation',
//             data: { 'grade': gradevalu },

//             success: function (result) {

//                 $("#strpresentdesignation").val(result.Designation);


//             },
//             error: function () {

//                 alert('Error');
//             }

//         });


//     });














//Post by discipline


$("#fk_dicipline").change(function () {
    var dicpline = $("#fk_dicipline").val();
  
    if (dicpline == "") {
        alert("Please select discipline");
        $('#fk_postid').empty().append($('<option/>').attr('value', "").text("--- Select ---")).trigger('change');
        $('#strEssentialQualification').empty().append($('<option/>').attr('value', "").text("--- Select ---"));
    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/RecruitmentCareer/Postbydiscipline',
            data: { 'fk_dicipline': dicpline, 'fk_advertiseid': location.pathname.split('/')[location.pathname.split('/').length - 1] },
            success: function (result) {
                $('#fk_postid').empty();
                $('#strEssentialQualification').empty();

                if (result.PostMaster.length > 0) {
                    $('#fk_postid').append($('<option/>').attr('value', "").text("--- Select ---"));
                    $.each(result.PostMaster, function (result) {
                        $('#fk_postid').append($('<option/>').attr('value', this.fk_postid).text(this.Postname));
                    });
                }
                if (result.EssebtialQualification.length > 0) {
                    $('#strEssentialQualification').append($('<option/>').attr('value', "").text("--- Select ---"));
                    $.each(result.EssebtialQualification, function (result) {
                        $('#strEssentialQualification').append($('<option/>').attr('value', this.Value).text(this.Text));
                    });
                }
            },
            error: function () {

                alert('Error');
            }
        });
    }
});


$("#fk_postid").change(function () {
    var fk_postid = $("#fk_postid").val();

    if (fk_postid == "") {
        alert("Please select post");
        $('#strEssentialQualification').empty().append($('<option/>').attr('value', "").text("--- Select ---"));
    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/RecruitmentCareer/QualificationByPost',
            data: { 'fk_postid': fk_postid, 'fk_advertiseid': location.pathname.split('/')[location.pathname.split('/').length - 1] },
            success: function (result) {
                $('#strEssentialQualification').empty();

                if (result.EssebtialQualification.length > 0) {
                    $('#strEssentialQualification').append($('<option/>').attr('value', "").text("--- Select ---"));
                    $.each(result.EssebtialQualification, function (result) {
                        $('#strEssentialQualification').append($('<option/>').attr('value', this.Value).text(this.Text));
                    });
                }
            },
            error: function () {

                alert('Error');
            }
        });
       
            $("#cer").hide();
            var value = $.trim($("#fk_postid option:selected").text()).toLowerCase();
            var jj = '';
         var arr = ['Valid First Aid Certificate'];
        console.log($.trim($("#fk_postid option:selected").text()).toLowerCase());

                if (value == 'mining mate') {
                    //var arr = ['Valid Mate Certificate of Competency for Metalliferous Mine(Unrestricted)'];
                    var arr = ['Valid Mining Mate Certificate of Competency for metalliferous mines (unrestricted)'];

                    arr.push('Valid First Aid Certificate');
                    $("#tbodyCertificate").empty();
                }


                else if (value == 'blaster') {
                    var arr = ['Valid Blaster Certificate of Competency for Metalliferous Mine (Unrestricted)'];
                    arr.push('Valid First Aid Certificate');
                    $("#tbodyCertificate").empty();
                }
                else if (value == 'assistant  foreman') {
                    var arr = ['Valid Mines Foreman Certificate of Competency for metalliferous mines (unrestricted)'];
                    arr.push('Valid First Aid Certificate');
                    $("#tbodyCertificate").empty();
                }
                else if (value == "wed'b'" || value == "wed 'b'" || value == "wed ‘ b’") {
                    var arr = ['Valid 1st Class Winding Engine Driver’s Certificate'];
                    $("#tbodyCertificate").empty();
                }
                else if (value == "wed'c'" || value == "wed 'c'" || value =="wed ‘c’") {
                    var arr = ['Valid 2nd Class Winding Engine Driver’s Certificate'];
                    $("#tbodyCertificate").empty();
                }

                for (var i = 0; i< arr.length; i++) {
                    jj += '<tr>';
                    jj += '    <td> <input value="' + arr[i] + '" readonly class="form-control" id="CertificateName' + i + '" name="CertificateName' + i + '"  type="text" autocomplete="off" required> </td>';
                    jj += '    <td> <input class="form-control" id="CertificateNo' + i + '" name="CertificateNo' + i + '" type="text" value="" autocomplete="off" required > </td>';
                    jj += '    <td> <input class="form-control input-append date"  id="CertificateIssueDate' + i + '" name="CertificateIssueDate' + i + '" placeholder="dd-mm-yyyy" type="text" value="" autocomplete="off" required > </td>';
                    jj += '    <td> <input class="form-control input-append date" id="CertificateExpiryDate' + i + '" name="CertificateExpiryDate' + i + '" placeholder="dd-mm-yyyy" type="text" value="" autocomplete="off" required > </td>';
                    jj += '    <td> <input class="form-control" id="IssuingAuthority' + i + '" name="IssuingAuthority' + i + '" type="text" value="" required > </td>';
                    jj += '</tr>';
                }
                $("#cer").show();
                $("#tbodyCertificate").append(jj);
        $('.date').datepicker({
            format: 'dd-mm-yyyy'
        }).datepicker().on('changeDate', function (ev) {
            $(this).next("span").remove();

        });
            
        
    }
});















var hidValue = $('#errorCount').val();
var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

//keyup Personal information
$("#fk_dicipline").change(function () {
    var fk_dicipline = $("#fk_dicipline").val();
    $("#fk_dicipline").next("span").remove();
    if (fk_dicipline == "") {
        $("#fk_dicipline").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_dicipline").next("span").remove();

    }
});

$("#fk_postid").change(function () {
    var fk_postid = $("#fk_postid").val();
    $("#fk_postid").next("span").remove();
    if (fk_postid == "") {
        $("#fk_postid").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_postid").next("span").remove();
    }
});


$("#strApplicantName").keyup(function () {
    var strApplicantName = $("#strApplicantName").val();
    $("#strApplicantName").next("span").remove();
    if (strApplicantName == "") {
        $("#strApplicantName").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strApplicantName").next("span").remove();
    }
});


$("#strDomicilestate").change(function () {
    var strDomicilestate = $("#strDomicilestate").val();
    $("#strDomicilestate").next("span").remove();
    if (strDomicilestate == "") {
        $("#strDomicilestate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strDomicilestate").next("span").remove();
    }
});


$("#dtDOB").keyup(function () {
    var dtDOB = $("#dtDOB").val();
    $("#dtDOB").next("span").remove();
    if (dtDOB == "") {
        $("#dtDOB").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dtDOB").next("span").remove();
    }
});
$("#strEmail").keyup(function () {
    var strEmail = $("#strEmail").val();
    $("#strEmail").next("span").remove();
    if (strEmail == "") {
        $("#strEmail").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strEmail").next("span").remove();
    }
});

$("#strEmail").keyup(function () {
    if (!emailReg.test($("#strEmail").val())) {
        $("#strEmail").next("span").remove();
        $("#strEmail").after("<span style='color:Red'>Please Enter a Valid Email Address</span>");
        noerror = 0;
    }
});


$("#strNationality").keyup(function () {
    var strNationality = $("#strNationality").val();
    $("#strNationality").next("span").remove();
    if (strNationality == "") {
        $("#strNationality").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strNationality").next("span").remove();
    }
});


$("#strGender").change(function () {
    var strGender = $("#strGender").val();
    $("#strGender").next("span").remove();
    if (strGender == "") {
        $("#strGender").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strGender").next("span").remove();
    }
});


$("#strsubcaste").keyup(function () {
    var strsubcaste = $("#strsubcaste").val();
    $("#strsubcaste").next("span").remove();
    if (strsubcaste == "") {
        $("#strsubcaste").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strsubcaste").next("span").remove();
    }
});




$("#strcertificateno").keyup(function () {
    var strcertificateno = $("#strcertificateno").val();
    $("#strcertificateno").next("span").remove();
    if (strcertificateno == "") {
        $("#strcertificateno").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strcertificateno").next("span").remove();
    }
});

$("#dt_certificateissuedate").keyup(function () {
    var dt_certificateissuedate = $("#dt_certificateissuedate").val();
    $("#dt_certificateissuedate").next("span").remove();
    if (dt_certificateissuedate == "") {
        $("#dt_certificateissuedate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dt_certificateissuedate").next("span").remove();
    }
});
$("#strcertificateissue").keyup(function () {
    var strcertificateissue = $("#strcertificateissue").val();
    $("#strcertificateissue").next("span").remove();
    if (strcertificateissue == "") {
        $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strcertificateissue").next("span").remove();
    }
});
$("#strMaritalStatus").change(function () {
    var strMaritalStatus = $("#strMaritalStatus").val();
    $("#strMaritalStatus").next("span").remove();
    if (strMaritalStatus == "") {
        $("#strMaritalStatus").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strMaritalStatus").next("span").remove();
    }
});

$("#strExserviceMan").change(function () {

    var strExserviceMan = $("#strExserviceMan").val();
    $("#strExserviceMan").next("span").remove();
    if (strExserviceMan == "") {
        $("#strExserviceMan").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strExserviceMan").next("span").remove();
    }
});

$("#strexservicemanno").keyup(function () {
    var strexservicemanno = $("#strexservicemanno").val();
    $("#strexservicemanno").next("span").remove();
    if (strexservicemanno == "") {
        $("#strexservicemanno").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strexservicemanno").next("span").remove();
    }
});
$("#fk_domicilestateid").change(function () {
    var fk_domicilestateid = $("#fk_domicilestateid").val();
    $("#fk_domicilestateid").next("span").remove();
    if (fk_domicilestateid == "") {
        $("#fk_domicilestateid").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_domicilestateid").next("span").remove();
    }
});



$("#stremployeecode").keyup(function () {

    var stremployeecode = $("#stremployeecode").val();
    $("#stremployeecode").next("span").remove();
    if (stremployeecode == "") {
        $("#stremployeecode").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#stremployeecode").next("span").remove();
    }
});

$("#strgrade").keyup(function () {

    var strgrade = $("#strgrade").val();
    $("#strgrade").next("span").remove();
    if (strgrade == "") {
        $("#strgrade").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strgrade").next("span").remove();
    }
});
$("#strplaceposting").keyup(function () {

    var strplaceposting = $("#strplaceposting").val();
    $("#strplaceposting").next("span").remove();
    if (strplaceposting == "") {
        $("#strplaceposting").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strplaceposting").next("span").remove();
    }
});
$("#strpresentdesignation").keyup(function () {

    var strpresentdesignation = $("#strpresentdesignation").val();
    $("#strpresentdesignation").next("span").remove();
    if (strpresentdesignation == "") {
        $("#strpresentdesignation").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strpresentdesignation").next("span").remove();
    }
});

$("#dt_presententrydate").keyup(function () {

    var dt_presententrydate = $("#dt_presententrydate").val();
    $("#dt_presententrydate").next("span").remove();
    if (dt_presententrydate == "") {
        $("#dt_presententrydate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dt_presententrydate").next("span").remove();
    }
});



//keyupCorrespondenceAddress
$("#strCorrespondenceAddress").keyup(function () {

    var strCorrespondenceAddress = $("#strCorrespondenceAddress").val();
    $("#strCorrespondenceAddress").next("span").remove();
    if (strCorrespondenceAddress == "") {
        $("#strCorrespondenceAddress").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strCorrespondenceAddress").next("span").remove();
    }
});

$("#strState").keyup(function () {

    var strState = $("#strState").val();
    $("#strState").next("span").remove();
    if (strState == "") {
        $("#strState").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strState").next("span").remove();
    }
});
$("#strDistrict").keyup(function () {

    var strDistrict = $("#strDistrict").val();
    $("#strDistrict").next("span").remove();
    if (strDistrict == "") {
        $("#strDistrict").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strDistrict").next("span").remove();
    }
});
$("#strTelephone").keyup(function () {
    var strTelephone = $("#strTelephone").val();
    $("#strTelephone").next("span").remove();
    if (strTelephone.toString().length < 11 && strTelephone != "") {
        $("#strTelephone").after("<span style='color:Red'>Phone no. must be 11 digit</span>");
    }
    else {
        $("#strTelephone").next("span").remove();
    }
});
$("#strMobileNo").keyup(function () {
    var strMobileNo = $("#strMobileNo").val();
    $("#strMobileNo").next("span").remove();
    if (strMobileNo.toString().length < 10 && strMobileNo != "") {
        $("#strMobileNo").after("<span style='color:Red'>Mobile no. must be 10 digit</span>");
    }
    else {
        $("#strMobileNo").next("span").remove();
    }
});

$("#strPin").keyup(function () {

    var strPin = $("#strPin").val();
    $("#strPin").next("span").remove();
    if (strPin == "") {
        $("#strPin").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPin").next("span").remove();
    }
});

$("#strPin").keyup(function () {
    var strPin = $("#strPin").val();
    $("#strPin").next("span").remove();
    if (strPin.toString().length < 6 && strPin != "") {
        $("#strPin").after("<span style='color:Red'>Pin must be 6 digit</span>");
    }
    else {
        $("#strPin").next("span").remove();
    }
});
//permanentaddress
$("#strPermanentAddress").keyup(function () {

    var strPermanentAddress = $("#strPermanentAddress").val();
    $("#strPermanentAddress").next("span").remove();
    if (strPermanentAddress == "") {
        $("#strPermanentAddress").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPermanentAddress").next("span").remove();
    }
});

$("#strPermanentState").keyup(function () {

    var strPermanentState = $("#strPermanentState").val();
    $("#strPermanentState").next("span").remove();
    if (strPermanentState == "") {
        $("#strPermanentState").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPermanentState").next("span").remove();
    }
});

$("#strPermanentDistrict").keyup(function () {

    var strPermanentDistrict = $("#strPermanentDistrict").val();
    $("#strPermanentDistrict").next("span").remove();
    if (strPermanentDistrict == "") {
        $("#strPermanentDistrict").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPermanentDistrict").next("span").remove();
    }
});
$("#strPermanentTelephoneNo").keyup(function () {
    var strPermanentTelephoneNo = $("#strPermanentTelephoneNo").val();
    $("#strPermanentTelephoneNo").next("span").remove();
    if (strPermanentTelephoneNo.toString().length < 11 && strPermanentTelephoneNo != "") {
        $("#strPermanentTelephoneNo").after("<span style='color:Red'>Phone no. must be 11 digit</span>");
    }
    else {
        $("#strPermanentTelephoneNo").next("span").remove();
    }
});
$("#strPermanentMobile1").keyup(function () {
    var strPermanentMobile1 = $("#strPermanentMobile1").val();
    $("#strPermanentMobile1").next("span").remove();
    if (strPermanentMobile1.toString().length < 10 && strPermanentMobile1 != "") {
        $("#strPermanentMobile1").after("<span style='color:Red'>Mobile no. must be 10 digit</span>");
    }
    else {
        $("#strPermanentMobile1").next("span").remove();
    }
});

$("#strPermanentPinCode").keyup(function () {

    var strPermanentPinCode = $("#strPermanentPinCode").val();
    $("#strPermanentPinCode").next("span").remove();
    if (strPermanentPinCode == "") {
        $("#strPermanentPinCode").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPermanentPinCode").next("span").remove();
    }
});
$("#strPermanentPinCode").keyup(function () {
    var strPermanentPinCode = $("#strPermanentPinCode").val();
    $("#strPermanentPinCode").next("span").remove();
    if (strPermanentPinCode.toString().length < 6 && strPermanentPinCode != "") {
        $("#strPermanentPinCode").after("<span style='color:Red'>Pin must be 6 digit</span>");
    }
    else {
        $("#strPermanentPinCode").next("span").remove();
    }
});




//Numeric
$("#strPermanentPinCode").ForceNumericOnly();
$("#strPermanentMobile1").ForceNumericOnly();
$("#strPermanentTelephoneNo").ForceNumericOnly();
$("#strPin").ForceNumericOnly();
$("#strMobileNo").ForceNumericOnly();
$("#strTelephone").ForceNumericOnly();
//limit
$("#strApplicantName").on("input", function () {
    LimtCharacters(this, 100);
});

$("#strFatherName").on("input", function () {
    LimtCharacters(this, 40);
});
$("#strEmail").on("input", function () {
    LimtCharacters(this, 80);
});

$("#strNationality").on("input", function () {
    LimtCharacters(this, 15);
});
$("#strsubcaste").on("input", function () {
    LimtCharacters(this, 60);
});
$("#strcertificateno").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strcertificateissue").on("input", function () {
    LimtCharacters(this, 100);
});

$("#strexservicemanno").on("input", function () {
    LimtCharacters(this, 30);
});

$("#strcertificateno1").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strcertificateissue1").on("input", function () {
    LimtCharacters(this, 100);
});
$("#stremployeecode").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strgrade").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strplaceposting").on("input", function () {
    LimtCharacters(this, 50);
});
$("#strpresentdesignation").on("input", function () {
    LimtCharacters(this, 100);
});
//correspondence
$("#strCorrespondenceAddress").on("input", function () {
    LimtCharacters(this, 150);
});
//$("#strState").on("input", function () {
//    LimtCharacters(this, 20);
//});
$("#strDistrict").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strNearestPostOffice").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strNearestPoliceStation").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strNearestRailwaystation").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strPin").on("input", function () {
    LimtCharacters(this, 6);
});
$("#strTelephone").on("input", function () {
    LimtCharacters(this, 11);
});
$("#strMobileNo").on("input", function () {
    LimtCharacters(this, 10);
});
//permanent
$("#strPermanentAddress").on("input", function () {
    LimtCharacters(this, 150);
});
//$("#strPermanentState").on("input", function () {
//    LimtCharacters(this, 20);
//});
$("#strPermanentDistrict").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strPermanentNearestPostOffice").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strPermanentNearestPoliceStation").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strPermanentNearestRailwayStation").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strPermanentPinCode").on("input", function () {
    LimtCharacters(this, 6);
});
$("#strPermanentTelephoneNo").on("input", function () {
    LimtCharacters(this, 11);
});
$("#strPermanentMobile1").on("input", function () {
    LimtCharacters(this, 10);
});

$("#strAadharNo").on("input", function () {
    LimtCharacters(this, 12);
});
$("#strPANNo").on("input", function () {
    LimtCharacters(this, 10);
});



function LimtCharacters(txtMsg, CharLength) {
    $(txtMsg).next("span").remove();
    chars = txtMsg.value.length;
    if (chars > CharLength && chars > 0) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $(txtMsg).after("<span style='color:Red'> Max Length reached..</span>");
    }
}



//ERROR
function error() {
    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var strTelephone = $("#strTelephone").val();
    var email = $("#strEmail").val();
    var strMobileNo = $("#strMobileNo").val();
    var strPermanentTelephoneNo = $("#strPermanentTelephoneNo").val();
    var strPermanentMobile1 = $("#strPermanentMobile1").val();
    var strPin = $("#strPin").val();
    var strPermanentPinCode = $("#strPermanentPinCode").val();


    if ($("#fk_dicipline").val() == "") {
        $("#fk_dicipline").next("span").remove();
        $("#fk_dicipline").after("<span style='color:Red'> This field is required</span>");
        $("#fk_dicipline").focus();
        noerror = 0;
    }

    if ($("#fk_postid").val() == "") {
        $("#fk_postid").next("span").remove();
        $("#fk_postid").after("<span style='color:Red'> This field is required</span>");
        $("#fk_postid").focus();
        noerror = 0;
    }

    if ($("#strEssentialQualification").val() == "") {
        $("#strEssentialQualification").next("span").remove();
        $("#strEssentialQualification").after("<span style='color:Red'> This field is required</span>");
        $("#strEssentialQualification").focus();
        noerror = 0;
    }


    if ($("#strApplicantName").val() == "") {
        $("#strApplicantName").next("span").remove();
        $("#strApplicantName").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#dtDOB").val() == "") {
        $("#dtDOB").next("span").remove();
        $("#dtDOB").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strEmail").val() == "") {
        $("#strEmail").next("span").remove();
        $("#strEmail").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strNationality").val() == "") {
        $("#strNationality").next("span").remove();
        $("#strNationality").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strGender").val() == "" || $("#strGender")[0].selectedIndex==0) {
        $("#strGender").next("span").remove();
        $("#strGender").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strCategory").val() == "" || $("#strCategory")[0].selectedIndex == 0) {
        $("#strCategory").next("span").remove();
        $("#strCategory").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#strsubcaste").val() == "") {
        $("#strsubcaste").next("span").remove();
        $("#strsubcaste").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "SC" && $("#strsubcaste").val() == "") {
        $("#strsubcaste").next("span").remove();
        $("#strsubcaste").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "ST" && $("#strsubcaste").val() == "") {
        $("#strsubcaste").next("span").remove();
        $("#strsubcaste").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#strcertificateno").val() == "") {
        $("#strcertificateno").next("span").remove();
        $("#strcertificateno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "SC" && $("#strcertificateno").val() == "") {
        $("#strcertificateno").next("span").remove();
        $("#strcertificateno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "ST" && $("#strcertificateno").val() == "") {
        $("#strcertificateno").next("span").remove();
        $("#strcertificateno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#dt_certificateissuedate").val() == "") {
        $("#dt_certificateissuedate").next("span").remove();
        $("#dt_certificateissuedate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "SC" && $("#dt_certificateissuedate").val() == "") {
        $("#dt_certificateissuedate").next("span").remove();
        $("#dt_certificateissuedate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "ST" && $("#dt_certificateissuedate").val() == "") {
        $("#dt_certificateissuedate").next("span").remove();
        $("#dt_certificateissuedate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#strcertificateissue").val() == "") {
        $("#strcertificateissue").next("span").remove();
        $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "SC" && $("#strcertificateissue").val() == "") {
        $("#strcertificateissue").next("span").remove();
        $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "ST" && $("#strcertificateissue").val() == "") {
        $("#strcertificateissue").next("span").remove();
        $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strMaritalStatus").val() == "") {
        $("#strMaritalStatus").next("span").remove();
        $("#strMaritalStatus").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strExserviceMan").val() == "") {
        $("#strExserviceMan").next("span").remove();
        $("#strExserviceMan").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }



    if ($("#strDomicilestate").val() == "") {
        $("#strDomicilestate").next("span").remove();
        $("#strDomicilestate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }



    if ($("#strExserviceMan").val() == "Yes" && $("#strexservicemanno").val() == "") {
        $("#strexservicemanno").next("span").remove();
        $("#strexservicemanno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

 
    if ($("#strInternalCandidate").val() == "") {
        $("#strInternalCandidate").next("span").remove();
        $("#strInternalCandidate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strapplyproper").val() == "") {
        $("#strapplyproper").next("span").remove();
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strInternalCandidate").val() == "Yes" && $("#stremployeecode").val() == "") {
        $("#stremployeecode").next("span").remove();
        $("#stremployeecode").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strInternalCandidate").val() == "Yes" && $("#strgrade").val() == "") {
        $("#strgrade").next("span").remove();
        $("#strgrade").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strInternalCandidate").val() == "Yes" && $("#strplaceposting").val() == "") {
        $("#strplaceposting").next("span").remove();
        $("#strplaceposting").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strInternalCandidate").val() == "Yes" && $("#strpresentdesignation").val() == "") {
        $("#strpresentdesignation").next("span").remove();
        $("#strpresentdesignation").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strInternalCandidate").val() == "Yes" && $("#dt_presententrydate").val() == "") {
        $("#dt_presententrydate").next("span").remove();
        $("#dt_presententrydate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strEmployedIn").val() == "") {
        $("#strEmployedIn").next("span").remove();
        $("#strEmployedIn").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strEmployedIn").val() == "Govt" && $("#strapplyproper").val() == "") {
        $("#strapplyproper").next("span").remove();
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strEmployedIn").val() == "Semi-Govt" && $("#strapplyproper").val() == "") {
        $("#strapplyproper").next("span").remove();
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strEmployedIn").val() == "PSU" && $("#strapplyproper").val() == "") {
        $("#strapplyproper").next("span").remove();
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strCorrespondenceAddress").val() == "") {
        $("#strCorrespondenceAddress").next("span").remove();
        $("#strCorrespondenceAddress").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strState").val() == "") {
        $("#strState").next("span").remove();
        $("#strState").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strDistrict").val() == "") {
        $("#strDistrict").next("span").remove();
        $("#strDistrict").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPin").val() == "") {
        $("#strPin").next("span").remove();
        $("#strPin").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPermanentAddress").val() == "") {
        $("#strPermanentAddress").next("span").remove();
        $("#strPermanentAddress").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPermanentState").val() == "") {
        $("#strPermanentState").next("span").remove();
        $("#strPermanentState").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPermanentDistrict").val() == "") {
        $("#strPermanentDistrict").next("span").remove();
        $("#strPermanentDistrict").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPermanentPinCode").val() == "") {
        $("#strPermanentPinCode").next("span").remove();
        $("#strPermanentPinCode").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (strTelephone.toString().length < 11 && strTelephone != "") {
        $("#strTelephone").next("span").remove();
        $("#strTelephone").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
        noerror = 0;
    }
    if (strMobileNo.toString().length < 10 && strMobileNo != "") {
        $("#strMobileNo").next("span").remove();
        $("#strMobileNo").after("<span style='color:Red'>Mobile must be 10 digit</span>");
        noerror = 0;
    }
    if (strPermanentTelephoneNo.toString().length < 11 && strPermanentTelephoneNo != "") {
        $("#strPermanentTelephoneNo").next("span").remove();
        $("#strPermanentTelephoneNo").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
        noerror = 0;
    }
    if (strPermanentMobile1.toString().length < 10 && strPermanentMobile1 != "") {
        $("#strPermanentMobile1 ").next("span").remove();
        $("#strPermanentMobile1 ").after("<span style='color:Red'>Mobile must be 10 digit</span>");
        noerror = 0;
    }

    if (!emailReg.test(email)) {
        $("#strEmail").next("span").remove();
        $("#strEmail").after("<span style='color:Red'>Please enter valid Email </span>");
        noerror = 0;
    }
    if (strPin.toString().length < 6 && strPin != "") {
        $("#strPin ").next("span").remove();
        $("#strPin ").after("<span style='color:Red'>Pin must be 6 digit</span>");
        noerror = 0;
    }
    if (strPermanentPinCode.toString().length < 6 && strPermanentPinCode != "") {
        $("#strPermanentPinCode ").next("span").remove();
        $("#strPermanentPinCode ").after("<span style='color:Red'>Pin must be 6 digit</span>");
        noerror = 0;
    }

    if ($("#strPermanentNearestRailwayStation").val() == "") {
        $("#strPermanentNearestRailwayStation").next("span").remove();
        $("#strPermanentNearestRailwayStation").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strNearestRailwaystation").val() == "") {
        $("#strNearestRailwaystation").next("span").remove();
        $("#strNearestRailwaystation").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strSportsperson").val() == "") {
        $("#strSportsperson").next("span").remove();
        $("#strSportsperson").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {
            return true;
        }
        else {
            return false;
        }

    }


    if (noerror == 0) {
        return false;



    }

}
//SameAddress
$('#SameF').click(function () {
    if (this.checked) {
        var strCorrespondenceAddress = $("#strCorrespondenceAddress").val();
        var strState = $("#strState").val();
        var strDistrict = $("#strDistrict").val();
        var strNearestPostOffice = $("#strNearestPostOffice").val();
        var strNearestPoliceStation = $("#strNearestPoliceStation").val();
        var strNearestRailwaystation = $("#strNearestRailwaystation").val();
        var strPin = $("#strPin").val();
        var strTelephone = $("#strTelephone").val();
        var strMobileNo = $("#strMobileNo").val();
        $("#strPermanentAddress").val(strCorrespondenceAddress);
        $("#strPermanentState").val(strState);
        $("#strPermanentDistrict").val(strDistrict);
        $("#strPermanentNearestPostOffice").val(strNearestPostOffice);
        $("#strPermanentNearestPoliceStation").val(strNearestPoliceStation);
        $("#strPermanentNearestRailwayStation").val(strNearestRailwaystation);
        $("#strPermanentPinCode").val(strPin);
        $("#strPermanentTelephoneNo").val(strTelephone);
        $("#strPermanentMobile1").val(strMobileNo);



    }

    else {
        $("#strPermanentAddress").val("");
        $("#strPermanentState").val("");
        $("#strPermanentDistrict").val("");
        $("#strPermanentNearestPostOffice").val("");
        $("#strPermanentNearestPoliceStation").val("");
        $("#strPermanentNearestRailwayStation").val("");
        $("#strPermanentPinCode").val("");
        $("#strPermanentTelephoneNo").val("");
        $("#strPermanentMobile1").val("");

    }

})
//disablefield
var end = $("#strCategory").val();

if (end == '') {

    $("#strsubcaste").attr('disabled', 'disabled');
}
if ($("#strcertificateno").val() == '') {
    $("#strcertificateno").attr('disabled', 'disabled');
}
if ($("#dt_certificateissuedate").val() == '') {
    $("#dt_certificateissuedate").attr('disabled', 'disabled');
}
if ($("#strcertificateissue").val() == '') {
    $("#strcertificateissue").attr('disabled', 'disabled');
}
if ($("#strexservicemanno").val() == '') {
    $("#strexservicemanno").attr('disabled', 'disabled');
}


if ($("#stremployeecode").val() == '') {
    $("#stremployeecode").attr('disabled', 'disabled');
}
if ($("#strgrade").val() == '') {
    $("#strgrade").attr('disabled', 'disabled');
}
if ($("#strplaceposting").val() == '') {
    $("#strplaceposting").attr('disabled', 'disabled');
}
if ($("#strpresentdesignation").val() == '') {
    $("#strpresentdesignation").attr('disabled', 'disabled');
}
if ($("#dt_presententrydate").val() == '') {
    $("#dt_presententrydate").attr('disabled', 'disabled');
}
if ($("#strapplyproper").val() == '') {
    $("#strapplyproper").attr('disabled', 'disabled');
}

//Disable Label
$("#lblsubcaste").hide();
$("#lblcertificateno").hide();
$("#lblissuedate").hide();
$("#lblcertificateissue").hide();
$("#lblexservicemanno").hide();
$("#lbltypeofdisable").hide();
$("#lblstrDisableDetail").hide();
$("#lblcertificateno1").hide();
$("#lblcertificateissuedate1").hide();
$("#lblcertificateissue1").hide();
$("#lblemployeecode").hide();
$("#lblgrade").hide();
$("#lblplaceposting").hide();
$("#lblpresentdesignation").hide();
$("#lblpresententrydate").hide();
$("#lblapplyproper").hide();



//Category
$("#strCategory").change(function () {
    var strCategory = $("#strCategory").val();
    $("#strCategory").next("span").remove();
    if (strCategory == "") {
        $("#strCategory").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strCategory").next("span").remove();
        Category();
    }
});
function Category() {
    var end = $("#strCategory").val();
    if (end !== 'General') {
        $("#lblsubcaste").show();
        $("#lblcertificateno").show();
        $("#lblissuedate").show();
        $("#lblcertificateissue").show();
        $("#strsubcaste").removeAttr('disabled');
        $("#strcertificateno").removeAttr('disabled');
        $("#dt_certificateissuedate").removeAttr('disabled');
        $("#strcertificateissue").removeAttr('disabled');

    }
    else {
        $("#lblsubcaste").hide();
        $("#lblcertificateno").hide();
        $("#lblissuedate").hide();
        $("#lblcertificateissue").hide();
        $("#strsubcaste").attr('disabled', 'disabled');
        $("#strcertificateno").attr('disabled', 'disabled');
        $("#dt_certificateissuedate").attr('disabled', 'disabled');
        $("#strcertificateissue").attr('disabled', 'disabled');
        $("#strsubcaste").val('');
        $("#strcertificateno").val('');
        $("#dt_certificateissuedate").val('');
        $("#strcertificateissue").val('');
        $("#strsubcaste").next("span").remove();
        $("#strcertificateno").next("span").remove();
        $("#dt_certificateissuedate").next("span").remove();
        $("#strcertificateissue").next("span").remove();
    }

}
//exserviceman
$("#strExserviceMan").change(function () {

    var strExserviceMan = $("#strExserviceMan").val();
    $("#strExserviceMan").next("span").remove();
    if (strExserviceMan == "") {
        $("#strExserviceMan").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strExserviceMan").next("span").remove();
        exserviceman();
    }
});
function exserviceman() {
    var end = $("#strExserviceMan").val();

    if (end !== 'Yes') {

        $("#lblexservicemanno").hide();

        $("#strexservicemanno").attr('disabled', 'disabled');
        $("#strexservicemanno").val('');
        $("#strexservicemanno").next("span").remove();
    }
    else {

        $("#lblexservicemanno").show();
        $("#strexservicemanno").removeAttr('disabled');



    }

}


$("#strapplyproper").change(function () {
    var strapplyproper = $("#strapplyproper").val();
    $("#strapplyproper").next("span").remove();
    if (strapplyproper == "") {
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strapplyproper").next("span").remove();
    }
});

//internalcandidate
$("#strInternalCandidate").change(function () {

    var strInternalCandidate = $("#strInternalCandidate").val();
    $("#strInternalCandidate").next("span").remove();
    if (strInternalCandidate == "") {
        $("#strInternalCandidate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strInternalCandidate").next("span").remove();
        internalcandidate();
    }
});
function internalcandidate() {
    var end = $("#strInternalCandidate").val();
    if (end == 'Yes') {
        $("#lblemployeecode").show();
        $("#lblgrade").show();
        $("#lblplaceposting").show();
        $("#lblpresentdesignation").show();
        $("#lblpresententrydate").show();
        $("#stremployeecode").removeAttr('disabled');
        $("#strgrade").removeAttr('disabled');
        $("#strplaceposting").removeAttr('disabled');
        $("#strpresentdesignation").removeAttr('disabled');
        $("#dt_presententrydate").removeAttr('disabled');

    }
    else {
        $("#lblemployeecode").hide();
        $("#lblgrade").hide();
        $("#lblplaceposting").hide();
        $("#lblpresentdesignation").hide();
        $("#lblpresententrydate").hide();
        $("#stremployeecode").attr('disabled', 'disabled');
        $("#strgrade").attr('disabled', 'disabled');
        $("#strplaceposting").attr('disabled', 'disabled');
        $("#strpresentdesignation").attr('disabled', 'disabled');
        $("#dt_presententrydate").attr('disabled', 'disabled');

        $("#stremployeecode").val('');
        $("#strgrade").val('');
        $("#strplaceposting").val('');
        $("#strpresentdesignation").val('');
        $("#dt_presententrydate").val('');
        $("#stremployeecode").next("span").remove();
        $("#strgrade").next("span").remove();
        $("#strplaceposting").next("span").remove();
        $("#strpresentdesignation").next("span").remove();
        $("#dt_presententrydate").next("span").remove();

    }

}
//Apply through
$("#strEmployedIn").change(function () {
    var strEmployedIn = $("#strEmployedIn").val();
    $("#strEmployedIn").next("span").remove();
    if (strEmployedIn == "") {
        $("#strEmployedIn").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strEmployedIn").next("span").remove();
        Apply();
    }
});
function Apply() {
    var end = $("#strEmployedIn").val();
    if (end == 'N/A') {

        $("#lblapplyproper").hide();
        $("#strapplyproper").val('');
        $("#strapplyproper").attr('disabled', 'disabled');
        $("#strapplyproper").next("span").remove();
    }
    else {

        $("#lblapplyproper").show();
        $("#strapplyproper").removeAttr('disabled');

    }

}




//Aadhar and PAN 

$("#strAadharNo").keyup(function () {
    var strAadharNo = $("#strAadharNo").val();
    $("#strAadharNo").next("span").remove();
    if (strAadharNo.toString().length < 12 && strAadharNo != "") {
        $("#strAadharNo").after("<span style='color:Red'>Aadhaar no. must be 12 digit</span>");
    }
    else {
        $("#strAadharNo").val(strAadharNo.substring(0, 12));
        $("#strAadharNo").next("span").remove();
    }
});

$("#strPANNo").keyup(function () {
    var strPANNo = $("#strPANNo").val();
    $("#strPANNo").next("span").remove();
    if (strPANNo.toString().length < 10 && strPANNo != "") {
        $("#strPANNo").after("<span style='color:Red'>PAN No. must be 10 digit</span>");
    }
    else {
        $("#strPANNo").val(strPANNo.substring(0, 10));
        $("#strPANNo").next("span").remove();
    }
});

$('.date').datepicker({
    format: 'dd-mm-yyyy'
}).datepicker().on('changeDate', function (ev) {
    $(this).next("span").remove();

});