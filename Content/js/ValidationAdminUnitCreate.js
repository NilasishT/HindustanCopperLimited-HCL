


function error() {


    var noerror = 1;
    var strUnitName = $('#strUnitName').val();
    var strUnitCode = $('#strUnitCode').val();
    var strUnitAddress = $('#strUnitAddress').val();
    var strContactInfo = $('#strContactInfo').val();




    if (strUnitName == "") {
        $("#errmsg").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (strUnitCode == "") {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    if (strUnitAddress == "") {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        noerror = 0;
    }



    if (strContactInfo == "") {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    if (noerror == 1) {

        if (confirm("Are You Sure?")) {
            if ($('#ValidationAdminUnitCreate')[0].checkValidity()) {
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

$("#strUnitName").keyup(function () {

    if (this.value.length == 0) {

        $("#errmsg").html('This field is required').show().css("color", "red");

        return false;
            }
    else {
        $("#errmsg").html('');
    }

});




$("#strUnitCode").keyup(function () {

    if (this.value.length == 0) {

        $("#errmsg1").html('This field is required').show().css("color", "red");

        return false;
    }
    else {
        $("#errmsg1").html('');
    }


});




$("#strUnitAddress").keyup(function () {

    if (this.value.length == 0) {

        $("#errmsg2").html('This field is required').show().css("color", "red");

        return false;
    }
    else {
        $("#errmsg2").html('');
    }


});




$("#strContactInfo").keyup(function () {

    if (this.value.length == 0) {

        $("#errmsg3").html('This field is required').show().css("color", "red");

        return false;
    }
    else {
        $("#errmsg3").html('');
    }


});


$("#strUnitName").on("input", function () {
    LimtCharacters(this, 150, 'errmsg');
});
$("#strUnitCode").on("input", function () {
    LimtCharacters(this, 50, 'errmsg1');
});
$("#strUnitAddress").on("input", function () {
    LimtCharacters(this, 250, 'errmsg2');
});
$("#strContactInfo").on("input", function () {
    LimtCharacters(this, 250, 'errmsg3');
});
function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}