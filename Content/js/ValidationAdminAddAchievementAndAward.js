$("#strSubjectdfsEnglish").keyup(function () {
    var strSubjectdfsEnglish = $("#strSubjectdfsEnglish").val();
    $("#strSubjectdfsEnglish").next("span").remove();
    if (strSubjectdfsEnglish == "") {
        $("#strSubjectdfsEnglish").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strSubjectdfsEnglish").next("span").remove();
    }
});

$("#strSubjectdfsHindi").keyup(function () {
    var strSubjectdfsHindi = $("#strSubjectdfsHindi").val();
    $("#strSubjectdfsHindi").next("span").remove();
    if (strSubjectdfsHindi == "") {
        $("#strSubjectdfsHindi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strSubjectdfsHindi").next("span").remove();
    }
});

$("#strDescriptiondfsEnglish").keyup(function () {
    var strDescriptiondfsEnglish = $("#strDescriptiondfsEnglish").val();
    $("#strDescriptiondfsEnglish").next("span").remove();
    if (strDescriptiondfsEnglish == "") {
        $("#strDescriptiondfsEnglish").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strDescriptiondfsEnglish").next("span").remove();
    }
});

$("#strDescriptiondfsHindi").keyup(function () {
    var strDescriptiondfsHindi = $("#strDescriptiondfsHindi").val();
    $("#strDescriptiondfsHindi").next("span").remove();
    if (strDescriptiondfsHindi == "") {
        $("#strDescriptiondfsHindi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strDescriptiondfsHindi").next("span").remove();
    }
});

$("#dtAwardDate").keyup(function () {
    var dtAwardDate = $("#dtAwardDate").val();
    $("#dtAwardDate").next("span").remove();
    if (dtAwardDate == "") {
        $("#dtAwardDate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dtAwardDate").next("span").remove();
    }
});
$("#strAwardFile").change(function () {

    var strAwardFile = $("#strAwardFile").val();
    $("#strAwardFile").next("span").remove();
    if (strAwardFile == "") {
        $("#strAwardFile").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strAwardFile").next("span").remove();
    }
});

$("#strSubjectdfsEnglish").on("input", function () {
    LimtCharacters(this, 200);
});

$("#strSubjectdfsHindi").on("input", function () {
    LimtCharacters(this, 200);
});
$("#strDescriptiondfsEnglish").on("input", function () {
    LimtCharacters(this, 400);
});
$("#strDescriptiondfsHindi").on("input", function () {
    LimtCharacters(this, 400);
});
//$("#intPeriodInMonths").ForceNumericOnly();


function error() {
var noerror = 1;
    if ($("#strSubjectdfsEnglish").val() == "") {
        $("#strSubjectdfsEnglish").next("span").remove();
        $("#strSubjectdfsEnglish").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strSubjectdfsHindi").val() == "") {
        $("#strSubjectdfsHindi").next("span").remove();
        $("#strSubjectdfsHindi").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strDescriptiondfsEnglish").val() == "") {
        $("#strDescriptiondfsEnglish").next("span").remove();
        $("#strDescriptiondfsEnglish").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strDescriptiondfsHindi").val() == "") {
        $("#strDescriptiondfsHindi").next("span").remove();
        $("#strDescriptiondfsHindi").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strAwardFile").val() == "") {
        $("#strAwardFile").next("span").remove();
        $("#strAwardFile").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#dtAwardDate").val() == "") {
        $("#dtAwardDate").next("span").remove();
        $("#dtAwardDate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#tbl_mst_AchievementAndAward')[0].checkValidity()) {
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


function LimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:Red'> Max Length reached..</span>");
    }

}