function error() {

    var noerror = 1;

    var WorkOrder = $('#WORKORDERID').val();
   
    var Location = $('#LOCATIONID').val();
    var Workman = $('#WORKMANID').val();
    var Month = $('#MNTH').val();
    var Year = $('#YEAR').val();
    var Attendance = $('#ATTENDANCE').val();
    var WageRate = $('#WAGERATE').val();
    var TotalDeduction = $('#TOTALDEDUCTION').val();
    var NetAmount = $('#NETAMOUNT').val();
    var AbsentDays = $('#ABSENTDAYS').val();
    var BasicPay = $('#BASICPAY').val();
    var VDA = $('#VDA').val();
    var SDA = $('#SDA').val();
    var UGAllow = $('#UGALLOW').val();
    var Bonus = $('#BONUS').val();
    var PFGross = $('#PFGROSS').val();
    var AttendanceBonus = $('#ATTENDANCEBONUS').val();
    var Pension = $('#PENSION').val();
    var Addlincr = $('#ADDLINCR').val();
    var Gross = $('#GROSS').val();
    var Netpay = $('#NETPAY').val();
    var CatCode = $('#CATCODE').val();
    var NormalWagesEarned = $('#NORMALWAGESEARNED').val();
    var OTWages = $('#OTWAGES').val();
    var PF = $('#PF').val();






    if (WorkOrder == "" || WorkOrder == undefined) {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        noerror = 0;
       
    }
    if (Location == "" || Location == undefined) {
        $("#errmsg2").html('This field is required').show().css("color", "red");
         noerror = 0;
    }
     if (Workman == "" || Workman == undefined) {
        $("#errmsg3").html('This field is required').show().css("color", "red");
    }
    if (Month == "") {
        $("#errmsg4").html('This field is required').show().css("color", "red");
       noerror = 0;
    }
    if (Year == "") {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (Attendance == "") {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (WageRate == "") {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (TotalDeduction == "") {
        $("#errmsg8").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (NetAmount == "") {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (AbsentDays == "") {
        $("#errmsg10").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (BasicPay == "") {
        $("#errmsg11").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (VDA == "") {
        $("#errmsg12").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
        
    if (SDA == "") {
        $("#errmsg13").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (UGAllow == "") {
        $("#errmsg14").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (Bonus == "") {
        $("#errmsg15").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (PFGross == "") {

        $("#errmsg16").html('This field is required').show().css("color", "red");
        noerror = 0;

    }
    if (AttendanceBonus == "") {
        $("#errmsg17").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (Pension == "") {
        $("#errmsg18").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (Addlincr == "") {
        $("#errmsg19").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (Gross == "") {
        $("#errmsg20").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (Netpay == "") {
        $("#errmsg21").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (CatCode == "") {
        $("#errmsg22").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (NormalWagesEarned == "") {
        $("#errmsg23").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (OTWages == "") {
        $("#errmsg24").html('This field is required').show().css("color", "red");
        noerror = 0;
    }
    if (PF == "") {
        $("#errmsg25").html('This field is required').show().css("color", "red");
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



function onchangeevent() {
    alert(this.value);
}

$("#WORKORDERID").change(function () {
    if (this.value == "" || this.value == undefined) {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        return false;
    }
    else {
        $("#errmsg1").html('');
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Vendor/GetWorkman',
            data: { 'WORKORDERID': $("#WORKORDERID").val() },
            success: function (result) {
                $('#WORKMANID').empty();
                if (result.Workman != "") {
                    if (result.Workman.length > 0) {
                        $("#WORKMANID").append('<option value="' + 0 + '">' + "Select" + '</option>');
                        $.each(result.Workman, function (result) {
                            $('#WORKMANID').append($('<option/>').attr('value', this.WORKMANID).text(this.NAME));
                        });

                    }

                }

            },
            error: function () {

                alert('Error');
            }

        });


    }
});






$("#LOCATIONID").change(function () {
    if (this.value == "" || this.value == undefined) {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg2").html('');
    }
});



$("#WORKMANID").change(function () {
    if (this.value == "" || this.value == undefined) {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg3").html('');
    }
});



//$("#MNTH").bind("click", function () {
//    if (this.value == "") {
//        $("#errmsg4").html('This field is required').show().css("color", "red");
//        //return false;

//    } else {
//        $("#errmsg4").html('');
//    }
//});







//$("#YEAR").bind("click", function () {
//    if (this.value == "") {
//        $("#errmsg5").html('This field is required').show().css("color", "red");
//        return false;

//    } else {
//        $("#errmsg5").html('');
//    }
//});



$("#ATTENDANCE").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg6").html('');
    }
});


$("#WAGERATE").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg7").html('');
    }
});


$("#TOTALDEDUCTION").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg8").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg8").html('');
    }
});



$("#NETAMOUNT").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg9").html('');
    }
});



$("#ABSENTDAYS").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg10").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg10").html('');
    }
});


$("#BASICPAY").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg11").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg11").html('');
    }
});



