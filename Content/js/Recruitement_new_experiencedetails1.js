date2 = "31-08-2025";
var d1 = new Date(date2.split("-").reverse().join("-"));
var dd1 = d1.getDate();
var mm1 = d1.getMonth() + 1;
var yy1 = d1.getFullYear();
var newdate1 = yy1 + "-" + 0 + mm1 + "-" + dd1;



if ($("#hidCount").val() > 4) {
    $(".newRow").show();
    $("#addRow").hide();
} else {
    $(".newRow").hide();
    $("#addRow").show();
}

var dtCurrentDate = newdate1;
$('.todate,.fromdate').attr('max', dtCurrentDate);
//debugger;
//if ($('.fromdate').attr('min') != undefined || $('.todate').attr('min') != undefined) {
//    $(".fromdate,.todate").datepicker("option", "minDate", $('.fromdate').attr('min'));
//}


function GetDateDiff(birthDate, ageAtDate) {
    var daysInMonth = 30.436875; // Days in a month on average.
    var dob = birthDate;
    var aad;
    if (ageAtDate == undefined || ageAtDate == null) aad = new Date();
    else aad = ageAtDate;
    var yearAad = aad.getFullYear();
    var yearDob = dob.getFullYear();
    var years = yearAad - yearDob; // Get age in years.
    dob.setFullYear(yearAad); // Set birthday for this year.
    var aadMillis = aad.getTime();
    var dobMillis = dob.getTime();
    if (aadMillis < dobMillis) {
        //--years;
        dob.setFullYear(yearAad - 1); // Set to previous year's birthday
        dobMillis = dob.getTime();
    }

    var days = (aadMillis - dobMillis) / 86400000;
    return days;
}

var ExpDaysRequired;
if ($('#pExperience').text().toLowerCase().indexOf('6 month') >= 0) {
    ExpDaysRequired = 180;
}
else if ($('#pExperience').text().toLowerCase().indexOf('1 year') >= 1) {
    ExpDaysRequired = 365;
}
else if ($('#pExperience').text().toLowerCase().indexOf('2 year') >= 2) {
    ExpDaysRequired = 365 * 2;
}
else if ($('#pExperience').text().toLowerCase().indexOf('3 year') >= 3) {
    ExpDaysRequired = 365 * 3;
}
else if ($('#pExperience').text().toLowerCase().indexOf('4 year') >= 4) {
    ExpDaysRequired = 365 * 4;
}
else if ($('#pExperience').text().toLowerCase().indexOf('5 year') >= 5) {
    ExpDaysRequired = 365 * 5;
}
else if ($('#pExperience').text().toLowerCase().indexOf('6 year') >= 6) {
    ExpDaysRequired = 365 * 6;
}
else if ($('#pExperience').text().toLowerCase().indexOf('7 year') >= 6) {
    ExpDaysRequired = 365 * 7;
}

