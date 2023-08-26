namespace EDIWalks.Repositories.Walk
{
    using EDIWalks.Data;
    using EDIWalks.Models.Domain;
    using EDIWalks.Models.DTO;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class WalkRepository : IWalkRepository
    {
        private readonly EDIWalksDbContext dbContext;

        public WalkRepository(EDIWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Walks>> GetAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walks?> GetByIdAsync(Guid Id)
        {
            return await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Walks> CreateAsync(AddWalkRequestDto addWalkRequestDto)
        {
            var walk = new Walks()
            {
                Name = addWalkRequestDto.Name,
                Description = addWalkRequestDto.Description,
                LongInKm = addWalkRequestDto.LongInKm,
                RegionId = addWalkRequestDto.RegionId,
                DifficultyId = addWalkRequestDto.DifficultyId
            };

            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walks?> UpdateAsync(Guid Id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);

            if (walkDomainModel == null)
            {
                return null;
            }

            walkDomainModel.Name = updateWalkRequestDto.Name;
            walkDomainModel.Description = updateWalkRequestDto.Description;
            walkDomainModel.LongInKm = updateWalkRequestDto.LongInKm;
            walkDomainModel.RegionId = updateWalkRequestDto.RegionId;
            walkDomainModel.DifficultyId = updateWalkRequestDto.DifficultyId;

            await dbContext.SaveChangesAsync();
            
            return walkDomainModel;
        }

        public async Task<Walks?> DeleteAsync(Guid Id)
        {
            var walkDomainModel = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);

            if (walkDomainModel == null)
            {
                return null;
            }

            dbContext.Walks.Remove(walkDomainModel);
            await dbContext.SaveChangesAsync();
            
            return walkDomainModel;
        }
    }
}
