using Azure;
using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Services;
using MDS.Services.Medico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : BaseController
    {

        private readonly IMedicoService _medicoService;
        public MedicosController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        //By William Vilca
        [HttpGet, Route("GetMedicos")]
        public async Task<IActionResult> GetMedicos()
        {
            var response = await _medicoService.GetMedicos();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetMedico")]
        public async Task<IActionResult> GetMedico(long medicoId)
        {
            var response = await _medicoService.GetMedico(medicoId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddMedico")]
        public async Task<IActionResult> AddMedico(CreateMedicoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoMedicoDto dto = new MantenimientoMedicoDto
            {
                id_persona = model.CPER_ID,
                id_servicionegocio = model.CSER_IDSERVICIO_NEGOCIO,
                id_medicoparticular = model.CPAR_IDMEDICO_PARTICULAR,
                id_especialiadad = model.CESP_IDESPECIALIDAD,
                id_banco = model.CBAN_IDBANCO,
                beeper = model.SMED_BEEPER,
                zona = model.SMED_ZONA,
                yo = model.FMED_YO,
                cod_use = model.SMED_COD_USE,
                factura = model.SMED_FACTURA,
                pago = model.NMED_PAGO,
                cmp = model.SMED_CMP,
                turno = model.NMED_TURNO,
                pago_noche = model.NMED_PAGO_NOCHE,
                inicio_guardia_noche = model.DMED_INICIO_GUARDIA_NOCHE,
                fin_guardia_noche = model.DMED_FIN_GUARDIA_NOCHE,
                mensaje = model.FMED_MENSAJE,
                maxisalud = model.FMED_MAXISALUD,
                numero = model.SMED_NUMERO,
                login = model.SMED_LOGIN,
                ruc = model.SMED_RUC,
                cuenta_bancaria = model.SMED_CUENTA_BANCARIA,
                sap_glf_registrado = model.FMED_SAP_GLF_REGISTRADO,
                id_doc_id = model.NMED_ID_DOC_ID,
                pago_hhmm = model.FMED_PAGO_HHMM,
                registrado_hhmm = model.FMED_REGISTRADO_HHMM,
                encargado_ekg = model.FMED_ENCARGADO_EKG,
                lector_ekg = model.FMED_LECTOR_EKG,
                dronline = model.FMED_DRONLINE,
                melchorita = model.FMED_MELCHORITA,
                last_login = model.NMED_LAST_LOGIN,
                envio_disponibilidad = model.FMED_ENVIO_DISPONIBILIDAD,
                teleconsulta_covid = model.FMED_TELECONSULTA_COVID,
                telemedicina = model.FMED_TELEMEDICINA,
                alicorp = model.FMED_ALICORP,
                conductor_asociado = model.SMED_CODUCTOR_ASOCIADO,
                estado = model.FMED_ESTADO,
                usuario_creacion = model.NMED_USUARIO_CREACION,
                fecha_creacion = model.DMED_FECHA_CREACION,
                usuario_modificacion = model.NMED_USUARIO_MODIFICACION,
                fecha_modificacion = model.DMED_FECHA_MODIFICACION
            };

            var response = await _medicoService.AddMedico(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
