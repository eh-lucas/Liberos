using Liberos.Api.Interfaces;
using System.Linq.Expressions;
using Liberos.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Liberos.Api.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly LiberosDbContext Context;

    public Repository(LiberosDbContext context)
    {
        Context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return Context.Set<T>().AsNoTracking().ToList();
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return Context.Set<T>().FirstOrDefault(predicate);
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
