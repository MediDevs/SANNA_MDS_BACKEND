using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Paciente;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MDS.Api.Controllers.Test
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : BaseController
    {
        private readonly IPacienteService _pacienteService;
        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        //By William Vilca
        [HttpGet, Route("GetPacientes")]
        public async Task<IActionResult> GetPacientes()
        {
            var response = await _pacienteService.GetPacientes();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetPaciente_By_Dni")]
        public async Task<IActionResult> GetPaciente_By_Dni(string? vBusqueda, string? vValor)
        {
            var response = await _pacienteService.GetPaciente_By_Dni(vBusqueda,vValor);

            return ReturnFormattedResponse(response);
        }


        //By Henrry Torres
        [HttpGet, Route("GetPacientesFiltro")]
        public async Task<IActionResult> GetPacientesFiltro(string? busqueda, string? condicion)
        {
            var response = await _pacienteService.GetPacientesFiltro(busqueda, condicion);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetPaciente")]
        public async Task<IActionResult> GetPaciente(string pacienteId)
        {
            var response = await _pacienteService.GetPaciente(pacienteId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddPaciente")]
        public async Task<IActionResult> AddPaciente(CreatePacienteViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoPacienteDto dto = new MantenimientoPacienteDto
            {
                id_persona = model.id_persona,
                finc= model.DPAC_FINC,
                cod_par = model.SPAC_COD_PAR,
                fcre = model.DPAC_FCRE,
                bol_act = model.FPAC_BOL_ACT,
                obs = model.SPAC_OBS,
                flg_correo = model.FPAC_FLG_CORREO,
                usucre_email = model.SPAC_USUCRE_EMAIL,
                usumodif_email = model.SPAC_USUMODIF_EMAIL,
                flag_ficha = model.SPAC_FLAG_FICHA,
                flag_bloq = model.FPAC_FLAG_BLOQ,
                flag_vip = model.FPAC_FLAG_VIP,
                clasificacion = model.NPAC_CLASIFICACION,
                vip = model.SPAC_VIP,
                cod_subclasif = model.NPAC_COD_SUBCLASIF,
                fecha_vigencia = model.DPAC_FECHA_VIGENCIA,
                flg_registrar_pac_tablet = model.FPAC_FLG_REGISTRAR_PAC_TABLET,
                clave = model.FPAC_CLAVE,
                tipo_clave = model.SPAC_TIPO_CLAVE,
                obs_clave = model.SPAC_OBS_CLAVE,
                consent_informado = model.FPAC_CONSENT_INFORMADO,
                consent_recibir_info = model.FPAC_CONSENT_RECIBIR_INFO,
                consent_firma_const = model.FPAC_CONSENT_FIRMA_CONST,
                consmt_ri = model.FPAC_CONSMT_RI,
                flg_conflictivo_callmed = model.FPAC_FLG_CONFLICTIVO_CALLMED,
                flg_activo_farmacia = model.FPAC_FLG_ACTIVO_FARMACIA,
                norden_obs = model.NPAC_NORDEN_OBS,
                grupo_cronicos = model.SPAC_GRUPO_CRONICOS,
                flg_paquete_salud = model.FPAC_FLG_PAQUETE_SALUD,
                estado = model.FPAC_ESTADO,
                usuario_creacion = model.NPAC_USUARIO_CREACION,
                fecha_creacion = model.DPAC_FECHA_CREACION,
                usuario_modificacion = model.NPAC_USUARIO_MODIFICACION,
                fecha_modificacion = model.DPAC_FECHA_MODIFICACION
            };

            var response = await _pacienteService.AddPaciente(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
