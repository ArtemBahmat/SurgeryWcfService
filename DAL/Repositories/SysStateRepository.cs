using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class SysStateRepository : ISysStateRepository
    {
        public IQueryable<SysState> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
