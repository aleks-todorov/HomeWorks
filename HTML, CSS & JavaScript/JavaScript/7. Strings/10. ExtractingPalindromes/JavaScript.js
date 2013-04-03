//Task 10: 
//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

var text = "ABBA something lamal somethingelse exe asdasd adddda and some other text for endne";
var words = text.split(' ');
var i = 0;
var j = 0;
var word = new String();
var isPalindrome = true;
for (i = 0; i < words.length; i++) {
    word = words[i];
    isPalindrome = true;
    for (j = 0; j < word.length / 2; j++) {
        if (word.charAt(j) !== word.charAt(word.length - j - 1)) {
            isPalindrome = false;
            break;
        }
    }
    if (isPalindrome == true) {
        console.log(word);
    }
}