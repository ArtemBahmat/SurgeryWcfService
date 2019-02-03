using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.MockRepositories
{
    public class ClientMockRepository : IClientRepository
    {
        public IQueryable<Client> GetAll()
        {
            return new List<Client>
            {
                new Client {Id = "id1", IsDeactivated = false, IsTestApprovalProcess = true, VersionId = "ver1"},
                new Client {Id = "id2", IsDeactivated = true, IsTestApprovalProcess = false, VersionId = "ver2"},
                new Client {Id = "id3", IsDeactivated = false, IsTestApprovalProcess = true, VersionId = "ver3"},
            }.AsQueryable();
        }
    }
}
