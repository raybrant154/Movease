using Movease.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models
{
    public class MyMovieCollectionListItem
    {
        public int MyMovieId { get; set; }
        public string CollectionName { get; set; }
        public string Description { get; set; }

    }
}
