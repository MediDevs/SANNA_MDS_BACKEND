using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Especialidad;
using Microsoft.AspNetCore.Mvc;


namespace MDS.Api.Controllers.Test
{

    [ApiController]
    [Route("[controller]")]
    public class EspecialidadesController : BaseController
    {
        private readonly IEspecialidadService _especialidadService;

        public EspecialidadesController(IEspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }

        //By William Vilca
        [HttpGet, Route("GetEspecialidades")]
        public async Task<IActionResult> GetEspecialidades()
        {
            var response = await _especialidadService.GetEspecialidades();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetEspecialidad")]
        public async Task<IActionResult> GetEspecialidad(string especialidadId)
        {
            var response = await _especialidadService.GetEspecialidad(especialidadId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddEspecialidad")]
        public async Task<IActionResult> AddEspecialidad(CreateEspecialidadViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoEspecialidadDto dto = new MantenimientoEspecialidadDto
            {
                nombre = model.SESP_NOMBRE,
                gral_ped = model.SESP_GRAL_PED,
                cod_espr = model.SESP_COD_ESPR,
                tipo_prof_rimac = model.SESP_TIPO_PROF_RIMAC,
                abreviatura = model.SESP_ABREVIATURA,
                id_hhmm = model.SESP_ID_HHMM,
                siteds = model.SESP_SITEDS,
                cod_caract_fact = model.SESP_COD_CARACT_FACT,
                mostrar_app_mad = model.FESP_MOSTRAR_APP_MAD,
                usuario_creacion = model.NESP_USUARIO_CREACION,
                fecha_creacion = model.DESP_FECHA_CREACION,
                usuario_modificacion = model.NESP_USUARIO_MODIFICACION,
                fecha_modificacion = model.DESP_FECHA_MODIFICACION
            };

            var response = await _especialidadService.AddEspecialidad(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
