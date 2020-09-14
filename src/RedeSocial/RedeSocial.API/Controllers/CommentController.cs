using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.API.Domain;
using RedeSocial.API.Services;
using RedeSocial.Repository.Context;

namespace RedeSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService commentService;

        public CommentController(RedeSocialContext context)
        {
            commentService = new CommentService(context);
        }
        
        
        [HttpGet]
        public ActionResult GetAllPostComment()
        {
            var comments = commentService.GetAllPostComment();
            return Ok(comments);
        }

        [HttpPost]
        public ActionResult CreatePost([FromBody] CommentRequest comment)
        {
            commentService.Create(comment);
            return Ok("Comentário criado com Sucesso");
        }
    }
}