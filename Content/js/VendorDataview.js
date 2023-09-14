var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;


function error() {
    $('#hidstrRegistrationApplied').val($('#strRegistrationApplied').multipleSelect('getSelects'))
    $('#hidFk_intUnitId').val($('#Fk_intUnitId').multipleSelect('getSelects'))
    $('#hidFk_intDepartment').val($('#Fk_intDepartment').multipleSelect('getSelects'))
    



    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;


    var names = $('#strNameofFirmCompany').val();
    var email = $('#strEmail1').val();
    var telephone = $('#strPhone1').val();
    var names1 = $('#strCorrespondenceAddress').val();
    var names2 = $('#strstrRegisteredOfficeAddress').val();
    var email1 = $('#strEmail2').val();
    var telephone1 = $('#strPhone2').val();
    var names3 = $('#strNameContactPerson').val();
    var names4 = $('#strDesignationofContactPerson').val();
    var telephone2 = $('#strPhoneoffice').val();
    var mobile = $('#strMobile').val();
    var email2 = $('#strEmail').val();
    var fax1 = $('#strFax').val();
    var fax2 = $('#strFax1').val();
    var fax3 = $('#strFax2').val();
    var phoneResidence = $('#strPhoneResidence').val();
    var telephone3 = $('#strPhone3').val();
    var gstNo=$('#strGSTNo').val();

    //For unit
    if ($('#Fk_intUnitId').multipleSelect('getSelects') == '' || $('#Fk_intUnitId').multipleSelect('getSelects') == null) {
        $("#errmsg75").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    //Company Status
    if ($("#int_fk_CompanyStatusID").val() == "") {
        $("#errmsg105").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    //Year Of Establishment
    if ($("#strYearofEstablishment").val() == "") {
        $("#errmsgEstablishment").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    //RegistrationApplied
    if ($("#strRegistrationApplied").val() == null) {
        $("#errmsgregApplied").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    //TypeofIndustry&MSME
    if ($("#strTypeofIndustry").val() == "") {
        $("#errmsgTypeofins").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if ($("#strTypeofIndustry").val() == "OTHERS" && $("#txtlagescaleforOthers").val() == "") {
        $("#errmsgStatusofMSMEother").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if ($("#strTypeofIndustry").val() == "MSME") {
        if ($("#intfk_CasteID").val() == "") {
            $("#errmsgStatusofMSME").html('This field is required').show().css("color", "red");
            noerror = 0;
        }
        if ($("#strcategoryMSMED").val() == "") {
            $("#errmsgStatusofMSMECate").html('This field is required').show().css("color", "red");
            noerror = 0;
        }
        if ($("#strMSMEDocument").val() == "") {
            $("#errmsgStatusofMSMEDoc").html('This field is required').show().css("color", "red");
            noerror = 0;
            if ($("#strMSMEDocument1").html() == "View") {
                $("#errmsgStatusofMSMEDoc").html('');
                
                noerror = 0;
            }
        }

    }
    //Manpower
    if ($("#int_fk_CompanyStatusID").val() == "5") {
        if ($("#ifManpowerSupply").val() == "") {
            $("#errmsg106").html('required').show().css("color", "red");
            noerror = 0;
        }
        if ($("#ifManpowerSupply").val() == "Yes") {
            $("#errmsg106").html('');
            if ($('#Fk_intDepartment').multipleSelect('getSelects') == '' || $('#Fk_intDepartment').multipleSelect('getSelects') == null) {
                $("#errmsg107").html('This field is required').show().css("color", "red");               
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
    //GST
    if (gstNo == "") {
        $("#errmsg72").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (gstNo.toString().length < 15) {
        $("#errmsg72").html('GST NO. must be 15 digit').show().css("color", "red");
        noerror = 0;
    }
    if (ValidCaptchaRoni() == false) {
        $("#errmsgCap").html('Invalid Captcha').show().css("color", "red");
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
//Shoumya
$("#strNameofApplicant").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg73").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg73").html('');


    }
});

$("#strPlace").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg74").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg74").html('');


    }
});

$("#strGSTNo").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg72").html('This field is required').show().css("color", "red");
        return false;

    } else {
        Minimumcharaterlimit(this, 15, 'errmsg72', 'GST NO. must be 15 digit');

    }
}); 
$("#strNameofApplicant").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg73").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg73").html('');


    }
});

