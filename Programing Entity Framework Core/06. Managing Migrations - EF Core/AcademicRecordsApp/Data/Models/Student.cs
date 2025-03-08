namespace AcademicRecordsApp.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
