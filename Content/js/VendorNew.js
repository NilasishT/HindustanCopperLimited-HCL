var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

$('#strRegistrationApplied').multipleSelect({
    isOpen: true,
    keepOpen: true,
    selectAll: true,
    minimumCountSelected: 1,
    single: false,
    maxHeight: 300
});
var RegistrationApplied = $("#hidstrRegistrationApplied").val();

if (RegistrationApplied != "") {
    var data = $("#hidstrRegistrationApplied").val();
    var dataarray = data.split(",");
    $("#strRegistrationApplied").val(dataarray);
    $("#strRegistrationApplied").multipleSelect("refresh");
}



$("#strNameofFirmCompany").keyup("input", function () {
    Required(this);
});
$("#strGSTNo").bind("input", function () {
    LimtCharacters(this, 15, 'GST No. must be 15 digit');
});
//$("#strPANNo").bind("input", function () {
//    LimtCharacters(this, 11, 'PAN No. must be 10 digit');
//});
$("#fk_intConstitutionFirmID").change("input", function () {
    Required(this);
});
$("#str_company_others").keyup("input", function () {
    Required(this);
});
$("#int_fk_CompanyStatusID").change("input", function () {
    Required(this);
});

//$("#str_city").keyup("input", function () {
//    Required(this);
//});
$("#str_state").change("input", function () {
    if ($("#str_country").val() == "India") {
        Required(this);
    }
});
$("#str_country").change("input", function () {
    Required(this);
});
$("#str_pin").keyup("input", function () {
    if ($("#str_country").val() == "India") {
        Required(this);
    }
});

$("#strIsManpowerSupplier").change("input", function () {
    Required(this);
});
$("#strCorrespondenceAddress").keyup("input", function () {
    Required(this);
});


$("#strPhone1").keyup(function () {
    var strPhone1 = $("#strPhone1").val();
    $("#strPhone1").next("span").remove();
    if (strPhone1.toString().length < 11 && strPhone1 != "") {
        $("#strPhone1").after("<span style='color:#C00000'>Phone no. must be 11 digit</span>");
    }
    else {
        $("#strPhone1").next("span").remove();
    }
});

//$("#strPhone1").bind("input", function () {
//    LimtCharacters(this, 11, 'Phone No. must be 11 digit');
//});
//$("#str_companydesc").bind("input", function () {
//    LimtCharacters(this, 30);
//});

$("#strNameContactPerson").keyup("input", function () {
    Required(this);
});
$("#strDesignationofContactPerson").keyup("input", function () {
    Required(this);
});
$("#strMobile").bind("input", function () {
    LimtCharacters(this, 10, 'Mobile No. must be 10 digit');
});



$("#strPANNo").bind("input", function () {
    LimtCharacters(this, 10, 'PAN No. must be 10 digit');
});

//$("#strPANNo").keyup("input", function () {
//    Required(this);
//});



$("#strEmail").keyup("input", function () {
    Required(this);
});
$("#strRegistrationApplied").change("input", function () {
    Required(this);
});
$("#strTypeofIndustry").change("input", function () {
    if ($("#str_country").val() == "India") {
        Required(this);
    }
});
$("#intfk_CategoryID").change("input", function () {
    Required(this);
});
$("#CaptchaRoniInput").keyup("input", function () {
    Required(this);
});
$("#str_serviceprovidertype").change("input", function () {
    Required(this);
});


numeric();
Country();






$("#fk_intConstitutionFirmID").change(function () {
    FirmStatus();
});

if ($("#fk_intConstitutionFirmID").val() != "") {
    FirmStatus();
}


function FirmStatus() {
    var FirmStatus = $("#fk_intConstitutionFirmID").val();
    var other = $("#str_company_others").val();


    if (FirmStatus == "") {
        $("#errmsgFirm").html('This field is required').show().css("color", "red");
        return false;
    }
    else if (FirmStatus == '5') {
        $("#str_company_others").next("span").remove();
        if (other == '') {

            $("#str_company_others").after("<span style='color:#C00000'> This field is required</span>")
        }

        else {
            $("#str_company_others").next("span").remove();
        }
        $("#str_company_others").show();
        $("#Others").show();


        return false;
    }
    else {
        $("#str_company_others").next("span").remove();
        $("#errmsgFirm").html('');
        $("#str_company_others").hide();
        $("#Others").hide();

        $("#str_company_others").val('');
    }
}








if ($("#int_fk_CompanyStatusID").val() != "") {
    companyStatus();
}


