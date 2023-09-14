$('#Fk_Qualification6').multipleSelect({
        isOpen: true,
        keepOpen: true,
        selectAll: true,
        minimumCountSelected: 1,
        single: false,
        maxHeight: 150

    });

function error() {

   

    $('#hidQualification6').val($('#Fk_Qualification6').multipleSelect('getSelects'))

       
        var noerror = 1;



        if ($("#Fk_Disciplineid").val() == "") {
            $("#Fk_Disciplineid").next("span").remove();
            $("#Fk_Disciplineid").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Postname").val() == "") {
            $("#Postname").next("span").remove();
            $("#Postname").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if ($("#Fk_intGrade").val() == "") {
            $("#Fk_intGrade").next("span").remove();
            $("#Fk_intGrade").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Payscale").val() == "") {
            $("#Payscale").next("span").remove();
            $("#Payscale").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if ($("#dtcompareDate").val() == "") {
            $("#dtcompareDate").next("span").remove();
            $("#dtcompareDate").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        
        if ($("#dtExpiryDate").val() == "") {
            $("#dtExpiryDate").next("span").remove();
            $("#dtExpiryDate").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#dtstartdate").val() == "") {
            $("#dtstartdate").next("span").remove();
            $("#dtstartdate").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if (noerror == 1) {
            if (confirm("Are you sure ?")) {

                if ($('#tbl_mst_Post')[0].checkValidity()) {
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
    

    $("#Fk_Disciplineid").change(function () {

        var Fk_Disciplineid = $("#Fk_Disciplineid").val();
        $("#Fk_Disciplineid").next("span").remove();
        if (Fk_Disciplineid == "") {
            $("#Fk_Disciplineid").after("<span style='color:Red'> This field is required</span>");
        }
        else {
            $("#Fk_Disciplineid").next("span").remove();
        }
    });
    $("#Postname").keyup(function () {

        var Postname = $("#Postname").val();
        $("#Postname").next("span").remove();
        if (Postname == "") {
            $("#Postname").after("<span style='color:Red'> This field is required</span>");
        }
        else {
            $("#Postname").next("span").remove();
        }
    });
    $("#Fk_intGrade").keyup(function () {
        var Fk_intGrade = $("#Fk_intGrade").val();
        $("#Fk_intGrade").next("span").remove();
        if (Fk_intGrade == "") {
            $("#Fk_intGrade").after("<span style='color:Red'> This field is required</span>");
        }
        else {
            $("#Fk_intGrade").next("span").remove();
        }
    });
    $("#Payscale").keyup(function () {
        var Payscale = $("#Payscale").val();
        $("#Payscale").next("span").remove();
        if (Payscale == "") {
            $("#Payscale").after("<span style='color:Red'> This field is required</span>");
        }
        else {
            $("#Payscale").next("span").remove();
        }
    });
    $("#dtcompareDate").keyup(function () {
        var dtcompareDate = $("#dtcompareDate").val();
        $("#dtcompareDate").next("span").remove();
        if (dtcompareDate == "") {
            $("#dtcompareDate").after("<span style='color:Red'> This field is required</span>");
        }
        else {
            $("#dtcompareDate").next("span").remove();
        }
    });
    $("#dtExpiryDate").keyup(function () {
        var dtExpiryDate = $("#dtExpiryDate").val();
        $("#dtExpiryDate").next("span").remove();
        if (dtExpiryDate == "") {
            $("#dtExpiryDate").after("<span style='color:Red'> This field is required</span>");
        }
        else {
            $("#dtExpiryDate").next("span").remove();
        }
    });

    $("#dtstartdate").keyup(function () {
        var dtExpiryDate = $("#dtExpiryDate").val();
        $("#dtExpiryDate").next("span").remove();
        if (dtExpiryDate == "") {
            $("#dtExpiryDate").after("<span style='color:Red'> This field is required</span>");
        }
        else {
            $("#dtExpiryDate").next("span").remove();
        }
    });
   
    
    
    
//characterlimit    
    $("#Postname").on("input", function () {
        LimtCharacters(this, 100);
    });

    $("#Postnumber_gen").on("input", function () {
        LimtCharacters(this, 10);
    });
    $("#Postnumber_obc").on("input", function () {
        LimtCharacters(this, 10);
    });

    $("#Postnumber_sc").on("input", function () {
        LimtCharacters(this, 10);
    });
    $("#Postnumber_st").on("input", function () {
        LimtCharacters(this, 10);
    });
    $("#Postnumber_pwd").on("input", function () {
        LimtCharacters(this, 10);
    });
    $("#Fk_intGrade").on("input", function () {
        LimtCharacters(this, 50);
    });

    $("#Payscale").on("input", function () {
        LimtCharacters(this, 50);
    });
    $("#Maxage_freshers").on("input", function () {
        LimtCharacters(this, 6);
    });
    $("#Maxage_exp").on("input", function () {
        LimtCharacters(this, 6);
    });
    $("#Minage_freshers").on("input", function () {
        LimtCharacters(this, 6);
    });
    $("#Minage_exp").on("input", function () {
        LimtCharacters(this, 6);
    });
    $("#Minexp").on("input", function () {
        LimtCharacters(this, 6);
    });
    function LimtCharacters(txtMsg, CharLength) {
        $(txtMsg).next("span").remove();
        chars = txtMsg.value.length;
        if (chars > CharLength && chars > 0) {
            txtMsg.value = txtMsg.value.substring(0, CharLength);
            $(txtMsg).after("<span style='color:Red'> Max Length reached..</span>");
        }
    }
    //Forcenumeric
    $("#Postnumber_gen").ForceNumericOnly();
    $("#Postnumber_obc").ForceNumericOnly();
    $("#Postnumber_sc").ForceNumericOnly();
    $("#Postnumber_st").ForceNumericOnly();
    $("#Postnumber_pwd").ForceNumericOnly();
    $("#Postnumber_sc").ForceNumericOnly();
    $("#Maxage_freshers").ForceNumericOnly();
    $("#Maxage_exp").ForceNumericOnly();
    $("#Minage_freshers").ForceNumericOnly();
    $("#Minage_exp").ForceNumericOnly();
    $("#Minexp").ForceNumericOnly();