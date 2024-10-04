using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blogapp.Models
{
    public class Tag
    {
        [Key]
         public long id { get; set; }

    public string name { get; set; }

    public DateTime createdAt { get; set; }

    public DateTime updatedAt { get; set; }

    public ICollection<Post> posts { get; set; }
    }
}