using AutoMapper;
using ProcessInfo.DB.Models;
using ProcessInfo.Web.Models.DTOs.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.AutoMapperProfiles.ResponseDTO
{
    public class ApplicationEnvironmentResponseDTOProfile : Profile
    {
        public ApplicationEnvironmentResponseDTOProfile()
        {
            CreateMap<ApplicationEnvironment, ApplicationEnvironmentResponseDTO>();
        }
    }
}
