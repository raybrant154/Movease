using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models
{
    public class MyMoviesCollection
    {
        public int CollectionId { get; set; }
        public string CollectionTitle { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }    //Not entirely sure this is needed, may need editing.
    }
}
