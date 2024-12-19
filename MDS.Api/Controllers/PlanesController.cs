using MDS.Api.Infrastructure;
using MDS.Services.Plan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PlanesController : BaseController
    {
        private readonly IPlanService _planService;

        public PlanesController(IPlanService planeService)
        {
            _planService = planeService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetPlanes")]
        public async Task<IActionResult> GetPlanes()
        {
            var response = await _planService.GetPlanes();

            return ReturnFormattedResponse(response);
        }

    }
}
