//Bhashkar

//alert($("#hidstr_uploadphoto").val());
//readURL($("#hidstr_uploadphoto").val());
//$("#str_uploadphoto").val($("#hidstr_uploadphoto").val());

// $("#UploadCaste").attr("disabled", "disabled");
Apply();
$("#strPWD").attr("disabled", false);
// $("#strPWD").val("No");
$("#strSportsperson").val("No");
//$(".aa").hide();
if ($("#hidstr_uploadphoto").val() != "" && $("#hidstr_uploadphoto").val() != null) {
    $('#blah').attr('src', $("#hidstr_uploadphoto").val()).width(70).height(80);
}
if ($("#hidstr_uploadsignature").val() != "" && $("#hidstr_uploadsignature").val() != null) {
    $('#blah1').attr('src', $("#hidstr_uploadsignature").val()).width(120).height(35);
}

if ($("#is_freshers").val() == "Yes") {
    $("#tblexprenceDetails").find("input,button,textarea,select").attr("disabled", "disabled");
}
else {
    $("#tblexprenceDetails").find("input,button,textarea,select").removeAttr("disabled", "disabled");
}

$(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
    //this.value = this.value.replace(/[^0-9\.]/g,'');
    $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});


//if ($("#IsCertificateRequired").val()) {
//    $("#Certificate").show();
//}
//else {
//    $("#Certificate").hide();
//}

$("#is_freshers").hide();
$("#other").hide();
$("#strAadharNo").ForceNumericOnly();
$("#strEmployedIn").change(function () {
    $("#other").val('');
    if (this.value == "Other(Govt.)") {
        $("#other").show();
    }

    else {
        $("#other").hide();
        if (this.value == "Private" || this.value == "Not Applicable") {
            if (!$('#select-box').find("option:contains('Not Applicable')").length) {
                $("#strapplyproper option[value='Not Applicable']").remove();
            }
            $('#strapplyproper').append(new Option('Not Applicable', 'Not Applicable'));
            $("#strapplyproper").val('Not Applicable');

        }
        else {

            $("#strapplyproper option[value='Not Applicable']").remove();

        }

    }
});


//Bhashkar



//I Agree

//$("#Submit").attr('disabled', 'disabled');

$("#CandidateAgree").change(function () {
    if ($(this).prop('checked')) {
        $("#Submit").removeAttr('disabled', 'disabled');
    } else {
        $("#Submit").attr('disabled', 'disabled');
    }
});


//I Agree



//     $('input').on('input', function () {
//         var c = this.selectionStart,
//         r = /[^a-z0-9]/gi,
//         v = $(this).val();
//         if (r.test(v)) {
//             $(this).val(v.replace(r, ''));
//             c--;
//         }
//         this.setSelectionRange(c, c);
//     });

function stringToDate(_date, _format, _delimiter) {
    if (_date != null && _date != 'undefiend') {

        var from = _date.split("-")
        return new Date(from[2], from[1] - 1, from[0])
    }

    //    var formatLowerCase = _format.toLowerCase();
    //    var formatItems = formatLowerCase.split(_delimiter);   
    //    var dateItems = _date.split(_delimiter);
    //    var monthIndex = formatItems.indexOf("mm");
    //    var dayIndex = formatItems.indexOf("dd");
    //    var yearIndex = formatItems.indexOf("yyyy");
    //    var month = parseInt(dateItems[monthIndex]);
    //    //month -= 1;
    //    //var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
    //    var formatedDate = new Date(dateItems[yearIndex], dateItems[monthIndex], dateItems[dayIndex]);
    //    return formatedDate;
}


function DateDiff(date1, date2) {
    var DMY = date1.split('/'); //splits the date string by '/' and stores in a array.
    var DMY1 = date2.split('/');

    var day = DMY[0];
    var month = DMY[1];
    var year = DMY[2];

    var day1 = DMY1[0];
    var month1 = DMY1[1];
    var year1 = DMY1[2];

    var dateTemp1 = new Date(year, (parseInt(month) - 1), day);
    var dateTemp2 = new Date(year1, (parseInt(month1) - 1), day1);
    var Days = Math.ceil(((dateTemp2.getTime() - dateTemp1.getTime()) / (1000 * 60 * 60 * 24)));
    return Days + 1;

}
$("#dt_fromdate").change(function () {
    var Str_passingyear2 = $("#Str_passingyear2").val();
    var Str_passingyear3 = $("#Str_passingyear3").val();



    if (Str_passingyear3 != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate(Str_passingyear3, "dd/MM/yyyy", "/")) {
            alert('Minimum exp. date is ' + Str_passingyear3)
            this.value = "";
            $("#str_noyears").val('');
            GetTotalYear();
        }

    }
    if (Str_passingyear2 != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate(Str_passingyear2, "dd/MM/yyyy", "/")) {
            alert('Minimum exp. date is ' + Str_passingyear2)
            this.value = "";
            $("#str_noyears").val('');
            GetTotalYear();
        }
    }

    if (Str_passingyear2 == "" && this.value != "") {
        alert('First you put your Educational Qualification');
        this.value = "";
        $("#str_noyears").val('');
        GetTotalYear();
    }

});

$("#dt_fromdate1").change(function () {

    if ($("#dt_todate").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType1").val('');
        $("#StrEmploymentPresentStatus1").val('');
        $("#str_organisation1").val('');
        $("#Str_designation1").val('');
        $("#str_CTC1").val('');
        $("#str_PayScale1").val('');
        $("#dt_todate1").val('');
        $("#str_noyears1").val('');
    }
    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears1").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate2").change(function () {

    if ($("#dt_todate1").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType2").val('');
        $("#StrEmploymentPresentStatus2").val('');
        $("#str_organisation2").val('');
        $("#Str_designation2").val('');
        $("#str_CTC2").val('');
        $("#str_PayScale2").val('');
        $("#dt_todate2").val('');
        $("#str_noyears2").val('');
    }
    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate1").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears2").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate3").change(function () {

    if ($("#dt_todate2").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType3").val('');
        $("#StrEmploymentPresentStatus3").val('');
        $("#str_organisation3").val('');
        $("#Str_designation3").val('');
        $("#str_CTC3").val('');
        $("#str_PayScale3").val('');
        $("#dt_todate3").val('');
        $("#str_noyears3").val('');
    }
    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate2").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears3").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate4").change(function () {

    if ($("#dt_todate3").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType4").val('');
        $("#StrEmploymentPresentStatus4").val('');
        $("#str_organisation4").val('');
        $("#Str_designation4").val('');
        $("#str_CTC4").val('');
        $("#str_PayScale4").val('');
        $("#dt_todate4").val('');
        $("#str_noyears4").val('');
    }
    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate3").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears4").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate5").change(function () {
    if ($("#dt_todate4").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType5").val('');
        $("#StrEmploymentPresentStatus5").val('');
        $("#str_organisation5").val('');
        $("#Str_designation5").val('');
        $("#str_CTC5").val('');
        $("#str_PayScale5").val('');
        $("#dt_todate5").val('');
        $("#str_noyears5").val('');
    }
    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate4").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears5").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate6").change(function () {

    if ($("#dt_todate5").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType6").val('');
        $("#StrEmploymentPresentStatus6").val('');
        $("#str_organisation6").val('');
        $("#Str_designation6").val('');
        $("#str_CTC6").val('');
        $("#str_PayScale6").val('');
        $("#dt_todate6").val('');
        $("#str_noyears6").val('');
    }

    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate5").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears6").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate7").change(function () {

    if ($("#dt_todate6").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType7").val('');
        $("#StrEmploymentPresentStatus7").val('');
        $("#str_organisation7").val('');
        $("#Str_designation7").val('');
        $("#str_CTC7").val('');
        $("#str_PayScale7").val('');
        $("#dt_todate7").val('');
        $("#str_noyears7").val('');
    }
    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate6").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears7").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate8").change(function () {

    if ($("#dt_todate7").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType8").val('');
        $("#StrEmploymentPresentStatus8").val('');
        $("#str_organisation8").val('');
        $("#Str_designation8").val('');
        $("#str_CTC8").val('');
        $("#str_PayScale8").val('');
        $("#dt_todate8").val('');
        $("#str_noyears8").val('');
    }

    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate7").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears8").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate9").change(function () {

    if ($("#dt_todate8").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType9").val('');
        $("#StrEmploymentPresentStatus9").val('');
        $("#str_organisation9").val('');
        $("#Str_designation9").val('');
        $("#str_CTC9").val('');
        $("#str_PayScale9").val('');
        $("#dt_todate9").val('');
        $("#str_noyears9").val('');
    }

    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate8").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears9").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate10").change(function () {

    if ($("#dt_todate9").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType10").val('');
        $("#StrEmploymentPresentStatus10").val('');
        $("#str_organisation10").val('');
        $("#Str_designation10").val('');
        $("#str_CTC10").val('');
        $("#str_PayScale10").val('');
        $("#dt_todate10").val('');
        $("#str_noyears10").val('');
    }
    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate9").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears10").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate11").change(function () {

    if ($("#dt_todate10").val() == "" && this.value != "") {
        alert('Fillup the previous row')
        this.value = "";
        $("#str_organisationType11").val('');
        $("#StrEmploymentPresentStatus11").val('');
        $("#str_organisation11").val('');
        $("#Str_designation11").val('');
        $("#str_CTC11").val('');
        $("#str_PayScale11").val('');
        $("#dt_todate11").val('');
        $("#str_noyears11").val('');
    }
    if (this.value != "") {
        if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate10").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears11").val('');
            GetTotalYear();
        }
    }

});

$("#dt_immediatefromdate,#dt_immediatetodate").change(function () {
    var fromDate = $("#dt_immediatefromdate").val();
    var toDate = $("#dt_immediatetodate").val();

    if (fromDate != "" && toDate != "") {
        var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here


        if (parseInt(n) > 0) {
            $("#str_immediatenoyears").val(n);
        }
        else {
            alert('Invalid Date');
            $("#dt_immediatefromdate").val('');
            $("#dt_immediatetodate").val('');
            $("#str_immediatenoyears").val('');
        }
    }
});


$("#dt_fromdate,#dt_todate").change(function () {
    var fromDate = $("#dt_fromdate").val();
    var toDate = $("#dt_todate").val();
    if ((fromDate != "" || toDate != "") && ($("#str_organisationType").val() == "" || $("#StrEmploymentPresentStatus").val() == "" || $("#str_organisation").val() == "" || $("#Str_designation").val() == "" || ($("#str_CTC").val() == "" && $("#str_PayScale").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate").val('');
        if ($("#StrEmploymentPresentStatus").val() != "Currently Working") {
            $("#dt_todate").val('');
        }
        $("#str_noyears").val('');
        GetTotalYear();
    }

    //         if ((fromDate != "" || toDate != "") && ($("#str_CTC").val() == "" && $("#str_PayScale").val() == "")) {
    //             alert('Please fillup previous columns in this row.');
    //             $("#dt_fromdate").val('');
    //             $("#dt_todate").val('');
    //             $("#str_noyears").val('');
    //             GetTotalYear();
    //         }

    else {
        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here


            if (parseInt(n) > 0) {

                $("#str_noyears").val(n);
                GetTotalYear();

            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate").val('');
                if ($("#StrEmploymentPresentStatus").val() != "Currently Working") {
                    $("#dt_todate").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears").val('');
                GetTotalYear();
            }
        }
    }
});

$("#dt_fromdate1,#dt_todate1").change(function () {
    var fromDate = $("#dt_fromdate1").val();
    var toDate = $("#dt_todate1").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType1").val() == "" || $("#StrEmploymentPresentStatus1").val() == "" || $("#str_organisation1").val() == "" || $("#Str_designation1").val() == "" || ($("#str_CTC1").val() == "" && $("#str_PayScale1").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate1").val('');
        if ($("#StrEmploymentPresentStatus1").val() != "Currently Working") {
            $("#dt_todate1").val('');
        }
        $("#str_noyears1").val('');
        GetTotalYear();
    }

    else {

        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears1").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate1").val('');
                if ($("#StrEmploymentPresentStatus1").val() != "Currently Working") {
                    $("#dt_todate1").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears1").val('');
                GetTotalYear();
            }
        }
    }
});

$("#dt_fromdate2,#dt_todate2").change(function () {
    var fromDate = $("#dt_fromdate2").val();
    var toDate = $("#dt_todate2").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType2").val() == "" || $("#StrEmploymentPresentStatus2").val() == "" || $("#str_organisation2").val() == "" || $("#Str_designation2").val() == "" || ($("#str_CTC2").val() == "" && $("#str_PayScale2").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate2").val('');
        if ($("#StrEmploymentPresentStatus2").val() != "Currently Working") {
            $("#dt_todate2").val('');
        }
        $("#str_noyears2").val('');
        GetTotalYear();
    }

    else {

        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears2").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate2").val('');
                if ($("#StrEmploymentPresentStatus2").val() != "Currently Working") {
                    $("#dt_todate2").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears2").val('');
                GetTotalYear();
            }
        }

    }
});

$("#dt_fromdate3,#dt_todate3").change(function () {
    var fromDate = $("#dt_fromdate3").val();
    var toDate = $("#dt_todate3").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType3").val() == "" || $("#StrEmploymentPresentStatus3").val() == "" || $("#str_organisation3").val() == "" || $("#Str_designation3").val() == "" || ($("#str_CTC3").val() == "" && $("#str_PayScale3").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate3").val('');
        if ($("#StrEmploymentPresentStatus3").val() != "Currently Working") {
            $("#dt_todate3").val('');
        }
        $("#str_noyears3").val('');
        GetTotalYear();
    }

    else {

        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears3").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate3").val('');
                if ($("#StrEmploymentPresentStatus3").val() != "Currently Working") {
                    $("#dt_todate3").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears3").val('');
                GetTotalYear();
            }
        }
    }
});

$("#dt_fromdate4,#dt_todate4").change(function () {

    var fromDate = $("#dt_fromdate4").val();
    var toDate = $("#dt_todate4").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType4").val() == "" || $("#StrEmploymentPresentStatus4").val() == "" || $("#str_organisation4").val() == "" || $("#Str_designation4").val() == "" || ($("#str_CTC4").val() == "" && $("#str_PayScale4").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate4").val('');
        if ($("#StrEmploymentPresentStatus4").val() != "Currently Working") {
            $("#dt_todate4").val('');
        }
        $("#str_noyears4").val('');
        GetTotalYear();
    }

    else {


        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears4").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate4").val('');
                if ($("#StrEmploymentPresentStatus4").val() != "Currently Working") {
                    $("#dt_todate4").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears4").val('');
                GetTotalYear();
            }
        }
    }
});



$("#dt_fromdate5,#dt_todate5").change(function () {
    var fromDate = $("#dt_fromdate5").val();
    var toDate = $("#dt_todate5").val();


    if ((fromDate != "" || toDate != "") && ($("#str_organisationType5").val() == "" || $("#StrEmploymentPresentStatus5").val() == "" || $("#str_organisation5").val() == "" || $("#Str_designation5").val() == "" || ($("#str_CTC5").val() == "" && $("#str_PayScale5").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate5").val('');
        if ($("#StrEmploymentPresentStatus5").val() != "Currently Working") {
            $("#dt_todate5").val('');
        }
        $("#str_noyears5").val('');
        GetTotalYear();
    }

    else {

        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears5").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate5").val('');
                if ($("#StrEmploymentPresentStatus5").val() != "Currently Working") {
                    $("#dt_todate5").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears5").val('');
                GetTotalYear();
            }
        }
    }
});





