using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.MedicoParticular;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace MDS.Api.Controllers.Test
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoParticularesController : BaseController
    {

        private readonly IMedicoParticularService _medicoparticularService;
        public MedicoParticularesController(IMedicoParticularService medicoparticularService)
        {
            _medicoparticularService = medicoparticularService;
        }

        //By William Vilca
        [HttpGet, Route("GetMedicoParticulares")]
        public async Task<IActionResult> GetMedicoParticulares()
        {
            var response = await _medicoparticularService.GetMedicoParticulares();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetMedicoParticular")]
        public async Task<IActionResult> GetMedicoParticular(long medicoId)
        {
            var response = await _medicoparticularService.GetMedicoParticular(medicoId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddMedicoParticular")]
        public async Task<IActionResult> AddMedicoParticular(CreateMedicoParticularViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoMedicoParticularDto dto = new MantenimientoMedicoParticularDto
            {

                descripcion = model.SMED_DESCRIPCION,
                telefono = model.SMED_TELEFONO,
                email = model.SMED_EMAIL,
                email_culminacion = model.SMED_EMAIL_CULMINACION,
                enviar_email = model.FMED_ENVIAR_EMAIL,
                flg_proveedor_drmas = model.FMED_FLG_PROVEEDOR_DRMAS,
                nom_usu = model.SMED_NOM_USU,
                flg_visible_prov_seg_covid = model.FMED_FLG_VISIBLE_PROV_SEG_COVID,
                estado = model.FMED_ESTADO,
                usuario_creacion = model.NMED_USUARIO_CREACION,
                fecha_creacion = model.DMED_FECHA_CREACION,
                usuario_modificacion = model.NMED_USUARIO_MODIFICACION,
                fecha_modificacion = model.DMED_FECHA_MODIFICACION
            };

            var response = await _medicoparticularService.AddMedicoParticular(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
