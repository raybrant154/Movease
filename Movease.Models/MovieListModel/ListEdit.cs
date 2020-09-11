using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models.MovieListModel
{
    public class ListEdit
    {
        public int ListId { get; set; }
        public int MovieId { get; set; }
        public int CollectionId { get; set; }
        public int CommentId { get; set; }
    }
}
