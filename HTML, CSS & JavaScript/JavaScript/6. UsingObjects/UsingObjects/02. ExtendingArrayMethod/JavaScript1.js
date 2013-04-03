//Task 2: 
//Write a function that removes all elements with a given value
//var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];
//arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];
//Attach it to the array class
//Read about prototype and how to attach methods

Array.prototype.remove = function (element) {
    var newArray = [];
    for (var i = 0; i < this.length; i++) {
        if (this[i] !== element) {
            newArray.push(this[i]);
        }
    }
    return newArray;
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];
var finalArray = arr.remove(1);

for (var element in finalArray) {
    console.log(finalArray[element]);
}