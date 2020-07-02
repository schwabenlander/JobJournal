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
    //[Authorize]
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
        public async Task<ActionResult<IQueryable<CompanyDTO>>> GetAllCompaniesAsync(Guid userId)
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
        public void PostCompany([FromBody] CompanyDTO company)
        {
        }

        // PUT api/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpPut("{id:Guid}")]
        public void PutCompany(Guid id, [FromBody] CompanyDTO company)
        {
        }

        // DELETE api/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteCompanyAsync(Guid id)
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

        private static CompanyDTO CompanyToDTO(Company company) =>
            new CompanyDTO
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                WebsiteURI = company.WebsiteURI,
                PhoneNumber = company.PhoneNumber,
                EmailAddress = company.EmailAddress,
                City = company.City,
                State = company.State
            };
    }
}
