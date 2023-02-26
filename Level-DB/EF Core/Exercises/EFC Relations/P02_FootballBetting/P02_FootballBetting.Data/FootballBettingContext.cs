namespace P02_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P02_FootballBetting.Data.ModelBuilders;
    using P02_FootballBetting.Data.Models;

    public class FootballBettingContext
        : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameModelBuilder());
            modelBuilder.ApplyConfiguration(new TeamModelBuilder());
            modelBuilder.ApplyConfiguration(new PlayerStatisticModelBuilder());

            base.OnModelCreating(modelBuilder);
        }
    }
}
