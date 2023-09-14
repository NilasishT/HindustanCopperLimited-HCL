function error() {
var noerror = 1;
    if ($("#strFinancialYear").val() == "") {
        $("#strFinancialYear").next("span").remove();
        $("#strFinancialYear").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#intPeriodInMonths").val() == "") {
        $("#intPeriodInMonths").next("span").remove();
        $("#intPeriodInMonths").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    
    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#tbl_transaction_Student_Workshop')[0].checkValidity()) {
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


$("#strFinancialYear").on("input", function () {
    LimitCharacters(this, 10);
});
$("#intPeriodInMonths").on("input", function () {
    LimitCharacters(this, 4);
});





function LimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:Red'> Max Length reached..</span>");
    }

}


$("#intPeriodInMonths").ForceNumericOnly();


$("#intPeriodInMonths").keyup(function () {

    var intPeriodInMonths = $("#intPeriodInMonths").val();
    $("#intPeriodInMonths").next("span").remove();
    if (intPeriodInMonths == "") {
        $("#intPeriodInMonths").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#intPeriodInMonths").next("span").remove();
    }
});

$("#strFinancialYear").keyup(function () {

    var strFinancialYear = $("#strFinancialYear").val();
    $("#strFinancialYear").next("span").remove();
    if (strFinancialYear == "") {
        $("#strFinancialYear").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strFinancialYear").next("span").remove();
    }
});


