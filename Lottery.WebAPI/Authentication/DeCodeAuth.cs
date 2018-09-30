using Lottery.WebAPI.Entity;
using Lottery.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Authentication
{
    public class DeCodeAuth
    {
        private R_Authen r_Authen = new R_Authen();
        public User GetDeCodeAuthen() {
            string token = HttpContext.Current.Request.Headers["Authorization"];
            if (token != null) {
                Authentication decodeToken = Securities.JWTDecode<Authentication>(token);
                return r_Authen.GetUsers((int)decodeToken.username);
            }
            return null;
        }

    }
}