$("#dt_fromdate6,#dt_todate6").change(function () {
    var fromDate = $("#dt_fromdate6").val();
    var toDate = $("#dt_todate6").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType6").val() == "" || $("#StrEmploymentPresentStatus6").val() == "" || $("#str_organisation6").val() == "" || $("#Str_designation6").val() == "" || ($("#str_CTC6").val() == "" && $("#str_PayScale6").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate6").val('');
        if ($("#StrEmploymentPresentStatus6").val() != "Currently Working") {
            $("#dt_todate6").val('');
        }
        $("#str_noyears6").val('');
        GetTotalYear();
    }

    else {


        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears6").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate6").val('');
                if ($("#StrEmploymentPresentStatus6").val() != "Currently Working") {
                    $("#dt_todate6").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears6").val('');
                GetTotalYear();
            }
        }
    }
});



$("#dt_fromdate7,#dt_todate7").change(function () {
    var fromDate = $("#dt_fromdate7").val();
    var toDate = $("#dt_todate7").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType7").val() == "" || $("#StrEmploymentPresentStatus7").val() == "" || $("#str_organisation7").val() == "" || $("#Str_designation7").val() == "" || ($("#str_CTC7").val() == "" && $("#str_PayScale7").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate7").val('');
        if ($("#StrEmploymentPresentStatus7").val() != "Currently Working") {
            $("#dt_todate7").val('');
        }
        $("#str_noyears7").val('');
        GetTotalYear();
    }

    else {

        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears7").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate7").val('');
                if ($("#StrEmploymentPresentStatus7").val() != "Currently Working") {
                    $("#dt_todate7").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears7").val('');
                GetTotalYear();
            }
        }
    }
});


$("#dt_fromdate8,#dt_todate8").change(function () {
    var fromDate = $("#dt_fromdate8").val();
    var toDate = $("#dt_todate8").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType8").val() == "" || $("#StrEmploymentPresentStatus8").val() == "" || $("#str_organisation8").val() == "" || $("#Str_designation8").val() == "" || ($("#str_CTC8").val() == "" && $("#str_PayScale8").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate8").val('');
        if ($("#StrEmploymentPresentStatus8").val() != "Currently Working") {
            $("#dt_todate8").val('');
        }
        $("#str_noyears8").val('');
        GetTotalYear();
    }

    else {

        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears8").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate8").val('');
                if ($("#StrEmploymentPresentStatus8").val() != "Currently Working") {
                    $("#dt_todate8").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears8").val('');
                GetTotalYear();
            }
        }
    }
});


$("#dt_fromdate9,#dt_todate9").change(function () {
    var fromDate = $("#dt_fromdate9").val();
    var toDate = $("#dt_todate9").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType9").val() == "" || $("#StrEmploymentPresentStatus9").val() == "" || $("#str_organisation9").val() == "" || $("#Str_designation9").val() == "" || ($("#str_CTC9").val() == "" && $("#str_PayScale9").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate9").val('');
        if ($("#StrEmploymentPresentStatus9").val() != "Currently Working") {
            $("#dt_todate9").val('');
        }
        $("#str_noyears9").val('');
        GetTotalYear();
    }

    else {

        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears9").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate9").val('');
                if ($("#StrEmploymentPresentStatus9").val() != "Currently Working") {
                    $("#dt_todate9").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears9").val('');
                GetTotalYear();
            }
        }
    }
});


$("#dt_fromdate10,#dt_todate10").change(function () {
    var fromDate = $("#dt_fromdate10").val();
    var toDate = $("#dt_todate10").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType10").val() == "" || $("#StrEmploymentPresentStatus10").val() == "" || $("#str_organisation10").val() == "" || $("#Str_designation10").val() == "" || ($("#str_CTC10").val() == "" && $("#str_PayScale10").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate10").val('');
        if ($("#StrEmploymentPresentStatus10").val() != "Currently Working") {
            $("#dt_todate10").val('');
        }
        $("#str_noyears10").val('');
        GetTotalYear();
    }

    else {


        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears10").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate10").val('');
                if ($("#StrEmploymentPresentStatus10").val() != "Currently Working") {
                    $("#dt_todate10").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears10").val('');
                GetTotalYear();
            }
        }
    }
});



$("#dt_fromdate11,#dt_todate11").change(function () {
    var fromDate = $("#dt_fromdate11").val();
    var toDate = $("#dt_todate11").val();

    if ((fromDate != "" || toDate != "") && ($("#str_organisationType11").val() == "" || $("#StrEmploymentPresentStatus11").val() == "" || $("#str_organisation11").val() == "" || $("#Str_designation11").val() == "" || ($("#str_CTC11").val() == "" && $("#str_PayScale11").val() == ""))) {

        alert('Please fillup previous columns in this row.');
        $("#dt_fromdate11").val('');
        if ($("#StrEmploymentPresentStatus11").val() != "Currently Working") {
            $("#dt_todate11").val('');
        }
        $("#str_noyears11").val('');
        GetTotalYear();
    }

    else {
        if (fromDate != "" && toDate != "") {
            var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here

            if (parseInt(n) > 0) {
                $("#str_noyears11").val(n);
                GetTotalYear();
            }
            else {
                alert('Invalid Date');
                $("#dt_fromdate11").val('');
                if ($("#StrEmploymentPresentStatus11").val() != "Currently Working") {
                    $("#dt_todate11").val('');
                }
                //$("#dt_todate").val('');
                $("#str_noyears11").val('');
                GetTotalYear();
            }
        }
    }
});

function GetTotalYear() {
    var str_noyears = ($("#str_noyears").val() == "") ? "0" : $("#str_noyears").val();
    var str_noyears1 = ($("#str_noyears1").val() == "") ? "0" : $("#str_noyears1").val()
    var str_noyears2 = ($("#str_noyears2").val() == "") ? "0" : $("#str_noyears2").val()
    var str_noyears3 = ($("#str_noyears3").val() == "") ? "0" : $("#str_noyears3").val()
    var str_noyears4 = ($("#str_noyears4").val() == "") ? "0" : $("#str_noyears4").val()
    var str_noyears5 = ($("#str_noyears5").val() == "") ? "0" : $("#str_noyears5").val()
    var str_noyears6 = ($("#str_noyears6").val() == "") ? "0" : $("#str_noyears6").val()
    var str_noyears7 = ($("#str_noyears7").val() == "") ? "0" : $("#str_noyears7").val()
    var str_noyears8 = ($("#str_noyears8").val() == "") ? "0" : $("#str_noyears8").val()
    var str_noyears9 = ($("#str_noyears9").val() == "") ? "0" : $("#str_noyears9").val()
    var str_noyears10 = ($("#str_noyears10").val() == "") ? "0" : $("#str_noyears10").val()
    var str_noyears11 = ($("#str_noyears11").val() == "") ? "0" : $("#str_noyears11").val()
    var totalDays = parseInt(str_noyears) + parseInt(str_noyears1) + parseInt(str_noyears2) + parseInt(str_noyears3) + parseInt(str_noyears4) + parseInt(str_noyears5) + parseInt(str_noyears6) + parseInt(str_noyears7) + parseInt(str_noyears8) + parseInt(str_noyears9) + parseInt(str_noyears10) + parseInt(str_noyears11);


    //          var totalYears =parseInt(totalDays/365); //Math.Truncate(dectotalExp / 365);
    //          var totalMonths = parseInt((parseInt(totalDays % 365)) / 30); //Math.Truncate((dectotalExp % 365) / 30);
    //          var remainingDays = parseInt((parseInt(totalDays % 365)) % 30); //Math.Truncate((dectotalExp % 365) % 30);

    var totalExpYear = jarh(totalDays);
    $("#totalYearproper").val(totalExpYear);

    $("#totalYear").val(totalDays);

}

function jarh(x) {
    var y = 365;
    var y2 = 31;
    var remainder = x % y;
    var casio = remainder % y2;
    year = (x - remainder) / y;
    month = (remainder - casio) / y2;

    var result = year + " Years " + month + " Months " + casio + " Days";

    return result;
}

function readURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        var size = input.files[0].size / 1024;
        if (parseFloat(size) <= 50 && parseFloat(size) >= 20) {

            reader.onload = function (e) {
                $('#blah')
                    .attr('src', e.target.result)
                    .width(70)
                    .height(80);
            };

            reader.readAsDataURL(input.files[0]);
        }
    }
}

function readURL1(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        var size = input.files[0].size / 1024;
        if (parseFloat(size) <= 50 && parseFloat(size) >= 20) {

            reader.onload = function (e) {
                $('#blah1')
                    .attr('src', e.target.result)
                    .width(120)
                    .height(35);
            };

            reader.readAsDataURL(input.files[0]);
        }
    }
}

$("#str_uploadphoto").change(function () {
    var str_uploadphoto = $("#str_uploadphoto").val();
    $("#str_uploadphoto").next("span").remove();
    if (str_uploadphoto == "") {
        $("#str_uploadphoto").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_uploadphoto").next("span").remove();
    }
});


$("#str_uploadsignature").change(function () {
    var str_uploadsignature = $("#str_uploadsignature").val();
    $("#str_uploadsignature").next("span").remove();
    if (str_uploadsignature == "") {
        $("#str_uploadsignature").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#str_uploadsignature").next("span").remove();
    }
});


//     var parsed = JSON.parse(data, function (key, value) {
//         if (typeof value === 'string') {
//             var d = /\/Date\((\d*)\)\//.exec(value);
//             return (d) ? new Date(+d[1]) : value;
//         }
//         return value;
//     });

$("#dt_todate,#dt_todate1,#dt_todate2,#dt_todate3,#dt_todate4").change(function () {

    if (stringToDate(this.value, "dd/MM/yyyy", "/") > stringToDate($("#hidMaxExpdate").val(), "dd/MM/yyyy", "/")) {
        alert('Max exp. date is ' + $("#hidMaxExpdate").val())
        this.value = "";
    }
});

$("#str_organisationType").change(function () {
    if (this.value == "Other" || this.value == "Private") {

        $("#str_PayScale").val('');
        $("#str_CTC").removeAttr("disabled", "disabled");
        $("#str_PayScale").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC").val('');
        $("#str_PayScale").removeAttr("disabled", "disabled");
        $("#str_CTC").attr("disabled", "disabled");
    }
});

$("#str_organisationType1").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale1").val('');
        $("#str_CTC1").removeAttr("disabled", "disabled");
        $("#str_PayScale1").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC1").val('');
        $("#str_PayScale1").removeAttr("disabled", "disabled");
        $("#str_CTC1").attr("disabled", "disabled");
    }
});


$("#str_organisationType2").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale2").val('');
        $("#str_CTC2").removeAttr("disabled", "disabled");
        $("#str_PayScale2").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC2").val('');
        $("#str_PayScale2").removeAttr("disabled", "disabled");
        $("#str_CTC2").attr("disabled", "disabled");
    }
});


$("#str_organisationType3").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale3").val('');
        $("#str_CTC3").removeAttr("disabled", "disabled");
        $("#str_PayScale3").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC3").val('');
        $("#str_PayScale3").removeAttr("disabled", "disabled");
        $("#str_CTC3").attr("disabled", "disabled");
    }
});


$("#str_organisationType4").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale4").val('');
        $("#str_CTC4").removeAttr("disabled", "disabled");
        $("#str_PayScale4").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC4").val('');
        $("#str_PayScale4").removeAttr("disabled", "disabled");
        $("#str_CTC4").attr("disabled", "disabled");
    }
});

$("#str_organisationType5").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale5").val('');
        $("#str_CTC5").removeAttr("disabled", "disabled");
        $("#str_PayScale5").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC5").val('');
        $("#str_PayScale5").removeAttr("disabled", "disabled");
        $("#str_CTC5").attr("disabled", "disabled");
    }
});

$("#str_organisationType6").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale6").val('');
        $("#str_CTC6").removeAttr("disabled", "disabled");
        $("#str_PayScale6").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC6").val('');
        $("#str_PayScale6").removeAttr("disabled", "disabled");
        $("#str_CTC6").attr("disabled", "disabled");
    }
});

$("#str_organisationType7").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale7").val('');
        $("#str_CTC7").removeAttr("disabled", "disabled");
        $("#str_PayScale7").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC7").val('');
        $("#str_PayScale7").removeAttr("disabled", "disabled");
        $("#str_CTC7").attr("disabled", "disabled");
    }
});

$("#str_organisationType8").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale8").val('');
        $("#str_CTC8").removeAttr("disabled", "disabled");
        $("#str_PayScale8").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC8").val('');
        $("#str_PayScale8").removeAttr("disabled", "disabled");
        $("#str_CTC8").attr("disabled", "disabled");
    }
});

$("#str_organisationType9").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale9").val('');
        $("#str_CTC9").removeAttr("disabled", "disabled");
        $("#str_PayScale9").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC9").val('');
        $("#str_PayScale9").removeAttr("disabled", "disabled");
        $("#str_CTC9").attr("disabled", "disabled");
    }
});


$("#str_organisationType10").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale10").val('');
        $("#str_CTC10").removeAttr("disabled", "disabled");
        $("#str_PayScale10").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC10").val('');
        $("#str_PayScale10").removeAttr("disabled", "disabled");
        $("#str_CTC10").attr("disabled", "disabled");
    }
});

$("#str_organisationType11").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale11").val('');
        $("#str_CTC11").removeAttr("disabled", "disabled");
        $("#str_PayScale11").attr("disabled", "disabled");
    }
    else {
        $("#str_CTC11").val('');
        $("#str_PayScale11").removeAttr("disabled", "disabled");
        $("#str_CTC11").attr("disabled", "disabled");
    }
});


//$('input[type="file"]').change(function (e) {
//    var extension = $(this).val().replace(/^.*\./, '');

//    if (extension.toLowerCase() == 'png' || extension.toLowerCase() == 'jpeg' || extension.toLowerCase() == 'jpg') {
//        var size = this.files[0].size / 1024;

//        if (parseFloat(size) <= 50 && parseFloat(size) >= 20) {

//        }
//        else {

//            alert('Check the file size.');
//            $(this).val('');

//        }

//    }
//    else {
//        alert('Only png,jpeg,jpg file is allowed.');
//        $(this).val('');
//    }


//})



$("#fk_dicipline").change(function () {
    var dicpline = $("#fk_dicipline").val();

    if (dicpline == "") {
        alert("Please select discipline");
        $('#fk_postid').empty().append($('<option/>').attr('value', "").text("--- Select ---")).trigger('change');
        //  $('#strEssentialQualification').empty().append($('<option/>').attr('value', "").text("--- Select ---"));
    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/RecruitmentCareer/Postbydiscipline',
            data: { 'fk_dicipline': dicpline, 'fk_advertiseid': location.pathname.split('/')[location.pathname.split('/').length - 1] },
            success: function (result) {
                $('#fk_postid').empty();
                // $('#strEssentialQualification').empty();

                if (result.PostMaster.length > 0) {
                    $('#fk_postid').append($('<option/>').attr('value', "").text("--- Select ---"));
                    $.each(result.PostMaster, function (result) {
                        $('#fk_postid').append($('<option/>').attr('value', this.fk_postid).text(this.Postname));
                    });
                }
                //if (result.EssebtialQualification.length > 0) {
                //    $('#strEssentialQualification').append($('<option/>').attr('value', "").text("--- Select ---"));
                //    $.each(result.EssebtialQualification, function (result) {
                //        $('#strEssentialQualification').append($('<option/>').attr('value', this.Value).text(this.Text));
                //    });
                //}
            },
            error: function () {

                alert('Error');
            }
        });
    }
});


