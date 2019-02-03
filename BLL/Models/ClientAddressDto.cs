namespace BLL.Models
{
    public class ClientDetailedDto
    {
        public ClientDetailedDto(ClientDto client, AddressDto address)
        {
            Client = client;
            Address = address;
        }

        public ClientDto Client { get; set; }

        public AddressDto Address { get; set; }
    }
}