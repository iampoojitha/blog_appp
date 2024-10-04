using blogapp.Data;
using blogapp.Dto;
using blogapp.Models;
using blogapp.Repository;
using Microsoft.EntityFrameworkCore;
namespace blogapp.Service.impl
{
    public class PostServiceImpl : IPostService
    {

        private readonly BlogDbContext blogDbContext;
        private readonly PostRepository postRepository;

        private readonly TagRepository tagRepository;

        public PostServiceImpl(BlogDbContext blogDbContext,PostRepository postRepository,TagRepository tagRepository)
        {
            this.blogDbContext = blogDbContext;
            this.postRepository = postRepository;
            this.tagRepository = tagRepository;
            
        }

        public void deletePost(long postId)
        {
            postRepository.delete(postId);
        }

        public IEnumerable<Post> getAllPosts()
        {
            return postRepository.findAll();
        }

        public Post getPostById(long postId)
        {
            return postRepository.findPostById(postId);
        }

        public void saveComment(Comment comment)
        {
            postRepository.saveComment(comment);
        }

        public void savePost(Post post,IEnumerable<string> tagNames)
        {
            
            post.isPublished = true;
            post.createdAt = DateTime.UtcNow;
            post.publishedAt = DateTime.UtcNow;
            post.updatedAt = DateTime.UtcNow;

            var tagSet = new HashSet<Tag>();

            if(tagNames!=null){
                foreach(var tagName in tagNames){
                    var trimmedTag = tagName.Trim();
                    if(!string.IsNullOrWhiteSpace(trimmedTag)){
                        var tag = tagRepository.findTagByName(trimmedTag);
                        if(tag==null){
                            tag = new Tag
                            {
                                name = trimmedTag,
                                createdAt = DateTime.UtcNow,
                                updatedAt = DateTime.UtcNow

                            };
                            blogDbContext.Add(tag);
                        }

                        tagSet.Add(tag);


                    }
                }

            }
            post.tags = tagSet;

            postRepository.save(post);

        }

        public void update(long postId, Post updatedPost,IEnumerable<string> updatedTags)
        {
            Post oldPost = postRepository.findPostById(postId);
              if (oldPost == null)
             {
                throw new Exception("Post not found");
             }
             var updatedSet = new HashSet<Tag>();
            if (oldPost != null)
            {
                oldPost.title = updatedPost.title;
                oldPost.excerpt = updatedPost.excerpt;
                oldPost.content = updatedPost.content;
                oldPost.author = updatedPost.author;
                oldPost.updatedAt = DateTime.UtcNow;

                if(updatedTags != null){
                   foreach (var tagName in updatedTags){
                        var trimmedTag = tagName.Trim();
                        var tag = tagRepository.findTagByName(trimmedTag);
                        if(tag==null){
                            tag = new Tag
                            {
                                name = trimmedTag,
                                updatedAt = DateTime.UtcNow,
                                createdAt = DateTime.UtcNow
                            };
                             blogDbContext.Add(tag);
                        }
                        updatedSet.Add(tag);
                       
                   }
                    
                }
            }
            oldPost.tags = updatedSet;
            postRepository.save(oldPost);
        }
    }
}