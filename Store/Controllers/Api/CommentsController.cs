using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Business.Interfaces;
using Store.Contracts;
using Store.Contracts.Dtos;
using Store.Models;

namespace Store.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;   
        }
        // GET: api/<NewsController>
        [HttpGet("find")]
        public async Task<PagedResponseModel<CommentsDto>> GetAllNewsAsync([FromRoute]PageFilter filter)
        {
            return await _commentService.GetAllCommentByNewsAsync(filter);
        }

        // GET api/<NewsController>/5
        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult> AddCommment(AddCommentDto addComment)
        {
            if(ModelState.IsValid)
            { 
                await _commentService.AddAsync(addComment);
                return Ok();

            }
            return StatusCode(500, "Error");
        }
        [Authorize]
        [HttpPost("edit")]
        public async Task<ActionResult> AddCommment(EditCommentDto editComment)
        {
            var UserId = new Guid(User.Claims.FirstOrDefault(x => x.Type == "sub").Value);
            if (ModelState.IsValid&&UserId== editComment.UserId)
            {
                await _commentService.UpdateAsync(editComment);
                return Ok();

            }
            return StatusCode(500, "Error");
        }
    }
}
