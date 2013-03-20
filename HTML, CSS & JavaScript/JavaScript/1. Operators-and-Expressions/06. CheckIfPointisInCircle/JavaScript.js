//Write an expression that checks if given print (x,  y) is within a circle K(O, 5).

function CheckIfInCircle() {
    var possitionX = document.getElementById("possitionX").value;
    var possitionY = document.getElementById("possitionY").value;
    if ((possitionX <= 5 && possitionX >= -5) && (possitionY <= 5 && possitionY >= -5)) {
        alert("Point is NOT in Circle with center 0 and radius 5");
    }
    else {
        alert("Point is NOT inCircle with center 0 and radius 5");
    }
}
