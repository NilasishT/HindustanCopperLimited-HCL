var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;


function error() {
    $('#hidFk_intUnitId').val($('#Fk_intUnitId').multipleSelect('getSelects'))
    $('#hidFk_intDepartment').val($('#Fk_intDepartment').multipleSelect('getSelects'))



    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

    var UnitName = $('#strNameofFirmCompany').val();
    var UnitCode = $('#strEmail1').val();
    var UnitAdd = $('#strPhone1').val();
    var UnitContInfo = $('#strCorrespondenceAddress').val();

    //For unit
    if ($('#Fk_intUnitId').multipleSelect('getSelects') == '' || $('#Fk_intUnitId').multipleSelect('getSelects') == null) {
        $("#errmsg23").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    //Company Status
    if ($("#int_fk_CompanyStatusID").val() == "") {
        $("#errmsg26").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    //Manpower
    if ($("#int_fk_CompanyStatusID").val() == "5") {
        if ($("#ifManpowerSupply").val() == "") {
            $("#errmsg24").html('required').show().css("color", "red");
            noerror = 0;
        }
        if ($("#ifManpowerSupply").val() == "Yes") {
            if ($('#Fk_intDepartment').multipleSelect('getSelects') == '' || $('#Fk_intDepartment').multipleSelect('getSelects') == null) {
                $("#errmsg25").html('This field is required').show().css("color", "red");
                noerror = 0;
            }
        }
    }

    //Name of Firm/Company
    if (names == "") {
        $("#errmsg").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    //Correspondence Address
    if (names1 == "") {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    //E-mail
    if (email == "") {
        $("#errmsg4").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (!emailReg.test(email)) {
        $("#errmsg4").html('Please enter a valid email address').show().css("color", "red");
        noerror = 0;
    }

    //STD Code with Phone No.
    if (telephone == "") {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (telephone.toString().length < 11) {
        $("#errmsg2").html('Phone must be 11 digit').show().css("color", "red");
        noerror = 0;
    }
    if (telephone3.toString().length < 11 && telephone3.toString().length > 0) {
        $("#errmsg12").html('Phone must be 11 digit').show().css("color", "red");
        noerror = 0;
    }

    //Fax   
    if (fax1.toString().length < 11 && fax1.toString().length > 0) {
        $("#errmsg3").html('Fax must be 11 digit').show().css("color", "red");
        noerror = 0;
    }

    if (fax2.toString().length < 11 && fax2.toString().length > 0) {
        $("#errmsg8").html('Fax must be 11 digit').show().css("color", "red");
        noerror = 0;
    }
    if (fax3.toString().length < 11 && fax3.toString().length > 0) {
        $("#errmsg13").html('Fax must be 11 digit').show().css("color", "red");
        noerror = 0;
    }



    //RegisteredOfficeAddress
    if (names2 == "") {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    //E-mail1
    if (email1 == "") {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (!emailReg.test(email1)) {
        $("#errmsg9").html('Please enter a valid email address').show().css("color", "red");
        noerror = 0;
    }

    //STD Code with Phone No.1


    if (telephone1 == "") {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (telephone1.toString().length < 11) {
        $("#errmsg7").html('Phone must be 11 digit').show().css("color", "red");
        noerror = 0;
    }

    //NameContactPerson
    if (names3 == "") {
        $("#errmsg16").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    //DesignationofContactPerson
    if (names4 == "") {
        $("#errmsg17").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    //Phone No.Office    

    if (telephone2 == "") {
        $("#errmsg18").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (telephone2.toString().length < 11) {
        $("#errmsg18").html('Phone must be 11 digit').show().css("color", "red");
        noerror = 0;
    }

    if (phoneResidence.toString().length < 11 && phoneResidence.toString().length > 0) {
        $("#errmsg19").html('Phone must be 11 digit').show().css("color", "red");
        noerror = 0;
    }

    //MobileNo.
    if (mobile == "") {
        $("#errmsg20").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (mobile.toString().length < 10) {
        $("#errmsg20").html('Mobile must be 10 digit').show().css("color", "red");
        noerror = 0;
    }
    //Email
    if (email2 == "") {
        $("#errmsg21").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (!emailReg.test(email2)) {
        $("#errmsg21").html('Please enter a valid email address').show().css("color", "red");
        noerror = 0;
    }

    if (ValidCaptchaRoni() == false) {
        $("#errmsg22").html('Invalid Captcha').show().css("color", "red");
        noerror = 0;
    }

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {
            if ($('#VendorRegistration')[0].checkValidity()) {
                $('#spinner').show();
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























////
$("#strFax").bind("input", function () {
    Minimumcharaterlimit(this, 11, 'errmsg3', 'Fax must be 11 digit');
});
$("#strFax1").bind("input", function () {
    Minimumcharaterlimit(this, 11, 'errmsg8', 'Fax must be 11 digit');
});
$("#strFax2").bind("input", function () {
    Minimumcharaterlimit(this, 11, 'errmsg13', 'Fax must be 11 digit');
});
$("#strPhone3").bind("input", function () {
    Minimumcharaterlimit(this, 11, 'errmsg12', 'Phone must be 11 digit');
});
$("#strPhoneResidence").bind("input", function () {
    Minimumcharaterlimit(this, 11, 'errmsg19', 'Phone must be 11 digit');
});



$("#strEmail1").keyup(function () {
    if (emailReg.test(this.value)) {
        $("#errmsg4").html('');
    }
});
$("#strEmail2").keyup(function () {
    if (emailReg.test(this.value)) {
        $("#errmsg9").html('');
    }
});
$("#strEmail").keyup(function () {
    if (emailReg.test(this.value)) {
        $("#errmsg21").html('');
    }
});



$("#strNameofFirmCompany").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg").html('');


    }
});
$("#strCorrespondenceAddress").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg1").html('');


    }
});
$("#strPhone1").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        return false;

    } else {
        Minimumcharaterlimit(this, 11, 'errmsg2', 'Phone must be 11 digit');

    }
});

$("#strstrRegisteredOfficeAddress").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg6").html('');


    }
});

$("#strPhone2").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        return false;
    } else {
        Minimumcharaterlimit(this, 11, 'errmsg7', 'Phone must be 11 digit');
    }
});

$("#strNameContactPerson").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg16").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg16").html('');


    }
});
$("#strDesignationofContactPerson").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg17").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg17").html('');


    }
});
$("#strPhoneoffice").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg18").html('This field is required').show().css("color", "red");
        return false;

    } else {
        Minimumcharaterlimit(this, 11, 'errmsg18', 'Phone must be 11 digit');
    }
});
$("#strMobile").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg20").html('This field is required').show().css("color", "red");
        return false;

    } else {
        Minimumcharaterlimit(this, 10, 'errmsg20', 'Mobile must be 10 digit');

    }
});


