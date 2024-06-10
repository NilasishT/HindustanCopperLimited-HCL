date2 = "01-01-2024";
var d1 = new Date(date2.split("-").reverse().join("-"));
var dd1 = d1.getDate();
var mm1 = d1.getMonth() + 1;
var yy1 = d1.getFullYear();
var newdate1 = yy1 + "-0" + mm1 + "-0" + dd1;

var dtCurrentDate = newdate1;
$('.todate,.fromdate').attr('max', dtCurrentDate);


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


$("#dt_todate,#dt_todate1,#dt_todate2,#dt_todate3").change(function () {

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


function GetTotalYear() {
    debugger;
    var str_noyears = ($("#str_noyears").val() == "") ? "0" : $("#str_noyears").val();
    var str_noyears1 = ($("#str_noyears1").val() == "") ? "0" : $("#str_noyears1").val()
    var str_noyears2 = ($("#str_noyears2").val() == "") ? "0" : $("#str_noyears2").val()
    var str_noyears3 = ($("#str_noyears3").val() == "") ? "0" : $("#str_noyears3").val()
    var totalDays = parseInt(str_noyears) + parseInt(str_noyears1) + parseInt(str_noyears2) + parseInt(str_noyears3);
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
    debugger;
    var end = $("#StrEmploymentPresentStatus").val();
    if (end == 'Currently Working') {
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
function ErrorValidate() {
    if (ExperienceValidate() != true) {
        alert('Experience criteria is not matching');
        return false;
    }
}