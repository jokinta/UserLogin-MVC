using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem1
{
    class StudentData
    {
        private static List<Student> testStudents = new List<Student>();
        public static List<Student> TestStudents
        {
            get
            {
                ResetTestStudentData();
                return testStudents;
            }
            set { }
        }

        static private void ResetTestStudentData()
        {
            testStudents.Add(new Student("Dimitur", "Atanasov","Kostadinov", "FKST", "KSI", "Bachelor", "Active",  122216021, 3, 9, 37));
            testStudents.Add(new Student("Ivana", "Ivanova", "Dimitrova", "UTM", "Medicine", "Bachelor", "Active", 122435232, 2, 69, 04));
            testStudents.Add(new Student("Preslava","Ratkova", "Aleksandrova", "UASG", "Architecture", "Bachelor", "Active", 122232789, 5, 3, 09));
        }


    }
}