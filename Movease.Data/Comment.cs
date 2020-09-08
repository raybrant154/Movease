using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        //This is where we will put the foreign key for the movie database list

    }
}
