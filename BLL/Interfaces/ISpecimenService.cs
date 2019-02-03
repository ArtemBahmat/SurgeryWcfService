using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ISpecimenService
    {
        IList<SpecimenDto> GetAllSpecimens();
    }
}
