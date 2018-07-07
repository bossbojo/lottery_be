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
    public class MoneyIncomeController : ApiController
    {
        private R_MoneyIncome _MoneyIncome = new R_MoneyIncome();

        [Route("api/get/all/money_income")]
        public IHttpActionResult Get_All_MoneyIncome()
        {
            try
            {
                var user = Authentication.Authentication.User;
                var res = _MoneyIncome.GetAllMoneyIncome(user.Id);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/create/money_income")]
        public IHttpActionResult Post_Create_MoneyIncome([FromBody] m_MoneyInCome requset) {
            try
            {
                var res = _MoneyIncome.CreateMoneyIncom(requset);
                return Json(res);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/update/money_income")]
        public IHttpActionResult Put_Update_MoneyIncome([FromBody] decimal paid)
        {
            try
            {
                var user = Authentication.Authentication.User;
                var res = _MoneyIncome.UpdateMoneyIncom(paid,user.Id);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
