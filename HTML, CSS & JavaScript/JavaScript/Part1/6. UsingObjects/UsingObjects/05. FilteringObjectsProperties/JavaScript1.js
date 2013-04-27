//Task 5: 
//Write a function that finds the youngest person in a given array of persons and prints his/hers full name
//Each person have properties firstname, lastname and age, as shown:
//var persons = [
//  {firstname : "Gosho", lastname: "Petrov", age: 32}, 
//  {firstname : "Bay", lastname: "Ivan", age: 81},…];

function createPerson(firstName, lastName, age) {
    return {
        FirstName: firstName,
        LastName: lastName,
        Age: age,
        toString: function toString() {
            return "First Name: " + firstName + "\nLast Name: " + lastName + "\nAge: " + age;
        }
    }
}

//Creating persons :) 
var personArray = [
    createPerson("Johny", "Walker", 15),
    createPerson("Jack", "Daniels", 25),
    createPerson("Captain", "Morgan", 10)];


//Finding youngest person possition
var youngestPersonAge = 125;
var youngestPersonPossition = 0;
for (var i in personArray) {
    if (youngestPersonAge > personArray[i].Age) {
        youngestPersonAge = personArray[i].Age;
        youngestPersonPossition = i;
    }
}

//Printing youngest person
console.log(personArray[youngestPersonPossition].toString());