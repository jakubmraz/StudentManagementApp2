using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StudentManagementApp2UWP.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StudentManagementApp2UWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProgrammeInfoPage : Page
    {//ProgrammeInfoViewModel pvm = new ProgrammeInfoViewModel();
        //For the tenth time, please stop adding this to my files, Elvis. You make it load the viewmodel twice.
        public ProgrammeInfoPage()
        {
            this.InitializeComponent();
            //this.DataContext = pvm;
        }
    }
}
