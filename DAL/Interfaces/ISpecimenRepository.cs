using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISpecimenRepository : IRepository<Specimen>
    {
    }

    public interface ISpecimenMockRepository : IRepository<Specimen>
    {
    }
}
