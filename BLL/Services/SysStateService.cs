using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.MockRepositories;

namespace BLL.Services
{
    public class SysStateService : ISysStateService
    {
        private readonly ISysStateMockRepository sysStateRepository;

        public SysStateService(ISysStateMockRepository sysStateRepository)
        {
            this.sysStateRepository = sysStateRepository;
        }

        public IList<SysStateDto> GetAllSysStates()
        {
            return Mapper.Map<List<SysStateDto>>(sysStateRepository.GetAll());
        }
    }
}
