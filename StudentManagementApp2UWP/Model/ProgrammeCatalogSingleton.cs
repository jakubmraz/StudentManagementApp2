using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp2UWP.Percistency;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Model
{
    class ProgrammeCatalogSingleton
    {
        private StudentManagementDBAccess<Programme> programmeDbAccess = new StudentManagementDBAccess<Programme>("api/Programmes/");
       //private StudentWebAPIAsync<Programme> programmeDbAccess = new StudentWebAPIAsync<Programme>("api/Programmes/");

        private static ProgrammeCatalogSingleton _instance = null;

        public ProgrammeCatalogSingleton()
        {
            LoadFromDB();
            //Programme studentProgramme = new Programme("This one has students", new DateTime(2018, 9, 1), new DateTime(2020, 1, 1));

            //Student newStudent = new Student(00, "Bob Bobby", "bob0000@edu.easj.dk", "Computer Science");

            //Student newStudent2 = new Student(00, "Bob Bobby", "bob0000@edu.easj.dk", "Computer Science");

            //studentProgramme.TempStudents.Add(newStudent);
            //studentProgramme.TempStudents.Add(newStudent2);
            //Programmes.Add(studentProgramme);
        }

        public static ProgrammeCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProgrammeCatalogSingleton();
                }
                return _instance;
            }
        }

        public ObservableCollection<Programme> Programmes { get; } = new ObservableCollection<Programme>()
        {
            new Programme("AP Computer Science", new DateTime(2019, 9,1), new DateTime(2022, 1, 1)),
            new Programme("AP Multimedia Design", new DateTime(2018, 9,1), new DateTime(2021, 1, 1)),
            new Programme("AP Economics", new DateTime(2019, 2,1), new DateTime(2021, 6, 1))
        };

        public async void LoadFromDB()
        {
            Programmes.Clear();
            List<Programme> tempProgrammes = new List<Programme>();

            //Task<List<Programme>> task1 = Task.Run(() => programmeDbAccess.GetAll());
            //Task.WaitAll(task1);
            //tempProgrammes = task1.Result;
            tempProgrammes = await programmeDbAccess.GetAll();

            foreach (var programme in tempProgrammes)
            {
                Programmes.Add(programme);
            }
        }

        
    }
}
