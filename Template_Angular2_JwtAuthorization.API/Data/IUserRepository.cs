using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template_Angular2_JwtAuthorization.API.ViewModel;

namespace Template_Angular2_JwtAuthorization.API.Data
{
    public interface IUserRepository
    {
        void RegisterUser(UserViewModel user);
        UserViewModel LogUser(UserViewModel user);
        UserViewModel GetCurLoggedInUser(string token);
    }
}
