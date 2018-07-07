namespace Lottery.WebAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LTY.History_lottery")]
    public partial class History_lottery
    {
        public int Id { get; set; }

        public int user_id { get; set; }

        public int member_id { get; set; }

        [StringLength(2)]
        public string two_number_upper { get; set; }

        [StringLength(2)]
        public string two_number_lower { get; set; }

        [StringLength(3)]
        public string three_numbrt { get; set; }

        public int type_id { get; set; }

        public int Country_id { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_2 { get; set; }

        [Column(TypeName = "date")]
        public DateTime lot_dt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(3)]
        public string check { get; set; }

        [Column(TypeName = "money")]
        public decimal? member_get { get; set; }

        [Column(TypeName = "money")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? member_give { get; set; }

        [Required]
        [StringLength(3)]
        public string status { get; set; }

        public DateTime Update_dt { get; set; }

        public DateTime Create_dt { get; set; }
    }
}
