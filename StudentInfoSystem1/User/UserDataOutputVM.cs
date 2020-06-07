using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin1;

namespace StudentInfoSystem1
{
    class UserDataOutputVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User user = null;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                PropChanged("User");
                if (user == null)
                {

                }
                else
                {

                }
            }
        }

        protected virtual void PropChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
