//Task 5: 
//Write a function that counts how many times given number appears in given array. Write a test function to check if the function is working correctly.

function CountOccurence(numberArray, numberToCount) {
    var i = 0;
    var counter = 0;
    for (i = 0; i < numberArray.length; i++) {
        if (numberArray[i] === numberToCount) {
            counter++;
        }
    }
    return counter;
}

function TestCounter() {
    var numberToCount = 6;
    var numberArray = [1, 2, 3, 4, 6, 6, 6, 7, 78, 8, 6, 5, 5, 76];
    //Number 6 is occuring 4 times
    if (CountOccurence(numberArray, numberToCount) == 4) {
        alert("Count Function is working properly");
    }
    else {
        alert("Count Function is NOT working properly");
    }


}