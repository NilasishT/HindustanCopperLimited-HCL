




if ($("#Pk_criteriaid").val() == null) {
    $("#str_postCTC").hide();
    $("#str_postGrade").hide();
    $("#dt_compareDate").hide();
    $("#strExServicemen").hide();
    $("#str_postMinage").hide();
    $("#str_postMaxage").hide();
    $("#strPostIsFreshersAllowed").hide();
    $("#strPostPaySacle").hide();
    $("#intvacancy").hide();



    $("#lbl_CTC").hide();
    $("#lbl_Grade").hide();
    $("#lbl_ComparedDate").hide();
    $("#lbl_ExServicemen").hide();
    $("#lbl_minAge").hide();
    $("#lbl_maxAge").hide();
    $("#lbl_ifFresher").hide();
    $("#Vacancy").hide();
    $("#lbl_PayScale").hide();
}

$('#str_caste,#str_gender,#str_pwd').multipleSelect({
    isOpen: true,
    keepOpen: true,
    selectAll: true,
    minimumCountSelected: 1,
    single: false,
    maxHeight: 150

});

function error() {

    var noerror = 1;
    $('#hidstr_caste').val($('#str_caste').multipleSelect('getSelects'));
    $('#hidstr_gender').val($('#str_gender').multipleSelect('getSelects'));
    $('#hidstr_pwd').val($('#str_pwd').multipleSelect('getSelects'));


    if ($("#fk_advertisementid").val() == "") {

        $("#fk_advertisementid").next("span").remove();
        $("#fk_advertisementid").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if ($("#fk_diciplineid").val() == "") {

        $("#fk_diciplineid").next("span").remove();
        $("#fk_diciplineid").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#fk_postid").val() == "") {

        $("#fk_postid").next("span").remove();
        $("#fk_postid").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if ($("#fk_postid").val() != "") {

        if ($("#str_postCTC").val() == "") {

            $("#str_postCTC").next("span").remove();
            $("#str_postCTC").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if ($("#str_postGrade").val() == "") {

            $("#str_postGrade").next("span").remove();
            $("#str_postGrade").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if ($("#strExServicemen").val() == "") {

            $("#strExServicemen").next("span").remove();
            $("#strExServicemen").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if ($("#dt_compareDate").val() == "") {

            $("#dt_compareDate").next("span").remove();
            $("#dt_compareDate").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#str_postMinage").val() == "") {

            $("#str_postMinage").next("span").remove();
            $("#str_postMinage").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#str_postMaxage").val() == "") {

            $("#str_postMaxage").next("span").remove();
            $("#str_postMaxage").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#strPostIsFreshersAllowed").val() == "") {

            $("#strPostIsFreshersAllowed").next("span").remove();
            $("#strPostIsFreshersAllowed").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
    }

    if ($("#dt_compareDateExperience").val() == "") {

        $("#dt_compareDateExperience").next("span").remove();
        $("#dt_compareDateExperience").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_postMinageExperience").val() == "") {

        $("#str_postMinageExperience").next("span").remove();
        $("#str_postMinageExperience").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_postMaxageExperience").val() == "") {

        $("#str_postMaxageExperience").next("span").remove();
        $("#str_postMaxageExperience").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_qualification1").val() == "") {

        $("#str_qualification1").next("span").remove();
        $("#str_qualification1").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($('#str_caste').multipleSelect('getSelects') == '' || $('#str_caste').multipleSelect('getSelects') == null) {

        $("#str_caste").next("span").remove();
        $("#str_caste").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if ($('#str_gender').multipleSelect('getSelects') == '' || $('#str_caste').multipleSelect('getSelects') == null) {
        $("#str_gender").next("span").remove();
        $("#str_gender").after("<span style='color:Red'> This field is required</span>");
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



$("#fk_postid").change(function () {
    var fk_postid = $("#fk_postid").val();
    $("#fk_postid").next("span").remove();
    if (fk_postid == "") {
        $("#fk_postid").after("<span style='color:Red'> This field is required</span>");
        post();
    }
    else {
        $("#fk_postid").next("span").remove();
        post();
    }
});
function post() {

    var id = $("#fk_postid").val();
    if (id != "") {

        $("#str_postCTC").show();
        $("#str_postGrade").show();
        $("#dt_compareDate").show();
        $("#strExServicemen").show();
        $("#str_postMinage").show();
        $("#str_postMaxage").show();
        $("#strPostIsFreshersAllowed").show();
        $("#strPostPaySacle").show();

        $("#lbl_CTC").show();
        $("#lbl_Grade").show();
        $("#lbl_ComparedDate").show();
        $("#lbl_ExServicemen").show();
        $("#lbl_minAge").show();
        $("#lbl_maxAge").show();
        $("#lbl_ifFresher").show();
        $("#Vacancy").show();
        $("#lbl_PayScale").show();
        $("#intvacancy").show();
        $("#lbl_ifFresher").show();


    }
    else {


        $("#str_postCTC").hide();
        $("#str_postGrade").hide();
        $("#dt_compareDate").hide();
        $("#strExServicemen").hide();
        $("#str_postMinage").hide();
        $("#str_postMaxage").hide();
        $("#strPostIsFreshersAllowed").hide();
        $("#Vacancy").hide();
        $("#strPostPaySacle").hide();
        $("#intvacancy").hide();

        $("#lbl_CTC").hide();
        $("#lbl_Grade").hide();
        $("#lbl_ComparedDate").hide();
        $("#lbl_ExServicemen").hide();
        $("#lbl_minAge").hide();
        $("#lbl_maxAge").hide();
        $("#lbl_ifFresher").hide();
        $("#lbl_PayScale").hide();
        $("#str_postCTC").val('');
        $("#str_postGrade").val('');
        $("#dt_compareDate").val('');
        $("#strExServicemen").val('');
        $("#str_postMinage").val('');
        $("#str_postMaxage").val('');
        $("#strPostIsFreshersAllowed").val();
        $("#lbl_ifFresher").hide();

    }

}

//Change
$("#fk_advertisementid").change(function () {
    var fk_advertisementid = $("#fk_advertisementid").val();
    $("#fk_advertisementid").next("span").remove();
    if (fk_advertisementid == "") {
        $("#fk_advertisementid").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_advertisementid").next("span").remove();
    }
});


$("#fk_diciplineid").change(function () {
    var fk_diciplineid = $("#fk_diciplineid").val();
    $("#fk_diciplineid").next("span").remove();
    if (fk_diciplineid == "") {
        $("#fk_diciplineid").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_diciplineid").next("span").remove();
    }
});


$("#str_postCTC").keyup(function () {
    var str_postCTC = $("#str_postCTC").val();
    $("#str_postCTC").next("span").remove();
    if (str_postCTC == "") {
        $("#str_postCTC").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_postCTC").next("span").remove();
    }
});

$("#str_postGrade").keyup(function () {
    var str_postGrade = $("#str_postGrade").val();
    $("#str_postGrade").next("span").remove();
    if (str_postGrade == "") {
        $("#str_postGrade").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_postGrade").next("span").remove();
    }
});


$("#strExServicemen").change(function () {
    var strExServicemen = $("#strExServicemen").val();
    $("#strExServicemen").next("span").remove();
    if (strExServicemen == null) {
        $("#strExServicemen").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strExServicemen").next("span").remove();
    }
});

$("#dt_compareDate").keyup(function () {
    var dt_compareDate = $("#dt_compareDate").val();
    $("#dt_compareDate").next("span").remove();
    if (dt_compareDate == "") {
        $("#dt_compareDate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dt_compareDate").next("span").remove();
    }
});

$("#str_postMinage").change(function () {
    var str_postMinage = $("#str_postMinage").val();
    $("#str_postMinage").next("span").remove();
    if (str_postMinage == "") {
        $("#str_postMinage").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_postMinage").next("span").remove();
    }
});

$("#str_postMaxage").change(function () {
    var str_postMaxage = $("#str_postMaxage").val();
    $("#str_postMaxage").next("span").remove();
    if (str_postMaxage == "") {
        $("#str_postMaxage").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_postMaxage").next("span").remove();
    }
});

$("#strPostIsFreshersAllowed").change(function () {
    var strPostIsFreshersAllowed = $("#strPostIsFreshersAllowed").val();
    $("#strPostIsFreshersAllowed").next("span").remove();
    if (strPostIsFreshersAllowed == "") {
        $("#strPostIsFreshersAllowed").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPostIsFreshersAllowed").next("span").remove();
    }
});

$("#dt_compareDateExperience").keyup(function () {
    var dt_compareDateExperience = $("#dt_compareDateExperience").val();
    $("#dt_compareDateExperience").next("span").remove();
    if (dt_compareDateExperience == "") {
        $("#dt_compareDateExperience").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dt_compareDateExperience").next("span").remove();
    }
});

$("#str_postMinageExperience").change(function () {
    var str_postMinageExperience = $("#str_postMinageExperience").val();
    $("#str_postMinageExperience").next("span").remove();
    if (str_postMinageExperience == "") {
        $("#str_postMinageExperience").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_postMinageExperience").next("span").remove();
    }
});

$("#str_postMaxageExperience").change(function () {
    var str_postMaxageExperience = $("#str_postMaxageExperience").val();
    $("#str_postMaxageExperience").next("span").remove();
    if (str_postMaxageExperience == "") {
        $("#str_postMaxageExperience").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_postMaxageExperience").next("span").remove();
    }
});


$('#str_gender').change(function () {
    $("#str_gender").next("span").remove();
    if ($('#str_gender').multipleSelect('getSelects') == "") {
        $("#str_gender").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_gender").next("span").remove();
    }
});


$("#str_qualification1").keyup(function () {
    var str_qualification1 = $("#str_qualification1").val();
    $("#str_qualification1").next("span").remove();
    if (str_qualification1 == "") {
        $("#str_qualification1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_qualification1").next("span").remove();
    }
});

var hidstr_caste = $("#hidstr_caste").val();

if (hidstr_caste != "") {
    var data = $("#hidstr_caste").val();
    var dataarray = data.split(",");
    $("#str_caste").val(dataarray);
    $("#str_caste").multipleSelect("refresh");
}

var hidstr_pwd = $("#hidstr_pwd").val();

if (hidstr_pwd != "") {
    var data = $("#hidstr_pwd").val();
    var dataarray = data.split(",");
    $("#str_pwd").val(dataarray);
    $("#str_pwd").multipleSelect("refresh");
}

var hidstr_gender = $("#hidstr_gender").val();

if (hidstr_gender != "") {
    var data = $("#hidstr_gender").val();
    var dataarray = data.split(",");
    $("#str_gender").val(dataarray);
    $("#str_gender").multipleSelect("refresh");
}


$("#fk_postid").change(function () {

    var Id = $("#fk_postid").val();
    if (Id == "") {
        $("#str_postdetails").html('');

    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Admin/Getpostdetails',
            data: { 'Id': Id },
            success: function (result) {

                if (result.Post != "") {

                    $("#str_postCTC").val(result.GetCTCvalue);
                    $("#str_postGrade").val(result.GetGradevalue);
                    $("#str_postMinage").val(result.GetMinagevalue);
                    $("#str_postMaxage").val(result.GetMaxagevalue);
                    $("#strPostIsFreshersAllowed").val(result.GetIsFreshersAllowedvalue);
                    $("#dt_compareDate").val(result.GetComparedDate);
                    $("#str_postMinageExperience").val(result.GetMinagevalue);
                    $("#str_postMaxageExperience").val(result.GetMaxagevalue);
                    $("#strPostPaySacle").val(result.GetPostPaySaclevalue);


                }
            },
            error: function () {

                alert('Error');
            }

        });
    }
});

$("#str_postCTC").ForceNumericOnly();
$("#strPostPaySacle").ForceNumericOnly();
$("#str_postMinage").ForceNumericOnly();
$("#str_postMaxage").ForceNumericOnly();
$("#intvacancy").ForceNumericOnly();

$("#fk_diciplineid").change(function () {

    var discipline = $("#fk_diciplineid").val();
    if (discipline == "") {
        alert("Please select Discipline.");

    }
    else {


        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Admin/getDisciplinedetails',
            data: { 'discipline': discipline },
            success: function (result) {

                $('#fk_postid').empty();
                if (result.Disciplinemaster.length > 0) {
                    $('#fk_postid').append($('<option/>').attr('value', "0").text("Select"));
                    $.each(result.Disciplinemaster, function (result) {
                        $('#fk_postid').append($('<option/>').attr('value', this.Pk_Postid).text(this.Postname));
                    });

                }

            },
            error: function () {

                alert('Error');
            }

        });
    }



});





function BindAgeRelax() {
    var ele = $('#divAgeRelax').empty();
    ele.closest('fieldset').hide();
    var arr = $('#str_caste').val();
    if (arr != null) {
        $.each(arr, function (i, v) {
            if (i == 0) {
                ele.closest('fieldset').show();
            }
            var jj = '<div style="padding: 10px; border: 1px solid lightgray;">';
            jj += '    <div class="row">';
            jj += '        <div class="col-md-8">';
            jj += '            <label>' + v + '</label>';
            jj += '        </div>';
            jj += '        <div class="col-md-4">';
            jj += '            <input type="number" name="caste_cat_' + v + '" value="0" class="form-control" min="0" max="25" required/>';
            jj += '        </div>';
            jj += '    </div>';
            jj += '</div>';
            ele.append(jj);
        });
    }
    if ($('#str_pwd').val() != null) {
        var jj = '<div style="padding: 10px; border: 1px solid lightgray;">';
        jj += '    <div class="row">';
        jj += '        <div class="col-md-8">';
        jj += '            <label>PWD</label>';
        jj += '        </div>';
        jj += '        <div class="col-md-4">';
        jj += '            <input type="number" name="caste_cat_PWD" value="0" class="form-control" min="0" max="25" required/>';
        jj += '        </div>';
        jj += '    </div>';
        jj += '</div>';
        ele.append(jj);
    }
    if ($('#strExServicemen').val() == 'Yes') {
        var jj = '<div style="padding: 10px; border: 1px solid lightgray;">';
        jj += '    <div class="row">';
        jj += '        <div class="col-md-8">';
        jj += '            <label>Ex-Servicemen</label>';
        jj += '        </div>';
        jj += '        <div class="col-md-4">';
        jj += '            <input type="number" name="caste_cat_ExServicemen" value="0" class="form-control" min="0" max="25" required/>';
        jj += '        </div>';
        jj += '    </div>';
        jj += '</div>';
        ele.append(jj);
    }
}

$('#str_caste').change(function () {
    $("#str_caste").next("span").remove();
    if ($('#str_caste').multipleSelect('getSelects') == "") {
        $("#str_caste").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_caste").next("span").remove();
    }
    BindAgeRelax();
});
$('#str_caste,#str_pwd,#strExServicemen').change(function () {
    BindAgeRelax();
})
BindAgeRelax();