using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CustomFramework.Data;
using FluentValidation.Attributes;
using FootballStats.WebApi.Validators;
using Newtonsoft.Json;

namespace FootballStats.WebApi.Models
{
    [Validator(typeof(TeamValidator))]
    public class Team : BaseModel<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }

        [JsonIgnore]
        public List<Match> HomeMatches { get; set; }

        [JsonIgnore]
        public List<Match> AwayMatches { get; set; }

        [JsonIgnore]
        public virtual ICollection<Stat> Stats { get; set; }
    }
}