$("#int_fk_CompanyStatusID").change(function () {
    companyStatus();
});

$("#strIsManpowerSupplier").change(function () {


    manpower();



});

function companyStatus() {
    var companyStatus = $("#int_fk_CompanyStatusID").val();
    var Manpower = $("#strIsManpowerSupplier").val();
    var provider = $("#str_serviceprovidertype").val();
    if (companyStatus == "") {
        $("#int_fk_CompanyStatusID").after("<span style='color:#C00000'> This field is required</span>");
        return false;
    }
    else if (companyStatus == '5') {
        if (Manpower == '') {


            $("#strIsManpowerSupplier").after("<span style='color:#C00000'> This field is required</span>");
        }
        else {
            $("#strIsManpowerSupplier").next("span").remove();
        }
        if (provider == '') {
          

            $("#str_serviceprovidertype").after("<span style='color:#C00000'> This field is required</span>");
        }
        else {
            $("#str_serviceprovidertype").next("span").remove();
        }


        $("#ShowManProvided").show();
        $("#strIsManpowerSupplier").show();

        $("#int_fk_CompanyStatusID").next("span").remove();
        $("#ServiceProvided").show();
        $("#str_serviceprovidertype").show();

        $("#int_fk_CompanyStatusID").next("span").remove()
        return false;
    }
   
    else {
        $("#strIsManpowerSupplier").next("span").remove();
        $("#strIsManpowerSupplier").val('');
        $("#ShowManProvided").hide();
        $("#strIsManpowerSupplier").hide();
        $("#int_fk_CompanyStatusID").next("span").remove();
        $("#ServiceProvided").hide();
        $("#str_serviceprovidertype").hide();
        $("#str_serviceprovidertype").val('');
        $("#str_serviceprovidertype").next("span").remove()
    }
}



$("#strTypeofIndustry").change(function () {

    typeofins();
});




var end = $("#strTypeofIndustry").val();
if (end == 'MSME') {
    $("#intfk_CategoryID").show();
    $("#strcategoryMSMED").show();
    $("#cast").html('Category of MSME').append("<span style='color:#C00000'>(*)</span>");
}
else {
    $("#intfk_CategoryID").hide();
    $("#strcategoryMSMED").hide();
    $("#errmsgStatusofMSME").hide();
    $("#cast").html("");
    $("#intfk_CategoryID").val('');
}

function typeofins() {
    var end = $("#strTypeofIndustry").val();
    if (end == 'MSME') {
        $("#intfk_CategoryID").show();
        $("#strcategoryMSMED").show();
        $("#cast").html('Category of MSME').append("<span style='color:#C00000'>(*)</span>");
     
        $("#intfk_CategoryID").after("<span style='color:#C00000'> This field is required</span>");
    }
    else {
        $("#intfk_CategoryID").hide();
        $("#strcategoryMSMED").hide();
        $("#errmsgStatusofMSME").hide();
        $("#cast").html("");
        $("#intfk_CategoryID").val('');
        $("#intfk_CategoryID").next("span").remove();
    }
}



//Country
$("#str_country").change(function () {
   
    Country();
});



function Country() {
    var end = $("#str_country").val();
    $("#country").val(end);
    if (end == 'India') {
        $("#strGSTNo").show();
        $("#strPANNo").show();
        $("#Pin").show();
        $("#State").show();
        $("#STD").show();
        $("#MSME").show();
        $("#GST").html('GST No.').append("<span style='color:#C00000'>(*)</span>");
        $("#PAN").html('PAN No.').append("<span style='color:#C00000'>(*)</span>");
        if ($("#strGSTNo").val() == "" && $("#strPANNo").val() == "") {
           
            $("#strGSTNo").after("<span style='color:#C00000'> This field is required</span>");
            $("#strPANNo").after("<span style='color:#C00000'> This field is required</span>");
        }
        else {

            $("#strGSTNo").next("span").remove();
            $("#strPANNo").next("span").remove();
        }
        
    }
    else {
        $("#strGSTNo").hide();
        $("#strPANNo").hide();

        $("#GST").html("");
        $("#PAN").html("");
        $("#strGSTNo").val('');
        $("#strPANNo").val('');
        $("#strTypeofIndustry").val('');
        $("#strPANNo").next("span").remove();
        $("#strGSTNo").next("span").remove();
        $("#str_pin").next("span").remove();
        $("#str_state").next("span").remove();
        $("#strTypeofIndustry").next("span").remove();
        $("#strPhone1").next("span").remove();

        $("#intfk_CategoryID").hide();
        $("#strcategoryMSMED").hide();
        $("#errmsgStatusofMSME").hide();
        $("#cast").html("");


        $("#State").hide();
        $("#Pin").hide();
        $("#STD").hide();
        $("#MSME").hide();
        
        
    }
}





