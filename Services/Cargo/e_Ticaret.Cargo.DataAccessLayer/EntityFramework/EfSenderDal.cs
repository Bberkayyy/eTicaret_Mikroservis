using e_Ticaret.Cargo.DataAccessLayer.Abstract;
using e_Ticaret.Cargo.DataAccessLayer.Context;
using e_Ticaret.Cargo.DataAccessLayer.Repositories;
using e_Ticaret.Cargo.EntityLayer.Concrete;

namespace e_Ticaret.Cargo.DataAccessLayer.EntityFramework;

public class EfSenderDal : GenericRepository<Sender>, ISenderDal
{
    public EfSenderDal(CargoContext context) : base(context)
    {
    }
}
