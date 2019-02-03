using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AggregatedDataService : IAggregatedDataService
    {
        private readonly IClientMockRepository clientRepository;
        private readonly IAddressMockRepository addressRepository;
        private readonly ISysStateMockRepository sysStateRepository;

        public AggregatedDataService(IClientMockRepository clientRepository, IAddressMockRepository addressRepository, ISysStateMockRepository sysStateRepository)
        {
            this.clientRepository = clientRepository;
            this.addressRepository = addressRepository;
            this.sysStateRepository = sysStateRepository;
        }

        public ClientDetailedDto GetClientDetailed(string clientId)
        {
            var clients = clientRepository.GetAll().ToList();
            var addresses = addressRepository.GetAll().ToList();
            var sysStates = sysStateRepository.GetAll().ToList();

            var clientAndAddressResult = clients
                .Join(addresses,
                    client => new { client.Id, Version = client.VersionId },
                    address => new { Id = address.ReferenceId, Version = address.VersionId },
                    (client, address) => new { client, address })
                .Join(sysStates,
                    clientAndAddress => clientAndAddress.address.State,
                    sysState => sysState.StateCode,
                    (clientAndAddress, sysState) => new { clientAndAddress, sysState })
                .FirstOrDefault(item => item.clientAndAddress.client.Id.Equals(clientId)
                                        && !item.clientAndAddress.client.IsDeactivated
                                        && item.clientAndAddress.address.TypeId == "O"
                                        && item.clientAndAddress.address.Id == "C")?.clientAndAddress;

            if (clientAndAddressResult == null)
                return null;

            var clientDto = Mapper.Map<ClientDto>(clientAndAddressResult.client);
            var addressDto = Mapper.Map<AddressDto>(clientAndAddressResult.address);

            return new ClientDetailedDto(clientDto, addressDto);
        }
    }
}
