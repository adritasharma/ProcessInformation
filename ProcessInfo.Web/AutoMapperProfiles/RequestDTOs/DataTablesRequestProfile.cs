using AutoMapper;
using DataTables.AspNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.AutoMapperProfiles.RequestDTOs
{
    public class DataTablesRequestProfile : Profile
    {
        public DataTablesRequestProfile()
        {
            CreateMap<IDataTablesRequest, DataTablesRequestDTO>()
                .ForMember(m => m.SearchColumns, map => map.MapFrom(s =>
                     s.Columns != null && s.Columns.Any(x => x.IsSearchable) ?
                        s.Columns.Where(x => x.IsSearchable).Select(x => x.Field).ToArray()
                        : null
                )).ForMember(m => m.FilterType, map => map.MapFrom(s =>
                     s.AdditionalParameters != null && s.AdditionalParameters.Any(x => x.Key.ToLower() == "filtertype") ?
                        s.AdditionalParameters.First(x => x.Key.ToLower() == "filtertype").Value
                        : null
                ))
                .ForMember(m => m.SearchText, map => map.MapFrom(s => s.Search != null ? s.Search.Value.Trim() : null))
                .ForMember(m => m.SortColumn, map => map.MapFrom(s => s.Columns.Any(x => x.Sort != null) ? s.Columns.First(x => x.Sort != null).Field : null))
                .ForMember(m => m.SortType, map => map.MapFrom(s => s.Columns.Any(x => x.Sort != null) ? s.Columns.First(x => x.Sort != null).Sort.Direction : SortDirection.Ascending))
                .ForMember(m => m.Draw, map => map.MapFrom(s => s.Draw))
                .ForMember(m => m.Start, map => map.MapFrom(s => s.Start))
                .ForMember(m => m.Length, map => map.MapFrom(s => s.Length))
                .ForMember(m => m.AdditionalParameters, map => map.MapFrom(s => s.AdditionalParameters));
        }
    }
}
