using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template_Angular2_JwtAuthorization.API.Models;
using Template_Angular2_JwtAuthorization.API.ViewModel;

namespace Template_Angular2_JwtAuthorization.API.Helpers
{
    public class AutoMapperHelper
    {
        public static void ConfigureAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserViewModel>()
                .ReverseMap();
        }
    }
}

