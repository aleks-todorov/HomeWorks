//Task 2: 
//Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time


var number = 100;
var i = 1;
for (i = 1; i <= number; i++) {
    if (parseInt(i % 21) != 0) {
        console.log(i);
    }
}