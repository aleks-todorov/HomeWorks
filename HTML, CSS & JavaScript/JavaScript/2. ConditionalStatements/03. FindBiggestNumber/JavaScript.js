//Write a script that finds the biggest of three integers using nested if statements.

function FindMax() {
    var numberOne = parseInt(document.getElementById("numberOne").value);
    var numberTwo = parseInt(document.getElementById("numberTwo").value);
    var numberThree = parseInt(document.getElementById("numberThree").value);

    if (numberOne > numberTwo && numberOne > numberThree) {
        alert("The biggest is: " + numberOne);
    }
    else if (numberTwo > numberOne && numberTwo > numberThree) {
        alert("The biggest is: " + numberTwo);
    }
    else if (numberThree > numberOne && numberThree > numberTwo) {
        alert("The biggest is: " + numberThree);
    }
    else {
        alert("There is no single biggest number")
    }
}
