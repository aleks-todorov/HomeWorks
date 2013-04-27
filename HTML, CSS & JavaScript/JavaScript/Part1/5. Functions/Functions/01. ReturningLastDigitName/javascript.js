//Task 1: 
//Write a function that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine"

function CheckNumber() {
    var number = parseInt(document.getElementById("inputBox").value);
    CheckLastNumber(number % 10);
}

function CheckLastNumber(number) {
    switch (number) {

        case 1: alert("One"); break;
        case 2: alert("Two"); break;
        case 3: alert("Three"); break;
        case 4: alert("Four"); break;
        case 5: alert("Five"); break;
        case 6: alert("Six"); break;
        case 7: alert("Seven"); break;
        case 8: alert("Eight"); break;
        case 9: alert("Nine"); break;
        default: alert("Zero"); break;
    }
}