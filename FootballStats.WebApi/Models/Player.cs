using System;
using System.Collections.Generic;
using CustomFramework.Data;
using FluentValidation.Attributes;
using FootballStats.WebApi.Validators;
using Newtonsoft.Json;

namespace FootballStats.WebApi.Models
{
    [Validator(typeof(PlayerValidator))]
    public class Player : BaseModel<int>
    {
        private DateTime _birthDate;
        public string Name { get; set; }
        public string Surname { get; set; }
      
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value.Date;
        }

        [JsonIgnore]
        public virtual ICollection<Stat> Stats { get; set; }
    }
}
