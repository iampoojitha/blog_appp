using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapp.Models;
using Microsoft.EntityFrameworkCore; 

namespace blogapp.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Post> Posts{get;set;}

    public DbSet<Tag> tags { get; set; }

    public DbSet<Comment> comments { get; set; }
        
    }

}