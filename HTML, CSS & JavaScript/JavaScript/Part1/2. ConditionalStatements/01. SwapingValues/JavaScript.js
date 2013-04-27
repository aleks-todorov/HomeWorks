//Write an if statement that examines two integer variables and exchanges their 
//values if the first one is greater than the second one.

function CheckNumbers() {
    var numberOne = parseInt(document.getElementById("numberOne").value);
    var numberTwo = parseInt(document.getElementById("numberTwo").value);
    var swapValue = 0;
    if (numberOne > numberTwo) {
        swapValue = numberOne;
        numberOne = numberTwo;
        numberTwo = swapValue;
    }
    alert("First Value: " + numberOne + " Second Value: " + numberTwo);
}