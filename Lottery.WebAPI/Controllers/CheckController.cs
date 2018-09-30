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
    public class CheckController : ApiController
    {
        private DeCodeAuth deCodeAuth = new DeCodeAuth();
        private R_Check _Check = new R_Check();
        [Route("api/get/test")]
        public IHttpActionResult GetTextJson() {
            return Json(System.Text.Encoding.Unicode.GetBytes("{\"sd\" : \"aa\"}"));
        }
        [Route("api/get/check")]
        public IHttpActionResult Get_CheckLottery() {
            try
            {
                var user = deCodeAuth.GetDeCodeAuthen();
                var res = _Check.GetAllCheck(user.Id);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/create/check")]
        public IHttpActionResult Post_CreateCheck([FromBody] m_check request) {
            try
            {
                var user = deCodeAuth.GetDeCodeAuthen();
                var res = _Check.CreateCheck(request,user.Id);
                return Json(res);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }
        [Route("api/update/check")]
        public IHttpActionResult Put_UpdateCheck([FromBody] m_edit_check request,int Id)
        {
            try
            {
                var res = _Check.UpdateCheck(request,Id);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
