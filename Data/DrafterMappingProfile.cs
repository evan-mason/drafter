using AutoMapper;
using Drafter.Data.Entities;
using Drafter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data
{
    public class DrafterMappingProfile : Profile
    {
        public DrafterMappingProfile()
        {
            CreateMap<FantasyTeam, FantasyTeamViewModel>()
                //.ForMember(o => o.Name, ex => ex.MapFrom(o => o.Name)) // map from one to other altough this doesn't need to be set
                .ReverseMap(); // So we can go back from Order to OrderViewModel
            CreateMap<Draft,  DraftViewModel>()
                .ReverseMap();
        }
    }
}
