//Write an expression that calculates rectangle’s area by given width and height.

function CalculateArea() {
    var width = document.getElementById("width").value;
    var height = document.getElementById("height").value;
    var area = width * height;
    alert("The Area is: " + area);
}