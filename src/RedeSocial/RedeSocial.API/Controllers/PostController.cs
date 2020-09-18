using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.API.Domain;
using RedeSocial.Repository.Context;
using PostService = RedeSocial.API.Services.PostService;

namespace RedeSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService postService;

        public PostController(RedeSocialContext context)
        {
            postService = new PostService(context);
        }

        [HttpGet]
        public ActionResult GetAllPosts()
        {
            var posts = postService.GetAllPosts().OrderByDescending(x => x.PublishDateTime);
            return Ok(posts);
        }

        [HttpPost]
        public ActionResult CreatePost([FromBody] PostRequest post)
        {
            postService.Create(post);
            return Ok("Post criado com Sucesso");
        }
        
        [Route("get")]
        [HttpPost]
        public ActionResult GetPostById([FromBody] Guid idPost)
        {
            var post = postService.GetPostById(idPost);
            return Ok(post);
        }
    }
}