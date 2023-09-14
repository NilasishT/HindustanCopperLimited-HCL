$("#fk_productid").change(function () {

    var fk_productid = $("#fk_productid").val();
    $("#fk_productid").next("span").remove();
    if (fk_productid == "") {
        $("#fk_productid").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_productid").next("span").remove();
    }
});

$("#str_currency").change(function () {

    var str_currency = $("#str_currency").val();
    $("#strOrderType").next("span").remove();
    if (str_currency == "") {
        $("#str_currency").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_currency").next("span").remove();
    }
});

$("#fk_unit").change(function () {

    var fk_unit = $("#fk_unit").val();
    $("#fk_unit").next("span").remove();
    if (fk_unit == "") {
        $("#fk_unit").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_unit").next("span").remove();
    }
});


$("#str_quantity").keyup(function () {
    var str_quantity = $("#str_quantity").val();
    $("#str_quantity").next("span").remove();
    if (str_quantity == "") {
        $("#str_quantity").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_quantity").next("span").remove();
    }
});

$("#dt_closingtime").keyup(function () {
    var dt_closingtime = $("#dt_closingtime").val();
    $("#dt_closingtime").next("span").remove();
    if (dt_closingtime == "") {
        $("#dt_closingtime").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dt_closingtime").next("span").remove();
    }
});



$("#str_resevedprice").keyup(function () {
    var str_resevedprice = $("#str_resevedprice").val();
    $("#str_resevedprice").next("span").remove();
    if (str_resevedprice == "") {
        $("#str_resevedprice").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_resevedprice").next("span").remove();
    }
});


function error() {
    var noerror = 1;


    if ($("#fk_productid").val() == "") {
        $("#fk_productid").next("span").remove();
        $("#fk_productid").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_quantity").val() == "") {
        $("#str_quantity").next("span").remove();
        $("#str_quantity").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#dt_closingtime").val() == "") {
        $("#dt_closingtime").next("span").remove();
        $("#dt_closingtime").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_resevedprice").val() == "") {
        $("#str_resevedprice").next("span").remove();
        $("#str_resevedprice").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_currency").val() == "") {
        $("#str_currency").next("span").remove();
        $("#str_currency").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#fk_unit").val() == "") {
        $("#fk_unit").next("span").remove();
        $("#fk_unit").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    
    if (noerror == 1) {
        $('#spinner').show();
        if (confirm("Are you sure ?")) {
            if ($('#tbl_mst_SpotbookingOrders')[0].checkValidity()) {
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



//$("#fltProductPrice").ForceNumericOnly();



$("#str_quantity").on("input", function () {
    LimitCharacters(this, 18);
});

$("#str_resevedprice").on("input", function () {
    LimitCharacters(this, 18);
});
function LimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:Red'> Max Length reached..</span>");
    }
}

