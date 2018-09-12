namespace Lottery.WebAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LTY.v_CheckLottery")]
    public partial class v_CheckLottery
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime lot_dt { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [StringLength(50)]
        public string country_name { get; set; }

        [StringLength(2)]
        public string number_lower { get; set; }

        [StringLength(2)]
        public string number_upper { get; set; }

        [StringLength(3)]
        public string number_three { get; set; }

        public int? Id { get; set; }

        public int? count_check { get; set; }
    }
}
