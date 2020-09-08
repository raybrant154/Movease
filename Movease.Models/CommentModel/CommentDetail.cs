using Movease.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models
{
    public class CommentDetail
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        //This is where we will put references to the movie database list
    }
}
