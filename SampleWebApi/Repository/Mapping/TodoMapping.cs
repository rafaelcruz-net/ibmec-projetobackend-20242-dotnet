using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleWebApi.Model;
using Microsoft.EntityFrameworkCore.Design;

namespace SampleWebApi.Repository.Mapping
{
    public class TodoMapping : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("tbltodo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

        }
    }
}