$("#strPlace").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg74").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg74").html('');


    }
});


$("#txtOtherConstitution").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsgFirmother").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsgFirmother").html('');


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

//If MSME, Please specify Registration No. and Validity

$("#strUANCertificateNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg22');
});
$("#strSSICertificateNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg23');
});
$("#strNSICCertificateNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg24');
});
$("#strAcknowledgementtoEntrepreneurCertificateNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg25');
});
$("#strAnyotherGovtBodyCertificateNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg26');
});


//Statutory Registration Details (Please attach self attested copy. All attachment file size will be (Max.): 10 MB and file extensions are : .pdf)

$("#strCSTRegistrationNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg27');
});
$("#strST_VATRegistrationNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg28');
});
$("#strExciseControlCode").on("input", function () {
    LimtCharacters(this, 30, 'errmsg29');
});
$("#strTradeLicenceNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg30');
});
$("#strServiceTaxRegistrationNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg31');
});
$("#strPANNo").on("input", function () {
    LimtCharacters(this, 30, 'errmsg32');
});

//Technical 

$("#strDescriptionofMachineEquipment1").on("input", function () {
    LimtCharacters(this, 100, 'errmsg33');
});
$("#strQuantity1").on("input", function () {
    LimtCharacters(this, 30, 'errmsg34');
});
$("#strSpecificationCapacity1").on("input", function () {
    LimtCharacters(this, 100, 'errmsg35');
});
$("#strDescriptionofMachineEquipment2").on("input", function () {
    LimtCharacters(this, 100, 'errmsg36');
});
$("#strQuantity2").on("input", function () {
    LimtCharacters(this, 30, 'errmsg37');
});
$("#strSpecificationCapacity2").on("input", function () {
    LimtCharacters(this, 100, 'errmsg38');
});
$("#strDescriptionofMachineEquipment3").on("input", function () {
    LimtCharacters(this, 100, 'errmsg39');
});
$("#strQuantity3").on("input", function () {
    LimtCharacters(this, 30, 'errmsg40');
});
$("#strSpecificationCapacity3").on("input", function () {
    LimtCharacters(this, 100, 'errmsg41');
});
$("#strDescriptionofMachineEquipment4").on("input", function () {
    LimtCharacters(this, 100, 'errmsg42');
});
$("#strQuantity4").on("input", function () {
    LimtCharacters(this, 30, 'errmsg43');
});
$("#strSpecificationCapacity4").on("input", function () {
    LimtCharacters(this, 100, 'errmsg44');
});
$("#strDescriptionofMachineEquipment5").on("input", function () {
    LimtCharacters(this, 100, 'errmsg45');
});
$("#strQuantity5").on("input", function () {
    LimtCharacters(this, 30, 'errmsg46');
});
$("#strSpecificationCapacity5").on("input", function () {
    LimtCharacters(this, 100, 'errmsg47');
});
$("#strISOSpe").on("input", function () {
    LimtCharacters(this, 100, 'errmsg48');
});

//Financial Position

$("#strTurnover1").on("input", function () {
    LimtCharacters(this, 50, 'errmsg49');
});
$("#strTurnover2").on("input", function () {
    LimtCharacters(this, 50, 'errmsg50');
});
$("#strTurnover3").on("input", function () {
    LimtCharacters(this, 50, 'errmsg51');
});
$("#strdesItemsSupplied1").on("input", function () {
    LimtCharacters(this, 100, 'errmsg52');
});
$("#strnameofmajorcustomer1").on("input", function () {
    LimtCharacters(this, 100, 'errmsg53');
});
$("#strContractualdelivery1").on("input", function () {
    LimtCharacters(this, 100, 'errmsg54');
});
$("#strActualdeliveryperiod1").on("input", function () {
    LimtCharacters(this, 100, 'errmsg55');
});

