using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressMockRepository addressRepository;

        public AddressService(IAddressMockRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public IList<AddressDto> GetAllAddresses()
        {
            return Mapper.Map<List<AddressDto>>(addressRepository.GetAll());
        }
    }
}
