var SchoolNS = (function () {

    var School = Class.create({
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
    });

    var SchoolClass = Class.create({
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
            //This way for obtaining fName and lName are not the best, but at the moment I cannot think of other ...
            result += "Form Teacher: " + this.formTeacher._super.fName + " " + this.formTeacher._super.lName + "\n";
            result += "Students Count: " + this.studentCount;
            return result;
        }
    });

    var Person = Class.create({
        init: function (fName, lName, age) {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
        },

        introduce: function () {
            var result = "Name: " + this.fName + " " + this.lName + ", Age: " + this.age + ", ";
            return result;
        }
    });

    var Teacher = Class.create({
        init: function (fName, lName, age, speciality) {
            this._super.init(fName, lName, age);
            this.speciality = speciality;
        },

        introduce: function () {
            return "Teacher's " + this._super.introduce() + "Speciality: " + this.speciality;
        }
    });

    Teacher.inherit(Person);

    var Student = Class.create({
        init: function (fName, lName, age, grade) {
            this._super.init(fName, lName, age);
            this.grade = grade;
        },

        introduce: function () {
            return "Student's " + this._super.introduce() + "Grade: " + this.grade;
        }
    });

    Student.inherit(Person);

    return {
        School: School,
        SchoolClass: SchoolClass,
        Teacher: Teacher,
        Student: Student
    }; 
})();