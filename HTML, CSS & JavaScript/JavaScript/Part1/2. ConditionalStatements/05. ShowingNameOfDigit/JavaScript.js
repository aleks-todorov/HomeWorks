//Write script that asks for a digit and depending on the input shows the 
//name of that digit (in English) using a switch statement.

function ShowName() {
    var number = parseInt(document.getElementById("number").value);
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
        case 0: alert("Zero"); break;
        default: alert("Please enter valid digit"); break;
    }
}
