using System.Collections.Generic;
using TestLibrary.Services;

namespace WcfService
{
    public class SurgeryWcfService : ISurgeryWcfService
    {
        private readonly ISurgeryService surgeryService;

        public SurgeryWcfService(ISurgeryService surgeryService)
        {
            this.surgeryService = surgeryService;
        }

        public IList<string> GetSurgicalSpecInfo(string mdlNumber, string pathologyType, string hdrDataAsJson)
        {
            return surgeryService.GetSurgicalSpecInfo(mdlNumber, pathologyType, hdrDataAsJson);
        }
    }
}
