using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using StudentManagementApp2UWP.Percistency;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Model
{
    class StudentCatalogSingleton : INotifyPropertyChanged
    {

        private static string _url = "api/Students/";
        private int _count;
        private ObservableCollection<Student> _students;


        private StudentCatalogSingleton()
        {
            _students = new ObservableCollection<Student>();
            _students = GetStudent();
        }

        private static StudentCatalogSingleton _Instance;
        public static StudentCatalogSingleton Instance
        {
            get { return _Instance ?? (_Instance = new StudentCatalogSingleton()); }
        }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
        }

        public ObservableCollection<Student> GetStudent()
        {
            StudentManagementDBAccess<Student> gStudentsAsync = new StudentManagementDBAccess<Student>(_url);
            List<Student> sList = gStudentsAsync.GetAll().Result;
            return new ObservableCollection<Student>(sList);
        }

        public void NewStudent(Student s)
        {
            StudentWebAPIAsync<Student> newStudent = new StudentWebAPIAsync<Student>(_url);
            newStudent.CreateNewOne(s);
            _students.Add(s);
            POP();
        }

        public void RemoveStudent(int id)
        {
            StudentWebAPIAsync<Student> delStudent = new StudentWebAPIAsync<Student>(_url);
            delStudent.DeleteOne(id);
            _students.Remove(Students.FirstOrDefault(s => s.Student_Id == id));
            popDelete();
        }

        public int Counting
        {
            get { return _students.Count; }
        }
        
        public static StudentCatalogSingleton Student { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private  void POP()
        {
            var message = new MessageDialog("Student Added to the list, thank you");
            message.ShowAsync();
        }

        public void popDelete()
        {
            Student st = new Student();
            var message = new MessageDialog($"The selected student deleted" );
            message.ShowAsync(); 
        }
               
    }
}

