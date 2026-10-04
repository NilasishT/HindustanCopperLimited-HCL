


function error() {


    var noerror = 1;
    var dtFromDate = $('#dtFromDate').val();
    var dtToDate = $('#dtToDate').val();
    var strVendorName = $('#strVendorName').val();
    var strRemarks = $('#strRemarks').val();
    var unit = $('#strRemarks').val();




    if (dtFromDate == "") {
        $("#errmsg").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (dtToDate == "") {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    if (strVendorName == "") {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

//    if (strVendorCode == 0 || strVendorCode == undefined) {
//     $("#errmsg2").html('This field is required').show().css("color", "red");
//     noerror = 0;
// }

    if (strRemarks == "") {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (unit == "") {
        $("#errmsg4").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (noerror == 1) {

        if (confirm("Are You Sure?")) {
            if ($('#AdminVendorBlackListed')[0].checkValidity()) {
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

//$("#dtFromDate").change(function () {

//    if (this.value.length == 0) {

//        $("#errmsg").html('This field is required').show().css("color", "red");

//        return false;
//    }
//    else {
//        $("#errmsg").html('');
//    }

//});




//$("#dtToDate").change(function () {

//    if (this.value.length == 0) {

//        $("#errmsg1").html('This field is required').show().css("color", "red");

//        return false;
//    }
//    else {
//        $("#errmsg1").html('');
//    }


//});




$("#strVendorName").change(function () {
//    alert("OK");
    if (this.value.length == 0) {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg2").html('');
    }
});


$("#strRemarks").keyup(function () {

    if (this.value.length == 0) {

        $("#errmsg3").html('This field is required').show().css("color", "red");

        return false;
    }
    else {
        $("#errmsg3").html('');
    }


});


$("#strRemarks").on("input", function () {
    LimtCharacters(this, 100, 'errmsg3');
});
function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}