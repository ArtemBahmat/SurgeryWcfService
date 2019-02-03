using System.Collections.Generic;

namespace TestLibrary.Services
{
    public interface ISurgeryService
    {
        IList<string> GetSurgicalSpecInfo(string mdlNumber, string pathologyType, string hdrDataAsJson);
    }
}