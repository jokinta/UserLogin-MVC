using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UserLogin1;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem1
{
    /// <summary>
    /// Interaction logic for StudentDataOutput.xaml
    /// </summary>
    public partial class StudentDataOutput : Window
    {
        public List<string> StudStatusChoices { get; set; }

        public StudentDataOutput()
        {
            InitializeComponent();
            //FillStudStatusChoices();
            DataContext = this;

        }
        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
        
        /*
        public bool TestUsersIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
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

        public void CopyTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (User usr in UserData.TestUsers)
            {
                context.Users.Add(usr);
            }
            context.SaveChanges();
        }
        */

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            StudentValidation stdVal = new StudentValidation();
            Student stud = stdVal.GetStudentDataByUser(LoginForm.userOne);

            txtFirstName.Text = stud.FirstName;
            txtMiddleName.Text = stud.MiddleName;
            txtLastName.Text = stud.LastName;
            txtGroup.Text = stud.GroupId.ToString();
            txtPotok.Text = stud.Potok.ToString();
            txtProg.Text = stud.ProgrammType;
            txtSpec.Text = stud.Specialty;
            txtYear.Text = stud.Year.ToString();
            txtStat.Text = stud.Status;
            txtFac.Text = stud.Faculty;
            txtFakN.Text = stud.FakNomer.ToString();

        }
        


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
             
            }
        }


        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
