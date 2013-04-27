//Write a script that shows the sign (+ or -) of the product of three real numbers 
//without calculating it. Use a sequence of if statements.

function FindBiggest() {
    var countOfMinuses = 0;
    var number = parseInt(document.getElementById("numberOne").value);
    if (number < 0) {
        countOfMinuses++;
    }
    var number = parseInt(document.getElementById("numberTwo").value);
    if (number < 0) {
        countOfMinuses++;
    }
    var number = parseInt(document.getElementById("numberThree").value);
    if (number < 0) {
        countOfMinuses++;
    }

    if (countOfMinuses % 2 == 0) {
        alert("The sign will be positive!");
    }
    else {
        alert("The sign will be negative!");
    }
}
