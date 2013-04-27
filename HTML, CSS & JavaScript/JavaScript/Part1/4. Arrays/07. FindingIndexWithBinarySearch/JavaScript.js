//Task 7: 
//Write a program that finds the index of given element in a sorted 
//array of integers by using the binary search algorithm (find it in Wikipedia)

var array = new Array(100);
var i = 0;
//Predefining arrays values for easier comapring of resutls
for (i = 0; i < array.length; i++) {
    array[i] = i;
}
//Set posstion from here: 
var possition = 35;
//Binary search needed variables:
var low = 0;
var high = array.length - 1;
var middlePossition = parseInt((low + high) / 2);
//Performing the Binary Search algo
while (low + 1 < high) {
    middlePossition = parseInt((low + high) / 2);
    if (possition < middlePossition) {
        high = middlePossition;
    }
    else {
        low = middlePossition;
    }
}

//Printing results:
console.log(low);
