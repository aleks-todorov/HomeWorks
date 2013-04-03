//Task 4: 
//Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects

var minValue = new String();
var maxValue = new String();

FindMinAndMax(document);
FindMinAndMax(window);
FindMinAndMax(navigator);

function FindMinAndMax(location) {
    var isFirst = false;
    for (var i in location) {
        if (isFirst == false) {
            minValue = i;
            maxValue = i;
            isFirst = true;
        }
        else {
            if (i > maxValue) {
                maxValue = i;
            }
            if (i < minValue) {
                minValue = i;
            }
        }
    }
    PrintResult(location, minValue, maxValue);
}

function PrintResult(location, minValue, maxValue) {
    console.log("Location: " + location);
    console.log("Min Value: " + minValue);
    console.log("Max Value:" + maxValue);
}