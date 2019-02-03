using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;


namespace DAL.MockRepositories
{
    public class AddressMockRepository : IAddressRepository
    {
        public IQueryable<Address> GetAll()
        {
            return new List<Address>
            {
                new Address {Id = "id1", TypeId = "type1", VersionId = "ver1", ReferenceId = "ref1"},
                new Address {Id = "id2", TypeId = "type2", VersionId = "ver2", ReferenceId = "ref2"},
                new Address {Id = "id3", TypeId = "type3", VersionId = "ver3", ReferenceId = "ref3"},
            }.AsQueryable();
        }
    }
}
