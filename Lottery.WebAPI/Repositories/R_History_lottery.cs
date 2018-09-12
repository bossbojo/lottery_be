using Lottery.WebAPI.Entity;
using Lottery.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Repositories
{
    public class R_History_lottery
    {
        private LotteryDB db = new LotteryDB();
        public m_report_lottery GetSumLottery(DateTime lot_dt) {
            var res = db.History_lottery.Where(c => c.lot_dt == lot_dt);
            m_report_lottery sum = new m_report_lottery{
                lottery_t = new m_lottery_sum{
                    member_give = res.Where(c => c.Country_id == 1).Sum(c => c.member_give),
                    owner_give = res.Where(c => c.Country_id == 1).Sum(c => c.member_get)
                },
                lottery_l = new m_lottery_sum{
                    member_give = res.Where(c => c.Country_id == 2).Sum(c => c.member_give),
                    owner_give = res.Where(c => c.Country_id == 2).Sum(c => c.member_get)
                },
                lottery_v = new m_lottery_sum{
                    member_give = res.Where(c => c.Country_id == 3).Sum(c => c.member_give),
                    owner_give = res.Where(c => c.Country_id == 3).Sum(c => c.member_get)
                }
            };
            return sum;
        }
        public IEnumerable<History_lottery> GetAllHistory_lottery(int user_id,int member_id,int country_id,DateTime date) {
            var res = db.History_lottery.Where(c => c.user_id == user_id && c.lot_dt == date).OrderByDescending(c => c.Create_dt).ToList();
            if (member_id != 0) {
                res = res.Where(c => c.member_id == member_id).ToList();
            }
            if (country_id != 0) {
                res = res.Where(c => c.Country_id == country_id).ToList();
            }
            return res;
        }
        public History_lottery CreateHistory_lottery(m_History_lottery input) {
            var res = db.Database.SqlQuery<History_lottery>("EXEC [LTY].[s_History_lottery_Create] @user_id,@member_id,@number,@type,@Country_id,@price_1,@price_2,@lot_dt",
               new SqlParameter("@user_id", input.user_id),
               new SqlParameter("@member_id", input.member_id),
               new SqlParameter("@number", input.number),
               new SqlParameter("@type", input.type),
               new SqlParameter("@Country_id", input.Country_id),
               new SqlParameter("@price_1", input.price_1),
               new SqlParameter("@price_2", input.price_2),
               new SqlParameter("@lot_dt", input.lot_dt)
            ).FirstOrDefault();
            return res;
        }
        public History_lottery UpdateHistory_lottery(m_History_lottery input,int Id)
        {
            var res = db.Database.SqlQuery<History_lottery>("EXEC [LTY].[s_History_lottery_Update] @Id,@number,@type,@Country_id,@price_1,@price_2,@lot_dt",
               new SqlParameter("@Id", Id),
               new SqlParameter("@number", input.number),
               new SqlParameter("@type", input.type),
               new SqlParameter("@Country_id", input.Country_id),
               new SqlParameter("@price_1", input.price_1),
               new SqlParameter("@price_2", input.price_2),
               new SqlParameter("@lot_dt", input.lot_dt)
            ).FirstOrDefault();
            return res;
        }
    }
}