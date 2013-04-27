//Sort 3 real values in descending order using nested if statements.

function Sort() {
    var numberOne = document.getElementById('numberOne').value;
    var numberTwo = document.getElementById('numberTwo').value;
    var numberThree = document.getElementById('numberThree').value;

    if (numberOne > numberTwo && numberOne > numberThree) {
        if (numberTwo > numberThree) {
            alert(numberOne + " " + numberTwo + " " + numberThree);
        }
        else {
            alert(numberOne + " " + numberThree + " " + numberTwo);
        }
    }
    if (numberTwo > numberOne && numberTwo > numberThree) {
        if (numberOne > numberThree) {
            alert(numberTwo + " " + numberOne + " " + numberThree);
        }
        else {
            alert(numberTwo + " " + numberThree + " " + numberOne);
        }
    }
    if (numberThree > numberOne && numberThree > numberTwo) {
        if (numberOne > numberTwo) {
            alert(numberThree + " " + numberOne + " " + numberTwo);
        }
        else {
            alert(numberThree + " " + numberTwo + " " + numberOne);
        }
    }
}
