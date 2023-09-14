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

//$("#dtExpiryDate").keyup(function () {

//    var dtExpiryDate = $("#dtExpiryDate").val();
//    $("#dtExpiryDate").next("span").remove();
//    if (dtExpiryDate == "") {
//        $("#dtExpiryDate").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#dtExpiryDate").next("span").remove();
//    }
//});

//$("#dtEventDate").keyup(function () {

//    var dtEventDate = $("#dtEventDate").val();
//    $("#dtEventDate").next("span").remove();
//    if (dtEventDate == "") {
//        $("#dtEventDate").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#dtEventDate").next("span").remove();
//    }
//});

$("#strImageFileEnglish").change(function () {

    var strImageFileEnglish = $("#strImageFileEnglish").val();
    $("#strImageFileEnglish").next("span").remove();
    if (strImageFileEnglish == "") {
        $("#strImageFileEnglish").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strImageFileEnglish").next("span").remove();
    }
});

//$("#strImageFileHindi").change(function () {

//    var strImageFileHindi = $("#strImageFileHindi").val();
//    $("#strImageFileHindi").next("span").remove();
//    if (strImageFileHindi == "") {
//        $("#strImageFileHindi").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#strImageFileHindi").next("span").remove();
//    }
//});


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
    if ($("#strImageFileEnglish").val() == "") {
        $("#strImageFileEnglish").next("span").remove();
        $("#strImageFileEnglish").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

//    if ($("#strImageFileHindi").val() == "") {
//        $("#strImageFileHindi").next("span").remove();
//        $("#strImageFileHindi").after("<span style='color:Red'> This field is required</span>");
//        noerror = 0;
//    }
//    if ($("#dtEventDate").val() == "") {
//        $("#dtEventDate").next("span").remove();
//        $("#dtEventDate").after("<span style='color:Red'> This field is required</span>");
//        noerror = 0;
//    }
//    if ($("#dtExpiryDate").val() == "") {
//        $("#dtExpiryDate").next("span").remove();
//        $("#dtExpiryDate").after("<span style='color:Red'> This field is required</span>");
//        noerror = 0;
//    }
    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#tbl_mst_Events')[0].checkValidity()) {
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


$("#strSubjectdfsEnglish").on("input", function () {
    LimtCharacters(this, 150);
});

$("#strSubjectdfsHindi").on("input", function () {
    LimtCharacters(this, 150);
});
$("#strDescriptiondfsEnglish").on("input", function () {
    LimtCharacters(this, 400);
});

$("#strDescriptiondfsHindi").on("input", function () {
    LimtCharacters(this, 400);
});



function LimtCharacters(txtMsg, CharLength) {
    $(txtMsg).next("span").remove();
    chars = txtMsg.value.length;
    if (chars > CharLength && chars > 0) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $(txtMsg).after("<span style='color:Red'> Max Length reached..</span>");
    }
}



$("#strImageFileEnglish").change(function () {

    var fileExtension = ['jpeg', 'jpg', 'png', 'bmp'];
    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
        alert("Only '.jpeg','.jpg', '.png', '.gif', '.bmp' formats are allowed.");
        $("#strImageFileEnglish").val('');

    }

});



$("#str_uploadfile").change(function () {

    var fileExtension = ['jpeg', 'jpg', 'png', 'bmp'];
    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
        alert("Only '.jpeg','.jpg', '.png', '.gif', '.bmp' formats are allowed.");
        $("#str_uploadfile").val('');

    }

});