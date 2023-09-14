

var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;



function error() {

    //    var numberReg = /^[0-9]+$/;
   
    //    var lengthReg = /^[a-zA-Z]{10,15}$/;

    var noerror = 1;
   

    var name = $('#NAME').val();
   // var surname = $('#SURNAME').val();
    var date = $('#DATEOFBIRTH').val();
    var gender = $('#SEX').val();


    var fathername = $('#FATHERNAME').val();

    var DATEOFBIRTH = $('#DATEOFBIRTH').val();

    var employmenttype = $('#EMPLOYMENTTYPE').val();
    var designation = $('#DESIGNATION').val();
    var wagerate = $('#WAGERATE').val();
    var wageperiod = $('#WAGEPERIOD').val();
    var permanentaddress = $('#PERMANENTADDRESS').val();
    var presentaddress = $('#PRESENTADRESS').val();
    var permanentPINcode = $('#PERMANENTPINCODE').val();
    var presentPINcode = $('#PRESENTPINCODE').val();
    var PANNo = $('#PANNO').val();
    var mobileNo = $('#MOBILENO').val();
    var bankaccountNo = $('#BANKACNO').val();
    var caste = $('#CASTE').val();
    var bankname = $('#BANKNAME').val();
    var email = $('#EMAIL').val();
    var catcode = $('#CATCODE').val();


 

    if (name == "") {
        $("#errmsg").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


//    if (surname == "") {
//        $("#errmsg2").html('This field is required').show().css("color", "red");
//        noerror = 0;
//    }

    if (DATEOFBIRTH == "") {
        $("#errmsg40").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (gender == "" || gender == undefined) {
        $("#errmsg32").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (permanentaddress == "") {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        noerror = 0;
    }





     if (presentaddress == "") {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    
    if (fathername == "") {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        noerror = 0;
    }






    if (employmenttype == "" || employmenttype == undefined) {
        $("#errmsg42").html('This field is required').show().css("color", "red");
        noerror = 0;
    }



    if (designation == "") {
        $("#errmsg4").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (wagerate == "") {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (wageperiod == "") {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (permanentaddress == "") {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (presentaddress == "") {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (permanentPINcode == "") {
        $("#errmsg8").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


    if (permanentPINcode.toString().length < 6 && permanentPINcode != "") {
        $("#errmsg8").html('PINCODE  must be 6 digits').show().css("color", "red");
        noerror = 0;
    }



    if (presentPINcode == "") {
        $("#errmsg10").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (presentPINcode.toString().length < 6 && presentPINcode !="") {
        $("#errmsg10").html('PINCODE  must be 6 digits').show().css("color", "red");
        noerror = 0;

    }

  
    if (PANNo == "") {
        $("#errmsg11").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (PANNo.toString().length < 10 && PANNo != "") {

        $("#errmsg11").html('PAN No must be 10 digits').show().css("color", "red");
        noerror = 0;
    }

    if (mobileNo.toString().length < 10 && mobileNo != "") {
        $("#errmsg14").html('Mobile must be 10 digits').show().css("color", "red");
        noerror = 0;
    }

    if (mobileNo == "") {
        $("#errmsg14").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

   

//    if (email == "") {
//        $("#errmsg13").html('This field is required').show().css("color", "red");
//        noerror = 0;
//    }
    if (!emailReg.test(email)) {
        $("#errmsg13").html('Please enter a valid email address').show().css("color", "red");
        noerror = 0;
    }

    if (bankaccountNo == "") {
        $("#errmsg17").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (caste == "") {
        $("#errmsg18").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (bankname == "") {
        $("#errmsg23").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (catcode == "") {
        $("#errmsg43").html('This field is required').show().css("color", "red");
        noerror = 0;

    }

    if (noerror == 1) 
    {
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





     






$("#NAME").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg").html('');
    }
});


//$("#SURNAME").keyup(function () {
//    if (this.value.length == 0) {
//        $("#errmsg2").html('This field is required').show().css("color", "red");
//        return false;

//    } else {
//        $("#errmsg2").html('');
//    }
//});






$("#SEX").change(function () {
    if (this.value == "" || this.value == undefined) {
        $("#errmsg32").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg32").html('');
    }
});



$("#FATHERNAME").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg3").html('');
    }
});



$("#EMPLOYMENTTYPE").change(function () {
    if (this.value == "" || this.value == undefined) {
        $("#errmsg42").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg42").html('');
    }
});

$('#CATCODE').change(function () {
    if (this.value == "" || this.value == undefined) {
        $("#errmsg43").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg43").html('');
    }
});

$("#DESIGNATION").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg4").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg4").html('');
    }
});



$("#WAGERATE").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg5").html('');
    }
});



$("#WAGEPERIOD").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg6").html('');
    }
});



$("#PERMANENTPINCODE").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg8").html('This field is required').show().css("color", "red");
        return false;
    }
    if (this.value.length < 6) {
        $("#errmsg8").html('PINCODE must be 6 digits').show().css("color", "red");
        return false;
    }
    else {
        $("#errmsg8").html('');
    }
});



