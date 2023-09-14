date2 = "01-09-2023";
var d1 = new Date(date2.split("-").reverse().join("-"));
var dd1 = d1.getDate();
var mm1 = d1.getMonth() + 1;
var yy1 = d1.getFullYear();
var newdate1 = yy1 + "-" + mm1 + "-" + 0 + dd1;

var dtCurrentDate = newdate1;

$('#Str_passingyear,#Str_passingyear1,#Str_passingyear2,#Str_passingyear3,#Str_passingyear4').attr('max',dtCurrentDate);




$("#selectValue").val($('input[type=checkbox][name="str_qualification"]').val());
//$('#Str_exampassed1').val($('input[type=checkbox][name="str_qualification"]').val());
$('.essentialquali').val($('input[type=checkbox][name="str_qualification"]').val());
if ($('.clsGATEDoc').text() != '-') {
    $('input[type=file][name="str_GATEResult"]').attr('required', false);
}
$('input[type="checkbox"][name="chk_IsPersuing"]').on('change', function () {
    if ($(this).is(':checked')) {
        $('#Str_passingyear2').val('').attr('readonly', true);
        $('#Str_passingyear2').removeAttr('required');
        $('#Str_duration2').val('').attr('readonly', true);
        $('#Str_duration2').removeAttr('required');
        $('#Str_Marks2').val('').attr('readonly', true);
        $('#Str_Marks2').removeAttr('required');
        $('#Str_division2').val('').attr('readonly', true);
        $('#Str_division2').removeAttr('required');
    }
    else {
        $('#Str_passingyear2').attr('readonly', false);
        $('#Str_passingyear2').attr('required', true);
        $('#Str_duration2').attr('readonly', false);
        $('#Str_duration2').attr('required', true);
        $('#Str_Marks2').attr('readonly', false);
        $('#Str_Marks2').attr('required', true);
        $('#Str_division2').attr('readonly', false);
        $('#Str_division2').attr('required', true);
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

    if ($(this).prop("checked") == true) {

        var ALlQuValue = this.value.toString().split('WITH');
        $("#selectValue").val(this.value);
        $("#EduQulifi").val(this.value);

        if (this.value.toString().split('WITH').length == 1) {
            //$('#Str_exampassed2').val(ALlQuValue[0]);
            $('#Str_exampassed2').val($('input[type=checkbox][name="str_qualification"]').val());

            $('#Str_course3').attr('readonly', true);
            $('#Str_board3').attr('readonly', true);
            $('#Str_passingdetails3').attr('readonly', true);
            $('#Str_passingyear3').attr('readonly', true);
            $('#Str_duration3').attr('readonly', true);
            $('#Str_Marks3').attr('readonly', true);
            $('#Str_division3').attr('readonly', true);

            $('#Str_course4').attr('readonly', true);
            $('#Str_board4').attr('readonly', true);
            $('#Str_passingdetails4').attr('readonly', true);
            $('#Str_passingyear4').attr('readonly', true);
            $('#Str_duration4').attr('readonly', true);
            $('#Str_Marks4').attr('readonly', true);
            $('#Str_division4').attr('readonly', true);


        }

        if (this.value.toString().split('WITH').length == 2) {
            $('#Str_exampassed2').val(ALlQuValue[0]);
            $('#Str_exampassed3').val(ALlQuValue[1]);
            $('#Str_course4').attr('readonly', true);
            $('#Str_board4').attr('readonly', true);
            $('#Str_passingdetails4').attr('readonly', true);
            $('#Str_passingyear4').attr('readonly', true);
            $('#Str_duration4').attr('readonly', true);
            $('#Str_Marks4').attr('readonly', true);
            $('#Str_division4').attr('readonly', true);
        }

        if (this.value.toString().split('WITH').length == 3) {
            $('#Str_exampassed2').val(ALlQuValue[0]);
            $('#Str_exampassed3').val(ALlQuValue[1]);
            $('#Str_exampassed4').val(ALlQuValue[2]);
        }
    }

});

$(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});
$(document).on('change', '#Str_exampassed2', function (e) {
    $('#Str_exampassed2').val($('input[type=checkbox][name="str_qualification"]').val());
    $('#Str_course2').focus();
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

        var from = _date.split("-")
        return new Date(from[2], from[1] - 1, from[0])
    }
}

