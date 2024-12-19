using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.ServicioNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ServicioNegociosController : BaseController
    {
        private readonly IServicioNegocio _servicionegocio;

        public ServicioNegociosController(IServicioNegocio ServicioNegocio)
        {
            _servicionegocio = ServicioNegocio;
        }

        //By William Vilca
        [HttpGet, Route("GetServicioNegocios")]
        public async Task<IActionResult> GetServicioNegocios()
        {
            var response = await _servicionegocio.GetServicioNegocios();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetServicioNegocio")]
        public async Task<IActionResult> GetServicioNegocio(long servicioId)
        {
            var response = await _servicionegocio.GetServicioNegocio(servicioId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddServicioNegocio")]
        public async Task<IActionResult> AddServicioNegocio(CreateServicioNegocioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoServicioNegocioDto dto = new MantenimientoServicioNegocioDto
            {

                nombre = model.SSER_NOMBRE,
                grupo = model.SSER_GRUPO,
                uni_negocio = model.NSER_UNI_NEGOCIO,
                tipo_operacion_precisa = model.NSER_TIPO_OPERACION_PRECISA,
                onbase_subtipo_atencion = model.SSER_ONBASE_SUBTIPO_ATENCION,
                unccscl = model.NSER_UNCCSCL,
                negocio_facturacion = model.SSER_NEGOCIO_FACTURACION,
                programa_app = model.NSER_PROGRAMA_APP,
                estado = model.FSER_ESTADO,
                usuario_creacion = model.NSER_USUARIO_CREACION,
                fecha_creacion = model.DSER_FECHA_CREACION,
                usuario_modificacion = model.NSER_USUARIO_MODIFICACION,
                fecha_modificacion = model.DSER_FECHA_MODIFICACION
            };

            var response = await _servicionegocio.AddServicioNegocio(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
