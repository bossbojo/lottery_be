namespace Lottery.WebAPI.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LotteryDB : DbContext
    {
        public LotteryDB()
            : base("name=LotteryDB")
        {
        }

        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<History_lottery> History_lottery { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MoneyIncom> MoneyIncom { get; set; }
        public virtual DbSet<Type_play> Type_play { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<v_LotteryHistory> v_LotteryHistory { get; set; }
    }
}
