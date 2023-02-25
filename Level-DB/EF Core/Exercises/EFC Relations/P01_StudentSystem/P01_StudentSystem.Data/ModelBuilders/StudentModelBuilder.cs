namespace P01_StudentSystem.Data.ModelBuilders
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;
    using System.Reflection.Emit;

    public class StudentModelBuilder
        : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.Name).IsUnicode();
            builder.Property(e => e.PhoneNumber).IsUnicode(false);
        }
    }
}
