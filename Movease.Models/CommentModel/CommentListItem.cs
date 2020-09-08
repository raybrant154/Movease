using Movease.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models
{
   public class CommentListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
