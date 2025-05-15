using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using static P01_StudentSystem.Common.ValidationLength;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(ResourceValidation.maxLenghName)]
        public string Name { get; set; } = null!; //TODO: Need Unicode


        [MaxLength(ResourceValidation.maxLenghName)]
        public string? Url { get; set; }

        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
