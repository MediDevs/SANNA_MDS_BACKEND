using MDS.Api.Infrastructure;
using MDS.Services.Alerta;
using MDS.Services.Blog;
using MDS.Services.Blog.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.GestionPacientes
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : BaseController
    {
        private readonly IAlertaService _alertaService;
        public AlertaController(IAlertaService alertaService)
        {
            _alertaService = alertaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlertas()
        {
            var response = await _alertaService.GetAlertas();

            return ReturnFormattedResponse(response);
        }
    }
}
