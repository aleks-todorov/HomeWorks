//Write an expression that checks for given point (x, y) if it is within the 
//circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

function CheckIfInCircle() {
    var possitionX = document.getElementById("possitionX").value;
    var possitionY = document.getElementById("possitionY").value;
    if ((possitionX <= 4 && possitionX >= -2) && (possitionY <= 4 && possitionY >= -2)) {
        if ((possitionX <= 5 && possitionX >= -1) && (possitionY <= 1 && possitionY >= -1)) {
            alert("Point is in Circle with center (1,1) and radius 3 and in Rectangle");
        }
        else {
            alert("Point is in Circle with center (1,1) and radius 3 and NOT in Rectangle");
        }
    }
    else {
        alert("Point is NOT in Circle with center (1,1) and radius 3");
    }
}
