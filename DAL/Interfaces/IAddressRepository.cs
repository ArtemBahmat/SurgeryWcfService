using DAL.Models;

namespace DAL.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
    }

    public interface IAddressMockRepository : IRepository<Address>
    {
    }
}
