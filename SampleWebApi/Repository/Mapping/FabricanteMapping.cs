using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleWebApi.Model;

namespace SampleWebApi.Repository.Mapping
{
    public class FabricanteMapping : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.ToTable("fabricante");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.DataFundacao).IsRequired();

            builder.HasMany(x => x.Veiculos).WithOne(x => x.Fabricante);

        }
    }
}
