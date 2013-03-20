//Write an expression that calculates trapezoid's area by given sides a and b and height h.

function CalculateArea() {
    var sideA = parseInt(document.getElementById("sideA").value);
    var sideB = parseInt(document.getElementById("sideB").value);
    var height = document.getElementById("height").value;
    var area = ((sideA + sideB) / 2) * height;
    alert("The Area of the trapezoit is: " + area);
}