$("#fk_postid").change(function () {

    var fk_postid = $("#fk_postid").val();

    if (fk_postid == "") {
        alert("Please select post");
        $('#strEssentialQualification').empty().append($('<option/>').attr('value', "").text("--- Select ---"));
    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/RecruitmentCareer/QualificationByPost',
            data: { 'fk_postid': fk_postid, 'fk_advertiseid': location.pathname.split('/')[location.pathname.split('/').length - 1] },
            success: function (result) {
                $('#strEssentialQualification').empty();
                // For Certificate
                var IsCertificateRequired = result.IsCertificateRequired;
                if (IsCertificateRequired == true) {
                    $("#Certificate").show();
                    var arr = [result.CertificateDetails]
                    arr.push(result.ValidFirstAid);


                    for (var i = 0; i < arr.length; i++) {
                        jj += '<tr>';
                        jj += '    <td> <input value="' + arr[i] + '" readonly class="form-control" id="CertificateName' + i + '" name="CertificateName' + i + '"  type="text" autocomplete="off" required> </td>';
                        jj += '    <td> <input class="form-control" id="CertificateNo' + i + '" name="CertificateNo' + i + '" type="text" value="" autocomplete="off" required > </td>';
                        jj += '    <td> <input class="form-control input-append date"  id="CertificateIssueDate' + i + '" name="CertificateIssueDate' + i + '" placeholder="dd-mm-yyyy" type="text" value="" autocomplete="off" required > </td>';
                        jj += '    <td> <input class="form-control input-append date" id="CertificateExpiryDate' + i + '" name="CertificateExpiryDate' + i + '" placeholder="dd-mm-yyyy" type="text" value="" autocomplete="off" required > </td>';
                        jj += '    <td> <input class="form-control" id="IssuingAuthority' + i + '" name="IssuingAuthority' + i + '" type="text" value="" required > </td>';
                        jj += '</tr>';
                    }
                    $("#cer").show();
                    $("#tbodyCertificate").append(jj);
                    $('.date').datepicker({
                        format: 'dd-mm-yyyy'
                    }).datepicker().on('changeDate', function (ev) {
                        $(this).next("span").remove();

                    });
                }
                else {
                    $("#Certificate").hide();
                }
                //

                if (result.EssebtialQualification.length > 0) {
                    $('#strEssentialQualification').append($('<option/>').attr('value', "").text("--- Select ---"));
                    $.each(result.EssebtialQualification, function (result) {
                        $('#strEssentialQualification').append($('<option/>').attr('value', this.Value).text(this.Text));
                    });
                }

            },
            error: function () {

                alert('Error');
            }
        });

        //debugger;
        $("#cer").hide();
        var value = $.trim($("#fk_postid option:selected").text()).toLowerCase();
        var jj = '';
        console.log($.trim($("#fk_postid option:selected").text()).toLowerCase());


        console.log(value);
        var arr = ['Valid Mate Certificate of Competency for Metalliferous Mine(Unrestricted)'];

        arr.push('Valid First Aid Certificate');
        $("#tbodyCertificate").empty();

        //for (var i = 0; i < arr.length; i++) {
        //    jj += '<tr>';
        //    jj += '    <td> <input value="' + arr[i] + '" readonly class="form-control" id="CertificateName' + i + '" name="CertificateName' + i + '"  type="text" autocomplete="off" required> </td>';
        //    jj += '    <td> <input class="form-control" id="CertificateNo' + i + '" name="CertificateNo' + i + '" type="text" value="" autocomplete="off" required > </td>';
        //    jj += '    <td> <input class="form-control input-append date"  id="CertificateIssueDate' + i + '" name="CertificateIssueDate' + i + '" placeholder="dd-mm-yyyy" type="text" value="" autocomplete="off" required > </td>';
        //    jj += '    <td> <input class="form-control input-append date" id="CertificateExpiryDate' + i + '" name="CertificateExpiryDate' + i + '" placeholder="dd-mm-yyyy" type="text" value="" autocomplete="off" required > </td>';
        //    jj += '    <td> <input class="form-control" id="IssuingAuthority' + i + '" name="IssuingAuthority' + i + '" type="text" value="" required > </td>';
        //    jj += '</tr>';
        //}
        //$("#cer").show();
        //$("#tbodyCertificate").append(jj);
        //$('.date').datepicker({
        //    format: 'dd-mm-yyyy'
        //}).datepicker().on('changeDate', function (ev) {
        //    $(this).next("span").remove();

        //});


    }
});

//Akshat Copied Anusheel Code
$("#fk_postid").change(function () {
    var PostID = $("#fk_postid").val();
    var AddID = $("#fk_advertiseid").val();

    if (PostID == "") {
        alert("Please Select Post.");
        $('#strEssentialQualification').empty().append($('<option/>').attr('value', "").text("--- Select ---"));
    }
    else {

        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/RecruitmentCareer/QualificationByPost',
            data: { 'fk_postid': PostID, 'fk_advertiseid': AddID },
            success: function (result) {
                $('#strEssentialQualification').empty();

                if (result.EssebtialQualification.length > 0) {
                    $('#strEssentialQualification').append($('<option/>').attr('value', "").text("--- Select ---"));
                    $.each(result.EssebtialQualification, function (result) {
                        $('#strEssentialQualification').append($('<option/>').attr('value', this.Value).text(this.Text));
                    });
                }

            },
            error: function () {

                alert('Error');
            }
        });


        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/RecruitmentNew1/FillQualification',
            data: { 'postId': PostID, 'addId': AddID },
            success: function (result) {

                $('#strGender').empty();
                $('#strCategory').empty();

                if (result.GenderAll.length > 0) {
                    $('#strGender').append($('<option/>').attr('value', " ").text("Select"));
                    $.each(result.GenderAll, function (e, text) {
                        if (text != '') {
                            $('#strGender').append($('<option/>').attr('value', text).text(text));
                        }
                    });
                }
                if (result.castAll.length > 0) {
                    $('#strCategory').append($('<option/>').attr('value', " ").text("Select"));
                    $.each(result.castAll, function (e, text) {
                        if (text != '') {
                            $('#strCategory').append($('<option/>').attr('value', text).text(text));
                        }
                    });
                }



            }
        });
    }
});

$("#EduQulifi").change(function () {
    var ALlQuValue = this.value.toString().split('WITH');

    if (this.value.toString().split('WITH').length == 1) {
        $('#Str_exampassed2').val('');
        $('#Str_exampassed3').val('');
        $('#Str_exampassed2').val(ALlQuValue[0]);
        $('#Str_exampassed2').attr('readonly', true);
        $('#Str_exampassed3').removeAttr('readonly');
        $('#errorCount').val('1');
    }

    if (this.value.toString().split('WITH').length == 2) {
        $('#Str_exampassed2').val('');
        $('#Str_exampassed3').val('');
        $('#Str_exampassed2').val(ALlQuValue[0]);
        $('#Str_exampassed3').val(ALlQuValue[1]);
        $('#Str_exampassed2').attr('readonly', true);
        $('#Str_exampassed3').attr('readonly', true);
        $('#errorCount').val('2');
    }

});



//     $("#strgrade").change(function () {
//         var ALlQuValue = this.value.toString().split('WITH');

//         if (this.value.toString().split('WITH').length == 1) {
//             $('#strpresentdesignation').val('');
////             $('#Str_exampassed3').val('');
//             $('#strpresentdesignation').val(ALlQuValue[0]);
//             $('#strpresentdesignation').attr('readonly', true);
////             $('#Str_exampassed3').removeAttr('readonly');
//             $('#errorCount').val('1');
//         }

//         if (this.value.toString().split('WITH').length == 2) {
//             $('#strpresentdesignation').val('');
////             $('#Str_exampassed3').val('');
//             $('#strpresentdesignation').val(ALlQuValue[0]);
////             $('#Str_exampassed3').val(ALlQuValue[1]);
//             $('#strpresentdesignation').attr('readonly', true);
////             $('#Str_exampassed3').attr('readonly', true);
//             $('#errorCount').val('2');
//         }

//     });

$("#strgrade1").change(function () {
    var gradevalu = $("#strgrade1").val();

    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/RecruitmentCareer/PostbyDesignation',
        data: { 'grade': gradevalu },

        success: function (result) {

            $("#strpresentdesignation").val(result.Designation);


        },
        error: function () {

            alert('Error');
        }

    });


});












$("#is_freshers").change(function () {

    $("#tblexprenceDetails").find("input,button,textarea,select").removeAttr("disabled", "disabled");

    var PostID = $("#fk_postid").val();
    var Fresher = $("#is_freshers").val();

    var AddID = $("#addId").val();
    if (Fresher == "") {
        alert("Please select ");

    }
    else {
        if (Fresher == "Yes") {
            $("#dt_todate,#dt_todate1,#dt_todate2,#dt_todate3,#dt_todate4").val('');
            $("#tblexprenceDetails").find("input,button,textarea,select").attr("disabled", "disabled");
        }

    }
});

function convert(str) {
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [day, mnth, date.getFullYear()].join("-");
}



//Post by discipline


$("#fk_dicipline").change(function () {
    var dicpline = $("#fk_dicipline").val();
    if (dicpline == "") {
        alert("Please select discipline");
    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/RecruitmentCareer/Postbydiscipline',
            data: { 'fk_dicipline': dicpline, 'fk_advertiseid': $('#fk_advertiseid').val() },
            success: function (result) {
                $('#fk_postid').empty();
                if (result.PostMaster.length > 0) {
                    $('#fk_postid').append($('<option/>').attr('value', "0").text("--- Select ---"));
                    $.each(result.PostMaster, function (result) {
                        $('#fk_postid').append($('<option/>').attr('value', this.fk_postid).text(this.Postname));
                    });
                }
            },
            error: function () {

                alert('Error');
            }
        });
    }



});

















var hidValue = $('#errorCount').val();
var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

//keyup Personal information
$("#fk_dicipline").change(function () {
    var fk_dicipline = $("#fk_dicipline").val();
    $("#fk_dicipline").next("span").remove();
    if (fk_dicipline == "") {
        $("#fk_dicipline").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_dicipline").next("span").remove();
    }
});

$("#fk_postid").change(function () {
    var fk_postid = $("#fk_postid").val();
    $("#fk_postid").next("span").remove();
    if (fk_postid == "") {
        $("#fk_postid").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_postid").next("span").remove();
    }
});

$("#IsImportant").change(function () {
    var IsImportant = $("#IsImportant").val();
    $("#IsImportant").next("span").remove();
    if (IsImportant == "") {
        $("#IsImportant").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#IsImportant").next("span").remove();
    }
});

$("#strApplicantName").keyup(function () {
    var strApplicantName = $("#strApplicantName").val();
    $("#strApplicantName").next("span").remove();
    if (strApplicantName == "") {
        $("#strApplicantName").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strApplicantName").next("span").remove();
    }
});


$("#strDomicilestate").change(function () {
    var strDomicilestate = $("#strDomicilestate").val();
    $("#strDomicilestate").next("span").remove();
    if (strDomicilestate == "") {
        $("#strDomicilestate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strDomicilestate").next("span").remove();
    }
});


$("#dtDOB").keyup(function () {
    var dtDOB = $("#dtDOB").val();
    $("#dtDOB").next("span").remove();
    if (dtDOB == "") {
        $("#dtDOB").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dtDOB").next("span").remove();
    }
});
$("#strEmail").keyup(function () {
    var strEmail = $("#strEmail").val();
    $("#strEmail").next("span").remove();
    if (strEmail == "") {
        $("#strEmail").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strEmail").next("span").remove();
    }
});

$("#strEmail").keyup(function () {
    if (!emailReg.test($("#strEmail").val())) {
        $("#strEmail").next("span").remove();
        $("#strEmail").after("<span style='color:Red'>Please Enter a Valid Email Address</span>");
        noerror = 0;
    }
});


$("#strNationality").keyup(function () {
    var strNationality = $("#strNationality").val();
    $("#strNationality").next("span").remove();
    if (strNationality == "") {
        $("#strNationality").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strNationality").next("span").remove();
    }
});


$("#strGender").change(function () {
    var strGender = $("#strGender").val();
    $("#strGender").next("span").remove();
    if (strGender == "") {
        $("#strGender").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strGender").next("span").remove();
    }
});


$("#strReligion").change(function () {
    var strReligion = $("#strReligion").val();
    $("#strReligion").next("span").remove();
    if (strReligion == "") {
        $("#strReligion").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strReligion").next("span").remove();
    }
});





$("#strsubcaste").keyup(function () {
    var strsubcaste = $("#strsubcaste").val();
    $("#strsubcaste").next("span").remove();
    if (strsubcaste == "") {
        $("#strsubcaste").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strsubcaste").next("span").remove();
    }
});




$("#strcertificateno").keyup(function () {
    var strcertificateno = $("#strcertificateno").val();
    $("#strcertificateno").next("span").remove();
    if (strcertificateno == "") {
        $("#strcertificateno").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strcertificateno").next("span").remove();
    }
});

$("#dt_certificateissuedate").keyup(function () {
    var dt_certificateissuedate = $("#dt_certificateissuedate").val();
    $("#dt_certificateissuedate").next("span").remove();
    if (dt_certificateissuedate == "") {
        $("#dt_certificateissuedate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dt_certificateissuedate").next("span").remove();
    }
});
$("#strcertificateissue").keyup(function () {
    var strcertificateissue = $("#strcertificateissue").val();
    $("#strcertificateissue").next("span").remove();
    if (strcertificateissue == "") {
        $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strcertificateissue").next("span").remove();
    }
});
$("#strMaritalStatus").change(function () {
    var strMaritalStatus = $("#strMaritalStatus").val();
    $("#strMaritalStatus").next("span").remove();
    if (strMaritalStatus == "") {
        $("#strMaritalStatus").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strMaritalStatus").next("span").remove();
    }
});

$("#strTestCity").change(function () {
    var strTestCity = $("#strTestCity").val();
    $("#strTestCity").next("span").remove();
    if (strTestCity == "") {
        $("#strTestCity").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strTestCity").next("span").remove();
    }
});








$("#strExserviceMan").change(function () {

    var strExserviceMan = $("#strExserviceMan").val();
    $("#strExserviceMan").next("span").remove();
    if (strExserviceMan == "") {
        $("#strExserviceMan").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strExserviceMan").next("span").remove();
    }
});

$("#strexservicemanno").keyup(function () {
    var strexservicemanno = $("#strexservicemanno").val();
    $("#strexservicemanno").next("span").remove();
    if (strexservicemanno == "") {
        $("#strexservicemanno").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strexservicemanno").next("span").remove();
    }
});
$("#fk_domicilestateid").change(function () {
    var fk_domicilestateid = $("#fk_domicilestateid").val();
    $("#fk_domicilestateid").next("span").remove();
    if (fk_domicilestateid == "") {
        $("#fk_domicilestateid").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#fk_domicilestateid").next("span").remove();
    }
});


