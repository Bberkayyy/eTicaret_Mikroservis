using e_Ticaret.Cargo.DataAccessLayer.Abstract;
using e_Ticaret.Cargo.DataAccessLayer.Context;
using e_Ticaret.Cargo.DataAccessLayer.Repositories;
using e_Ticaret.Cargo.EntityLayer.Concrete;

namespace e_Ticaret.Cargo.DataAccessLayer.EntityFramework;

public class EfOperationDal : GenericRepository<Operation>, IOperationDal
{
    public EfOperationDal(CargoContext context) : base(context)
    {
    }
}
