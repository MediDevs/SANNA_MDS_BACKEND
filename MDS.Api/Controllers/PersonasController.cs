using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Settings;
using MDS.Services.Persona;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MDS.Api.Controllers.Test
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : BaseController
    {
        private readonly IAppSettings _appSettings;
        private readonly IPersonaService _personaService;
        private readonly WebServicePostgres _webServicePostgres;

        public PersonaController(IAppSettings appSettings, IPersonaService personaService)
        {
            _appSettings = appSettings;
            _personaService = personaService;
            _webServicePostgres = new WebServicePostgres();
        }

        //By William Vilca
        [HttpGet, Route("GetPersonas")]
        public async Task<IActionResult> GetPersonas()
        {
            var response = await _personaService.GetPersonas();

            return ReturnFormattedResponse(response);
        }
        //By William Vilca
        [HttpGet, Route("GetPersonaCodigo")]
        public async Task<IActionResult> GetPersonaCodigo()
        {
            var response = await _personaService.GetPersonaCodigo();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetPersona")]
        public async Task<IActionResult> GetPersona(long personaId)
        {
            var response = await _personaService.GetPersona(personaId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetPersona_x_Dni")]
        public async Task<IActionResult> GetPersona_x_Dni(string vDni)
        {
            var response = await _personaService.GetPersona_x_Dni(vDni);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddPersonaSctr")]
        public async Task<IActionResult> AddPersonaSctr(CreatePersonaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoPersonaDto dto = new MantenimientoPersonaDto
            {
                nombre = model.nombres,
                paterno = model.apellido_paterno,
                materno = model.apellido_materno,
                tipo_documento = model.tipo_documento,
                numero_documento = model.numero_documento,
                fecha_naciemiento = model.fecha_nacimiento,
                genero = model.sexo,
                telefono_celular = model.celular,
                usuario_creacion = model.usuario_creacion,
            };

            var response = await _personaService.AddPersonaSctr(dto);

            if (response.Success)
            {
                //Guardar en Postgres
                long pk_sql = Convert.ToInt64(response.ResultData.GetType().GetProperty("Id_persona").GetValue(response.ResultData, null));

                if (pk_sql != -1)
                {
                    string uriWsPg = _appSettings.WsPostgres + "api/m_pacientesdrmas/Add";
                    string estadoWsPg = _appSettings.EstadoWsPostgres;
                    bool _sexo = false;

                    if (model.sexo == "1")
                    {
                        _sexo = true;
                    }

                    m_pacientesdrmas dto_m_pacientesdrmas = new m_pacientesdrmas
                    {
                        PrimaryKey_SQL = pk_sql,
                        nom_pac = model.nombres,
                        appat_pac = model.apellido_paterno,
                        apmat_pac = model.apellido_materno,
                        id_doc_id = Convert.ToInt64(model.tipo_documento),
                        num_doc_id = model.numero_documento,
                        fnac_pac = model.fecha_nacimiento,
                        sex_pac = _sexo,
                        cel_pac = model.celular,
                        Codigo_Usuario_PG = model.usuario_creacion.ToString()
                    };

                    _webServicePostgres.Consumir(uriWsPg, dto_m_pacientesdrmas, estadoWsPg);
                }
            }

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddPersonaMad")]
        public async Task<IActionResult> AddPersonaMad(CreatePersonaMadViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));
            MantenimientoPersonaMadDto dto = new MantenimientoPersonaMadDto
            {
                id_documento = model.id_documento,
                id_pais = model.id_pais,
                numero_documento = model.numero_documento,
                nombres = model.nombres,
                apellido_paterno = model.apellido_paterno,
                apellido_materno = model.apellido_materno,
                //fecha_nacimiento = model.fecha_nacimiento,
                genero = model.genero,
                //descripcion = model.descripcion,
                telefono_celular = model.telefono_celular,
                estado = model.estado,
                usuario_creacion = model.usuario_creacion,
                //fecha_creacion = model.fecha_creacion,
            };
            var response = await _personaService.AddPersonaMad(dto);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("ActualizarPersonaMad")]
        public async Task<IActionResult> ActualizarPersonaMad(ActualizarPersonaMadViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));
            MantenimientoPersonaMadActualizarDto dto = new MantenimientoPersonaMadActualizarDto
            {
                id_persona = model.id_persona,
                id_documento = model.id_documento,
                id_pais = model.id_pais,
                numero_documento = model.numero_documento,
                nombres = model.nombres,
                apellido_paterno = model.apellido_paterno,
                apellido_materno = model.apellido_materno,
                fecha_nacimiento = model.fecha_nacimiento,
                email = model.email,
                genero = model.genero,
                telefono_celular = model.telefono_celular,
                estado = model.estado,
                usuario_modificacion = model.usuario_modificacion,
                fecha_modificacion = model.fecha_modificacion,
            };
            var response = await _personaService.ActualizarPersonaMad(dto);
            return ReturnFormattedResponse(response);
        }

    }
}
