using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Settings;
using MDS.Services.Cliente.Implementation;
using MDS.Services.Clinica;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClinicasController : BaseController
    {
        private readonly IAppSettings _appSettings;
        private readonly IClinicaService _clinicaService;
        private readonly WebServicePostgres _webServicePostgres;

        public ClinicasController(IAppSettings appSettings, IClinicaService clinicaService)
        {
            _appSettings = appSettings;
            _clinicaService = clinicaService;
            _webServicePostgres = new WebServicePostgres();
        }

        //By Henrry Torres
        [HttpGet, Route("GetClinicas")]
        public async Task<IActionResult> GetClinicas()
        {
            var response = await _clinicaService.GetClinicas();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetClinicasFiltro")]
        public async Task<IActionResult> GetClinicasFiltro(string? busqueda, string? condicion)
        {
            var response = await _clinicaService.GetClinicasFiltro(busqueda, condicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddClinica")]
        public async Task<IActionResult> AddClinica(CreateClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            ClinicaMtoDto dto = new ClinicaMtoDto
            {
                clinica = model.clinica,
                ubigeo = model.ubigeo,
                direccion = model.direccion,
                telefono = model.telefono,
                anexo = model.anexo,
                afiliado = model.afiliado,
                estado = model.estado,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _clinicaService.AddClinica(dto);

            if (response.Success)
            {
                //Guardar en Postgres
                long pk_sql = Convert.ToInt64(response.ResultData.GetType().GetProperty("id_clinica").GetValue(response.ResultData, null));
                string uriWsPg = _appSettings.WsPostgres + "api/mae_sctr_clinica/Add";
                string estadoWsPg = _appSettings.EstadoWsPostgres;

                bool _activo = false;
                bool _flg_plan_huerfano_ilimitado = false;
                bool _flg_afiliado = false;

                if (model.estado == 1)
                {
                    _activo = true;
                }

                if (model.plan_huerfano_ilimitado == 1)
                {
                    _flg_plan_huerfano_ilimitado = true;
                }

                if (model.afiliado == "1")
                {
                    _flg_afiliado = true;
                }

                mae_sctr_clinica dto_mae_sctr_clinica = new mae_sctr_clinica
                {
                    PrimaryKey_SQL = pk_sql,
                    cod_ipress = "0",
                    descripcion_ipress = model.clinica,
                    ubigeo = model.ubigeo,
                    direccion = model.direccion,
                    telefono = model.telefono,
                    flg_afiliado = _flg_afiliado,
                    flg_plan_huerfano_ilimitado = _flg_plan_huerfano_ilimitado,
                    activo = _activo
                };

                _webServicePostgres.Consumir(uriWsPg, dto_mae_sctr_clinica, estadoWsPg);
            }

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut, Route("UpdateClinica")]
        public async Task<IActionResult> UpdateClinica(UpdateClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            ClinicaMtoDto dto = new ClinicaMtoDto
            {
                id_clinica = model.id_clinica,
                clinica = model.clinica,
                ubigeo = model.ubigeo,
                direccion = model.direccion,
                telefono = model.telefono,
                anexo = model.anexo,
                afiliado = model.afiliado,
                estado = model.estado,
                usuario_modificacion = model.usuario_modificacion
            };

            var response = await _clinicaService.UpdateClinica(dto);

            if (response.Success)
            {
                //Actualizar en Postgres
                string uriWsPg = _appSettings.WsPostgres + "api/mae_sctr_clinica/Update";
                string estadoWsPg = _appSettings.EstadoWsPostgres;

                bool _activo = false;
                bool _flg_plan_huerfano_ilimitado = false;
                bool _flg_afiliado = false;

                if (model.estado == 1)
                {
                    _activo = true;
                }

                if (model.plan_huerfano_ilimitado == 1)
                {
                    _flg_plan_huerfano_ilimitado = true;
                }

                if (model.afiliado == "1")
                {
                    _flg_afiliado = true;
                }

                mae_sctr_clinica dto_mae_sctr_clinica = new mae_sctr_clinica
                {
                    PrimaryKey_PG = model.pk_pg,
                    PrimaryKey_SQL = model.id_clinica,
                    descripcion_ipress = model.clinica,
                    ubigeo = model.ubigeo,
                    direccion = model.direccion,
                    telefono = model.telefono,
                    flg_afiliado = _flg_afiliado,
                    flg_plan_huerfano_ilimitado = _flg_plan_huerfano_ilimitado,
                    activo = _activo
                };

                _webServicePostgres.Consumir(uriWsPg, dto_mae_sctr_clinica, estadoWsPg);
            }

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteClinica")]
        public async Task<IActionResult> DeleteClinica(DeleteClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            ClinicaMtoDto dto = new ClinicaMtoDto
            {
                id_clinica = model.id_clinica,
            };

            var response = await _clinicaService.DeleteClinica(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
