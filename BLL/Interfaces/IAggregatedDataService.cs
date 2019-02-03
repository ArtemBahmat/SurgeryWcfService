using BLL.Models;

namespace BLL.Interfaces
{
    public interface IAggregatedDataService
    {
        ClientDetailedDto GetClientDetailed(string clientId);
    }
}
