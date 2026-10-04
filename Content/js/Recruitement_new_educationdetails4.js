/*date2 = "01-01-2025";*/


var date2 = "01-05-2026";
var d1 = new Date(date2.split("-").reverse().join("-"));

var dd1 = String(d1.getDate()).padStart(2, '0');
var mm1 = String(d1.getMonth() + 1).padStart(2, '0');
var yy1 = d1.getFullYear();

var newdate1 = yy1 + "-" + mm1 + "-" + dd1;

if ($('#Str_passingyear').val() != "") {
    $('#Str_passingyear1').attr('min', $('#Str_passingyear').val());
    $('#Str_passingyear2').attr('min', $('#Str_passingyear').val());
    $('#CertificateIssueDate0').attr('min', $('#Str_passingyear').val());
}
if ($('#Str_passingyear1').val() != "") {
    $('#Str_passingyear2').attr('min', "");
    $('#Str_passingyear2').attr('min', $('#Str_passingyear1').val());
}

//if ($('#Str_exampassed2').val().toLowerCase().includes("class 10th")) {
//    $('#Str_course2').val('').attr('readonly', true);
//    $('#Str_course2').removeAttr('required');
//    $('#Str_board2').val('').attr('readonly', true);
//    $('#Str_board2').removeAttr('required');
//    $('#Str_passingdetails2').val('').attr('readonly', true);
//    $('#Str_passingdetails2').removeAttr('required');

//    $('#str_UploadCertificate2').val('').attr('readonly', true);
//    $('#str_UploadCertificate2').removeAttr('required');
    


//    $('#Str_passingyear2').val('').attr('readonly', true);
//    $('#Str_passingyear2').removeAttr('required');
//    $('#Str_duration2').val('').attr('readonly', true);
//    $('#Str_duration2').removeAttr('required');
//    $('#Str_Marks2').val('').attr('readonly', true);
//    $('#Str_Marks2').removeAttr('required');
//     $('#Str_division2').val('').attr('readonly', true);
   
//    $('#Str_division2').removeAttr('required');
//    $('#Str_division2').attr('class', 'notrequired')
//    $('#Str_division2').attr('notrequired');
//}


var dtCurrentDate = newdate1;
//$("#Certificate").hide();

//if ($("#IsCertificateRequired").val() == "True") {
//    // alert($("#CertificateNo0").val());
//    //$("#Certificate").show();

//    $("#Certificate").show();
//    if ($("#CertificateCount").val() == 0) {
//        var arr = [$("#CertificateDetails1").val()]
//        //if ($("#CertificateDetails2").val() != '') {
//        //    arr.push($("#CertificateDetails2").val());
//        //}
//        var jj = '';
//        for (var i = 0; i < arr.length; i++) {
//            jj += '<tr>';
//            jj += '    <td> <input value="' + arr[i] + '" readonly class="form-control" id="CertificateName' + i + '" name="CertificateName' + i + '"  type="text" autocomplete="off" required> </td>';
//            jj += '    <td> <input class="form-control" id="CertificateNo' + i + '" name="CertificateNo' + i + '" type="text" value="" autocomplete="off" required > </td>';
//            jj += '    <td> <input class="form-control input-append date"  id="CertificateIssueDate' + i + '" name="CertificateIssueDate' + i + '" placeholder="dd-mm-yyyy" type="text" value="" autocomplete="off" required > </td>';
//            jj += '    <td style="display:none"> <input style="display:none" class="form-control input-append date" id="CertificateExpiryDate' + i + '" name="CertificateExpiryDate' + i + '" placeholder="dd-mm-yyyy" type="text" value="" autocomplete="off" > </td>';
//            //jj += '   <input type="file" name="str_Certificate_New" id="str_Certificate_New"  accept="application/pdf" />'
//            jj += '</tr>';
//        }
//        $("#cer").show();
//        $("#tbodyCertificate").append(jj);
//        $('.date').datepicker({
//            format: 'dd-mm-yyyy'
//        }).datepicker().on('changeDate', function (ev) {
//            $(this).next("span").remove();

//        });
//    }
//}
//else {
//    console.log($("#IsCertificateRequired").val());
//    $("#Certificate").hide();
//}

