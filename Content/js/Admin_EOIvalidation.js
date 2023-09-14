
$("#strSnippet").keyup(function () {
    var strSnippet = $("#strSnippet").val();
    $("#strSnippet").next("span").remove();
    if (strSnippet == "") {
        $("#strSnippet").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strSnippet").next("span").remove();
    }
});


$("#strSnippethindi").keyup(function () {
    var strSnippethindi = $("#strSnippethindi").val();
    $("#strSnippethindi").next("span").remove();
    if (strSnippethindi == "") {
        $("#strSnippethindi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strSnippethindi").next("span").remove();
    }
});


$("#IsImportant").keyup(function () {

    var IsImportant = $("#IsImportant").val();
    $("#IsImportant").next("span").remove();
    if (IsImportant == "") {
        $("#IsImportant").after("<span style='color:white;text-align:center'> This field is required</span>");
    }
    else {
        $("#IsImportant").next("span").remove();
    }
});



$("#strStatus").change(function () {

    var strStatus = $("#IsStatus").val();
    $("#strStatus").next("span").remove();
    if (strStatus == "") {
        $("#strStatus").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strStatus").next("span").remove();
    }
});


$("#strFileUpload").change(function () {

    var strFileUpload = $("#strFileUpload").val();
    $("#strFileUpload").next("span").remove();
    if (strFileUpload == "") {
        $("#strFileUpload").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strFileUpload").next("span").remove();
    }
});


$("#strFileuploadhindi").change(function () {

    var strFileuploadhindi = $("#strFileuploadhindi").val();
    $("#strFileuploadhindi").next("span").remove();
    if (strFileuploadhindi == "") {
        $("#strFileuploadhindi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strFileuploadhindi").next("span").remove();
    }
});



$("#strSnippet,#strSnippethindi").on("input", function () {
    LimtCharacters(this, 25);
});




function LimtCharacters(txtMsg, CharLength) {
    $(txtMsg).next("span").remove();
    chars = txtMsg.value.length;
    if (chars > CharLength && chars > 0) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $(txtMsg).after("<span style='color:Red'> Max Length reached..</span>");
    }
}

function error() {



    var noerror = 1;
    var strSnippet = $("#strSnippet").val();
    var strSnippethindi = $("#strSnippethindi").val();
    var strFileUpload = $("#strFileUpload").val();
    var strFileuploadhindi = $("#strFileuploadhindi").val();
    var strStatus = $("#strStatus").val();
    var IsImportant = $("#IsImportant").val();

    var dtClosingDate = $("#dtClosingDate").val();
    var Hidtext = $("#Hidtext").val();
    var HidTexthindi = $("#HidTexthindi").val();

    if (strSnippet == "") {
        $("#strSnippet").next("span").remove();
        $("#strSnippet").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (strSnippethindi == "") {
        $("#strSnippethindi").next("span").remove();
        $("#strSnippethindi").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (strFileUpload == "" && Hidtext=="") {
        $("#strFileUpload").next("span").remove();
        $("#strFileUpload").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (strFileuploadhindi == "" && HidTexthindi == "") {
        $("#strFileuploadhindi").next("span").remove();
        $("#strFileuploadhindi").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    
    if (strStatus == "") {
        $("#strStatus").next("span").remove();
        $("#strStatus").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }



    if (IsImportant == "") {
        $("#IsImportant").next("span").remove();
        $("#IsImportant").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (dtClosingDate == "") {
        $("#dtClosingDate").next("span").remove();
        $("#dtClosingDate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
   

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#tbl_mst_Order')[0].checkValidity()) {
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