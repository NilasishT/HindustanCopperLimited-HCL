$(function () {
    //original field values
    var field_values = {
        //id        :  value
        'username': 'username',
        'password': 'password',
        'cpassword': 'password',
        'firstname': 'first name',
        'lastname': 'last name',
        'email': 'email address',
        'mobileno': 'mobile no'
    };




    //inputfocus
    $('input#username').inputfocus({ value: field_values['username'] });
    $('input#password').inputfocus({ value: field_values['password'] });
    $('input#cpassword').inputfocus({ value: field_values['cpassword'] });
    $('input#lastname').inputfocus({ value: field_values['lastname'] });
    $('input#firstname').inputfocus({ value: field_values['firstname'] });
    $('input#email').inputfocus({ value: field_values['email'] });
    $('input#mobileno').inputfocus({ value: field_values['mobileno'] });




    $("#firstname,#lastname").keypress(function (e) {
        var code = e.keyCode || e.which;
        if ((code < 65 || code > 90) && (code < 97 || code > 122) && code != 32 && code != 46 && code != 127 && code != 8 && code != 9) {
            return false;
        }
    });


    //reset progress bar
    $('#progress').css('width', '0');
    $('#progress_text').html('0% Complete');

    //first_step
    $('form').submit(function () { return false; });
    $('#submit_first').click(function () {
        //remove classes
        $('#first_step input').removeClass('error').removeClass('valid');

        //ckeck if inputs aren't empty
        var fields = $('#first_step input[type=text], #first_step input[type=password]');
        var error = 0;
        fields.each(function () {
            var value = $(this).val();
            if (value.length < 4 || value == field_values[$(this).attr('id')]) {
                $(this).addClass('error');
                $(this).effect("shake", { times: 3 }, 50);

                error++;
            } else {
                $(this).addClass('valid');
            }
        });

        if (!error) {
            if ($('#password').val() != $('#cpassword').val()) {
                $('#first_step input[type=password]').each(function () {
                    $(this).removeClass('valid').addClass('error');
                    $(this).effect("shake", { times: 3 }, 50);
                });

                return false;
            } else {
                //update progress bar
                $('#progress_text').html('33% Complete');
                $('#progress').css('width', '113px');

                //slide steps
                $('#first_step').slideUp();
                $('#second_step').slideDown();
            }
        } else return false;
    });


    $('#submit_second').click(function () {
        //remove classes
        $('#second_step input').removeClass('error').removeClass('valid');

        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        var mobilePattern = /^((\+[1-9]{1,4}[ \-]*)|(\([0-9]{2,3}\)[ \-]*)|([0-9]{2,4})[ \-]*)*?[0-9]{3,4}?[ \-]*[0-9]{3,4}?$/;
        var pattern = /^\d{10}$/;

        var fields = $('#second_step input[type=text]');
        var error = 0;
        fields.each(function () {
            var value = $(this).val();
            if (value.length < 1 || value == field_values[$(this).attr('id')] || ($(this).attr('id') == 'mobileno' && !mobilePattern.test(value)|| ($(this).attr('id') == 'mobileno' && !pattern.test(value) || ($(this).attr('id') == 'email' && !emailPattern.test(value))))) {
                $(this).addClass('error');
                $(this).effect("shake", { times: 3 }, 50);

                error++;
            } else {
                $(this).addClass('valid');
            }
        });

        if (!error) {
            //update progress bar
            $('#progress_text').html('66% Complete');
            $('#progress').css('width', '246px');

            //slide steps
            $('#second_step').slideUp();
            $('#third_step').slideDown();
        } else return false;


        

    });


    $('#submit_third').click(function () {
        //update progress bar
        $('#progress_text').html('100% Complete');
        $('#progress').css('width', '380px');

        //prepare the fourth step
        var fields = new Array(
            $('#username').val(),
//            $('#password').val(),
            $('#firstname').val() + ' ' + $('#lastname').val(),
            $('#mobileno').val(),
            $('#email').val(),
            $('#age').val(),
            $('#gender').val(),
            $('#country').val()
        );
        var tr = $('#fourth_step tr');
        tr.each(function () {
            //alert( fields[$(this).index()] )
            $(this).children('td:nth-child(2)').html(fields[$(this).index()]);
        });

        //slide steps
        $('#third_step').slideUp();
        $('#fourth_step').slideDown();
    });


    $('#submit_fourth').click(function () {
        //send information to server
        alert('Data sent');

    });

});