$("#strdesItemsSupplied2").on("input", function () {
    LimtCharacters(this, 100, 'errmsg56');
});
$("#strnameofmajorcustomer2").on("input", function () {
    LimtCharacters(this, 100, 'errmsg57');
});
$("#strContractualdelivery2").on("input", function () {
    LimtCharacters(this, 100, 'errmsg58');
});
$("#strActualdeliveryperiod2").on("input", function () {
    LimtCharacters(this, 100, 'errmsg59');
});

$("#strdesItemsSupplied3").on("input", function () {
    LimtCharacters(this, 100, 'errmsg60');
});
$("#strnameofmajorcustomer3").on("input", function () {
    LimtCharacters(this, 100, 'errmsg61');
});
$("#strContractualdelivery3").on("input", function () {
    LimtCharacters(this, 100, 'errmsg62');
});
$("#strActualdeliveryperiod3").on("input", function () {
    LimtCharacters(this, 100, 'errmsg63');
});

$("#strdesItemsSupplied4").on("input", function () {
    LimtCharacters(this, 100, 'errmsg64');
});
$("#strnameofmajorcustomer4").on("input", function () {
    LimtCharacters(this, 100, 'errmsg65');
});
$("#strContractualdelivery4").on("input", function () {
    LimtCharacters(this, 100, 'errmsg66');
});
$("#strActualdeliveryperiod4").on("input", function () {
    LimtCharacters(this, 100, 'errmsg67');
});

$("#strdesItemsSupplied5").on("input", function () {
    LimtCharacters(this, 100, 'errmsg68');
});
$("#strnameofmajorcustomer5").on("input", function () {
    LimtCharacters(this, 100, 'errmsg69');
});
$("#strContractualdelivery5").on("input", function () {
    LimtCharacters(this, 100, 'errmsg70');
});
$("#strActualdeliveryperiod5").on("input", function () {
    LimtCharacters(this, 100, 'errmsg71');
});
$("#strGSTNo").on("input", function () {
    LimtCharacters(this, 15, 'errmsg72');
});

$("#strNameofApplicant").on("input", function () {
    LimtCharacters(this, 100, 'errmsg73');
});
$("#strPlace").on("input", function () {
    LimtCharacters(this, 100, 'errmsg74');
});



function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
        return false;
    }
}
//File Extension
$('input[type="file"]').change(function (e) {
    var extension = $(this).val().replace(/^.*\./, '');

    if (extension.toLowerCase() == 'pdf') {
        var size = this.files[0].size / 1048576;
        if (parseFloat(size) <= 10) {
        }
        else {
            alert('Please check file Size');
            $(this).val('');
        }

    }
    else {
        alert('Please check file extension');
        $(this).val('');
    }


})

////Shoumya
numeric();
ISO();
typeofins();
firm();
//ShoumyaYearofEstablishment
$('#strYearofEstablishment').change(function () {
    if ($('#strYearofEstablishment').val() == "") {
        $("#errmsgEstablishment").html('This field is required').show().css("color", "red");

    }
    else {
        $("#errmsgEstablishment").html('');
    }
});
//RegistrationApplied
$('#strRegistrationApplied').change(function () {
    if ($('#strRegistrationApplied').multipleSelect('getSelects') == "") {
        $("#errmsgregApplied").html('This field is required').show().css("color", "red");

    }
    else {
        $("#errmsgregApplied").html('');
    }
});
//End
$("#fk_intConstitutionFirmID").change(function () {
    $("#strConstitutionofthefirmfile1").val('');
    $("#strConstitutionofthefirmfile2").val('');
    var end = this.value;
    var doc = $("#strConstitutionofthefirmview").html();
    var doc1 = $("#strConstitutionofthefirmview1").html();
    firm();
});

$("#strTypeofIndustry").change(function () {
    typeofins();
});

$("#strISOaccredited").change(function () {
    var end = this.value;
    var doc = $("#strISOaccrediteddocumentview").html();
    ISO();
});

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


