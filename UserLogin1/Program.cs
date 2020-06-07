using System;
using System.IO;

namespace UserLogin1
{
    
    public class Program
    {
        

        public static void printMsg (string errorMsg)
        {
            Console.WriteLine("!" + errorMsg + "!");
        }
        static void Main(string[] args)
        {


            string userName;
            string password;
            int option;
            User userOne = null;
            string[] menu = {"MENU", "Choose an option:", "0: Exit.",
                    "1: Change of the role of the user.", "2: Change the activity date of the user.",
                "3: List users.", "4: See all log activities", "5: See curent log activities"};

            Console.WriteLine("Enter your username:");
            userName = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();

            LoginValidation.ActionOnError deleg = new LoginValidation.ActionOnError(printMsg);
            LoginValidation userValidation = new LoginValidation(userName, password, deleg);
            userValidation.timeSpend.Start();
            
            while (!userValidation.ValidateUserInput(ref userOne))
            {

                if (userValidation.IncorrectUsrPwd > 2 || userValidation.ShortInputCnt > 2)
                {
                    break;
                }

                Console.WriteLine("Enter your username:");
                userName = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                password = Console.ReadLine();
                userValidation.UserName = userName;
                userValidation.Password = password;

            
            }
            userValidation.timeSpend.Stop();
            if (userOne != null)
            {
                string usrname;
                int role;
                DateTime newDate;
                Console.WriteLine("username {0}, password {1}, and role {2}. !LOGGED SUCCESSFULLY!", 
                    userOne.UserName, userOne.Password, userOne.Role);
                foreach (string str in menu)
                {
                    Console.WriteLine(str + "\n");
                }
                option = Convert.ToInt32(Console.ReadLine());
                switch (option) 
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Enter username and role:");
                        usrname = Console.ReadLine();
                        role = Convert.ToInt32(Console.ReadLine());
                        UserData.AssignUserRole(usrname, (UserRoles)role);
                        break;
                    case 2:
                        Console.WriteLine("Enter username and date:");
                        usrname = Console.ReadLine();
                        newDate = Convert.ToDateTime(Console.ReadLine());
                        UserData.SetUserActiveTo(usrname, newDate);
                        break;
                    case 3:
                        foreach (var usr in UserData.TestUsers)
                        {
                            Console.WriteLine(usr.UserName + " - " + usr.FakNomer + " - " + usr.Created + " - " + usr.ActiveTime);
                        }
                        break;
                    case 4:
                        Logger.DisplayLog();
                        break;
                    case 5:
                        Logger.GetCurrentSessionActivities();
                        break;

                }
            } else
            {
                Console.WriteLine(userValidation.ErrorMessage);
            }
            switch (LoginValidation.CurrentUserRole)
            {
                case 0:
                    Console.WriteLine("Anonymous");
                    break;

                case (UserLogin1.UserRoles)1:
                    Console.WriteLine("Admin");
                    break;
                case (UserLogin1.UserRoles)2:
                    Console.WriteLine("Inspector");
                    break;
                case (UserLogin1.UserRoles)3:
                    Console.WriteLine("Professor");
                    break;
                case (UserLogin1.UserRoles)4:
                    Console.WriteLine("Student");
                    break;

            }

            /*string dateFromConsole;
            dateFromConsole = Console.ReadLine();
            DateTime temp = Convert.ToDateTime(dateFromConsole);
            Console.WriteLine("Date -> " + temp); */

        }
    
        
    }
    
}