$("#Str_passingyear,#Str_passingyear1,#Str_passingyear2,#Str_passingyear3,#Str_passingyear4").change(function () {

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


    if ($("#selectValue").val().toString().split('WITH').length == 1) {
        $('#Str_exampassed2').val(ALlQuValue[0]);

        $('#Str_course3').attr('readonly', true);
        $('#Str_board3').attr('readonly', true);
        $('#Str_passingdetails3').attr('readonly', true);
        $('#Str_passingyear3').attr('readonly', true);
        $('#Str_duration3').attr('readonly', true);
        $('#Str_Marks3').attr('readonly', true);
        $('#Str_division3').attr('readonly', true);

        $('#Str_course4').attr('readonly', true);
        $('#Str_board4').attr('readonly', true);
        $('#Str_passingdetails4').attr('readonly', true);
        $('#Str_passingyear4').attr('readonly', true);
        $('#Str_duration4').attr('readonly', true);
        $('#Str_Marks4').attr('readonly', true);
        $('#Str_division4').attr('readonly', true);


    }

    if ($("#selectValue").val().toString().split('WITH').length == 2) {
        $('#Str_exampassed2').val(ALlQuValue[0]);
        $('#Str_exampassed3').val(ALlQuValue[1]);
        $('#Str_course4').attr('readonly', true);
        $('#Str_board4').attr('readonly', true);
        $('#Str_passingdetails4').attr('readonly', true);
        $('#Str_passingyear4').attr('readonly', true);
        $('#Str_duration4').attr('readonly', true);
        $('#Str_Marks4').attr('readonly', true);
        $('#Str_division4').attr('readonly', true);
    }

    if ($("#selectValue").val().toString().split('WITH').length == 3) {
        $('#Str_exampassed2').val(ALlQuValue[0]);
        $('#Str_exampassed3').val(ALlQuValue[1]);
        $('#Str_exampassed4').val(ALlQuValue[2]);
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

    //$('#tbllistofplantMachinery').find("input:not([readonly],[type=hidden])").each(function () {
    //    var element = $(this);
    //    if (element.val() == "") {
    //        isValid = false;
    //        $(this).next("span").remove();
    //        $(this).after("<span style='color:Red'> This field is required</span>");
    //    }
    //});
    if ($("#Str_course2").val() == '') {
        $("#Str_course2").focus();
        $("#Str_course2").next("span").remove();
        $("#Str_course2").after("<span style='color:Red'>This field is required</span>");

    }
    if ($("#Str_exampassed2").val() == '') {
        $("#Str_exampassed2").focus();
        $("#Str_exampassed2").next("span").remove();
       $("#Str_exampassed2").after("<span style='color:Red'>This field is required</span>");
        
    }
    if ($("#Str_board2").val() == '') {
        $("#Str_board2").focus();
        $("#Str_board2").next("span").remove();
        $("#Str_board2").after("<span style='color:Red'>This field is required</span>");

    }
    if ($("#Str_passingdetails2").val() == '') {
        $("#Str_passingdetails2").focus();
        $("#Str_passingdetails2").next("span").remove();
        $("#Str_passingdetails2").after("<span style='color:Red'>This field is required</span>");

    }
    if ($("#Str_passingyear2").val() == '') {
        $("#Str_passingyear2").focus();
        $("#Str_passingyear2").next("span").remove();
        $("#Str_passingyear2").after("<span style='color:Red'>This field is required</span>");

    }
    if ($("#Str_duration2").val() == '') {
        $("#Str_duration2").focus();
        $("#Str_duration2").next("span").remove();
        $("#Str_duration2").after("<span style='color:Red'>This field is required</span>");

    }
    if ($("#Str_Marks2").val() == '') {
        $("#Str_Marks2").focus();
        $("#Str_Marks2").next("span").remove();
        $("#Str_Marks2").after("<span style='color:Red'>This field is required</span>");

    }
    if ($("#Str_division2").val() == '') {
        $("#Str_division2").focus();
        $("#Str_division2").next("span").remove();
        $("#Str_division2").after("<span style='color:Red'>This field is required</span>");

    }



    

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
        if ($('#str_GateRegistrationNo1')[0] != undefined) {
            if ($('#str_GateExaminationPaper1').val() == '' || $('#str_GateMarks1').val() == '' || $('#str_GateExaminationPaper1').val() == '' || (($('input[type=file][name="str_GATEResult"]').val() == '') && $('.clsGATEDoc').text() == '')) {
                return false;
            }
        }

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