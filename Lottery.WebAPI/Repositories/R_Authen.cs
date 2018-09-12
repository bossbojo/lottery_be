using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lottery.WebAPI.Entity;

namespace Lottery.WebAPI.Repositories
{
    public class R_Authen
    {
        private LotteryDB db = new LotteryDB();
        public User GetUsers(int username) {
            return db.Users.Where(c => c.username == username).FirstOrDefault();
        }
        public bool haveUser(int username)
        {
            var res = db.Users.Count(c => c.username == username);
            if (res > 0)
            {
                return true;
            }
            return false;
        }
        public User login(int username,string PIN) {
            var res = db.Users.FirstOrDefault(c => c.username == username && c.PIN == PIN);
            if (res != null)
            {
                return res;
            }
            return null;
        }
    }
}