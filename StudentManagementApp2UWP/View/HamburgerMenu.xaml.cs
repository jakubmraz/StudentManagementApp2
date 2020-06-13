using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StudentManagementApp2UWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HamburgerMenu : Page
    {
        public HamburgerMenu()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(UserHomePage));
        }

        private void CampusesButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(CampusListPage));
            ResetFontWeights();
            CampusesButton.FontWeight = FontWeights.Bold;
        }

        private void ProgrammesButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(UserProgrammeListPage));
            ResetFontWeights();
            ProgrammesButton.FontWeight = FontWeights.Bold;
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(StudentListPage));
            ResetFontWeights();
            StudentsButton.FontWeight = FontWeights.Bold;
        }

        private void ResetFontWeights()
        {
            ProgrammesButton.FontWeight = FontWeights.Normal;
            CampusesButton.FontWeight = FontWeights.Normal;
            StudentsButton.FontWeight = FontWeights.Normal;
            AddStudentsButton.FontWeight = FontWeights.Normal;
        }

        private void AddStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(CreateStudent));
            ResetFontWeights();
            AddStudentsButton.FontWeight = FontWeights.Bold;
        }
    }
}
