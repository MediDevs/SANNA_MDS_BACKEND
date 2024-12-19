using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BlogsController : BaseController
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet, Route("GetBlogs")]
        public async Task<IActionResult> GetBlogs()
        {
            var response = await _blogService.GetBlogs();

            return ReturnFormattedResponse(response);
        }

        [HttpGet, Route("GetBlog")]
        public async Task<IActionResult> GetBlog(long blogId)
        {
            var response = await _blogService.GetBlog(blogId);

            return ReturnFormattedResponse(response);
        }

        [HttpPost, Route("AddBlog")]
        public async Task<IActionResult> AddBlog(CreateBlogViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            BlogDto dto = new BlogDto
            {
                Url = model.Url
            };

            var response = await _blogService.AddBlog(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpPut, Route("UpdateBlog")]
        public async Task<IActionResult> UpdateBlog(UpdateBlogViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            BlogDto dto = new BlogDto
            {
                Id = model.Id,
                Url = model.Url
            };

            var response = await _blogService.UpdateBlog(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpDelete, Route("DeleteBlog")]
        public async Task<IActionResult> DeleteBlog(DeleteBlogViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            BlogDto dto = new BlogDto
            {
                Id = model.Id
            };

            var response = await _blogService.DeleteBlog(dto);

            return ReturnFormattedResponse(response);
        }
    }
}
