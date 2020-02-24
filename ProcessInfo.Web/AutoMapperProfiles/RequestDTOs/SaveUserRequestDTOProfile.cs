using AutoMapper;
using ProcessInfo.DB.Models;
using ProcessInfo.Web.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.AutoMapperProfiles.RequestDTOs
{
    public class SaveUserRequestDTOProfile: Profile
    {
        public SaveUserRequestDTOProfile()
        {
            CreateMap<SaveUserRequestDTO, User>()
              .ForMember(m => m.PasswordHash, map => map.MapFrom(s => s.Password))
              .ForMember(m => m.PasswordSalt, map => map.MapFrom(s => s.Password));

        }
    }
}