$('#Str_passingyear,#Str_passingyear1,#Str_passingyear2,#Str_passingyear3,#Str_passingyear4,#CertificateIssueDate0').attr('max', dtCurrentDate);
//debugger;



$("#selectValue").val($('input[type=checkbox][name="str_qualification"]').val());
//$('#Str_exampassed1').val($('input[type=checkbox][name="str_qualification"]').val());
$('.essentialquali').val($('input[type=checkbox][name="str_qualification"]').val());
if ($('.clsGATEDoc').text() != '-') {
    $('input[type=file][name="str_GATEResult"]').attr('required', false);
}

if ($("#chk_IsPersuing").prop("checked") == true) {
    $('#Str_passingyear2').val('').attr('readonly', true);
    $('#Str_passingyear2').removeAttr('required');
    $('#Str_duration2').val('').attr('readonly', true);
    $('#Str_duration2').removeAttr('required');
    $('#Str_Marks2').val('').attr('readonly', true);
    $('#Str_Marks2').removeAttr('required');
    $('#Str_division2').val('Pursuing').attr('readonly', true);
    $('#Str_division2').removeAttr('required');
}


$('input[type="checkbox"][name="chk_IsPersuing"]').on('change', function () {
    if ($(this).is(':checked')) {
        $('#Str_passingyear2').val('').attr('readonly', true);
        $('#Str_passingyear2').removeAttr('required');
        $('#Str_duration2').val('').attr('readonly', true);
        $('#Str_duration2').removeAttr('required');
        $('#Str_Marks2').val('').attr('readonly', true);
        $('#Str_Marks2').removeAttr('required');
        $('#Str_division2').val('Pursuing').attr('readonly', true);
        /*$('#Str_division2').removeAttr('required');*/
    }
    else {
        $('#Str_passingyear2').attr('readonly', false);
        $('#Str_passingyear2').attr('required', true);
        $('#Str_duration2').attr('readonly', false);
        $('#Str_duration2').attr('required', true);
        $('#Str_Marks2').attr('readonly', false);
        $('#Str_Marks2').attr('required', true);
        $('#Str_division2').val('').attr('readonly', false);
       /* $('#Str_division2').attr('required', true);*/
    }
});
$('input[type="checkbox"][name="str_qualification"]').on('change', function () {
    $('input[type="checkbox"]').not(this).prop('checked', false);

    $('#Str_course3').attr('readonly', false);
    $('#Str_board3').attr('readonly', false);
    $('#Str_passingdetails3').attr('readonly', false);
    $('#Str_passingyear3').attr('readonly', false);
    $('#Str_duration3').attr('readonly', false);
    $('#Str_Marks3').attr('readonly', false);
    $('#Str_division3').attr('readonly', false);

    $('#Str_course4').attr('readonly', false);
    $('#Str_board4').attr('readonly', false);
    $('#Str_passingdetails4').attr('readonly', false);
    $('#Str_passingyear4').attr('readonly', false);
    $('#Str_duration4').attr('readonly', false);
    $('#Str_Marks4').attr('readonly', false);
    $('#Str_division4').attr('readonly', false);

    $('#tbllistofplantMachinery').find("input").not("[type='checkbox'],#Str_exampassed,#Str_exampassed1").val('');
    $("#qulificationDetailsHead").next("span").remove();
    $("input").each(function () {
        $(this).next("span").remove();
    });

    //debugger;
    if ($(this).prop("checked") == true) {

        var ALlQuValue = this.value.toString().split('WITH');
        $("#selectValue").val(this.value);
        $("#EduQulifi").val(this.value);

        if (this.value.toString().split('WITH').length == 1) {
            //$('#Str_exampassed2').val(ALlQuValue[0]);
            $('#Str_exampassed' + ($('#tbllistofplantMachinery tbody tr').length - 1)).val($('input[type=checkbox][name="str_qualification"]').val());

            //$('#Str_course3').attr('readonly', true);
            //$('#Str_board3').attr('readonly', true);
            //$('#Str_passingdetails3').attr('readonly', true);
            //$('#Str_passingyear3').attr('readonly', true);
            //$('#Str_duration3').attr('readonly', true);
            //$('#Str_Marks3').attr('readonly', true);
            //$('#Str_division3').attr('readonly', true);

            //$('#Str_course4').attr('readonly', true);
            //$('#Str_board4').attr('readonly', true);
            //$('#Str_passingdetails4').attr('readonly', true);
            //$('#Str_passingyear4').attr('readonly', true);
            //$('#Str_duration4').attr('readonly', true);
            //$('#Str_Marks4').attr('readonly', true);
            //$('#Str_division4').attr('readonly', true);


        }

        else if (this.value.toString().split('WITH').length == 2) {
            //$('#Str_exampassed2').val(ALlQuValue[0]);
            //$('#Str_exampassed3').val(ALlQuValue[1]);
            $('#Str_course4').attr('readonly', true);
            $('#Str_board4').attr('readonly', true);
            $('#Str_passingdetails4').attr('readonly', true);
            $('#Str_passingyear4').attr('readonly', true);
            $('#Str_duration4').attr('readonly', true);
            $('#Str_Marks4').attr('readonly', true);
            $('#Str_division4').attr('readonly', true);
        }

        else if (this.value.toString().split('WITH').length == 3) {
            //$('#Str_exampassed2').val(ALlQuValue[0]);
            //$('#Str_exampassed3').val(ALlQuValue[1]);
            //$('#Str_exampassed4').val(ALlQuValue[2]);
        }
    }

});

