using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lottery.WebAPI.Repositories;
using Lottery.WebAPI.Models;

namespace Lottery.WebAPI.Controllers
{
    public class CheckController : ApiController
    {
        private R_Check _Check = new R_Check();
        [Route("api/create/check")]
        public IHttpActionResult Post_CreateCheck([FromBody] m_check request) {
            try
            {
                var res = _Check.CreateCheck(request);
                return Json(res);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }
        [Route("api/update/check")]
        public IHttpActionResult Put_UpdateCheck([FromBody] m_check request,int Id)
        {
            try
            {
                var res = _Check.UpdateCheck(Id,request);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
