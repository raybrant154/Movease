using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Data
{
    public class MovieOnList
    {
        [Key]
        public int ListId { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey(nameof(MyMoviesCollection))]
        public int CollectionId { get; set; }
        public virtual MyMovieCollection MyMoviesCollection { get; set; }
        public string Comment { get; set; }

    }
}
