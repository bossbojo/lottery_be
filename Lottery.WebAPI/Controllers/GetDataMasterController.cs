using Lottery.WebAPI.Authentication;
using Lottery.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lottery.WebAPI.Controllers
{
    [JWTAuthorize]
    public class GetDataMasterController : ApiController
    {
        private R_GetMasterData _GetDataMaster = new R_GetMasterData();
        [Route("api/get/all/country")]
        public IHttpActionResult GetCountry() {
            try
            {
                return Json(_GetDataMaster.GetCountry());
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/get/all/type")]
        public IHttpActionResult Get_Type()
        {
            try
            {
                return Json(_GetDataMaster.Get_Type());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
