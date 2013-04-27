//Write an expression that checks if given integer is odd or even.

function CheckForOddOrEven() {
    var number = document.getElementById("textBox").value;
    if (number % 2 == 0) {
        alert("The number is even!");
    }
    else {
        alert("The number is odd!");
    }
}