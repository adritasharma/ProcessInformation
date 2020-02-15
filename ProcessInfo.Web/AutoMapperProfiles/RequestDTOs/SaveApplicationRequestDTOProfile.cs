using AutoMapper;
using ProcessInfo.DB.Models;
using ProcessInfo.Web.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.AutoMapperProfiles.RequestDTOs
{
    public class SaveApplicationEnvironmentRequestDTOProfile: Profile
    {
        public SaveApplicationEnvironmentRequestDTOProfile()
        {
            CreateMap<SaveApplicationEnvironmentRequestDTO, ApplicationEnvironment>();
        }
    }
}
