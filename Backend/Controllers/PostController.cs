using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [Route("api/posts/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => await _postsService.Get();
    }
}
