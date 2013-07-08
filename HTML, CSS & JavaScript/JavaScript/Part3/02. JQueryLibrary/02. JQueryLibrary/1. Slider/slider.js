/// <reference path="../jquery-1.9.1.min.js" />
var slider = (function () {
    var elements = [];
    var counter = 0;
    $('<div id="slider"></div>').appendTo('body');
    var slider = $("#slider");
    console.log(slider);

    for (var i = 0; i < 5; i++) {
        var slide = $('<div class= "slide">' + i + '</div>');
        elements.push(slide);
    }

    setInterval(ShowElement, 3000);

    function ShowElement(step) {

        step = step | 1;
        if ($(".slide")) {
            $(".slide").remove();
        }

        if (counter > elements.length - 1) {
            counter = 0;
        }

        $(elements[counter]).appendTo('#slider');
        counter += step;
    }

    $("#nextButton").on("click", function () {

        CheckCounterRange();
        ShowElement(1);
    });

    //Sometimes there is a problem because of the SetInterval request. 
    $("#prevButton").on("click", function () {

        CheckCounterRange();
        ShowElement(-1);
    });

    function CheckCounterRange() {

        if (counter < 0) {
            counter = elements.length - 1;
        }
        else if (counter > elements.length - 1) {
            counter = 0;
        }
    }
})();