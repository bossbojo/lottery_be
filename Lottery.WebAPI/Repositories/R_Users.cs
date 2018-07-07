using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lottery.WebAPI.Entity;
using System.Data.SqlClient;

namespace Lottery.WebAPI.Repositories
{
    public class R_Users
    {
        private LotteryDB db = new LotteryDB();
        public IEnumerable<Users> GetAllUser() {
            return db.Users.ToList();
        }
        public Users GetUserByUsername(int username) {
            return db.Users.FirstOrDefault(c => c.username == username);
        }
        public Users CreateUser(string PIN , string Name) {
            var res = db.Database.SqlQuery<Users>("EXEC [s_Users_Create] @PIN,@Name",
                    new SqlParameter("@PIN", PIN),
                    new SqlParameter("@Name", Name)
                ).FirstOrDefault();
            return res;
        }
        public Users UpdateUser(int Id, string Name)
        {
            var res = db.Database.SqlQuery<Users>("EXEC [s_Users_Update] @Id,@Name",
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@Name", Name)
                ).FirstOrDefault();
            return res;
        }
        public Users UpdateSettingUser(int Id,decimal two,decimal three_straight,decimal three_unstraight)
        {
            var res = db.Database.SqlQuery<Users>("EXEC [s_Users_Update_Setting] @Id,@two,@three_straight,@three_unstraight",
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@two", two),
                    new SqlParameter("@three_straight", three_straight),
                    new SqlParameter("@three_unstraight", three_unstraight)
                ).FirstOrDefault();
            return res;
        }
    }
}