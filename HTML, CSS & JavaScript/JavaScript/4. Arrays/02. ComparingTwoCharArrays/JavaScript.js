//Task 2: 
//Write a script that compares two char arrays lexicographically (letter by letter).

var charArrayOne = ['h', 'g', 't', 'r', 'q', 'i'];
var charArrayTwo = ['h', 'g', 't', 'r', 'q', 'i'];
var areEqual = true;
var i = 0;

for (i = 0; i < charArrayOne.length; i++) {
    if (charArrayOne[i] != charArrayTwo[i]) {
        areEqual = false;
        break;
    }
}
if (areEqual == false) {
    console.log("Arrays are not same");
}
else {
    console.log("Arrays are lexicographically same");
}