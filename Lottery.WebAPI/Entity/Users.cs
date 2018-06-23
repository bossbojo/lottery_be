namespace Lottery.WebAPI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LTY.Users")]
    public partial class Users
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? username { get; set; }

        [Required]
        [StringLength(50)]
        public string PIN { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public string Status { get; set; }

        public int Count_Expire_day { get; set; }

        [Column(TypeName = "date")]
        public DateTime Expire_dt { get; set; }

        public DateTime Create_dt { get; set; }
    }
}
