using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary.Pagination;
namespace Lottery.WebAPI.Controllers
{
    public class ReportController : ApiController
    {
        private PaginationAndFilter pagi = new PaginationAndFilter("LotteryDB");
      //  [Authentication.JWTAuthorize]
        [Route("api/get/report_sum/{lot_dt}")]
        public IHttpActionResult Get_ReportSumBylot(string lot_dt) {
          //  var user = Authentication.Authentication.User;
            return Json(pagi.queryNonPaginationJSON("[LTY].v_Report_sum", new ConditionString().Where($"CONVERT(DATE,lot_dt) = CONVERT(DATE,'{lot_dt}') AND user_id = {2}")));
        }
    }
}
