/// <reference path="../jquery-1.9.1.min.js" />
(function () {

    //I have used both ways, just for the practice;
    $("#btnBefore").on("click", function () {
        $("#container").prepend("<p>Inserted Before</p>");
    });

    $("#btnAfter").on("click", function () {
        $("<p>Inserted After</p>").appendTo("#container");
    });

})();