$("#strtypeofdisable").keyup(function () {

    var strtypeofdisable = $("#strtypeofdisable").val();
    $("#strtypeofdisable").next("span").remove();
    if (strtypeofdisable == "") {
        $("#strtypeofdisable").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strtypeofdisable").next("span").remove();
    }
});



$("#strScribe").keyup(function () {

    var strScribe = $("#strScribe").val();
    $("#strScribe").next("span").remove();
    if (strScribe == "") {
        $("#strScribe").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strScribe").next("span").remove();
    }
});


$("#strcertificateno1").keyup(function () {

    var strcertificateno1 = $("#strcertificateno1").val();
    $("#strcertificateno1").next("span").remove();
    if (strcertificateno1 == "") {
        $("#strcertificateno1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strcertificateno1").next("span").remove();
    }
});

$("#strcertificateno1").keyup(function () {

    var strcertificateno1 = $("#strcertificateno1").val();
    $("#strcertificateno1").next("span").remove();
    if (strcertificateno1 == "") {
        $("#strcertificateno1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strcertificateno1").next("span").remove();
    }
});

$("#dt_certificateissuedate1").keyup(function () {

    var dt_certificateissuedate1 = $("#dt_certificateissuedate1").val();
    $("#dt_certificateissuedate1").next("span").remove();
    if (dt_certificateissuedate1 == "") {
        $("#dt_certificateissuedate1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dt_certificateissuedate1").next("span").remove();
    }
});

$("#strcertificateissue1").keyup(function () {

    var strcertificateissue1 = $("#strcertificateissue1").val();
    $("#strcertificateissue1").next("span").remove();
    if (strcertificateissue1 == "") {
        $("#strcertificateissue1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strcertificateissue1").next("span").remove();
    }
});



$("#stremployeecode").keyup(function () {

    var stremployeecode = $("#stremployeecode").val();
    $("#stremployeecode").next("span").remove();
    if (stremployeecode == "") {
        $("#stremployeecode").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#stremployeecode").next("span").remove();
    }
});

$("#strgrade").keyup(function () {

    var strgrade = $("#strgrade").val();
    $("#strgrade").next("span").remove();
    if (strgrade == "") {
        $("#strgrade").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strgrade").next("span").remove();
    }
});
$("#strplaceposting").keyup(function () {

    var strplaceposting = $("#strplaceposting").val();
    $("#strplaceposting").next("span").remove();
    if (strplaceposting == "") {
        $("#strplaceposting").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strplaceposting").next("span").remove();
    }
});
$("#strpresentdesignation").keyup(function () {

    var strpresentdesignation = $("#strpresentdesignation").val();
    $("#strpresentdesignation").next("span").remove();
    if (strpresentdesignation == "") {
        $("#strpresentdesignation").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strpresentdesignation").next("span").remove();
    }
});

$("#dt_presententrydate").keyup(function () {

    var dt_presententrydate = $("#dt_presententrydate").val();
    $("#dt_presententrydate").next("span").remove();
    if (dt_presententrydate == "") {
        $("#dt_presententrydate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dt_presententrydate").next("span").remove();
    }
});



//keyupCorrespondenceAddress
$("#strCorrespondenceAddress").keyup(function () {

    var strCorrespondenceAddress = $("#strCorrespondenceAddress").val();
    $("#strCorrespondenceAddress").next("span").remove();
    if (strCorrespondenceAddress == "") {
        $("#strCorrespondenceAddress").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strCorrespondenceAddress").next("span").remove();
    }
});

$("#strState").keyup(function () {

    var strState = $("#strState").val();
    $("#strState").next("span").remove();
    if (strState == "") {
        $("#strState").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strState").next("span").remove();
    }
});

$("#strDistrict").keyup(function () {

    var strDistrict = $("#strDistrict").val();
    $("#strDistrict").next("span").remove();
    if (strDistrict == "") {
        $("#strDistrict").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strDistrict").next("span").remove();
    }
});
$("#strTelephone").keyup(function () {
    var strTelephone = $("#strTelephone").val();
    $("#strTelephone").next("span").remove();
    if (strTelephone.toString().length < 11 && strTelephone != "") {
        $("#strTelephone").after("<span style='color:Red'>Phone no. must be 11 digit</span>");
    }
    else {
        $("#strTelephone").next("span").remove();
    }
});
$("#strMobileNo").keyup(function () {
    var strMobileNo = $("#strMobileNo").val();
    $("#strMobileNo").next("span").remove();
    if (strMobileNo.toString().length < 10 && strMobileNo != "") {
        $("#strMobileNo").after("<span style='color:Red'>Mobile no. must be 10 digit</span>");
    }
    else {
        $("#strMobileNo").next("span").remove();
    }
});

$("#strPin").keyup(function () {

    var strPin = $("#strPin").val();
    $("#strPin").next("span").remove();
    if (strPin == "") {
        $("#strPin").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPin").next("span").remove();
    }
});

$("#strPin").keyup(function () {
    var strPin = $("#strPin").val();
    $("#strPin").next("span").remove();
    if (strPin.toString().length < 6 && strPin != "") {
        $("#strPin").after("<span style='color:Red'>Pin must be 6 digit</span>");
    }
    else {
        $("#strPin").next("span").remove();
    }
});
//permanentaddress
$("#strPermanentAddress").keyup(function () {

    var strPermanentAddress = $("#strPermanentAddress").val();
    $("#strPermanentAddress").next("span").remove();
    if (strPermanentAddress == "") {
        $("#strPermanentAddress").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPermanentAddress").next("span").remove();
    }
});

$("#strPermanentState").keyup(function () {

    var strPermanentState = $("#strPermanentState").val();
    $("#strPermanentState").next("span").remove();
    if (strPermanentState == "") {
        $("#strPermanentState").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPermanentState").next("span").remove();
    }
});

$("#strPermanentDistrict").keyup(function () {

    var strPermanentDistrict = $("#strPermanentDistrict").val();
    $("#strPermanentDistrict").next("span").remove();
    if (strPermanentDistrict == "") {
        $("#strPermanentDistrict").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPermanentDistrict").next("span").remove();
    }
});
$("#strPermanentTelephoneNo").keyup(function () {
    var strPermanentTelephoneNo = $("#strPermanentTelephoneNo").val();
    $("#strPermanentTelephoneNo").next("span").remove();
    if (strPermanentTelephoneNo.toString().length < 11 && strPermanentTelephoneNo != "") {
        $("#strPermanentTelephoneNo").after("<span style='color:Red'>Phone no. must be 11 digit</span>");
    }
    else {
        $("#strPermanentTelephoneNo").next("span").remove();
    }
});
$("#strPermanentMobile1").keyup(function () {
    var strPermanentMobile1 = $("#strPermanentMobile1").val();
    $("#strPermanentMobile1").next("span").remove();
    if (strPermanentMobile1.toString().length < 10 && strPermanentMobile1 != "") {
        $("#strPermanentMobile1").after("<span style='color:Red'>Mobile no. must be 10 digit</span>");
    }
    else {
        $("#strPermanentMobile1").next("span").remove();
    }
});

$("#strPermanentPinCode").keyup(function () {

    var strPermanentPinCode = $("#strPermanentPinCode").val();
    $("#strPermanentPinCode").next("span").remove();
    if (strPermanentPinCode == "") {
        $("#strPermanentPinCode").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPermanentPinCode").next("span").remove();
    }
});
$("#strPermanentPinCode").keyup(function () {
    var strPermanentPinCode = $("#strPermanentPinCode").val();
    $("#strPermanentPinCode").next("span").remove();
    if (strPermanentPinCode.toString().length < 6 && strPermanentPinCode != "") {
        $("#strPermanentPinCode").after("<span style='color:Red'>Pin must be 6 digit</span>");
    }
    else {
        $("#strPermanentPinCode").next("span").remove();
    }
});


//Educational Qualification  

$("#EduQulifi").change(function () {

    var EduQulifi = $("#EduQulifi").val();
    $("#EduQulifi").next("span").remove();
    if (EduQulifi == "") {
        $("#EduQulifi").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#EduQulifi").next("span").remove();
    }
});
//1st row
$("#Str_board").keyup(function () {
    $("#Str_board").next("span").remove();
    if ($("#Str_board").val() == "") {
        $("#Str_board").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_board").next("span").remove();
    }
});

$("#Str_passingdetails").keyup(function () {
    $("#Str_passingdetails").next("span").remove();
    if ($("#Str_passingdetails").val() == "") {
        $("#Str_passingdetails").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_passingdetails").next("span").remove();
    }
});

$("#Str_duration").keyup(function () {
    $("#Str_duration").next("span").remove();
    if ($("#Str_duration").val() == "") {
        $("#Str_duration").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_duration").next("span").remove();
    }
});

//$("#Str_passingyear").keyup(function () {
//    $("#Str_passingyear").next("span").remove();
//    if ($("#Str_passingyear").val() == "") {
//        $("#Str_passingyear").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#Str_passingyear").next("span").remove();
//    }
//});

$("#Str_division").keyup(function () {
    $("#Str_division").next("span").remove();
    if ($("#Str_division").val() == "") {
        $("#Str_division").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_division").next("span").remove();
    }
});


$("#Str_Marks").keyup(function () {
    $("#Str_Marks").next("span").remove();
    if ($("#Str_Marks").val() == "") {
        $("#Str_Marks").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_Marks").next("span").remove();
    }
});

//$("#StrRemarks").change(function () {
//    $("#StrRemarks").next("span").remove();
//    if ($("#StrRemarks").val() == "") {
//        $("#StrRemarks").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#StrRemarks").next("span").remove();
//    }
//});

//2nd row
$("#Str_board1").keyup(function () {
    $("#Str_board1").next("span").remove();
    if ($("#Str_board1").val() == "") {
        $("#Str_board1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_board1").next("span").remove();
    }
});

$("#Str_passingdetails1").keyup(function () {
    $("#Str_passingdetails1").next("span").remove();
    if ($("#Str_passingdetails1").val() == "") {
        $("#Str_passingdetails1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_passingdetails1").next("span").remove();
    }
});

$("#Str_duration1").keyup(function () {
    $("#Str_duration1").next("span").remove();
    if ($("#Str_duration1").val() == "") {
        $("#Str_duration1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_duration1").next("span").remove();
    }
});

//$("#Str_passingyear1").keyup(function () {
//    $("#Str_passingyear1").next("span").remove();
//    if ($("#Str_passingyear1").val() == "") {
//        $("#Str_passingyear1").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#Str_passingyear1").next("span").remove();
//    }
//});

$("#Str_division1").keyup(function () {
    $("#Str_division1").next("span").remove();
    if ($("#Str_division1").val() == "") {
        $("#Str_division1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_division1").next("span").remove();
    }
});

$("#Str_Marks1").keyup(function () {
    $("#Str_Marks1").next("span").remove();
    if ($("#Str_Marks1").val() == "") {
        $("#Str_Marks1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_Marks1").next("span").remove();
    }
});

//$("#StrRemarks1").change(function () {
//    $("#StrRemarks1").next("span").remove();
//    if ($("#StrRemarks1").val() == "") {
//        $("#StrRemarks1").after("<span style='color:Red'> This field is required</span>");
//    }
//    else {
//        $("#StrRemarks1").next("span").remove();
//    }
//});

//3rd row
$("#Str_board2").keyup(function () {


    $("#Str_board2").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_board2").val() == "") {
        $("#Str_board2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_board2").next("span").remove();
    }
});


$("#Str_passingdetails2").keyup(function () {

    $("#Str_passingdetails2").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_passingdetails2").val() == "") {
        $("#Str_passingdetails2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_passingdetails2").next("span").remove();
    }
});

$("#Str_duration2").keyup(function () {

    $("#Str_duration2").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_duration2").val() == "") {
        $("#Str_duration2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_duration2").next("span").remove();
    }
});

$("#Str_division2").keyup(function () {

    $("#Str_division2").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_division2").val() == "") {
        $("#Str_division2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_division2").next("span").remove();
    }
});




$("#Str_Marks2").keyup(function () {

    $("#Str_Marks2").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_Marks2").val() == "") {
        $("#Str_Marks2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_Marks2").next("span").remove();
    }
});

$("#StrRemarks2").change(function () {
    $("#StrRemarks2").next("span").remove();
    if ($("#StrRemarks2").val() == "") {
        $("#StrRemarks2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrRemarks2").next("span").remove();
    }
});
//4th row
$("#Str_board3").keyup(function () {


    $("#Str_board3").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_board3").val() == "") {
        $("#Str_board3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_board3").next("span").remove();
    }
});


$("#Str_passingdetails3").keyup(function () {

    $("#Str_passingdetails3").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_passingdetails3").val() == "") {
        $("#Str_passingdetails3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_passingdetails3").next("span").remove();
    }
});

$("#Str_duration3").keyup(function () {

    $("#Str_duration3").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_duration3").val() == "") {
        $("#Str_duration3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_duration3").next("span").remove();
    }
});

$("#Str_division3").keyup(function () {

    $("#Str_division3").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_division3").val() == "") {
        $("#Str_division3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_division3").next("span").remove();
    }
});




$("#Str_Marks3").keyup(function () {

    $("#Str_Marks3").next("span").remove();
    if ($("#EduQulifi").val() != "" && $("#Str_Marks3").val() == "") {
        $("#Str_Marks3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#Str_Marks3").next("span").remove();
    }
});

$("#StrRemarks3").change(function () {
    $("#StrRemarks3").next("span").remove();
    if ($("#StrRemarks3").val() == "") {
        $("#StrRemarks3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrRemarks3").next("span").remove();
    }
});


$("#strOrderNo").keyup(function () {
    $("#strOrderNo").next("span").remove();

    if ($("#strOrderNo").val() != "" && $("#strOrderNo").val() == "") {
        $("#strOrderNo").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strOrderNo").next("span").remove();
    }
});

$("#strBankName").keyup(function () {
    $("#strBankName").next("span").remove();

    if ($("#strBankName").val() != "" && $("#strBankName").val() == "") {
        $("#strBankName").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strBankName").next("span").remove();
    }
});


$("#strBranch").keyup(function () {
    $("#strBranch").next("span").remove();

    if ($("#strBranch").val() != "" && $("#strBranch").val() == "") {
        $("#strBranch").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strBranch").next("span").remove();
    }
});

$("#dtIssueDate").keyup(function () {
    $("#dtIssueDate").next("span").remove();

    if ($("#dtIssueDate").val() != "" && $("#dtIssueDate").val() == "") {
        $("#dtIssueDate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#dtIssueDate").next("span").remove();
    }
});

$("#decAmount").keyup(function () {
    $("#decAmount").next("span").remove();

    if ($("#decAmount").val() != "" && $("#decAmount").val() == "") {
        $("#decAmount").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#decAmount").next("span").remove();
    }
});


//Numeric
$("#strPermanentPinCode").ForceNumericOnly();
$("#strPermanentMobile1").ForceNumericOnly();
$("#strPermanentTelephoneNo").ForceNumericOnly();
$("#strPin").ForceNumericOnly();
$("#strMobileNo").ForceNumericOnly();
$("#strTelephone").ForceNumericOnly();
//limit
$("#strApplicantName").on("input", function () {
    LimtCharacters(this, 100);
});

