﻿using P01_StudentSystem.Data.Models.Enumelator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static P01_StudentSystem.Common.ValidationLength;


namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [MaxLength(HomeworkValidation.maxLengContent)]
        public string Content { get; set; } = null!;

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }


        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; } = null!;


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
