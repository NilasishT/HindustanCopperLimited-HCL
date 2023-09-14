$("#Str_duration,#Str_duration1,#Str_duration2").ForceNumericOnly();
$(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});



$("#Str_TotalMarks,#Str_MarksObtained,#Str_TotalMarks1,#Str_MarksObtained1,#Str_TotalMarks2,#Str_MarksObtained2").change(function () {
    var Str_TotalMarks = $("#Str_TotalMarks").val();
    var Str_MarksObtained = $("#Str_MarksObtained").val();

    var Str_TotalMarks1 = $("#Str_TotalMarks1").val();
    var Str_MarksObtained1 = $("#Str_MarksObtained1").val();

    var Str_TotalMarks2 = $("#Str_TotalMarks2").val();
    var Str_MarksObtained2 = $("#Str_MarksObtained2").val();


    var Marks = (parseInt(Str_MarksObtained) / parseInt(Str_TotalMarks) * 100);
    var Marks1 = (parseInt(Str_MarksObtained1) / parseInt(Str_TotalMarks1) * 100);
    var Marks2 = (parseInt(Str_MarksObtained2) / parseInt(Str_TotalMarks2) * 100);

    if (!isNaN(Marks)) {
        $("#Str_Marks").val(Marks.toFixed(2));
    }

    if (!isNaN(Marks1)) {        
        $("#Str_Marks1").val(Marks1.toFixed(2));
    }

    if (!isNaN(Marks2)) {
        $("#Str_Marks2").val(Marks2.toFixed(2));
    }
});
 //ERROR
    function error() {
        var noerror = 1;

        var Str_passingyear = $("#Str_passingyear").val();
        var Str_passingyear1 = $("#Str_passingyear1").val();
        var Str_passingyear2 = $("#Str_passingyear2").val();

        if (new Date(Str_passingyear) >= new Date(Str_passingyear1) && Str_passingyear != null && Str_passingyear1 != null) {
            $("#Str_passingyear1").next("span").remove();
            $("#Str_passingyear1").after("<span style='color:Red'> Wrong passing year</span>");
            noerror = 0;
        }
        if (new Date(Str_passingyear) >= new Date(Str_passingyear2) && Str_passingyear != null && Str_passingyear2 != null) {
            $("#Str_passingyear2").next("span").remove();
            $("#Str_passingyear2").after("<span style='color:Red'>  Wrong passing year</span>");
            noerror = 0;
        }
       
        if ($("#Str_course").val() == "") {
            $("#Str_course").next("span").remove();
            $("#Str_course").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


        if ($("#Str_course2").val() == "") {
            $("#Str_course2").next("span").remove();
            $("#Str_course2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Str_board").val() == "") {
            $("#Str_board").next("span").remove();
            $("#Str_board").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Str_board2").val() == "") {
            $("#Str_board2").next("span").remove();
            $("#Str_board2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Str_passingdetails2").val() == "") {
            $("#Str_passingdetails2").next("span").remove();
            $("#Str_passingdetails2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


        if ($("#Str_passingyear").val() == "") {
            $("#Str_passingyear").next("span").remove();
            $("#Str_passingyear").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


        if ($("#Str_passingyear2").val() == "") {
            $("#Str_passingyear2").next("span").remove();
            $("#Str_passingyear2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


        if ($("#Str_duration").val() == "") {
            $("#Str_duration").next("span").remove();
            $("#Str_duration").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


        if ($("#Str_duration2").val() == "") {
            $("#Str_duration2").next("span").remove();
            $("#Str_duration2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Str_Marks").val() == "") {
            $("#Str_Marks").next("span").remove();
            $("#Str_Marks").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


        if ($("#Str_Marks2").val() == "") {
            $("#Str_Marks2").next("span").remove();
            $("#Str_Marks2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


        if ($("#Str_division").val() == "") {
            $("#Str_division").next("span").remove();
            $("#Str_division").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Str_division2").val() == "") {
            $("#Str_division2").next("span").remove();
            $("#Str_division2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#StrRemarks").val() == "") {
            $("#StrRemarks").next("span").remove();
            $("#StrRemarks").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


//        if ($("#StrRemarks2").val() == "") {
//            $("#StrRemarks2").next("span").remove();
//            $("#StrRemarks2").after("<span style='color:Red'> This field is required</span>");
//            noerror = 0;
//        }


        if ($("#Str_TotalMarks").val() == "") {
            $("#Str_TotalMarks").next("span").remove();
            $("#Str_TotalMarks").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Str_TotalMarks2").val() == "") {
            $("#Str_TotalMarks2").next("span").remove();
            $("#Str_TotalMarks2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }
        if ($("#Str_MarksObtained").val() == "") {
            $("#Str_MarksObtained").next("span").remove();
            $("#Str_MarksObtained").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if ($("#Str_MarksObtained2").val() == "") {
            $("#Str_MarksObtained2").next("span").remove();
            $("#Str_MarksObtained2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }


        if ($("#Str_Affiliation2").val() == "") {
            $("#Str_Affiliation2").next("span").remove();
            $("#Str_Affiliation2").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

          if ($("#Str_course1").val() != "" || $("#Str_board1").val() != "" || $("#Str_passingdetails1").val() != "" || $("#Str_passingyear1").val() != "" || $("#Str_duration1").val() != "" || $("#Str_Marks1").val() != "" ||
           $("#Str_division1").val() != "" || $("#StrRemarks1").val() != "" || $("#Str_TotalMarks1").val() != "" || $("#Str_MarksObtained1").val() != "") {


              if ($("#Str_course1").val() == "") {
                  $("#Str_course1").next("span").remove();
                  $("#Str_course1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }

              if ($("#Str_board1").val() == "") {
                  $("#Str_board1").next("span").remove();
                  $("#Str_board1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }

              if ($("#Str_passingdetails1").val() == "") {
                  $("#Str_passingdetails1").next("span").remove();
                  $("#Str_passingdetails1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }

              if ($("#Str_passingyear1").val() == "") {
                  $("#Str_passingyear1").next("span").remove();
                  $("#Str_passingyear1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }

              if ($("#Str_duration1").val() == "") {
                  $("#Str_duration1").next("span").remove();
                  $("#Str_duration1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }

//              if ($("#Str_Marks1").val() == "") {
//                  $("#Str_Marks1").next("span").remove();
//                  $("#Str_Marks1").after("<span style='color:Red'> This field is required</span>");
//                  noerror = 0;
//              }

              if ($("#Str_division1").val() == "") {
                  $("#Str_division1").next("span").remove();
                  $("#Str_division1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }

              if ($("#StrRemarks1").val() == "") {
                  $("#StrRemarks1").next("span").remove();
                  $("#StrRemarks1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }

              if ($("#Str_TotalMarks1").val() == "") {
                  $("#Str_TotalMarks1").next("span").remove();
                  $("#Str_TotalMarks1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }
              if ($("#Str_MarksObtained1").val() == "") {
                  $("#Str_MarksObtained1").next("span").remove();
                  $("#Str_MarksObtained1").after("<span style='color:Red'> This field is required</span>");
                  noerror = 0;
              }
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

