using System.Collections.Generic;
using System.Linq;
using FootballStats.WebSite.Enums;
using FootballStats.WebSite.Utils;

namespace FootballStats.WebSite.Models
{
    public class Statistic
    {
        private readonly IList<StatisticDetail> _statisticDetails;
        public Statistic(IList<StatisticDetail> statisticDetails)
        {
            _statisticDetails = statisticDetails;

            TotalGoals = new List<TopResult>();
            TotalPositionGoal = new List<TopResult>();
            TotalPenaltyGoal = new List<TopResult>();
            TotalMissedPenalty = new List<TopResult>();
            TotalAssist = new List<TopResult>();
            TotalWin = new List<TopResult>();
            TotalLoose = new List<TopResult>();
            TotalOwnGoal = new List<TopResult>();

            PerMatchTotalGoal = new List<TopResult>();
            PerMatchPositionGoal = new List<TopResult>();
            PerMatchAssist = new List<TopResult>();
            PerMatchPenaltyGoal = new List<TopResult>();
            PerMatchMissedPenalty = new List<TopResult>();
            PerMatchOwnGoal = new List<TopResult>();

            RatioWin = new List<TopResult>();
            RatioLoose = new List<TopResult>();

            PenaltyRatio = new List<TopResult>();

            SetTotalGoals();
            SetTotalPositionGoal();
            SetTotalPenaltyGoal();
            SetTotalMissedPenalty();
            SetTotalAssist();
            SetTotalOwnGoal();
            SetTotalWin();
            SetTotalLoose();
            SetPerMatchTotalGoal();
            SetPerMatchPositionGoal();
            SetPerMatchAssist();
            SetPerMatchPenaltyGoal();
            SetPerMatchMissedPenalty();
            SetPerMatchOwnGoal();
            SetRatioWin();
            SetRatioLoose();
            SetPenaltyRatio();
        }

        public List<TopResult> TotalGoals { get; private set; }

        private void SetTotalGoals()
        {
            TotalGoals = (from p in _statisticDetails
                          orderby p.TotalGoal descending, p.MatchCount ascending, p.Player.Name ascending
                          select new TopResult
                          {
                              PlayerId = p.Player.Id,
                              Name = $"{p.Player.Name} {p.Player.Surname}",
                              Result = p.TotalGoal,
                              MatchCount = p.MatchCount,
                          }).Take(5).ToList();
        }

        public List<TopResult> TotalPositionGoal { get; private set; }

        private void SetTotalPositionGoal()
        {
            TotalPositionGoal = (from p in _statisticDetails
                                 orderby p.TotalStatDetail.Goal descending, p.MatchCount ascending, p.Player.Name ascending
                                 select new TopResult
                                 {
                                     PlayerId = p.Player.Id,
                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                     Result = p.TotalStatDetail.Goal,
                                     MatchCount = p.MatchCount,
                                 }).Take(5).ToList();
        }

        public List<TopResult> TotalPenaltyGoal { get; private set; }

        private void SetTotalPenaltyGoal()
        {
            TotalPenaltyGoal = (from p in _statisticDetails
                                orderby p.TotalStatDetail.PenaltyScore descending, p.MatchCount ascending, p.Player.Name ascending
                                select new TopResult
                                {
                                    PlayerId = p.Player.Id,
                                    Name = $"{p.Player.Name} {p.Player.Surname}",
                                    Result = p.TotalStatDetail.PenaltyScore,
                                    MatchCount = p.MatchCount,
                                }).Take(5).ToList();
        }

        public List<TopResult> TotalMissedPenalty { get; private set; }

        private void SetTotalMissedPenalty()
        {
            TotalMissedPenalty = (from p in _statisticDetails
                                  orderby p.TotalStatDetail.MissedPenalty descending, p.MatchCount ascending, p.Player.Name ascending
                                  select new TopResult
                                  {
                                      PlayerId = p.Player.Id,
                                      Name = $"{p.Player.Name} {p.Player.Surname}",
                                      Result = p.TotalStatDetail.MissedPenalty,
                                      MatchCount = p.MatchCount,
                                  }).Take(5).ToList();
        }

