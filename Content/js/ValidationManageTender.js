

    $("#strVendorsId").change(function () {
        var valueNew = $('#strVendorsId').multipleSelect('getSelects');
        if (valueNew != "" && valueNew != null) {
            var countLength = valueNew.toString().split(",");
            var TenderType = $("#strTenderType").val();
            if (countLength.length > 1 && TenderType == 'STE') {                 
                alert('Please select a single vendor.');
                $('#strVendorsId').multipleSelect('uncheckAll');
            }
        }
    });

    $("#fk_intUnitId").change(function () {
        var E1 = $('#strVendorsId').multipleSelect('getSelects');
        var no = $("#fk_intUnitId").val();
        if (no == "") {
  
        $("#strEnquiryNo").val("");
        $("#hidstrEnquiryNo").val("");
                    
        }
        else {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '/Admin/EnquiryNo',
                data: { 'fk_intUnitId': no },
                success: function (result) {
                    $('#strVendorsId').empty();
                    $("#hidstrVendorsId").val('');
                    if (result.EnquiryNo != "") {
                        $("#strEnquiryNo").val(result.EnquiryNo);
                        $("#hidstrEnquiryNo").val(result.EnquiryNo);
                    }
                    
                },
                error: function () {

                    alert('Error');
                }

            });
        }

    });


    $("#strTenderType,#fk_intUnitId").change(function () {
        // 
        var TenderType = $("#strTenderType").val();
        var UnitId = $("#fk_intUnitId").val();
        if (UnitId == "") {
            $('#strVendorsId').empty();
            $('#strVendorsId').multipleSelect('refresh');
            alert("Please select unit.");

        }
        else {

            if (TenderType == 'STE' || TenderType == 'LTE') {

                var E1 = $('#strVendorsId').multipleSelect('getSelects');
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '/Admin/VendorNo',
                    data: { 'fk_intUnitId': UnitId },
                    success: function (result) {
                        $('#strVendorsId').empty();
                        $("#hidstrVendorsId").val('');
                        if (result.EnquiryNo != "") {
                            if (result.Vendor.length > 0) {
                                $.each(result.Vendor, function (result) {
                                    $('#strVendorsId').append($('<option/>').attr('value', this.Pk_intNewVendorRegistrationID).text(this.strVendorRegistrationID));
                                });
                                $('#strVendorsId').multipleSelect('setSelects', [E1]);
                            }
                            $('#strVendorsId').multipleSelect('refresh');
                        }

                    },
                    error: function () {

                        alert('Error');
                    }

                });
            }


            else {
                $('#strVendorsId').empty();
                $('#strVendorsId').multipleSelect('refresh');
            }
        }
    });



    $('#strVendorsId').multipleSelect({
        isOpen: true,
        keepOpen: true,
        selectAll: true,
        minimumCountSelected: 1,
        single: false,
        maxHeight: 150
    });



    
   

       function error1(){
       var noerror = 1;
       var fk_intUnitId= $('#fk_intUnitId').val();
       var strEnquiryNo = $('#strEnquiryNo').val();
       var strEnquiryTitle = $('#strEnquiryTitle').val();
       var dtEnquiryDate = $('#dtEnquiryDate').val();
       var dtActiveDate = $('#dtActiveDate').val();
       var dtClosingDate = $('#dtClosingDate').val();
       var strTenderType = $('#strTenderType').val();
//       var  doc= fileupload

       $('#hidstrVendorsId').val($('#strVendorsId').multipleSelect('getSelects'))

       var TenderType = $("#strTenderType").val();
       if (TenderType == 'STE' || TenderType == 'LTE') {

           if ($("#fk_intUnitId").val() == '') {
               alert('Please Select Unit');
               return false;
           }

           if ($('#strVendorsId').multipleSelect('getSelects') == '' || $('#strVendorsId').multipleSelect('getSelects') == null) {
               alert('Please Select Vendor');
               return false;
           }
       }


       if (fk_intUnitId == "") {
           $("#errmsg7").html('This field is required').show().css("color", "red");
           noerror = 0;
       }

       if (strEnquiryNo == "") {
           $("#errmsg8").html('This field is required').show().css("color", "red");
           noerror = 0;
       }

       if (strEnquiryTitle == "") {
           $("#errmsg").html('This field is required').show().css("color", "red");
           noerror = 0;
       }

//       if (dtEnquiryDate == "") {
//           $("#").html('This field is required').show().css("color", "red");
//           noerror = 0;
//       }

//       if (dtActiveDate == "") {
//           $("#").html('This field is required').show().css("color", "red");
//           noerror = 0;
//       }

//       if (dtClosingDate == "") {
//           $("#").html('This field is required').show().css("color", "red");
//           noerror = 0;
//       }

       if (strTenderType == "") {
           $("#errmsg6").html('This field is required').show().css("color", "red");
           noerror = 0;
       }




       if (noerror == 1) {
           if (confirm("Are you sure ?")) {

               if ($('#ValidationManageTender')[0].checkValidity()) {
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



    $("#numCostofTender").ForceNumericOnly();
    $("#numEarnestMoney").ForceNumericOnly();

    //Shoumya
    
    $("#strEnquiryTitle").on("input", function () {
        LimtCharacters(this, 500, 'errmsg');
    });
    $("#numCostofTender").on("input", function () {
        LimtCharacters(this, 14, 'errmsg1');
    });
    $("#numEarnestMoney").on("input", function () {
        LimtCharacters(this, 14, 'errmsg2');
    });
    $("#strBiddersQualification").on("input", function () {
        LimtCharacters(this, 500, 'errmsg3');
    });
    $("#strBiddingInstruction").on("input", function () {
        LimtCharacters(this, 500, 'errmsg4');
    });
    $("#strSignature").on("input", function () {
        LimtCharacters(this, 500, 'errmsg5');
    });

    function LimtCharacters(txtMsg, CharLength, errmsg) {
        chars = txtMsg.value.length;
        if (chars > CharLength) {
            txtMsg.value = txtMsg.value.substring(0, CharLength);
            $("#" + errmsg).html("Max Length reached..").show().fadeOut("slow").css("color", "red");
        }
    }


    $('input[type="file"]').change(function (e) {
        var extension = $(this).val().replace(/^.*\./, '');

        if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpeg' || extension.toLowerCase() == 'doc' || extension.toLowerCase() == 'docx' || extension.toLowerCase() == 'xls' || extension.toLowerCase() == 'xlsx') {
            var size = this.files[0].size / 1048576;
            if (parseFloat(size) <= 4) {
            }
            else {
                alert('Please check file Size');
                $(this).val('');
            }

        }
        else {
            alert('Please check file extension');
            $(this).val('');
        }


    });



    $("#fk_intUnitId").change(function () {
        if (this.value == "" || this.value == undefined) {
            $("#errmsg7").html('This field is required').show().css("color", "red");
            $("#errmsg8").html('This field is required').show().css("color", "red");

            return false;

        }
        else {
            $("#errmsg7").html('');
            $("#errmsg8").html('');
        }
    });


   

    $("#strEnquiryTitle").keyup(function () {
        if (this.value.length == 0) {
            $("#errmsg").html('This field is required').show().css("color", "red");
            return false;

        }
        else {
            $("#errmsg").html('');
        }
    });



       // $("#dtEnquiryDate").keyup(function () {
//        if (this.value.length == 0) {
//            $("#errmsg").html('This field is required').show().css("color", "red");
//            return false;

//        }
//        else {
//            $("#errmsg").html('');
//        }
//    });
//    $("#dtActiveDate").keyup(function () {
//        if (this.value.length == 0) {
//            $("#errmsg").html('This field is required').show().css("color", "red");
//            return false;

//        }
//        else {
//            $("#errmsg").html('');
//        }
//    });
//    $("#dtClosingDate").keyup(function () {
//        if (this.value.length == 0) {
//            $("#errmsg").html('This field is required').show().css("color", "red");
//            return false;

//        }
//        else {
//            $("#errmsg").html('');
//        }
//    });

    $("#strTenderType").change(function () {
        if (this.value.length == 0) {
            $("#errmsg6").html('This field is required').show().css("color", "red");
            return false;

        }
        else {
            $("#errmsg6").html('');
        }
    });


