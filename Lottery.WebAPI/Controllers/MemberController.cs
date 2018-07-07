using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lottery.WebAPI.Repositories;
using Lottery.WebAPI.Models;
using Lottery.WebAPI.Authentication;

namespace Lottery.WebAPI.Controllers
{
    [JWTAuthorize]
    public class MemberController : ApiController
    {
        private R_Member _Member = new R_Member();
       
        [Route("api/get/all/member")]
        public IHttpActionResult Get_AllMember()
        {
            try
            {
                var user = Authentication.Authentication.User;
                var res = _Member.GetAllMember(user.Id);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/create/member")]
        public IHttpActionResult Post_CreateMember([FromBody] string name)
        {
            try
            {
                var user = Authentication.Authentication.User;
                var res = _Member.CreateMember(user.Id,name);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/update/member")]
        public IHttpActionResult Put_UpdateMember([FromBody] string name,int Id)
        {
            try
            {
                var user = Authentication.Authentication.User;
                var res = _Member.UpdateMember(Id,user.Id,name);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
