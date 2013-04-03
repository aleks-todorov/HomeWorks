//Task 2: 
//Write a JavaScript function to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

//Will show that brackets are not correct
var expression = ")(a+b)/5-d(";
//Will show that brackets are correct
//var expression = "(a+b)"
var openBracket = 0;
var closeBracket = 0;
var isFirstOppening = false;
var isLastClosing = false;
for (var index in expression) {
    if (expression[index] == '(') {
        openBracket++;
        if (openBracket == 1 && closeBracket == 0) {
            isFirstOppening = true;
        }
        isLastClosing = false;
    }
    if (expression[index] == ')') {
        closeBracket++;
        isLastClosing = true;
    }
}
if (openBracket != closeBracket || isFirstOppening == false || isLastClosing == false) {
    console.log("Brackets are NOT correct");
}
if (openBracket == closeBracket && isFirstOppening == true && isLastClosing == true) {
    console.log("Brackets are correct");
}