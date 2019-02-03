using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientMockRepository clientRepository;

        public ClientService(IClientMockRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public IList<ClientDto> GetAllClients()
        {
            return Mapper.Map<List<ClientDto>>(clientRepository.GetAll());
        }
    }
}
