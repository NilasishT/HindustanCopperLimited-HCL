var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;


$("#strName").keyup(function () {
    var strName = $("#strName").val();
    $("#strName").next("span").remove();
    if (strName == "") {
        $("#strName").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strName").next("span").remove();
    }
});


$("#strname_Hindi").keyup(function () {
    var strname_Hindi = $("#strname_Hindi").val();
    $("#strname_Hindi").next("span").remove();
    if (strname_Hindi == "") {
        $("#strname_Hindi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strname_Hindi").next("span").remove();
    }
});
$("#strEmailId").keyup(function () {
    var strEmailId = $("#strEmailId").val();
    $("#strEmailId").next("span").remove();
    if (strEmailId == "") {
        $("#strEmailId").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strEmailId").next("span").remove();
    }
});

$("#strEmailId").keyup(function () {
    $("#strEmailId").next("span").remove();
    if (emailReg.test($("#strEmailId").val())) {
        $("#strEmailId").next("span").remove();
    }
    else {
        $("#strEmailId").after("<span style='color:Red'>Please Enter a Valid Email Address</span>");
    }
});


$("#strDesignation").keyup(function () {
    var strDesignation = $("#strDesignation").val();
    $("#strDesignation").next("span").remove();
    if (strDesignation == "") {
        $("#strDesignation").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strDesignation").next("span").remove();
    }
});


$("#strDesignation_Hindi").keyup(function () {
    var strDesignation_Hindi = $("#strDesignation_Hindi").val();
    $("#strDesignation_Hindi").next("span").remove();
    if (strDesignation_Hindi == "") {
        $("#strDesignation_Hindi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strDesignation_Hindi").next("span").remove();
    }
});


$("#strReaponsibilityArea").keyup(function () {
    var strReaponsibilityArea = $("#strReaponsibilityArea").val();
    $("#strReaponsibilityArea").next("span").remove();
    if (strReaponsibilityArea == "") {
        $("#strReaponsibilityArea").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strReaponsibilityArea").next("span").remove();
    }
});

$("#strReaponsibilityArea_Hindi").keyup(function () {
    var strReaponsibilityArea_Hindi = $("#strReaponsibilityArea_Hindi").val();
    $("#strReaponsibilityArea_Hindi").next("span").remove();
    if (strReaponsibilityArea_Hindi == "") {
        $("#strReaponsibilityArea_Hindi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strReaponsibilityArea_Hindi").next("span").remove();
    }
});
$("#strPhone").keyup(function () {
    var strPhone = $("#strPhone").val();
    $("#strPhone").next("span").remove();
    if (strPhone == "") {
        $("#strPhone").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPhone").next("span").remove();
    }
});





$("#strOfficeType").change(function () {
    var strOfficeType = $("#strOfficeType").val();
    $("#strOfficeType").next("span").remove();
    if (strOfficeType == "") {
        $("#strOfficeType").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strOfficeType").next("span").remove();
    }
});


$("#strOfficeType_Hindi").change(function () {
    var strOfficeType_Hindi = $("#strOfficeType_Hindi").val();
    $("#strOfficeType_Hindi").next("span").remove();
    if (strOfficeType_Hindi == "") {
        $("#strOfficeType_Hindi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strOfficeType_Hindi").next("span").remove();
    }
});


$("#intSlNo").keyup(function () {

    var intSlNo = $("#intSlNo").val();
    $("#intSlNo").next("span").remove();
    if (intSlNo == "") {
        $("#intSlNo").after("<span style='color:Red'> This field is required</span>");
    }
   
    else {
        $("#intSlNo").next("span").remove();
    }
});





//Limit Charcter
$("#strName").on("input", function () {
    LimtCharacters(this, 100);
});

$("#strname_Hindi").on("input", function () {
    LimtCharacters(this, 100);
});
$("#strDesignation").on("input", function () {
    LimtCharacters(this, 50);
});

$("#strDesignation_Hindi").on("input", function () {
    LimtCharacters(this, 50);
});
$("#strReaponsibilityArea").on("input", function () {
    LimtCharacters(this, 200);
});
$("#strReaponsibilityArea_Hindi").on("input", function () {
    LimtCharacters(this, 200);
});
$("#strPhone").on("input", function () {
    LimtCharacters(this, 15);
});

$("#strEmailId").on("input", function () {
    LimtCharacters(this, 100);
});
$("#intSlNo").on("input", function () {
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


function error() {
    
    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var strOfficeType = $("#strOfficeType").val();
    var strOfficeType_Hindi = $("#strOfficeType_Hindi").val();
    var strName = $("#strName").val();
    var strname_Hindi = $("#strname_Hindi").val();
    var strDesignation = $("#strDesignation").val();
    var strDesignation_Hindi = $("#strDesignation_Hindi").val();
    var strReaponsibilityArea = $("#strReaponsibilityArea").val();
    var strReaponsibilityArea_Hindi = $("#strReaponsibilityArea_Hindi").val();
    var strPhone = $("#strPhone").val();
    var strEmailId = $("#strEmailId").val();

  
    if ($("#strOfficeType").val() == "") {
        $("#strOfficeType").next("span").remove();
        $("#strOfficeType").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
   
    if ($("#strOfficeType_Hindi").val() == "") {
        $("#strOfficeType_Hindi").next("span").remove();
        $("#strOfficeType_Hindi").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strName").val() == "") {
        $("#strName").next("span").remove();
        $("#strName").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strname_Hindi").val() == "") {
        $("#strname_Hindi").next("span").remove();
        $("#strname_Hindi").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if ($("#strDesignation").val() == "") {
        $("#strDesignation").next("span").remove();
        $("#strDesignation").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strDesignation_Hindi").val() == "") {
        $("#strDesignation_Hindi").next("span").remove();
        $("#strDesignation_Hindi").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strReaponsibilityArea").val() == "") {
        $("#strReaponsibilityArea").next("span").remove();
        $("#strReaponsibilityArea").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strReaponsibilityArea_Hindi").val() == "") {
        $("#strReaponsibilityArea_Hindi").next("span").remove();
        $("#strReaponsibilityArea_Hindi").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPhone").val() == "") {
        $("#strPhone").next("span").remove();
        $("#strPhone").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strEmailId").val() == "") {
        $("#strEmailId").next("span").remove();
        $("#strEmailId").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if (!emailReg.test(strEmailId)) {
        $("#strEmailId").next("span").remove();
        $("#strEmailId").after("<span style='color:Red'>Please enter valid Email </span>");
        noerror = 0;
    }

    

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#tbl_ManagementKeyExecutives')[0].checkValidity()) {
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