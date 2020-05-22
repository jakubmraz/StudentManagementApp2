﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp2UWP.Percistency;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Model
{
    class StudentCatalogSingleton : INotifyPropertyChanged
    {

        //StudentManagementDBAccess<Student> studentAPIAsync = new StudentManagementDBAccess<Student>("http://localhost:56934/", "api/Students");

//StudentWebAPIAsync studentWebApiAsync = new StudentWebAPIAsync("http://localhost:56934/", "api/Students/");

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
            StudentWebAPIAsync<Student> gStudentsAsync = new StudentWebAPIAsync<Student>(_url);
            List<Student> sList = gStudentsAsync.GetAll();
            return new ObservableCollection<Student>(sList);
            //var tempst = (studentWebApiAsync.GetAll().Result);
            //return new ObservableCollection<Student>(tempst);
            // return new ObservableCollection<Student>();
            //return _students;
        }

        public void NewStudent(Student s)
        {
            StudentWebAPIAsync<Student> newStudent = new StudentWebAPIAsync<Student>(_url);
            newStudent.CreateNewOne(s);
            OnPropertyChanged(nameof(_students));
            //OnPropertyChanged(nameof(Counting));
        }

        //public void NewStudent(Student st)
        //{
        //    studentWebApiAsync.CreateNew(st);
        //    _students.Add(st);
        //}


        public void RemoveStudent(int id)
        {           
            StudentWebAPIAsync<Student> delStudent = new StudentWebAPIAsync<Student>(_url);

            delStudent.DeleteOne(id); 
            _students.Remove(Students.FirstOrDefault(s => s.Student_Id == id));

            OnPropertyChanged(nameof(_students));
            //OnPropertyChanged(nameof(Counting));
            
        //    studentWebApiAsync.DeleteObject(id);

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
    }
}

