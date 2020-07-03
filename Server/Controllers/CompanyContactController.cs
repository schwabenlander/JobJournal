using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobJournal.Server.Data;
using JobJournal.Shared;
using JobJournal.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobJournal.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyContactController : ControllerBase
    {
        private readonly ICompanyContactRepository _repository;
        private readonly IMapper _mapper;

        public CompanyContactController(ICompanyContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/companycontacts/1E98B65B-C56D-470D-B509-148AC693A013
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<CompanyContactDTO>>> GetCompanyContactsAsync(Guid id)
        {
            try
            {
                return Ok(await _mapper.ProjectTo<CompanyContactDTO>(_repository.GetContactsForCompany(id)).ToListAsync());
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // GET api/<CompanyContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyContactController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompanyContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
