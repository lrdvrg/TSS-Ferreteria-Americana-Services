using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSS_FAMERICANA.DTOs;
using TSS_FAMERICANA.Models;

namespace TSS_FAMERICANA.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Header, HeaderDTO>();
            CreateMap<Detail, DetailDTO>();
        }
    }
}