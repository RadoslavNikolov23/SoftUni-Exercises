﻿using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using static P01_StudentSystem.Common.ConnectionStringValidation;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options) : base(options)
        {
        }

        public StudentSystemContext()
        {
        }


        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Resource>? Resources { get; set; }
        public DbSet<Homework>? Homeworks { get; set; }
        public DbSet<StudentCourse>? StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConnectionAddress);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });


            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsUnicode();


            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsUnicode();


            modelBuilder.Entity<Resource>()
                .Property(r => r.Name)
                .IsUnicode();


        }
    }
}
