//Task 3: 
//Write a script that finds the max and min number from a sequence of numbers

var array = [1, 2, 4, 5, 6, -34, 23, 100, 23, 645, -123, 234, 0];
var minValue = array[0];
var maxValue = array[0];
for (var i in array) {
    if (array[i] > maxValue) {
        maxValue = array[i];
    }
    if (array[i] < minValue) {
        minValue = array[i];
    }
}

console.log(minValue);
console.log(maxValue);