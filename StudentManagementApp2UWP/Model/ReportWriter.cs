using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Model
{
    class ReportWriter
    {
        public async void GenerateReportProgramme(Programme programme, StorageFile storageFile)
        {
            string report;

            report = "PROGRAMME REPORT\n" +
                     $"Programme ID: {programme.Programme_Id}\n" +
                     $"Programme Name: {programme.Name}\n" +
                     $"Beginning: {programme.Year_Of_Beginning.ToString("MMMM yyyy")}\n" +
                     $"End: {programme.Year_Of_End.ToString("MMMM yyyy")}\n" +
                     $"Number of Students: {programme.Students.Count}\n" +
                     "\n" +
                     "List of Students:\n";

            foreach (var student in programme.Students)
            {
                report += $"{student.Name}, {student.Email}\n";
            }

            await FileIO.WriteTextAsync(storageFile, report);
        }
    }
}
