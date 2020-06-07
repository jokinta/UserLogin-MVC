using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Reflection.Emit;

namespace UserLogin1
{
    public static class UserData
    {
        private static List<User> testUsers = new List<User>();
        public static List<User> TestUsers
        {
            get { ResetTestUserData();
                return testUsers;
            }
            set { }
        }

        public static void SetUserActiveTo (string username, DateTime newDate)
        {
            
            
            UserContext context = new UserContext();
            User user =
                (from us in context.Users
                 where us.UserName == username
                 select us).First();
            if (user != null)
            {
                user.ActiveTime = newDate;
                Logger.LogActivity("Changed active date successfully", user.UserName);
            }
             else
            {
                Logger.LogActivity("Change of active date unsuccessfully", user.UserName);
            }

        }

        public static void AssignUserRole (string username, UserRoles newRole)
        {
           
            UserContext context = new UserContext();
            User user =
                (from us in context.Users
                 where us.UserName == username
                 select us).First();
            if (user != null)
            {
                user.Role = (Int32) newRole;
                Logger.LogActivity("Changed role successfully", user.UserName);
            }
            else
            {
                Logger.LogActivity("Change of active date unsuccessfully", user.UserName);
            }

        }
        public static User IsUserPassCorrect(string username, string password)
        {

          
            UserContext context = new UserContext();
            
            try
            {
                User returnUser =
               (from us in context.Users
                where us.UserName == username && us.Password == password
                select us).First();
                if (returnUser == null)
                { return null; }
                else
                {
                    return returnUser;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
           

         
        }
        static private void ResetTestUserData()
        {
            testUsers.Add(new User("jovan", "jovan123!", 123217003, 4));
            testUsers.Add(new User("igor", "igor123!", 1222505001, 4));
          
        }
    }
}
