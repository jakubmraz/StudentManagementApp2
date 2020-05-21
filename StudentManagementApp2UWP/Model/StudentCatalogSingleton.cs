using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Model
{
    class StudentCatalogSingleton
    {


        StudentManagementDBAccess<Student> studentAPIAsync = new StudentManagementDBAccess<Student>("https://localhost:44366/", "api/Students");


        private int _count;
        private ObservableCollection<Student> _students;


        private StudentCatalogSingleton()
        {
            _students = new ObservableCollection<Student>();

            _students.Add((new Student()
            {
                Student_Id = 1,
                Name = "Dominik",
                Email = "dominik000@edu.eadj.dk",
                Background = "Technical It-school"
            }));
            _students = GetStudent();
        }

        public ObservableCollection<Student> GetStudent()
        {
            //return new ObservableCollection<Student>(studentAPIAsync.GetAll().Result);
            return _students;
        }

        public int Counting
        {
            get { return _students.Count; }
        }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
        }

        public void NewStudent(Student st)
        {
            studentAPIAsync.CreateNew(st);
            _students.Add(st);
        }


        public void RemoveStudent(int id)
        {
            studentAPIAsync.DeleteObject(id);
            _students.Remove(Students.FirstOrDefault(s => s.Student_Id == id));

        }




        private static StudentCatalogSingleton _Instance;

        public static StudentCatalogSingleton Instance
        {
            get { return _Instance ?? (_Instance = new StudentCatalogSingleton()); }
        }

        public static StudentCatalogSingleton Student { get; internal set; }

    }
}

