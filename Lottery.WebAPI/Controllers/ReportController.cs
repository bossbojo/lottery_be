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
        [Authentication.JWTAuthorize]
        [Route("api/get/report_sum/{lot_dt}")]
        public IHttpActionResult Get_ReportSumBylot(string lot_dt) {
            try {
                var user = Authentication.Authentication.User;
                var res = pagi.queryNonPaginationJSON("[LTY].v_Report_sum", new ConditionString().Where($"lot_dt = CONVERT(DATE,'{lot_dt}') AND user_id = {user.Id}"));
                return Json(res);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [Authentication.JWTAuthorize]
        [Route("api/get/historyLottery/{lot_dt}/{member_id}")]
        public IHttpActionResult Get_historyLotteryMember(int member_id,string lot_dt) {
            try
            {
                var user = Authentication.Authentication.User;
                var res = pagi.queryNonPaginationJSON("[LTY].History_lottery",
                    new ConditionString().Where($"lot_dt = CONVERT(DATE,'{lot_dt}') AND user_id = {user.Id} AND member_id = {member_id}")
                    );
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
