using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiMik_Auto_Ins_RestfulApi.Models.Domain;

namespace MiMik_Auto_Ins_RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IMapper _mapper;

        public PolicyController(IPolicyRepository policyRepository, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
        }

        // GET: api/<PolicyController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _policyRepository.GetAllAsync());
        }

        // GET: api/<PolicyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _policyRepository.GetByIdAsync(id));
        }

        // POST: api/<PolicyController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddPolicyModel policy)
        {
            if (policy == null)
            {
                return NotFound();
            }
            var policyModel = _mapper.Map<Models.DTOs.Policy>(policy);
            await _policyRepository.AddAsync(policyModel);
            return NoContent();
        }

        // PUT: api/<PolicyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AddPolicyModel policy)
        {
            var existingPolicy = await _policyRepository.GetByIdAsync(id);
            if (existingPolicy == null)
            {
                return NotFound();
            }
            existingPolicy.BodInjLabCvg = policy.BodInjLabCvg;
            existingPolicy.PropDamLiabCvg = policy.PropDamLiabCvg;
            existingPolicy.PersInjProtCvg = policy.PersInjProtCvg;
            existingPolicy.PolicyState = policy.PolicyState;
            existingPolicy.DateTimeIssued = policy.DateTimeIssued;
            existingPolicy.DateTimeBeginTerm = policy.DateTimeBeginTerm;
            existingPolicy.DateTimeEndTerm = policy.DateTimeEndTerm;
            existingPolicy.PremiumTermAmount = policy.PremiumTermAmount;
            await _policyRepository.UpdateAsync(existingPolicy);
            return NoContent();
        }

        // DELETE: api/<PolicyController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingPolicy = await _policyRepository.GetByIdAsync(id);
            if (existingPolicy == null)
            {
                return NotFound();
            }
            await _policyRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
