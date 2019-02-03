using System;
using System.Collections.Generic;

namespace TestLibrary.Models
{
    public class SpecimenTest
    {
        public string SpecimenId { get; }

        public SpecimenTest(string specimenId)
        {
            SpecimenId = specimenId;
        }

        public List<SpecimenTestItem> Search(bool param, TestType testType, string strTestApprovalProcess, string strState)
        {
            var allowedTests = SearchSimple(true, TestType.TestOnly, strTestApprovalProcess, strState);
            var panelsAllowedTests = SearchPanels(strTestApprovalProcess, strState);
            allowedTests.AddRange(panelsAllowedTests);

            return allowedTests;
        }

        private List<SpecimenTestItem> SearchSimple(bool param, TestType testType, string strTestApprovalProcess, string strState)
        {
            throw new NotImplementedException();
        }

        private IList<SpecimenTestItem> SearchPanels(string strTestApprovalProcess, string strState)
        {
            throw new NotImplementedException();
        }
    }

    public enum TestType
    {
        TestOnly
    }
}
