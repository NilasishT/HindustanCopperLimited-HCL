$(document).ready(function () {
    $('#btnPrint').click(function () {
       // $('#btnPrint').hide();
        var css = '@page { size: a4; }',
            head = document.head || document.getElementsByTagName('head')[0],
            style = document.createElement('style');
        style.type = 'text/css';
        style.media = 'print';
        if (style.styleSheet) {
            style.styleSheet.cssText = css;
        } else {
            style.appendChild(document.createTextNode(css));
        }
        head.appendChild(style);
        window.print();
    });
})