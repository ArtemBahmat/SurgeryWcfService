using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class SpecimenRepository : ISpecimenRepository
    {
        public IQueryable<Specimen> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
