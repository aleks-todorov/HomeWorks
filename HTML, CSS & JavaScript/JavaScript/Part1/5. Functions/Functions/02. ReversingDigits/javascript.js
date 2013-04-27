//Task 2: 
//Write a function that reverses the digits of given decimal number. Example: 256  652

function ReverseNumber() {
    var number = parseInt(document.getElementById("inputBox").value);
    var reversedNumber = "";
    while (number > 0) {
        reversedNumber += parseInt(number % 10);
        number  = parseInt(number/10);
    }
    alert(reversedNumber);
}