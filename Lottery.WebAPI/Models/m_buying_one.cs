using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Models
{
    public class m_buying_one
    {
        public int who { get; set; }
        public int country { get; set; }
        public string number { get; set; }
        public int price1 { get; set; }
        public int price2 { get; set; }
        public string type { get; set; }
    }
}