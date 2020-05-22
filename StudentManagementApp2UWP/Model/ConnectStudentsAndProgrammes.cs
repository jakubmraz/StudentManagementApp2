using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Model
{
    public class ConnectStudentsAndProgrammes
    {
        StudentCatalogSingleton studentCatalogInstance = StudentCatalogSingleton.Instance;
        ProgrammeCatalogSingleton programmeCatalogInstance = ProgrammeCatalogSingleton.Instance;
        StudentProgrammeSingleton studentProgrammeInstance = StudentProgrammeSingleton.Instance;

        public void LoadStudentsFromDB()
        {
            List<Student> tempStudents = new List<Student>();

            foreach (var programme in programmeCatalogInstance.Programmes)
            {
                programme.Students.Clear();

                foreach (var studentProgramme in studentProgrammeInstance.StudentProgrammes)
                {
                    if (programme.Programme_Id == studentProgramme.Programme_Id)
                    {
                        tempStudents.Add(studentCatalogInstance.Students.FirstOrDefault(data => data.Student_Id == studentProgramme.Student_Id));
                    }
                }

                foreach (var student in tempStudents)
                {
                    programme.Students.Add(student);
                }

                tempStudents.Clear();
            }
        }
    }
}