$("#PRESENTPINCODE").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg10").html('This field is required').show().css("color", "red");
        return false;
    }
    if (this.value.length < 6) {
        $("#errmsg10").html('PINCODE must be 6 digits').show().css("color", "red");
        return false;
    }

     else {
        $("#errmsg10").html('');
    }
});



$("#PANNO").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg11").html('This field is required').show().css("color", "red");
        return false;
    }
    if (this.value.length < 10) {
        $("#errmsg11").html('PAN No must be 10 digits').show().css("color", "red");
        return false;
    }
    else {
        $("#errmsg11").html('');
    }
});



$("#MOBILENO").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg14").html('This field is required').show().css("color", "red");
        return false;
    }
    else if (this.value.length < 10) {
        $("#errmsg14").html('Mobile must be 10 digit').show().css("color", "red");
        return false;
    }

    else {
        $("#errmsg14").html('');
    }
});

$("#AADHARNO").keyup(function () {
    if (this.value.length < 12) {
        $("#errmsg12").html('Aadhar No must be 12 digits').show().css("color", "red");
        return false;
    }
    

    else {
        $("#errmsg12").html('');
    }
});


$("#BANKACNO").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg17").html('This field is required').show().css("color", "red");
        return false;

    }
     else {
        $("#errmsg17").html('');
    }
});


$("#BANKNAME").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg23").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg23").html('');
    }
});


$("#CASTE").change(function () {
    if (this.value.length == 0) {
        $("#errmsg18").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg18").html('');
    }
});




$("#PERMANENTADDRESS").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg7").html('');
    }
});

$("#PRESENTADRESS").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        return false;

    } else {
        $("#errmsg9").html('');


    }
});





$("#EMAIL").keyup(function () {
    //    if (emailReg.test(this.value)) {
    //        $("#errmsg13").html('');
    //    }
    //    if (this.value == "") {
    //        $("#errmsg13").html('This field is required').show().css("color", "red");

    //    }
    if (!emailReg.test(this.value)) {
        $("#errmsg13").html('Please enter a valid email address').show().css("color", "red");

    }
    else {
        $("#errmsg13").html('');

    }
});


$("#WAGERATE").ForceNumericOnly();
$("#MOBILENO").ForceNumericOnly();
$("#BANKACNO").ForceNumericOnly();
$("#CONTRACTORID").ForceNumericOnly();
//$("#UGALLOWEDPER").ForceNumericOnly();
$("#PFPER").ForceNumericOnly();
$("#PENSIONALLOWEDPER").ForceNumericOnly();
//$("#ADDLINCRPER").ForceNumericOnly();
$("#BONUSALLOWEDPER").ForceNumericOnly();
$("#ATTDBONUSALLOWEDPER").ForceNumericOnly();
$("#LOI").ForceNumericOnly();
$("#PERMANENTPINCODE").ForceNumericOnly();
$("#PRESENTPINCODE").ForceNumericOnly();
$("#AADHARNO").ForceNumericOnly();
$("#UGALLOWEDPER").number(true, 2);
$("#ADDLINCRPER").number(true, 2);





