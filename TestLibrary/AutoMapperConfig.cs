using AutoMapper;
using TestLibrary.Models;

namespace TestLibrary
{
    public class AutoMapperConfig
    {
        public static void RegisterAutoMapperConfig()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Specimen, SurgicalDt>();
                cfg.CreateMap<SelDiscrepancy, DiscrepancyInfo>()
                    .ForMember(destination => destination.NoteCodeId, opts => opts.MapFrom(source => source.RejectionId))
                    .ForMember(destination => destination.Notes, opts => opts.MapFrom(source => source.AddMsg));
                cfg.CreateMap<DrTest, SelTest>();
                cfg.CreateMap<SpecimenTestItem, DtAllowed>()
                    .ForMember(destination => destination.IsPanel, opts => opts.MapFrom(source => source.IsPanel ? "Test" : "Panel"));
                cfg.CreateMap<DtSpecimen, DtSurHdrData>();
                cfg.CreateMap<SpecimenTestItem, DtAllowed>();
            });
        }
    }
}