        public List<TopResult> TotalAssist { get; private set; }

        private void SetTotalAssist()
        {
            TotalAssist = (from p in _statisticDetails
                           orderby p.TotalStatDetail.Assist descending, p.MatchCount ascending, p.Player.Name ascending
                           select new TopResult
                           {
                               PlayerId = p.Player.Id,
                               Name = $"{p.Player.Name} {p.Player.Surname}",
                               Result = p.TotalStatDetail.Assist,
                               MatchCount = p.MatchCount,
                           }).Take(5).ToList();
        }

        public List<TopResult> TotalOwnGoal { get; private set; }

        private void SetTotalOwnGoal()
        {
            TotalOwnGoal = (from p in _statisticDetails
                orderby p.TotalStatDetail.OwnGoal descending, p.MatchCount ascending, p.Player.Name ascending
                select new TopResult
                {
                    PlayerId = p.Player.Id,
                    Name = $"{p.Player.Name} {p.Player.Surname}",
                    Result = p.TotalStatDetail.OwnGoal,
                    MatchCount = p.MatchCount,
                }).Take(5).ToList();
        }


        public List<TopResult> TotalWin { get; private set; }

        private void SetTotalWin()
        {
            TotalWin = (from p in _statisticDetails
                        orderby p.MatchForms.Count(m => m == (MatchScore.Win)) descending, p.MatchCount ascending, p.Player.Name ascending
                        select new TopResult
                        {
                            PlayerId = p.Player.Id,
                            Name = $"{p.Player.Name} {p.Player.Surname}",
                            Result = p.MatchForms.Count(m => m == (MatchScore.Win)),
                            MatchCount = p.MatchCount,
                        }).Take(5).ToList();
        }

        public List<TopResult> TotalLoose { get; private set; }

        private void SetTotalLoose()
        {
            TotalLoose = (from p in _statisticDetails
                          orderby p.MatchForms.Count(m => m == (MatchScore.Loose)) descending, p.MatchCount ascending, p.Player.Name ascending
                          select new TopResult
                          {
                              PlayerId = p.Player.Id,
                              Name = $"{p.Player.Name} {p.Player.Surname}",
                              Result = p.MatchForms.Count(m => m == (MatchScore.Loose)),
                              MatchCount = p.MatchCount,
                          }).Take(5).ToList();
        }

        public List<TopResult> PerMatchTotalGoal { get; private set; }

        private void SetPerMatchTotalGoal()
        {
            PerMatchTotalGoal = (from p in _statisticDetails
                                 orderby p.PerMatchTotalGoal descending, p.MatchCount ascending, p.Player.Name ascending
                                 select new TopResult
                                 {
                                     PlayerId = p.Player.Id,
                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                     Result = p.PerMatchTotalGoal.RoundValue(),
                                     MatchCount = p.MatchCount,
                                 }).Take(5).ToList();
        }

        public List<TopResult> PerMatchPositionGoal { get; private set; }

        private void SetPerMatchPositionGoal()
        {
            PerMatchPositionGoal = (from p in _statisticDetails
                                 orderby p.PerMatchPositionGoal descending, p.MatchCount ascending, p.Player.Name ascending
                                 select new TopResult
                                 {
                                     PlayerId = p.Player.Id,
                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                     Result = p.PerMatchPositionGoal.RoundValue(),
                                     MatchCount = p.MatchCount,
                                 }).Take(5).ToList();
        }

        public List<TopResult> PerMatchAssist { get; private set; }

