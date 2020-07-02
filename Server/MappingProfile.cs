using AutoMapper;
using JobJournal.Shared;
using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<CompanyContact, CompanyContactDTO>().ReverseMap();
            CreateMap<JobApplication, JobApplicationDTO>().ReverseMap();
        }
    }
}
