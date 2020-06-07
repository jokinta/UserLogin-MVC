using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserLogin1;

namespace StudentInfoSystem1
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {

        public static User userOne = null;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lblSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            string username = txtUsername.Text;
            string password = pwdBox.Password;
            LoginValidation.ActionOnError deleg = new LoginValidation.ActionOnError(Program.printMsg);
            LoginValidation userValidation = new LoginValidation(username, password, deleg);
            userValidation.timeSpend.Start();
            while (!userValidation.ValidateUserInput(ref userOne))
            {
                if (userValidation.lockInput == true)
                {
                    MessageBox.Show("Input locked", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Stopwatch timeSpend = new Stopwatch();
                    txtUsername.Text = string.Empty;
                    pwdBox.Password = string.Empty;
                    timeSpend.Start();
                    while (timeSpend.ElapsedMilliseconds <= 5000)
                    {
                        txtUsername.IsEnabled = false;
                        pwdBox.IsEnabled = false;
                    }
                    timeSpend.Stop();
                    txtUsername.IsEnabled = true;
                    pwdBox.IsEnabled = true;
                    userValidation.lockInput = false;
                    break;
                }
                else
                {
                    var res = MessageBox.Show("Error", "Incorrect username or password", MessageBoxButton.OK, MessageBoxImage.Warning);
                    if (res == MessageBoxResult.OK)
                    {
                        txtUsername.Text = string.Empty;
                        pwdBox.Password = string.Empty;
                        break;
                    }
                }

                userValidation.UserName = txtUsername.Text;
                userValidation.Password = pwdBox.Password;

            }

            userValidation.timeSpend.Stop();
            if (userOne != null)
            {
                MessageBox.Show("Logged in", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.LogActivity("Login successfull", userOne.UserName);
                StudentValidation stdVal = new StudentValidation();
                Student stud = stdVal.GetStudentDataByUser(userOne);
                if (stud != null)
                {
                    StudentDataOutput newWindow = new StudentDataOutput();
                    newWindow.DataContext = new StudentDataOutputVM() { Student = stud };
                    newWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The user is not a student", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    UserDataForm newWindow = new UserDataForm(); //TOD
                    newWindow.Show();
                    this.Close();
                }
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblCancel_Click(object sender, RoutedEventArgs e)
    {
            MessageBoxResult res = MessageBox.Show("About to exit program?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                this.Close();
            };
    }

       
        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignInForm newWindow = new SignInForm(); 
            newWindow.Show();
        }
    }
}