function typeofins() {
    var end = $("#strTypeofIndustry").val();
    if (end == 'OTHERS') {
        $("#intfk_CasteID").hide();
        $("#txtlagescaleforOthers").show();
        $("#MSMEDAct").hide();
        $("#strcategoryMSMED").hide();
        $("#MSMEDocument").hide();
        $("#MSMEUpload").hide();
        $("#strMSMEDocument").hide();
        $("#hideDoc").hide();

        $("#strUANCertificateNo").attr('disabled', 'disabled');
        $("#strSSICertificateNo").attr('disabled', 'disabled');
        $("#strNSICCertificateNo").attr('disabled', 'disabled');
        $("#strAcknowledgementtoEntrepreneurCertificateNo").attr('disabled', 'disabled');
        $("#strAnyotherGovtBodyCertificateNo").attr('disabled', 'disabled');
        $("#strUANCertificateValidity").attr('disabled', 'disabled');
        $("#strSSICertificateValidity").attr('disabled', 'disabled');
        $("#strNSICCertificateValidity").attr('disabled', 'disabled');
        $("#strAcknowledgementtoEntrepreneurCertificateValidity").attr('disabled', 'disabled');
        $("#strAnyotherGovtBodyCertificateValidity").attr('disabled', 'disabled');
        $("#cast").html("");


    }
    else {
        $("#hideDoc").show();
        $("#strMSMEDocument").removeAttr('disabled', 'disabled');
        $("#strMSMEDocument").show();
        $("#intfk_CasteID").show();
        $("#txtlagescaleforOthers").hide();
        $("#MSMEDocument").show();
        $("#MSMEUpload").show();
        $("#cast").html('Status of MSME').append("<span style='color:Red'> (*)</span>");
        $("#MSMEDAct").show();
        $("#strcategoryMSMED").show();
        $("#strUANCertificateNo").removeAttr('disabled');
        $("#strSSICertificateNo").removeAttr('disabled');
        $("#strNSICCertificateNo").removeAttr('disabled');
        $("#strAcknowledgementtoEntrepreneurCertificateNo").removeAttr('disabled');
        $("#strAnyotherGovtBodyCertificateNo").removeAttr('disabled');
        $("#strUANCertificateValidity").removeAttr('disabled');
        $("#strSSICertificateValidity").removeAttr('disabled');
        $("#strNSICCertificateValidity").removeAttr('disabled');
        $("#strAcknowledgementtoEntrepreneurCertificateValidity").removeAttr('disabled');
        $("#strAnyotherGovtBodyCertificateValidity").removeAttr('disabled');
    }
}

function firm() {
    var end = $("#fk_intConstitutionFirmID").val();
    $("#errmsgFirmother").html('');
    if (end == '1') {
        $("#strConstitutionofthefirmfile1").removeAttr('disabled');
        $("#strConstitutionofthefirmfile2").removeAttr('disabled');
        $("#consFile1").html('Self Attested Copy of Memorandum of Articles of Association');
        $("#consFile2").html('Self Attested Copy Of Certificate Of Incorporation');
        $("#lblOtherConstitution").hide();
        $("#txtOtherConstitution").hide();

    }
    else if (end == '2') {
        $("#strConstitutionofthefirmfile1").removeAttr('disabled');
        $("#strConstitutionofthefirmfile2").attr('disabled', 'disabled');
        $("#consFile1").html('Self Attested copy of Partnership Deed');
        $("#consFile2").html('');
        $("#lblOtherConstitution").hide();
        $("#txtOtherConstitution").hide();


    }
    else if (end == '3') {
        $("#strConstitutionofthefirmfile1").removeAttr('disabled');
        $("#strConstitutionofthefirmfile2").attr('disabled', 'disabled');
        $("#consFile1").html('Self Attested Copy Of Registration Certificate/Proprietorship');
        $("#consFile2").html('');
        $("#lblOtherConstitution").hide();
        $("#txtOtherConstitution").hide();
    }
    else if (end == '4') {
        $("#strConstitutionofthefirmfile1").removeAttr('disabled');
        $("#strConstitutionofthefirmfile2").attr('disabled', 'disabled');
        $("#consFile1").html('Self Attested Copy Of Registration Certificate');
        $("#consFile2").html('');
        $("#lblOtherConstitution").hide();
        $("#txtOtherConstitution").hide();
    }
    else if (end == '5') {
        $("#consFile1").html('');
        $("#consFile2").html('');
        $("#strConstitutionofthefirmfile1").removeAttr('disabled');
        $("#strConstitutionofthefirmfile2").removeAttr('disabled');
        $("#lblOtherConstitution").show();
        $("#txtOtherConstitution").show();
    }

    else {
        $("#consFile1").html('');
        $("#consFile2").html('');
        $("#strConstitutionofthefirmfile1").attr('disabled', 'disabled');
        $("#strConstitutionofthefirmfile2").attr('disabled', 'disabled');
        $("#lblOtherConstitution").hide();
        $("#txtOtherConstitution").hide();
    }

}

