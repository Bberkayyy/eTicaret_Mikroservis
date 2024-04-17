using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace e_Ticaret.Cargo.DataAccessLayer.Abstract;

public interface IGenericDal<T> where T : class
{
    void Add(T entity);
    void Delete(int id);
    void Update(T entity);
    T GetById(int id);
    T GetByFilter(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
}
