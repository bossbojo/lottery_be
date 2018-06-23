using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lottery.WebAPI.Repositories;
using Lottery.WebAPI.Authentication;
using Lottery.WebAPI.Entity;

namespace Lottery.WebAPI.Controllers
{
    public class AuthenController : ApiController
    {
        private R_Authen _Authen = new R_Authen();
        [JWTAuthorize]
        [Route("api/Authentication")]
        public IHttpActionResult GetAuthen()
        {
            var user = Authentication.Authentication.User;
            return Json(new
            {
                Token = Authentication.Authentication.SetAuthenticated(user),
                Detail = user
            });
        }
        [Route("api/signin")]
        public IHttpActionResult PostSignIn([FromBody] SignIn request) {
            try
            {
                var res = _Authen.haveUser(request.username);
                if (res) {
                    return Json(new { TempData = Securities.Encode(_Authen.GetUsers(request.username)) });
                }
                return BadRequest("This username don't has in database");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/signin/pin")]
        public IHttpActionResult PostSignIn([FromBody] SignInPIN request)
        {
            try
            {
                var decode = Securities.Decode<Users>(request.TempData);
                if (decode != null) {
                    var res = _Authen.login((int)decode.username,request.PIN);
                    if (res != null)
                    {
                        return Json(new { Token = Authentication.Authentication.SetAuthenticated(res) , Detail = res });
                    }
                    return BadRequest("PIN incorrent");
                }
                return BadRequest("Model incorrent");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    public class SignIn {
        public int username { get; set; }
    }
    public class SignInPIN
    {
        public string TempData { get; set; }
        public string PIN { get; set; }
    }
}
