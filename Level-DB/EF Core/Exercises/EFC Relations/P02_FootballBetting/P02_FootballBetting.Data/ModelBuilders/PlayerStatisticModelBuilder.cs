namespace P02_FootballBetting.Data.ModelBuilders
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P02_FootballBetting.Data.Models;

    public class PlayerStatisticModelBuilder
        : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(ps => new { ps.PlayerId, ps.GameId });
        }
    }
}
