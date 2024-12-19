using MDS.Api.Infrastructure;
using MDS.Services.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ParametrosController : BaseController
    {
        private readonly IParametroService _parametroService;

        public ParametrosController(IParametroService parametroService)
        {
            _parametroService = parametroService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetParametro")]
        public async Task<IActionResult> GetParametro(int CPAR_GRUPO_ID)
        {
            var response = await _parametroService.GetParametro(CPAR_GRUPO_ID);

            return ReturnFormattedResponse(response);
        }

    }
}
