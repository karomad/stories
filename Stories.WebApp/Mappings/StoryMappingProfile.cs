using AutoMapper;
using Stories.DataModels.Entities;
using Stories.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Mappings
{
    public class StoryMappingProfile : Profile
    {
        public StoryMappingProfile()
        {
            CreateMap<StoryViewModel, Story>()
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.Groups, opt => opt.Ignore())
                .AfterMap((s, d) => d.Groups = s.Groups.Select(x => new Group
                {
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name

                }).ToList());
                ;
            CreateMap<Story, StoryViewModel>()
                .ForMember(x => x.Groups, opt => opt.Ignore())
                .AfterMap((s, d) =>
                {
                    d.Groups = s.Groups.Select(x => new GroupViewModel
                    {
                        Description = x.Description,
                        Id = x.Id,
                        Name = x.Name

                    }).ToList();
                });
        }
    }
}