using Microsoft.EntityFrameworkCore;
using SampleWebApi.Model;
using SampleWebApi.Repository.Mapping;

namespace SampleWebApi.Repository
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options) { }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoMapping());
            modelBuilder.ApplyConfiguration(new FabricanteMapping());
            modelBuilder.ApplyConfiguration(new VeiculoMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
