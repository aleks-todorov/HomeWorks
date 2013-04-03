//Task 6: 
//Write a function that groups an array of persons by age, first or last name. The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups
//Use function overloading (i.e. just one function)
//var persons = {…};
//var groupedByFname = group(persons,"firstname");
//var groupedByAge= group(persons,"age");


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
    createPerson("Jack", "Bone", 10),
    createPerson("Jack", "Bone", 12),
    createPerson("Jack", "Bone", 15),
    createPerson("Johny", "Bone", 15),
    createPerson("Tim", "Bone", 15),
    createPerson("Ben", "Bone", 15),
    createPerson("Jimmy", "Smith", 15),
    createPerson("Jack", "Doe", 15)];

//Grouping people by Age and printing the result
var groupedByAge = groupPeople(personArray, "age");
consoleLog(groupedByAge);
//Grouping people by First Name and printing the result
var groupedByFirstName = groupPeople(personArray, "firstName");
//consoleLog(groupedByFirstName);
//Grouping people by Last Name and printing the result
var groupedByLastName = groupPeople(personArray, "lastName");
//consoleLog(groupedByLastName);

//Function for displaying results 
function consoleLog(groupedArray) {
    for (var i in groupedArray) {
        console.log(groupedArray[i].toString())
    }
}
//Grouping People
function groupPeople(personArray, criteria) {
    var groupedArray = [];
    var hasMatch = false;
    switch (criteria) {
        case "age": {
            for (var i in personArray) {
                for (var j = 0; j < personArray.length && i != j; j++) {
                    if (personArray[i].Age == personArray[j].Age) {
                        hasMatch = true;
                        break;
                    }
                }
                if (hasMatch == true) {
                    groupedArray.push(personArray[i]);
                }
            }; break;
        }
        case "firstName": {
            for (var i in personArray) {
                for (var j = 0; j < personArray.length && i != j; j++) {
                    if (personArray[i].FirstName === personArray[j].FirstName) {
                        groupedArray.push(personArray[i]);
                        break;
                    }
                }
            }; break;
        }
        case "lastName": {
            for (var i in personArray) {
                for (var j = 0; j < personArray.length && i != j; j++) {
                    if (personArray[i].LastName === personArray[j].LastName) {
                        groupedArray.push(personArray[i]);
                        break;
                    }
                }
            }; break;
        }
    }
    return groupedArray;
}
