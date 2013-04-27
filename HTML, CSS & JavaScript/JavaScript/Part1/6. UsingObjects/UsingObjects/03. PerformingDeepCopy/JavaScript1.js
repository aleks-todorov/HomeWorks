//Task 3: 
//Write a function that makes a deep copy of an object
//The function should work for both primitive and reference types

function clone(obj) {
    if (obj == null || typeof (obj) != 'object')
        return obj;
    var temp = new obj.constructor();
    for (var key in obj)
        temp[key] = clone(obj[key]);
    return temp;
}

var personOne = {
    Name: "John",
    Age: 15,
    Sex: "Male"
}

var personTwo = clone(personOne);

personOne.Name = "Mike";
//The new object does not change its Name. 
for (var i in personTwo) {
    console.log(personTwo[i]);
}

//PS: this method will not work for DateTime objects for example. 
//But for the purpose of this excersies I think it is good enough.