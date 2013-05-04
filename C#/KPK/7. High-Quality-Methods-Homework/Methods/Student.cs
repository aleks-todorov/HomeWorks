using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }
        public DateTime BirthDay { get; set; }

        public Student(string firstName, string lastName, DateTime birthDay, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.OtherInfo = otherInfo;
        }

        public bool IsOlderThan(Student secondStudent)
        {
            if (!(secondStudent is Student) || secondStudent == null)
            {
                throw new ArgumentException("Input data was not valid. Please check and provide new one! ");
            }

            var result = this.BirthDay > secondStudent.BirthDay;
            return result;
        }
    }
}
