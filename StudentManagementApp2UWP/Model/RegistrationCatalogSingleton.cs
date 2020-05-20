using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp2UWP.Model
{
    class RegistrationCatalogSingleton : INotifyPropertyChanged
    {
        ObservableCollection<Registration> registrations = new ObservableCollection<Registration>();

        private ObservableCollection<Registration> _registrations;




        private RegistrationCatalogSingleton()
        {
            _registrations = new ObservableCollection<Registration>();
            currentlogin = new Registration();

            _registrations.Add(new Registration() { Username = "admin", Password = "password" });
            _registrations.Add(new Registration() { Username = "elvis ", Password = "password" });
            _registrations.Add(new Registration() { Username = "leon", Password = "password" });
            _registrations.Add(new Registration() { Username = "jakub", Password = "password" });
        }

        public ObservableCollection<Registration> GetAllUsers()
        {

            return _registrations;

        }

        public Registration currentlogin { get; set; }

        public void AddedUser(Registration user)
        {
            _registrations.Add(user);
        }

        private static RegistrationCatalogSingleton _Instance;

        public static RegistrationCatalogSingleton Instance
        {
            get { return _Instance ?? (_Instance = new RegistrationCatalogSingleton()); }
        }

        public ObservableCollection<Registration> allUsers
        {
            get
            {
                ObservableCollection<Registration> users = GetAllUsers();

                return new ObservableCollection<Registration>(GetAllUsers());
            }
        }


        private ObservableCollection<Registration> userCollection = new ObservableCollection<Registration>();

        public bool ReCheck(string username, string password)
        {
            bool status = false;
            foreach (var r in GetAllUsers())
            {
                if (r.Username.Equals(username) && r.Password.Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return status;
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
