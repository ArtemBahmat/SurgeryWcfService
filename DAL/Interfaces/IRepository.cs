using System.Linq;

namespace DAL.Interfaces
{
    public interface IRepository<out T>
    {
        IQueryable<T> GetAll();
    }
}
