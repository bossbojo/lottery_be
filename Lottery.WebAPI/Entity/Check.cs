namespace Lottery.WebAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LTY.Check")]
    public partial class Check
    {
        public int Id { get; set; }

        public int user_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime lot_dt { get; set; }

        [Required]
        [StringLength(2)]
        public string number_upper { get; set; }

        [Required]
        [StringLength(2)]
        public string number_lower { get; set; }

        [Required]
        [StringLength(3)]
        public string number_three { get; set; }

        public int Country_id { get; set; }

        public DateTime Create_dt { get; set; }
    }
}
