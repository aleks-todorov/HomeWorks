//Task 1: 
//Write a JavaScript function reverses string and returns itExample: "sample"  "elpmas".

var word = "987654321";
var reversedWord = new String();
var i = 0;
for (i = 0; i <= word.length; i++) {
    reversedWord += word.charAt(word.length - i);
}
console.log(reversedWord);