        private void SetPerMatchAssist()
        {
            PerMatchAssist = (from p in _statisticDetails
                              orderby p.PerMatchStatDetail.Assist descending, p.MatchCount ascending, p.Player.Name ascending
                              select new TopResult
                              {
                                  PlayerId = p.Player.Id,
                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                  Result = p.PerMatchStatDetail.Assist.RoundValue(),
                                  MatchCount = p.MatchCount,
                              }).Take(5).ToList();
        }

        public List<TopResult> PerMatchPenaltyGoal { get; private set; }

        private void SetPerMatchPenaltyGoal()
        {
            PerMatchPenaltyGoal = (from p in _statisticDetails
                                   orderby p.PerMatchStatDetail.PenaltyScore descending, p.MatchCount ascending, p.Player.Name ascending
                                   select new TopResult
                                   {
                                       PlayerId = p.Player.Id,
                                       Name = $"{p.Player.Name} {p.Player.Surname}",
                                       Result = p.PerMatchStatDetail.PenaltyScore.RoundValue(),
                                       MatchCount = p.MatchCount,
                                   }).Take(5).ToList();
        }

        public List<TopResult> PerMatchMissedPenalty { get; private set; }

        private void SetPerMatchMissedPenalty()
        {
            PerMatchMissedPenalty = (from p in _statisticDetails
                                     orderby p.PerMatchStatDetail.MissedPenalty descending, p.MatchCount ascending, p.Player.Name ascending
                                     select new TopResult
                                     {
                                         PlayerId = p.Player.Id,
                                         Name = $"{p.Player.Name} {p.Player.Surname}",
                                         Result = p.PerMatchStatDetail.MissedPenalty.RoundValue(),
                                         MatchCount = p.MatchCount,
                                     }).Take(5).ToList();
        }

        public List<TopResult> PerMatchOwnGoal { get; private set; }

        private void SetPerMatchOwnGoal()
        {
            PerMatchOwnGoal = (from p in _statisticDetails
                                     orderby p.PerMatchStatDetail.OwnGoal descending, p.MatchCount ascending, p.Player.Name ascending
                                     select new TopResult
                                     {
                                         PlayerId = p.Player.Id,
                                         Name = $"{p.Player.Name} {p.Player.Surname}",
                                         Result = p.PerMatchStatDetail.OwnGoal.RoundValue(),
                                         MatchCount = p.MatchCount,
                                     }).Take(5).ToList();
        }

        public List<TopResult> RatioWin { get; private set; }

        private void SetRatioWin()
        {
            RatioWin = (from p in _statisticDetails
                        orderby p.WinRatio descending, p.MatchCount ascending, p.Player.Name ascending
                        select new TopResult
                        {
                            PlayerId = p.Player.Id,
                            Name = $"{p.Player.Name} {p.Player.Surname}",
                            Result = p.WinRatio.RoundValue(),
                            MatchCount = p.MatchCount,
                        }).Take(5).ToList();
        }

        public List<TopResult> RatioLoose { get; private set; }

        private void SetRatioLoose()
        {
            RatioLoose = (from p in _statisticDetails
                          orderby p.LooseRatio descending, p.MatchCount ascending, p.Player.Name ascending
                          select new TopResult
                          {
                              PlayerId = p.Player.Id,
                              Name = $"{p.Player.Name} {p.Player.Surname}",
                              Result = p.LooseRatio.RoundValue(),
                              MatchCount = p.MatchCount,
                          }).Take(5).ToList();
        }

        public List<TopResult> PenaltyRatio { get; private set; }

        private void SetPenaltyRatio()
        {
            PenaltyRatio = (from p in _statisticDetails
                            orderby p.PenaltyRatio descending, p.MatchCount ascending, p.Player.Name ascending
                            select new TopResult
                            {
                                PlayerId = p.Player.Id,
                                Name = $"{p.Player.Name} {p.Player.Surname}",
                                Result = p.PenaltyRatio.RoundValue(),
                                MatchCount = p.MatchCount,
                            }).Take(5).ToList();
        }
    }
}
