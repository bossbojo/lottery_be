﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebAPI.Models
{
    public class m_buying_many
    {
        public DateTime lot_dt { get; set; }
        public int country { get; set; }
        public int who { get; set; }
        public List<m_buying_list> buying { get; set;}
    }
    public class m_buying_list {
        public string number { get; set; }
        public int price1 { get; set; }
        public int price2 { get; set; }
        public string type { get; set; }
    }
}