//Task 6: 
//Write a function that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

function CheckNeighbours(numberArray, numberToCount) {
    var i = 0;
    var numberArray = [1, 2, 3, 4, 6, 6, 6, 7, 78, 8, 6, 5, 5, 76];
    var checkPossition = 8;

    if (CheckIfBigger(numberArray, checkPossition)) {
        alert("Number is bigger");
    }
    else {
        alert("Number is smaller");
    }

    //Task 7: 
    //Write a Function that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
    //Use the function from the previous exercise.
    var positionOfElement = -1;
    for (i = 0; i < numberArray.length; i++) {
        if (CheckIfBigger(numberArray, i)) {
            positionOfElement = i;
            break;
        }
    }
    alert(positionOfElement);
}

function CheckIfBigger(numberArray, checkPossition) {
    var isBigger = true;
    if (checkPossition > 0 && !(numberArray[checkPossition] > numberArray[checkPossition - 1])) {
        isBigger = false;
    }
    if (checkPossition < numberArray.length && !(numberArray[checkPossition] > numberArray[checkPossition + 1])) {
        isBigger = false;
    }
    return isBigger;
}