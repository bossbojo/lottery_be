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

        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? Receivable { get; set; }

        [Column(TypeName = "money")]
        public decimal? Paid { get; set; }

        [Column(TypeName = "money")]
        public decimal? total { get; set; }

        public DateTime Create_dt { get; set; }
    }
}
