
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SampleWebApi.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T> 
                    where T : class
    {
        private SampleContext Context { get; set; }
        private DbSet<T> DbSet { get; set; }
        public UnitOfWork(SampleContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        public async Task SaveAsync(T model)
        {
            await this.DbSet.AddAsync(model);
            await this.Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T model)
        {
            this.DbSet.Update(model);
            await this.Context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await this.DbSet.FindAsync(id);
            this.DbSet.Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await this.DbSet.ToListAsync();
        }

        public Task<IQueryable<T>> GetAllByCriteria(Expression<Func<T, bool>> expression)
        {
            return Task.FromResult(this.DbSet.Where(expression));
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await this.DbSet.FindAsync(id);
        }

    }
}
