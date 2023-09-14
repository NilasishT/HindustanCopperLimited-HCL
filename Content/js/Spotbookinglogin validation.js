function error() {
    var noerror = 1;



    if ($("#str_code").val() == "") {
        $("#str_code").next("span").remove();
        $("#str_code").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#str_pwNew").val() == "") {
        $("#str_pwNew").next("span").remove();
        $("#str_pwNew").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (noerror == 1) {

        $("#str_pw").val($("#str_pwNew").val());
        var pwdObj = document.getElementById('str_pwNew');
        var hashObj = new jsSHA("SHA-512", "TEXT", { numRounds: 1 });
        hashObj.update(pwdObj.value);
        var hash = hashObj.getHash("HEX");
        pwdObj.value = hash;
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

$(function () {
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
});

$(document).on('keypress', 'textarea', function (event) {
    var regex = new RegExp("^[. @/A-Za-z0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
});
