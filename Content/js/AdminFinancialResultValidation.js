
$("#Fk_intPerticular").change(function () {

    var Fk_intPerticular = $("#Fk_intPerticular").val();
    $("#Fk_intPerticular").next("span").remove();
    if (Fk_intPerticular == "") {
        $("#Fk_intPerticular").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Fk_intPerticular").next("span").remove();
    }
});





$("#Fk_intYearId").change(function () {

    var Fk_intYearId = $("#Fk_intYearId").val();
    $("#Fk_intYearId").next("span").remove();
    if (Fk_intYearId == "") {
        $("#Fk_intYearId").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Fk_intYearId").next("span").remove();
    }
});





$("#vchPerStatus").change(function () {

    var vchPerStatus = $("#vchPerStatus").val();
    $("#vchPerStatus").next("span").remove();
    if (vchPerStatus == "") {
        $("#vchPerStatus").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchPerStatus").next("span").remove();
    }
});





$("#vchProfStatus").change(function () {

    var vchProfStatus = $("#vchProfStatus").val();
    $("#vchProfStatus").next("span").remove();
    if (vchProfStatus == "") {
        $("#vchProfStatus").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchProfStatus").next("span").remove();
    }
});


$("#vchHeading").keyup(function () {
    var vchHeading = $("#vchHeading").val();
    $("#vchHeading").next("span").remove();
    if (vchHeading == "") {
        $("#vchHeading").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchHeading").next("span").remove();
    }
});




$("#vchHeading").on("input", function () {
    LimtCharacters(this, 10);
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

    var vchHeading = $("#vchHeading").val();
    var vchProfStatus = $("#vchProfStatus").val();
    var vchPerStatus = $("#vchPerStatus").val();
    var Fk_intYearId = $("#Fk_intYearId").val();
    var Fk_intPerticular = $("#Fk_intPerticular").val();










    if (vchHeading == "") {
        $("#vchHeading").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if (vchProfStatus == "") {
        $("#vchProfStatus").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if (vchPerStatus == "") {
        $("#vchPerStatus").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }



    if (Fk_intYearId == "") {
        $("#Fk_intYearId").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (Fk_intPerticular == "") {
        $("#Fk_intPerticular").after("<span style='color:Red'> This field is required</span>");
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