function numeric() {


//    $("#strGSTNo").hide();
//    $("#strPANNo").hide();
//    $("#GST").hide();
//    $("#PAN").hide();




    $("#ShowManProvided").hide();
    $("#strIsManpowerSupplier").hide();

    $("#str_company_others").hide();

    $("#ServiceProvided").hide();
    $("#str_serviceprovidertype").hide();


   $("#Others").hide();

    $("#strPhone1").ForceNumericOnly();

    $("#strMobile").ForceNumericOnly();

    $("#strFax").ForceNumericOnly();

    var end = $("#str_country").val();
    $("#country").val(end);
  

}




function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + txtMsg.id).next("span").remove();
        $("#" + txtMsg.id).after("<span style='color:#C00000'> Max Length reached..</span>");
        $("#" + txtMsg.id).next('span').show().fadeOut("slow");
        return false;
    }

    else if (chars == 0) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + txtMsg.id).next("span").remove();
        $("#" + txtMsg.id).after("<span style='color:#C00000'> This field is required</span>");
        return false;
    }

    else {
        $("#" + txtMsg.id).next("span").remove();
        $("#" + txtMsg.id).after("<span style='color:#C00000'> " + errmsg + "</span>");
        
    }
}

function Required(txtMsg) {
    chars = txtMsg.value.length;
    if (chars > 0) {
        $("#" + txtMsg.id).next("span").remove();
        return false;
    }
    else {
        $("#" + txtMsg.id).next("span").remove();
        $("#" + txtMsg.id).after("<span style='color:#C00000'> This field is required</span>");

    }
}







