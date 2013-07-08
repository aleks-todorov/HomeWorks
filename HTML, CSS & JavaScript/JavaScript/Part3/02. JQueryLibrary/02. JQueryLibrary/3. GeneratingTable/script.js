/// <reference path="../jquery-1.9.1.min.js" /> 
(function () {

    var students = [
        { firstName: "Peter", lastName: "Ivanov", grade: 3 },
         { firstName: "Milena", lastName: "Grigorova", grade: 6 },
          { firstName: "Gergana", lastName: "Borisova", grade: 12 },
           { firstName: "Boyko", lastName: "Petrov", grade: 7 }
    ];

    $("<table id=\"table\"></table>").appendTo("body");
    $("<tr>" +
        "<th>First Name</th>" +
        "<th>Last Name</th>" +
        "<th>Grade</th>" +
      "</tr>").appendTo("#table");

    for (var i = 0; i < students.length; i++) {
        $("<tr>" +
       "<td>" + students[i].firstName + "</td>" +
       "<td>" + students[i].lastName + "</td>" +
       "<td>" + students[i].grade + "</td>" +
     "</tr>").appendTo("#table");
    }

})();