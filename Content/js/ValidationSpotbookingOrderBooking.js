$("#strProducts").change(function () {

    var strProducts = $("#strProducts").val();
    $("#strProducts").next("span").remove();
    if (strProducts == "") {
        $("#strProducts").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strProducts").next("span").remove();
    }
});

$("#strOrderType").change(function () {

    var strOrderType = $("#strOrderType").val();
    $("#strOrderType").next("span").remove();
    if (strOrderType == "") {
        $("#strOrderType").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strOrderType").next("span").remove();
    }
});

$("#strOrderOption").change(function () {

    var strOrderOption = $("#strOrderOption").val();
    $("#strOrderOption").next("span").remove();
    if (strOrderOption == "") {
        $("#strOrderOption").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strOrderOption").next("span").remove();
    }
});

$("#strLiftingOption").change(function () {

    var strLiftingOption = $("#strLiftingOption").val();
    $("#strLiftingOption").next("span").remove();
    if (strLiftingOption == "") {
        $("#strLiftingOption").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strLiftingOption").next("span").remove();
    }
});

$("#tmRealBookingTime").change(function () {

    var tmRealBookingTime = $("#tmRealBookingTime").val();
    $("#tmRealBookingTime").next("span").remove();
    if (tmRealBookingTime == "") {
        $("#tmRealBookingTime").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#tmRealBookingTime").next("span").remove();
    }
});

$("#fltBookedQuantity").keyup(function () {
    var fltBookedQuantity = $("#fltBookedQuantity").val();
    $("#fltBookedQuantity").next("span").remove();
    if (fltBookedQuantity == "") {
        $("#fltBookedQuantity").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fltBookedQuantity").next("span").remove();
    }
});

$("#str_deliveryplace").change(function () {
    var str_deliveryplace = $("#str_deliveryplace").val();
    $("#str_deliveryplace").next("span").remove();
    if (str_deliveryplace == "") {
        $("#str_deliveryplace").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_deliveryplace").next("span").remove();
    }
});

function error() {
    

    var noerror = 1;
    if ($("#hidPrice").val() == "required" && $("#fltProductPrice").val() == "") {
        $("#fltProductPrice").next("span").remove();
        $("#fltProductPrice").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#hidPrice").val() == "required" && $("#fltProductPrice").val() == "0" && $("#fltProductPrice").val() != "") {
        $("#fltProductPrice").next("span").remove();
        $("#fltProductPrice").after("<span style='color:Red'> Product Price must be greater than 0 </span>");
        noerror = 0;
    }

    if ($("#strProducts").val() == "" || $("#strProducts").val() == "0") {
        $("#strProducts").next("span").remove();
        $("#strProducts").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ( parseInt($("#hidfltBookedQuantity").val()) <  parseInt($("#fltBookedQuantity").val() )) {
        $("#fltBookedQuantity").next("span").remove();
        $("#fltBookedQuantity").after("<span style='color:Red'> Booked Qty <= Tender Qty</span>");
        noerror = 0;
    }

    if (parseInt($("#hidfltProductPrice").val()) > parseInt($("#fltProductPrice").val())) {
        $("#fltProductPrice").next("span").remove();
        $("#fltProductPrice").after("<span style='color:Red'> Product Offer Price>= Reserve Price</span>");
        noerror = 0;
    }

    if ($("#strOrderType").val() == "" || $("#strOrderType").val() == "0") {
        $("#strOrderType").next("span").remove();
        $("#strOrderType").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strOrderOption").val() == "" || $("#strOrderOption").val() == "0") {
        $("#strOrderOption").next("span").remove();
        $("#strOrderOption").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strLiftingOption").val() == "" || $("#strLiftingOption").val() == "0") {
        $("#strLiftingOption").next("span").remove();
        $("#strLiftingOption").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#tmRealBookingTime").val() == "" || $("#tmRealBookingTime").val() == "0") {
        $("#tmRealBookingTime").next("span").remove();
        $("#tmRealBookingTime").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#fltBookedQuantity").val() == "" || $("#fltBookedQuantity").val() == "0") {
        $("#fltBookedQuantity").next("span").remove();
        $("#fltBookedQuantity").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_deliveryplace").val() == "" || $("#str_deliveryplace").val() == "0") {
        $("#str_deliveryplace").next("span").remove();
        $("#str_deliveryplace").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    



   

    if (noerror == 1) {
        $('#spinner').show();
        if (confirm("Are you sure ?")) {
            if ($('#tbl_mst_SpotbookingOrders')[0].checkValidity()) {                
            }
        }
        else {
            $('#spinner').hide(); 
            return false;
        }
    }

    if (noerror == 0) {
        return false;
    }
}



$("#fltProductPrice").numeric();
$("#fltBookedQuantity").numeric();



$("#strComments").on("input", function () {
    LimitCharacters(this, 100);
});
function LimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:Red'> Max Length reached..</span>");
    }
}

