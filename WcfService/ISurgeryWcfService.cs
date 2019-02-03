using System.Collections.Generic;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface ISurgeryWcfService
    {
        [OperationContract]
        IList<string> GetSurgicalSpecInfo(string mdlNumber, string pathologyType, string hdrDataAsJson);
    }
}
