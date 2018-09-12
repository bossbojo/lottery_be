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

        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<History_lottery> History_lottery { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MoneyIncom> MoneyIncoms { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Type_play> Type_play { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<v_LotteryHistory> v_LotteryHistory { get; set; }
        public virtual DbSet<v_CheckLottery> v_CheckLottery { get; set; }
    }
}
