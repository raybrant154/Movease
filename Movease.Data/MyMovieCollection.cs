using Movease.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movease
{
    public class MyMovieCollection
    {
        public int MyMovieID { get; set; }
        public string CollectionName { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }


        //public Collection<MovieOnList> { get; set; }
    }
}