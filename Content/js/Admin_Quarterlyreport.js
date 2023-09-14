
$("#numSalesData").keyup(function () {
    var numSalesData = $("#numSalesData").val();
    $("#numSalesData").next("span").remove();
    if (numSalesData == "") {
        $("#numSalesData").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#numSalesData").next("span").remove();
    }
});


$("#QuarterId").change(function () {

    var QuarterId = $("#QuarterId").val();
    $("#QuarterId").next("span").remove();
    if (QuarterId == "") {
        $("#QuarterId").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#QuarterId").next("span").remove();
    }
});
$("#ItemId").change(function () {

    var ItemId = $("#ItemId").val();
    $("#ItemId").next("span").remove();
    if (ItemId == "") {
        $("#ItemId").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#ItemId").next("span").remove();
    }
});



$("#txtData").change(function () {

    var txtData = $("#txtData").val();
    $("#txtData").next("span").remove();
    if (txtData == "") {
        $("#txtData").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#txtData").next("span").remove();
    }
});


$("#numYear").change(function () {

    var numYear = $("#numYear").val();
    $("#numYear").next("span").remove();
    if (numYear == "") {
        $("#numYear").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#numYear").next("span").remove();
    }
});


$("#numSalesData").on("input", function () {
    LimtCharacters(this, 15);
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

    if ($("#numSalesData").val() == "") {
        $("#numSalesData").next("span").remove();
        $("#numSalesData").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#QuarterId").val() == "") {
        $("#QuarterId").next("span").remove();
        $("#QuarterId").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#ItemId").val() == "") {
        $("#ItemId").next("span").remove();
        $("#ItemId").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#txtData").val() == "") {
        $("#txtData").next("span").remove();
        $("#txtData").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#numYear").val() == "") {
        $("#numYear").next("span").remove();
        $("#numYear").after("<span style='color:Red'> This field is required</span>");
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