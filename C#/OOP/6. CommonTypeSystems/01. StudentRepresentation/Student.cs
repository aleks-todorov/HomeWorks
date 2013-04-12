using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentRepresentation
{
    class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Course { get; set; }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }

        public Student(string firstName, string middleName, string lastName, string SSN, string address, string phoneNumber,
            string email, int course, Specialties specialty, Universities university, Faculties faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = SSN;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;

            //Comaparing Students only based on few parameters
            if (student == null)
            {
                return false;
            }

            if (!Object.Equals(this.FirstName, student.FirstName))
            {
                return false;
            }

            if (!Object.Equals(this.LastName, student.LastName))
            {
                return false;
            }

            if (!Object.Equals(this.SSN, student.SSN))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Student:");
            sb.AppendLine("FirstName: " + this.FirstName);
            sb.AppendLine("LastName: " + this.LastName);
            sb.AppendLine("SSN: " + this.SSN);
            sb.AppendLine("Email " + this.Email);
            sb.AppendLine("PhoneNumber " + this.PhoneNumber.ToString());
            sb.AppendLine("University " + this.University.ToString());
            sb.AppendLine("Specialty " + this.Specialty.ToString());
            sb.AppendLine("Course: " + this.Course.ToString());
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ MiddleName.GetHashCode() ^ SSN.GetHashCode();
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return Student.Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !(Student.Equals(firstStudent, secondStudent));
        }

        //Task 2: Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.

        internal Student Clone()
        {
            var studentCloned = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.PhoneNumber, this.Email, this.Course, this.Specialty, this.University, this.Faculty);
            return studentCloned;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            {
                return (String.Compare(this.FirstName, student.FirstName));
            }
            if (this.LastName != student.LastName)
            {
                return (String.Compare(this.LastName, student.LastName));
            }
            if (this.SSN != student.SSN)
            {
                return (String.Compare(this.SSN, student.SSN));
            }
            return 0;
        }
    }
}
