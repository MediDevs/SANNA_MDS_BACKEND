using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Direccion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DireccionesController : BaseController
    {
        private readonly IDireccionService _direccionService;

        public DireccionesController(IDireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        //By William Vilca
        [HttpGet, Route("GetListaDirecciones")]
        public async Task<IActionResult> GetListaDirecciones(int vIdPersona)
        {
            var response = await _direccionService.GetListaDirecciones(vIdPersona);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetDirecciones")]
        public async Task<IActionResult> GetDireccion(long CPER_ID)
        {
            var response = await _direccionService.GetDirecciones(CPER_ID);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetDireccion")]
        public async Task<IActionResult> GetDireccion(long CPER_ID, long CDIR_ID)
        {
            var response = await _direccionService.GetDireccion(CPER_ID, CDIR_ID);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddDireccion")]
        public async Task<IActionResult> AddDireccion(CreateDireccionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            DireccionDto dto = new DireccionDto
            {
                id_persona = model.id_persona,
                id_ubigeo = model.id_ubigeo,
                id_tipo_direccion = model.id_tipo_direccion,
                descripcion = model.descripcion,
                anexo = model.anexo,
                celular = model.celular,
                telefono_fijo = model.telefono_fijo,
                nro_mz_lote = model.nro_mz_lote,
                urbanizacion = model.urbanizacion,
                referencia = model.referencia,
                dpto_interior = model.dpto_interior,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _direccionService.AddDireccion(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut, Route("UpdateDireccion")]
        public async Task<IActionResult> UpdateDireccion(UpdateDireccionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            DireccionDto dto = new DireccionDto
            {
                id_direccion = model.id_direccion,
                id_persona = model.id_persona,
                id_ubigeo = model.id_ubigeo,
                id_tipo_direccion = model.id_tipo_direccion,
                descripcion = model.descripcion,
                anexo = model.anexo,
                celular = model.celular,
                telefono_fijo = model.telefono_fijo,
                nro_mz_lote = model.nro_mz_lote,
                urbanizacion = model.urbanizacion,
                referencia = model.referencia,
                dpto_interior = model.dpto_interior,
                usuario_modificacion = model.usuario_modificacion
            };

            var response = await _direccionService.UpdateDireccion(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteDireccion")]
        public async Task<IActionResult> DeleteDireccion(DeleteDireccionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            DireccionDto dto = new DireccionDto
            {
                id_persona = model.CPER_ID,
                id_direccion = model.CDIR_ID
            };

            var response = await _direccionService.DeleteDireccion(dto);

            return ReturnFormattedResponse(response);
        }
    }
}
