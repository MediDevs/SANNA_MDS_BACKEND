using MDS.Api.Infrastructure;
using MDS.Services.Pais;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PaisController : BaseController
    {
        private readonly IPaisService _paisService;

        public PaisController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetPais")]
        public async Task<IActionResult> GetPais()
        {
            var response = await _paisService.GetPais();

            return ReturnFormattedResponse(response);
        }

    }
}
