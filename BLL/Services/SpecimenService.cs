using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SpecimenService : ISpecimenService
    {
        private readonly ISpecimenMockRepository specimenRepository;

        public SpecimenService(ISpecimenMockRepository specimenRepository)
        {
            this.specimenRepository = specimenRepository;
        }

        public IList<SpecimenDto> GetAllSpecimens()
        {
            return Mapper.Map<List<SpecimenDto>>(specimenRepository.GetAll());
        }
    }
}
