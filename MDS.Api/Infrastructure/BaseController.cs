using Microsoft.AspNetCore.Mvc;
using MDS.Api.Utility.Extensions;
using MDS.Infrastructure.Helper;

namespace MDS.Api.Infrastructure
{
    public class BaseController : ControllerBase
    {
        public long CurrentUserId => this.HttpContext.GetCurrentUserId();

        [NonAction] 
        internal async Task<Stream> GetFileStream(string filePath)
        {
            var fileContents = new FileStream(filePath, FileMode.Open);
            return fileContents;
        }

        [NonAction]
        internal IActionResult ReturnFormattedResponse(ServiceResponse response)
        {
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(response.StatusCode, response);
        }
    }
}
