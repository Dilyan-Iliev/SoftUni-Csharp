namespace P01_StudentSystem.Data.ModelBuilders
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;
    using System.Reflection.Emit;

    public class StudentCourseModelBuilder
        : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder
                 .HasKey(k => new
                 {
                     k.StudentId,
                     k.CourseId
                 });
        }
    }
}
