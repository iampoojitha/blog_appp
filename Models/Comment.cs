using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blogapp.Models
{
    public class Comment
    {
        [Key]
         public long Id { get; set; }
    public string name { get; set; }

    public string email { get; set; }

    public string comment { get; set; }

    public Post post  { get; set; }
    }
}