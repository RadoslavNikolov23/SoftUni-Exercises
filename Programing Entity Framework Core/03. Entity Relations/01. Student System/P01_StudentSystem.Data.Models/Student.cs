using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P01_StudentSystem.Common.ValidationLength;


namespace P01_StudentSystem.Data.Models
{
 
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(StudentValidation.maxLenghtName)]
        public string Name { get; set; } = null!;

        //[MaxLength(StudentValidation.maxLenghtPhoneNumber)]
        [Column(TypeName = "char(10)")]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday  { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();   
        
        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();


    }
}