$("#strFatherName").on("input", function () {
    LimtCharacters(this, 40);
});
$("#strEmail").on("input", function () {
    LimtCharacters(this, 80);
});

$("#strNationality").on("input", function () {
    LimtCharacters(this, 15);
});
$("#strsubcaste").on("input", function () {
    LimtCharacters(this, 60);
});
$("#strcertificateno").on("input", function () {
    LimtCharacters(this, 25);
});
$("#strcertificateissue").on("input", function () {
    LimtCharacters(this, 100);
});

$("#strexservicemanno").on("input", function () {
    LimtCharacters(this, 30);
});
//$("#strtypeofdisable").on("input", function () {
//    LimtCharacters(this, 20);
//});
$("#strcertificateno1").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strcertificateissue1").on("input", function () {
    LimtCharacters(this, 100);
});
$("#stremployeecode").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strgrade").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strplaceposting").on("input", function () {
    LimtCharacters(this, 50);
});
$("#strpresentdesignation").on("input", function () {
    LimtCharacters(this, 100);
});
//correspondence
$("#strCorrespondenceAddress").on("input", function () {
    LimtCharacters(this, 150);
});
//$("#strState").on("input", function () {
//    LimtCharacters(this, 20);
//});
$("#strDistrict").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strNearestPostOffice").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strNearestPoliceStation").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strNearestRailwaystation").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strPin").on("input", function () {
    LimtCharacters(this, 6);
});
$("#strTelephone").on("input", function () {
    LimtCharacters(this, 11);
});
$("#strMobileNo").on("input", function () {
    LimtCharacters(this, 10);
});
//permanent
$("#strPermanentAddress").on("input", function () {
    LimtCharacters(this, 150);
});
//$("#strPermanentState").on("input", function () {
//    LimtCharacters(this, 20);
//});
$("#strPermanentDistrict").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strPermanentNearestPostOffice").on("input", function () {
    LimtCharacters(this, 20);
});
$("#strPermanentNearestPoliceStation").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strPermanentNearestRailwayStation").on("input", function () {
    LimtCharacters(this, 20);
});

$("#strPermanentPinCode").on("input", function () {
    LimtCharacters(this, 6);
});
$("#strPermanentTelephoneNo").on("input", function () {
    LimtCharacters(this, 11);
});
$("#strPermanentMobile1").on("input", function () {
    LimtCharacters(this, 10);
});


$("#Str_exampassed3").on("input", function () {
    LimtCharacters(this, 50);
});

$("#others_exampassed1").on("input", function () {
    LimtCharacters(this, 50);
});

$("#others_exampassed2").on("input", function () {
    LimtCharacters(this, 50);
});
$("#others_exampassed3").on("input", function () {
    LimtCharacters(this, 50);
});

$("#others_exampassed4").on("input", function () {
    LimtCharacters(this, 50);
});




$("#Str_board").on("input", function () {
    LimtCharacters(this, 200);
});

$("#Str_board1").on("input", function () {
    LimtCharacters(this, 200);
});

$("#Str_board2").on("input", function () {
    LimtCharacters(this, 200);
});

$("#Str_board3").on("input", function () {
    LimtCharacters(this, 200);
});

$("#others_board1").on("input", function () {
    LimtCharacters(this, 200);
});

$("#others_board2").on("input", function () {
    LimtCharacters(this, 200);
});
$("#others_board3").on("input", function () {
    LimtCharacters(this, 200);
});

$("#others_board4").on("input", function () {
    LimtCharacters(this, 200);
});


$("#Str_passingdetails").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_passingdetails1").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_passingdetails2").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_passingdetails3").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_passingdetails1").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_passingdetails2").on("input", function () {
    LimtCharacters(this, 100);
});
$("#others_passingdetails3").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_passingdetails4").on("input", function () {
    LimtCharacters(this, 100);
});



$("#Str_duration").on("input", function () {
    LimtCharacters(this, 50);
});

$("#Str_duration1").on("input", function () {
    LimtCharacters(this, 50);
});

$("#Str_duration2").on("input", function () {
    LimtCharacters(this, 50);
});

$("#Str_duration3").on("input", function () {
    LimtCharacters(this, 50);
});

$("#others_duration1").on("input", function () {
    LimtCharacters(this, 50);
});

$("#others_duration2").on("input", function () {
    LimtCharacters(this, 50);
});
$("#others_duration3").on("input", function () {
    LimtCharacters(this, 50);
});

$("#others_duration4").on("input", function () {
    LimtCharacters(this, 50);
});


$("#Str_division").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_division1").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_division2").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_division3").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_division1").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_division2").on("input", function () {
    LimtCharacters(this, 100);
});
$("#others_division3").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_division4").on("input", function () {
    LimtCharacters(this, 100);
});




$("#Str_Marks").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_Marks1").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_Marks2").on("input", function () {
    LimtCharacters(this, 100);
});

$("#Str_Marks3").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_Marks1").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_Marks2").on("input", function () {
    LimtCharacters(this, 100);
});
$("#others_Marks3").on("input", function () {
    LimtCharacters(this, 100);
});

$("#others_Marks4").on("input", function () {
    LimtCharacters(this, 100);
});

//Experience

$("#Str_designation").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks").on("input", function () {
    LimtCharacters(this, 500);
});

$("#Str_designation1").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation1").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks1").on("input", function () {
    LimtCharacters(this, 500);
});

$("#Str_designation2").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation2").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks2").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation3").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation3").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks3").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation4").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation4").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks4").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation5").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation5").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks5").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation6").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation6").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks6").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation7").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation7").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks7").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation8").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation8").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks8").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation9").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation9").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks9").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation10").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation10").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks10").on("input", function () {
    LimtCharacters(this, 500);
});


$("#Str_designation11").on("input", function () {
    LimtCharacters(this, 50);
});
$("#str_organisation11").on("input", function () {
    LimtCharacters(this, 200);
});

$("#str_remarks11").on("input", function () {
    LimtCharacters(this, 500);
});

//Award & Scholarship 

$("#straward").on("input", function () {
    LimtCharacters(this, 100);
});
$("#straward1").on("input", function () {
    LimtCharacters(this, 100);
});

$("#straward2").on("input", function () {
    LimtCharacters(this, 100);
});
//PaperPresentation

$("#str_Publication_PaperPresentation").on("input", function () {
    LimtCharacters(this, 100);
});
$("#str_Publication_PaperPresentation1").on("input", function () {
    LimtCharacters(this, 100);
});

$("#str_Publication_PaperPresentation2").on("input", function () {
    LimtCharacters(this, 100);
});
//Other details
$("#strProfessionalBodies").on("input", function () {
    LimtCharacters(this, 500);
});
$("#strJoiningTimeReq").on("input", function () {
    LimtCharacters(this, 500);
});

$("#strJoinEarly").on("input", function () {
    LimtCharacters(this, 500);
});
//DD Details
$("#strOrderNo").on("input", function () {
    LimtCharacters(this, 50);
});
$("#strBankName").on("input", function () {
    LimtCharacters(this, 50);
});

$("#strBranch").on("input", function () {
    LimtCharacters(this, 50);
});

$("#decAmount").on("input", function () {
    LimtCharacters(this, 8);
});

$("#strAadharNo").on("input", function () {
    LimtCharacters(this, 12);
});
$("#strPANNo").on("input", function () {
    LimtCharacters(this, 10);
});



function LimtCharacters(txtMsg, CharLength) {
    $(txtMsg).next("span").remove();
    chars = txtMsg.value.length;
    if (chars > CharLength && chars > 0) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
        $(txtMsg).after("<span style='color:Red'> Max Length reached..</span>");
    }
}

