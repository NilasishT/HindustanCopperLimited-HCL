
    Category();
    pwd();

    function LimtCharacters(txtMsg, CharLength) {
        $(txtMsg).next("span").remove();
        chars = txtMsg.value.length;
        if (chars > CharLength && chars > 0) {
            txtMsg.value = txtMsg.value.substring(0, CharLength);
            $(txtMsg).after("<span style='color:Red'> Max Length reached..</span>");
        }
    }


    $("input:not([readonly],[type=hidden])").keyup(function () {
        var element = $(this);
        if (element.val() != "") {
            $(this).next("span").remove();
        }
    });

    $("select").change(function () {
        var element = $(this);
        if (element.val() != "") {
            $(this).next("span").remove();
        }
    });

    $("textarea").keyup(function () {
        var element = $(this);
        if (element.val() != "") {
            $(this).next("span").remove();
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


    $("#strApprenticeshipRegNo").keyup(function () {
        this.value = this.value.split(/[^a-zA-Z0-9 ]/).join('');
        var strApprenticeshipRegNo = $("#strApprenticeshipRegNo").val();
        $("#strApprenticeshipRegNo").next("span").remove();
        if (strApprenticeshipRegNo.toString().charAt(0).toUpperCase() != "A") {
            $("#strApprenticeshipRegNo").next("span").remove();
            $("#strApprenticeshipRegNo").after("<span style='color:Red'>Apprenticeship Registration No must be starting with A </span>");
        }
        else {
            $("#strApprenticeshipRegNo").next("span").remove();
        }
    });


    $("#strPin").keyup(function () {
        this.value = this.value.split(/[^a-zA-Z0-9 ]/).join('');
        var strPin = $("#strPin").val();
        $("#strPin").next("span").remove();
        if (strPin.toString().length < 6 && strPin != "") {
            $("#strPin").after("<span style='color:Red'>Pin must be 6 digit</span>");
        }
        else {
            $("#strPin").next("span").remove();
        }
    });

    $("#strTelephone").keyup(function () {
        this.value = this.value.split(/[^a-zA-Z0-9 ]/).join('');
        var strTelephone = $("#strTelephone").val();
        $("#strTelephone").next("span").remove();
        if (strTelephone.toString().length < 11 && strTelephone != "") {
            $("#strTelephone").after("<span style='color:Red'>Telephone must be 11 digit</span>");
        }
        else {
            $("#strTelephone").next("span").remove();
        }
    });

    $("#strMobileNo").keyup(function () {
        this.value = this.value.split(/[^a-zA-Z0-9 ]/).join('');
        var strMobileNo = $("#strMobileNo").val();
        $("#strMobileNo").next("span").remove();
        if (strMobileNo.toString().length < 10 && strMobileNo != "") {
            $("#strMobileNo").after("<span style='color:Red'>Mobile must be 10 digit</span>");
        }
        else {
            $("#strMobileNo").next("span").remove();
        }
    });



    $("#strPermanentPinCode").keyup(function () {
        this.value = this.value.split(/[^a-zA-Z0-9 ]/).join('');
        var strPermanentPinCode = $("#strPermanentPinCode").val();
        $("#strPermanentPinCode").next("span").remove();
        if (strPermanentPinCode.toString().length < 6 && strPin != "") {
            $("#strPermanentPinCode").after("<span style='color:Red'>Pin must be 6 digit</span>");
        }
        else {
            $("#strPermanentPinCode").next("span").remove();
        }
    });

    $("#strPermanentTelephoneNo").keyup(function () {
        this.value = this.value.split(/[^a-zA-Z0-9 ]/).join('');
        var strPermanentTelephoneNo = $("#strPermanentTelephoneNo").val();
        $("#strPermanentTelephoneNo").next("span").remove();
        if (strPermanentTelephoneNo.toString().length < 11 && strPermanentTelephoneNo != "") {
            $("#strPermanentTelephoneNo").after("<span style='color:Red'>Telephone must be 11 digit</span>");
        }
        else {
            $("#strPermanentTelephoneNo").next("span").remove();
        }
    });

    $("#strPermanentMobile1").keyup(function () {
        this.value = this.value.split(/[^a-zA-Z0-9 ]/).join('');
        var strPermanentMobile1 = $("#strPermanentMobile1").val();
        $("#strPermanentMobile1").next("span").remove();
        if (strPermanentMobile1.toString().length < 10 && strPermanentMobile1 != "") {
            $("#strPermanentMobile1").after("<span style='color:Red'>Mobile must be 10 digit</span>");
        }
        else {
            $("#strPermanentMobile1").next("span").remove();
        }
    });

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


    $("#strApprenticeshipRegNo").on("input", function () {
        LimtCharacters(this, 13);
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
    $("#strPermanentPinCode").on("input", function () {
        LimtCharacters(this, 6);
    });
    $("#strPermanentTelephoneNo").on("input", function () {
        LimtCharacters(this, 11);
    });
    $("#strPermanentMobile1").on("input", function () {
        LimtCharacters(this, 10);
    });


    $("#strPermanentMobile1").on("input", function () {
        LimtCharacters(this, 10);
    });
    $("#strPermanentMobile1").on("input", function () {
        LimtCharacters(this, 10);
    });

    $("#strAadharNo").on("input", function () {
        LimtCharacters(this, 12);
    });
    $("#strPANNo").on("input", function () {
        LimtCharacters(this, 10);
    });


    //Category
    $("#strCategory").change(function () {
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
        if (end !== 'General' && end != 'EWS') {
            $("#lblsubcaste").show();
            $("#lblcertificateno").show();
            $("#lblissuedate").show();
            $("#lblcertificateissue").show();
            $("#strsubcaste").removeAttr('disabled');
            $("#strcertificateno").removeAttr('disabled');
            $("#dt_certificateissuedate").removeAttr('disabled');
            $("#strcertificateissue").removeAttr('disabled');
        }

       else if (end == 'EWS') {
       
            $("#lblsubcaste").hide();
            $("#lblcertificateno").show();
            $("#lblissuedate").show();
            $("#lblcertificateissue").show();
            $("#strsubcaste").attr('disabled', 'disabled');
            $("#strcertificateno").removeAttr('disabled');
            $("#dt_certificateissuedate").removeAttr('disabled');
            $("#strcertificateissue").removeAttr('disabled');
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


    //ERROR
    function error() {
        var noerror = 1;
        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        var strTelephone = $("#strTelephone").val();
        var email = $("#strEmail").val();
        var strMobileNo = $("#strMobileNo").val();
        var strPermanentTelephoneNo = $("#strPermanentTelephoneNo").val();
        var strPermanentMobile1 = $("#strPermanentMobile1").val();
        var strPin = $("#strPin").val();
        var strPermanentPinCode = $("#strPermanentPinCode").val();
        var strApprenticeshipRegNo = $("#strApprenticeshipRegNo").val();

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
        if ($("#strGender").val() == "") {
            $("#strGender").next("span").remove();
            $("#strGender").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#strCategory").val() == "") {
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

        if ($("#strCategory").val() == "EWS" && $("#strcertificateno").val() == "") {
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
        if ($("#strCategory").val() == "EWS" && $("#dt_certificateissuedate").val() == "") {
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
        if ($("#strCategory").val() == "EWS" && $("#strcertificateissue").val() == "") {
            $("#strcertificateissue").next("span").remove();
            $("#strcertificateissue").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if ($("#strMaritalStatus").val() == "") {
            $("#strMaritalStatus").next("span").remove();
            $("#strMaritalStatus").after("<span style='color:Red'> This field is required</span>");
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
        if (strTelephone.toString().length != 11 && strTelephone != "") {
            $("#strTelephone").next("span").remove();
            $("#strTelephone").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
            noerror = 0;
        }
        if (strMobileNo.toString().length != 10 && strMobileNo != "") {
            $("#strMobileNo").next("span").remove();
            $("#strMobileNo").after("<span style='color:Red'>Mobile must be 10 digit</span>");
            noerror = 0;
        }
        if (strPermanentTelephoneNo.toString().length != 11 && strPermanentTelephoneNo != "") {
            $("#strPermanentTelephoneNo").next("span").remove();
            $("#strPermanentTelephoneNo").after("<span style='color:Red'>Ph no. must be 11 digit</span>");
            noerror = 0;
        }
        if (strPermanentMobile1.toString().length != 10 && strPermanentMobile1 != "") {
            $("#strPermanentMobile1 ").next("span").remove();
            $("#strPermanentMobile1 ").after("<span style='color:Red'>Mobile must be 10 digit</span>");
            noerror = 0;
        }

        if (!emailReg.test(email)) {
            $("#strEmail").next("span").remove();
            $("#strEmail").after("<span style='color:Red'>Please enter valid Email </span>");
            noerror = 0;
        }
        if (strPin.toString().length != 6 && strPin != "") {
            $("#strPin ").next("span").remove();
            $("#strPin ").after("<span style='color:Red'>Pin must be 6 digit</span>");
            noerror = 0;
        }
        if (strPermanentPinCode.toString().length != 6 && strPermanentPinCode != "") {
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
        if ($("#strApprenticeshipRegNo").val() == "") {
            $("#strApprenticeshipRegNo").next("span").remove();
            $("#strApprenticeshipRegNo").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if (strApprenticeshipRegNo.toString().length == 10 && strApprenticeshipRegNo.toString().charAt(0).toUpperCase() != "A") {
            $("#strApprenticeshipRegNo").next("span").remove();
            $("#strApprenticeshipRegNo").after("<span style='color:Red'>Apprenticeship Registration No must be starting with A </span>");
            noerror = 0;

        }
        if (strApprenticeshipRegNo.toString().charAt(0).toUpperCase() != "A") {
            $("#strApprenticeshipRegNo").next("span").remove();
            $("#strApprenticeshipRegNo").after("<span style='color:Red'>Apprenticeship Registration No must be starting with A </span>");
            noerror = 0;
        }

        //if (strApprenticeshipRegNo.toString().length == 10 && $.isNumeric(strApprenticeshipRegNo.toString().substr(strApprenticeshipRegNo.length - 9)) == false) {
        //    $("#strApprenticeshipRegNo").next("span").remove();
        //    $("#strApprenticeshipRegNo").after("<span style='color:Red'>Apprenticeship Registration No must be starting with A and rest digits</span>");
        //    noerror = 0;
        //}  
        
        var str = strApprenticeshipRegNo.toString();
        var arr = [];
        for (var i = 0; i < str.length; i++) {
            arr.push({ Index: i, Value: str[i], IsNum: !isNaN(str[i]) });
        }
        //if (arr[0].Value.toUpperCase() != 'A' || arr.length < 11 || arr.filter(a => a.IsNum == false).length != 1 || arr.filter(a => a.IsNum == true).length < 10) {
        if (arr[0].Value.toUpperCase() != 'A' || arr.length < 10 || arr.filter(a => a.IsNum == false).length != 1 || arr.filter(a => a.IsNum == true).length < 9) {
             $("#strApprenticeshipRegNo").next("span").remove();
            $("#strApprenticeshipRegNo").after("<span style='color:Red'>Apprenticeship Registration No must be starting with A  and rest digits </span>");
            noerror = 0;
        }
        

        if (noerror == 1) {
            if (confirm("Are you sure ?")) {

                if ($('#tbl_mst_Order')[0].checkValidity()) {
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


