﻿using Movease.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movease
{
    public class MyMovieCollection
    {
        [Key]
        public int MyMovieId { get; set; }
        
        [Required]
        public string CollectionName { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }


        //public ICollection<MovieOnList> { get; set; }
    }
}