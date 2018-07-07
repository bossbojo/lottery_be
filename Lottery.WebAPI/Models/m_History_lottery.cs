using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Models
{
    public class m_History_lottery
    {
        public int user_id { get; set; }
        public int member_id { get; set; }
        public int two_number_upper { get; set; }
        public int two_number_lower { get; set; }
        public int three_numbrt { get; set; }
        public int type_id { get; set; }
        public int Country_id { get; set; }
        public decimal price_1 { get; set; }
        public decimal price_2 { get; set; }
        public DateTime lot_dt { get; set; }
    }
}