using e_Ticaret.Cargo.DataAccessLayer.Abstract;
using e_Ticaret.Cargo.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.DataAccessLayer.Repositories;

public class GenericRepository<T> : IGenericDal<T>, IQuery<T> where T : class
{
    protected readonly CargoContext _context;

    public GenericRepository(CargoContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        T? value = _context.Set<T>().Find(id);
        _context.Set<T>().Remove(value);
        _context.SaveChanges();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (include is not null)
            queryable = include(queryable);
        return queryable.ToList();
    }

    public T GetByFilter(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> queryable = Query().Where(predicate);
        if (include is not null)
            queryable = include(queryable);
        return queryable.SingleOrDefault();
    }

    public IQueryable<T> Query() => _context.Set<T>();

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}
