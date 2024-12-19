using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Settings;
using MDS.Services.Seguimiento;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SeguimientosController : BaseController
    {
        private readonly IAppSettings _appSettings;
        private readonly ISeguimientoService _seguimientoService;
        private readonly WebServicePostgres _webServicePostgres;


        public SeguimientosController(IAppSettings appSettings, ISeguimientoService seguimientoService)
        {
            _appSettings = appSettings;
            _seguimientoService = seguimientoService;
            _webServicePostgres = new WebServicePostgres();
        }

        //By Henrry Torres
        [HttpGet, Route("GetSeguimientoByHistoriaClinica")]
        public async Task<IActionResult> GetSeguimientoByHistoriaClinica(string codHistoriaClinica)
        {
            var response = await _seguimientoService.GetSeguimientoByHistoriaClinica(codHistoriaClinica);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddSeguimientoSctr")]
        public async Task<IActionResult> AddSeguimientoSctr(CreateSeguimientoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            SeguimientoDto dto = new SeguimientoDto
            {
                cod_historia_clinica = model.cod_historia_clinica,
                observacion = model.observacion,
                cod_servicio = model.id_servicio,
                usuario = model.usuario
            };

            var response = await _seguimientoService.AddSeguimientoSctr(dto);

            if (response.Success)
            {
                string uriWsPg;
                string estadoWsPg = _appSettings.EstadoWsPostgres;

                //REGISTRAR SEGUIMIENTO ATENCION SCTR
                m_segatenciones dto_m_segatenciones = new m_segatenciones
                {
                    PrimaryKey_SQL = Convert.ToInt64(response.ResultData.GetType().GetProperty("cod_seguimiento").GetValue(response.ResultData, null)),
                    cod_ate = Int64.Parse(model.cod_historia_clinica),
                    obs_ser = model.observacion,
                    des_ser = model.id_servicio.ToString(),
                    Codigo_Usuario_PG = model.usuario_creacion_pg
                };

                uriWsPg = _appSettings.WsPostgres + "api/m_segatenciones/Add";

                _webServicePostgres.Consumir(uriWsPg, dto_m_segatenciones, estadoWsPg);
            }

            return ReturnFormattedResponse(response);
        }

    }
}
