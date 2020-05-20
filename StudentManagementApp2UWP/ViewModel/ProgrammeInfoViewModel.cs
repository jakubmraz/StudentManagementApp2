using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentManagementApp2UWP.Common;
using StudentManagementApp2UWP.Model;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.ViewModel
{
    class ProgrammeInfoViewModel : INotifyPropertyChanged
    {
        private Programme _thisProgramme;

        private ProgrammeCatalogSingleton programmeCatalog;
        private StudentCatalogSingleton studentCatalog;

        private ObservableCollection<Student> _students;

        private Student _selectedStudent;

        private bool _listEnabled;
        private bool _popupOpen;

        public ProgrammeInfoViewModel()
        {
            programmeCatalog = ProgrammeCatalogSingleton.Instance;
            studentCatalog = StudentCatalogSingleton.Instance;
            _thisProgramme = new Programme();

            _thisProgramme = StaticObjects.StaticSelectedProgramme;
            _students = ThisProgramme.TempStudents;
            AllStudents = studentCatalog.Students;

            OpenPopupCommand = new RelayCommand(OpenPopup);
            ClosePopupCommand = new RelayCommand(ClosePopup);
            AddStudentCommand = new RelayCommand(AddStudentToProgramme);

            _selectedStudent = null;

            _listEnabled = true;
            _popupOpen = false;
        }

        public Programme ThisProgramme
        {
            get { return _thisProgramme; }
            set
            {
                _thisProgramme = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Student> AllStudents { get; }

        public ICommand OpenPopupCommand { get; set; }
        public ICommand ClosePopupCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public bool ListEnabled
        {
            get { return _listEnabled; }
            set
            {
                _listEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool PopupOpen
        {
            get { return _popupOpen; }
            set
            {
                _popupOpen = value;
                OnPropertyChanged();
            }
        }

        public void AddStudentToProgramme()
        {
            //ProgrammeCatalog.Instance.Programmes.FirstOrDefault(data => data.Programme_Id == ThisProgramme.Programme_Id).TempStudents.Add(SelectedStudent);

            ProgrammeCatalogSingleton.Instance.Programmes.FirstOrDefault(data => data.Name == ThisProgramme.Name).TempStudents
                .Add(SelectedStudent);
            ClosePopup();
            SelectedStudent = null;
            ThisProgramme = ThisProgramme; //To reload the page?
        }

        public void OpenPopup()
        {
            ListEnabled = false;
            PopupOpen = true;
        }

        public void ClosePopup()
        {
            ListEnabled = true;
            PopupOpen = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