function ISO() {
    var ISOaccredited = $("#strISOaccredited").val();
    var end = ISOaccredited;
    var doc = $("#strISOaccrediteddocumentview").html();
    if (end == "Yes") {
        $("#lblISOSpe").show();
        $("#txtISOSpe").show();
        $("#strISOaccrediteddocument1").show();
        if (doc == "View") {
        }
        else {
            $("#strISOaccrediteddocument1").attr("required", "true");
        }

        $("#txtISOSpe").attr("required", "true");
    }
    else {

        $("#errmsgISODoc").html('');
        $("#errmsg48").html('');
        $("#lblISOSpe").hide();
        $("#txtISOSpe").hide();
        $("#lblISOSpe1").hide();
        $("#strISOaccrediteddocument1").hide();
        $("#strISOaccrediteddocument1").removeAttr("required");
        $("#txtISOSpe").removeAttr("required");
    }
}


function numeric() {
    $("#txtlagescaleforOthers").hide();
    $("#consFile1").html('');
    $("#consFile2").html('');
    $("#strConstitutionofthefirmfile1").attr('disabled', 'disabled');
    $("#strConstitutionofthefirmfile2").attr('disabled', 'disabled');

    $("#strUANCertificateNo").attr('disabled', 'disabled');
    $("#strSSICertificateNo").attr('disabled', 'disabled');
    $("#strNSICCertificateNo").attr('disabled', 'disabled');
    $("#strAcknowledgementtoEntrepreneurCertificateNo").attr('disabled', 'disabled');
    $("#strAnyotherGovtBodyCertificateNo").attr('disabled', 'disabled');
    $("#strUANCertificateValidity").attr('disabled', 'disabled');
    $("#strSSICertificateValidity").attr('disabled', 'disabled');
    $("#strNSICCertificateValidity").attr('disabled', 'disabled');
    $("#strAcknowledgementtoEntrepreneurCertificateValidity").attr('disabled', 'disabled');
    $("#strAnyotherGovtBodyCertificateValidity").attr('disabled', 'disabled');

    $("#lblOtherConstitution").hide();
    $("#txtOtherConstitution").hide();

    $("#lblISOSpe").hide();
    $("#txtISOSpe").hide();
    $("#strISOaccrediteddocument1").hide();
    $("#lblISOSpe1").hide();


    $("#ShowManProvided").hide();
    $("#ifManpowerSupply").hide();
    $("#ShowDepartment").hide();
    $("#ShowDepartmentlistView").hide();

    $("#txtqun1").ForceNumericOnly();
    $("#txtqun2").ForceNumericOnly();
    $("#txtqun3").ForceNumericOnly();
    $("#txtqun4").ForceNumericOnly();
    $("#txtqun5").ForceNumericOnly();


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
        $("#errmsg107").html('This field is required').show().css("color", "red");

    }
    else {
        $("#errmsg107").html('');
    }
});



$('#Fk_intUnitId').change(function () {
    if ($('#Fk_intUnitId').multipleSelect('getSelects') == "") {
        $("#errmsg75").html('This field is required').show().css("color", "red");
    }
    else {
        $("#errmsg75").html('');
    }
});

$('#strRegistrationApplied').multipleSelect({
    isOpen: true,
    keepOpen: true,
    selectAll: true,
    minimumCountSelected: 1,
    single: false,
    maxHeight: 200
});
var RegistrationApplied = $("#hidstrRegistrationApplied").val();

