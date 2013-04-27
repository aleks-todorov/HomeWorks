//Task 1: 
//Write a script that allocates array of 20 integers and initializes 
//each element by its index multiplied by 5. Print the obtained array on the console.

var numberArray = new Array(20);
var i = 0;
for (i = 0; i < numberArray.length; i++) {
    numberArray[i] = i * 5;
    console.log(numberArray[i]);
}
