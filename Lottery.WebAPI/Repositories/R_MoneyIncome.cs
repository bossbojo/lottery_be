using Lottery.WebAPI.Entity;
using Lottery.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Repositories
{
    public class R_MoneyIncome
    {
        private LotteryDB db = new LotteryDB();
        public IEnumerable<MoneyIncom> GetAllMoneyIncome(int user_id) {
            return db.MoneyIncoms.Where(c => c.user_id == user_id).ToList();
        }
        public MoneyIncom CreateMoneyIncom(m_MoneyInCome input) {
            var res = db.Database.SqlQuery<MoneyIncom>("EXEC [s_MoneyIncome_Create] @user_id,@member_id,@paid",
                new SqlParameter("@user_id", input.user_id),
                new SqlParameter("@member_id", input.member_id),
                new SqlParameter("@paid", input.paid)
             ).FirstOrDefault();
            return res;
        }
        public MoneyIncom UpdateMoneyIncom(decimal paid,int Id)
        {
            var res = db.Database.SqlQuery<MoneyIncom>("EXEC [s_MoneyIncome_Update] @Id,@paid",
                new SqlParameter("@Id", Id),
                new SqlParameter("@paid", paid)
             ).FirstOrDefault();
            return res;
        }
    }
}