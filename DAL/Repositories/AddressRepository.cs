using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public IQueryable<Address> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
