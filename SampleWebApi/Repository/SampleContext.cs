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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
