using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Models
{
    public class m_MoneyInCome
    {
        public int user_id {get; set;}
        public int member_id { get; set;}
        public decimal paid { get; set;}
    }
}