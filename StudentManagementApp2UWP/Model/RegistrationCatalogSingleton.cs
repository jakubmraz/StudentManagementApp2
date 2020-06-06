using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Diagnostics;
using StudentManagementApp2UWP.Percistency;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Model
{
    class RegistrationCatalogSingleton : INotifyPropertyChanged
    {
        ObservableCollection<Registration> registrations = new ObservableCollection<Registration>();

        private ObservableCollection<Registration> _registrations;


        private static string _url = "api/Admins/";
        private static string U_url = "api/Users";

        private RegistrationCatalogSingleton()
        {
            _registrations = new ObservableCollection<Registration>();
            currentlogin = new Registration();
            //_registrations.Add(new Registration(){Username = "admin", Password = "password"});
            _registrations = GetAllUsers();
        }

        public ObservableCollection<Registration> GetAllUsers()
        {
            return _registrations;
        }

        public Registration currentlogin { get; set; }


        private static RegistrationCatalogSingleton _Instance;

        public static RegistrationCatalogSingleton Instance
        {
            get { return _Instance ?? (_Instance = new RegistrationCatalogSingleton()); }
        }

        public bool ReCheck(string username, string password)
        {
            StudentWebAPIAsync<Admin> regApiAsync = new StudentWebAPIAsync<Admin>(_url);
           
            bool status = false;
            foreach (var r in regApiAsync.GetAll())
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
