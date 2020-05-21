namespace StudentManagementApp2WebAPI
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("Student")]
    public  class Student
    {
        private int _student_Id;
        private string _name;
        private string _email;
        private string _background;

        public Student()
        {
        }

        public Student(int studentId, string name, string email, string background)
        {
            _student_Id = studentId;
            _name = name;
            _email = email;
            _background = background;
        }
        public int Student_Id
        {
            get { return _student_Id; }
            set { _student_Id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
       
        public string Background
        {
            get { return _background; }
            set { _background = value; }
        }



        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Student()
        //{
        //    Grades = new HashSet<Grade>();
        //    Programmes = new HashSet<Programme>();
        //}
        //public Student(int studentId, string name, string email, string background)
        //{
        //    Student_Id = studentId;
        //    Name = name;
        //    Email = email;
        //    Background = background;
        //}

        //[Key]
        //public int Student_Id { get; set; }

        //[StringLength(50)]
        //public string Name { get; set; }

        //[StringLength(50)]
        //public string Email { get; set; }

        //[StringLength(50)]
        //public string Background { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Grade> Grades { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Programme> Programmes { get; set; }
    }
}
