using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blogapp.Models
{
    public class Post
    {
        [Key]  // Mark this as the primary key
    public long? Id { get; set; }  

    public string title { get; set; }

    public string excerpt { get; set; }

    public string content { get; set; }

    public string author { get; set; }

    public DateTime createdAt { get; set; }

    public DateTime publishedAt { get; set; }

    public bool isPublished { get; set; }

    public DateTime updatedAt { get; set; }

    public ICollection<Tag> tags { get; set; }

    public ICollection<Comment> comments { get; set; }
    
    }
        
    
}