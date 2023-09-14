var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
function error() {
    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var email = $("#EMailId").val();
if ($("#F_Name").val() == "") {
    $("#F_Name").next("span").remove();
    $("#F_Name").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#EmpCd").val() == "") {
        $("#EmpCd").next("span").remove();
        $("#EmpCd").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#Department").val() == "") {
        $("#Department").next("span").remove();
        $("#Department").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    } 
    if ($("#Desg").val() == "") {
        $("#Desg").next("span").remove();
        $("#Desg").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#Password").val() == "") {
        $("#Password").next("span").remove();
        $("#Password").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchPassword").val() == "") {
        $("#vchPassword").next("span").remove();
        $("#vchPassword").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (!emailReg.test(email)) {
        $("#EMailId").next("span").remove();
        $("#EMailId").after("<span style='color:Red'>Please enter valid Email </span>");
        noerror = 0;
    }
    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#tbl_mstEmployee')[0].checkValidity()) {
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


$("#F_Name").on("input", function () {
    LimitCharacters(this, 250);
}); 
$("#Department").on("input", function () {
    LimitCharacters(this, 250);
});
$("#Desg").on("input", function () {
    LimitCharacters(this, 250);
});





function LimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:Red'> Max Length reached..</span>");
    }

}


$("#Phone").ForceNumericOnly();


$("#F_Name").keyup(function () {
    var F_Name = $("#F_Name").val();
    $("#F_Name").next("span").remove();
    if (F_Name == "") {
        $("#F_Name").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#F_Name").next("span").remove();
    }
});

$("#EmpCd").keyup(function () {
    var EmpCd = $("#EmpCd").val();
    $("#EmpCd").next("span").remove();
    if (EmpCd == "") {
        $("#EmpCd").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#EmpCd").next("span").remove();
    }
});

$("#Department").keyup(function () {
    var Department = $("#Department").val();
    $("#Department").next("span").remove();
    if (Department == "") {
        $("#Department").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Department").next("span").remove();
    }
});

$("#Desg").keyup(function () {
    var Desg = $("#Desg").val();
    $("#Desg").next("span").remove();
    if (Desg == "") {
        $("#Desg").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Desg").next("span").remove();
    }
});
$("#Password").keyup(function () {
    var Password = $("#Password").val();
    $("#Password").next("span").remove();
    if (Password == "") {
        $("#Password").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Password").next("span").remove();
    }
});
$("#vchPassword").keyup(function () {
    var vchPassword = $("#vchPassword").val();
    $("#vchPassword").next("span").remove();
    if (vchPassword == "") {
        $("#vchPassword").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchPassword").next("span").remove();
    }
});



$("#EMailId").keyup(function () {
    $("#EMailId").next("span").remove();
    if (emailReg.test($("#EMailId").val())) {
        $("#EMailId").next("span").remove();
    }
    else {
        $("#EMailId").after("<span style='color:Red'>Please Enter a Valid Email Address</span>");
    }
});