using AutoMapper;
using ProcessInfo.DB.Models;
using ProcessInfo.Web.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Environment = ProcessInfo.DB.Models.Environment;

namespace ProcessInfo.Web.AutoMapperProfiles.RequestDTOs
{
    public class SaveEnvironmentRequestDTOProfile : Profile
    {
        public SaveEnvironmentRequestDTOProfile()
        {
            CreateMap<SaveEnvironmentRequestDTO, Environment>();
        }
    }
}
