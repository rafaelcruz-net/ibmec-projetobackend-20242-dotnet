using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleWebApi.Model;

namespace SampleWebApi.Repository.Mapping
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.UrlFoto).IsRequired().HasMaxLength(500);
            builder.Property(x => x.TipoVeiculo).IsRequired();

        }
    }
}
