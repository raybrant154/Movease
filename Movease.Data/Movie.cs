using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Data
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Rated")]
        public string Rated { get; set; }

        [JsonProperty("Runtime")]
        public string Runtime { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Writer")]
        public string Writer { get; set; }

        [JsonProperty("Actors")]
        public string Actors { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Awards")]
        public string Awards { get; set; }

        
    }
}
