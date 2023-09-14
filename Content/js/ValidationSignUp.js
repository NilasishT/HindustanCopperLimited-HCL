var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

function error() {

 var noerror = 1;
 var Fk_intUnitId = $('#Fk_intUnitId').val();
 var strusertype = $('#strusertype').val();
 var strUserName = $('#strUserName').val();
 var strUserPwd = $('#strUserPwd').val();
 var strEmail = $('#strEmail').val();
 var strDesignation = $('#strDesignation').val();

 var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

 $('#hid_strMenuRightID').val($('#strMenuRightID').multipleSelect('getSelects'))
 var boolCheck = true;

 if ($('#strMenuRightID').multipleSelect('getSelects') == '' || $('#strMenuRightID').multipleSelect('getSelects') == null) {
     alert('Please select Menu');
     boolCheck = false;
 }

// if (Fk_intUnitId == "") {
//     $("#errmsg4").html('This field is required').show().css("color", "red");
//     noerror = 0;
// }


 if (strusertype == "") {
     $("#errmsg5").html('This field is required').show().css("color", "red");
     noerror = 0;
 }

 if (strUserName == "" ) {
     $("#errmsg").html('This field is required').show().css("color", "red");
     noerror = 0;
 }


// if (strUserPwd == "") {
//     $("#errmsg1").html('This field is required').show().css("color", "red");
//     noerror = 0;
// }

 if (strUserPwd.length < 6) {
     $("#strUserPwd").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
     noerror = 0;
 }

 
// if (strEmail =="") {
//     $("#errmsg2").html('This field is required').show().css("color", "red");
//     noerror = 0;
// }

 if (!emailReg.test(strEmail)) {
     $("#strEmail").html('Please enter a valid email address').show().css("color", "red");
     $("#strEmail").after("<span style='color:Red'>Please enter a valid email address</span>");
     noerror = 0;
 }

 if (!emailReg.test(strEmail)) {
     $("#errmsg2").html('Please enter a valid email address').show().css("color", "red");
     noerror = 0;
 }

 if (strDesignation =="") {
     $("#errmsg3").html('This field is required').show().css("color", "red");
     noerror = 0;
 }


 if (noerror == 1) {
     if (confirm("Are you sure ?")) {

         if ($('#ValidationEmployee')[0].checkValidity()) {
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


$('#strMenuRightID').multipleSelect({
    isOpen: true,
    keepOpen: true,
    selectAll: true,
    minimumCountSelected: 1,
    single: false,
    maxHeight: 150

});

var MenuRightID = $("#hid_strMenuRightID").val();

if (MenuRightID != "") {
    var data = $("#hid_strMenuRightID").val();
    var dataarray = data.split(",");
    $("#strMenuRightID").val(dataarray);
    $("#strMenuRightID").multipleSelect("refresh");
}


//$("#Fk_intUnitId").change(function () {
//    if (this.value.length == 0) {
//        $("#errmsg4").html('This field is required').show().css("color", "red");
//        return false;

//    } else {
//        $("#errmsg4").html('');
//    }
//});
$("#strusertype").change(function () {
    if (this.value.length == 0) {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg5").html('');
    }
});
$("#strUserName").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg").html('');
    }
});
//$("#strUserPwd").keyup(function () {
//    if (this.value.length == 0) {
//        $("#errmsg1").html('This field is required').show().css("color", "red");
//        return false;

//    } else {
//        $("#errmsg1").html('');
//    }
//});

$("#strUserPwd").keyup(function () {
    var strUserPwd = $("#strUserPwd").val();
    $("#strUserPwd").next("span").remove();
    if (strUserPwd == "") {
        $("#strUserPwd").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
    }
    else {
        $("#strUserPwd").next("span").remove();
    }
});

//$("#strpassword").keyup(function () {
//    $("#strpassword").next('span').remove();
//    if (this.value.length == 0) {
//        $("#strpassword").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
//        return false;

//    } else {
//        $("#errmsg1").html('');
//    }
//});


$("#strDesignation").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg3").html('');
    }
});

//$("#strEmail").keyup(function () {
//    if (emailReg.test(this.value)) {
//        $("#errmsg2").html('');
//    }
//    if (this.value == '') {
//        $("#errmsg2").html('This field is required').show().css("color", "red");
//    }

//});



$("#strEmail").keyup(function () {
    if (!emailReg.test(this.value)) {
        $("#strEmail").html('Please enter a valid email address').show().css("color", "red");

    }
    else {
        $("#strEmail").html('');

    }
});



$("#strUserName").on("input", function () {
    LimtCharacters(this, 50, 'errmsg');
});
$("#strUserPwd").on("input", function () {
    LimtCharacters(this, 100, 'errmsg1');
});
$("#strEmail").on("input", function () {
    LimtCharacters(this, 100, 'errmsg2');
});
$("#strDesignation").on("input", function () {
    LimtCharacters(this, 50, 'errmsg3');
});

function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}