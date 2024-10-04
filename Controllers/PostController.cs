using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapp.Data;
using blogapp.Dto;
using blogapp.Models;
using blogapp.Service;
using Microsoft.AspNetCore.Mvc;

namespace blogapp.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext blogDbContext;
        private readonly IPostService postService;
        
        public PostController(BlogDbContext blogDbContext, IPostService postService)
        {
            this.blogDbContext = blogDbContext;
            this.postService = postService;
        }



        [HttpGet]
        public IActionResult Add(){
            return View();

        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(PostDetailsDTO postDetailsDTO){

            var tagNames = Request.Form["tags"].ToString().Split(",");

            var post = new Post {
                title = postDetailsDTO.title,
                excerpt = postDetailsDTO.excerpt,
                content = postDetailsDTO.content,
                author = postDetailsDTO.author,
                tags = postDetailsDTO.tags
            };

            postService.savePost(post,tagNames);
    
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List(){
            IEnumerable<Post> posts = postService.getAllPosts() ?? new List<Post>();
            return View(posts);
        }

        [HttpGet("view/{postId}")]
        public IActionResult View(long postId){
            Post post = postService.getPostById(postId);
            if(post == null){
                return NotFound();
            }
            else{
                return View(post);
            }
            
        }

        [HttpGet("edit/{postId}")]
        public IActionResult Edit(long postId){
            Post post = postService.getPostById(postId);
            return View(post);
        }

        [HttpPost("update/{postId}")]
        public IActionResult Update(long postId, Post updatedPost){

            var updatesTags = Request.Form["tags"];
            postService.update(postId, updatedPost,updatesTags);
            return RedirectToAction("View", new { postId = postId });
        }

        [HttpPost("delete/{postId}")]
        public IActionResult Delete(long postId){
            System.Console.WriteLine("coming");
            postService.deletePost(postId);
            return RedirectToAction("List");
        }

        [HttpPost("addComment/{postId}")]
        public IActionResult AddComment(long postId, CommentDTO commentDTO){

            if(ModelState.IsValid){
                var comment = new Comment
                {
                    name = commentDTO.name,
                    email = commentDTO.email,
                    comment = commentDTO.comment
                };

                postService.saveComment(comment);
                return RedirectToAction("View", new { postId = postId });
            }
          var post = postService.getPostById(postId);
          return View("View", post);
        }
        
    }
}