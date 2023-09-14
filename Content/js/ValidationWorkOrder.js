

function error() {



    var noerror = 1;
    var WO_UNIT = $('#WO_UNIT').val();
    var WorkOrderNo = $('#WORKORDERNO').val();
    var NameofWork = $('#NAMEOFTHEWORK').val();
    var Establishment = $('#ESTABLISHMENT').val();
    var CompanyName = $('#NAMEOFTHECOMPANY').val();
    var WorkLocation = $('#LOCATIONOFWORK').val();
    var CommencementDate = $('#DATEOFCOMMENCEMENT').val();
    var CompletionDate = $('#DATEOFCOMPLETIONWORK').val();
    var MaxEmployees = $('#MAXNOOFEMPLOYEES').val();
    var WOrderIssuedBy = $('#WORKORDERISSUEDBY').val();
    var LabourLiscence = $('#LABOURLICENCE').val();
    var PrincipalEmployerName = $('#NAMEOFTHEPRINCIPALEMPLOYER').val();
    var WorkOrderArea = $('#WO_AREA').val();
    var WorkOrderHeadquarter = $('#WO_HQ').val();

    //fileupload
    var WorkOrderFile = $('#WO_FILE').val();
  
    //$('input[name="hd_UpldFile"]').val(WorkOrderFile);

    var EmployerAddress = $('#PRINCIPALEMPLOYERADDRESS').val();
    var EstablishmentAddress = $('#ESTABLISHMENTADDRESS').val();





    if (WO_UNIT == "") {
        $("#errmsg13").html('This field is required').show().css("color", "red");
         noerror = 0;
    }


    if (WorkOrderNo == "") {
        $("#errmsg").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (NameofWork == "") {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (Establishment == "") {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (CompanyName == "") {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (WorkLocation == "") {
        $("#errmsg4").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

//    if (CommencementDate == "") {
//        $("#errmsg14").html('This field is required').show().css("color", "red");
//        noerror = 0;
//    }

//    if (CompletionDate == "") {
//        $("#errmsg15").html('This field is required').show().css("color", "red");
//        noerror = 0;
//    }

    if (MaxEmployees == "") {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (WOrderIssuedBy == "") {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (LabourLiscence == "") {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (PrincipalEmployerName == "") {
        $("#errmsg8").html('This field is required').show().css("color", "red");
        noerror = 0;

    }

    if (WorkOrderArea == "") {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (WorkOrderHeadquarter == "") {
        $("#errmsg10").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if ($("#hdWO_FILE").val() == "") {
        $("#errmsg16").html('This field is required').show().css("color", "red");
        noerror = 0;
    }


//    if ($("#WO_FILE") == undefined || $("#WO_FILE").val() == "") {
//        $("#errmsg16").html('This field is required').show().css("color", "red");
//        noerror = 0;
//    }
//    if ($("#WO_FILE") == undefined || $("#WO_FILE").val() == "" || $("#hideDoc1").html() != "View Upload Doc...") {
//        $("#errmsg16").html('This field is required').show().css("color", "red");
//        noerror = 0;
//    }

   

    if (EstablishmentAddress == "") {
        $("#errmsg12").html('This field is required').show().css("color", "red");
        noerror = 0;
    }



    if (EmployerAddress == "") {
        $("#errmsg11").html('This field is required').show().css("color", "red");
        noerror = 0;
    }

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#ValidationWorkOrder')[0].checkValidity()) {
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





$("#WO_UNIT").change(function () {
    if (this.value == "" || this.value == undefined) {
        $("#errmsg13").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg13").html('');
    }
});

$("#WORKORDERNO").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg").html('');
    }
});

$("#NAMEOFTHEWORK").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg1").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg1").html('');
    }
});

$("#ESTABLISHMENT").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg2").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg2").html('');
    }
});

$("#NAMEOFTHECOMPANY").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg3").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg3").html('');
    }
});

$("#LOCATIONOFWORK").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg4").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg4").html('');
    }
});

//$("#DATEOFCOMMENCEMENT").keyup(function () {
//    if (this.value.length == 0) {
//        $("#errmsg14").html('This field is required').show().css("color", "red");
//        return false;

//    }
//    else {
//        $("#errmsg14").html('');
//    }
//});

//$("#DATEOFCOMPLETIONWORK").keyup(function () {
//    if (this.value.length == 0) {
//        $("#errmsg15").html('This field is required').show().css("color", "red");
//        return false;

//    }
//    else {
//        $("#errmsg15").html('');
//    }
//});

$("#MAXNOOFEMPLOYEES").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg5").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg5").html('');
    }
});

$("#WORKORDERISSUEDBY").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg6").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg6").html('');
    }
});

$("#LABOURLICENCE").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg7").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg7").html('');
    }
});

$("#NAMEOFTHEPRINCIPALEMPLOYER").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg8").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg8").html('');
    }
});

$("#WO_AREA").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg9").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg9").html('');
    }
});

$("#WO_HQ").keyup(function () {
    if (this.value.length == 0) {
        $("#errmsg10").html('This field is required').show().css("color", "red");
        return false;

    }
    else {
        $("#errmsg10").html('');
    }
});

$("#WO_FILE").change(function () {
     $("#hdWO_FILE").val(this.value);
    $("#errmsg16").html('');

    
});



    $("#PRINCIPALEMPLOYERADDRESS").keyup(function () {
        if (this.value.length == 0) {
            $("#errmsg11").html('This field is required').show().css("color", "red");
            return false;

        } else {
            $("#errmsg11").html('');
        }
    });

    $("#ESTABLISHMENTADDRESS").keyup(function () {
        if (this.value.length == 0) {
            $("#errmsg12").html('This field is required').show().css("color", "red");
            return false;

        } 
        else {
            $("#errmsg12").html('');
        }
    });


    
$("#MAXNOOFEMPLOYEES").ForceNumericOnly();

$("#WORKORDERNO").on("input", function () {
    LimtCharacters(this, 60, 'errmsg');
});
$("#NAMEOFTHEWORK").on("input", function () {
    LimtCharacters(this, 350, 'errmsg1');
});
$("#ESTABLISHMENT").on("input", function () {
    LimtCharacters(this, 100, 'errmsg2');
});
$("#NAMEOFTHECOMPANY").on("input", function () {
    LimtCharacters(this, 20, 'errmsg3');
});
$("#LOCATIONOFWORK").on("input", function () {
    LimtCharacters(this, 20, 'errmsg4');
});
$("#MAXNOOFEMPLOYEES").on("input", function () {
    LimtCharacters(this, 10, 'errmsg5');
});
$("#WORKORDERISSUEDBY").on("input", function () {
    LimtCharacters(this, 60, 'errmsg6');
});
$("#LABOURLICENCE").on("input", function () {
    LimtCharacters(this, 60, 'errmsg7');
});
$("#NAMEOFTHEPRINCIPALEMPLOYER").on("input", function () {
    LimtCharacters(this, 60, 'errmsg8');
});
$("#WO_AREA").on("input", function () {
    LimtCharacters(this, 25, 'errmsg9');
});
$("#WO_HQ").on("input", function () {
    LimtCharacters(this, 15, 'errmsg10');
});
$("#PRINCIPALEMPLOYERADDRESS").on("input", function () {
    LimtCharacters(this, 400, 'errmsg11');
});
$("#ESTABLISHMENTADDRESS").on("input", function () {
    LimtCharacters(this, 400, 'errmsg12');
});

function LimtCharacters(txtMsg, CharLength, errmsg) {
    chars = txtMsg.value.length;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
    }
}