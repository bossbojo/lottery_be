using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lottery.WebAPI.Entity;
using System.Data.SqlClient;

namespace Lottery.WebAPI.Repositories
{
    public class R_Member
    {
        private LotteryDB db = new LotteryDB();
        public IEnumerable<Member> GetAllMember(int user_id) {
            return db.Member.Where(c => c.user_id == user_id).ToList();
        }
        public Member GetMemberById(int Id) {
            return db.Member.FirstOrDefault(c => c.Id == Id);
        }
        public Member CreateMember(int user_id,string name) {
            var res = db.Database.SqlQuery<Member>("EXEC [LTY].[Member_Create] @user_id,@Name",
               new SqlParameter("@user_id", user_id),
               new SqlParameter("@Name", name)
           ).FirstOrDefault();
            return res;
        }
        public Member UpdateMember(int Id,int user_id, string name)
        {
            var res = db.Database.SqlQuery<Member>("EXEC [LTY].[Member_Update] @Id,@user_id,@Name",
               new SqlParameter("@Id", Id),
               new SqlParameter("@user_id", user_id),
               new SqlParameter("@Name", name)
           ).FirstOrDefault();
            return res;
        }
    }
}