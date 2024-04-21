using AutoMapper;
using Qz.Application.Contracts.Dtos;
using Qz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Maper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Team, AddTeamResponse>().ReverseMap();
        }
    }
}
