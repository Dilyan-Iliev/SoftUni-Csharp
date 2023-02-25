namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.ModelBuilders;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext
        : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseModelBuilder());
            modelBuilder.ApplyConfiguration(new HomeworkModelBuilder());
            modelBuilder.ApplyConfiguration(new ResourceModelBuilder());
            modelBuilder.ApplyConfiguration(new StudentModelBuilder());
            modelBuilder.ApplyConfiguration(new StudentCourseModelBuilder());

            base.OnModelCreating(modelBuilder);
        }
    }
}
