var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
var Complainer = $('#vchComplainer').val();
var ComplainType = $('#vchComplainType').val();
var City = $('#vchCity').val();
var Location = $('#vchLocation').val();
var ComplainerAddress = $('#vchComplainerAddress').val();
var Designation = $('#vchCompAgainstOff').val();
var Pin = $('#vchPin').val();
var StdCode = $('#vchStdCode').val();
var ComplainDetails = $('#vchComplainDetails').val();
var ContactNo = $('#vchContactNo').val();
var Email = $('#vchEmail').val();
var Dob = $('#dtmDob').val();

// File upload validation
var FileName = $('#vchFileName').val();

// Onkeyup validations for various fields
$("#vchComplainer").keyup(function () {
    var Complainer = $('#vchComplainer').val();
    $("#vchComplainer").next("span").remove();
    if (Complainer == "") {
        $("#vchComplainer").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchComplainer").next("span").remove();
    }
});

$("#vchCity").keyup(function () {
    var City = $('#vchCity').val();
    $("#vchCity").next("span").remove();
    if (City == "") {
        $("#vchCity").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchCity").next("span").remove();
    }
});

$("#vchComplainerAddress").keyup(function () {
    var ComplainerAddress = $('#vchComplainerAddress').val();
    $("#vchComplainerAddress").next("span").remove();
    if (ComplainerAddress == "") {
        $("#vchComplainerAddress").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchComplainerAddress").next("span").remove();
    }
});

$("#vchPin").keyup(function () {
    var Pin = $('#vchPin').val();
    $("#vchPin").next("span").remove();
    if (Pin == "") {
        $("#vchPin").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchPin").next("span").remove();
    }
});

$("#vchContactNo").keyup(function () {
    var ContactNo = $('#vchContactNo').val();
    $("#vchContactNo").next("span").remove();
    if (ContactNo == "") {
        $("#vchContactNo").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchContactNo").next("span").remove();
    }
});

$("#vchComplainType").change(function () {
    var ComplainType = $('#vchComplainType').val();
    $("#vchComplainType").next("span").remove();
    if (ComplainType == "0") {
        $("#vchComplainType").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchComplainType").next("span").remove();
    }
});

$("#vchLocation").change(function () {
    var Location = $('#vchLocation').val();
    $("#vchLocation").next("span").remove();
    if (Location == "0") {
        $("#vchLocation").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchLocation").next("span").remove();
    }
});

$("#vchCompAgainstOff").change(function () {
    var Designation = $('#vchCompAgainstOff').val();
    $("#vchCompAgainstOff").next("span").remove();
    if (Designation == "0") {
        $("#vchCompAgainstOff").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchCompAgainstOff").next("span").remove();
    }
});

$("#vchComplainDetails").keyup(function () {
    var ComplainDetails = $('#vchComplainDetails').val();
    $("#vchComplainDetails").next("span").remove();
    if (ComplainDetails == "") {
        $("#vchComplainDetails").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#vchComplainDetails").next("span").remove();
    }
});

$("#dtmDob").keyup(function () {
    var Dob = $('#dtmDob').val();
    $("#dtmDob").next("span").remove();
    if (Dob == "") {
        $("#dtmDob").after("<span style='color:Red'> This field is required</span>");
    } else {
        $("#dtmDob").next("span").remove();
    }
});

// Email validation with regex
$("#vchEmail").keyup(function () {
    $("#vchEmail").next("span").remove();
    var email = $('#vchEmail').val();
    if (email == "") {
        $("#vchEmail").after("<span style='color:Red'> This field is required</span>");
    } else if (!emailReg.test(email)) {
        $("#vchEmail").after("<span style='color:Red'> Enter Valid Email</span>");
    } else {
        $("#vchEmail").next("span").remove();
    }
});

// File validation for allowed file types and size
$("#vchFileName").change(function () {
    var extension = $(this).val().replace(/^.*\./, '');
    if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'doc' || extension.toLowerCase() == 'docx' || extension.toLowerCase() == 'xls' || extension.toLowerCase() == 'xlsx') {
        var size = this.files[0].size / 1048576;
        if (parseFloat(size) <= 1) {
            $("#vchFileName").val(this.value);
            $("#vchFileName").next("span").remove();
        } else {
            alert('File Size Exceeding.');
            $(this).val('');
        }
    } else {
        alert('Only pdf, doc, docx files are allowed.');
        $(this).val('');
    }
});

