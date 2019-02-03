using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ISysStateService
    {
        IList<SysStateDto> GetAllSysStates();
    }
}