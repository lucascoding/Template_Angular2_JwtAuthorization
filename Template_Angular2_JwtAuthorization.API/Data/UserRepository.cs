using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template_Angular2_JwtAuthorization.API.Models;

namespace Template_Angular2_JwtAuthorization.API.Data
{
    public class UserRepository
    {
        private ApplicationDbContext _ctx;

        public UserRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }

        public void RegisterUser(User newUser)
        {
            _ctx.Users.Add(newUser);
            _ctx.SaveChanges();
        }

        public bool LoginUser(string username, string password)
        {
            var user = _ctx.Users.FirstOrDefault(x => (x.Name == username && x.Password == password));
            return user == null ? false : true;
        }
    }
}
