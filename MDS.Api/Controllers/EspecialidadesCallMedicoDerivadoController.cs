using MDS.Api.Infrastructure;
using MDS.Services.CentroMedicoDerivado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EspecialidadesCallMedicoController : BaseController
    {
        private readonly IEspecialidadCallMedicoService _especialidadCallMedicoService;

        public EspecialidadesCallMedicoController(IEspecialidadCallMedicoService especialidadCallMedicoService)
        {
            _especialidadCallMedicoService = especialidadCallMedicoService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetEspecialidadCallMedicoByCentroMedico")]
        public async Task<IActionResult> GetEspecialidadCallMedicoByCentroMedico(int id_centro_medico)
        {
            var response = await _especialidadCallMedicoService.GetEspecialidadCallMedicoByCentroMedico(id_centro_medico);

            return ReturnFormattedResponse(response);
        }

    }
}
