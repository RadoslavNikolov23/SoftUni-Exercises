using System.ComponentModel.DataAnnotations;
using static P01_StudentSystem.Common.ValidationLength;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(CourseValidation.maxLenghName)]
        public string Name { get; set; } = null!; //TODO: Need Unicode
       

        [MaxLength(CourseValidation.maxLenghDescription)]
        public string? Description { get; set; } //TODO: Need Unicode

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();

        public virtual ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();
    }


}