$("#NAME").on("input", function () {
    LimtCharacters(this, 60, 'errmsg');
});
$("#MIDDLENAME").on("input", function () {
    LimtCharacters(this, 60, 'errmsg1');
});
$("#SURNAME").on("input", function () {
    LimtCharacters(this, 60, 'errmsg2');
});
$("#FATHERNAME").on("input", function () {
    LimtCharacters(this, 60, 'errmsg3');
});
$("#DESIGNATION").on("input", function () {
    LimtCharacters(this, 60, 'errmsg4');
});
$("#WAGERATE").on("input", function () {
    LimtCharacters(this, 5, 'errmsg5');
});
$("#WAGEPERIOD").on("input", function () {
    LimtCharacters(this, 7, 'errmsg6');
});
$("#PERMANENTADDRESS").on("input", function () {
    LimtCharacters(this, 400, 'errmsg7');
});
$("#PERMANENTPINCODE").on("input", function () {
    LimtCharacters(this, 6, 'errmsg8');
});
$("#PRESENTADRESS").on("input", function () {
    LimtCharacters(this, 400, 'errmsg9');
});
$("#PRESENTPINCODE").on("input", function () {
    LimtCharacters(this, 6, 'errmsg10');
});
$("#PANNO").on("input", function () {
    LimtCharacters(this, 10, 'errmsg11');
});
$("#AADHARNO").on("input", function () {
    LimtCharacters(this, 12, 'errmsg12');
});
$("#EMAIL").on("input", function () {
    LimtCharacters(this, 60, 'errmsg13');
});
$("#MOBILENO").on("input", function () {
    LimtCharacters(this, 10, 'errmsg14');
});
$("#PFNO").on("input", function () {
    LimtCharacters(this, 40, 'errmsg16');
});
$("#BANKACNO").on("input", function () {
    LimtCharacters(this, 20, 'errmsg17');
});
$("#CASTE").on("input", function () {
    LimtCharacters(this, 10, 'errmsg18');
});
$("#EDUQUAL").on("input", function () {
    LimtCharacters(this, 200, 'errmsg19');
});
$("#TECHQUAL").on("input", function () {
    LimtCharacters(this, 200, 'errmsg20');
});
$("#REASONS").on("input", function () {
    LimtCharacters(this, 200, 'errmsg21');
});
$("#CONTRACTORID").on("input", function () {
    LimtCharacters(this, 7, 'errmsg22');
});
$("#BANKNAME").on("input", function () {
    LimtCharacters(this, 40, 'errmsg23');
});
$("#PFOTHER").on("input", function () {
    LimtCharacters(this, 100, 'errmsg24');
});
$("#NOMINEE1").on("input", function () {
    LimtCharacters(this, 60, 'errmsg25');
});
$("#RELATION1").on("input", function () {
    LimtCharacters(this, 20, 'errmsg26');
});
$("#NOMINEE2").on("input", function () {
    LimtCharacters(this, 60, 'errmsg27');
});
$("#RELATION2").on("input", function () {
    LimtCharacters(this, 20, 'errmsg28');
});
$("#NOMINEEOTH1").on("input", function () {
    LimtCharacters(this, 60, 'errmsg29');
});
$("#NOMINEEOTH2").on("input", function () {
    LimtCharacters(this, 60, 'errmsg30');
});
$("#WUIN").on("input", function () {
    LimtCharacters(this, 8, 'errmsg31');
});
$("#UGALLOWEDPER").on("input", function () {
    LimtCharacters(this, 5, 'errmsg90');
});
$("#PFPER").on("input", function () {
    LimtCharacters(this, 5, 'errmsg33');
});
$("#PENSIONALLOWEDPER").on("input", function () {
    LimtCharacters(this, 5, 'errmsg34');
});
$("#ADDLINCRPER").on("input", function () {
    LimtCharacters(this, 5, 'errmsg35');
});
$("#BONUSALLOWEDPER").on("input", function () {
    LimtCharacters(this, 5, 'errmsg36');
});
$("#ATTDBONUSALLOWEDPER").on("input", function () {
    LimtCharacters(this, 5, 'errmsg37');
});
$("#LOI").on("input", function () {
    LimtCharacters(this, 5, 'errmsg38');
});

$("#ESINO").on("input", function () {
    LimtCharacters(this, 20, 'errmsg60');
});

function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}
//Email



//    if (email == "") {
//        $("#errmsg2").html('This field is required').show().css("color", "red");
//    }
//    else if (!emailReg.test(email)) {
//        $("#errmsg2").html('Please enter a valid email address').show().css("color", "red");
//    }
//    else if (!lengthReg.test(email)) {
//        $("#errmsg2").html('Please 3-7').show().css("color", "red");
//    }




//function isValidEmailAddress(emailAddress) {
//    var pattern = /^([\w-\.]+@@([\w-]+\.)+[\w-]{2,4})?$/;
//    // alert( pattern.test(emailAddress) );
//    return pattern.test(emailAddress);
//};
//$("#EMAIL").keyup(function () {
//    var email = $("#EMAIL").val();
//    if (email != 0) {
//        if (isValidEmailAddress(email)) {
//            $("#errmsg13").html('');

//        } else {
//            $("#errmsg13").html('Email invalid').show().css("color", "red");
//        }
//    }
//    else {
//        $("#errmsg13").html('');
//    }

//});



$("#PANNO").change(function () {
    var PANNO = $('#PANNO').val();
    if (PANNO == "") {
    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Vendor/checkPAN',
            data: { 'PANNO': PANNO },
            success: function (result) {
                if (result.already == "Yes") {
                    alert('PAN NO. already exists.')
                    $('#PANNO').val('');
                }
            },
            error: function () {
                alert('Error');
            }
        });
    }
});