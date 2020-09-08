using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movease
{
    public class MovieCollection
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public string CollectionDescription { get; set; }

        //[ForeignKey(using(User))]
        //public int UserID { get; set; }
        //public Collection<MovieOnList> {get; set; }

    }
}