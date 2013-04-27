// Task 4:
// Write a function that checks if a given object contains a given property
// var obj  = …;
//var hasProp = hasProperty(obj, "length");

function CheckForProperty(object, property) {
    var hasProperty = false;
    if (object.hasOwnProperty(property)) {
        return true;
    }
    return false;
}

//Creating simple object
var Person = {
    Name: "John",
    Age: 15,
    Sex: "Male"
}

//Object has property "Name", so the result is true
console.log(CheckForProperty(Person, "Name"));
//Object doesn't have property "IQ", so the result is false
console.log(CheckForProperty(Person, "IQ"));
