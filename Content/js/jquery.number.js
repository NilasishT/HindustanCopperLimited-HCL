jQuery.fn.ForceNumericOnly =
function()
{
    return this.each(function()
    {
        $(this).keydown(function(e)
        {
            var key = e.charCode || e.keyCode || 0; // allow backspace, tab, delete, arrows, numbers and keypad numbers ONLY
            return (
                        key == 8 ||
                        key == 9 ||
                        key == 46 ||
                        (key >= 37 && key <= 40) ||
                        (key >= 48 && key <= 57) ||
                        (key >= 96 && key <= 105)
                    );
        })
    })
};

history.pushState(null, document.title, location.href);
window.addEventListener('popstate', function (event) {
    history.pushState(null, document.title, location.href);
});

$('input').attr("autocomplete", "off");
$('input[type="password"]').attr("autocomplete", "off");
$('#strUserPwd').attr("autocomplete", "off");
$("form").attr("autocomplete", "off");

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


})

