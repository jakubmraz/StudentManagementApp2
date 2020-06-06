using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp2UWP.Model;

namespace StudentManagementApp2UWP.ViewModel
{
    class RegistrationViewModel
    {
        private string _username;
        private string _password;
        private RegistrationCatalogSingleton _regs;

        public RegistrationViewModel()
        {
            Username = _username;
            Password = _password;
            _regs = RegistrationCatalogSingleton.Instance;

        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public RegistrationCatalogSingleton Regs
        {
            get { return _regs; }
            set { _regs = value; }
        }

        public bool LogIn()
        {
            if (Regs.ReCheck(Username, Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LogInUser()
        {
            if (Regs.Check(Username, Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}
