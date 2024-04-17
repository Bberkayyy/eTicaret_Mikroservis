namespace e_Ticaret.Cargo.DataAccessLayer.Repositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
