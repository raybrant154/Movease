﻿using Movease.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models.MyMovieCollectionModel
{
    public class MyMovieCollectionDetail
    {
        public int MyMovieId { get; set; }
        public string CollectionName { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
