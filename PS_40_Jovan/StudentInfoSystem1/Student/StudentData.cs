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
            testStudents.Add(new Student("Martin", "Atanasov","Marinov", "FKST", "KSI", "Bachelor", "Active",  123218021, 3, 9, 32));
            testStudents.Add(new Student("Ivana", "Kirilova", "Dimitrova", "UTM", "Medicine", "Bachelor", "Active", 123218040, 2, 24, 05));

        }


    }
}