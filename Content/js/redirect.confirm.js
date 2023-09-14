// Redirect Confirm
// Version   : 1.0.2
// Developer : Ekrem KAYA
// Website   : http://e-piksel.com
// GitHub    : https://github.com/epiksel/redirect-confirm

!(function ($) {
    $.fn.RedirectConfirm = function(options) {
        var defaults = {
            selector: 'a',
            excluding: 'data-rc-exclude', // excluding attribute
            title: 'Exiting our website',
            message: 'You are now leaving our website. We are not responsible for any external Web sites or their content.',
            continuelbl: 'Continue',
            returnlbl: 'Return',
            targetUrl: '_blank'
        };

        var options = $.extend(defaults, options);
        var confirmed = false;
        var getDomain = function(hostname) {
            var s = hostname.split(',');
            return s.slice(-2).join('.');
        };

        var currentDomain = getDomain(location.hostname);
        var link = new Array();
        $(options.selector).each(function() {

            var $modal = $('<div id="redirectconfirm-modal" class="modal fade">\
                <div class="modal-dialog">\
                    <div class="modal-content">\
                        <div class="modal-header">\
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>\
                            <h3>' + options.title + '</h3>\
                        </div>\
                        <div class="modal-body">\
                            <p>' + options.message + '</p>\
                        </div>\
                        <div class="modal-footer">\
                            <a href="#" class="btn btn-default" data-dismiss="modal">' + options.returnlbl + '</a>\
                            <a href="' + $(this).attr("href") + '" target="' + options.targetUrl + '" class="btn btn-primary btn-continue">' + options.continuelbl + '</a>\
                        </div>\
                    </div>\
                </div>\
            </div>').appendTo('body');

            var $a = jQuery(this);
            var $exclude = $a.attr(options.excluding);

            if ($exclude == 'true' && $exclude != 'undefined') {
                $a.attr(options.excluding, true);
            }

            if ($a.get(0).hostname && getDomain($a.get(0).hostname) != currentDomain && !$exclude) {
                $a.click(function(event) {
                    if (!confirmed) {
                        link.push($(this).attr("href"));
                        event.preventDefault();
                        event.stopPropagation();

                        $modal.on('show', function() {
                            $modal.find('.btn-continue').click(function() {
                                confirmed = true;
                                $a.get(0).click();
                                $modal.modal('hide');
                                location.reload();
                            });
                        });

                        $modal.on('hide', function() {
                            confirmed = false;
                        });

                        $modal.find('.btn-continue').click(function() {
                            $modal.modal('hide');
                        });

                        $modal.find('.modal-body > p').html(options.message.replace('{url}', $a.attr('href')));
                        $modal.modal('show');
                    }
                });
            }
        });
    }
})(jQuery);