using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IClientService
    {
        IList<ClientDto> GetAllClients();
    }
}