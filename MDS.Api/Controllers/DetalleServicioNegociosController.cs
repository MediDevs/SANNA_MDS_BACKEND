using Azure;
using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Services.DetalleServicioNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]

    public class DetalleServicioNegociosController : BaseController
    {

        private readonly IDetalleServicioNegocio _detalleservicionegocio;

        public DetalleServicioNegociosController(IDetalleServicioNegocio detalleServicioNegocio)
        {
            _detalleservicionegocio = detalleServicioNegocio;
        }

        //By William Vilca
        [HttpGet, Route("GetDetalleServicioNegocios")]
        public async Task<IActionResult> GetDetalleServicioNegocios()
        {
            var response = await _detalleservicionegocio.GetDetalleServicioNegocios();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetDetalleServicioNegocio")]
        public async Task<IActionResult> GetDetalleServicioNegocio(long detservicioId)
        {
            var response = await _detalleservicionegocio.GetDetalleServicioNegocio(detservicioId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddDetalleServicioNegocio")]
        public async Task<IActionResult> AddDetalleServicioNegocio(CreateDetalleServicioNegocioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoDetalleServicioNegocioDto dto = new MantenimientoDetalleServicioNegocioDto
            {
                id_servicio = model.CDSN_IDSERVICIO,
                nombre = model.SDSN_NOMBRE,
                estado = model.FDSN_ESTADO,
                usuario_creacion = model.NDSN_USUARIO_CREACION,
                fecha_creacion = model.DDSN_FECHA_CREACION,
                usuario_modificacion = model.NDSN_USUARIO_MODIFICACION,
                fecha_modificacion = model.DDSN_FECHA_MODIFICACION
            };

            var response = await _detalleservicionegocio.AddDetalleServicioNegocio(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
