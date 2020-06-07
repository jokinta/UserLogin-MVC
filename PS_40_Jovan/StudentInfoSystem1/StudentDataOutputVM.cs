using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;

namespace StudentInfoSystem1
{
    class StudentDataOutputVM : INotifyPropertyChanged
    {
        private ICommand disableCommand;
        private ICommand clearCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        

        public ICommand DisableCommand
        {
            get { return disableCommand; }
        }

        public ICommand ClearCommand
        {
            get { return clearCommand; }
        }
       

        private Student student = null;
        public Student Student
        {
            get { return student; }
            set
            {
                student = value;
                PropChanged("Student");
                if (student == null)
                {
                
                }
                else
                {

                }
            }
        }


        private bool formEnabled = true;

        public bool FormEnabled
        {
            get { return formEnabled; }
            set { formEnabled = value; PropChanged("FormEnabled"); }
        }

        public StudentDataOutputVM()
        {
            disableCommand = new RelayCommand(_ => FormEnabled = !FormEnabled);
            clearCommand = new RelayCommand(_ => Student = null, param => FormEnabled);
        }

        

        protected virtual void PropChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
