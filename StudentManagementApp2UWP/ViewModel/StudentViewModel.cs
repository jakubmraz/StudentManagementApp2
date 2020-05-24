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
    class StudentViewModel : INotifyPropertyChanged
    {
        // ´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´Create, Select and Delete Students´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´

        public StudentCatalogSingleton studentCatalogSingleton { get; set; }

        public int Student_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Background { get; set; }


        private ICommand _createStudentCommand;
        public ICommand CreateStudentCommand
        {
            get { return _createStudentCommand; }
            set
            {
                _createStudentCommand = value;
                //OnPropertyChanged(nameof(AddStudent));
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        private ICommand _deleteStudentCommand;
        public ICommand DeleteStudentCommand
        {
            get { return _deleteStudentCommand; }
            set
            {
                _deleteStudentCommand = value;
                OnPropertyChanged(nameof(SelectedStudent));
                //OnPropertyChanged(nameof(Count));

            }
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }
        public void DeleteStudent()
        {
            int id = SelectedStudent.Student_Id;
            studentCatalogSingleton.RemoveStudent(id);
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(SelectedStudent));
        }

        public int Count
        {
            get { return studentCatalogSingleton.Counting; }
        }

        //private ICommand _searchStudentText;
        //public ICommand SearchStudentText
        //{
        //    get
        //    {
        //        return _searchStudentText;
        //    }
        //    set
        //    {
        //        _searchStudentText = value;
        //        OnPropertyChanged();
        //    }
        //}

        //'''''''''''''''''''''''''''''''''''''''''''' CTOR ''''''''''''''''''''''''''''''
        public StudentViewModel()
        {
            studentCatalogSingleton = StudentCatalogSingleton.Instance;
            _createStudentCommand = new RelayCommand(AddStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            _selectedStudent = new Student();
        }

        //'''''''''''''''''''''''''''''''''''''''''''' AddStudent Method incl. fields ''''''''''''''''''''''''''''''
        public void AddStudent()
        {
            Student sp = new Student();
            sp.Student_Id = Student_Id;
            sp.Name = Name;
            sp.Email = Email;
            sp.Background = Background;

            studentCatalogSingleton.NewStudent(sp);
            OnPropertyChanged(nameof(Count));
        }


        //'''''''''''''''''''''''''''''''''''''''''''' CODE FOR SEARCH STUDENTS ''''''''''''''''''''''''''''''''''''''''''''
        private string _searchByName;

        public string Search_By_Name
        {
            get { return _searchByName; }
            set
            {
                _searchByName = value;
                OnPropertyChanged(nameof(FilteredStudents));
            }
        }

        public ObservableCollection<Student> FilteredStudents
        {
            get
            {
                var filteredstudents = new ObservableCollection<Student>();
                ObservableCollection<Student> myList = studentCatalogSingleton.GetStudent();

                foreach (var st in myList)
                {
                    // if the search box is not empty ,  get all students from catalog and try to search based on the first name 
                    if (Search_By_Name != string.Empty && Search_By_Name != null)
                    {
                        if (!st.Name.ToLower().Trim().StartsWith(Search_By_Name.ToLower().Trim()))
                        {
                            // if the name does not fit continue
                            continue;
                        }
                        // else AddingNewEventArgs the name to the list
                        filteredstudents.Add(st);
                    }
                    // otherwise , if the searchbox is empty , get data from the singleton catalog
                    else
                    {
                        filteredstudents = studentCatalogSingleton.GetStudent();
                    }
                }
                return filteredstudents;
            }

        }
        


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
