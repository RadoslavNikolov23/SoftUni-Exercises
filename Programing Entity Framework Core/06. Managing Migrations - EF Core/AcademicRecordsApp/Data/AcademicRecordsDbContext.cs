namespace AcademicRecordsApp.Data
{
    using AcademicRecordsApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static ConfigurationConnection;

    public partial class AcademicRecordsDbContext : DbContext
    {
        public AcademicRecordsDbContext()
        {
        }

        public AcademicRecordsDbContext(DbContextOptions<AcademicRecordsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exam> Exams { get; set; } = null!;

        public virtual DbSet<Grade> Grades { get; set; } = null!;

        public virtual DbSet<Student> Students { get; set; } = null!;

        public virtual DbSet<Course> Courses { get; set; } = null!;

        public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionAddress);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity
                    .HasKey(e => e.Id)
                    .HasName("PK__Exams__3214EC07E38DAA34");

                entity
                    .Property(e => e.Name)
                    .HasMaxLength(100);

                entity
                    .Property(e => e.CourseId)
                    .IsRequired(false);

                entity
                    .HasOne(e => e.Course)
                    .WithMany(c => c.Exams)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_Exams");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity
                    .HasKey(g => g.Id)
                    .HasName("PK__Grades__3214EC07523091CB");

                entity
                    .Property(g => g.Value)
                    .HasColumnType("decimal(3, 2)");

                entity
                    .HasOne(g => g.Exam)
                    .WithMany(e => e.Grades)
                    .HasForeignKey(g => g.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Exams");

                entity
                    .HasOne(g => g.Student)
                    .WithMany(s => s.Grades)
                    .HasForeignKey(g => g.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Students");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity
                    .HasKey(s => s.Id)
                    .HasName("PK__Students__3214EC07D7E505AA");

                entity
                    .Property(s => s.FullName)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity
                    .HasKey(c => c.Id);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(150)
                    .HasDefaultValue(string.Empty);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity
                    .HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity
                    .HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentsCourses)
                    .HasForeignKey(sc => sc.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsCourses)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