// Force numeric only for specific fields
$("#vchPin").ForceNumericOnly();
$("#vchStdCode").ForceNumericOnly();
$("#vchContactNo").ForceNumericOnly();
$("#vchLPhoneNo").ForceNumericOnly();

// Limit characters for specific fields
$("#vchComplainer").on("input", function () {
    LimitCharacters(this, 50);
});

$("#vchCity").on("input", function () {
    LimitCharacters(this, 100);
});

$("#vchStdCode").on("input", function () {
    LimitCharacters(this, 10);
});

$("#vchComplainDetails").on("input", function () {
    LimitCharacters(this, 500);
});

$("#vchContactNo").on("input", function () {
    MinMaxLimitCharacters(this, 10);
});

$("#vchPin").on("input", function () {
    MinMaxLimitCharacters(this, 6);
});

// Limit the number of characters allowed
function LimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    var chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:Red'> Max Length reached..</span>");
    }
}

// Min-max length validation for numeric fields
function MinMaxLimitCharacters(ControlId, CharLength) {
    $(ControlId).next("span").remove();
    var chars = ControlId.value.length;
    if (chars > CharLength && chars > 0) {
        ControlId.value = ControlId.value.substring(0, CharLength);
        $(ControlId).after("<span style='color:Red'> Max Length reached..</span>");
    }
    if (chars < CharLength && chars > 0) {
        $(ControlId).after("<span style='color:Red'> Enter Valid Input ..</span>");
    }
}

// Error function to validate all fields before submitting
function error() {
    var noerror = 1;
    var vchContactNo = $("#vchContactNo").val();
    var vchPinNo = $("#vchPin").val();

    // Validation for all fields
    if ($("#vchComplainer").val() == "") {
        $("#vchComplainer").next("span").remove();
        $("#vchComplainer").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchCity").val() == "") {
        $("#vchCity").next("span").remove();
        $("#vchCity").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchComplainerAddress").val() == "") {
        $("#vchComplainerAddress").next("span").remove();
        $("#vchComplainerAddress").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchPin").val() == "") {
        $("#vchPin").next("span").remove();
        $("#vchPin").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (vchPinNo.toString().length < 6 && vchPinNo != "") {
        $("#vchPin").next("span").remove();
        $("#vchPin").after("<span style='color:Red'>Pin No.  must be 6 digits</span>");
        noerror = 0;
    }

    if ($("#vchContactNo").val() == "") {
        $("#vchContactNo").next("span").remove();
        $("#vchContactNo").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (vchContactNo.toString().length < 10 && vchContactNo != "") {
        $("#vchContactNo").next("span").remove();
        $("#vchContactNo").after("<span style='color:Red'>Mobile No. must be 10 digits</span>");
        noerror = 0;
    }

    if ($("#vchComplainType").val() == "0") {
        $("#vchComplainType").next("span").remove();
        $("#vchComplainType").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchLocation").val() == "0") {
        $("#vchLocation").next("span").remove();
        $("#vchLocation").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchCompAgainstOff").val() == "0") {
        $("#vchCompAgainstOff").next("span").remove();
        $("#vchCompAgainstOff").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchComplainDetails").val() == "") {
        $("#vchComplainDetails").next("span").remove();
        $("#vchComplainDetails").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#dtmDob").val() == "") {
        $("#dtmDob").next("span").remove();
        $("#dtmDob").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if ($("#vchEmail").val() == "") {
        $("#vchEmail").next("span").remove();
        $("#vchEmail").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

    if (!emailReg.test(Email)) {
        $("#vchEmail").next("span").remove();
        $("#vchEmail").after("<span style='color:Red'> Enter Valid Email</span>");
        noerror = 0;
    }

    if (noerror == 1) {
        if (confirm("Are you sure ?")) {
            if ($('#T_GrievanceMaster')[0].checkValidity()) {
                return true;
            }
        } else {
            return false;
        }
    }

    if (noerror == 0) {
        return false;
    }
}
