using DAL.Models;

namespace DAL.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
    }

    public interface IClientMockRepository : IRepository<Client>
    {
    }
}
