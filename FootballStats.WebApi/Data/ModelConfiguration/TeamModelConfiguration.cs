using CustomFramework.Data.ModelConfiguration;
using FootballStats.WebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballStats.WebApi.Data.ModelConfiguration
{
    public class TeamModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Team
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