function ExperienceValidate() {
    var d_Days = 0;
    if ($("#dt_fromdate").val() != '' && $("#dt_todate").val() != '') {
        d_Days += DateDiff($("#dt_fromdate").val().replace(/\//g, '-'), $("#dt_todate").val().replace(/\//g, '-'));
    }
    if ($("#dt_fromdate1").val() != '' && $("#dt_todate1").val() != '') {
        d_Days += DateDiff($("#dt_fromdate1").val().replace(/\//g, '-'), $("#dt_todate1").val().replace(/\//g, '-'));
    }
    if ($("#dt_fromdate2").val() != '' && $("#dt_todate2").val() != '') {
        d_Days += DateDiff($("#dt_fromdate2").val().replace(/\//g, '-'), $("#dt_todate2").val().replace(/\//g, '-'));
    }
    if ($("#dt_fromdate3").val() != '' && $("#dt_todate3").val() != '') {
        d_Days += DateDiff($("#dt_fromdate3").val().replace(/\//g, '-'), $("#dt_todate3").val().replace(/\//g, '-'));
    }
    if ($("#dt_fromdate4").val() != '' && $("#dt_todate4").val() != '') {
        d_Days += DateDiff($("#dt_fromdate4").val().replace(/\//g, '-'), $("#dt_todate4").val().replace(/\//g, '-'));
    }
    if ($("#dt_fromdate5").val() != '' && $("#dt_todate5").val() != '') {
        d_Days += DateDiff($("#dt_fromdate5").val().replace(/\//g, '-'), $("#dt_todate5").val().replace(/\//g, '-'));
    }
    if ($("#dt_fromdate6").val() != '' && $("#dt_todate6").val() != '') {
        d_Days += DateDiff($("#dt_fromdate6").val().replace(/\//g, '-'), $("#dt_todate6").val().replace(/\//g, '-'));
    }
    if ($("#dt_fromdate7").val() != '' && $("#dt_todate7").val() != '') {
        d_Days += DateDiff($("#dt_fromdate7").val().replace(/\//g, '-'), $("#dt_todate7").val().replace(/\//g, '-'));
    }
    if ($("#dt_fromdate8").val() != '' && $("#dt_todate8").val() != '') {
        d_Days += DateDiff($("#dt_fromdate8").val().replace(/\//g, '-'), $("#dt_todate8").val().replace(/\//g, '-'));
    }
    var yearDiff = d_Days / 365;

    if ($('#pExperience').text().toLowerCase().indexOf('6 month') >= 0 && d_Days < 180) {
        return false;
    }
    else if ($('#pExperience').text().toLowerCase().indexOf('1 year') >= 0 && yearDiff < 1) {
        return false;
    }
    else if ($('#pExperience').text().toLowerCase().indexOf('2 year') >= 0 && yearDiff < 2) {
        return false;
    }
    else if ($('#pExperience').text().toLowerCase().indexOf('3 year') >= 0 && yearDiff < 3) {
        return false;
    }
    else if ($('#pExperience').text().toLowerCase().indexOf('4 year') >= 0 && yearDiff < 4) {
        return false;
    }
    else if ($('#pExperience').text().toLowerCase().indexOf('5 year') >= 0 && yearDiff < 5) {
        return false;
    }
    else if ($('#pExperience').text().toLowerCase().indexOf('6 year') >= 0 && yearDiff < 6) {
        return false;
    }
    else if ($('#pExperience').text().toLowerCase().indexOf('7 year') >= 0 && yearDiff < 7) {
        return false;
    }
    else if ($('#pExperience').text().toLowerCase().indexOf('8 year') >= 0 && yearDiff < 8) {
        return false;
    }
    return true;
}


function stringToDate(_date, _format, _delimiter) {
    if (_date != null && _date != 'undefiend') {

        var from = _date.split("-")
        return new Date(from[2], from[1] - 1, from[0])
    }
}

function DateDiff(date1, date2) {

    date1 = date1.replace(/-/g, '/').split('/'); //splits the date string by '/' and stores in a array.
    date2 = date2.replace(/-/g, '/').split('/');

    var d1 = new Date(date1);
    var day = d1.getDate();
    var month = d1.getMonth() + 1;
    var year = d1.getFullYear();
    var newdate1 = year + "-" + month + "-" + day;
    var d2 = new Date(date2);
    var day1 = d2.getDate();
    var month1 = d2.getMonth() + 1;
    var year1 = d2.getFullYear();
    var newdate2 = year1 + "-" + month1 + "-" + day1;
    var dateTemp1 = new Date(year, (parseInt(month) - 1), day);
    var dateTemp2 = new Date(year1, (parseInt(month1) - 1), day1);
    var Days = Math.ceil(((dateTemp2.getTime() - dateTemp1.getTime()) / (1000 * 60 * 60 * 24)));
    return Days + 1;
}


$("#dt_todate,#dt_todate1,#dt_todate2,#dt_todate3,#dt_todate4,#dt_todate5,#dt_todate6,#dt_todate7").change(function () {

    if (stringToDate(this.value, "dd/MM/yyyy", "/") > stringToDate($("#hidMaxExpdate").val(), "dd/MM/yyyy", "/")) {
        alert('Max exp. date is ' + $("#hidMaxExpdate").val())
        this.value = "";
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
        if (new Date(this.value) < new Date($("#dt_todate").val())) {
            //if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate").val(), "dd/MM/yyyy", "/")) {
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
        if (new Date(this.value) < new Date($("#dt_todate1").val())) {

            //  if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate1").val(), "dd/MM/yyyy", "/")) {
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
        if (new Date(this.value) < new Date($("#dt_todate2").val())) {

            //   if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate2").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears3").val('');
            GetTotalYear();
        }
    }

});



$("#dt_fromdate4").change(function () {

    if ($("#dt_todate2").val() == "" && this.value != "") {
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
        if (new Date(this.value) < new Date($("#dt_todate2").val())) {

            //   if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate2").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears4").val('');
            GetTotalYear();
        }
    }

});


$("#dt_fromdate5").change(function () {

    if ($("#dt_todate2").val() == "" && this.value != "") {
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
        if (new Date(this.value) < new Date($("#dt_todate2").val())) {

            //   if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate2").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears5").val('');
            GetTotalYear();
        }
    }

});



$("#dt_fromdate6").change(function () {

    if ($("#dt_todate2").val() == "" && this.value != "") {
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
        if (new Date(this.value) < new Date($("#dt_todate2").val())) {

            //   if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate2").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears6").val('');
            GetTotalYear();
        }
    }

});

$("#dt_fromdate7").change(function () {

    if ($("#dt_todate2").val() == "" && this.value != "") {
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
        if (new Date(this.value) < new Date($("#dt_todate2").val())) {

            //   if (stringToDate(this.value, "dd/MM/yyyy", "/") < stringToDate($("#dt_todate2").val(), "dd/MM/yyyy", "/")) {
            alert('Experience in Chronological Order')
            this.value = "";
            $("#str_noyears7").val('');
            GetTotalYear();
        }
    }

});


function GetTotalYear() {
    //debugger;
    var str_noyears = ($("#str_noyears").val() == "") ? "0" : $("#str_noyears").val();
    var str_noyears1 = ($("#str_noyears1").val() == "") ? "0" : $("#str_noyears1").val()
    var str_noyears2 = ($("#str_noyears2").val() == "") ? "0" : $("#str_noyears2").val()
    var str_noyears3 = ($("#str_noyears3").val() == "") ? "0" : $("#str_noyears3").val()
    var str_noyears4 = ($("#str_noyears4").val() == "") ? "0" : $("#str_noyears4").val()
    var str_noyears5 = ($("#str_noyears5").val() == "") ? "0" : $("#str_noyears5").val()
    var str_noyears6 = ($("#str_noyears6").val() == "") ? "0" : $("#str_noyears6").val()
    var str_noyears7 = ($("#str_noyears7").val() == "") ? "0" : $("#str_noyears7").val()
    var totalDays = parseInt(str_noyears) + parseInt(str_noyears1) + parseInt(str_noyears2) + parseInt(str_noyears3) + parseInt(str_noyears4) + parseInt(str_noyears5) + parseInt(str_noyears6) + parseInt(str_noyears7);
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
                $("#str_noyears7").val('');
                GetTotalYear();
            }
        }
    }
});



$("#str_organisationType").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale").val('');
        $("#str_CTC").removeAttr("readonly", "readonly");
        $("#str_PayScale").attr("readonly", "readonly");
    }
    else {
        $("#str_CTC").val('');
        $("#str_PayScale").removeAttr("readonly", "readonly");
        $("#str_CTC").attr("readonly", "readonly");
    }
});

$("#str_organisationType1").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale1").val('');
        $("#str_CTC1").removeAttr("readonly", "readonly");
        $("#str_PayScale1").attr("readonly", "readonly");
    }
    else {
        $("#str_CTC1").val('');
        $("#str_PayScale1").removeAttr("readonly", "readonly");
        $("#str_CTC1").attr("readonly", "readonly");
    }
});


$("#str_organisationType2").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale2").val('');
        $("#str_CTC2").removeAttr("readonly", "readonly");
        $("#str_PayScale2").attr("readonly", "readonly");
    }
    else {
        $("#str_CTC2").val('');
        $("#str_PayScale2").removeAttr("readonly", "readonly");
        $("#str_CTC2").attr("readonly", "readonly");
    }
});


$("#str_organisationType3").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale3").val('');
        $("#str_CTC3").removeAttr("readonly", "readonly");
        $("#str_PayScale3").attr("readonly", "readonly");
    }
    else {
        $("#str_CTC3").val('');
        $("#str_PayScale3").removeAttr("readonly", "readonly");
        $("#str_CTC3").attr("readonly", "readonly");
    }
});


$("#str_organisationType4").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale4").val('');
        $("#str_CTC4").removeAttr("readonly", "readonly");
        $("#str_PayScale4").attr("readonly", "readonly");
    }
    else {
        $("#str_CTC4").val('');
        $("#str_PayScale4").removeAttr("readonly", "readonly");
        $("#str_CTC4").attr("readonly", "readonly");
    }
});


$("#str_organisationType5").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale5").val('');
        $("#str_CTC5").removeAttr("readonly", "readonly");
        $("#str_PayScale5").attr("readonly", "readonly");
    }
    else {
        $("#str_CTC5").val('');
        $("#str_PayScale5").removeAttr("readonly", "readonly");
        $("#str_CTC5").attr("readonly", "readonly");
    }
});


