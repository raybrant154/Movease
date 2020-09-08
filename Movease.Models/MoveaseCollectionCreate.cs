using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Models
{
    public class MoveaseCollectionCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }
    }
}
