using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movease
{
    public class MyMovies
    {
        public int MyMovieID { get; set; }
        public string ListName { get; set; }
        public string Description { get; set; }

        //[ForeignKey(using(User))]  //Does User need to be changed?
        //public int UserID { get; set; }
        //public Collection<MovieOnList> { get; set; }

    }
}