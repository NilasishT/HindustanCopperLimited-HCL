


function error() {
    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var names = $('#strf_name').val();
    var names1 = $('#strl_name').val();
    var names2 = $('#str_address').val();
    var names3 = $('#str_state').val();
    var names4 = $('#str_country').val();
    var names5 = $('#str_comment').val();
    var names6 = $('#str_city').val();
    var email = $('#str_email').val();
    var telephone = $('#str_ph').val();
    var pin = $('#str_zipcode').val();
    var Fk_titleid = $('#Fk_titleid').val();

    if (names == "") {
        $("#errmsg").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (names1 == "") {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (names2 == "") {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (names3 == "") {
        $("#errmsg8").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (names4 == "") {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (names5 == "") {
        $("#errmsg10").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (names6 == "") {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (telephone.toString().length < 11 && telephone != "") {
        $("#errmsg4").html('Phone must be 11 digit').show().css("color", "red");
        noerror = 0;
    }
    if (pin.toString().length < 6 && pin !="") {
        $("#errmsg5").html('Pin must be 6 digit').show().css("color", "red");
        noerror = 0;
    }
    if (email == "") {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (!emailReg.test(email)) {
        $("#errmsg3").html('Please enter a valid email address').show().css("color", "red");
        noerror = 0;
    }


    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            return true;
        }
        else {
            return false;
        }

    }


    if (noerror == 0) {
        return false;

    }




}

$("#strf_name").keyup(function () {
    if (this.value != '') {
        $("#errmsg").html('');
    }
});

$("#strl_name").keyup(function () {
    if (this.value != '') {
        $("#errmsg2").html('');
    }
});

$("#str_email").keyup(function () {
    if (this.value != '') {
        $("#errmsg3").html('');
    }
});

$("#str_address").keyup(function () {
    if (this.value != '') {
        $("#errmsg6").html('');
    }
});

$("#str_city").keyup(function () {
    if (this.value != '') {
        $("#errmsg7").html('');
    }
});

$("#str_state").keyup(function () {
    if (this.value != '') {
        $("#errmsg8").html('');
    }
});

$("#str_country").keyup(function () {
    if (this.value != '') {
        $("#errmsg9").html('');
    }
});

$("#str_comment").keyup(function () {
    if (this.value != '') {
        $("#errmsg10").html('');
    }
});

$("#str_ph").bind("input", function () {
    Minimumcharaterlimit(this, 11, 'errmsg4', 'Phone must be 11 digit');
});


$("#str_zipcode").bind("input", function () {
    Minimumcharaterlimit(this, 11, 'errmsg5', 'Pin must be 6 digit');
});


function Minimumcharaterlimit(txtMsg, CharLength, errmsg, errmsgtext) {
    chars = txtMsg.value.length;
    if (chars > 0) {
        if (chars < CharLength) {
            txtMsg.value = txtMsg.value.substring(0, CharLength);
            $("#" + errmsg).html(errmsgtext).show().css("color", "red");
            return false;
        }
        else {
            $("#" + errmsg).html('');

        }
    }
    else {
        $("#" + errmsg).html('');


    }
}

$("#str_ph").ForceNumericOnly();
$("#str_zipcode").ForceNumericOnly();
//Limitcharacter

$("#strf_name").on("input", function () {
    LimtCharacters(this, 30, 'errmsg');
});
$("#strm_name").on("input", function () {
    LimtCharacters(this, 30, 'errmsg1');
});
$("#strl_name").on("input", function () {
    LimtCharacters(this, 30, 'errmsg2');
});
$("#str_email").on("input", function () {
    LimtCharacters(this, 30, 'errmsg3');
});
$("#str_ph").on("input", function () {
    LimtCharacters(this, 11, 'errmsg4');
});
$("#str_zipcode").on("input", function () {
    LimtCharacters(this, 6, 'errmsg5');
});
$("#str_address").on("input", function () {
    LimtCharacters(this, 100, 'errmsg6');
});
$("#str_city").on("input", function () {
    LimtCharacters(this, 20, 'errmsg7');
});
$("#str_state").on("input", function () {
    LimtCharacters(this, 30, 'errmsg8');
});
$("#str_country").on("input", function () {
    LimtCharacters(this, 35, 'errmsg9');
});
$("#str_comment").on("input", function () {
    LimtCharacters(this, 150, 'errmsg10');
});
$("#str_cntactp").on("input", function () {
    LimtCharacters(this, 35, 'errmsg11');
});

function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}




