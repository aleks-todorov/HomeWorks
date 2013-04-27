//Task 4: 
//Write a script that finds the maximal increasing sequence in an array. 
//Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

var numberArray = [1, 4, 3, 4, 5, 5, 7];
var isFirst = true;
var currentNumber;
var maxSequence = new Array();
var currentSequence = new Array();

for (var index in numberArray) {
    if (isFirst == true) {
        currentNumber = numberArray[index];
        currentSequence.push(numberArray[index]);
        isFirst = false;
        continue;
    }
    if (currentNumber + 1 == numberArray[index]) {
        currentSequence.push(numberArray[index]);
        if (currentSequence.length >= maxSequence.length) {
            maxSequence = currentSequence;
        }
        currentNumber = numberArray[index];
    }
    else {
        currentNumber = numberArray[index];
        if (currentSequence.length >= maxSequence.length) {
            maxSequence = currentSequence;
        }
        currentSequence = new Array();
        currentSequence.push(numberArray[index]);
        currentNumber = numberArray[index];
    }
}

for (var index in maxSequence) {
    console.log(maxSequence[index]);
}