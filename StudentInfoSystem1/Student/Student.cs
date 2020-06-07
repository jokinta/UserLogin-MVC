using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem1
{
    public class Student
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string faculty;
        private string specialty;
        private string programmType;
        private string status;
        private int fakNomer;
        private int year;
        private int? potok;
        private int groupId;
        public int StudentId { get; set; }

        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Faculty { get => faculty; set => faculty = value; }
        public string Specialty { get => specialty; set => specialty = value; }
        public string ProgrammType { get => programmType; set => programmType = value; }
        public string Status { get => status; set => status = value; }
        public int FakNomer { get => fakNomer; set => fakNomer = value; }
        public int Year { get => year; set => year = value; }
        public int? Potok { get => potok; set => potok = value; }
        public int GroupId { get => groupId; set => groupId = value; }

        public Student(string firstName, string middleName, string lastName, string faculty, string specialty, string programmType,
            string status, int fakNomer, int year, int potok, int groupId)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.specialty = specialty;
            this.programmType = programmType;
            this.status = status;
            this.fakNomer = fakNomer;
            this.year = year;
            this.potok = potok;
            this.groupId = groupId;

        }

        public Student()
        {

        }


    }
}