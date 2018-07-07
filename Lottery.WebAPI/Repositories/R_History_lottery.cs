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
        public IEnumerable<History_lottery> GetAllHistory_lottery(int user_id) {
            return db.History_lottery.Where(c => c.user_id == user_id).ToList();
        }
        public History_lottery CreateHistory_lottery(m_History_lottery input) {
            var res = db.Database.SqlQuery<History_lottery>("EXEC [s_History_lottery_Create] @user_id,@member_id,@two_number_upper,@two_number_lower,@three_numbrt,@type_id,@Country_id,@price_1,@price_2,@lot_dt",
               new SqlParameter("@user_id", input.user_id),
               new SqlParameter("@member_id", input.member_id),
               new SqlParameter("@two_number_upper", input.two_number_upper),
               new SqlParameter("@two_number_lower", input.two_number_lower),
               new SqlParameter("@three_numbrt", input.three_numbrt),
               new SqlParameter("@type_id", input.type_id),
               new SqlParameter("@Country_id", input.Country_id),
               new SqlParameter("@price_1", input.price_1),
               new SqlParameter("@price_2", input.price_2),
               new SqlParameter("@lot_dt", input.lot_dt)
            ).FirstOrDefault();
            return res;
        }
        public History_lottery UpdateHistory_lottery(m_History_lottery input,int Id)
        {
            var res = db.Database.SqlQuery<History_lottery>("EXEC [s_History_lottery_Update] @Id,@member_id,@two_number_upper,@two_number_lower,@three_numbrt,@type_id,@Country_id,@price_1,@price_2,@lot_dt",
               new SqlParameter("@Id", Id),
               new SqlParameter("@member_id", input.member_id),
               new SqlParameter("@two_number_upper", input.two_number_upper),
               new SqlParameter("@two_number_lower", input.two_number_lower),
               new SqlParameter("@three_numbrt", input.three_numbrt),
               new SqlParameter("@type_id", input.type_id),
               new SqlParameter("@Country_id", input.Country_id),
               new SqlParameter("@price_1", input.price_1),
               new SqlParameter("@price_2", input.price_2),
               new SqlParameter("@lot_dt", input.lot_dt)
            ).FirstOrDefault();
            return res;
        }
    }
}