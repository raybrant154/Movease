﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models.MovieListModel
{
    public class ListCreate
    {
        public int MovieId { get; set; }
        public int CollectionId { get; set; }
        public string Comment { get; set; }
    }
}
