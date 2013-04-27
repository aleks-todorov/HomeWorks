//Task 5: 
//Sorting an array means to arrange its elements in increasing order.
//Write a script to sort an array. Use the "selection sort" algorithm: 
//Find the smallest element, move it at the first position, find the smallest from the rest, 
//move it at the second position, etc.Hint: Use a second array

var array = [2, 3, 4, 2, 1, 8, 4, 7, 3, 4, 6, 7, 8, 9];
var sortedArray = new Array(array.length);
var i = 0;
var j = 0;

for (i = 0; i < sortedArray.length; i++) {
    var minNumber = Number.MAX_VALUE;
    var position = 0;
    for (j = 0; j < array.length; j++) {
        if (minNumber > array[j]) {
            minNumber = array[j];
            position = j;
        }
        if (j == array.length - 1) {
            sortedArray[i] = array[position];
            array[position] = Number.MAX_VALUE;
        }
    }
}

console.log(sortedArray.join(', '));
