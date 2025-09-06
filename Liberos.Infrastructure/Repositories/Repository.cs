using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Liberos.Domain.Interfaces;
using Liberos.Infrastructure.Data;

namespace Liberos.Infrastructure.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly LiberosDbContext Context;

    public Repository(LiberosDbContext context)
    {
        Context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public T Create(T entity)
    {
        PrepareEntityForSave(entity);
        Context.Set<T>().Add(entity);
        return entity;
    }

    public T Update(T entity)
    {
        PrepareEntityForSave(entity);
        Context.Set<T>().Update(entity);
        return entity;
    }

    public T Delete(T entity)
    {
        PrepareEntityForSave(entity);
        Context.Set<T>().Remove(entity);
        return entity;
    }

    private void PrepareEntityForSave(T entity)
    {
        var properties = typeof(T).GetProperties()
            .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

        foreach (var prop in properties)
        {
            var value = prop.GetValue(entity);
            if (value is DateTime dt && dt.Kind != DateTimeKind.Utc)
            {
                prop.SetValue(entity, DateTime.SpecifyKind(dt, DateTimeKind.Utc));
            }
            else if (value is DateTime nullableValue && nullableValue.Kind != DateTimeKind.Utc)
            {
                prop.SetValue(entity, DateTime.SpecifyKind(nullableValue, DateTimeKind.Utc));
            }
        }
    }
}
