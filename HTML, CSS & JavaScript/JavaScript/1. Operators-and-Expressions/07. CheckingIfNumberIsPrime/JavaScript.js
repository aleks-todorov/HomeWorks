//Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

function CheckIfPrime() {
    var number = document.getElementById("number").value;
    if (number <= 100 && number >= 0) {
        if (number % 2 != 0 && number % 3 != 0 && number % 5 != 0 && number % 7 != 0) {
            alert("Number is PRIME!");
        }
        else {
            alert("Number is Not PRIME!");
        }
    }
    else
        alert("Please use number between 0 and 100!");
}