function draft() {

    var noerror = 1;

    if ($("#fk_dicipline").val() == "") {
        $("#fk_dicipline").next("span").remove();
        $("#fk_dicipline").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#fk_postid").val() == "") {
        $("#fk_postid").next("span").remove();
        $("#fk_postid").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strCategory").val() == "") {
        $("#strCategory").next("span").remove();
        $("#strCategory").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (noerror == 1) {
        return true;

    }


    if (noerror == 0) {
        return false;



    }

}

//ERROR
function error() {
    //debugger;
    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var strTelephone = $("#strTelephone").val();
    var email = $("#strEmail").val();
    var strMobileNo = $("#strMobileNo").val();
    var strPermanentTelephoneNo = $("#strPermanentTelephoneNo").val();
    var strPermanentMobile1 = $("#strPermanentMobile1").val();
    var strPin = $("#strPin").val();
    var strPermanentPinCode = $("#strPermanentPinCode").val();

    




    // var fileInput = $('#str_UploadCaste');
    // var fileError = $('#fileError');

    // if (fileInput[0].files.length === 0 && ($("#strCategory").val() == "OBC (Non-Creamy Layer)" || $("#strCategory").val() == "ST" || $("#strCategory").val() == "SC")) {
        // // No file selected
        // $("#str_UploadCaste").next("span").remove();
        // $("#str_UploadCaste").after("<span style='color:Red'> This field is required</span>");
        // noerror = 0;
    // } 


    //if ($("#str_UploadCaste").val() == "" && (("#strCategory").val() == "OBC (Non-Creamy Layer)" || ("#strCategory").val() == "ST" || ("#strCategory").val() == "SC")) {
    //    $("#str_UploadCaste").next("span").remove();
    //    $("#str_UploadCaste").after("<span style='color:Red'> This field is required</span>");
    //    noerror = 0;
    //}


    var hidValue = $('#errorCount').val();

    //for upload only
    if ($("#str_uploadphoto").val() == "" && $("#hidstr_uploadphoto").val() == "") {
        $("#str_uploadphoto").next("span").remove();
        $("#str_uploadphoto").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#str_uploadsignature").val() == "" && $("#hidstr_uploadsignature").val() == "") {
        $("#str_uploadsignature").next("span").remove();
        $("#str_uploadsignature").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //for DD

    if ($("#strOrderNo").val() == "") {
        $("#strOrderNo").next("span").remove();
        $("#strOrderNo").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strBankName").val() == "") {
        $("#strBankName").next("span").remove();
        $("#strBankName").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strBranch").val() == "") {
        $("#strBranch").next("span").remove();
        $("#strBranch").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#dtIssueDate").val() == "") {
        $("#dtIssueDate").next("span").remove();
        $("#dtIssueDate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#decAmount").val() == "") {
        $("#decAmount").next("span").remove();
        $("#decAmount").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if (hidValue != "0" && $("#EduQulifi").val() == " ") {
        $("#EduQulifi").next("span").remove();
        $("#EduQulifi").after("<span style='color:Red'> This field is required</span>");

        noerror = 0;
    }




    if (hidValue == "1" && $("#Str_board2").val() == "") {
        $("#Str_board2").next("span").remove();
        $("#Str_board2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if (hidValue == "1" && $("#Str_passingdetails2").val() == "") {
    //        $("#Str_passingdetails2").next("span").remove();
    //        $("#Str_passingdetails2").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    //    if (hidValue == "1" && $("#Str_passingdetails2").val() == "") {
    //        $("#Str_passingdetails2").next("span").remove();
    //        $("#Str_passingdetails2").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    if (hidValue == "1" && $("#Str_duration2").val() == "") {
        $("#Str_duration2").next("span").remove();
        $("#Str_duration2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if (hidValue == "1" && $("#Str_passingyear2").val() == "") {

        $("#Str_passingyear2").next("span").remove();
        $("#Str_passingyear2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "1" && $("#Str_division2").val() == "") {
        $("#Str_division2").next("span").remove();
        $("#Str_division2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "1" && $("#Str_Marks2").val() == "") {
        $("#Str_Marks2").next("span").remove();
        $("#Str_Marks2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "1" && $("#StrRemarks2").val() == "") {
        $("#StrRemarks2").next("span").remove();
        $("#StrRemarks2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "2" && $("#Str_board3").val() == "") {

        $("#Str_board3").next("span").remove();
        $("#Str_board3").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if (hidValue == "2" && $("#Str_passingdetails3").val() == "") {
    //        $("#Str_passingdetails3").next("span").remove();
    //        $("#Str_passingdetails3").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    if (hidValue == "2" && $("#Str_duration3").val() == "") {
        $("#Str_duration3").next("span").remove();
        $("#Str_duration3").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "2" && $("#Str_passingyear3").val() == "") {
        $("#Str_passingyear3").next("span").remove();
        $("#Str_passingyear3").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "2" && $("#Str_division3").val() == "") {
        $("#Str_division3").next("span").remove();
        $("#Str_division3").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if (hidValue == "2" && $("#Str_Marks3").val() == "") {
        $("#Str_Marks3").next("span").remove();
        $("#Str_Marks3").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "2" && $("#StrRemarks3").val() == "") {
        $("#StrRemarks3").next("span").remove();
        $("#StrRemarks3").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    ///
    if (hidValue == "2" && $("#Str_board2").val() == "") {

        $("#Str_board2").next("span").remove();
        $("#Str_board2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if (hidValue == "2" && $("#Str_passingdetails2").val() == "") {
    //        $("#Str_passingdetails2").next("span").remove();
    //        $("#Str_passingdetails2").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    if (hidValue == "2" && $("#Str_duration2").val() == "") {
        $("#Str_duration2").next("span").remove();
        $("#Str_duration2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "2" && $("#Str_passingyear2").val() == "") {
        $("#Str_passingyear2").next("span").remove();
        $("#Str_passingyear2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "2" && $("#Str_division2").val() == "") {
        $("#Str_division2").next("span").remove();
        $("#Str_division2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if (hidValue == "2" && $("#Str_Marks2").val() == "") {
        $("#Str_Marks2").next("span").remove();
        $("#Str_Marks2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (hidValue == "2" && $("#StrRemarks2").val() == "") {
        $("#StrRemarks2").next("span").remove();
        $("#StrRemarks2").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    ///
    if ($("#Str_board").val() == "") {
        $("#Str_board").next("span").remove();
        $("#Str_board").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if ($("#Str_passingdetails").val() == "") {
    //        $("#Str_passingdetails").next("span").remove();
    //        $("#Str_passingdetails").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    if ($("#Str_duration").val() == "") {
        $("#Str_duration").next("span").remove();
        $("#Str_duration").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if ($("#Str_passingyear").val() == "") {
    //        $("#Str_passingyear").next("span").remove();
    //        $("#Str_passingyear").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    if ($("#Str_division").val() == "") {
        $("#Str_division").next("span").remove();
        $("#Str_division").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#Str_Marks").val() == "") {
        $("#Str_Marks").next("span").remove();
        $("#Str_Marks").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if ($("#StrRemarks").val() == "") {
    //        $("#StrRemarks").next("span").remove();
    //        $("#StrRemarks").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    //


    if ($("#Str_board1").val() == "") {
        $("#Str_board1").next("span").remove();
        $("#Str_board1").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if ($("#Str_passingdetails1").val() == "") {
    //        $("#Str_passingdetails1").next("span").remove();
    //        $("#Str_passingdetails1").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    if ($("#Str_duration1").val() == "") {
        $("#Str_duration1").next("span").remove();
        $("#Str_duration1").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if ($("#Str_passingyear1").val() == "") {
    //        $("#Str_passingyear1").next("span").remove();
    //        $("#Str_passingyear1").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    if ($("#Str_division1").val() == "") {
        $("#Str_division1").next("span").remove();
        $("#Str_division1").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#Str_Marks1").val() == "") {
        $("#Str_Marks1").next("span").remove();
        $("#Str_Marks1").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    //    if ($("#StrRemarks1").val() == "") {
    //        $("#StrRemarks1").next("span").remove();
    //        $("#StrRemarks1").after("<span style='color:Red'> This field is required</span>");
    //        noerror = 0;
    //    }

    if ($("#fk_dicipline").val() == "") {
        $("#fk_dicipline").next("span").remove();
        $("#fk_dicipline").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#fk_postid").val() == "") {
        $("#fk_postid").next("span").remove();
        $("#fk_postid").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#is_freshers").val() == "") {
        $("#is_freshers").next("span").remove();
        $("#is_freshers").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strApplicantName").val() == "") {
        $("#strApplicantName").next("span").remove();
        $("#strApplicantName").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#dtDOB").val() == "") {
        $("#dtDOB").next("span").remove();
        $("#dtDOB").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strEmail").val() == "") {
        $("#strEmail").next("span").remove();
        $("#strEmail").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strNationality").val() == "") {
        $("#strNationality").next("span").remove();
        $("#strNationality").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($.trim($("#strGender").val()) == "" || $("#strGender").val() == "Select") {
        $("#strGender").next("span").remove();
        $("#strGender").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($.trim($("#strReligion").val()) == "" || $("#strReligion").val() == "Select") {
        $("#strReligion").next("span").remove();
        $("#strReligion").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($.trim($("#strCategory").val()) == "" || $("#strCategory").val() == "Select") {
        $("#strCategory").next("span").remove();
        $("#strCategory").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#strsubcaste").val() == "") {
        $("#strsubcaste").next("span").remove();
        $("#strsubcaste").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "SC" && $("#strsubcaste").val() == "") {
        $("#strsubcaste").next("span").remove();
        $("#strsubcaste").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "ST" && $("#strsubcaste").val() == "") {
        $("#strsubcaste").next("span").remove();
        $("#strsubcaste").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#strcertificateno").val() == "") {
        $("#strcertificateno").next("span").remove();
        $("#strcertificateno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "SC" && $("#strcertificateno").val() == "") {
        $("#strcertificateno").next("span").remove();
        $("#strcertificateno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "ST" && $("#strcertificateno").val() == "") {
        $("#strcertificateno").next("span").remove();
        $("#strcertificateno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#dt_certificateissuedate").val() == "") {
        $("#dt_certificateissuedate").next("span").remove();
        $("#dt_certificateissuedate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "SC" && $("#dt_certificateissuedate").val() == "") {
        $("#dt_certificateissuedate").next("span").remove();
        $("#dt_certificateissuedate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "ST" && $("#dt_certificateissuedate").val() == "") {
        $("#dt_certificateissuedate").next("span").remove();
        $("#dt_certificateissuedate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "OBC (Non-Creamy Layer)" && $("#strcertificateissue").val() == "") {
        $("#strcertificateissue").next("span").remove();
        $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "SC" && $("#strcertificateissue").val() == "") {
        $("#strcertificateissue").next("span").remove();
        $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strCategory").val() == "ST" && $("#strcertificateissue").val() == "") {
        $("#strcertificateissue").next("span").remove();
        $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strMaritalStatus").val() == "") {
        $("#strMaritalStatus").next("span").remove();
        $("#strMaritalStatus").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strExserviceMan").val() == "") {
        $("#strExserviceMan").next("span").remove();
        $("#strExserviceMan").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strTestCity").val() == "") {
        $("#strTestCity").next("span").remove();
        $("#strTestCity").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }



    if ($("#strDomicilestate").val() == "") {
        $("#strDomicilestate").next("span").remove();
        $("#strDomicilestate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }



    if ($("#strExserviceMan").val() == "Yes" && $("#strexservicemanno").val() == "") {
        $("#strexservicemanno").next("span").remove();
        $("#strexservicemanno").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strPWD").val() == "") {
        $("#strPWD").next("span").remove();
        $("#strPWD").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPWD").val() == "Yes" && $("#strtypeofdisable").val() == "") {
        $("#strtypeofdisable").next("span").remove();
        $("#strtypeofdisable").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    //!---------------!Akshat COde Edit!--------------------

    if ($("#strPWD").val() == "Yes" && $("#strcertificateno1").val() == "") {
        $("#strcertificateno1").next("span").remove();
        $("#strcertificateno1").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPWD").val() == "Yes" && $("#dt_certificateissuedate1").val() == "") {
        $("#dt_certificateissuedate1").next("span").remove();
        $("#dt_certificateissuedate1").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPWD").val() == "Yes" && $("#strcertificateissue1").val() == "") {
        $("#strcertificateissue1").next("span").remove();
        $("#strcertificateissue1").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    // Add code by gaurav

    if ($("#strPWD").val() == "Yes" && $("#strScribe").val() == "") {
        $("#strScribe").next("span").remove();
        $("#strScribe").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }




    if ($("#strInternalCandidate").val() == "") {
        $("#strInternalCandidate").next("span").remove();
        $("#strInternalCandidate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }


    if ($("#strapplyproper").val() == "") {
        $("#strapplyproper").next("span").remove();
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strInternalCandidate").val() == "Yes" && $("#stremployeecode").val() == "") {
        $("#stremployeecode").next("span").remove();
        $("#stremployeecode").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strInternalCandidate").val() == "Yes" && $("#strgrade").val() == "") {
        $("#strgrade").next("span").remove();
        $("#strgrade").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strInternalCandidate").val() == "Yes" && $("#strplaceposting").val() == "") {
        $("#strplaceposting").next("span").remove();
        $("#strplaceposting").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strInternalCandidate").val() == "Yes" && $("#strpresentdesignation").val() == "") {
        $("#strpresentdesignation").next("span").remove();
        $("#strpresentdesignation").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strInternalCandidate").val() == "Yes" && $("#dt_presententrydate").val() == "") {
        $("#dt_presententrydate").next("span").remove();
        $("#dt_presententrydate").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strEmployedIn").val() == "") {
        $("#strEmployedIn").next("span").remove();
        $("#strEmployedIn").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strEmployedIn").val() == "Govt" && $("#strapplyproper").val() == "") {
        $("#strapplyproper").next("span").remove();
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strEmployedIn").val() == "Semi-Govt" && $("#strapplyproper").val() == "") {
        $("#strapplyproper").next("span").remove();
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strEmployedIn").val() == "PSU" && $("#strapplyproper").val() == "") {
        $("#strapplyproper").next("span").remove();
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#strCorrespondenceAddress").val() == "") {
        $("#strCorrespondenceAddress").next("span").remove();
        $("#strCorrespondenceAddress").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strState").val() == "") {
        $("#strState").next("span").remove();
        $("#strState").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strDistrict").val() == "") {
        $("#strDistrict").next("span").remove();
        $("#strDistrict").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPin").val() == "") {
        $("#strPin").next("span").remove();
        $("#strPin").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPermanentAddress").val() == "") {
        $("#strPermanentAddress").next("span").remove();
        $("#strPermanentAddress").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPermanentState").val() == "") {
        $("#strPermanentState").next("span").remove();
        $("#strPermanentState").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPermanentDistrict").val() == "") {
        $("#strPermanentDistrict").next("span").remove();
        $("#strPermanentDistrict").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strPermanentPinCode").val() == "") {
        $("#strPermanentPinCode").next("span").remove();
        $("#strPermanentPinCode").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if (strTelephone.toString().length < 11 && strTelephone != "") {
        $("#strTelephone").next("span").remove();
        $("#strTelephone").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
        noerror = 0;
    }
    if (strMobileNo.toString().length < 10 && strMobileNo != "") {
        $("#strMobileNo").next("span").remove();
        $("#strMobileNo").after("<span style='color:Red'>Mobile must be 10 digit</span>");
        noerror = 0;
    }
    if (strPermanentTelephoneNo.toString().length < 11 && strPermanentTelephoneNo != "") {
        $("#strPermanentTelephoneNo").next("span").remove();
        $("#strPermanentTelephoneNo").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
        noerror = 0;
    }
    if (strPermanentMobile1.toString().length < 10 && strPermanentMobile1 != "") {
        $("#strPermanentMobile1 ").next("span").remove();
        $("#strPermanentMobile1 ").after("<span style='color:Red'>Mobile must be 10 digit</span>");
        noerror = 0;
    }

    if (!emailReg.test(email)) {
        $("#strEmail").next("span").remove();
        $("#strEmail").after("<span style='color:Red'>Please enter valid Email </span>");
        noerror = 0;
    }
    if (strPin.toString().length < 6 && strPin != "") {
        $("#strPin ").next("span").remove();
        $("#strPin ").after("<span style='color:Red'>Pin must be 6 digit</span>");
        noerror = 0;
    }
    if (strPermanentPinCode.toString().length < 6 && strPermanentPinCode != "") {
        $("#strPermanentPinCode ").next("span").remove();
        $("#strPermanentPinCode ").after("<span style='color:Red'>Pin must be 6 digit</span>");
        noerror = 0;
    }

    if ($("#strPermanentNearestRailwayStation").val() == "") {
        $("#strPermanentNearestRailwayStation").next("span").remove();
        $("#strPermanentNearestRailwayStation").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }
    if ($("#strNearestRailwaystation").val() == "") {
        $("#strNearestRailwaystation").next("span").remove();
        $("#strNearestRailwaystation").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#tbl_mst_Order')[0].checkValidity()) {
                $("#is_freshers").removeAttr("disabled", "disabled");
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
//SameAddress
$('#SameF').click(function () {
    if (this.checked) {
        var strCorrespondenceAddress = $("#strCorrespondenceAddress").val();
        var strState = $("#strState").val();
        var strDistrict = $("#strDistrict").val();
        var strNearestPostOffice = $("#strNearestPostOffice").val();
        var strNearestPoliceStation = $("#strNearestPoliceStation").val();
        var strNearestRailwaystation = $("#strNearestRailwaystation").val();
        var strPin = $("#strPin").val();
        var strTelephone = $("#strTelephone").val();
        var strMobileNo = $("#strMobileNo").val();
        $("#strPermanentAddress").val(strCorrespondenceAddress);
        $("#strPermanentState").val(strState);
        $("#strPermanentDistrict").val(strDistrict);
        $("#strPermanentNearestPostOffice").val(strNearestPostOffice);
        $("#strPermanentNearestPoliceStation").val(strNearestPoliceStation);
        $("#strPermanentNearestRailwayStation").val(strNearestRailwaystation);
        $("#strPermanentPinCode").val(strPin);
        $("#strPermanentTelephoneNo").val(strTelephone);
        $("#strPermanentMobile1").val(strMobileNo);



    }

    else {
        $("#strPermanentAddress").val("");
        $("#strPermanentState").val("");
        $("#strPermanentDistrict").val("");
        $("#strPermanentNearestPostOffice").val("");
        $("#strPermanentNearestPoliceStation").val("");
        $("#strPermanentNearestRailwayStation").val("");
        $("#strPermanentPinCode").val("");
        $("#strPermanentTelephoneNo").val("");
        $("#strPermanentMobile1").val("");

    }

})
//disablefield
var end = $("#strCategory").val();

if (end == '') {

    $("#strsubcaste").attr('disabled', 'disabled');
}
if ($("#strsubcaste").val() == '') {
    $("#strsubcaste").attr('disabled', 'disabled');
}
if ($("#strcertificateno").val() == '') {
    $("#strcertificateno").attr('disabled', 'disabled');
}
if ($("#dt_certificateissuedate").val() == '') {
    $("#dt_certificateissuedate").attr('disabled', 'disabled');
}
if ($("#strcertificateissue").val() == '') {
    $("#strcertificateissue").attr('disabled', 'disabled');
}
if ($("#strexservicemanno").val() == '') {
    $("#strexservicemanno").attr('disabled', 'disabled');
}
if ($("#strtypeofdisable").val() == '') {
    $("#strtypeofdisable").attr('disabled', 'disabled');
}
if ($("#strcertificateno1").val() == '') {
    $("#strcertificateno1").attr('disabled', 'disabled');
}
if ($("#dt_certificateissuedate1").val() == '') {
    $("#dt_certificateissuedate1").attr('disabled', 'disabled');
}
if ($("#strcertificateissue1").val() == '') {
    $("#strcertificateissue1").attr('disabled', 'disabled');
}
if ($("#strScribe").val() == '') {
    $("#strScribe").attr('disabled', 'disabled');
}
if ($("#stremployeecode").val() == '') {
    $("#stremployeecode").attr('disabled', 'disabled');
}
if ($("#strgrade").val() == '') {
    $("#strgrade").attr('disabled', 'disabled');
}
if ($("#strplaceposting").val() == '') {
    $("#strplaceposting").attr('disabled', 'disabled');
}
if ($("#strpresentdesignation").val() == '') {
    $("#strpresentdesignation").attr('disabled', 'disabled');
}
if ($("#dt_presententrydate").val() == '') {
    $("#dt_presententrydate").attr('disabled', 'disabled');
}
//if ($("#strapplyproper").val() == '') {
//    $("#strapplyproper").attr('disabled', 'disabled');
//}

//Disable Label
$("#lblsubcaste").hide();
$("#lblcertificateno").hide();
$("#lblissuedate").hide();
$("#lblcertificateissue").hide();
$("#lblexservicemanno").hide();
$("#lbltypeofdisable").hide();
$("#lblcertificateno1").hide();
$("#lblcertificateissuedate1").hide();
$("#lblcertificateissue1").hide();
$("#lblemployeecode").hide();
$("#lblgrade").hide();
$("#lblplaceposting").hide();
$("#lblpresentdesignation").hide();
$("#lblpresententrydate").hide();
$("#lblapplyproper").hide();
$("#lblisScribe").hide();



//Category
$("#strCategory").change(function () {

    
    
    // $('#str_UploadCaste').val('');
    // $('#str_UploadCaste').next("span").remove();
    $(".clsEduDoc").val('');
    $('.clsEduDoc').attr('href', '');
    $('.clsEduDoc').text('-');

    var strCategory = $("#strCategory").val();
    $("#strCategory").next("span").remove();
    if (strCategory == "") {
        $("#strCategory").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strCategory").next("span").remove();
        Category();
    }
});
function Category() {
   
    var end = $("#strCategory").val();
    if (end !== 'General') {
        $("#lblsubcaste").show();
        $("#lblcertificateno").show();
        $("#lblissuedate").show();
        $("#lblcertificateissue").show();
        $("#strsubcaste").removeAttr('disabled');
        $("#strcertificateno").removeAttr('disabled');
        $("#dt_certificateissuedate").removeAttr('disabled');
        $("#strcertificateissue").removeAttr('disabled');
        // $(".UploadCaste").show();



    }
    else {
        $("#lblsubcaste").hide();
        $("#lblcertificateno").hide();
        $("#lblissuedate").hide();
        $("#lblcertificateissue").hide();
        $("#strsubcaste").attr('disabled', 'disabled');
        $("#strcertificateno").attr('disabled', 'disabled');
        $("#dt_certificateissuedate").attr('disabled', 'disabled');
        $("#strcertificateissue").attr('disabled', 'disabled');
        $("#strsubcaste").val('');
        $("#strcertificateno").val('');
        $("#dt_certificateissuedate").val('');
        $("#strcertificateissue").val('');
        $("#strsubcaste").next("span").remove();
        $("#strcertificateno").next("span").remove();
        $("#dt_certificateissuedate").next("span").remove();
        $("#strcertificateissue").next("span").remove();
        // $(".UploadCaste").hide();

        

       
        
    }

}
//exserviceman
$("#strExserviceMan").change(function () {

    var strExserviceMan = $("#strExserviceMan").val();
    $("#strExserviceMan").next("span").remove();
    if (strExserviceMan == "") {
        $("#strExserviceMan").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strExserviceMan").next("span").remove();
        exserviceman();
    }
});
function exserviceman() {
    var end = $("#strExserviceMan").val();

    if (end !== 'Yes') {

        $("#lblexservicemanno").hide();

        $("#strexservicemanno").attr('disabled', 'disabled');
        $("#strexservicemanno").val('');
        $("#strexservicemanno").next("span").remove();
    }
    else {

        $("#lblexservicemanno").show();
        $("#strexservicemanno").removeAttr('disabled');



    }

}
//pwd
$("#strPWD").change(function () {

    var strPWD = $("#strPWD").val();
    $("#strPWD").next("span").remove();
    if (strPWD == "") {
        $("#strPWD").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strPWD").next("span").remove();
        pwd();
    }
});
function pwd() {
    debugger;
    var end = $("#strPWD").val();
    if (end == 'Yes') {
        $("#lbltypeofdisable").show();
        $("#lblcertificateno1").show();
        $("#lblcertificateissuedate1").show();
        $("#lblcertificateissue1").show();
        $("#strtypeofdisable").removeAttr('disabled');
        $("#strcertificateno1").removeAttr('disabled');
        $("#dt_certificateissuedate1").removeAttr('disabled');
        $("#strcertificateissue1").removeAttr('disabled');
        $("#lblisScribe").show();     
        $("#strScribe").removeAttr('disabled');
    }
    else {
        $("#lbltypeofdisable").hide();
        $("#lblcertificateno1").hide();
        $("#lblcertificateissuedate1").hide();
        $("#lblcertificateissue1").hide();
        $("#strtypeofdisable").attr('disabled', 'disabled');
        $("#strcertificateno1").attr('disabled', 'disabled');
        $("#dt_certificateissuedate1").attr('disabled', 'disabled');
        $("#strcertificateissue1").attr('disabled', 'disabled');
        $("#strtypeofdisable").val('');
        $("#strcertificateno1").val('');
        $("#dt_certificateissuedate1").val('');
        $("#strcertificateissue1").val('');
        $("#strtypeofdisable").next("span").remove();
        $("#strcertificateno1").next("span").remove();
        $("#dt_certificateissuedate1").next("span").remove();
        $("#strcertificateissue1").next("span").remove();
        $("#lblisScribe").hide();     // hide (*) mark
        $("#strScribe").attr('disabled', 'disabled');
        $("#strScribe").val('');
        $("#strScribe").next("span").remove();
    }

}

$("#strapplyproper").change(function () {
    var strapplyproper = $("#strapplyproper").val();
    $("#strapplyproper").next("span").remove();
    if (strapplyproper == "") {
        $("#strapplyproper").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strapplyproper").next("span").remove();
    }
});

//internalcandidate
$("#strInternalCandidate").change(function () {

    var strInternalCandidate = $("#strInternalCandidate").val();
    $("#strInternalCandidate").next("span").remove();
    if (strInternalCandidate == "") {
        $("#strInternalCandidate").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strInternalCandidate").next("span").remove();
        internalcandidate();
    }
});
function internalcandidate() {
    var end = $("#strInternalCandidate").val();
    if (end == 'Yes') {
        $("#lblemployeecode").show();
        $("#lblgrade").show();
        $("#lblplaceposting").show();
        $("#lblpresentdesignation").show();
        $("#lblpresententrydate").show();
        $("#stremployeecode").removeAttr('disabled');
        $("#strgrade").removeAttr('disabled');
        $("#strplaceposting").removeAttr('disabled');
        $("#strpresentdesignation").removeAttr('disabled');
        $("#dt_presententrydate").removeAttr('disabled');

    }
    else {
        $("#lblemployeecode").hide();
        $("#lblgrade").hide();
        $("#lblplaceposting").hide();
        $("#lblpresentdesignation").hide();
        $("#lblpresententrydate").hide();
        $("#stremployeecode").attr('disabled', 'disabled');
        $("#strgrade").attr('disabled', 'disabled');
        $("#strplaceposting").attr('disabled', 'disabled');
        $("#strpresentdesignation").attr('disabled', 'disabled');
        $("#dt_presententrydate").attr('disabled', 'disabled');

        $("#stremployeecode").val('');
        $("#strgrade").val('');
        $("#strplaceposting").val('');
        $("#strpresentdesignation").val('');
        $("#dt_presententrydate").val('');
        $("#stremployeecode").next("span").remove();
        $("#strgrade").next("span").remove();
        $("#strplaceposting").next("span").remove();
        $("#strpresentdesignation").next("span").remove();
        $("#dt_presententrydate").next("span").remove();

    }

}
//Apply through
$("#strEmployedIn").change(function () {
    var strEmployedIn = $("#strEmployedIn").val();
    $("#strEmployedIn").next("span").remove();
    if (strEmployedIn == "") {
        $("#strEmployedIn").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#strEmployedIn").next("span").remove();
        Apply();
    }
});
function Apply() {
    var end = $("#strEmployedIn").val();
    if (end == 'N/A') {

    $("#lblapplyproper").hide();
    $("#strapplyproper").val('');
        /* $("#strapplyproper").attr('disabled', 'disabled');*/
        $("#strapplyproper").off('mousedown').off('keydown');
    $("#strapplyproper").next("span").remove();
}
else if (end == 'Private' || end == 'Not Applicable')
{
    $("#lblapplyproper").hide();
    $("#strapplyproper").val('Not Applicable');
    $("#strapplyproper").attr('readonly', 'readonly');
        /* $("#strapplyproper").attr('disabled', 'disabled');*/
        $("#strapplyproper").on('mousedown keydown', function (e) {
            e.preventDefault();
            this.blur();
            return false;
        });
    $("#strapplyproper").next("span").remove();
}
else {

    $("#lblapplyproper").show();
 //   $("#strapplyproper").removeAttr('disabled');
	$("#strapplyproper").removeAttr('readonly');
        $("#strapplyproper").off('mousedown').off('keydown');

}

}
//Educational Qualification InActive
if ($("#StrRemarks").val() == "Pursuing" && $("#Str_passingyear").val() == "") {
    $("#Str_passingyear").next("span").remove();
    $("#Str_passingyear").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}

if ($("#StrRemarks").val() == "") {
    $("#StrRemarks").next("span").remove();
    $("#StrRemarks").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}

if ($("#Str_passingyear").val() == "") {
    $("#Str_passingyear").next("span").remove();
    $("#Str_passingyear").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}

if ($("#StrRemarks1").val() == "Pursuing" && $("#Str_passingyear1").val() == "") {
    $("#Str_passingyear1").next("span").remove();
    $("#Str_passingyear1").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}

if ($("#StrRemarks1").val() == "") {
    $("#StrRemarks1").next("span").remove();
    $("#StrRemarks1").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}

if ($("#Str_passingyear1").val() == "") {
    $("#Str_passingyear1").next("span").remove();
    $("#Str_passingyear1").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}

$("#StrRemarks").change(function () {
    var StrRemarks = $("#StrRemarks").val();
    $("#StrRemarks").next("span").remove();
    if (StrRemarks == "") {
        $("#StrRemarks").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrRemarks").next("span").remove();
        Remarks();
    }
});

function Remarks() {
    var end = $("#StrRemarks").val();
    if (end == 'Pursuing') {
        $("#Str_passingyear").val($("#hidMaxExpdate").val());
        $("#Str_passingyear").attr('disabled', 'disabled');
        $("#Str_passingyear").next("span").remove();
    }
    else {
        $("#Str_passingyear").removeAttr('disabled');

    }

}

$("#StrRemarks1").change(function () {
    var StrRemarks1 = $("#StrRemarks1").val();
    $("#StrRemarks1").next("span").remove();
    if (StrRemarks1 == "") {
        $("#StrRemarks1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrRemarks1").next("span").remove();
        Remarks1();
    }
});

function Remarks1() {
    var end = $("#StrRemarks1").val();
    if (end == 'Pursuing') {
        $("#Str_passingyear1").val($("#hidMaxExpdate").val());
        $("#Str_passingyear1").attr('disabled', 'disabled');
        $("#Str_passingyear1").next("span").remove();
    }
    else {
        $("#Str_passingyear1").removeAttr('disabled');

    }

}
$("#StrRemarks2").change(function () {
    var StrRemarks2 = $("#StrRemarks2").val();
    $("#StrRemarks2").next("span").remove();
    if (StrRemarks2 == "") {
        $("#StrRemarks2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrRemarks2").next("span").remove();
        Remarks2();
    }
});

function Remarks2() {
    var end = $("#StrRemarks2").val();
    if (end == 'Pursuing') {
        $("#Str_passingyear2").val($("#hidMaxExpdate").val());
        $("#Str_passingyear2").attr('disabled', 'disabled');
        $("#Str_passingyear2").next("span").remove();
    }
    else {
        $("#Str_passingyear2").removeAttr('disabled');

    }

}

$("#StrRemarks3").change(function () {
    var StrRemarks3 = $("#StrRemarks3").val();
    $("#StrRemarks3").next("span").remove();
    if (StrRemarks3 == "") {
        $("#StrRemarks3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrRemarks3").next("span").remove();
        Remarks3();
    }
});

function Remarks3() {
    var end = $("#StrRemarks3").val();
    if (end == 'Pursuing') {
        $("#Str_passingyear3").val($("#hidMaxExpdate").val());
        $("#Str_passingyear3").attr('disabled', 'disabled');
        $("#Str_passingyear3").next("span").remove();
    }
    else {
        $("#Str_passingyear3").removeAttr('disabled');

    }

}


$("#others_Remarks1").change(function () {
    var others_Remarks1 = $("#others_Remarks1").val();
    $("#others_Remarks1").next("span").remove();
    if (others_Remarks1 == "") {
        $("#others_Remarks1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#others_Remarks1").next("span").remove();
        othersRemarks1();
    }
});

function othersRemarks1() {
    var end = $("#others_Remarks1").val();
    if (end == 'Pursuing') {
        $("#others_passingyear1").val($("#hidMaxExpdate").val());
        $("#others_passingyear1").attr('disabled', 'disabled');
        $("#others_passingyear1").next("span").remove();
    }
    else {
        $("#others_passingyear1").removeAttr('disabled');

    }

}

$("#others_Remarks2").change(function () {
    var others_Remarks2 = $("#others_Remarks2").val();
    $("#others_Remarks2").next("span").remove();
    if (others_Remarks2 == "") {
        $("#others_Remarks2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#others_Remarks2").next("span").remove();
        othersRemarks2();
    }
});

function othersRemarks2() {
    var end = $("#others_Remarks2").val();
    if (end == 'Pursuing') {
        $("#others_passingyear2").val($("#hidMaxExpdate").val());
        $("#others_passingyear2").attr('disabled', 'disabled');
        $("#others_passingyear2").next("span").remove();
    }
    else {
        $("#others_passingyear2").removeAttr('disabled');

    }

}

$("#others_Remarks3").change(function () {
    var others_Remarks3 = $("#others_Remarks3").val();
    $("#others_Remarks3").next("span").remove();
    if (others_Remarks3 == "") {
        $("#others_Remarks3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#others_Remarks3").next("span").remove();
        othersRemarks3();
    }
});

function othersRemarks3() {
    var end = $("#others_Remarks3").val();
    if (end == 'Pursuing') {
        $("#others_passingyear3").val($("#hidMaxExpdate").val());
        $("#others_passingyear3").attr('disabled', 'disabled');
        $("#others_passingyear3").next("span").remove();
    }
    else {
        $("#others_passingyear3").removeAttr('disabled');

    }

}

$("#others_Remarks4").change(function () {
    var others_Remarks4 = $("#others_Remarks4").val();
    $("#others_Remarks4").next("span").remove();
    if (others_Remarks4 == "") {
        $("#others_Remarks4").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#others_Remarks4").next("span").remove();
        othersRemarks4();
    }
});

function othersRemarks4() {
    var end = $("#others_Remarks4").val();
    if (end == 'Pursuing') {
        $("#others_passingyear4").val($("#hidMaxExpdate").val());
        $("#others_passingyear4").attr('disabled', 'disabled');
        $("#others_passingyear4").next("span").remove();
    }
    else {
        $("#others_passingyear4").removeAttr('disabled');

    }

}

//Experience Details
if ($("#StrEmploymentPresentStatus").val() == "Currently Working" && $("#dt_todate").val() == "") {
    $("#dt_todate").next("span").remove();
    $("#dt_todate").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus").change(function () {
    var StrEmploymentPresentStatus = $("#StrEmploymentPresentStatus").val();
    $("#StrEmploymentPresentStatus").next("span").remove();
    if (StrEmploymentPresentStatus == "") {
        $("#StrEmploymentPresentStatus").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus").next("span").remove();
        EmploymentPresentStatus();
    }
});


function EmploymentPresentStatus() {
    var end = $("#StrEmploymentPresentStatus").val();
    if (end == 'Currently Working') {
        $("#dt_todate").val($("#hidMaxExpdate").val());
        $("#dt_todate").attr('disabled', 'disabled');
        $("#dt_todate").next("span").remove();
        $("#dt_fromdate").val('');
        $("#str_noyears").val('');

        $("#str_organisation").val('');
        $("#Str_designation").val('');
        $("#str_CTC").val('');
        $("#str_PayScale").val('');

        GetTotalYear();
    }
    else {

        $("#dt_fromdate").val('');
        $("#dt_todate").val('');
        $("#str_noyears").val('');

        $("#str_organisation").val('');
        $("#Str_designation").val('');
        $("#str_CTC").val('');
        $("#str_PayScale").val('');
        GetTotalYear();
        $("#dt_todate").removeAttr('disabled');

    }

}

if ($("#StrEmploymentPresentStatus1").val() == "Currently Working" && $("#dt_todate1").val() == "") {
    $("#dt_todate1").next("span").remove();
    $("#dt_todate1").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus1").change(function () {
    var StrEmploymentPresentStatus1 = $("#StrEmploymentPresentStatus1").val();
    $("#StrEmploymentPresentStatus1").next("span").remove();
    if (StrEmploymentPresentStatus1 == "") {
        $("#StrEmploymentPresentStatus1").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus1").next("span").remove();
        EmploymentPresentStatus1();
    }
});


function EmploymentPresentStatus1() {
    var end = $("#StrEmploymentPresentStatus1").val();
    if (end == 'Currently Working') {
        $("#dt_todate1").val($("#hidMaxExpdate").val());
        $("#dt_todate1").attr('disabled', 'disabled');
        $("#dt_todate1").next("span").remove();

        $("#dt_fromdate1").val('');
        $("#str_noyears1").val('');


        $("#str_organisation1").val('');
        $("#Str_designation1").val('');
        $("#str_CTC1").val('');
        $("#str_PayScale1").val('');
        GetTotalYear();
    }
    else {
        $("#dt_fromdate1").val('');
        $("#dt_todate1").val('');
        $("#str_noyears1").val('');


        $("#str_organisation1").val('');
        $("#Str_designation1").val('');
        $("#str_CTC1").val('');
        $("#str_PayScale1").val('');

        GetTotalYear();

        $("#dt_todate1").removeAttr('disabled');

    }

}


if ($("#StrEmploymentPresentStatus2").val() == "Currently Working" && $("#dt_todate2").val() == "") {
    $("#dt_todate2").next("span").remove();
    $("#dt_todate2").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus2").change(function () {
    var StrEmploymentPresentStatus2 = $("#StrEmploymentPresentStatus2").val();
    $("#StrEmploymentPresentStatus2").next("span").remove();
    if (StrEmploymentPresentStatus2 == "") {
        $("#StrEmploymentPresentStatus2").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus2").next("span").remove();
        EmploymentPresentStatus2();
    }
});


function EmploymentPresentStatus2() {
    var end = $("#StrEmploymentPresentStatus2").val();
    if (end == 'Currently Working') {
        $("#dt_todate2").val($("#hidMaxExpdate").val());
        $("#dt_todate2").attr('disabled', 'disabled');
        $("#dt_todate2").next("span").remove();

        $("#dt_fromdate2").val('');
        $("#str_noyears2").val('');


        $("#str_organisation2").val('');
        $("#Str_designation2").val('');
        $("#str_CTC2").val('');
        $("#str_PayScale2").val('');

        GetTotalYear();
    }
    else {
        $("#dt_fromdate2").val('');
        $("#dt_todate2").val('');
        $("#str_noyears2").val('');


        $("#str_organisation2").val('');
        $("#Str_designation2").val('');
        $("#str_CTC2").val('');
        $("#str_PayScale2").val('');

        GetTotalYear();
        $("#dt_todate2").removeAttr('disabled');

    }

}


if ($("#StrEmploymentPresentStatus3").val() == "Currently Working" && $("#dt_todate3").val() == "") {
    $("#dt_todate3").next("span").remove();
    $("#dt_todate3").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus3").change(function () {
    var StrEmploymentPresentStatus3 = $("#StrEmploymentPresentStatus3").val();
    $("#StrEmploymentPresentStatus3").next("span").remove();
    if (StrEmploymentPresentStatus3 == "") {
        $("#StrEmploymentPresentStatus3").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus3").next("span").remove();
        EmploymentPresentStatus3();
    }
});


function EmploymentPresentStatus3() {
    var end = $("#StrEmploymentPresentStatus3").val();
    if (end == 'Currently Working') {
        $("#dt_todate3").val($("#hidMaxExpdate").val());
        $("#dt_todate3").attr('disabled', 'disabled');
        $("#dt_todate3").next("span").remove();

        $("#dt_fromdate3").val('');
        $("#str_noyears3").val('');


        $("#str_organisation3").val('');
        $("#Str_designation3").val('');
        $("#str_CTC3").val('');
        $("#str_PayScale3").val('');

        GetTotalYear();
    }
    else {
        $("#dt_fromdate3").val('');
        $("#dt_todate3").val('');
        $("#str_noyears3").val('');


        $("#str_organisation3").val('');
        $("#Str_designation3").val('');
        $("#str_CTC3").val('');
        $("#str_PayScale3").val('');

        GetTotalYear();

        $("#dt_todate3").removeAttr('disabled');

    }

}


if ($("#StrEmploymentPresentStatus4").val() == "Currently Working" && $("#dt_todate4").val() == "") {
    $("#dt_todate4").next("span").remove();
    $("#dt_todate4").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus4").change(function () {
    var StrEmploymentPresentStatus4 = $("#StrEmploymentPresentStatus4").val();
    $("#StrEmploymentPresentStatus4").next("span").remove();
    if (StrEmploymentPresentStatus4 == "") {
        $("#StrEmploymentPresentStatus4").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus4").next("span").remove();
        EmploymentPresentStatus4();
    }
});


function EmploymentPresentStatus4() {
    var end = $("#StrEmploymentPresentStatus4").val();
    if (end == 'Currently Working') {
        $("#dt_todate4").val($("#hidMaxExpdate").val());
        $("#dt_todate4").attr('disabled', 'disabled');
        $("#dt_todate4").next("span").remove();

        $("#dt_fromdate4").val('');
        $("#str_noyears4").val('');


        $("#str_organisation4").val('');
        $("#Str_designation4").val('');
        $("#str_CTC4").val('');
        $("#str_PayScale4").val('');

        GetTotalYear();
    }
    else {
        $("#dt_fromdate4").val('');
        $("#dt_todate4").val('');
        $("#str_noyears4").val('');


        $("#str_organisation4").val('');
        $("#Str_designation4").val('');
        $("#str_CTC4").val('');
        $("#str_PayScale4").val('');

        GetTotalYear();


        $("#dt_todate4").removeAttr('disabled');

    }

}





if ($("#StrEmploymentPresentStatus5").val() == "Currently Working" && $("#dt_todate5").val() == "") {
    $("#dt_todate5").next("span").remove();
    $("#dt_todate5").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus5").change(function () {
    var StrEmploymentPresentStatus5 = $("#StrEmploymentPresentStatus5").val();
    $("#StrEmploymentPresentStatus5").next("span").remove();
    if (StrEmploymentPresentStatus5 == "") {
        $("#StrEmploymentPresentStatus5").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus5").next("span").remove();
        EmploymentPresentStatus5();
    }
});


function EmploymentPresentStatus5() {
    var end = $("#StrEmploymentPresentStatus5").val();
    if (end == 'Currently Working') {
        $("#dt_todate5").val($("#hidMaxExpdate").val());
        $("#dt_todate5").attr('disabled', 'disabled');
        $("#dt_todate5").next("span").remove();

        $("#dt_fromdate5").val('');
        $("#str_noyears5").val('');
        GetTotalYear();


        $("#str_organisation5").val('');
        $("#Str_designation5").val('');
        $("#str_CTC5").val('');
        $("#str_PayScale5").val('');
    }
    else {
        $("#dt_fromdate5").val('');
        $("#dt_todate5").val('');
        $("#str_noyears5").val('');
        GetTotalYear();


        $("#str_organisation5").val('');
        $("#Str_designation5").val('');
        $("#str_CTC5").val('');
        $("#str_PayScale5").val('');

        $("#dt_todate5").removeAttr('disabled');

    }

}







if ($("#StrEmploymentPresentStatus6").val() == "Currently Working" && $("#dt_todate6").val() == "") {
    $("#dt_todate6").next("span").remove();
    $("#dt_todate6").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus6").change(function () {
    var StrEmploymentPresentStatus6 = $("#StrEmploymentPresentStatus6").val();
    $("#StrEmploymentPresentStatus6").next("span").remove();
    if (StrEmploymentPresentStatus6 == "") {
        $("#StrEmploymentPresentStatus6").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus6").next("span").remove();
        EmploymentPresentStatus6();
    }
});


function EmploymentPresentStatus6() {
    var end = $("#StrEmploymentPresentStatus6").val();
    if (end == 'Currently Working') {
        $("#dt_todate6").val($("#hidMaxExpdate").val());
        $("#dt_todate6").attr('disabled', 'disabled');
        $("#dt_todate6").next("span").remove();

        $("#dt_fromdate6").val('');
        $("#str_noyears6").val('');
        GetTotalYear();


        $("#str_organisation6").val('');
        $("#Str_designation6").val('');
        $("#str_CTC6").val('');
        $("#str_PayScale6").val('');
    }
    else {
        $("#dt_fromdate6").val('');
        $("#dt_todate6").val('');
        $("#str_noyears6").val('');
        GetTotalYear();


        $("#str_organisation6").val('');
        $("#Str_designation6").val('');
        $("#str_CTC6").val('');
        $("#str_PayScale6").val('');

        $("#dt_todate6").removeAttr('disabled');

    }

}





if ($("#StrEmploymentPresentStatus7").val() == "Currently Working" && $("#dt_todate7").val() == "") {
    $("#dt_todate7").next("span").remove();
    $("#dt_todate7").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus7").change(function () {
    var StrEmploymentPresentStatus7 = $("#StrEmploymentPresentStatus7").val();
    $("#StrEmploymentPresentStatus7").next("span").remove();
    if (StrEmploymentPresentStatus7 == "") {
        $("#StrEmploymentPresentStatus7").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus7").next("span").remove();
        EmploymentPresentStatus7();
    }
});


function EmploymentPresentStatus7() {
    var end = $("#StrEmploymentPresentStatus7").val();
    if (end == 'Currently Working') {
        $("#dt_todate7").val($("#hidMaxExpdate").val());
        $("#dt_todate7").attr('disabled', 'disabled');
        $("#dt_todate7").next("span").remove();

        $("#dt_fromdate7").val('');
        $("#str_noyears7").val('');
        GetTotalYear();


        $("#str_organisation7").val('');
        $("#Str_designation7").val('');
        $("#str_CTC7").val('');
        $("#str_PayScale7").val('');
    }
    else {
        $("#dt_fromdate7").val('');
        $("#dt_todate7").val('');
        $("#str_noyears7").val('');
        GetTotalYear();


        $("#str_organisation7").val('');
        $("#Str_designation7").val('');
        $("#str_CTC7").val('');
        $("#str_PayScale7").val('');

        $("#dt_todate7").removeAttr('disabled');

    }

}






if ($("#StrEmploymentPresentStatus8").val() == "Currently Working" && $("#dt_todate8").val() == "") {
    $("#dt_todate8").next("span").remove();
    $("#dt_todate8").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus8").change(function () {
    var StrEmploymentPresentStatus8 = $("#StrEmploymentPresentStatus8").val();
    $("#StrEmploymentPresentStatus8").next("span").remove();
    if (StrEmploymentPresentStatus8 == "") {
        $("#StrEmploymentPresentStatus8").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus8").next("span").remove();
        EmploymentPresentStatus8();
    }
});


function EmploymentPresentStatus8() {
    var end = $("#StrEmploymentPresentStatus8").val();
    if (end == 'Currently Working') {
        $("#dt_todate8").val($("#hidMaxExpdate").val());
        $("#dt_todate8").attr('disabled', 'disabled');
        $("#dt_todate8").next("span").remove();

        $("#dt_fromdate8").val('');
        $("#str_noyears8").val('');
        GetTotalYear();


        $("#str_organisation8").val('');
        $("#Str_designation8").val('');
        $("#str_CTC8").val('');
        $("#str_PayScale8").val('');
    }
    else {
        $("#dt_fromdate8").val('');
        $("#dt_todate8").val('');
        $("#str_noyears8").val('');
        GetTotalYear();


        $("#str_organisation8").val('');
        $("#Str_designation8").val('');
        $("#str_CTC8").val('');
        $("#str_PayScale8").val('');

        $("#dt_todate8").removeAttr('disabled');

    }

}





if ($("#StrEmploymentPresentStatus9").val() == "Currently Working" && $("#dt_todate9").val() == "") {
    $("#dt_todate9").next("span").remove();
    $("#dt_todate9").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus9").change(function () {
    var StrEmploymentPresentStatus9 = $("#StrEmploymentPresentStatus9").val();
    $("#StrEmploymentPresentStatus9").next("span").remove();
    if (StrEmploymentPresentStatus9 == "") {
        $("#StrEmploymentPresentStatus9").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus9").next("span").remove();
        EmploymentPresentStatus9();
    }
});


function EmploymentPresentStatus9() {
    var end = $("#StrEmploymentPresentStatus9").val();
    if (end == 'Currently Working') {
        $("#dt_todate9").val($("#hidMaxExpdate").val());
        $("#dt_todate9").attr('disabled', 'disabled');
        $("#dt_todate9").next("span").remove();

        $("#dt_fromdate9").val('');
        $("#str_noyears9").val('');
        GetTotalYear();


        $("#str_organisation9").val('');
        $("#Str_designation9").val('');
        $("#str_CTC9").val('');
        $("#str_PayScale9").val('');
    }
    else {
        $("#dt_fromdate9").val('');
        $("#dt_todate9").val('');
        $("#str_noyears9").val('');
        GetTotalYear();


        $("#str_organisation9").val('');
        $("#Str_designation9").val('');
        $("#str_CTC9").val('');
        $("#str_PayScale9").val('');

        $("#dt_todate9").removeAttr('disabled');

    }

}





if ($("#StrEmploymentPresentStatus10").val() == "Currently Working" && $("#dt_todate10").val() == "") {
    $("#dt_todate10").next("span").remove();
    $("#dt_todate10").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus10").change(function () {
    var StrEmploymentPresentStatus10 = $("#StrEmploymentPresentStatus10").val();
    $("#StrEmploymentPresentStatus10").next("span").remove();
    if (StrEmploymentPresentStatus10 == "") {
        $("#StrEmploymentPresentStatus10").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus10").next("span").remove();
        EmploymentPresentStatus10();
    }
});


function EmploymentPresentStatus10() {
    var end = $("#StrEmploymentPresentStatus10").val();
    if (end == 'Currently Working') {
        $("#dt_todate10").val($("#hidMaxExpdate").val());
        $("#dt_todate10").attr('disabled', 'disabled');
        $("#dt_todate10").next("span").remove();

        $("#dt_fromdate10").val('');
        $("#str_noyears10").val('');
        GetTotalYear();


        $("#str_organisation10").val('');
        $("#Str_designation10").val('');
        $("#str_CTC10").val('');
        $("#str_PayScale10").val('');
    }
    else {
        $("#dt_fromdate10").val('');
        $("#dt_todate10").val('');
        $("#str_noyears10").val('');
        GetTotalYear();


        $("#str_organisation10").val('');
        $("#Str_designation10").val('');
        $("#str_CTC10").val('');
        $("#str_PayScale10").val('');

        $("#dt_todate10").removeAttr('disabled');

    }

}


if ($("#StrEmploymentPresentStatus11").val() == "Currently Working" && $("#dt_todate11").val() == "") {
    $("#dt_todate11").next("span").remove();
    $("#dt_todate11").after("<span style='color:Red'> This field is required</span>");
    noerror = 0;
}


$("#StrEmploymentPresentStatus11").change(function () {
    var StrEmploymentPresentStatus11 = $("#StrEmploymentPresentStatus11").val();
    $("#StrEmploymentPresentStatus11").next("span").remove();
    if (StrEmploymentPresentStatus11 == "") {
        $("#StrEmploymentPresentStatus11").after("<span style='color:Red'> This field is required</span>");
    }
    else {
        $("#StrEmploymentPresentStatus11").next("span").remove();
        EmploymentPresentStatus11();
    }
});


function EmploymentPresentStatus11() {
    var end = $("#StrEmploymentPresentStatus11").val();
    if (end == 'Currently Working') {
        $("#dt_todate11").val($("#hidMaxExpdate").val());
        $("#dt_todate11").attr('disabled', 'disabled');
        $("#dt_todate11").next("span").remove();

        $("#dt_fromdate11").val('');
        $("#str_noyears11").val('');
        GetTotalYear();


        $("#str_organisation11").val('');
        $("#Str_designation11").val('');
        $("#str_CTC11").val('');
        $("#str_PayScale11").val('');
    }
    else {
        $("#dt_fromdate11").val('');
        $("#dt_todate11").val('');
        $("#str_noyears11").val('');
        GetTotalYear();


        $("#str_organisation11").val('');
        $("#Str_designation11").val('');
        $("#str_CTC11").val('');
        $("#str_PayScale11").val('');

        $("#dt_todate11").removeAttr('disabled');

    }

}


//Aadhar and PAN 

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