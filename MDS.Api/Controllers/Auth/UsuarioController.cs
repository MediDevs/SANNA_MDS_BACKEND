using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Dto;
using MDS.Dto.List;
using MDS.Dto.Resources;
using MDS.Services.Usuario;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        //By Henrry Torres
        [HttpGet]
        public async Task<IActionResult> GetAllUsuario([FromQuery] UsuarioResource usuarioResource)
        {
            var resultado = await _usuarioService.GetAllUsuario(usuarioResource);

            var paginacion = JsonConvert.DeserializeObject<TablaPaginacionList>(resultado.ResultData.ToJsonNoFormat());

            var paginationMetadata = new
            {
                totalCount = paginacion.TotalCount,
                pageSize = paginacion.PageSize,
                skip = paginacion.Skip,
                totalPages = paginacion.TotalPages
            };

            Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return ReturnFormattedResponse(resultado);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUsuario(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpGet("GetContrasena")]
        public async Task<IActionResult> GetContrasena(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet("GetUsuario")]
        public async Task<IActionResult> GetUsuario(int vBusqueda)
        {
            var response = await _usuarioService.GetUsuario(vBusqueda);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetPersonasSinUsuario")]
        public async Task<IActionResult> GetPersonasSinUsuario(string vBusqueda)
        {
            var response = await _usuarioService.GetPersonasSinUsuario(vBusqueda);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost("AddUsuarioPersona")]
        public async Task<IActionResult> AddUsuarioPersona(CreateUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                tipo_documento = model.tipo_documento,
                numero_documento = model.numero_documento,
                sexo = model.sexo,
                fecha_nacimiento = model.fecha_nacimiento,
                nombres = model.nombres,
                apellidoPaterno = model.apellidoPaterno,
                apellidoMaterno = model.apellidoMaterno,
                usuario = model.usuario,
                contrasena = model.contrasena,
                telefonoMovil = model.telefonoMovil,
                email = model.email,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _usuarioService.AddUsuarioPersona(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpPut("UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario(UpdateUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                sexo = model.sexo,
                fecha_nacimiento = model.fecha_nacimiento,
                contrasena = model.contrasena,
                telefonoMovil = model.telefonoMovil,
                email = model.email,
                id_persona = model.id_persona,
                id_usuario=model.id_usuario,
                usuario_modificacion = model.usuario_modificacion
            };

            var response = await _usuarioService.UpdateUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpDelete("DeleteUsuario")]
        public async Task<IActionResult> DeleteUsuario(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost("AddUsuario")]
        public async Task<IActionResult> AddUsuario(CreateUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                telefonoMovil = model.telefonoMovil,
                email = model.email,
                id_persona = model.id_persona,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _usuarioService.AddUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut("ActivarUsuario")]
        public async Task<IActionResult> ActivarUsuario(ActivarUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                id_persona = model.id_persona,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _usuarioService.ActivarUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete("DesactivarUsuario")]
        public async Task<IActionResult> DesactivarUsuario(DesactivarUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                id_persona = model.id_persona,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _usuarioService.DesactivarUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut("ActivarDobleFactorUsuario")]
        [AllowAnonymous]
        public async Task<IActionResult> ActivarDobleFactorUsuario(ActivarDobleFactorUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                id_usuario = model.id_usuario
            };

            var response = await _usuarioService.ActivarDobleFactorUsuario(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
