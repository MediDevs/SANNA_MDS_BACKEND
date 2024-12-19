using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.SedeTraslado;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SedeTrasladoController : BaseController
    {
        private readonly ISedeTrasladoService _sedeTrasladoService;

        public SedeTrasladoController(ISedeTrasladoService sedeTrasladoService)
        {
            _sedeTrasladoService = sedeTrasladoService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetSedeTraslado")]
        public async Task<IActionResult> GetSedeTraslado()
        {
            var response = await _sedeTrasladoService.GetSedeTraslado();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetSedesTrasladoFiltro")]
        public async Task<IActionResult> GetSedesTrasladoFiltro(string? busqueda, string? condicion)
        {
            var response = await _sedeTrasladoService.GetSedesTrasladoFiltro(busqueda, condicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddSedeTraslado")]
        public async Task<IActionResult> AddSedeTraslado(CreateSedeTrasladoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            SedeTrasladoMtoDto dto = new SedeTrasladoMtoDto
            {
                nombre = model.nombre,
                direccion= model.direccion,
                referencia = model.referencia,
                ruc = model.ruc,
                cod_ubigeo = model.cod_ubigeo,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _sedeTrasladoService.AddSedeTraslado(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut, Route("UpdateSedeTraslado")]
        public async Task<IActionResult> UpdateSedeTraslado(UpdateSedeTrasladoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            SedeTrasladoMtoDto dto = new SedeTrasladoMtoDto
            {
                id = model.id,
                nombre = model.nombre,
                direccion = model.direccion,
                referencia= model.referencia,
                ruc = model.ruc,
                cod_ubigeo = model.cod_ubigeo,
                usuario_modificacion = model.usuario_modificacion
            };

            var response = await _sedeTrasladoService.UpdateSedeTraslado(dto);

            return ReturnFormattedResponse(response);
        }
    }
}
