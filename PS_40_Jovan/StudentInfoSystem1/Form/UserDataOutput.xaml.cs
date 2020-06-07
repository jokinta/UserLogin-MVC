using System;
using System.Windows;
using System.Linq;
using UserLogin1;

namespace StudentInfoSystem1
{
    /// <summary>
    /// Interaction logic for UserDataForm.xaml
    /// </summary>
    public partial class UserDataOutput : Window
    {
        
        public UserDataOutput()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void lblExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
  
        
    }
}
