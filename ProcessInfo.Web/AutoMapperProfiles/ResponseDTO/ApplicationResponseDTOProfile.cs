using AutoMapper;
using ProcessInfo.DB.Models;
using ProcessInfo.Web.Models.DTOs.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.AutoMapperProfiles.ResponseDTO
{
    public class ApplicationResponseDTOProfile : Profile
    {
        public ApplicationResponseDTOProfile()
        {
            CreateMap<Application, ApplicationResponseDTO>()
               .ForMember(m => m.TeamMembers, map => map.MapFrom(s => s.ApplicationDevelopers.Select(x => x.User)))
               .ForMember(m => m.ApplicationTypeName, map => map.MapFrom(s => s.ApplicationType.ApplicationTypeName))
               .ForMember(m => m.TeamMemberNames, map => map.MapFrom(s => (string.Join(",", (s.ApplicationDevelopers.Select(x =>x.User)).Select(y => y.FirstName)))));
        }
    }
}
