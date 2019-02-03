using System;
using System.Collections.Generic;
using TestLibrary.Models;

namespace TestLibrary.Services
{
    public class RequisitionService : IRequisitionService
    {
        private string pathologyType;
        private string mdlNumber;

        public void Initialize(string pathologyType, string mdlNumber)
        {
            this.pathologyType = pathologyType;
            this.mdlNumber = mdlNumber;
        }

        public IList<DtSpecimen> GetSpecimensInfo(bool someBooleanFlag)
        {
            throw new NotImplementedException();
        }

        public IList<DtReqMdl> GetReqMDLInfo(bool someBooleanFlag)
        {
            throw new NotImplementedException();
        }

        public IList<DtSpecimen> GetTestsInfo(int specimenNum)
        {
            throw new NotImplementedException();
        }

        public IList<DrTest> GetTestsInfo(string specimenNum)
        {
            throw new NotImplementedException();
        }
    }
}