if (RegistrationApplied != "") {
    var data = $("#hidstrRegistrationApplied").val();
    var dataarray = data.split(",");
    $("#strRegistrationApplied").val(dataarray);
    $("#strRegistrationApplied").multipleSelect("refresh");
}




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

    if (companyStatus == '5') {        
        $("#ShowManProvided").show();
        $("#ifManpowerSupply").show();
        if ($("#hidFk_intDepartment").val() == "") {
            $("#errmsg106").html('Required').show().css("color", "red");
        }
    }

    else {       
        $("#ShowManProvided").hide();
        $("#ifManpowerSupply").hide();
        $("#ShowDepartment").hide();
        $("#ShowDepartmentlistView").hide();
        $("#hidFk_intDepartment").val('');
        $("#errmsg105").html('');
        $("#errmsg106").html('');
        $("#errmsg107").html('');
        $("#ifManpowerSupply").val('');

    }
}


function manpower() {
    var companyStatus = $("#ifManpowerSupply").val();
    if (companyStatus != '') {
        $("#errmsg106").html('');
        if (companyStatus == 'Yes') {
            if ($("#hidFk_intDepartment").val() == "") {
                $("#errmsg107").html('This field is required').show().css("color", "red");
            }

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

        }
        else {

            $("#hidFk_intDepartment").val('');
            $("#Fk_intDepartment").val('');
            $('#Fk_intDepartment').multipleSelect('refresh');
            $('#hidFk_intDepartment').val('');
            $("#errmsg107").html('');
            $("#ShowDepartment").hide();
            $("#ShowDepartmentlistView").hide();


        }
    }

    else {
        $("#hidFk_intDepartment").val('');
        $("#Fk_intDepartment").val('');
        $('#Fk_intDepartment').multipleSelect('refresh');
        $('#hidFk_intDepartment').val('');
        $("#errmsg106").html('Required').show().css("color", "red");
        $("#ShowDepartment").hide();
        $("#ShowDepartmentlistView").hide();

    }

}

$('#strTypeofIndustry').change(function () {
    if ($('#strTypeofIndustry').val() == "") {
        $("#errmsgTypeofins").html('This field is required').show().css("color", "red");
        $("#errmsgStatusofMSME").html('');
        $("#errmsgStatusofMSMEother").html('');
        $("#errmsgStatusofMSMECate").html('');
        $("#errmsgStatusofMSMEDoc").html('');

    }
    else {
        $("#errmsgTypeofins").html('');
        $("#errmsgStatusofMSME").html('');
        $("#errmsgStatusofMSMEother").html('');
        $("#errmsgStatusofMSMECate").html('');
        $("#errmsgStatusofMSMEDoc").html('');
    }
});


///
$('#Fk_intUnitId,#Fk_intDepartment').multipleSelect({
    isOpen: true,
    keepOpen: true,
    selectAll: true,
    minimumCountSelected: 1,
    single: false,
    maxHeight: 150

});



var DepartmentId = $("#hidFk_intDepartment").val();
var companyStatus1stTime = $("#int_fk_CompanyStatusID").val();

if (DepartmentId != "" && companyStatus1stTime == '5') {
    var data = $("#hidFk_intDepartment").val();
    var dataarray = data.split(",");
    $("#Fk_intDepartment").val(dataarray);
    $("#Fk_intDepartment").multipleSelect("refresh");
    $("#ifManpowerSupply").val("Yes");
    $("#ifManpowerSupply").show();
    $("#ShowDepartmentlistView").show();
}
else if (DepartmentId == "" && companyStatus1stTime == '5') {
    $("#ifManpowerSupply").val("No");
    $("#ifManpowerSupply").show();
    $("#ShowDepartment").hide();
    $("#ShowDepartmentlistView").hide();
}

else {
    $("#ifManpowerSupply").hide();
    $("#ShowDepartmentlistView").hide();
}


var unitIds = $("#hidFk_intUnitId").val();

if (unitIds != "") {
    var data = $("#hidFk_intUnitId").val();
    var dataarray = data.split(",");
    $("#Fk_intUnitId").val(dataarray);
    $("#Fk_intUnitId").multipleSelect("refresh");
}



   