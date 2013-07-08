/// <reference path="jquery-1.9.1.min.js" />
(function ($) {

    $.fn.expandable = function () {
        $(this).find("li").click(function (ev) {
            ev.stopPropagation();
        });
        $(this).find('li>ul').parent().click(function (ev) {
            ev.stopPropagation();
            $(this).find('>ul').toggle('normal');
        });

        return $(this);
    };
})(jQuery);