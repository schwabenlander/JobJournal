﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobJournal.Client;
using JobJournal.Server.Data;
using JobJournal.Server.Utilities;
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
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationRepository _repository;
        private readonly IMapper _mapper;

        public JobApplicationController(IJobApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("user/{userId:Guid}/count")]
        public async Task<ActionResult<int>> GetCompanyCountForUser(Guid userId)
        {
            try
            {
                return Ok(await _repository.GetJobApplicationCountForUser(userId));
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // GET: api/jobapplication/user/9B27E7B5-1ACF-42C8-919A-6394FD1DDFE8?Page=2&RecordsPerPage=20
        [HttpGet("user/{userId:Guid}")]
        public async Task<ActionResult<PaginatedResultDTO<JobApplicationDTO>>> GetJobApplications([FromRoute] Guid userId, [FromQuery] PaginationDTO paginationDTO)
        {
            try
            {
                var applications = _repository.GetJobApplicationsForUser(userId);

                var results = await _mapper.ProjectTo<JobApplicationDTO>(applications.Paginate(paginationDTO)).ToListAsync();

                var response = new PaginatedResultDTO<JobApplicationDTO> 
                { 
                    Results = results, 
                    CurrentPage = paginationDTO.Page, 
                    RecordsPerPage = paginationDTO.RecordsPerPage, 
                    TotalRecords = await applications.CountAsync()
                };

                return Ok(response);
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // GET: api/jobapplication/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpGet("company/{companyId:Guid}")]
        public async Task<ActionResult<IEnumerable<JobApplicationDTO>>> GetJobApplicationsForCompany(Guid companyId)
        {
            try
            {
                return Ok(await _mapper.ProjectTo<JobApplicationDTO>(_repository.GetJobApplicationsForCompany(companyId)).ToListAsync());
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // GET api/jobapplication/58E55E99-CBAD-4C93-B804-FE8C265F9835
        [HttpGet("{id:Guid}")]
        public ActionResult<JobApplicationDTO> GetJobApplication(Guid id)
        {
            try
            {
                var jobApplication = _repository.GetJobApplication(id);
                return Ok(_mapper.Map<JobApplicationDTO>(jobApplication));
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        // POST api/jobapplication
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JobApplicationDTO applicationDTO)
        {
            try
            {
                var application = _mapper.Map<JobApplication>(applicationDTO);
                var newApplication = await _repository.AddJobApplication(application);

                return CreatedAtAction(nameof(GetJobApplication), new { id = newApplication.Id }, _mapper.Map<JobApplicationDTO>(newApplication));
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // PUT api/jobapplication/58E55E99-CBAD-4C93-B804-FE8C265F9835
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] JobApplicationDTO applicationDTO)
        {
            if (id != applicationDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var application = _mapper.Map<JobApplication>(applicationDTO);
                await _repository.UpdateJobApplication(application);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // TODO: Log exception
                return NotFound();
            }
        }

        // DELETE api/jobapplication/58E55E99-CBAD-4C93-B804-FE8C265F9835
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteJobApplication(id);
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
