using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapp.Data;
using blogapp.Models;

namespace blogapp.Repository
{
    public class TagRepository
    {
        private readonly BlogDbContext blogDbContext;

        public TagRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
            
        }
        public Tag findTagByName(string trimmedTag){
            return blogDbContext.tags.SingleOrDefault(t => t.name == trimmedTag);
        }
        
    }
}