$("#str_organisationType6").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale6").val('');
        $("#str_CTC6").removeAttr("readonly", "readonly");
        $("#str_PayScale6").attr("readonly", "readonly");
    }
    else {
        $("#str_CTC6").val('');
        $("#str_PayScale6").removeAttr("readonly", "readonly");
        $("#str_CTC6").attr("readonly", "readonly");
    }
});


$("#str_organisationType7").change(function () {
    if (this.value == "Other" || this.value == "Private") {
        $("#str_PayScale7").val('');
        $("#str_CTC7").removeAttr("readonly", "readonly");
        $("#str_PayScale7").attr("readonly", "readonly");
    }
    else {
        $("#str_CTC7").val('');
        $("#str_PayScale7").removeAttr("readonly", "readonly");
        $("#str_CTC7").attr("readonly", "readonly");
    }
});



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
    // debugger;
    var end = $("#StrEmploymentPresentStatus").val();
    if (end == 'Currently Working') {
        //alert(dtCurrentDate);
        $("#dt_todate").val(dtCurrentDate);
        $("#dt_todate").attr('disabled', 'disabled');
        $("#dt_todate").next("span").remove();
        //  $("#dt_fromdate").val('');
        $("#str_noyears").val('');
        $("#str_organisation").val('');
        $("#Str_designation").val('');
        $("#str_CTC").val('');
        $("#str_PayScale").val('');

        GetTotalYear();
        //if (fromDate != "" && toDate != "") {
        //var fromDate = $("#dt_fromdate").val();
        //var toDate = $("#dt_todate").val();

        //    var n = DateDiff(fromDate.toString().replace('-', '/').replace('-', '/'), toDate.toString().replace('-', '/').replace('-', '/')); //DateDiffNew is called here


        //    if (parseInt(n) > 0) {

        //        $("#str_noyears").val(n);
        //        GetTotalYear();

        //    }
        //}
    }
    else {

        // $("#dt_fromdate").val('');
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
        $("#dt_todate1").val(dtCurrentDate);
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
        $("#dt_todate2").val(dtCurrentDate);
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
        $("#dt_todate3").val(dtCurrentDate);
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


if ($("#StrEmploymentPresentStatus").val() == "Private" || $("#StrEmploymentPresentStatus").val() == "Other") {
    $("#str_PayScale").attr('readonly', 'readonly');
    $("#str_CTC").removeAttr('readonly');
}
else {
    $("#str_CTC").attr('readonly', 'readonly');
    $("#str_PayScale").removeAttr('readonly');
}


if ($("#StrEmploymentPresentStatus1").val() == "Private" || $("#StrEmploymentPresentStatus1").val() == "Other") {
    $("#str_PayScale1").attr('readonly', 'readonly');
    $("#str_CTC1").removeAttr('readonly');
}
else {
    $("#str_CTC1").attr('readonly', 'readonly');
    $("#str_PayScale1").removeAttr('readonly');
}


if ($("#StrEmploymentPresentStatus2").val() == "Private" || $("#StrEmploymentPresentStatus2").val() == "Other") {
    $("#str_PayScale2").attr('readonly', 'readonly');
    $("#str_CTC2").removeAttr('readonly');
}
else {
    $("#str_CTC2").attr('readonly', 'readonly');
    $("#str_PayScale2").removeAttr('readonly');
}

if ($("#StrEmploymentPresentStatus3").val() == "Private" || $("#StrEmploymentPresentStatus3").val() == "Other") {
    $("#str_PayScale3").attr('readonly', 'readonly');
    $("#str_CTC3").removeAttr('readonly');
}
else {
    $("#str_CTC3").attr('readonly', 'readonly');
    $("#str_PayScale3").removeAttr('readonly');
}

if ($("#StrEmploymentPresentStatus4").val() == "Private" || $("#StrEmploymentPresentStatus4").val() == "Other") {
    $("#str_PayScale4").attr('readonly', 'readonly');
    $("#str_CTC4").removeAttr('readonly');
}
else {
    $("#str_CTC4").attr('readonly', 'readonly');
    $("#str_PayScale4").removeAttr('readonly');
}

if ($("#StrEmploymentPresentStatus5").val() == "Private" || $("#StrEmploymentPresentStatus5").val() == "Other") {
    $("#str_PayScale5").attr('readonly', 'readonly');
    $("#str_CTC5").removeAttr('readonly');
}
else {
    $("#str_CTC5").attr('readonly', 'readonly');
    $("#str_PayScale5").removeAttr('readonly');
}



if ($("#StrEmploymentPresentStatus6").val() == "Private" || $("#StrEmploymentPresentStatus6").val() == "Other") {
    $("#str_PayScale6").attr('readonly', 'readonly');
    $("#str_CTC6").removeAttr('readonly');
}
else {
    $("#str_CTC6").attr('readonly', 'readonly');
    $("#str_PayScale6").removeAttr('readonly');
}


if ($("#StrEmploymentPresentStatus7").val() == "Private" || $("#StrEmploymentPresentStatus7").val() == "Other") {
    $("#str_PayScale7").attr('readonly', 'readonly');
    $("#str_CTC7").removeAttr('readonly');
}
else {
    $("#str_CTC7").attr('readonly', 'readonly');
    $("#str_PayScale7").removeAttr('readonly');
}


if ($("#StrEmploymentPresentStatus").val() == "Currently Working") {
    $("#dt_todate").attr('disabled', 'disabled');
    $("#dt_todate").val(dtCurrentDate);
}
else {
    $("#dt_todate").removeAttr('disabled');
}

if ($("#StrEmploymentPresentStatus1").val() == "Currently Working") {
    $("#dt_todate1").attr('disabled', 'disabled');
    $("#dt_todate1").val(dtCurrentDate);
}
else {
    $("#dt_todate1").removeAttr('disabled');
}

if ($("#StrEmploymentPresentStatus2").val() == "Currently Working") {
    $("#dt_todate2").attr('disabled', 'disabled');
    $("#dt_todate2").val(dtCurrentDate);
}
else {
    $("#dt_todate2").removeAttr('disabled');
}

if ($("#StrEmploymentPresentStatus3").val() == "Currently Working") {
    $("#dt_todate3").attr('disabled', 'disabled');
    $("#dt_todate3").val(dtCurrentDate);
}
else {
    $("#dt_todate3").removeAttr('disabled');
}

if ($("#StrEmploymentPresentStatus4").val() == "Currently Working") {
    $("#dt_todate4").attr('disabled', 'disabled');
    $("#dt_todate4").val(dtCurrentDate);
}
else {
    $("#dt_todate4").removeAttr('disabled');
}

if ($("#StrEmploymentPresentStatus5").val() == "Currently Working") {
    $("#dt_todate5").attr('disabled', 'disabled');
    $("#dt_todate5").val(dtCurrentDate);
}
else {
    $("#dt_todate5").removeAttr('disabled');
}

if ($("#StrEmploymentPresentStatus6").val() == "Currently Working") {
    $("#dt_todate6").attr('disabled', 'disabled');
    $("#dt_todate6").val(dtCurrentDate);
}
else {
    $("#dt_todate6").removeAttr('disabled');
}

if ($("#StrEmploymentPresentStatus7").val() == "Currently Working") {
    $("#dt_todate7").attr('disabled', 'disabled');
    $("#dt_todate7").val(dtCurrentDate);
}
else {
    $("#dt_todate7").removeAttr('disabled');
}
function ErrorValidate() {
    if (($('#str_organisation').val() != undefined && $('#str_organisation').val() != '') && (($('input[type=file][name="str_UploadExpCertificate"]').val() == '') && ($('.clsExpDoc').text() == '' || $('.clsExpDoc').text() == '-'))) {
        $($('input[type=file][name="str_UploadExpCertificate"]')).next("span").remove();
        $($('input[type=file][name="str_UploadExpCertificate"]')).after("<span style='color:Red'> This field is required</span>");
        return false;
    }
    if (($('#str_organisation1').val() != undefined && $('#str_organisation1').val() != '') && (($('input[type=file][name="str_UploadExpCertificate1"]').val() == '') && ($('.clsExpDoc1').text() == '' || $('.clsExpDoc1').text() == '-'))) {
        $($('input[type=file][name="str_UploadExpCertificate1"]')).next("span").remove();
        $($('input[type=file][name="str_UploadExpCertificate1"]')).after("<span style='color:Red'> This field is required</span>");
        return false;
    }
    if (($('#str_organisation2').val() != undefined && $('#str_organisation2').val() != '') && (($('input[type=file][name="str_UploadExpCertificate2"]').val() == '') && ($('.clsExpDoc2').text() == '' || $('.clsExpDoc2').text() == '-'))) {
        $($('input[type=file][name="str_UploadExpCertificate2"]')).next("span").remove();
        $($('input[type=file][name="str_UploadExpCertificate2"]')).after("<span style='color:Red'> This field is required</span>");
        return false;
    }
    if (($('#str_organisation3').val() != undefined && $('#str_organisation3').val() != '') && (($('input[type=file][name="str_UploadExpCertificate3"]').val() == '') && ($('.clsExpDoc3').text() == '' || $('.clsExpDoc3').text() == '-'))) {
        $($('input[type=file][name="str_UploadExpCertificate3"]')).next("span").remove();
        $($('input[type=file][name="str_UploadExpCertificate3"]')).after("<span style='color:Red'> This field is required</span>");
        return false;
    }
    if (($('#str_organisation4').val() != undefined && $('#str_organisation4').val() != '') && (($('input[type=file][name="str_UploadExpCertificate4"]').val() == '') && ($('.clsExpDoc4').text() == '' || $('.clsExpDoc4').text() == '-'))) {
        $($('input[type=file][name="str_UploadExpCertificate4"]')).next("span").remove();
        $($('input[type=file][name="str_UploadExpCertificate4"]')).after("<span style='color:Red'> This field is required</span>");
        return false;
    }
    if (($('#str_organisation5').val() != undefined && $('#str_organisation5').val() != '') && (($('input[type=file][name="str_UploadExpCertificate5"]').val() == '') && ($('.clsExpDoc5').text() == '' || $('.clsExpDoc5').text() == '-'))) {
        $($('input[type=file][name="str_UploadExpCertificate5"]')).next("span").remove();
        $($('input[type=file][name="str_UploadExpCertificate5"]')).after("<span style='color:Red'> This field is required</span>");
        return false;
    }
    if (($('#str_organisation6').val() != undefined && $('#str_organisation6').val() != '') && (($('input[type=file][name="str_UploadExpCertificate6"]').val() == '') && ($('.clsExpDoc6').text() == '' || $('.clsExpDoc6').text() == '-'))) {
        $($('input[type=file][name="str_UploadExpCertificate6"]')).next("span").remove();
        $($('input[type=file][name="str_UploadExpCertificate6"]')).after("<span style='color:Red'> This field is required</span>");
        return false;
    }
    if (($('#str_organisation7').val() != undefined && $('#str_organisation7').val() != '') && (($('input[type=file][name="str_UploadExpCertificate7"]').val() == '') && ($('.clsExpDoc7').text() == '' || $('.clsExpDoc7').text() == '-'))) {
        $($('input[type=file][name="str_UploadExpCertificate7"]')).next("span").remove();
        $($('input[type=file][name="str_UploadExpCertificate7"]')).after("<span style='color:Red'> This field is required</span>");
        return false;
    }


    if (ExperienceValidate() != true) {
        alert('Experience criteria is not matching');
        return false;
    }


}

$("#addRow").click(function () {
    // alert("ssdfs");
    $(".newRow").show();
    $("#addRow").hide();

});



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
        $("#dt_todate4").val(dtCurrentDate);
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
        $("#dt_todate5").val(dtCurrentDate);
        $("#dt_todate5").attr('disabled', 'disabled');
        $("#dt_todate5").next("span").remove();

        $("#dt_fromdate5").val('');
        $("#str_noyears5").val('');


        $("#str_organisation5").val('');
        $("#Str_designation5").val('');
        $("#str_CTC5").val('');
        $("#str_PayScale5").val('');

        GetTotalYear();
    }
    else {
        $("#dt_fromdate5").val('');
        $("#dt_todate5").val('');
        $("#str_noyears5").val('');


        $("#str_organisation5").val('');
        $("#Str_designation5").val('');
        $("#str_CTC5").val('');
        $("#str_PayScale5").val('');

        GetTotalYear();

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
        $("#dt_todate6").val(dtCurrentDate);
        $("#dt_todate6").attr('disabled', 'disabled');
        $("#dt_todate6").next("span").remove();

        $("#dt_fromdate6").val('');
        $("#str_noyears6").val('');


        $("#str_organisation6").val('');
        $("#Str_designation6").val('');
        $("#str_CTC6").val('');
        $("#str_PayScale6").val('');

        GetTotalYear();
    }
    else {
        $("#dt_fromdate6").val('');
        $("#dt_todate6").val('');
        $("#str_noyears6").val('');


        $("#str_organisation6").val('');
        $("#Str_designation6").val('');
        $("#str_CTC6").val('');
        $("#str_PayScale6").val('');

        GetTotalYear();

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
        $("#dt_todate7").val(dtCurrentDate);
        $("#dt_todate7").attr('disabled', 'disabled');
        $("#dt_todate7").next("span").remove();

        $("#dt_fromdate7").val('');
        $("#str_noyears7").val('');


        $("#str_organisation7").val('');
        $("#Str_designation7").val('');
        $("#str_CTC7").val('');
        $("#str_PayScale7").val('');

        GetTotalYear();
    }
    else {
        $("#dt_fromdate7").val('');
        $("#dt_todate7").val('');
        $("#str_noyears7").val('');


        $("#str_organisation7").val('');
        $("#Str_designation7").val('');
        $("#str_CTC7").val('');
        $("#str_PayScale7").val('');

        GetTotalYear();

        $("#dt_todate7").removeAttr('disabled');

    }

}
$("input[type=file]").on("change", function () {
    //debugger;
    /* current this object refer to input element */
    var $input = $(this);

    /* collect list of files choosen */
    var files = $input[0].files;

    var filename = files[0].name;

    /* getting file extenstion eg- .jpg,.png, etc */
    var extension = filename.substr(filename.lastIndexOf("."));

    /* define allowed file types */
    var allowedExtensionsRegx = /(\.pdf|\.PDF)$/i;

    /* testing extension with regular expression */
    var isAllowed = allowedExtensionsRegx.test(extension);
    //var file_size = $('#file-upload')[0].files[0].size;
    var file_size = $(this)[0].files[0].size;
    // if (file_size > 2097152) {
    if (file_size > 1048576 || file_size < 20480) {
        //$("#file_error").html("File size is greater than 2MB");
        //$(".demoInputBox").css("border-color", "#FF0000");
        // alert("File size is greater than 1MB & ");
        alert("File size must be between 20 Kb to 1 Mb");
        $(this).val("");
        isValid = false;
        $(this).next("span").remove();
        $(this).after("<span style='color:Red'> This field is required</span>");
        return false;
    } else {
        $(this).next("span").remove();
    }
    if (isAllowed) {
        // alert("File type is valid for the upload");      
        /* file upload logic goes here... */
    } else {
        alert("Invalid File Type.");
        $(this).val("");
        return false;
    }
});