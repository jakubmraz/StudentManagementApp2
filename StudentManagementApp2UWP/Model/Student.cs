namespace StudentManagementApp2WebAPI
{
    public class Student
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

        public object Username { get; internal set; }
        public object Password { get; internal set; }
    }
}
