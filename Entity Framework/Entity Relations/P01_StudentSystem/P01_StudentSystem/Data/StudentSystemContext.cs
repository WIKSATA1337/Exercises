using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=StudentSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity
                    .HasKey(x => x.StudentId);

                entity
                    .Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity
                    .Property(x => x.PhoneNumber)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasColumnType("CHAR(10)");

                entity
                    .Property(x => x.RegisteredOn)
                    .IsRequired();

                entity
                    .Property(x => x.Birthday)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity
                    .HasKey(x => x.CourseId);

                entity
                    .Property(x => x.Name)
                    .HasMaxLength(80)
                    .IsRequired()
                    .IsUnicode();

                entity
                    .Property(x => x.Description)
                    .IsUnicode()
                    .IsRequired(false);

                entity
                    .Property(x => x.StartDate)
                    .IsRequired();

                entity
                    .Property(x => x.EndDate)
                    .IsRequired();

                entity
                    .Property(x => x.Price)
                    .IsRequired();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity
                    .HasKey(x => x.ResourceId);

                entity
                    .Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsUnicode()
                    .IsRequired();

                entity
                    .Property(x => x.Url)
                    .IsRequired()
                    .IsUnicode(false);

                entity
                    .Property(e => e.ResourceType)
                    .IsRequired();

                entity
                    .HasOne(e => e.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity
                    .HasKey(x => x.HomeworkId);

                entity
                    .Property(x => x.Content)
                    .IsRequired()
                    .IsUnicode(false);

                entity
                    .Property(x => x.ContentType)
                    .IsRequired();

                entity
                    .Property(e => e.SubmissionTime)
                    .IsRequired();

                entity
                    .HasOne(x => x.Student)
                    .WithMany(x => x.Homeworks)
                    .HasForeignKey(x => x.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(x => x.Course)
                    .WithMany(x => x.Homeworks)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity
                    .HasKey(x => new { x.StudentId, x.CourseId });

                entity
                    .HasOne(x => x.Student)
                    .WithMany(x => x.StudentsCourses)
                    .HasForeignKey(x => x.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(x => x.Course)
                    .WithMany(x => x.StudentsCourses)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}