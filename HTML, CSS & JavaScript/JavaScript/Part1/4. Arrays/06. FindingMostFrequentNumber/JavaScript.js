//Task 6: 
//Write a program that finds the most frequent number in an array. Example:
//{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

var array = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
var currentNumber = 0;
var mostFrequentNumber = 0;
var occurence = 1;
var maxOccurence = 1;
var i = 0;
array.sort(orderBy());

for (i = 0; i < array.length; i++) {
    currentNumber = array[i];
    if (currentNumber == array[i + 1]) {
        occurence++;
        continue;
    }
    if (occurence > maxOccurence) {
        maxOccurence = occurence;
        mostFrequentNumber = array[i - 1];
    }
    occurence = 1;
}

console.log("Number: " + mostFrequentNumber + " occured: " + maxOccurence + " times");

function orderBy(a, b) {
    return (a == b) ? 0 : (a > b) ? 1 : -1
}

