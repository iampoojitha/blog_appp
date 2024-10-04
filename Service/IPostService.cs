using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapp.Models;

namespace blogapp.Service
{
    public interface IPostService
    {
        public void savePost(Post post,IEnumerable<string>tagNames);

        public IEnumerable<Post> getAllPosts();

        public Post getPostById(long postId);

        public void update(long postId, Post updatedPost,IEnumerable<string> updatedTags);

        public void deletePost(long postId);

        public void saveComment(Comment comment);
        
    }
}