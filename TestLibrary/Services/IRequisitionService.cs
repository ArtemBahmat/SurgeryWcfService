using System.Collections.Generic;
using TestLibrary.Models;

namespace TestLibrary.Services
{
    public interface IRequisitionService
    {
        void Initialize(string pathologyType, string mdlNumber);

        IList<DtReqMdl> GetReqMDLInfo(bool someBooleanFlag);

        IList<DtSpecimen> GetSpecimensInfo(bool someBooleanFlag);

        IList<DtSpecimen> GetTestsInfo(int specimenNum);

        IList<DrTest> GetTestsInfo(string specimenNum);
    }
}