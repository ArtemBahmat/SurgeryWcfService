using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using TestLibrary.Common;
using TestLibrary.Helpers;
using TestLibrary.Models;

namespace TestLibrary.Services
{
    public class SurgeryService : ISurgeryService
    {
        private readonly IRequisitionService requisitionService;
        private readonly IAggregatedDataService aggregatedDataService;
        private readonly ISpecimenService specimenService;


        public SurgeryService(
            IRequisitionService requisitionService,
            IAggregatedDataService aggregatedDataService,
            ISpecimenService specimenService)
        {
            AutoMapperConfig.RegisterAutoMapperConfig();
            this.requisitionService = requisitionService;
            this.aggregatedDataService = aggregatedDataService;
            this.specimenService = specimenService;
        }

        public IList<string> GetSurgicalSpecInfo(string mdlNumber, string pathologyType, string hdrDataAsJson)
        {
            var hdrCollection = GetHdrCollection(mdlNumber, pathologyType, hdrDataAsJson);

            if (hdrCollection.IsNullOrEmpty())
                return new List<string>();

            var selTestCollection = new List<SelTest>();
            var surgicalDtCollection = new List<SurgicalDt>();
            var firstHdr = hdrCollection.First();
            InitializeCollections(mdlNumber, pathologyType, firstHdr, surgicalDtCollection, selTestCollection);
            firstHdr.SelTests = selTestCollection.SerializeIntended();

            return GetFinalStringCollection(hdrCollection, surgicalDtCollection);
        }

        private IList<string> GetFinalStringCollection(IList<Hdr> hdrCollection, IList<SurgicalDt> surgicalDtCollection)
        {
            var result = new List<string>();

            if (!hdrCollection.IsNullOrEmpty())
            {
                result.Add(hdrCollection.SerializeIntended(true));
            }
            if (!surgicalDtCollection.IsNullOrEmpty())
            {
                result.Add(surgicalDtCollection.SerializeIntended(true));
            }

            result.Add(string.Empty);

            return result;
        }

        private void InitializeCollections(string mdlNumber, string pathologyType, Hdr hdr, ICollection<SurgicalDt> surgicalDtCollection, List<SelTest> selTestCollection)
        {
            var selDiscrepancyCollection = new List<SelDiscrepancy>();
            var specimens = specimenService.GetAllSpecimens();
            var discrepancyInfoCollection = specimens.IsNullOrEmpty() ? new List<DiscrepancyInfo>() : GetDiscrepancyInfo(mdlNumber);

            foreach (var specimen in specimens)
            {
                var surgicalDt = Mapper.Map<SurgicalDt>(specimen);

                if (discrepancyInfoCollection.Any())
                {
                    var discrepanciesList = new List<string>();

                    foreach (var discrepancyInfo in discrepancyInfoCollection.Where(x => x.SpecimenNum.Equals(specimen.Num)))
                    {
                        var selDiscrepancy = Mapper.Map<SelDiscrepancy>(discrepancyInfo);
                        discrepanciesList.Add(discrepancyInfo.NotesCodeInfo);
                        selDiscrepancyCollection.Add(selDiscrepancy);
                    }

                    surgicalDt.SerializeDiscrepancyInfo = selDiscrepancyCollection.SerializeIntended();
                    surgicalDt.Discrepancy = discrepanciesList.AsString();
                }

                selTestCollection.AddRange(GetSelTests(mdlNumber, pathologyType, specimen.Num, hdr.ClientId));
                surgicalDtCollection.Add(surgicalDt);
            }
        }

        private IEnumerable<SelTest> GetSelTests(string mdlNumber, string pathologyType, string specimenNum, string clientId)
        {
            var result = new List<SelTest>();
            requisitionService.Initialize(pathologyType, mdlNumber);
            var drTestCollection = requisitionService.GetTestsInfo(specimenNum);
            var dtAllowedTests = GetAllowedTests(specimenNum, clientId);

            foreach (var drTest in drTestCollection)
            {
                var selTest = Mapper.Map<SelTest>(drTest);
                selTest.IsAllowed = drTest.IsNoBill || !dtAllowedTests.Any(x => x.DisplayTestCode.Equals(drTest.DisplayTestCode)) && string.IsNullOrEmpty(drTest.DateInactive);
                result.Add(selTest);
            }

            return result;
        }

