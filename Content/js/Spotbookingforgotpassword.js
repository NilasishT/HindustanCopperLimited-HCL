function error() {
    var noerror = 1;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
   
    var email = $("#str_email").val();


     if ($("#str_email").val() == "") {
        $("#str_email").next("span").remove();
        $("#str_email").after("<span style='color:Red'> This field is required</span>");
        noerror = 0;
    }

     if (!emailReg.test(email)) {
        $("#str_email").next("span").remove();
        $("#str_email").after("<span style='color:Red'>Please enter valid Email </span>");
        noerror = 0;
    }
    if (noerror == 1) {
        if (confirm("Are you sure ?")) {

            if ($('#SpotbookingRegistrationdetails')[0].checkValidity()) {
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