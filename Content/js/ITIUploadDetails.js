
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

var _URL = window.URL || window.webkitURL;

$('input[type="file"]').change(function (e) {
    var file, img;
    if ((file = this.files[0])) {
        img = new Image();
        img.onload = function () {
            $("#hidImageWidth").val(this.width);
            $("#hidImageHeight").val(this.height);
        };

        img.onerror = function () {
            alert("not a valid file: " + file.type);
        };
        img.src = _URL.createObjectURL(file);
    }


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


//        if ($("#str_upload10").val() == "" && $("#hdUpload10").val() == "") {
//            $("#str_upload10").next("span").remove();
//            $("#str_upload10").after("<span style='color:Red'> This field is required</span>");
//            noerror = 0;
//        }



//        if ($("#str_uploadITI").val() == "" && $("#hdUploadITI").val() == "") {            
//            $("#str_uploadITI").next("span").remove();
//            $("#str_uploadITI").after("<span style='color:Red'> This field is required</span>");
//            noerror = 0;
//        }



//        if ($("#str_uploadRegistrationITI").val() == "" && $("#hdRegistrationITI").val() == "") {
//            $("#str_uploadRegistrationITI").next("span").remove();
//            $("#str_uploadRegistrationITI").after("<span style='color:Red'> This field is required</span>");
//            noerror = 0;
//        }



//        if ($("#hdCastecondition").val() != "General" && $("#hdCaste").val() == '' && $("#str_uploadcast").val()=='') {
//            $("#str_uploadcast").next("span").remove();
//            $("#str_uploadcast").after("<span style='color:Red'> This field is required</span>");
//            noerror = 0;
//        }


//        if (parseInt($("#hdAffidavit").val()) <= 2016 && $("#hdUploadAffidavit").val() == '' && $("#str_uploadaffidavit").val() == '') {
//            $("#str_uploadaffidavit").next("span").remove();
//            $("#str_uploadaffidavit").after("<span style='color:Red'> This field is required</span>");
//            noerror = 0;
//        }

//        if ($("#hdReferencecondition").val() == "YES" && $("#hdReference").val() == '' && $("#str_uploadReference").val()=='') {
//            $("#str_uploadReference").next("span").remove();
//            $("#str_uploadReference").after("<span style='color:Red'> This field is required</span>");
//            noerror = 0;
//        }


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






