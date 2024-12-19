using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Blog
{
    public interface IBlogService : IService
    {

        Task<ServiceResponse> GetBlogs();
        Task<ServiceResponse> GetBlog(long blogId);
        Task<ServiceResponse> AddBlog(BlogDto dto);
        Task<ServiceResponse> UpdateBlog(BlogDto dto);
        Task<ServiceResponse> DeleteBlog(BlogDto dto);
    }
}

