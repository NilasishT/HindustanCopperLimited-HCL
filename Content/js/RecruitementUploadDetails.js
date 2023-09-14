function readURL(input, id) {   
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        var size = input.files[0].size / 1024;
        if (parseFloat(size) <= 50) {

            reader.onload = function (e) {
                $('#' + id)
                        .attr('src', e.target.result)
                        .width(100)
                        .height(100);
            };

            reader.readAsDataURL(input.files[0]);
        }
    }
}



$('input[type="file"]').change(function (e) {
    var extension = $(this).val().replace(/^.*\./, '');

    if (extension.toLowerCase() == 'png' || extension.toLowerCase() == 'jpeg' || extension.toLowerCase() == 'jpg') {
        var size = this.files[0].size / 1024;

        if (parseFloat(size) <= 50) {

        }
        else {

            alert('Maximum file size allowed for upload 50 KB .');
            $(this).val('');

        }

    }
    else {
        alert('Only png,jpeg,jpg file is allowed.');
        $(this).val('');
    }


})

function error() {
   
        var noerror = 1;

        if ($("#str_uploadphoto").val() == "" && $("#hdPhoto").val() == "/content/img/passport-photo1.png") {
            $("#str_uploadphoto").next("span").remove();
            $("#str_uploadphoto").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }




        if ($("#str_uploadsignature").val() == "" && $("#hdSignature").val() == "/content/img/signatureBox1.png") {
            $("#str_uploadsignature").next("span").remove();
            $("#str_uploadsignature").after("<span style='color:Red'> This field is required</span>");
            noerror = 0;
        }

        if (noerror == 1) {
            if (confirm("Are you sure ?")) {
                return true;
            }
            else {
                return false;
            }

        }


        if (noerror == 0) {
            return false;



        }
    }






