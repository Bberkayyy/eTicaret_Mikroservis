namespace e_Ticaret.Order.Application.Interfaces;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