$(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57) && (parseInt(event.which) > 100)) {
        event.preventDefault();
    }
});
$(document).on('change', '#Str_exampassed' + ($('#tbllistofplantMachinery tbody tr').length - 1), function (e) {
    $('#Str_exampassed' + ($('#tbllistofplantMachinery tbody tr').length - 1)).val($('input[type=checkbox][name="str_qualification"]').val());
    $('#Str_course' + ($('#tbllistofplantMachinery tbody tr').length - 1)).focus();
})
$(document).on('keydown', '#Str_division1', function (e) {
    var keyCode = e.keyCode || e.which;

    if (keyCode == 9) {
        e.preventDefault();
        // call custom function here
        //setTimeout(function () {
        //$("#selectValue").val($('input[type=checkbox][name="str_qualification"]').val());
        //$('#Str_exampassed2').val($('input[type=checkbox][name="str_qualification"]').val());
        //$('#Str_exampassed2').focus();
        //}, 100);
        return false;
    }
});

function stringToDate(_date, _format, _delimiter) {
    if (_date != null && _date != 'undefiend') {

        var from = _date.split("-");
        if (from[0].length == 4) {
            return new Date(_date);
        }
        else {
            return new Date([from[2], from[1], from[0]].join('-'));
        }
    }
}

function Convertyyyymmdd(_date) {
    if (_date != null && _date != 'undefiend') {

        var from = _date.split("-")
        return from[2] + "-" + from[1] + "-" + from[0];
    }
}

//$("#CertificateIssueDate0").change(function () {

//    var aa = Convertyyyymmdd(this.value);
//    if (stringToDate(aa, "dd/MM/yyyy", "/") <= stringToDate($("#Str_passingyear").val(), "dd/MM/yyyy", "/")) {
//        alert('Date can not be less then/equal ' + $("#Str_passingyear").val())
//        this.value = "";
//        $(this).attr('min', $("#Str_passingyear").val());
//    }
//});
$("#CertificateIssueDate0").change(function () {

    var aa = Convertyyyymmdd(this.value);
    var certDate = stringToDate(aa, "dd/MM/yyyy", "/");

    // sabhi passing year fields check karo
    var passingIds = [
        "#Str_passingyear",
        "#Str_passingyear1",
        "#Str_passingyear2",
        "#Str_passingyear3",
        "#Str_passingyear4"
    ];

    var maxDate = null;

    for (var i = 0; i < passingIds.length; i++) {
        var val = $(passingIds[i]).val();
        if (val) {
            var d = stringToDate(val, "dd/MM/yyyy", "/");
            if (maxDate === null || d > maxDate) {
                maxDate = d;
            }
        }
    }

    if (maxDate && certDate <= maxDate) {
        var formattedDate = formatDate(maxDate); // dd/MM/yyyy banaya
        alert('Date can not be less than or equal ' + formattedDate);
        this.value = "";
        $(this).attr('min', formattedDate.split("/").reverse().join("-")); // yyyy-MM-dd format for input[type=date]
    }
});

