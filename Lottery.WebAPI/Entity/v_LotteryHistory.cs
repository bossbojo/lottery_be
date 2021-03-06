namespace Lottery.WebAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LTY.v_LotteryHistory")]
    public partial class v_LotteryHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int member_id { get; set; }

        [StringLength(3)]
        public string number { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int type { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country_id { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_2 { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime lot_dt { get; set; }

        [StringLength(3)]
        public string check { get; set; }

        [Column(TypeName = "money")]
        public decimal? member_get { get; set; }

        [Column(TypeName = "money")]
        public decimal? member_give { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(3)]
        public string status { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime Update_dt { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime Create_dt { get; set; }

        [StringLength(50)]
        public string country_name { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
