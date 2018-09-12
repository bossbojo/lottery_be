using Lottery.WebAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Repositories
{
    public class R_GetMasterData
    {
        private LotteryDB db = new LotteryDB();
        public IEnumerable<Country> GetCountry() {
            return db.Countries.ToList();
        }
        public IEnumerable<Type_play> Get_Type()
        {
            return db.Type_play.ToList();
        }
    }
}