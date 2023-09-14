var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

  
        $(document).on('input', 'input', function (e) {
            var keyCode = e.keyCode || e.which;

            //  $("#lblError").html("");

            //Regex for Valid Characters i.e. Alphabets and Numbers.
            var regex = /^[. @/A-Za-z0-9]+$/;

            //Validate TextBox value against the Regex.
            var value = this.value;
            var isValid = regex.test(value);
            if (!isValid && this.value != '') {
                //  $("#lblError").html("Only Alphabets and Numbers allowed.");
                // alert("Special Character Not Allowed");
                e.preventDefault();
            }
            var newValue = '';
            for (var i = 0; i < value.length; i++) {
                if (regex.test(value[i]) || value[i] == '') {
                    newValue += value[i];
                }
            }
            this.value = newValue;

            return isValid;
        });
       

    $(document).on('keypress', 'textarea', function (event) {
            var regex = new RegExp("^[. @/A-Za-z0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
    return false;
            }
        });

$("#str_namefirm").keyup(function () {
    var str_namefirm = $("#str_namefirm").val();
    $("#str_namefirm").next("span").remove();
    if (str_namefirm == "") {
        $("#str_namefirm").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_namefirm").next("span").remove();
    }
});


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
    $("#str_email").next("span").remove();
    if (emailReg.test($("#str_email").val())) {
        $("#str_email").next("span").remove();
    }
    else {
        $("#str_email").after("<span style='color:Red'>Please Enter a Valid Email Address</span>");
    }
});


$("#str_address").keyup(function () {
    var str_address = $("#str_address").val();
    $("#str_address").next("span").remove();
    if (str_address == "") {
        $("#str_address").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_address").next("span").remove();
    }
});


$("#str_city").keyup(function () {
    var str_city = $("#str_city").val();
    $("#str_city").next("span").remove();
    if (str_city == "") {
        $("#str_city").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_city").next("span").remove();
    }
});


$("#str_district").keyup(function () {
    var str_district = $("#str_district").val();
    $("#str_district").next("span").remove();
    if (str_district == "") {
        $("#str_district").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_district").next("span").remove();
    }
});

$("#fk_region").change(function () {
    var fk_region = $("#fk_region").val();
    $("#fk_region").next("span").remove();
    if (str_state == "") {
        $("#fk_region").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_region").next("span").remove();
    }
});


$("#str_state").change(function () {
    var str_state = $("#str_state").val();
    $("#str_state").next("span").remove();
    if (str_state == "") {
        $("#str_state").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_state").next("span").remove();
    }
});


$("#str_country").change(function () {
    var str_country = $("#str_country").val();
    $("#str_country").next("span").remove();
    if (str_country == "") {
        $("#str_country").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_country").next("span").remove();
    }
});
$("#str_pw").keyup(function () {
    var str_pw = $("#str_pw").val();
    $("#str_pw").next("span").remove();
    if (str_pw == "") {
        $("#str_pw").after("<span style='color:Red'> This field is required</span>");
    }
    else if (str_pw.toString().length < 8) {
        $("#str_pw").after("<span style='color:Red'>Password must be 8 digit</span>");
    }
    else {
        $("#str_pw").next("span").remove();
    }
});

$("#str_confirmpw").keyup(function () {

    var str_confirmpw = $("#str_confirmpw").val();
    $("#str_confirmpw").next("span").remove();
    if (str_confirmpw == "") {
        $("#str_confirmpw").after("<span style='color:Red'> This field is required</span>");
    }
    else if (str_confirmpw.toString().length < 8) {
        $("#str_confirmpw").after("<span style='color:Red'>Password must be 8 digit</span>");
    }
    else {
        $("#str_confirmpw").next("span").remove();
    }
});

//$("#str_phno").keyup(function () {

//    var phno = $("#str_phno").val();
//    $("#str_phno").next("span").remove();
//    if (phno == "") {
//        $("#str_phno").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#str_phno").next("span").remove();
//    }
//});

$("#str_phno").keyup(function () {
    var str_phno = $("#str_phno").val();
    $("#str_phno").next("span").remove();

    if (str_phno.toString().length < 11 && str_phno != "") {
        $("#str_phno").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
    }
    else {
        $("#str_phno").next("span").remove();
    }

});

