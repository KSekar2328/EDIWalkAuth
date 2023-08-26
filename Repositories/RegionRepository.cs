namespace EDIWalks.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using EDIWalks.Models.Domain;
    using System;
    using EDIWalks.Models.DTO;
    using EDIWalks.Data;

    public class RegionRepository : IRegionRepository
    {
        private readonly EDIWalksDbContext dbContext;
        public RegionRepository(EDIWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid Id)
        {
            return await dbContext.Regions.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Region> CreateAsync(AddRegionRequestDto addRegionRequestDto)
        {
            var region = new Region()
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code
            };

            dbContext.Regions.Add(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> UpdateAsync(Guid Id, UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if (regionDomainModel == null)
            {
                return null;
            }

            regionDomainModel.Id = Id;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.Code = updateRegionRequestDto.Code;

            await dbContext.SaveChangesAsync();

            return regionDomainModel;
        }

        public async Task<Region?> DeleteAsync(Guid Id)
        {
            var existingregionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if (existingregionDomainModel == null)
            {
                return null;
            }

            dbContext.Regions.Remove(existingregionDomainModel);
            await dbContext.SaveChangesAsync();

            return existingregionDomainModel;
        }

    }
}
