using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
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
        private StudentProgrammeSingleton studentProgrammeSingleton;

        private ConnectStudentsAndProgrammes connectStudentsAndProgrammes = new ConnectStudentsAndProgrammes();

        private ObservableCollection<Student> _students;
        private ObservableCollection<Student> _allStudents;

        private Student _selectedStudent;

        private bool _listEnabled;
        private bool _popupOpen;

        public ProgrammeInfoViewModel()
        {
            connectStudentsAndProgrammes.LoadStudentsFromDB();

            programmeCatalog = ProgrammeCatalogSingleton.Instance;
            studentCatalog = StudentCatalogSingleton.Instance;
            studentProgrammeSingleton = StudentProgrammeSingleton.Instance;
            
            _thisProgramme = new Programme();

            _thisProgramme = StaticObjects.StaticSelectedProgramme;
            _students = new ObservableCollection<Student>(ThisProgramme.Students);

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

        public ObservableCollection<Student> AllStudents
        {
            get
            {
                _allStudents = studentCatalog.Students;
                foreach (var student in ThisProgramme.Students)
                {
                    _allStudents.Remove(student);
                }

                return _allStudents;
            }
        }

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

            //ProgrammeCatalogSingleton.Instance.Programmes.FirstOrDefault(data => data.Name == ThisProgramme.Name).Students
                //.Add(SelectedStudent);
            //ProgrammeCatalogSingleton.Instance.Programmes.Remove(ThisProgramme);
            //ThisProgramme.TempStudents.Add(SelectedStudent);
            //ProgrammeCatalogSingleton.Instance.Programmes.Add(ThisProgramme);
            studentProgrammeSingleton.AddStudentToProgramme(ThisProgramme, SelectedStudent);
            connectStudentsAndProgrammes.LoadStudentsFromDB();

            ClosePopup();
            SelectedStudent = null;

            //ThisProgramme = ThisProgramme; //To reload the page? NOPE, find a different way
            //Students = new ObservableCollection<Student>(ThisProgramme.Students);
            ThisProgramme =
                programmeCatalog.Programmes.FirstOrDefault(data => data.Programme_Id == ThisProgramme.Programme_Id);
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
