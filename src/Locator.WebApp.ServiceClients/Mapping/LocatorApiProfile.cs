using AutoMapper;
using Locator.Api.Contracts.Responses;
using Locator.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.WebApp.ServiceClients.Mapping
{
    public class LocatorApiProfile : Profile
    {
        public LocatorApiProfile()
        {
            CreateMap<LandmarkResponse, LandmarkModel>().ReverseMap();
            CreateMap<RouteResponse, RouteModel>().ReverseMap();
        }
    }
}
