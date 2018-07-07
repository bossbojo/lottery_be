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
    public class History_lotteryController : ApiController
    {
        private R_History_lottery _History_Lottery = new R_History_lottery();
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
        [Route("api/create/buy/lottery/one")]
        public IHttpActionResult Post_CreateBuyLottery([FromBody] m_buying_one request)
        {
            try
            {
                return Json(request);
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
                return Json(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
