using MDS.Api.Infrastructure;
using MDS.Services.Motivo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MotivosController : BaseController
    {
        private readonly IMotivoService _motivoService;

        public MotivosController(IMotivoService motivoService)
        {
            _motivoService = motivoService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetMotivos")]
        public async Task<IActionResult> GetMotivos()
        {
            var response = await _motivoService.GetMotivos();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetMotivosByTipoAndPase")]
        public async Task<IActionResult> GetMotivosByTipoAndPase(int NMOT_TIPO_ATENCION, int NMOT_TIPO_PASE)
        {
            var response = await _motivoService.GetMotivosByTipoAndPase(NMOT_TIPO_ATENCION, NMOT_TIPO_PASE);

            return ReturnFormattedResponse(response);
        }

    }
}
