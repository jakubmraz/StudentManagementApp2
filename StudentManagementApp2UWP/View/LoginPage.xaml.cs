using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StudentManagementApp2UWP.View;
using StudentManagementApp2UWP.ViewModel;
using MenuBar = StudentManagementApp2UWP.View.MenuBar;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudentManagementApp2UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        RegistrationViewModel registration = new RegistrationViewModel();
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = registration;
        }
        
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (registration.LogIn())
            {
                Frame.Navigate(typeof(MenuBar));
            }
            else if (registration.LogInUser())
            {
                Frame.Navigate(typeof(HamburgerMenu));
            }
            else 
            {
                var message = new MessageDialog("Your username or password is incorrect \nPlease Try again 😊 ", 
                    "Fail Login");
                message.ShowAsync();
            }
        }
    }
}
