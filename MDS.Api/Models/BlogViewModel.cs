using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateBlogViewModel
    {
        [Required]
        public string Url { get; set; }
    }
    public class UpdateBlogViewModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Url { get; set; }
    }
    public class DeleteBlogViewModel
    {
        [Required]
        public long Id { get; set; }
    }
}
