namespace EDIWalks.Controllers
{
    using AutoMapper;
    using EDIWalks.CustomActionFilters;
    using EDIWalks.Models;
    using EDIWalks.Models.Domain;
    using EDIWalks.Models.DTO;
    using EDIWalks.Repositories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]    
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> Get()
        {
            var region = await regionRepository.GetAllAsync();

            return Ok(this.mapper.Map<List<RegionDto>>(region));
        }

        [HttpGet("{Id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var regionDomainModel = await regionRepository.GetByIdAsync(Id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<RegionDto>(regionDomainModel));
        }

        [HttpPost]
        [ValidationModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = this.mapper.Map<Region>(addRegionRequestDto);

            regionDomainModel = await regionRepository.CreateAsync(addRegionRequestDto);

            //Covert Domain model to DTO
            var regionDto = this.mapper.Map<RegionDto>(regionDomainModel);

            //Return value to Region
            return CreatedAtAction(nameof(Get), new { Id = regionDto.Id }, regionDto);
        }

        [HttpPut("{Id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Map to Domain Model to DTO
            var regionDomainModel = this.mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateAsync(Id, updateRegionRequestDto);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<RegionDto>(regionDomainModel));
        }

        [HttpDelete("{Id:Guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid Id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(Id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
