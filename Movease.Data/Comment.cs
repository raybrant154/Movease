using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Data
{
    public class Comment
    {
        
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey(nameof(User))]  
        public int UserId { get; set; }
        public virtual User User { get; set; }

        //This is where we will put the foreign key for the movie database list

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
