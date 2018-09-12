using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Models
{
    public class m_report_lottery
    {
        public m_lottery_sum lottery_t { get; set; }
        public m_lottery_sum lottery_l { get; set; }
        public m_lottery_sum lottery_v { get; set; }
    }
    public class m_lottery_sum {
        public decimal? member_give { get; set; }
        public decimal? owner_give { get; set; }
    }
}