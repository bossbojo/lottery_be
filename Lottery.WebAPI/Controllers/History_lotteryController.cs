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
    public class History_lotteryController : ApiController
    {
        private R_History_lottery _History_Lottery = new R_History_lottery();
        [JWTAuthorize]
        [Route("api/get/history/lottery/{member_id}/{country_id}/{date}")]
        public IHttpActionResult Get_HistoryLottery(int member_id,int country_id,DateTime date) {
            try {
                var user = Authentication.Authentication.User;
                return Json(_History_Lottery.GetAllHistory_lottery(user.Id,member_id,country_id,date));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        [Route("api/create/histrory/lottery")]
        public IHttpActionResult Post_CreateHistroyLottery([FromBody] m_History_lottery request)
        {
            try
            {
                var res = _History_Lottery.CreateHistory_lottery(request);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/update/histrory/lottery")]
        public IHttpActionResult Put_UpdateHistroyLottery([FromBody] m_History_lottery request, int Id)
        {
            try
            {
                var res = _History_Lottery.UpdateHistory_lottery(request, Id);
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [JWTAuthorize]
        [Route("api/create/buy/lottery/one")]
        public IHttpActionResult Post_CreateBuyLottery([FromBody] m_buying_one request)
        {
            try
            {
                var user = Authentication.Authentication.User;
                var res = _History_Lottery.CreateHistory_lottery(new m_History_lottery {
                    Country_id = request.country,
                    member_id = request.who,
                    number = request.number,
                    price_1 = request.price1,
                    price_2 = request.price2,
                    type = request.number.Length,
                    lot_dt = request.lot_dt,
                    user_id = user.Id
                });
                return Json(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/create/buy/lottery/many")]
        public IHttpActionResult Post_CreateBuyLotteryMany([FromBody] m_buying_many request)
        {
            try
            {
                var user = Authentication.Authentication.User;
                foreach (var data in request.buying) {
                    var res = _History_Lottery.CreateHistory_lottery(new m_History_lottery
                    {
                        Country_id = request.country,
                        member_id = request.who,
                        number = data.number,
                        price_1 = data.price1,
                        price_2 = data.price2,
                        type = data.number.Length,
                        lot_dt = request.lot_dt,
                        user_id = user.Id
                    });
                }
                return Json(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/delete/historylottery")]
        public IHttpActionResult Delete_HistoryLottery(int Id) {
            try {
                var res = _History_Lottery.DeleteHistory_lottery(Id);
                return Json(res);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
