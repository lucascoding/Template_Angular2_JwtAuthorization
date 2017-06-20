﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template_Angular2_JwtAuthorization.API.Helpers;
using Template_Angular2_JwtAuthorization.API.Models;
using Template_Angular2_JwtAuthorization.API.ViewModel;

namespace Template_Angular2_JwtAuthorization.API.Data
{
    public class UserRepository: IUserRepository
    {
        private ApplicationDbContext _ctx;

        public UserRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;

            Mapper.Initialize(cfg =>
            {
                AutoMapperHelper.ConfigureAutoMapper(cfg);
            }
);
        }

        public void RegisterUser(UserViewModel user)
        {
            User u = Mapper.Map<UserViewModel, User>(user);
            _ctx.Users.Add(u);
            _ctx.SaveChanges();
        }

        public bool LogUser(string username, string password)
        {
            var u = _ctx.Users.FirstOrDefault(x => (x.Name == username && x.Password == password));
            return u == null ? false : true;
        }
        
    }
}
