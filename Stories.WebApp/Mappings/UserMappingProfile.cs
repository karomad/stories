using AutoMapper;
using Stories.DataModels.Entities;
using Stories.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}