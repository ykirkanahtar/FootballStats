﻿using System;
using System.Collections.Generic;
using CustomFramework.Data;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using FootballStats.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballStats.WebApi.Data.Seeding
{
    public class SeedWebApiData
    {
        public SeedWebApiData()
        {
            Matches = new List<Match>();
            Teams = new List<Team>();
            Players = new List<Player>();
            Stats = new List<Stat>();
        }

        public IList<Match> Matches { get; set; }
        public IList<Team> Teams { get; set; }
        public IList<Player> Players { get; set; }
        public IList<Stat> Stats { get; set; }

        public void SeedMatchData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Match, int>(modelBuilder, Matches);
        }

        public void SeedTeamData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Team, int>(modelBuilder, Teams);
        }

        public void SeedPlayerData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Player, int>(modelBuilder, Players);
        }

        public void SeedStatData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Stat, int>(modelBuilder, Stats);
        }

        public void SeedAll(ModelBuilder modelBuilder)
        {
            SeedMatchData(modelBuilder);
            SeedTeamData(modelBuilder);
            SeedPlayerData(modelBuilder);
            SeedStatData(modelBuilder);
        }
    }
}