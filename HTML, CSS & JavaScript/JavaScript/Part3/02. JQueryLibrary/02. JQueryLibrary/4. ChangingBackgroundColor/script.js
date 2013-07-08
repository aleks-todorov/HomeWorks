/// <reference path="../jquery-1.9.1.min.js" /> 

(function () {

    $("#changer").change(function () {
        var color = $("#changer").val();
        $("body").css("background-color", color);
    });
})();