// helper function dd/MM/yyyy format me date return kare
function formatDate(date) {
    var dd = String(date.getDate()).padStart(2, '0');
    var mm = String(date.getMonth() + 1).padStart(2, '0');
    var yyyy = date.getFullYear();
    return dd + '/' + mm + '/' + yyyy;
}





$("#Str_passingyear,#Str_passingyear1,#Str_passingyear2,#Str_passingyear3,#Str_passingyear4").change(function () {
    //debugger;
    if (this.id == "Str_passingyear") {
        $('#Str_passingyear1').attr('min', this.value);
        $('#Str_passingyear1').val('');
        $('#Str_passingyear2').attr('min', this.value);
        $('#Str_passingyear2').val('');
    }
    else if (this.id == "Str_passingyear1") {

        if (stringToDate(this.value, "dd/MM/yyyy", "/") <= stringToDate($("#Str_passingyear").val(), "dd/MM/yyyy", "/")) {
            alert('Date can not be less then/equal ' + $("#Str_passingyear").val())
            this.value = "";
            this.attr('min', $("#Str_passingyear").val());
        }
        $('#Str_passingyear2').attr('min', this.value);
        $('#Str_passingyear2').val('');
    }
    else if (this.id == "Str_passingyear2") {

        if ($("#Str_passingyear1").val() != "" && this.value != "") {
            if (stringToDate(this.value, "dd/MM/yyyy", "/") <= stringToDate($("#Str_passingyear1").val(), "dd/MM/yyyy", "/")) {
                alert('Date can not be less then/equal ' + $("#Str_passingyear1").val())
                this.value = "";
                this.attr('min', $("#Str_passingyear1").val());
            }
        }
        if ($("#Str_passingyear").val() != "" && this.value != "") {
            if (stringToDate(this.value, "dd/MM/yyyy", "/") <= stringToDate($("#Str_passingyear").val(), "dd/MM/yyyy", "/")) {
                alert('Date can not be less then/equal ' + $("#Str_passingyear").val())
                this.value = "";
                this.attr('min', $("#Str_passingyear").val());
            }
        }
        if ($("#Str_passingyear").val() != "" && $("#Str_passingyear1").val() != "" && this.value != "") {
            if (stringToDate(this.value, "dd/MM/yyyy", "/") <= stringToDate($("#Str_passingyear").val(), "dd/MM/yyyy", "/")) {
                alert('Date can not be less then/equal ' + $("#Str_passingyear").val())
                this.value = "";
                this.attr('min', $("#Str_passingyear").val());
            }
            if (stringToDate(this.value, "dd/MM/yyyy", "/") <= stringToDate($("#Str_passingyear1").val(), "dd/MM/yyyy", "/")) {
                alert('Date can not be less then/equal ' + $("#Str_passingyear1").val())
                this.value = "";
                this.attr('min', $("#Str_passingyear1").val());
            }
        }
        // $('#Str_passingyear2').attr('min', this.value);
    }


    // add for date compare error -- Gaurav
    //var maxExpDateStr = $("#hidMaxExpdate").val().split(" ")[0]; // sirf date le lo
    //if (stringToDate(this.value, "dd/MM/yyyy", "/") > stringToDate(maxExpDateStr, "dd/MM/yyyy", "/")) {
    //    alert('Max exp. date is ' + maxExpDateStr);
    //    this.value = "";
    //}


    if (stringToDate(this.value, "dd/MM/yyyy", "/") > stringToDate($("#hidMaxExpdate").val(), "dd/MM/yyyy", "/")) {
        alert('Max exp. date is ' + $("#hidMaxExpdate").val())
        this.value = "";
    }
});

$("#Str_Marks,#Str_Marks1,#Str_Marks2,#Str_Marks3,#Str_Marks4").change(function () {
    if (parseInt(this.value) > 100) {
        alert('% Marks upto 100');
        this.value = "";
    }
});
// if ($('#str_GateMarks1').val() == '' || $('#str_GateRegistrationNo1').val() == '' || ($('#str_GateExaminationPaper1').val() == '')) {
    // alert('this field is required!!');
// }

