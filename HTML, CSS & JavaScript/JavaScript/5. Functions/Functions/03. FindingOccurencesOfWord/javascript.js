//Task 3: 
//Write a function that finds all the occurrences of word in a text
//The search can case sensitive or case insensitive
//Use function overloading

function FindOccurence() {
    var text = document.getElementById('inputBox').value;
    //For the purpose of this demo the only separator is ' '
    var words = text.split(' ');
    //This method will show only 1
    CheckForOccurences(words, 'Lorem', "caseSenstive");
    //This method will show 2
    CheckForOccurences(words, 'lorem', "caseInsenstive");
}

function CheckForOccurences(words, wordToFind, typeOfSerach) {
    var counter = 0;
    switch (typeOfSerach) {
        case "caseSenstive": {
            for (var i = 0; i < words.length; i++) {
                if (words[i] == wordToFind) {
                    counter++;
                }
            }
        }; break;
        case "caseInsenstive": {
            for (var i = 0; i < words.length; i++) {
                if (words[i].toLowerCase() == wordToFind.toLowerCase()) {
                    counter++;
                }
            }
        }; break;
    }
    alert(counter);
}