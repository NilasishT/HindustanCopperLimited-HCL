var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
$("#str_fname").keyup(function () {
    var str_fname = $("#str_fname").val();
    $("#str_fname").next("span").remove();
    if (str_fname == "") {
        $("#str_fname").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_fname").next("span").remove();
    }
});



$("#str_email").keyup(function () {
    var str_email = $("#str_email").val();
    $("#str_email").next("span").remove();
    if (str_email == "") {
        $("#str_email").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_email").next("span").remove();
    }
});
$("#str_email").keyup(function () {
    if (!emailReg.test($("#str_email").val())) {
        $("#str_email").next("span").remove();
        $("#str_email").after("<span style='color:Red'>Please Enter a Valid Email Address</span>");
        noerror = 0;
    }
});



$("#str_phone").keyup(function () {
    var str_phone = $("#str_phone").val();
    $("#str_phone").next("span").remove();

    if (str_phone.toString().length < 11 && str_phone != "") {
        $("#str_phone").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
    }
    else {
        $("#str_phone").next("span").remove();
    }

});
$("#str_mobile").keyup(function () {
    var str_mobile = $("#str_mobile").val();
    $("#str_mobile").next("span").remove();
    if (str_mobile == "") {
        $("#str_mobile").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_mobile").next("span").remove();
    }
});

$("#str_mobile").keyup(function () {
    var str_mobile = $("#str_mobile").val();
    $("#str_mobile").next("span").remove();
    if (str_mobile.toString().length < 10 && str_mobile != "") {
        $("#str_mobile").after("<span style='color:Red'>Mobile no. must be 10 digit</span>");
    }
    else {
        $("#str_mobile").next("span").remove();
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

$("#str_cnfrmpw").keyup(function () {
    var str_cnfrmpw = $("#str_cnfrmpw").val();
    $("#str_cnfrmpw").next("span").remove();
    if (str_cnfrmpw == "") {
        $("#str_cnfrmpw").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_cnfrmpw").next("span").remove();
    }
});

function error() {
    var noerror = 1;
    var str_phone = $("#str_phone").val();
    var str_mobile = $("#str_mobile").val();
    var email = $("#str_email").val();
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
if ($("#str_fname").val() == "") {
    $("#str_fname").next("span").remove();
    $("#str_fname").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    
    
    if ($("#str_email").val() == "") {
        $("#str_email").next("span").remove();
        $("#str_email").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (!emailReg.test(email)) {
       
        $("#str_email").next("span").remove();
        $("#str_email").after("<span style='color:Red'>Please enter valid Email </span>");
        noerror = 0;
    }

    if (str_phone.toString().length < 11 && str_phone != "") {
        $("#str_phone").next("span").remove();
        $("#str_phone").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
        noerror = 0;
    }
   
   
    
    if ($("#str_mobile").val() == "") {
        $("#str_mobile").next("span").remove();
        $("#str_mobile").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (str_mobile.toString().length < 10 && str_mobile != "") {
        $("#str_mobile").next("span").remove();
        $("#str_mobile").after("<span style='color:Red'>Mobile must be 10 digit</span>");
        noerror = 0;
    }

    if ($("#str_pw").val() == "") {
        $("#str_pw").next("span").remove();
        $("#str_pw").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_cnfrmpw").val() == "") {
        $("#str_cnfrmpw").next("span").remove();
        $("#str_cnfrmpw").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {
            if ($('#tbl_mst_CCOregistrations')[0].checkValidity()) {
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


$("#str_fname").on("input", function () {
    LimitCharacters(this, 50);
});
$("#str_lname").on("input", function () {
    LimitCharacters(this, 50);
});
$("#str_email").on("input", function () {
    LimitCharacters(this, 150);
});
$("#str_phone").on("input", function () {
    LimitCharacters(this, 11);
});
$("#str_mobile").on("input", function () {
    LimitCharacters(this, 10);
});
$("#str_cnfrmpw").on("input", function () {
    LimitCharacters(this, 10);
});
$("#str_pw").on("input", function () {
    LimitCharacters(this, 10);
});




function LimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:Red'> Max Length reached..</span>");
    }

}


$("#str_phone").ForceNumericOnly();
$("#str_mobile").ForceNumericOnly();




