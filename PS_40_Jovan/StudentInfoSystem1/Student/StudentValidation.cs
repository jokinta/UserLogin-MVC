using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using UserLogin1;

namespace StudentInfoSystem1
{
    public class StudentValidation
    {
        public StudentValidation()
        {
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
        }
        public Student GetStudentDataByUser(User user)
        {
            StudentInfoContext context = new StudentInfoContext(); 
            Student returnStudent =
                (from stud in context.Students
                 where stud.FakNomer == user.FakNomer
                 select stud).FirstOrDefault();

            if (returnStudent == null)
            {
                Logger.LogActivity("No student found,", null);
                return null;
            } else 
            {
                return returnStudent;
            }

            
        }
        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }

    }
}