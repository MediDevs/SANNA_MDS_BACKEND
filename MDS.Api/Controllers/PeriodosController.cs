using Azure;
using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Services;
using MDS.Services.Periodo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PeriodosController : BaseController
    {
        private readonly IPeriodoService _periodoService;

        public PeriodosController(IPeriodoService periodoService)
        {
            _periodoService = periodoService;
        }

        //By William Vilca
        [HttpGet, Route("GetPeriodos")]
        public async Task<IActionResult> GetPeriodos()
        {
            var response = await _periodoService.GetPeriodos();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetPeriodo")]
        public async Task<IActionResult> GetPeriodo(long periodoId)
        {
            var response = await _periodoService.GetPeriodo(periodoId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddPeriodo")]
        public async Task<IActionResult> AddPeriodo(CreatePeriodoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            PeriodoDto dto = new PeriodoDto
            {
                Nombre = model.Nombre,
                Estado = model.Estado
            };

            var response = await _periodoService.AddPeriodo(dto);

            return ReturnFormattedResponse(response);
        }

    }
}