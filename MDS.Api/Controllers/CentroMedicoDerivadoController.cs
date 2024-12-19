using MDS.Api.Infrastructure;
using MDS.Services.CentroMedicoDerivado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CentroMedicoDerivadoController : BaseController
    {
        private readonly ICentroMedicoDerivadoService _centroMedicoDerivadoService;

        public CentroMedicoDerivadoController(ICentroMedicoDerivadoService centroMedicoDerivadoService)
        {
            _centroMedicoDerivadoService = centroMedicoDerivadoService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetCentroMedicoDerivadoByTipoReferencia")]
        public async Task<IActionResult> GetCentroMedicoDerivadoByTipoReferencia(int tipo_referencia)
        {
            var response = await _centroMedicoDerivadoService.GetCentroMedicoDerivadoByTipoReferencia(tipo_referencia);

            return ReturnFormattedResponse(response);
        }

    }
}
