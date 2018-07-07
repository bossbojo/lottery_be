using Lottery.WebAPI.Entity;
using Lottery.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Repositories
{
    public class R_Check
    {
        private LotteryDB db = new LotteryDB();
        public IEnumerable<Check> GetAllCheck() {
            return db.Check.ToList();
        }
        public Check GetCheckById(int Id) {
            return db.Check.FirstOrDefault(c => c.Id == Id);
        }
        public Check CreateCheck(m_check input) {
            var res = db.Database.SqlQuery<Check>("EXEC [s_Check_Create] @user_id,@number_upper,@number_lower,@number_three,@Country_id",
                new SqlParameter("@user_id", input.user_id),
                new SqlParameter("@number_upper", input.number_upper),
                new SqlParameter("@number_lower", input.number_lower),
                new SqlParameter("@number_three", input.number_three),
                new SqlParameter("@Country_id", input.Country_id)
            ).FirstOrDefault();
            return res;
        }
        public Check UpdateCheck(int id, m_check input)
        {
            var res = db.Database.SqlQuery<Check>("EXEC [s_Check_Update] @id,@user_id,@number_upper,@number_lower,@number_three,@Country_id",
                new SqlParameter("@id", id),
                new SqlParameter("@user_id", input.user_id),
                new SqlParameter("@number_upper", input.number_upper),
                new SqlParameter("@number_lower", input.number_lower),
                new SqlParameter("@number_three", input.number_three),
                new SqlParameter("@Country_id", input.Country_id)
            ).FirstOrDefault();
            return res;
        }
    }
}