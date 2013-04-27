//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

function CheckThirdBit() {
    var number = document.getElementById("number").value;
    var mask = 1 << 3;
    var bit = number & mask;
    bit = bit >> 3;
    if (bit == 1) {
        alert("The third bit is 1!");
    }
    else {
        alert("The third bit is NOT 1!");
    }
}
