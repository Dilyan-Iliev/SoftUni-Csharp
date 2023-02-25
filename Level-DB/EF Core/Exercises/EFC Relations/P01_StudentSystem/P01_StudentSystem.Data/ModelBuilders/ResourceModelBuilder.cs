namespace P01_StudentSystem.Data.ModelBuilders
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;
    using System.Reflection.Emit;

    public class ResourceModelBuilder
        : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.Property(e => e.Name).IsUnicode();
            builder.Property(e => e.Url).IsUnicode(false);
        }
    }
}
