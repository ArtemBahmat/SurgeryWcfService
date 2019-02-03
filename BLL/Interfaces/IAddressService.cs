using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IAddressService
    {
        IList<AddressDto> GetAllAddresses();
    }
}