namespace EDIWalks.Repositories.Walk
{
    using EDIWalks.Models.Domain;
    using EDIWalks.Models.DTO;

    public interface IWalkRepository
    {
        Task<List<Walks>> GetAsync();
        Task<Walks?> GetByIdAsync(Guid Id);
        Task<Walks> CreateAsync(AddWalkRequestDto addWalkRequestDto);
        Task<Walks?> UpdateAsync(Guid Id, UpdateWalkRequestDto addWalkRequestDto);
        Task<Walks?> DeleteAsync(Guid Id);
    }
}
