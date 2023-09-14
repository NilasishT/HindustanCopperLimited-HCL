


function error() {


    var noerror = 1;
    var fk_intUnitId = $('#fk_intUnitId').val();
    var strEnquiryNo = $('#strEnquiryNo').val();
    var strEnquiryTitle = $('#strEnquiryTitle').val();
    var strEnquiryTitleHindi = $('#strEnquiryTitleHindi').val();
    var dtEnquiryDate = $('#dtEnquiryDate').val();
    var dtActiveDate = $('#dtActiveDate').val();
    var dtClosingDate = $('#dtClosingDate').val();
    var strTenderType = $('#strTenderType').val();
    var strFile = $('#strFile').val();
    var strFilehindi = $('#strFilehindi').val();
    
    

    $('#hidstrVendorsId').val($('#strVendorsId').multipleSelect('getSelects'));

    var TenderType = $("#strTenderType").val();
    if (TenderType == 'STE' || TenderType == 'LTE') {

        if ($("#fk_intUnitId").val() == '') {
            alert('Please Select Unit');
            noerror = 0;
        }

        if ($('#strVendorsId').multipleSelect('getSelects') == '' || $('#strVendorsId').multipleSelect('getSelects') == null) {
            alert('Please Select Vendor');
            noerror = 0;
        }
    }

    if (strEnquiryNo == "") {       
        noerror = 0;
    }

    if (fk_intUnitId == "") {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    //    if (strEnquiryNo == "") {
    //        $("#errmsg2").html('This field is required').show().css("color", "red");
    //        noerror = 0;
    //    }

    if (strEnquiryTitle == "") {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (strEnquiryTitleHindi == "") {
        $("#errmsg30").html('This field is required').show().css("color", "red");
        noerror = 0;
    } 

    if (dtEnquiryDate == "") {
        $("#errmsg4").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (dtActiveDate == "") {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (dtClosingDate == "") {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (strTenderType == "") {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    if ($("#HidFile").val() == "") {
        $("#errmsg8").html('This field is required').show().css("color", "red");
        noerror = 0;
    }



    if ($("#HidFilehindi").val() == "") {
        $("#errmsg33").html('This field is required').show().css("color", "red");
        noerror = 0;
    }



    if (noerror == 1) {

        if (confirm("Are You Sure?")) {
            if ($('#AdminManageTender')[0].checkValidity()) {
                return true;
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

$("#fk_intUnitId").change(function () {
    //    alert("OK");
    if (this.value.length == 0) {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg1").html('');
    }
});

$("#strEnquiryTitle").keyup(function () {

    if (this.value.length == 0) {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        return false;
    }
    else {
        $("#errmsg3").html('');
    }
});

$("#strEnquiryTitleHindi").keyup(function () {

    if (this.value.length == 0) {
        $("#errmsg30").html('This field is required').show().css("color", "red");
        return false;
    }
    else {
        $("#errmsg30").html('');
    }
});

$("#strTenderType").change(function () {
    //    alert("OK");
    if (this.value.length == 0) {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg7").html('');
    }
});


$("#strFilechange").change(function () {


    var extension = $(this).val().replace(/^.*\./, '');

    if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpeg' || extension.toLowerCase() == 'doc' || extension.toLowerCase() == 'docx' || extension.toLowerCase() == 'xls' || extension.toLowerCase() == 'xlsx') {
        var size = this.files[0].size / 1048576;
        if (parseFloat(size) <= 4) {
            $("#HidFile").val(this.value);
            $("#errmsg8").html('');
        }
        else {
            alert('Only pdf,jpeg,doc,docx file is allowed.');
            $(this).val('');
        }

    }
    else {
        alert('Only pdf,jpeg,doc,docx file is allowed.');
        $(this).val('');
    }

    
});





$("#strFilechangehindi").change(function () {


    var extension = $(this).val().replace(/^.*\./, '');

    if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpeg' || extension.toLowerCase() == 'doc' || extension.toLowerCase() == 'docx' || extension.toLowerCase() == 'xls' || extension.toLowerCase() == 'xlsx') {
        var size = this.files[0].size / 1048576;
        if (parseFloat(size) <= 4) {
            $("#HidFilehindi").val(this.value);
            $("#errmsg33").html('');
        }
        else {
            alert('Only pdf,jpeg,doc,docx file is allowed.');
            $(this).val('');
        }

    }
    else {
        alert('Only pdf,jpeg,doc,docx file is allowed.');
        $(this).val('');
    }


});




function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}