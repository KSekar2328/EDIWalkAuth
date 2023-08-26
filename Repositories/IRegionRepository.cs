namespace EDIWalks.Repositories
{
    using EDIWalks.Models.Domain;
    using EDIWalks.Models.DTO;

    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid Id);

        Task<Region> CreateAsync(AddRegionRequestDto addRegionRequestDto);

        Task<Region?> UpdateAsync(Guid Id, UpdateRegionRequestDto updateRegionRequestDto);

        Task<Region?> DeleteAsync(Guid Id);
    }
}
