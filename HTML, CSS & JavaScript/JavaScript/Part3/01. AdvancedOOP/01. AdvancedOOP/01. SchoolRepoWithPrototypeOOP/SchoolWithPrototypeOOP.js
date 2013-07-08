var SchoolNS = (function () {

    var School = {
        init: function (name, town) {
            this.name = name;
            this.town = town;
            this.classes = [];
        },

        addClass: function (schoolClass) {
            this.classes.push(schoolClass);
        },

        toString: function () {
            var result = this.name + " school in " + this.town + " city. Classes: ";
            for (var schoolClass in this.classes) {
                result += this.classes[schoolClass].name + " ";
            }
            return result;
        }
    };

    var SchoolClass = {
        init: function (name, capacity, formTeacher) {
            this.name = name;
            this.capacity = capacity;
            this.formTeacher = formTeacher;
            this.students = [];
            this.studentCount = 0;
        },
        addStudents: function (student) {
            if (this.studentCount == this.capacity) {
                throw new RangeException("Adding students is no longer possible");
            }

            this.students.push(student);
            this.studentCount++;
        },
        toString: function () {
            var result = "Class: " + this.name + "\n";
            result += "Form Teacher: " + this.formTeacher.fName + " " + this.formTeacher.lName + "\n";
            result += "Students Count: " + this.studentCount;
            return result;
        }
    };

    var Person = {
        init: function (fName, lName, age) {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
        },

        introduce: function () {
            var result = "Name: " + this.fName + " " + this.lName + ", Age: " + this.age + ", ";
            return result;
        }
    };

    var Teacher = Person.extend({
        init: function (fName, lName, age, speciality) {
            Person.init.apply(this, arguments);
            this.speciality = speciality;
        },

        introduce: function () {
            return "Teacher's " + Person.introduce.apply(this) + "Speciality: " + this.speciality;
        }
    });

    var Student = Person.extend({
        init: function (fName, lName, age, grade) {
            Person.init.apply(this, arguments);
            this.grade = grade;
        },

        introduce: function () {
            return "Student's " + Person.introduce.apply(this) + "Grade: " + this.grade;
        }
    });

    return {
        School: School,
        SchoolClass: SchoolClass,
        Teacher: Teacher,
        Student: Student
    }
})();