function Minimumcharaterlimit(txtMsg, CharLength, errmsg, errmsgtext) {
    chars = txtMsg.value.length;
    if (chars > 0) {
        if (chars < CharLength) {
            txtMsg.value = txtMsg.value.substring(0, CharLength);
            $("#" + errmsg).html(errmsgtext).show().css("color", "red");
            return false;
        }
        else {
            $("#" + errmsg).html('');

        }
    }
    else {
        $("#" + errmsg).html('');


    }
}



$("#strNameofFirmCompany").on("input", function () {
    LimtCharacters(this, 100, 'errmsg');
});

//Correspondence Address
$("#strCorrespondenceAddress").on("input", function () {
    LimtCharacters(this, 400, 'errmsg1');
});
$("#strPhone1").on("input", function () {
    LimtCharacters(this, 11, 'errmsg2');
});
$("#strFax").on("input", function () {
    LimtCharacters(this, 11, 'errmsg3');
});
$("#strEmail1").on("input", function () {
    LimtCharacters(this, 50, 'errmsg4');
});
$("#strWebsite1").on("input", function () {
    LimtCharacters(this, 50, 'errmsg5');
});

//Registered Office Address

$("#strstrRegisteredOfficeAddress").on("input", function () {
    LimtCharacters(this, 400, 'errmsg6');
});
$("#strPhone2").on("input", function () {
    LimtCharacters(this, 11, 'errmsg7');
});
$("#strFax1").on("input", function () {
    LimtCharacters(this, 11, 'errmsg8');
});
$("#strEmail2").on("input", function () {
    LimtCharacters(this, 50, 'errmsg9');
});
$("#strWebsite2").on("input", function () {
    LimtCharacters(this, 50, 'errmsg10');
});

//Factory Address

$("#strFactoryAddress").on("input", function () {
    LimtCharacters(this, 400, 'errmsg11');
});
$("#strPhone3").on("input", function () {
    LimtCharacters(this, 11, 'errmsg12');
});
$("#strFax2").on("input", function () {
    LimtCharacters(this, 11, 'errmsg13');
});
$("#strNameContactPerson1").on("input", function () {
    LimtCharacters(this, 150, 'errmsg14');
});
$("#strDesignationofContactPerson1").on("input", function () {
    LimtCharacters(this, 150, 'errmsg15');
});


//Name of Contact Person

$("#strNameContactPerson").on("input", function () {
    LimtCharacters(this, 50, 'errmsg16');
});
$("#strDesignationofContactPerson").on("input", function () {
    LimtCharacters(this, 50, 'errmsg17');
});
$("#strPhoneoffice").on("input", function () {
    LimtCharacters(this, 11, 'errmsg18');
});
$("#strPhoneResidence").on("input", function () {
    LimtCharacters(this, 11, 'errmsg19');
});
$("#strMobile").on("input", function () {
    LimtCharacters(this, 10, 'errmsg20');
});
$("#strEmail").on("input", function () {
    LimtCharacters(this, 50, 'errmsg21');
});



function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
        return false;
    }
}

////Shoumya
numeric();

