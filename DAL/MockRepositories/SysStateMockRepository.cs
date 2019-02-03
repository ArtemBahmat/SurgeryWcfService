using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.MockRepositories
{
    public class SysStateMockRepository : ISysStateRepository
    {
        public IQueryable<SysState> GetAll()
        {
            return new List<SysState>
            {
                new SysState {StateCode = "stateCode1"},
                new SysState {StateCode = "stateCode2"},
                new SysState {StateCode = "stateCode3"}
            }.AsQueryable();
        }
    }
}
