function error() {
    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;


    var names = $('#strpassword').val();
    var email = $('#strEmail').val();
    $('input,file,select,textarea').next('span').remove();

    if (names.length < 6) {
        $("#strpassword").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
        noerror = 0;
//        alert('should have miniumum 4 chars');
    }

    if (email == "") {
        $("#strEmail").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
//    if (names == "") {
//        $("#strpassword").after("<span style='color:Red'> This field is required</span>");
//        noerror = 0;
//    }

    if (!emailReg.test(email)) {
        $("#strEmail").after("<span style='color:Red'> Please enter a valid email address</span>");
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



$("#strpassword").keyup(function () {
    $("#strpassword").next('span').remove();
    if (this.value.length == 0) {
        $("#strpassword").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
        return false;

    } else {
        $("#errmsg1").html('');
    }
});

$("#strEmail").keyup(function () {
    $("#strEmail").next('span').remove();
    if (this.value == "") {
        $("#strEmail").after("<span style='color:Red'> This field is required</span>");
        return false;

    } else {
        $("#errmsg2").html('');
    }
});