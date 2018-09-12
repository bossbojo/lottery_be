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
        public IEnumerable<v_CheckLottery> GetAllCheck(int user_id)
        {
            return db.v_CheckLottery.Where(c => c.user_id == user_id).OrderByDescending(c => c.lot_dt).ToList();
        }
        public IEnumerable<Check> GetAllCheck()
        {
            return db.Checks.ToList();
        }
        public Check GetCheckById(int Id)
        {
            return db.Checks.FirstOrDefault(c => c.Id == Id);
        }
        public Check CreateCheck(m_check input, int user_id)
        {
            if (db.v_CheckLottery.Count(c => c.lot_dt == input.lot_dt && c.Country_id == input.Country_id && c.user_id == user_id && c.Id.HasValue) == 0)
            {
                var add = db.Checks.Add(new Check
                {
                    Country_id = input.Country_id,
                    lot_dt = input.lot_dt,
                    number_lower = input.number_lower,
                    number_upper = input.number_upper,
                    number_three = input.number_three,
                    Create_dt = DateTime.Now,
                    user_id = user_id
                });
                var res = db.SaveChanges();
                if (res > 0)
                {

                    return add;
                }
                throw new Exception("failed save to database");
            }
            throw new Exception("Have your check lottery");
        }
        public Check UpdateCheck(m_edit_check input, int id)
        {
            if (db.Checks.Count(c => c.Id == id) == 1)
            {
                var update = db.Checks.FirstOrDefault(c => c.Id == id);
                update.number_lower = input.number_lower;
                update.number_three = input.number_three;
                update.number_upper = input.number_upper;
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return update;
                }
                throw new Exception("failed save to database");
            }
            throw new Exception("don't have your check lottery");
        }
    }
}