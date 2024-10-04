using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapp.Data;
using blogapp.Models;
using Microsoft.EntityFrameworkCore;

namespace blogapp.Repository
{
    public class PostRepository
    {

        private readonly BlogDbContext blogDbContext;

        public PostRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public IEnumerable<Post> findAll(){
           return blogDbContext.Posts
                   .Include(post => post.tags) 
                   .ToList();
        }

        public Post findPostById(long postId){
            return blogDbContext.Posts
                  .Include(post => post.tags)
                  .FirstOrDefault(post => post.Id == postId);
        }

        public void save(Post post){

            var existingPost = blogDbContext.Posts.Find(post.Id);
            if(existingPost != null){
                blogDbContext.Entry(existingPost).CurrentValues.SetValues(post);
            }
            else{
                blogDbContext.Add(post);
            }
            blogDbContext.SaveChanges();
        }

        public void delete(long postId){
            var post = blogDbContext.Posts.Find(postId);
            if(post!=null){
                blogDbContext.Posts.Remove(post);
                blogDbContext.SaveChanges();
            }
            else{
                throw new Exception("Post not found");
            }
        }

        public void saveComment(Comment comment){
            blogDbContext.comments.Add(comment);
            blogDbContext.SaveChanges();
        }
    }
}