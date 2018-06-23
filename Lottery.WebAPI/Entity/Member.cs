namespace Lottery.WebAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LTY.Member")]
    public partial class Member
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? count_two_number_both { get; set; }

        public int? count_two_number_up { get; set; }

        public int? count_two_number_down { get; set; }

        public int? count_three_numbrt_straight { get; set; }

        public int? count_three_numbrt_unstraight { get; set; }

        public DateTime? Create_dt { get; set; }
    }
}
