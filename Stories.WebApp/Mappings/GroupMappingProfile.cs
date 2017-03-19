using AutoMapper;
using Stories.DataModels.Entities;
using Stories.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Mappings
{
    public class GroupMappingProfile : Profile
    {

        public GroupMappingProfile()
        {
            CreateMap<GroupViewModel, Group>()
                .ForMember(x => x.Members, opt => opt.Ignore())
                .ForMember(x => x.Stories, opt => opt.Ignore()); 
            CreateMap<Group, GroupViewModel>()
                .ForMember(x => x.Members, opt => opt.Ignore())
                .ForMember(x => x.Stories, opt => opt.Ignore());
            CreateMap<Group, KeyValueItem>();
        }
    }
}