$('#SameF').click(function () {
    if (this.checked) {
        var CorrespondenceAddress = $("#strCorrespondenceAddress").val();
        var STD = $("#strSTD1").val();
        var Phone = $("#strPhone1").val();
        var Fax = $("#strFax1").val();
        var Email = $("#strEmail1").val();
        var Website = $("#strWebsite1").val();
        $("#strstrRegisteredOfficeAddress").val(CorrespondenceAddress);
        $("#strSTD2").val(STD);
        $("#strPhone2").val(Phone);
        $("#strFax").val(Fax);
        $("#strEmail2").val(Email);
        $("#strWebsite2").val(Website);

        $("#strNameofFirmCompany,#strCorrespondenceAddress,#strPhone1,#strEmail1,#strstrRegisteredOfficeAddress,#strPhone2,#strEmail2,#strNameContactPerson,#strDesignationofContactPerson,#strPhoneoffice,#strMobile,#strEmail").keyup();
    }

    else {
        $("#strstrRegisteredOfficeAddress").val("");
        $("#strSTD2").val("");
        $("#strPhone2").val("");
        $("#strFax").val("");
        $("#strEmail2").val("");
        $("#strWebsite2").val("");

    }

})


function numeric() {
    $("#ShowManProvided").hide();
    $("#ifManpowerSupply").hide();
    $("#ShowDepartment").hide();
    $("#ShowDepartmentlistView").hide();

    $("#strPhone1").ForceNumericOnly();
    $("#strPhone2").ForceNumericOnly();
    $("#strPhone3").ForceNumericOnly();
    $("#strPhoneoffice").ForceNumericOnly();
    $("#strPhoneResidence").ForceNumericOnly();
    $("#strYearofEstablishment").ForceNumericOnly();
    $("#strMobile3").ForceNumericOnly();
    $("#strMobile").ForceNumericOnly();
    $("#strFax1").ForceNumericOnly();
    $("#strFax").ForceNumericOnly();
    $("#strFax2").ForceNumericOnly();
    if ($("#strPhone1").val() == '') {
        $("#strPhone1").val('0');
    }
    if ($("#strPhone2").val() == '') {
        $("#strPhone2").val('0');
    }

    if ($("#strPhoneoffice").val() == '') {
        $("#strPhoneoffice").val('0');
    }
}





$('#Fk_intUnitId,#Fk_intDepartment').multipleSelect({
    isOpen: true,
    keepOpen: true,
    selectAll: true,
    minimumCountSelected: 1,
    single: false,
    maxHeight: 150

});





$('#Fk_intDepartment').change(function () {
    if ($('#Fk_intDepartment').multipleSelect('getSelects') == "") {
        $("#errmsg25").html('This field is required').show().css("color", "red");

    }
    else {
        $("#errmsg25").html('');
    }
});



$('#Fk_intUnitId').change(function () {
    if ($('#Fk_intUnitId').multipleSelect('getSelects') == "") {
        $("#errmsg23").html('This field is required').show().css("color", "red");
    }
    else {
        $("#errmsg23").html('');
    }
});
//Manpower
if ($("#int_fk_CompanyStatusID").val() != "") {
    companyStatus();
}
if ($("#ifManpowerSupply").val() != "") {
    manpower();
}


$("#int_fk_CompanyStatusID").change(function () {

    companyStatus();
});

$("#ifManpowerSupply").change(function () {
    manpower();

});


function companyStatus() {
    var companyStatus = $("#int_fk_CompanyStatusID").val();
    if (companyStatus == "") {
        $("#errmsg26").html('This field is required').show().css("color", "red");
        return false;
    }

    else if (companyStatus == '5') {
        $("#errmsg24").html('Required').show().css("color", "red");
        $("#ShowManProvided").show();
        $("#ifManpowerSupply").show();
        $("#ifManpowerSupply").val('');
        $("#errmsg26").html('')
        return false;
    }

    else {
        $("#errmsg24").html('')
        $("#errmsg25").html('')
        $("#ShowManProvided").hide();
        $("#ifManpowerSupply").hide();
        $("#ShowDepartment").hide();
        $("#ShowDepartmentlistView").hide();
        $("#hidFk_intDepartment").val('');
        $("#errmsg26").html('')

    }
}


function manpower() {
    var companyStatus = $("#ifManpowerSupply").val();
    if (companyStatus != '') {
        $("#errmsg24").html('');
        if (companyStatus == 'Yes') {

            $('#Fk_intDepartment').multipleSelect({
                isOpen: true,
                keepOpen: true,
                selectAll: true,
                minimumCountSelected: 1,
                single: false,
                maxHeight: 150

            });

            $("#ShowDepartment").show();
            $("#ShowDepartmentlistView").show();
            $("#errmsg25").html('This field is required').show().css("color", "red");
            return false;

        }
        else {

            $("#hidFk_intDepartment").val('');
            $("#Fk_intDepartment").val('');
            $('#Fk_intDepartment').multipleSelect('refresh');
            $('#hidFk_intDepartment').val('');
            $("#errmsg25").html('');
            $("#ShowDepartment").hide();
            $("#ShowDepartmentlistView").hide();


        }
    }
}            
    