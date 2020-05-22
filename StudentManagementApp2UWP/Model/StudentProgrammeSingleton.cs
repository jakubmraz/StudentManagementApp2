using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Model
{
    class StudentProgrammeSingleton
    {
        private StudentManagementDBAccess<Student_Programme> studentProgrammeDbAccess = new StudentManagementDBAccess<Student_Programme>("api/Student_Programme/");

        private static StudentProgrammeSingleton _instance = null;

        public StudentProgrammeSingleton()
        {
            LoadFromDB();
        }

        public static StudentProgrammeSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentProgrammeSingleton();
                }
                return _instance;
            }
        }

        public ObservableCollection<Student_Programme> StudentProgrammes { get; } = new ObservableCollection<Student_Programme>(){};

        public async void LoadFromDB()
        {
            StudentProgrammes.Clear();
            List<Student_Programme> tempStudentProgrammes = new List<Student_Programme>();

            tempStudentProgrammes = await studentProgrammeDbAccess.GetAll();

            foreach (var programme in tempStudentProgrammes)
            {
                StudentProgrammes.Add(programme);
            }
        }
    }
}
