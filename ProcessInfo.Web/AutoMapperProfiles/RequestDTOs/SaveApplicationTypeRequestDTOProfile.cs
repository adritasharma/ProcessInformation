using AutoMapper;
using ProcessInfo.DB.Models;
using ProcessInfo.Web.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationType = ProcessInfo.DB.Models.ApplicationType;

namespace ProcessInfo.Web.AutoMapperProfiles.RequestDTOs
{
    public class SaveApplicationTypeRequestDTOProfile : Profile
    {
        public SaveApplicationTypeRequestDTOProfile()
        {
            CreateMap<SaveApplicationTypeRequestDTO, ApplicationType>();
        }
    }
}