function error() {
    $('#hidstrRegistrationApplied').val($('#strRegistrationApplied').multipleSelect('getSelects'))
    var noerror = 1;

    if ($("#strNameofFirmCompany").val() == "") {
        $("#strNameofFirmCompany").next("span").remove();
        $("#strNameofFirmCompany").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }
   
//    if ($("#strPANNo").val() == "") {
//        $("#strPANNo").next("span").remove();
//        $("#strPANNo").after("<span style='color:#C00000'> This field is required</span>");
//        noerror = 0;
//    }
    if ($("#fk_intConstitutionFirmID").val() == "") {
        $("#fk_intConstitutionFirmID").next("span").remove();
        $("#fk_intConstitutionFirmID").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }
  

    if ($("#fk_intConstitutionFirmID").val() == "5") {
        if ($("#str_company_others").val() == "") {
            $("#str_company_others").next("span").remove();
            $("#str_company_others").after("<span style='color:#C00000'> This field is required</span>");
            noerror = 0;
        }
  }



    if ($("#int_fk_CompanyStatusID").val() == "") {
        $("#int_fk_CompanyStatusID").next("span").remove();
        $("#int_fk_CompanyStatusID").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }



    if ($("#int_fk_CompanyStatusID").val() == "5") {
        if ($("#strIsManpowerSupplier").val() == "") {
           $("#strIsManpowerSupplier").next("span").remove();
            $("#strIsManpowerSupplier").after("<span style='color:#C00000'> This field is required</span>");
           noerror = 0;
        }

   }


    if ($("#strCorrespondenceAddress").val() == "") {
        $("#strCorrespondenceAddress").next("span").remove();
        $("#strCorrespondenceAddress").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }
    
    if ($("#strNameContactPerson").val() == "") {
        $("#strNameContactPerson").next("span").remove();
        $("#strNameContactPerson").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strDesignationofContactPerson").val() == "") {
        $("#strDesignationofContactPerson").next("span").remove();
        $("#strDesignationofContactPerson").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strMobile").val() == "") {
        $("#strMobile").next("span").remove();
        $("#strMobile").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }

    
    var telephone = $("#strPhone1").val();

    if (telephone!="" && telephone.toString().length < 11) {
        $("#strPhone1").next("span").remove();
        $("#strPhone1").after("<span style='color:#C00000'>Phone must be 11 digit</span>");
      
        noerror = 0;
    }




//    if ($("#str_city").val() == "") {
//        $("#str_city").next("span").remove();
//        $("#str_city").after("<span style='color:#C00000'> This field is required</span>");
//        noerror = 0;
//    }


   


    if ($("#str_country").val() == "") {
        $("#str_country").next("span").remove();
        $("#str_country").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_pin").val() == "" && $("#str_country").val() == "India") {
       
        $("#str_pin").next("span").remove();
        $("#str_pin").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }




    if ($("#strEmail").val() == "") {
        $("#strEmail").next("span").remove();
        $("#strEmail").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }
    if ($("#hidstrRegistrationApplied").val() == "") {
        $("#strRegistrationApplied").next("span").remove();
        $("#strRegistrationApplied").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }

   
    if ($("#strTypeofIndustry").val() == "MSME") {
        alert($("#intfk_CategoryID").val());
        if ($("#intfk_CategoryID").val() == "") {
            $("#intfk_CategoryID").next("span").remove();
            $("#intfk_CategoryID").after("<span style='color:#C00000'> This field is required</span>");
            noerror = 0;
        }
    }


    if ($("#CaptchaRoniInput").val() == "") {
        $("#CaptchaRoniInput").next("span").remove();
        $("#CaptchaRoniInput").after("<span style='color:#C00000'> This field is required</span>");
        noerror = 0;
    }


    if ($("#str_country").val() == "India") {

        if ($("#strPhone1").val() == "" && $("#str_country").val() == "India") {
            $("#strPhone1").next("span").remove();
            $("#strPhone1").after("<span style='color:#C00000'> This field is required</span>");
            noerror = 0;
        }

        if ($("#str_state").val() == "" && $("#str_country").val() == "India") {
            $("#str_state").next("span").remove();
            $("#str_state").after("<span style='color:#C00000'> This field is required</span>");
            noerror = 0;
        }

        if ($("#strTypeofIndustry").val() == "" && $("#str_country").val() == "India") {
            $("#strTypeofIndustry").next("span").remove();
            $("#strTypeofIndustry").after("<span style='color:#C00000'> This field is required</span>");
            noerror = 0;
        }

        var GSTNo = $('#strGSTNo').val();
        var valid = GSTNo.substr(2, 10);
        if ($("#strPANNo").val() != valid) {

            $("#strPANNo").next("span").remove();
            $("#strPANNo").after("<span style='color:#C00000'>Pan No. is invalid</span>");
            noerror = 0;
        }
        if ($("#strGSTNo").val() == "" && $("#str_country").val() == "India") {
            $("#strGSTNo").next("span").remove();
            $("#strGSTNo").after("<span style='color:#C00000'> This field is required</span>");
            noerror = 0;
        }

        if ($("#strPANNo").val() == "" && $("#str_country").val() == "India") {
            $("#strPANNo").next("span").remove();
            $("#strPANNo").after("<span style='color:#C00000'> This field is required</span>");
            noerror = 0;
        }
    }






    
    if (noerror == 1) {
        if (confirm("Are you sure ?")) {
            $('#spinner').show();
            if ($('#VendorsNew')[0].checkValidity()) {
            }
        }
        else {
            return false;
        }
    }

    if (noerror == 0) {
        return false;
    }
}


$("#strGSTNo").change(function () {
    var GSTNo = $('#strGSTNo').val();
    if (GSTNo == "") 
    {

    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/VendorRegistration/checkGST',
            data: { 'GSTNo': GSTNo },
            success: function (result) {
                if (result.already == "Yes") {
                    alert('GST No. already exists.')
                    $('#strGSTNo').val('');
                }
            },
            error: function () {
                alert('Error');
            }
        });
    }
});



  

   

$("#str_company_others").on("input", function () {
    LimitCharacters(this, 150);
});

$("#str_companydesc").on("input", function () {
    LimitCharacters(this, 300);
});

$("#strNameContactPerson").on("input", function () {
    LimitCharacters(this, 50);
});

$("#strDesignationofContactPerson").on("input", function () {
    LimitCharacters(this, 50);
});

$("#strEmail").on("input", function () {
    LimitCharacters(this, 50);
});



$("#strNameofFirmCompany").on("input", function () {
    LimitCharacters(this, 100);
});

$("#str_city").on("input", function () {
    LimitCharacters(this, 80);
});

$("#str_pin").on("input", function () {
    LimitCharacters(this, 10);
});

$("#strFax").on("input", function () {
    LimitCharacters(this, 11);
});
$("#strPhone1").on("input", function () {
    LimitCharacters(this, 11);
});

function LimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:#C00000'> Max Length reached..</span>");
    }
}