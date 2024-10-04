using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using blogapp.Models;

namespace blogapp.Dto
{
    public class PostDetailsDTO
    {
        [Required]
        public string title { get; set; }

        [Required]
        public string excerpt { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        public string author { get; set; }

        [Required]
        public ICollection<Tag> tags { get; set; }
    }
}
