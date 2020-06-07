using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Linq;

namespace UserLogin1
{
    public class LoginValidation
    {

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = ""; }
        }
        private static int _shortInputCnt;
        public int ShortInputCnt
        {
            get { return _shortInputCnt; }
            set { _shortInputCnt = value; }
        }
        private static int _incorrectUsrPwd;
        public int IncorrectUsrPwd
        {
            get { return _incorrectUsrPwd; }
            set { _incorrectUsrPwd = value; }
        }

        public Stopwatch timeSpend = new Stopwatch ();
        public ActionOnError errorFunc;

        public LoginValidation (string userName, string password, ActionOnError errorFunc)
        {
            UserName = userName;
            Password = password;
            this.errorFunc = errorFunc;
            if (TestUsersIfEmpty())
            {
                CopyTestUsers();
            }
        }

        private bool TestUsersIfEmpty()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            if (countUsers == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CopyTestUsers()
        {
            UserContext context = new UserContext();

            foreach (User usr in UserData.TestUsers)
            {
                context.Users.Add(usr);
            }
            context.SaveChanges();
        }
        public static UserRoles CurrentUserRole 
        {
            get;
            private set;
        }

        public delegate void ActionOnError(string errorMsg);

        public void resetUsrPwdCounter ()
        {
            IncorrectUsrPwd = 0;
            ShortInputCnt = 0;
        }
        public Boolean lockInput;
        
        public void errMessage(string errMsg)
        {
            ErrorMessage = errMsg;
        }
        public bool ValidateUserInput(ref User user)
        {  
            Boolean emptyUserName;
            emptyUserName = UserName.Equals(String.Empty);
            Boolean emptyPassword;
            emptyPassword = Password.Equals(String.Empty);
            Boolean flag = false;
            if (emptyUserName == true || emptyPassword == true)
            {
                ShortInputCnt++;
                errMessage("ERROR. Username or password not entered");
                errorFunc(ErrorMessage);
                flag = true;
            } else if (UserName.Length < 5 || Password.Length < 5)
            {
                ShortInputCnt++;
                errMessage("ERROR. Username or password length less than 5 characters");
                errorFunc(ErrorMessage);
                flag = true;
            }   
                if ((ShortInputCnt >= 3 || IncorrectUsrPwd >= 3) && (timeSpend.ElapsedMilliseconds < 120000))
                {
                    errMessage("ERROR. Short username or password more than 3 times in 2 min");
                    errorFunc(ErrorMessage);
                    Logger.LogActivity(ErrorMessage, UserName);
                    resetUsrPwdCounter();
                    lockInput = true;
                    return false;
                } 

            if (Password.Length > 4 && UserName.Length > 4)
            {
                ShortInputCnt = 0;
            }
           
            if (!flag)
            {
                if (UserData.IsUserPassCorrect(UserName, Password) == null)
                {
                    IncorrectUsrPwd++;
                    if (IncorrectUsrPwd >= 3)
                    {
                        lockInput = true;
                        IncorrectUsrPwd = 0;
                    }
                    errMessage("ERROR. Username or password not correct.");
                    errorFunc(ErrorMessage);
                    Logger.LogActivity(ErrorMessage, UserName);
                    return false;
                }
                
                else
                {
                    user = UserData.IsUserPassCorrect(UserName, Password);
                    resetUsrPwdCounter();
                }
            } else
            {
                return false;
            }

            CurrentUserRole = (UserRoles)user.Role;
            return true;
        }

    }
}
