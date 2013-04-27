//Task 1:
//Write functions for working with shapes in  standard Planar coordinate system
//Points are represented by coordinates P(X, Y)
//Lines are represented by two points, marking their beginning and ending
//L(P1(X1,Y1),P2(X2,Y2))
//Calculate the distance between two points
//Check if three segment lines can form a triangle

//Creating Constructor for Points
function createPoint(possitionX, possitionY) {
    return {
        possitionX: possitionX,
        possitionY: possitionY,
        toString: function () {
            return "PossitionX: " + possitionX + " PossitionY: " + possitionY;
        }
    }
}
//Crating Constructor for Lines and introducint functions for calculating Distance
function createLine(pointOne, pointTwo) {
    return {
        pointOne: pointOne,
        pointTwo: pointTwo,
    }
}

function calculateDistance(pointOne, pointTwo) {
    var distance = (pointOne.possitionX - pointTwo.possitionX) * (pointOne.possitionX - pointTwo.possitionX) +
        (pointOne.possitionY - pointTwo.possitionY) * (pointOne.possitionY - pointTwo.possitionY);
    distance = Math.sqrt(distance);
    return distance;
}

function checkIfTriangleCanBeMade(lineOne, lineTwo, lineThree) {
    var distanceOne = calculateDistance(lineOne.pointOne, lineOne.pointTwo);
    var distanceTwo = calculateDistance(lineTwo.pointOne, lineTwo.pointTwo);
    var distanceThree = calculateDistance(lineThree.pointOne, lineThree.pointTwo);
    if (distanceOne + distanceTwo > distanceThree && distanceOne + distanceThree > distanceTwo && distanceTwo + distanceThree > distanceOne) {
        return "Forming Triangle is Possible";
    }
    else {
        return "Forming Triangle is NOT Possible";
    }
}

//Example
var pointOne = createPoint(5, 5);
var pointTwo = createPoint(10, 15);
var pointThree = createPoint(5, 15);
var lineOne = createLine(pointOne, pointTwo);
var lineTwo = createLine(pointOne, pointThree);
var lineThree = createLine(pointTwo, pointThree);
console.log("Distance between these first two dots is: " + calculateDistance(pointOne, pointTwo));
console.log(checkIfTriangleCanBeMade(lineOne, lineTwo, lineThree));