        private IList<DtAllowed> GetAllowedTests(string specimenNum, string clientId)
        {
            VerifyParams(specimenNum, clientId);
            var clientDetailed = aggregatedDataService.GetClientDetailed(clientId);

            if (clientDetailed == null)
                return null;

            var isTestApprovalProcessAsString = clientDetailed.Client.IsTestApprovalProcess.AsString();
            var resultState = clientDetailed.Address.State;

            return GetDtAllowed(isTestApprovalProcessAsString, resultState, specimenNum);
        }

        private void VerifyParams(string specimenNum, string clientId)
        {
            specimenNum.ThrowIfNullOrEmpty(nameof(specimenNum));
            specimenNum.ThrowIfNullOrEmpty(nameof(clientId));
            clientId.ThrowIfNotNumeric();
        }

        private IList<string> GetSurgicalHdrInfo(string mdlNumber, string pathologyType)
        {
            var result = new List<string>();
            var dtSurHdrDataCollection = new List<DtSurHdrData>();

            requisitionService.Initialize(pathologyType, mdlNumber);
            var dtSpecimenCollection = requisitionService.GetSpecimensInfo(true);
            var dtReqMdlCollection = requisitionService.GetReqMDLInfo(true);

            foreach (var dtSpecimen in dtSpecimenCollection)
            {
                var dtSurHdrData = Mapper.Map<DtSurHdrData>(dtSpecimen);
                dtSurHdrData.ClientId = dtReqMdlCollection.FirstOrDefault()?.ClientId;
                var specInfoDto = requisitionService.GetTestsInfo(dtSpecimen.SpecimenNum);
                dtSurHdrData.TestCode = specInfoDto.FirstOrDefault()?.TestCode;

                if (dtSurHdrData.TestCode == null)
                    continue;

                dtSurHdrDataCollection.Add(dtSurHdrData);
                break;
            }

            result.Add(dtSurHdrDataCollection.SerializeIntended(true));

            return result;
        }

        private IList<Hdr> GetHdrCollection(string mdlNumber, string pathologyType, string hdrDataAsJson)
        {
            if (string.IsNullOrEmpty(hdrDataAsJson))
                return new List<Hdr>();

            var hdrCollection = hdrDataAsJson.Deserialize<List<Hdr>>();
            if (!hdrCollection.IsNullOrEmpty())
                return hdrCollection;

            var hdrInfo = GetSurgicalHdrInfo(mdlNumber, pathologyType).FirstOrDefault();

            return hdrInfo == null ? hdrCollection : hdrInfo.Deserialize<List<Hdr>>();
        }

        private IList<DiscrepancyInfo> GetDiscrepancyInfo(string mdlNumber)
        {
            var reqNotes = new ReqNotes(mdlNumber, Constants.ReqNotesConstants.NoteCategoryId, Constants.ReqNotesConstants.NoteTypeId);
            return reqNotes.GetReqNotes();
        }

        private List<DtAllowed> GetDtAllowed(string strTestApprovalProcess, string strState, string specimenNum)
        {
            var specimenTest = new SpecimenTest(specimenNum);
            var dtAllowedCollection = new List<DtAllowed>();
            var specimenTestItems = specimenTest.Search(true, TestType.TestOnly, strTestApprovalProcess, strState);

            if (specimenTestItems == null)
                return dtAllowedCollection;

            dtAllowedCollection.AddRange(specimenTestItems.Where(specimenTestItem => specimenTestItem.IsAccessible)
                .Select(Mapper.Map<DtAllowed>));

            return dtAllowedCollection;
        }
    }
}
