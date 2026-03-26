namespace Problem7.Models
{
    public class Student
    {
        public int StudentId
        {
            get;
            set;
        }

        public string StudentName
        {
            get;
            set;
        } = string.Empty;

        public string Course
        {
            get;
            set;
        } = string.Empty;
    }
}