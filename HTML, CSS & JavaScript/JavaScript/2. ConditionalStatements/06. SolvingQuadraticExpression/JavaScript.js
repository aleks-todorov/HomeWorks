//Write script that asks for a digit and depending on the input shows the 
//name of that digit (in English) using a switch statement.

function SolveQuadraticExpression() {
    var a = parseFloat(document.getElementById("a").value);
    var b = parseFloat(document.getElementById("b").value);
    var c = parseFloat(document.getElementById("c").value);
    var rootOne;
    var rootTwo;
    var D = b * b - 4 * a * c;
    var sqrtD = Math.sqrt(D);
    if (D < 0) {
        console.log("There are no real roots");
    }
    else if (D == 0) {
        rootOne = rootTwo = (-b / 2 * a);
        console.log("Root one and root two are equal to : " + rootOne);
    }
    else if (D > 0) {
        rootOne = ((-b + sqrtD) / (2 * a));
        rootTwo = ((-b - sqrtD) / (2 * a));
        console.log("Root one is " + rootOne + " and root two is " + rootTwo);
    }
    alert("Check Console");
}
