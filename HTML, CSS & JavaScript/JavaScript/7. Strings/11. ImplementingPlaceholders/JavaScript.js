//Task 11: 
//Write a function that formats a string using placeholders:
//var str = stringFormat("Hello {0}!","Peter");
//str = "Hello Peter!";
//The function should work with up to 30 placeholders and all types
//var format = "{0}, {1}, {0} text {2}";
//var str = stringFormat(format, 1, "Pesho", "Gosho");
//str = "1, Pesho, 1 text Gosho"

var format = "{0}, {1}, {0} text {2}";
var str = stringFormat(format, 1, "Pesho", "Gosho");

console.log(str);

function stringFormat() {
    var result = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        result = result.replace(new RegExp('\\{' + (i - 1) + '\\}', "g"), arguments[i]);
    }
    return result;
}