$('#str_GateMarks1').change(function () {

    if (parseInt(this.value) > 100) {
        alert('Marks Should be Less than or Equal to 100');
        this.value = "";
    }
});


if ($("#selectValue").val() != null && $("#selectValue").val() != "") {
    $("#EduQulifi").val($("#selectValue").val());
    var ALlQuValue = $("#selectValue").val().toString().split('WITH');

    $('#Str_course3').attr('readonly', false);
    $('#Str_board3').attr('readonly', false);
    $('#Str_passingdetails3').attr('readonly', false);
    $('#Str_passingyear3').attr('readonly', false);
    $('#Str_duration3').attr('readonly', false);
    $('#Str_Marks3').attr('readonly', false);
    $('#Str_division3').attr('readonly', false);

    $('#Str_course4').attr('readonly', false);
    $('#Str_board4').attr('readonly', false);
    $('#Str_passingdetails4').attr('readonly', false);
    $('#Str_passingyear4').attr('readonly', false);
    $('#Str_duration4').attr('readonly', false);
    $('#Str_Marks4').attr('readonly', false);
    $('#Str_division4').attr('readonly', false);
    //$('#tbllistofplantMachinery tbody tr').length-1 

    if ($("#selectValue").val().toString().split('WITH').length == 1) {
        $('#Str_exampassed' + ($('#tbllistofplantMachinery tbody tr').length - 1)).val(ALlQuValue[0]);

        //$('#Str_course3').attr('readonly', true);
        //$('#Str_board3').attr('readonly', true);
        //$('#Str_passingdetails3').attr('readonly', true);
        //$('#Str_passingyear3').attr('readonly', true);
        //$('#Str_duration3').attr('readonly', true);
        //$('#Str_Marks3').attr('readonly', true);
        //$('#Str_division3').attr('readonly', true);

        //$('#Str_course4').attr('readonly', true);
        //$('#Str_board4').attr('readonly', true);
        //$('#Str_passingdetails4').attr('readonly', true);
        //$('#Str_passingyear4').attr('readonly', true);
        //$('#Str_duration4').attr('readonly', true);
        //$('#Str_Marks4').attr('readonly', true);
        //$('#Str_division4').attr('readonly', true);


    }
    else if ($("#selectValue").val().toString().split('WITH').length == 2) {
        $('#Str_exampassed' + ($('#tbllistofplantMachinery tbody tr').length - 1)).val(ALlQuValue[0]);
        //$('#Str_exampassed3').val(ALlQuValue[1]);
        //$('#Str_course4').attr('readonly', true);
        //$('#Str_board4').attr('readonly', true);
        //$('#Str_passingdetails4').attr('readonly', true);
        //$('#Str_passingyear4').attr('readonly', true);
        //$('#Str_duration4').attr('readonly', true);
        //$('#Str_Marks4').attr('readonly', true);
        //$('#Str_division4').attr('readonly', true);
    }

    else if ($("#selectValue").val().toString().split('WITH').length == 3) {
        $('#Str_exampassed' + ($('#tbllistofplantMachinery tbody tr').length - 1)).val(ALlQuValue[0]);
        //$('#Str_exampassed3').val(ALlQuValue[1]);
        //$('#Str_exampassed4').val(ALlQuValue[2]);
    }

}

$("input:not([readonly],[type=hidden])").keyup(function () {
    var element = $(this);
    if (element.val() != "") {
        $(this).next("span").remove();
    }
});


