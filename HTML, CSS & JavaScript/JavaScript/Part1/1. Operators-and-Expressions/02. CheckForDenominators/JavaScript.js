//Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

function CheckForDenominators() {
    var number = document.getElementById("textBox").value;
    if (number % (5 * 7) == 0) {
        alert("Number is devidible by 7 and 5");
    }
    else {
        alert("Number is NOT devidible by 7 and 5");
    }
}