using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public IQueryable<Client> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
