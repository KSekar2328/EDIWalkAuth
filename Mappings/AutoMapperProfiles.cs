namespace EDIWalks.Mappings
{
    using AutoMapper;
    using EDIWalks.Models.Domain;
    using EDIWalks.Models.DTO;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            this.CreateMap<Region, RegionDto>().ReverseMap();
            this.CreateMap<Region, AddRegionRequestDto>().ReverseMap();
            this.CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();
            this.CreateMap<Walks, WalksDto>().ReverseMap();
            this.CreateMap<Walks, AddWalkRequestDto>().ReverseMap();
            this.CreateMap<Walks, UpdateWalkRequestDto>().ReverseMap();
        }
    }
}
