using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using FootballStats.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballStats.WebApi.Data.ModelConfiguration
{
    public class StatModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Stat
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.MatchId)
                .IsRequired();

            builder.Property(p => p.TeamId)
                .IsRequired();

            builder.Property(p => p.PlayerId)
                .IsRequired();

            builder.Property(p => p.Goal)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.OwnGoal)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.PenaltyScore)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.MissedPenalty)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.Assist)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .HasOne(r => r.Match)
                .WithMany(c => (IEnumerable<T>)c.Stats)
                .HasForeignKey(r => r.MatchId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.Team)
                .WithMany(c => (IEnumerable<T>)c.Stats)
                .HasForeignKey(r => r.TeamId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.Player)
                .WithMany(c => (IEnumerable<T>)c.Stats)
                .HasForeignKey(r => r.PlayerId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder.HasIndex(p => new { p.MatchId, p.PlayerId, p.TeamId }).IsUnique();
        }
    }
}
