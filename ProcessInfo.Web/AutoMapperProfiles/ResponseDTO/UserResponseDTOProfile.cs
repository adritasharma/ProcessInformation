﻿using AutoMapper;
using ProcessInfo.DB.Models;
using ProcessInfo.Utility;
using ProcessInfo.Web.Models.DTOs.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.AutoMapperProfiles.ResponseDTO
{
    public class UserResponseDTOProfile : Profile
    {
        public UserResponseDTOProfile()
        {
            CreateMap<User, UserResponseDTO>()
               .ForMember(m => m.UserRoleName, map => map.MapFrom(s => s.Role.ToEnumDescription()));
        }
    }
}
