using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UserLogin1;

namespace StudentInfoSystem1
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {
        List<string> rolesCollection = new List<string>();
        public SignInForm()
        {
            try
            {
                InitializeComponent();
                populateComboBox();
            } catch (System.StackOverflowException e)
            {
                e.ToString();
            }
        }

        public void populateComboBox()
        {
            rolesCollection.Add("ANONYMOUS");
            rolesCollection.Add("INSPECTOR");
            rolesCollection.Add("PROFESSOR");
            cmbRoleList.ItemsSource = rolesCollection;
        }
        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lblSubmit_Click(object sender, RoutedEventArgs e)
        {
            Boolean flag = false;
            UserContext context = new UserContext();
            String username = txtUsername.Text;
            String originalPassword = pwdBox.Password;
            String repeatedPassword = pwdRepeatBox.Password;
            int faknomer;
            bool parseResult = int.TryParse(txtFaknomer.Text, out faknomer);
            if (!parseResult)
            {
                flag = true;
                MessageBox.Show("Fak.nomer must contain just numbers", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (txtFaknomer.Text.Length < 9 || txtFaknomer.Text.Length > 9)
            {
                flag = true;
                MessageBox.Show("Fak.nomer must contain exactly 9 digits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            int role = cmbRoleList.SelectedIndex + 1;

            if (username.Equals(String.Empty) || originalPassword.Equals(String.Empty) ||
                   faknomer.Equals(String.Empty) || role == 0)
            {
                 flag = true;
                MessageBox.Show("NO EMPTY FIELDS", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!flag)
            {
                if (originalPassword.Length < 4)
                {
                    MessageBox.Show("Password must be more than 4 characters", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                if (username.Length < 4)
                {
                    MessageBox.Show("Username must be more than 4 characters", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                if (!originalPassword.Equals(repeatedPassword))
                {
                    MessageBox.Show("Password must be equal!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                
                    User returnStudent =
                    (from usr in context.Users
                     where usr.FakNomer == faknomer
                     select usr).FirstOrDefault();
                    if (returnStudent == null)
                    {
                        User newUser = new User(username, originalPassword, faknomer, role);
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        Logger.LogActivitySignForm("User successfully created", username, cmbRoleList.SelectedItem.ToString());
                        MessageBox.Show("User successfully created!", "CREATED", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("User with same fak.nomer already exists!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }

        }

        private void lblCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
