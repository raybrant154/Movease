using Movease.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models
{
    public class MyMovieCollectionCreate
    {
        public int UserId { get; set; }
        public string CollectionName { get; set; }
        public string Description { get; set; }
    }
}