$("#VDA").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg12").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg12").html('');
    }
});



$("#SDA").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg13").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg13").html('');
    }
});


$("#UGALLOW").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg14").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg14").html('');
    }
});



$("#BONUS").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg15").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg15").html('');
    }
});



$("#PFGROSS").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg16").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg16").html('');
    }
});



$("#ATTENDANCEBONUS").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg17").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg17").html('');
    }
});


$("#PENSION").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg18").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg18").html('');
    }
});



$("#ADDLINCR").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg19").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg19").html('');
    }
});


$("#GROSS").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg20").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg20").html('');
    }
});


$("#NETPAY").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg21").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg21").html('');
    }
});


$("#CATCODE").change(function () {
    if (this.value.length == 0) {
        $("#errmsg22").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg22").html('');
    }
});


$("#NORMALWAGESEARNED").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg23").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg23").html('');
    }
});


$("#OTWAGES").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg24").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg24").html('');
    }
});


$("#PF").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg25").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg25").html('');
    }
});








$("#ATTENDANCE").ForceNumericOnly();
$("#WAGERATE").ForceNumericOnly();
$("#TOTALDEDUCTION").ForceNumericOnly();
$("#NETAMOUNT").ForceNumericOnly();
$("#ABSENTDAYS").ForceNumericOnly();
$("#BASICPAY").ForceNumericOnly();
$("#VDA").ForceNumericOnly();
$("#SDA").ForceNumericOnly();
$("#UGALLOW").ForceNumericOnly();
$("#BONUS").ForceNumericOnly();
$("#PFGROSS").ForceNumericOnly();
$("#ATTENDANCEBONUS").ForceNumericOnly();
$("#PENSION").ForceNumericOnly();
$("#ADDLINCR").ForceNumericOnly();
$("#GROSS").ForceNumericOnly();
$("#NETPAY").ForceNumericOnly();
$("#OTHERALLOWANCE").ForceNumericOnly();
$("#NORMALWAGESEARNED").ForceNumericOnly();
$("#OTWAGES").ForceNumericOnly();
$("#PF").ForceNumericOnly();
$("#OTHERDEDUCTION").ForceNumericOnly();


$("#ATTENDANCE").on("input", function () {
    LimtCharacters(this, 2, 'errmsg6');
});
$("#ABSENTDAYS").on("input", function () {
    LimtCharacters(this, 2, 'errmsg10');
});
$("#OTHERS").on("input", function () {
    LimtCharacters(this, 60, 'errmsg2');
});
$("#WAGERATE").on("input", function () {
    LimtCharacters(this, 5, 'errmsg7');
});
$("#TOTALDEDUCTION").on("input", function () {
    LimtCharacters(this, 5, 'errmsg8');
});
$("#NETAMOUNT").on("input", function () {
    LimtCharacters(this, 5, 'errmsg9');
});
$("#BASICPAY").on("input", function () {
    LimtCharacters(this, 5, 'errmsg11');
});
$("#VDA").on("input", function () {
    LimtCharacters(this, 5, 'errmsg12');
});
$("#SDA").on("input", function () {
    LimtCharacters(this, 5, 'errmsg13');
});
$("#UGALLOW").on("input", function () {
    LimtCharacters(this, 5, 'errmsg14');
});
$("#BONUS").on("input", function () {
    LimtCharacters(this, 5, 'errmsg15');
});
$("#PFGROSS").on("input", function () {
    LimtCharacters(this, 5, 'errmsg16');
});
$("#ATTENDANCEBONUS").on("input", function () {
    LimtCharacters(this, 5, 'errmsg17');
});
$("#PENSION").on("input", function () {
    LimtCharacters(this, 5, 'errmsg18');
});
$("#ADDLINCR").on("input", function () {
    LimtCharacters(this, 5, 'errmsg19');
});
$("#GROSS").on("input", function () {
    LimtCharacters(this, 5, 'errmsg20');
});
$("#NETPAY").on("input", function () {
    LimtCharacters(this, 5, 'errmsg21');
});
$("#OTHERALLOWANCE").on("input", function () {
    LimtCharacters(this, 5, 'errmsg17');
});
$("#NORMALWAGESEARNED").on("input", function () {
    LimtCharacters(this, 5, 'errmsg18');
});
$("#OTWAGES").on("input", function () {
    LimtCharacters(this, 5, 'errmsg19');
});
$("#PF").on("input", function () {
    LimtCharacters(this, 5, 'errmsg20');
});
$("#OTHERDEDUCTION").on("input", function () {
    LimtCharacters(this, 5, 'errmsg21');
});
$("#REMARKS").on("input", function () {
    LimtCharacters(this, 400, 'errmsg22');
});




function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}