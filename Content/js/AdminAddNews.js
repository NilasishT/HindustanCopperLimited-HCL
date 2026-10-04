


function error() {

    debugger;
    var noerror = 1;
    var strNewsType = $('#strNewsType').val();
    var strSubjectdfsEnglish = $('#strSubjectdfsEnglish').val();
    var dtExpiryDate = $('#dtExpiryDate').val();
    var strFileEnglish = $('#strFileEnglish').val();
    var strSubjectdfshindi = $('#strSubjectdfshindi').val();
    var strFileHindi = $('#strFileHindi').val();


    if (strNewsType == "") {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (strSubjectdfsEnglish == "") {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (strSubjectdfshindi == "") {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (dtExpiryDate == "") {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    //    if ($("HidFile").val() == undefined)
    //if ($("#strFileEnglish") == undefined || $("#strFileEnglish").val() == "")
    // {
    //    $("#errmsg4").html('This field is required').show().css("color", "red");
    //    noerror = 0;
    //}
    //if ($("#strFileHindi") == undefined || $("#strFileHindi").val() == "") {
    //    $("#errmsg6").html('This field is required').show().css("color", "red");
    //    noerror = 0;
    //}

    if (!strFileEnglish || strFileEnglish.trim() === "") {
        $("#errmsg4").html('This field is required').show().css("color", "red");
        noerror = 0;
    } else {
        $("#errmsg4").html('');
    }

    // Hindi file validation
    if (!strFileHindi || strFileHindi.trim() === "") {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        noerror = 0;
    } else {
        $("#errmsg6").html('');
    }

    if (noerror == 1) {

        if (confirm("Are You Sure?")) {
            if ($('#AdminAddNews')[0].checkValidity()) {
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



$("#strSubjectdfsEnglish").on("input", function () {
    LimtCharacters(this, 500, 'errmsg2');
});

$("#strSubjectdfshindi").on("input", function () {
    LimtCharacters(this, 500, 'errmsg5');
});




$("#strNewsType").change(function () {
    //    alert("OK");
    if (this.value.length == 0) {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg1").html('');
    }
});

$("#strSubjectdfsEnglish").keyup(function () {

    if (this.value.length == 0) {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        return false;
    }
    else {
        $("#errmsg2").html('');
    }
});

$("#strSubjectdfshindi").keyup(function () {

    if (this.value.length == 0) {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        return false;
    }
    else {
        $("#errmsg5").html('');
    }
});

$("#strFileEnglish").change(function () {
    $("#HidFile").val(this.value);
    $("#errmsg4").html('');
});

$("#strFileHindi").change(function () {
    $("#HidFile1").val(this.value);
    $("#errmsg6").html('');
});





function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}