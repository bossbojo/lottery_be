using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary.Pagination;
using Lottery.WebAPI.Authentication;

namespace Lottery.WebAPI.Controllers
{
    public class ReportController : ApiController
    {
        private DeCodeAuth deCodeAuth = new DeCodeAuth();
        private PaginationAndFilter pagi = new PaginationAndFilter("LotteryDB");
        [Authentication.JWTAuthorize]
        [Route("api/get/report_sum/{lot_dt}")]
        public IHttpActionResult Get_ReportSumBylot(string lot_dt) {
            try {
                var user = deCodeAuth.GetDeCodeAuthen();
                var res = pagi.queryNonPaginationJSON("[LTY].v_Report_sum", new ConditionString().Where($"lot_dt = CONVERT(DATE,'{lot_dt}') AND user_id = {user.Id}"));
                return Json(res);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [Authentication.JWTAuthorize]
        [Route("api/get/report_sum_member/{lot_dt}/{member_id}")]
        public IHttpActionResult Get_ReportSumBylotAndMember(string lot_dt,int member_id)
        {
            try
            {
                var user = deCodeAuth.GetDeCodeAuthen();
                var res = pagi.queryNonPaginationJSON("[LTY].v_Report_sum_member",
                    new ConditionString().Where($"lot_dt = CONVERT(DATE,'{lot_dt}') AND user_id = {user.Id} AND member_id = {member_id}")
                    );
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authentication.JWTAuthorize]
        [Route("api/get/report_member")]
        public IHttpActionResult Get_ReportMember()
        {
            try
            {
                var user = deCodeAuth.GetDeCodeAuthen();
                var res = pagi.queryNonPaginationJSON("[LTY].v_Report_Member",
                    new ConditionString().Where($"user_id = {user.Id}")
                    );
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authentication.JWTAuthorize]
        [Route("api/get/historyLottery/{lot_dt}/{member_id}")]
        public IHttpActionResult Get_historyLotteryMember(int member_id,string lot_dt) {
            try
            {
                var user = deCodeAuth.GetDeCodeAuthen();
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
        [Authentication.JWTAuthorize]
        [Route("api/get/check_report_lottery/{lot_dt}/{country_id}")]
        public IHttpActionResult Get_CheckReportLottery(int country_id, string lot_dt)
        {
            try
            {
                var user = deCodeAuth.GetDeCodeAuthen();
                var res = pagi.queryNonPaginationJSON("[LTY].v_check_lottery",
                    new ConditionString().Where($"lot_dt = CONVERT(DATE,'{lot_dt}') AND user_id = {user.Id} AND Country = {country_id}")
                    );
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authentication.JWTAuthorize]
        [Route("api/get/check_report_lottery/only_correct/{lot_dt}/{country_id}")]
        public IHttpActionResult Get_CheckReportLotteryOnlyCorrect(int country_id, string lot_dt)
        {
            try
            {
                var user = deCodeAuth.GetDeCodeAuthen();
                string cor = "[status] = 'hav' AND (f_check_UpAndDown != 0 OR f_check_Up != 0 OR f_check_Down != 0 OR f_check_Straight != 0 OR f_check_Notstraight != 0)";
                var res = pagi.queryNonPaginationJSON("[LTY].v_check_lottery",
                    new ConditionString().Where($"lot_dt = CONVERT(DATE,'{lot_dt}') AND user_id = {user.Id} AND Country = {country_id} AND {cor}")
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
