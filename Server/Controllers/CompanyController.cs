using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobJournal.Server.Data;
using JobJournal.Shared;
using JobJournal.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobJournal.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/company/all/9b27e7b5-1acf-42c8-919a-6394fd1ddfe8
        [HttpGet("all/{userId:Guid}")]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAllCompaniesAsync(Guid userId)
        {
            try 
            {
                return Ok(await _mapper.ProjectTo<CompanyDTO>(_repository.GetCompaniesForUser(userId)).ToListAsync());
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // GET api/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(Guid id)
        {
            try
            {
                var company = await _repository.GetCompany(id);
                return Ok(_mapper.Map<CompanyDTO>(company));
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        // POST api/company
        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> AddCompany([FromBody] CompanyDTO companyDTO)
        {
            try
            {
                var company = _mapper.Map<Company>(companyDTO);
                var newCompany = await _repository.AddCompany(company);

                return CreatedAtAction(nameof(GetCompany), new { id = newCompany.Id }, _mapper.Map<CompanyDTO>(newCompany));
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // PUT api/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateCompany(Guid id, [FromBody] CompanyDTO companyDTO)
        {
            if (id != companyDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var company = _mapper.Map<Company>(companyDTO);
                await _repository.UpdateCompany(company);

                return NoContent();
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        // DELETE api/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteCompany(Guid id)
        {
            try
            {
                await _repository.DeleteCompany(id);
                return NoContent();
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }
    }
}
