//Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

function CheckDigit() {
    var number = document.getElementById("number").value;
    number = parseInt(number / 100);
    var isSeven = true;
    if ((number % 10) == 7) {
        alert("The third digit(right-to-l eft) is 7 - " + isSeven);
    }
    else {
        isSeven = false;
        alert("The third digit(right-to-l eft) is 7 - " + isSeven);
    }
}
