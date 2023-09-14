function error() {
    var noerror = 1;



    if ($("#str_code").val() == "") {
        $("#str_code").next("span").remove();
        $("#str_code").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_pw").val() == "") {
        $("#str_pw").next("span").remove();
        $("#str_pw").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#SpotbookingRegistrationdetails')[0].checkValidity()) {
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

$("#str_code").keyup(function () {
    var str_code = $("#str_code").val();
    $("#str_code").next("span").remove();
    if (str_code == "") {
        $("#str_code").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_code").next("span").remove();
    }
});
$("#str_pw").keyup(function () {
    var str_pw = $("#str_pw").val();
    $("#str_pw").next("span").remove();
    if (str_pw == "") {
        $("#str_pw").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_pw").next("span").remove();
    }
});