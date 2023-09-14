function error() {
    var noerror = 1;


//    var CurrentPassword = $('#strUsercurrentPwd').val();
    var NewPassword = $('#strUserPwd').val();
    var RePassword = $('#strUserRePwd').val();
    $('input,file,select,textarea').next('span').remove();


    if ($("#strUsercurrentPwd").val() == "") {
        $("#strUsercurrentPwd").next("span").remove();
        $("#strUsercurrentPwd").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if (NewPassword.length < 6) {
        $("#strUserPwd").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
        noerror = 0;
    }

    if (RePassword.length < 6) {
        $("#strUserRePwd").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
        noerror = 0;
    }


    if (noerror == 1) {
        var pwdObj = document.getElementById('strUsercurrentPwd');
        var hashObj = new jsSHA("SHA-512", "TEXT", { numRounds: 1 });
        hashObj.update(pwdObj.value);
        var hash = hashObj.getHash("HEX");
        pwdObj.value = hash;

        var pwdObj = document.getElementById('strUserPwd');
        var hashObj = new jsSHA("SHA-512", "TEXT", { numRounds: 1 });
        hashObj.update(pwdObj.value);
        var hash = hashObj.getHash("HEX");
        pwdObj.value = hash;

        var pwdObj = document.getElementById('strUserRePwd');
        var hashObj = new jsSHA("SHA-512", "TEXT", { numRounds: 1 });
        hashObj.update(pwdObj.value);
        var hash = hashObj.getHash("HEX");
        pwdObj.value = hash;

        if (confirm("Are you sure ?")) {
            if ($('#tbl_mst_CandidateRegistrationForRecruitment')[0].checkValidity()) {
                $('#spinner').show();
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


$("#strUsercurrentPwd").keyup(function () {
    var strUsercurrentPwd = $("#strUsercurrentPwd").val();
    $("#strUsercurrentPwd").next("span").remove();
    if (strUsercurrentPwd == "") {
        $("#strUsercurrentPwd").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strUsercurrentPwd").next("span").remove();
    }
});


$("#strUserPwd").keyup(function () {
    $("#strUserPwd").next('span').remove();
    if (this.value.length == 0) {
        $("#strUserPwd").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
        return false;

    } else {
        $("#strUserPwd").next("span").remove();
    }
});

$("#strUserRePwd").keyup(function () {
    $("#strUserRePwd").next('span').remove();
    if (this.value == "") {
        $("#strUserRePwd").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
        return false;

    } else {
        $("#strUserRePwd").next("span").remove();
    }
});