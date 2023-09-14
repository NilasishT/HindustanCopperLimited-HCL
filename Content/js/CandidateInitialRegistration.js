
debugger;
var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
$("#strMobileNumber").ForceNumericOnly();
$("#strAadharNo").ForceNumericOnly();

$("#strMobileNumber").keyup(function () {
    var strMobileNo = $("#strMobileNumber").val();
    $("#strMobileNumber").next("span").remove();
    if (strMobileNo.toString().length < 10 && strMobileNo != "") {
        $("#strMobileNumber").after("<span style='color:Red'>Mobile no. must be 10 digit</span>");
    }
    else {
        $("#strMobileNumber").val(strMobileNo.substring(0, 10));
        $("#strMobileNumber").next("span").remove();
    }
});

$("#strAadharNo").keyup(function () {
    var strAadharNo = $("#strAadharNo").val();
    $("#strAadharNo").next("span").remove();
    if (strAadharNo.toString().length < 12 && strAadharNo != "") {
        $("#strAadharNo").after("<span style='color:Red'>Aadhaar no. must be 12 digit</span>");
    }
    else {
        $("#strAadharNo").val(strAadharNo.substring(0, 12));
        $("#strAadharNo").next("span").remove();
    }
});

$("#strPANNo").keyup(function () {
    var strPANNo = $("#strPANNo").val();
    $("#strPANNo").next("span").remove();
    if (strPANNo.toString().length < 10 && strPANNo != "") {
        $("#strPANNo").after("<span style='color:Red'>PAN No. must be 10 digit</span>");
    }
    else {
        $("#strPANNo").val(strPANNo.substring(0, 10));
        $("#strPANNo").next("span").remove();
    }
});
debugger;
function error1() {

    //    var numberReg = /^[0-9]+$/;
   
    //    var lengthReg = /^[a-zA-Z]{10,15}$/;
    debugger;
    var noerror = 1;

    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var name = $('#strCandidateFName').val();
    var dob = $('#dtDOB').val();
    var mail = $('#strEmail').val();
   // var aaddhar = $('#strAadharNo').val();

    
 

    if (name == "") {
        $("#errmsg").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    

    if (dob == "") {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    if ($("#strMobileNumber").val() == "") {
        $("#strMobileNumber").after("<span style='color:Red'>This field is required</span>");
        noerror = 0;
    }
//    if ($("#strPANNo").val() == "") {
//        $("#strPANNo").after("<span style='color:Red'>This field is required</span>");
//        noerror = 0;
//    }
    //if ($("#strAadharNo").val() == "") {
    //    $("#strAadharNo").after("<span style='color:Red'>This field is required</span>");
    //    noerror = 0;
    //}

    //if ($('#strAadharNo').val()=="") {
    //  $("#errormsg").html('This field is required').show().css("color", "red");
    //  noerror = 0;
    //}


    
    if (mail == "") {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (!emailReg.test(mail)) {
        $("#errmsg2").html('Please enter a valid email address').show().css("color", "red");
        noerror = 0;
    }

    if (!emailReg.test($("#strAlternate_EmaiID").val())) {
        $("#strAlternate_EmaiID").after("<span style='color:Red'>Please enter a valid email address</span>");
        noerror = 0;
    }


    if (noerror == 1) {

        var pwdObj = document.getElementById('strpassword');
    var hashObj = new jsSHA("SHA-512", "TEXT", { numRounds: 1 });
    hashObj.update(pwdObj.value);
    var hash = hashObj.getHash("HEX");
    pwdObj.value = hash;

     if (confirm("Are you sure ?")) {
           if ($('#tbl_mst_CandidateRegistrationForRecruitment')[0].checkValidity()) {
               
           }
       }
       else {
           return false;
       }
    }

    if(noerror==0)
    {
     return false;
    }
}


$("#strCandidateFName").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg").html('');
    }
});


$("#dtDOB").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg1").html('');
    }
});






$("#strEmail").keyup(function () {
    if (this.value == "" || this.value == undefined) {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg2").html('');
    }
});


//$("#strAadharNo").keyup(function () {
//    if (this.value == "" || this.value == undefined) {
//        $("#adhrerrmsg1").html('This field is required').show().css("color", "red");
//        return false;

//    } else {
//        $("#adhrerrmsg").html('');
//    }
//});


$("#strCandidateFName").on("input", function () {
    LimtCharacters(this, 50, 'errmsg');
});
$("#dtDOB").on("input", function () {
    LimtCharacters(this, 60, 'errmsg1');
});
$("#strEmail").on("input", function () {
    LimtCharacters(this, 50, 'errmsg2');
});

function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}
