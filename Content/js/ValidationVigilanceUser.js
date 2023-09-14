
var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

function error() {

    var noerror = 1;

    var vchFullName = $('#vchFullName').val();
    var vchUserName = $('#vchUserName').val();
    var vchPassword = $('#vchPassword').val();
    var dtmDob = $('#dtmDob').val();
    var dtmDoj = $('#dtmDoj').val();
    var vchGender = $('#vchGender').val();
    var vchEmpId = $('#vchEmpId').val();
    var vchEmailId = $('#vchEmailId').val();
    var vchOffNo = $('#vchOffNo').val();
    var vchMobNo = $('#vchMobNo').val();
    var vchFaxNo = $('#vchFaxNo').val();
    var vchPresAddress = $('#vchPresAddress').val();
    var vchPermAddress = $('#vchPermAddress').val();
    var vchPhotoPath = $('#vchPhotoPath').val();
    var vchReligion = $('#vchReligion').val();
    var vchUserStatus = $('#vchUserStatus').val();
    var vchUnitId = $('#vchUnitId').val();
    var vchDeptId = $('#vchDeptId').val();
    var vchAdminPrev = $('#vchAdminPrev').val();






    if ($("#vchFullName").val() == "") {
        $("#vchFullName").next("span").remove();
        $("#vchFullName").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchUserName").val() == "") {
        $("#vchUserName").next("span").remove();
        $("#vchUserName").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (vchPassword.length < 6) {
        $("#vchPassword").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
        noerror = 0;
    }

    if ($("#dtmDob").val() == "") {
        $("#dtmDob").next("span").remove();
        $("#dtmDob").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#dtmDoj").val() == "") {
        $("#dtmDoj").next("span").remove();
        $("#dtmDoj").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchGender").val() == "") {
        $("#vchGender").next("span").remove();
        $("#vchGender").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchEmpId").val() == "") {
        $("#vchEmpId").next("span").remove();
        $("#vchEmpId").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (!emailReg.test(vchEmailId)) {
        $("#vchEmailId").html('Please enter a valid email address').show().css("color", "red");
        $("#vchEmailId").after("<span style='color:Red'>Please enter a valid email address</span>");
        noerror = 0;
    }
    if (vchOffNo.toString().length < 11 && vchOffNo != "") {

        $("#vchOffNo").html('Ph No must be 11 digits').show().css("color", "red");
        $("#vchOffNo").after("<span style='color:Red'> Ph No must be 11 digits</span>");
        noerror = 0;
    }

    if (vchMobNo.toString().length < 10 && vchMobNo != "") {
        $("#vchMobNo").html('Mobile must be 10 digits').show().css("color", "red");
        $("#vchMobNo").after("<span style='color:Red'> Mobile must be 10 digits</span>");
        noerror = 0;
    }

//    if ($("#vchMobNo").val() == "") {
//        $("#vchMobNo").next("span").remove();
//        $("#vchMobNo").after("<span style='color:Red'> This field is required</span>");
//        noerror = 0;
//    }

    if (vchFaxNo.toString().length < 11 && vchFaxNo != "") {
        $("#vchFaxNo").html('Fax No must be 11 digits').show().css("color", "red");
        $("#vchFaxNo").after("<span style='color:Red'> Fax No must be 11 digits</span>");
        noerror = 0;
    }

//    if ($("#vchFaxNo").val() == "") {
//        $("#vchFaxNo").next("span").remove();
//        $("#vchFaxNo").after("<span style='color:Red'> This field is required</span>");
//        noerror = 0;
//    }
    if ($("#vchPresAddress").val() == "") {
        $("#vchPresAddress").next("span").remove();
        $("#vchPresAddress").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchPermAddress").val() == "") {
        $("#vchPermAddress").next("span").remove();
        $("#vchPermAddress").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchPhotoPath").val() == "") {
        $("#vchPhotoPath").next("span").remove();
        $("#vchPhotoPath").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchReligion").val() == "") {
        $("#vchReligion").next("span").remove();
        $("#vchReligion").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchUserStatus").val() == "") {
        $("#vchUserStatus").next("span").remove();
        $("#vchUserStatus").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchUnitId").val() == "") {
        $("#vchUnitId").next("span").remove();
        $("#vchUnitId").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchDeptId").val() == "") {
        $("#vchDeptId").next("span").remove();
        $("#vchDeptId").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#vchAdminPrev").val() == "") {
        $("#vchAdminPrev").next("span").remove();
        $("#vchAdminPrev").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    } 
    
    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#M_UserMaster')[0].checkValidity()) {
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



//Keyup&change

$("#vchFullName").change(function () {
    var vchFullName = $("#vchFullName").val();
    $("#vchFullName").next("span").remove();
    if (vchFullName == "") {
        $("#vchFullName").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchFullName").next("span").remove();
    }
});

$("#vchUserName").keyup(function () {
    var vchUserName = $("#vchUserName").val();
    $("#vchUserName").next("span").remove();
    if (vchUserName == "") {
        $("#vchUserName").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchUserName").next("span").remove();
    }
});

$("#vchPassword").keyup(function () {
    var vchPassword = $("#vchPassword").val();
    $("#vchPassword").next("span").remove();
    if (vchPassword == "") {
        $("#vchPassword").after("<span style='color:Red'> Password should have miniumum 6 characters</span>");
    }
    else {
        $("#vchPassword").next("span").remove();
    }
});

$("#dtmDob").change(function () {
    var dtmDob = $("#dtmDob").val();
    $("#dtmDob").next("span").remove();
    if (dtmDob == "") {
        $("#dtmDob").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dtmDob").next("span").remove();
    }
});

$("#dtmDoj ").change(function () {
    var dtmDoj = $("#dtmDoj ").val();
    $("#dtmDoj ").next("span").remove();
    if (dtmDoj == "") {
        $("#dtmDoj ").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dtmDoj ").next("span").remove();
    }
});

$("#vchGender").change(function () {
    var vchGender= $("#vchGender").val();
    $("#vchGender").next("span").remove();
    if (vchGender== "") {
        $("#vchGender").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchGender").next("span").remove();
    }
});

$("#vchEmpId").keyup(function () {
    var vchEmpId = $("#vchEmpId").val();
    $("#vchEmpId").next("span").remove();
    if (vchEmpId == "") {
        $("#vchEmpId").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchEmpId").next("span").remove();
    }
});

$("#vchEmailId").keyup(function () {
    if (!emailReg.test(this.value)) {
        $("#vchEmailId").html('Please enter a valid email address').show().css("color", "red");

    }
    else {
        $("#vchEmailId").html('');

    }
});


$("#vchOffNo").keyup(function () {
    if (this.value.length == 0) {
        $("#vchOffNo").html('This field is required').show().css("color", "red");
        return false;
    }
    if (this.value.length < 11) {
        $("#vchOffNo").html('Ph No must be 11 digits').show().css("color", "red");
        return false;
    }
    else {
        $("#vchOffNo").html('');
    }
});



$("#vchMobNo").keyup(function () {
    if (this.value.length == 0) {
        $("#vchMobNo").html('This field is required').show().css("color", "red");
        return false;
    }
    else if (this.value.length < 10) {
        $("#vchMobNo").html('Mobile No must be 10 digit').show().css("color", "red");
        return false;
    }

    else {
        $("#vchMobNo").html('');
    }
});

$("#vchFaxNo").keyup(function () {
    if (this.value.length == 0) {
        $("#vchFaxNo").html('This field is required').show().css("color", "red");
        return false;
    }
    if (this.value.length < 11) {
        $("#vchFaxNo").html('Ph No must be 11 digits').show().css("color", "red");
        return false;
    }
    else {
        $("#vchFaxNo").html('');
    }
});

$("#vchPresAddress").keyup(function () {
    var vchPresAddress = $("#vchPresAddress").val();
    $("#vchPresAddress").next("span").remove();
    if (vchPresAddress == "") {
        $("#vchPresAddress").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchPresAddress").next("span").remove();
    }
});

$("#vchPermAddress").keyup(function () {
    var vchPermAddress = $("#vchPermAddress").val();
    $("#vchPermAddress").next("span").remove();
    if (vchPermAddress == "") {
        $("#vchPermAddress").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchPermAddress").next("span").remove();
    }
});

$("#vchPhotoPath").keyup(function () {
    var vchPhotoPath = $("#vchPhotoPath").val();
    $("#vchPhotoPath").next("span").remove();
    if (vchPhotoPath == "") {
        $("#vchPhotoPath").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchPhotoPath").next("span").remove();
    }
});

$("#vchReligion").change(function () {
    var vchReligion = $("#vchReligion").val();
    $("#vchReligion").next("span").remove();
    if (vchReligion == "") {
        $("#vchReligion").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchReligion").next("span").remove();
    }
});

$("#vchUserStatus").change(function () {
    var vchUserStatus = $("#vchUserStatus").val();
    $("#vchUserStatus").next("span").remove();
    if (vchUserStatus == "") {
        $("#vchUserStatus").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchUserStatus").next("span").remove();
    }
});

$("#vchUnitId").change(function () {
    var vchUnitId = $("#vchUnitId").val();
    $("#vchUnitId").next("span").remove();
    if (vchUnitId == "") {
        $("#vchUnitId").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchUnitId").next("span").remove();
    }
});

$("#vchDeptId").change(function () {
    var vchDeptId = $("#vchDeptId").val();
    $("#vchDeptId").next("span").remove();
    if (vchDeptId == "") {
        $("#vchDeptId").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchDeptId").next("span").remove();
    }
});

$("#vchAdminPrev").change(function () {
    var vchAdminPrev = $("#vchAdminPrev").val();
    $("#vchAdminPrev").next("span").remove();
    if (vchAdminPrev == "") {
        $("#vchAdminPrev").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#vchAdminPrev").next("span").remove();
    }
});

//characterlimit   
$("#vchFullName").on("input", function () {
    LimtCharacters(this, 50);
});

$("#vchUserName").on("input", function () {
    LimtCharacters(this, 60);
});

$("#vchPassword").on("input", function () {
    LimtCharacters(this, 60);
});
$("#vchGender").on("input", function () {
    LimtCharacters(this, 50);
});
$("#vchEmpId").on("input", function () {
    LimtCharacters(this, 50);
});
$("#vchEmailId").on("input", function () {
    LimtCharacters(this, 60);
});

$("#vchOffNo").on("input", function () {
    LimtCharacters(this, 11);
});
$("#vchMobNo").on("input", function () {
    LimtCharacters(this, 10);
});
$("#vchFaxNo").on("input", function () {
    LimtCharacters(this, 11);
});

$("#vchPresAddress").on("input", function () {
    LimtCharacters(this, 200);
});
$("#vchPermAddress").on("input", function () {
    LimtCharacters(this, 200);
});
$("#vchPhotoPath").on("input", function () {
    LimtCharacters(this, 200);
});
$("#vchReligion").on("input", function () {
    LimtCharacters(this, 20);
});

$("#vchUserStatus").on("input", function () {
    LimtCharacters(this, 20);
});
$("#vchUnitId").on("input", function () {
    LimtCharacters(this, 250);
});
$("#vchDeptId").on("input", function () {
    LimtCharacters(this, 250);
});

$("#vchAdminPrev").on("input", function () {
    LimtCharacters(this, 5);
});
function LimtCharacters(txtMsg, CharLength) {
    $(txtMsg).next("span").remove();
    chars = txtMsg.value.length;
    if (chars > CharLength && chars > 0) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $(txtMsg).after("<span style='color:Red'> Max Length reached..</span>");
    }
}
