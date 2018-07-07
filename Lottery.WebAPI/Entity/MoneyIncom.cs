namespace Lottery.WebAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LTY.MoneyIncom")]
    public partial class MoneyIncom
    {
        public int Id { get; set; }

        public int user_id { get; set; }

        public int member_id { get; set; }

        [Column(TypeName = "money")]
        public decimal paid { get; set; }

        public DateTime Create_dt { get; set; }
    }
}