function error() {
    var isValid = true;

    $("#qulificationDetailsHead").next("span").remove();
    $("input").each(function () {
        $(this).next("span").remove();
    });
    
    $('#tbllistofplantMachinery').find("input:not([readonly],[type=hidden])").each(function () {
        var element = $(this);
        if (!$(this).hasClass('notrequired') && element.val() == "" ) {
            isValid = false;
            $(this).next("span").remove();
            $(this).after("<span style='color:Red'> This field is required</span>");
        }
    });

    //$('#tbllistofplantMachinery1').find("input:not([type=file],[type=hidden])").each(function () {
    //    var element = $(this);
    //    if (!$(this).hasClass('notrequired') && element.val() == "") {
    //        isValid = false;
    //        $(this).next("span").remove();
    //        $(this).after("<span style='color:Red'> This field is required</span>");
    //    }
    //});



    if ($('#str_GateRegistrationNo1')[0] != undefined) {
        var isTrue = false;
        $('#str_GateRegistrationNo1').closest('tbody').find('tr').each(function (i, v) {
            if (!isTrue) {
                var arr = true;
                $(v).find('input').each(function (ii, vv) {
                    if (arr == true) {
                        arr = $.trim($(vv).val()) != '';
                    }
                });
                $(v).find('select').each(function (ii, vv) {
                    if (arr == true) {
                        arr = $.trim($(vv).val()) != '';
                    }
                });
                if (arr) {
                    isTrue = arr;
                }
            }
        });
        if (!isTrue) {

        }
    }


    var noerror = 1;
    if ($("#selectValue").val() == "") {
        $("#qulificationDetailsHead").next("span").remove();
        $("#qulificationDetailsHead").after("<span style='color:Red; font-weight:bold'> Please check one.</span>");
        noerror = 0;
    }

    if (isValid == false) {
        noerror = 0;

    }

    if (noerror == 1) {
        // if ($('#str_GateRegistrationNo1')[0] != undefined) {
            // if ($('#str_GateExaminationPaper1').val() == '' || $('#str_GateMarks1').val() == '' || $('#str_GateExaminationPaper1').val() == '' || (($('input[type=file][name="str_GATEResult"]').val() == '') && $('.clsGATEDoc').text() == '')) {
                // return false;
            // }

        // }
		
		if ($('#str_GateRegistrationNo1')[0] != undefined) {
    var isValid = true;

    if ($('#str_GateRegistrationNo1').val() == '' || $('#str_GateRegistrationNo1').val() == null) {
        $('#str_GateRegistrationNo1').next('span').remove();
        $('#str_GateRegistrationNo1').after("<span style='color:Red'> This field is required</span>");
        isValid = false;
    }

    if ($('#str_GateExaminationPaper1').val() == '') {
        $('#str_GateExaminationPaper1').next('span').remove();
        $('#str_GateExaminationPaper1').after("<span style='color:Red'> This field is required</span>");
        isValid = false;
    }

    if ($('#str_GateMarks1').val() == '') {
        $('#str_GateMarks1').next('span').remove();
        $('#str_GateMarks1').after("<span style='color:Red'> This field is required</span>");
        isValid = false;
    }

    if (
        $('input[type=file][name="str_GATEResult"]').val() == '' &&
        $('.clsGATEDoc').text() == '-'
    ) {
        $('input[type=file][name="str_GATEResult"]').next('span').remove();
        $('input[type=file][name="str_GATEResult"]').after("<span style='color:Red'> This field is required</span>");
        isValid = false;
    }

    if (!isValid) {
        return false;
    }
}


        $('#tbllistofplantMachinery').find("input:not([readonly],[type=hidden])").each(function () {
            var element = $(this);
            if (!$(this).hasClass('notrequired') && element.val() == "") {
                isValid = false;
                $(this).next("span").remove();
                $(this).after("<span style='color:Red'> This field is required</span>");
            }
        });
        
        
        // Certificate for essential qualification row (row 0)
        if ($('input[type=file][name="str_UploadCertificate"]').length &&
            $('input[type=file][name="str_UploadCertificate"]').val() == '' &&
            ($('.clsEduDoc').text() == '' || $('.clsEduDoc').text() == '-')) {
            $('input[type=file][name="str_UploadCertificate"]').next("span.fileError").remove();
            $('input[type=file][name="str_UploadCertificate"]').after("<span class='fileError' style='color:Red'> This field is required</span>");
            alert('Please upload the Certificate/Marksheet document.');
            $('html, body').animate({ scrollTop: $('input[type=file][name="str_UploadCertificate"]').offset().top - 150 }, 300);
            return false;
        }

        // Certificate for Graduate/PG row (row 2) — required unless qualification is Class 10th
        var exampassed2Val = ($('#Str_exampassed2').val() || '').toLowerCase();
        if ($('input[type=file][name="str_UploadCertificate2"]').length &&
            !exampassed2Val.includes("class 10th") &&
            $('input[type=file][name="str_UploadCertificate2"]').val() == '' &&
            ($('.clsEduDoc2').text() == '' || $('.clsEduDoc2').text() == '-')) {
            $('input[type=file][name="str_UploadCertificate2"]').next("span.fileError").remove();
            $('input[type=file][name="str_UploadCertificate2"]').after("<span class='fileError' style='color:Red'> This field is required</span>");
            alert('Please upload the Certificate/Marksheet document.');
            $('html, body').animate({ scrollTop: $('input[type=file][name="str_UploadCertificate2"]').offset().top - 150 }, 300);
            return false;
        }

        // New Certificate upload — only when THIS post actually requires it
        if ($('#IsCertificateRequired').val() === 'True' &&
            $('input[type=file][name="str_Certificate_New"]').val() == '' &&
            ($('.clsCerDoc').text() == '' || $('.clsCerDoc').text() == '-')) {
            isValid = false;
            $('input[type=file][name="str_Certificate_New"]').next("span.fileError").remove();
            $('input[type=file][name="str_Certificate_New"]').after("<span class='fileError' style='color:Red'> This field is required</span>");
        }

        // Row 1 (Higher Secondary/12th) — optional row, but if any field is filled, upload becomes required
        var row1Filled = ['#Str_course1', '#Str_board1', '#Str_passingdetails1', '#Str_passingyear1', '#Str_duration1', '#Str_Marks1'].some(function (sel) {
            return $(sel).length && $.trim($(sel).val()) !== '';
        });
        if (row1Filled &&
            $('input[type=file][name="str_UploadCertificate1"]').length &&
            $('input[type=file][name="str_UploadCertificate1"]').val() == '' &&
            ($('.clsEduDoc1').text() == '' || $('.clsEduDoc1').text() == '-')) {
            isValid = false;
            $('input[type=file][name="str_UploadCertificate1"]').next("span.fileError").remove();
            $('input[type=file][name="str_UploadCertificate1"]').after("<span class='fileError' style='color:Red'> This field is required</span>");
        }

        // Other Qualification rows (add_1 to add_4) — if any field in a row is filled, upload becomes required
        for (var addRow = 1; addRow <= 4; addRow++) {
            (function (i) {
                var rowFields = ['#Str_exampassed_add_' + i, '#Str_course_add_' + i, '#Str_board_add_' + i, '#Str_passingdetails_add_' + i, '#Str_passingyear_add_' + i, '#Str_duration_add_' + i, '#Str_Marks_add_' + i, '#Str_division_add_' + i];
                var rowFilled = rowFields.some(function (sel) {
                    return $(sel).length && $.trim($(sel).val()) !== '';
                });
                var fileInput = $('input[type=file][name="str_UploadOtherCertificate_' + i + '"]');
                var docLink = $('.clsEduDoc_' + i);
                if (rowFilled && fileInput.length && fileInput.val() == '' && (docLink.text() == '' || docLink.text() == '-')) {
                    isValid = false;
                    fileInput.next("span.fileError").remove();
                    fileInput.after("<span class='fileError' style='color:Red'> This field is required</span>");
                }
            })(addRow);
        }

        if ($('#str_GateRegistrationNo1')[0] != undefined) {
        




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
/*$('input[type=checkbox][name="str_qualification"]').prop('checked', true).trigger('change');*/
/*Akshat code for disable tab*/
$(document).keydown(function (objEvent) {
    if (objEvent.keyCode == 9) {  //tab pressed
        objEvent.preventDefault(); // stops its action
    }
})

$("#str_GATEResult").on("change", function () {
    //debugger;
    /* current this object refer to input element */
    var $input = $(this);

    /* collect list of files choosen */
    var files = $input[0].files;

    var filename = files[0].name;

    /* getting file extenstion eg- .jpg,.png, etc */
    var extension = filename.substr(filename.lastIndexOf("."));

    /* define allowed file types */
    var allowedExtensionsRegx = /(\.pdf|\.PDF)$/i;

    /* testing extension with regular expression */
    var isAllowed = allowedExtensionsRegx.test(extension);
    //var file_size = $('#file-upload')[0].files[0].size;
    var file_size = $('#str_GATEResult')[0].files[0].size;
    // if (file_size > 2097152) {
    if (file_size > 1048576 || file_size < 20480) {
        //$("#file_error").html("File size is greater than 2MB");
        //$(".demoInputBox").css("border-color", "#FF0000");
        // alert("File size is greater than 1MB & ");
        alert("File size must be between 20 Kb to 1 Mb");
        $(this).val("");
        isValid = false;
        //$('#str_GATEResult').next("span").remove();
        //$('#str_GATEResult').after("<span style='color:Red'> This field is required</span>");
        return false;
    } else {
        $('#str_GATEResult').next("span").remove();
    }
    if (isAllowed) {
        // alert("File type is valid for the upload");      
        /* file upload logic goes here... */
    } else {
        alert("Invalid File Type.");
        $(this).val("");
        return false;
    }
});








$("input[type=file][name^='str_UploadCertificate']").on("change", function () {
    var $input = $(this);           
    var files = $input[0].files;

    if (files.length === 0) return;

    var filename = files[0].name;
    var extension = filename.substr(filename.lastIndexOf("."));
    var allowedExtensionsRegx = /(\.pdf|\.PDF)$/i;
    var isAllowed = allowedExtensionsRegx.test(extension);
    var file_size = files[0].size;

    $input.next("span.fileError").remove();   

    if (file_size > 2097152 || file_size < 20480) {
        alert("File size must be between 20 Kb to 2 Mb");
        $input.val("");               // clears THIS column only
        $input.after("<span class='fileError' style='color:Red'> Invalid file size</span>");
        return false;
    }

    if (!isAllowed) {
        alert("Certificate Document: only PDF format allowed.");
        $input.val("");               // clears THIS column only
        $input.after("<span class='fileError' style='color:Red'> Only PDF allowed</span>");
        return false;
    }
});



$("input[type=file][name^='str_UploadOtherCertificate']").on("change", function () {
    var $input = $(this);           // ← only THIS input, not others
    var files = $input[0].files;

    if (files.length === 0) return;

    var filename = files[0].name;
    var extension = filename.substr(filename.lastIndexOf("."));
    var allowedExtensionsRegx = /(\.pdf|\.PDF)$/i;
    var isAllowed = allowedExtensionsRegx.test(extension);
    var file_size = files[0].size;

    $input.next("span.fileError").remove();   // remove error for THIS input only

    if (file_size > 2097152 || file_size < 20480) {
        alert("File size must be between 20 Kb to 2 Mb");
        $input.val("");               // clears THIS column only
        $input.after("<span class='fileError' style='color:Red'> Invalid file size</span>");
        return false;
    }

    if (!isAllowed) {
        alert("Certificate Document: only PDF format allowed.");
        $input.val("");               // clears THIS column only
        $input.after("<span class='fileError' style='color:Red'> Only PDF allowed</span>");
        return false;
    }
});





//$("input[type=file]").on("change", function () {
//    //debugger;
//    /* current this object refer to input element */
//    var $input = $(this);

//    /* collect list of files choosen */
//    var files = $input[0].files;

//    var filename = files[0].name;

//    /* getting file extenstion eg- .jpg,.png, etc */
//    var extension = filename.substr(filename.lastIndexOf("."));

//    /* define allowed file types */
//    var allowedExtensionsRegx = /(\.pdf|\.PDF)$/i;

//    /* testing extension with regular expression */
//    var isAllowed = allowedExtensionsRegx.test(extension);
//    //var file_size = $('#file-upload')[0].files[0].size;
//    var file_size = $(this)[0].files[0].size;
//    // if (file_size > 2097152) {
//    if (file_size > 1048576 || file_size < 20480) {
//        //$("#file_error").html("File size is greater than 2MB");
//        //$(".demoInputBox").css("border-color", "#FF0000");
//        // alert("File size is greater than 1MB & ");
//        alert("File size must be between 20 Kb to 1 Mb");
//        $(this).val("");
//        isValid = false;
//        $(this).next("span").remove();
//        $(this).after("<span style='color:Red'> This field is required</span>");
//        return false;
//    } else {
//        $(this).next("span").remove();
//    }
//    if (isAllowed) {
//        // alert("File type is valid for the upload");      
//        /* file upload logic goes here... */
//    } else {
//        alert("Invalid File Type.");
//        $(this).val("");
//        return false;
//    }
//});