//$("#str_officeno").keyup(function () {
//    var str_officeno = $("#str_officeno").val();
//    $("#str_officeno").next("span").remove();
//    if (str_officeno == "") {
//        $("#str_officeno").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#str_officeno").next("span").remove();
//    }
//});



//$("#str_officeno").keyup(function () {
//    var str_officeno = $("#str_officeno").val();
//    $("#str_officeno").next("span").remove();
//    if (str_officeno == "") {
//        $("#str_officeno").after("<span style='color:Red'> This field is required</span>");
//    }
//    else if (str_officeno.toString().length < 11 ) {
//        $("#str_officeno").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
//    }
//    else {
//        $("#str_officeno").next("span").remove();
//    }
//});



$("#str_fax").keyup(function () {
    var str_fax = $("#str_fax").val();
    $("#str_fax").next("span").remove();

     if (str_fax.toString().length < 11 && str_fax != "") {
        $("#str_fax").after("<span style='color:Red'>Fax must be 11 digit</span>");
    }
    else {
        $("#str_fax").next("span").remove();
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



$("#str_mobile").change(function () {
    var str_mobile = $("#str_mobile").val();
    $("#str_mobile").next("span").remove();
    if (str_mobile == "") {
        $("#str_mobile").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_mobile").next("span").remove();
    }
});

//$("#str_pin").keyup(function () {

//    var str_pin = $("#str_pin").val();
//    $("#str_pin").next("span").remove();
//    if (str_pin == "") {
//        $("#str_pin").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#str_pin").next("span").remove();
//    }
//});
$("#str_pin").keyup(function () {
    var str_pin = $("#str_pin").val();
    $("#str_pin").next("span").remove();
    if (str_pin == "") {
        $("#str_pin").after("<span style='color:Red'> This field is required</span>");
    }
    else if (str_pin.toString().length < 6 ) {
        $("#str_pin").after("<span style='color:Red'>Pin must be 6 digit</span>");
    }
    else {
        $("#str_pin").next("span").remove();
    }
});

//$("#str_gstno").keyup(function () {

//    var str_gstno = $("#str_gstno").val();
//    $("#str_gstno").next("span").remove();
//    if (str_gstno == "") {
//        $("#str_gstno").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#str_gstno").next("span").remove();
//    }
//});
$("#str_gstno").keyup(function () {
    var str_gstno = $("#str_gstno").val();
    $("#str_gstno").next("span").remove();
    if (str_gstno == "") {
        $("#str_gstno").after("<span style='color:Red'> This field is required</span>");
    }
    else if (str_gstno.toString().length < 15 && str_gstno != "") {
        $("#str_gstno").after("<span style='color:Red'>Gst No. must be 15 digit</span>");
    }
    else {
        $("#str_gstno").next("span").remove();
    }
});
//Numeric
$("#str_phno").ForceNumericOnly();
$("#str_officeno").ForceNumericOnly();
$("#str_mobile").ForceNumericOnly();
$("#str_fax").ForceNumericOnly();
$("#str_pin").ForceNumericOnly();
//Limit Charcter
$("#str_namefirm").on("input", function () {
    LimtCharacters(this, 150);
});

$("#str_fname").on("input", function () {
    LimtCharacters(this, 40);
});
$("#str_mname").on("input", function () {
    LimtCharacters(this, 40);
});

$("#str_lname").on("input", function () {
    LimtCharacters(this, 40);
});
$("#str_email").on("input", function () {
    LimtCharacters(this, 80);
});
$("#str_phno").on("input", function () {
    LimtCharacters(this, 11);
});
$("#str_officeno").on("input", function () {
    LimtCharacters(this, 11);
});

$("#str_mobile").on("input", function () {
    LimtCharacters(this, 10);
});
$("#str_fax").on("input", function () {
    LimtCharacters(this, 11);
});
$("#str_address").on("input", function () {
    LimtCharacters(this, 280);
});
$("#str_city").on("input", function () {
    LimtCharacters(this, 30);
});
$("#str_district").on("input", function () {
    LimtCharacters(this, 30);
});
$("#str_pin").on("input", function () {
    LimtCharacters(this, 6);
});
$("#str_panno").on("input", function () {
    LimtCharacters(this, 15);
});
$("#str_gstno").on("input", function () {
    LimtCharacters(this, 15);
});

$("#str_pw").on("input", function () {
    LimtCharacters(this, 8);
});
$("#str_confirmpw").on("input", function () {
    LimtCharacters(this, 8);
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
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var str_phno = $("#str_phno").val();
    var email = $("#str_email").val();
    var str_mobile = $("#str_mobile").val();
    var str_officeno = $("#str_officeno").val();
    var str_fax = $("#str_fax").val();
    var strPin = $("#str_pin").val();
    var str_gstno = $("#str_gstno").val();
    var str_pw = $("#str_pw").val();
    var str_confirmpw = $("#str_confirmpw").val();
    var fk_region = $("#fk_region").val();

    if ($("#str_namefirm").val() == "") {
        $("#str_namefirm").next("span").remove();
        $("#str_namefirm").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#fk_region").val() == "") {
        $("#fk_region").next("span").remove();
        $("#fk_region").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

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
    
//    if ($("#str_officeno").val() == "") {
//        $("#str_officeno").next("span").remove();
//        $("#str_officeno").after("<span style='color:Red'> This field is required</span>");
//        noerror = 0;
//    }

    if ($("#str_mobile").val() == "") {
        $("#str_mobile").next("span").remove();
        $("#str_mobile").after("<span style='color:Red'> This field is required</span>");
           noerror = 0;
       }

    if ($("#str_address").val() == "") {
        $("#str_address").next("span").remove();
        $("#str_address").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#str_city").val() == "") {
        $("#str_city").next("span").remove();
        $("#str_city").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#str_district").val() == "") {
        $("#str_district").next("span").remove();
        $("#str_district").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_pin").val() == "") {
        $("#str_pin").next("span").remove();
        $("#str_pin").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_state").val() == "") {
        $("#str_state").next("span").remove();
        $("#str_state").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#str_country").val() == "") {
        $("#str_country").next("span").remove();
        $("#str_country").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#str_gstno").val() == "") {
        $("#str_gstno").next("span").remove();
        $("#str_gstno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
   
    if ($("#str_pw").val() == "") {
        $("#str_pw").next("span").remove();
        $("#str_pw").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_confirmpw").val() == "") {
        $("#str_confirmpw").next("span").remove();
        $("#str_confirmpw").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }



    if (str_phno.toString().length < 11 && str_phno != "") {
        $("#str_phno").next("span").remove();
        $("#str_phno").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
        noerror = 0;
    }
   
//    if (str_officeno.toString().length < 11 && str_officeno != "") {
//        $("#str_officeno").next("span").remove();
//        $("#str_officeno").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
//        noerror = 0;
//    }
    if (str_mobile.toString().length < 10 && str_mobile != "") {
        $("#str_mobile").next("span").remove();
        $("#str_mobile").after("<span style='color:Red'>Mobile must be 10 digit</span>");
        noerror = 0;
    }
    if (str_fax.toString().length < 11 && str_fax != "") {
        $("#str_fax").next("span").remove();
        $("#str_fax").after("<span style='color:Red'>Fax must be 11 digit</span>");
        noerror = 0;
    }

    if (!emailReg.test(email)) {
        $("#str_email").next("span").remove();
        $("#str_email").after("<span style='color:Red'>Please enter valid Email </span>");
        noerror = 0;
    }
    if (strPin.toString().length < 6 && strPin != "") {
        $("#str_pin ").next("span").remove();
        $("#str_pin ").after("<span style='color:Red'>Pin must be 6 digit</span>");
        noerror = 0;
    }
    if (str_gstno.toString().length < 15 && str_gstno != "") {
        $("#str_gstno").next("span").remove();
        $("#str_gstno").after("<span style='color:Red'>Gst No. must be 15 digit</span>");
        noerror = 0;
    }
    if (str_pw.toString().length < 8 && str_pw != "") {
        $("#str_pw").next("span").remove();
        $("#str_pw").after("<span style='color:Red'>Password must be 8 digit</span>");
        noerror = 0;
    }
    if (str_confirmpw.toString().length < 8 && str_confirmpw != "") {
        $("#str_confirmpw").next("span").remove();
        $("#str_confirmpw").after("<span style='color:Red'>Password must be 8 digit</span>");
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