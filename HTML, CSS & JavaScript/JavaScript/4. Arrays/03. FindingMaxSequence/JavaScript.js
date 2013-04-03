//Task 3: 
//Write a script that finds the maximal sequence of equal elements in an array.
//Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

var i = 0;
var numberArray = [2, 1, 1, 2, 3, 3, 3, 2, 2, 1];
var sequence = 0;
var maxSequence = 0;
var isFirst = true;
var currentNumber;
var maxNumberOccured;

for (var index in numberArray) {
    if (isFirst == true) {
        sequence++;
        currentNumber = numberArray[index];
        isFirst = false;
        continue;
    }
    if (currentNumber == numberArray[index]) {
        sequence++;
        if (sequence >= maxSequence) {
            maxNumberOccured = currentNumber;
            maxSequence = sequence;
        }
    }
    else {
        currentNumber = numberArray[index];
        sequence = 1;
    }
}

for (i = 1; i <= maxSequence; i++) {
    console.log(maxNumberOccured);
}