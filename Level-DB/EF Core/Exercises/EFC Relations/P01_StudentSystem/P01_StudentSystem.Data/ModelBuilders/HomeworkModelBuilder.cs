namespace P01_StudentSystem.Data.ModelBuilders
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;
    using System.Reflection.Emit;

    public class HomeworkModelBuilder
        : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.Property(e => e.Content).IsUnicode(false);
        }
    }
}
