namespace EDIWalks.Controllers
{
    using AutoMapper;
    using EDIWalks.Models.Domain;
    using EDIWalks.Models.DTO;
    using EDIWalks.Repositories.Walk;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var walkDomainModel = await walkRepository.GetAsync();

            //Map to Domain model to Dto
            return Ok(this.mapper.Map<List<WalksDto>>(walkDomainModel));
        }

        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(Id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map to Domain model to Dto
            return Ok(this.mapper.Map<WalksDto>(walkDomainModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map Dto to Domain model
            var walkDomainModel = this.mapper.Map<Walks>(addWalkRequestDto);

            walkDomainModel = await this.walkRepository.CreateAsync(addWalkRequestDto);

            //Map Domain model to Dto
            return Ok(this.mapper.Map<WalksDto>(walkDomainModel));
        }

        [HttpPut("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            //Map Dto to Domain model
            var walkDomainModel = this.mapper.Map<Walks>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(Id, updateWalkRequestDto);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain model to Dto
            return Ok(this.mapper.Map<WalksDto>(walkDomainModel));
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(Id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain model to Dto
            return Ok(this.mapper.Map<WalksDto>(walkDomainModel));
        }
    }
}
