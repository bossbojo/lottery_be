using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Lottery.WebAPI.Entity;

namespace Lottery.WebAPI.Authentication
{
    public class JWTAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            string token = HttpContext.Current.Request.Headers["Authorization"];
            if (token != null)
            {
                try
                {
                    Authentication decodeToken = Securities.JWTDecode<Authentication>(token);
                    if (Authentication.HasToken(decodeToken))
                    {
                        var users = new LotteryDB().Users.Where(c => c.username == decodeToken.username).FirstOrDefault();
                        if (users != null)
                        {
                            Authentication.SetAuthenticated(users);
                            return;
                        }
                    }
                    else
                    {
                        Authentication.SetAuthenticated(custObj:null);
                    }
                }
                catch
                { }
            }
            base.OnAuthorization(actionContext);
        }
    }
}