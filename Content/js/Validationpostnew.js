function error() {

    var noerror = 1;

    if ($("#fk_discipline").val() == "") {
        $("#fk_discipline").next("span").remove();
        $("#fk_discipline").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#Postname").val() == "") {
        $("#Postname").next("span").remove();
        $("#Postname").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#str_Grade").val() == "") {
        $("#str_Grade").next("span").remove();
        $("#str_Grade").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#Payscale").val() == "") {
        $("#Payscale").next("span").remove();
        $("#Payscale").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#str_ctc").val() == "") {
        $("#str_ctc").next("span").remove();
        $("#str_ctc").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#str_minexp").val() == "") {
        $("#str_minexp").next("span").remove();
        $("#str_minexp").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#dtcompareDate").val() == "") {
        $("#dtcompareDate").next("span").remove();
        $("#dtcompareDate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_minage").val() == "") {
        $("#str_minage").next("span").remove();
        $("#str_minage").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_maxage").val() == "") {
        $("#str_maxage").next("span").remove();
        $("#str_maxage").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strIsFreshersAllowed").val() == "") {
        $("#strIsFreshersAllowed").next("span").remove();
        $("#strIsFreshersAllowed").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#tbl_mst_Post')[0].checkValidity()) {
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

$("#str_minexp").ForceNumericOnly();
$("#str_minage").ForceNumericOnly();
$("#str_maxage").ForceNumericOnly();
//Keyup&change
$("#fk_discipline").change(function () {

    var fk_discipline = $("#fk_discipline").val();
    $("#fk_discipline").next("span").remove();
    if (fk_discipline == "") {
        $("#fk_discipline").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_discipline").next("span").remove();
    }
});
$("#Postname").keyup(function () {

    var Postname = $("#Postname").val();
    $("#Postname").next("span").remove();
    if (Postname == "") {
        $("#Postname").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Postname").next("span").remove();
    }
});
$("#str_Grade").keyup(function () {
    var str_Grade = $("#str_Grade").val();
    $("#str_Grade").next("span").remove();
    if (str_Grade == "") {
        $("#str_Grade").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_Grade").next("span").remove();
    }
});
$("#Payscale").keyup(function () {
    var Payscale = $("#Payscale").val();
    $("#Payscale").next("span").remove();
    if (Payscale == "") {
        $("#Payscale").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Payscale").next("span").remove();
    }
});
$("#str_ctc").keyup(function () {
    var str_ctc = $("#str_ctc").val();
    $("#str_ctc").next("span").remove();
    if (str_ctc == "") {
        $("#str_ctc").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_ctc").next("span").remove();
    }
});
$("#str_minexp").keyup(function () {
    var str_minexp = $("#str_minexp").val();
    $("#str_minexp").next("span").remove();
    if (str_minexp == "") {
        $("#str_minexp").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_minexp").next("span").remove();
    }
});
$("#dtcompareDate").keyup(function () {
    var dtcompareDate = $("#dtcompareDate").val();
    $("#dtcompareDate").next("span").remove();
    if (dtcompareDate == "") {
        $("#dtcompareDate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dtcompareDate").next("span").remove();
    }
});
$("#str_minage").keyup(function () {
    var str_minage = $("#str_minage").val();
    $("#str_minage").next("span").remove();
    if (str_minage == "") {
        $("#str_minage").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_minage").next("span").remove();
    }
});

$("#str_maxage").keyup(function () {
    var str_maxage = $("#str_maxage").val();
    $("#str_maxage").next("span").remove();
    if (str_maxage == "") {
        $("#str_maxage").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_maxage").next("span").remove();
    }
});

$("#strIsFreshersAllowed").keyup(function () {
    var strIsFreshersAllowed = $("#strIsFreshersAllowed").val();
    $("#strIsFreshersAllowed").next("span").remove();
    if (strIsFreshersAllowed == "") {
        $("#strIsFreshersAllowed").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strIsFreshersAllowed").next("span").remove();
    }
});


//characterlimit   
$("#fk_discipline").on("input", function () {
    LimtCharacters(this, 100);
});


$("#Postname").on("input", function () {
    LimtCharacters(this, 100);
});

$("#str_Grade").on("input", function () {
    LimtCharacters(this, 50);
});
$("#Payscale").on("input", function () {
    LimtCharacters(this, 50);
});

$("#str_ctc").on("input", function () {
    LimtCharacters(this, 20);
});
$("#str_minexp").on("input", function () {
    LimtCharacters(this, 200);
});
$("#str_minage").on("input", function () {
    LimtCharacters(this, 20);
});
$("#str_maxage").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strIsFreshersAllowed").on("input", function () {
    LimtCharacters(this, 50);
});

function LimtCharacters(txtMsg, CharLength) {
    $(txtMsg).next("span").remove();
    chars = txtMsg.value.length;
    if (chars > CharLength && chars > 0) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $(txtMsg).after("<span style='color:Red'> Max Length reached..</span>");
    }
}
