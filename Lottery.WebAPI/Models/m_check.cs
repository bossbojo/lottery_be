using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Models
{
    public class m_check
    {
        public DateTime lot_dt { get; set; }
        public string number_upper { get; set; }
        public string number_lower { get; set; }
        public string number_three { get; set; }
        public int Country_id { get; set; }
    }
    public class m_edit_check
    {
        public string number_upper { get; set; }
        public string number_lower { get; set; }
        public string number_three { get; set; }
    }
}