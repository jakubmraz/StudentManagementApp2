using System.Collections.ObjectModel;
using System.Linq;
using Windows.Devices.Sensors;
using StudentManagementApp2UWP.Model;

namespace StudentManagementApp2WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Programme")]
    public partial class Programme
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Programme()
        {
            Exams = new HashSet<Exam>();
            Campus = new HashSet<Campus>();
            Students = new ObservableCollection<Student>();
        }

        public Programme(string name, DateTime yearOfBeginning, DateTime yearOfEnd)
        {
            Name = name;
            Year_Of_Beginning = yearOfBeginning;
            Year_Of_End = yearOfEnd;
            //TempStudents = new ObservableCollection<Student>();
        }

        //Temporary before database works
        //public ObservableCollection<Student> TempStudents { get; set; }

        public string Activity
        {
            get
            {
                if (this.Year_Of_End < DateTime.Now)
                {
                    return "Ended";
                }

                if (Year_Of_Beginning > DateTime.Now)
                {
                    return "Scheduled";
                }

                return "Active";
            }
        }

        [Key] public int Programme_Id { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        [Column(TypeName = "date")] public DateTime Year_Of_Beginning { get; set; }

        [Column(TypeName = "date")] public DateTime Year_Of_End { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam> Exams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Campus> Campus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

    }

    public class Student_Programme
    {
        public Student_Programme()
        {

        }

        public int Programme_Id { get; set; }
        public int Student_Id { get; set; }
    }

}
