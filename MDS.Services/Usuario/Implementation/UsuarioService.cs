using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using MDS.Utility.Attributes;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MDS.Infrastructure.Settings;
using Microsoft.Extensions.Logging;
using MDS.Services.AuditoriaLogin;
using Microsoft.AspNetCore.SignalR;
using MDS.Services.Hub;
using MDS.Services.Hub.Implementation;
using MDS.Services.UsuarioRol;
using MDS.Utility.Extensions;
using Newtonsoft.Json;
using MDS.Services.RolClaim;
using MDS.Services.UsuarioClaim;
using MDS.Services.PaginaAccion;
using MDS.Dto.Resources;

namespace MDS.Services.Usuario.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAppSettings _appSettings;
        private readonly ILogger<UsuarioService> _logger;
        private readonly IAuditoriaLoginService _auditoriaService;
        private readonly IUsuarioRolService _usuarioRolService;
        private readonly IRolClaimService _rolClaimService;
        private readonly IUsuarioClaimService _usuarioClaimService;
        private readonly IPaginaAccionService _paginaAccionService;
        private readonly IHubContext<HubClienteService, IHubClienteService> _hubContext;
        private Encryption _security;

        public UsuarioService
        (
            IUnitOfWork uow,
            IAppSettings appSettings,
            ILogger<UsuarioService> logger,
            IAuditoriaLoginService auditoriaService,
            IUsuarioRolService usuarioRolService,
            IRolClaimService rolClaimService,
            IUsuarioClaimService usuarioClaimService,
            IPaginaAccionService paginaAccionService,
            IHubContext<HubClienteService,
            IHubClienteService> hubContext
        )
        {
            _uow = uow;
            _appSettings = appSettings;
            _logger = logger;
            _auditoriaService = auditoriaService;
            _usuarioRolService = usuarioRolService;
            _rolClaimService = rolClaimService;
            _usuarioClaimService = usuarioClaimService;
            _paginaAccionService = paginaAccionService;
            _hubContext = hubContext;
            _security = new Encryption();
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddUsuario(UsuarioDto dto)
        {
            try
            {
                dto.contrasena = _security.Encrypt(_appSettings.KeyGenerator, dto.contrasena);

                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@isUsuario", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.usuario },
                    new SqlParameter("@isClave", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.contrasena },
                    new SqlParameter("@isTelefono", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefonoMovil },
                    new SqlParameter("@isCorreo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_USUARIO", parameters);

                dto.id_persona = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddUsuarioPersona(UsuarioDto dto)
        {
            try
            {
                dto.contrasena = _security.Encrypt(_appSettings.KeyGenerator, dto.contrasena);

                SqlParameter[] parameters =
                {
                    new SqlParameter("@SPER_NOMBRES", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombres },
                    new SqlParameter("@SPER_APELLIDO_PATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.apellidoPaterno },
                    new SqlParameter("@SPER_APELLIDO_MATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.apellidoMaterno },
                    new SqlParameter("@CTDO_ID", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.tipo_documento },
                    new SqlParameter("@SPER_NUMERO_DOCUMENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numero_documento },
                    new SqlParameter("@DPER_FECHA_NACIMIENTO", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_nacimiento },
                    new SqlParameter("@NPER_GENERO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.sexo },
                    new SqlParameter("@isUsuario", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.usuario },
                    new SqlParameter("@isClave", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.contrasena },
                    new SqlParameter("@isTelefono", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefonoMovil },
                    new SqlParameter("@isCorreo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_USUARIO_PERSONA", parameters);

                dto.id_persona = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> UpdateUsuario(UsuarioDto dto)
        {
            try
            {
                dto.contrasena = _security.Encrypt(dto.contrasena, "1234567890");

                SqlParameter[] parameters =
                {
                    new SqlParameter("@DPER_FECHA_NACIMIENTO", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_nacimiento },
                    new SqlParameter("@NPER_GENERO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.sexo },
                    new SqlParameter("@inCodigoPersona", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_usuario },
                    new SqlParameter("@isClave", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.contrasena },
                    new SqlParameter("@isTelefono", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefonoMovil },
                    new SqlParameter("@isCorreo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email },
                    new SqlParameter("@inUsuarioModificacion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion},
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_USUARIO", parameters);

                dto.id_persona = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> DeleteUsuario()
        {
            throw new NotImplementedException();
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetAllUsuario(UsuarioResource dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isEmail", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email },
                    new SqlParameter("@isUsuario", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usuario },
                    new SqlParameter("@isPersona", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona },
                    new SqlParameter("@isNumeroDocumento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numero_documento },

                    new SqlParameter("@isOrderBy", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.OrderBy },
                    new SqlParameter("@inIndex", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.Skip },
                    new SqlParameter("@inTamanoPagina", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.PageSize },
                };

                var lstUsuario = await _uow.ExecuteStoredProcPagination<DbContext.Entities.Usuarios>("SPRMDS_LIST_USUARIO", parameters, dto.Skip, dto.PageSize);

                return ServiceResponse.ReturnResultWith200(lstUsuario);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetUsuario(int vBusqueda)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = vBusqueda }
                };

                List<DbContext.Entities.Usuario> usuario = new List<DbContext.Entities.Usuario>();

                usuario = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Usuario>("SPRMDS_GET_USUARIO_BY_ID", parameters);

                List<UsuarioDto> listUsuarios = new List<UsuarioDto>();

                listUsuarios = usuario.Select(s => new UsuarioDto
                {
                    id_persona = s.CPER_ID,
                    codigoUsuario = s.CUSR_ID,
                    tipo_documento = s.CTDO_ID,
                    numero_documento = s.SPER_NUMERO_DOCUMENTO,
                    fecha_nacimiento = s.DPER_FECHA_NACIMIENTO,
                    nombres = s.SPER_NOMBRES,
                    apellidoPaterno = s.SPER_APELLIDO_PATERNO,
                    apellidoMaterno = s.SPER_APELLIDO_MATERNO,
                    email = s.SUSR_EMAIL_CORP,
                    telefonoMovil = s.SUSR_TLF_CELULAR_CORP,
                    usuario = s.SUSR_NOMBRE,
                    contrasena = s.SUSR_CONTRASENA,
                    sexo = s.NPER_GENERO,
                    pk_pg=s.SUSR_PK_POSTGRES
                }).ToList();

                return ServiceResponse.ReturnResultWith201(listUsuarios);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> LoginUsuario(UsuarioDto dto)
        {
            try
            {
                var auditoria = new AuditoriaLoginDto
                {
                    usuario = dto.usuario,
                    origen = "WEB",
                    ip = dto.ip,
                    estado = ConstantsList.STATUS_SUCCESS.ToString(),
                    latitud = dto.latitud,
                    longitud = dto.longitud
                };

                SqlParameter[] parametroObtenerUsuario =
                {
                    new SqlParameter("@isNombreUsuario", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = (dto.usuario == null) ? DBNull.Value : dto.usuario},
                };

                var usuario = await _uow.ExecuteStoredProcObjectByParam<DbContext.Entities.Usuario>("SPRMDS_GET_USUARIO_BY_NAME", parametroObtenerUsuario);

                if (usuario != null)
                {
                    dto.contrasena = _security.Encrypt(_appSettings.KeyGenerator, dto.contrasena);

                    if (usuario.SUSR_CONTRASENA.Trim() != dto.contrasena)
                    {
                        auditoria.estado = ConstantsList.STATUS_ERROR;
                        auditoria.descripcion = ConstantsList.AUTH_ERROR_WRONG_PASSWORD;
                        await _auditoriaService.AddAuditoriaLogin(auditoria);
                        return ServiceResponse.ReturnUnauthorized();
                    }

                    if (usuario.FUSR_ESTADO == ConstantsList.AUTH_STATUS_OFF)
                    {
                        auditoria.estado = ConstantsList.STATUS_ERROR;
                        auditoria.descripcion = ConstantsList.AUTH_ERROR_STATUS;
                        await _auditoriaService.AddAuditoriaLogin(auditoria);
                        return ServiceResponse.ReturnFailed(ConstantsList.STATUS_CODE_599, ConstantsList.AUTH_ERROR_STATUS);
                    }

                    if (usuario.NUSR_INTENTOS_FALLIDOS > ConstantsList.AUTH_MAX_ATTEMPS)
                    {
                        auditoria.estado = ConstantsList.STATUS_ERROR;
                        auditoria.descripcion = ConstantsList.AUTH_ERROR_MAX_ATTEMPS;
                        await _auditoriaService.AddAuditoriaLogin(auditoria);
                        return ServiceResponse.ReturnFailed(ConstantsList.STATUS_CODE_598, ConstantsList.AUTH_ERROR_MAX_ATTEMPS);
                    }
                    await _auditoriaService.AddAuditoriaLogin(auditoria);
                }
                else
                {
                    auditoria.estado = ConstantsList.STATUS_ERROR;
                    auditoria.descripcion = ConstantsList.AUTH_ERROR_NOT_EXISTS;
                    await _auditoriaService.AddAuditoriaLogin(auditoria);
                    return ServiceResponse.Return404();
                }

                var usuarioDto = new UsuarioDto
                {
                    codigoUsuario = usuario.CUSR_ID,
                    nombres = usuario.SPER_NOMBRES,
                    apellidoPaterno = usuario.SPER_APELLIDO_PATERNO,
                    apellidoMaterno = usuario.SPER_APELLIDO_MATERNO,
                    email = usuario.SUSR_EMAIL_CORP,
                    telefonoMovil = usuario.SUSR_TLF_CELULAR_CORP,
                    dobleFactor = usuario.FUSR_DOBLE_FACTOR,
                    emailConfirmacion = usuario.FUSR_EMAIL_CONFIRMACION,
                    intentosFallidos = usuario.NUSR_INTENTOS_FALLIDOS,
                    estado = usuario.FUSR_ESTADO,
                    usuario = usuario.SUSR_NOMBRE,
                    pk_pg = usuario.SUSR_PK_POSTGRES
                };

                var usuarioAuthDto = await BuildUsuarioAuth(usuarioDto);

                var usuarioEnLinea = new UsuarioEnLineaDto
                {
                    usuario = usuarioAuthDto.usuario,
                    id = usuarioAuthDto.id.ToString()
                };

                await _hubContext.Clients.All.Joined(usuarioEnLinea);

                return ServiceResponse.ReturnResultWith200(usuarioAuthDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return ServiceResponse.Return500(e);
            }
        }

        private async Task<UsuarioAuthDto> BuildUsuarioAuth(UsuarioDto dto)
        {
            UsuarioAuthDto usuarioAuthDto = new UsuarioAuthDto();
            //List<AppClaimDto> appClaims = new List<AppClaimDto>();

            usuarioAuthDto.id = dto.codigoUsuario;
            usuarioAuthDto.usuario = dto.usuario;
            usuarioAuthDto.nombres = dto.nombres;
            usuarioAuthDto.apellidoPaterno = dto.apellidoPaterno;
            usuarioAuthDto.apellidoMaterno = dto.apellidoMaterno;
            usuarioAuthDto.email = dto.email;
            usuarioAuthDto.telefonoMovil = dto.telefonoMovil;
            usuarioAuthDto.esAutentificado = true;
            usuarioAuthDto.foto = "";
            var appClaimDtos = await this.GetUsuarioRolClaims(dto);
            usuarioAuthDto.claims = appClaimDtos;
            var claims = appClaimDtos.Select(c => new Claim(c.claimType, c.claimValue)).ToList();
            usuarioAuthDto.token = BuildJwtToken(usuarioAuthDto, claims, dto.codigoUsuario);
            usuarioAuthDto.menu = await this.CreateMenu(appClaimDtos);
            usuarioAuthDto.dobleFactor = dto.dobleFactor;
            usuarioAuthDto.pk_pg = dto.pk_pg;

            //"{navCap:'Home',},{displayName:'Starter',iconName:'home',route:'/',},{navCap:'Other',},{displayName:'MenuLevel',iconName:'box-multiple',route:'/menu-level',children:[{displayName:'Menu1',iconName:'point',route:'/menu-1',children:[{displayName:'Menu1',iconName:'point',route:'/menu-1',},{displayName:'Menu2',iconName:'point',route:'/menu-2',},],},{displayName:'Menu2',iconName:'point',route:'/menu-2',},],},{displayName:'Disabled',iconName:'ban',route:'/disabled',disabled:true,},{displayName:'Chip',iconName:'mood-smile',route:'/primary',chip:true,chipClass:'bg-primarytext-white',chipContent:'9',},{displayName:'Outlined',iconName:'mood-smile',route:'/outline',chip:true,chipClass:'b-1border-primarytext-primary',chipContent:'outlined',},{displayName:'ExternalLink',iconName:'star',route:'https://www.google.com/',external:true,},";

            return usuarioAuthDto;
        }

        private async Task<List<object>> CreateMenu(List<AppClaimDto> appClaimDtos)
        {
            var menu = new List<object>();

            string nombreSeccion = "";
            string nombreSubSeccion = "";

            foreach (var claim in appClaimDtos)
            {
                if (claim.seccion != nombreSeccion)
                {
                    menu.Add(new { navCap = claim.seccion });
                    nombreSeccion = claim.seccion;
                }

                if (claim.nombreSubSeccion == "" || claim.nombreSubSeccion == null)
                {
                    menu.Add
                    (
                         new
                         {
                             displayName = StringExtensions.FirstCharToUpper(claim.nombrePaginaMenu),
                             iconName = claim.nombreIcono,
                             route = StringExtensions.FirstCharToUpper(claim.nombrePagina) == "Dashboard" ? "/" : claim.urlPagina.ToLower(),
                         }
                    );
                }
                else
                {
                    if (claim.nombreSubSeccion != nombreSubSeccion)
                    {
                        var finalResult = appClaimDtos.Where(item => item.nombreSubSeccion == claim.nombreSubSeccion);
                        var subMenu = new List<object>();

                        foreach (var f in finalResult)
                        {
                            subMenu.Add
                            (
                                new
                                {
                                    displayName = StringExtensions.FirstCharToUpper(f.nombrePaginaMenu),
                                    iconName = f.nombreIcono,
                                    route = f.urlPagina
                                }
                            );
                        }


                        menu.Add
                        (
                             new
                             {
                                 displayName = StringExtensions.FirstCharToUpper(claim.nombreSubSeccion),
                                 iconName = claim.nombreIconoSubSeccion,
                                 children = subMenu
                             }
                        );
                        nombreSubSeccion = claim.nombreSubSeccion;
                    }
                }
            }

            return menu;
        }

        private async Task<List<AppClaimDto>> GetUsuarioRolClaims(UsuarioDto dto)
        {
            var rspUsuarioClaim = await _usuarioClaimService.GetUsuarioClaim(dto.codigoUsuario);
            var usuarioClaimIds = JsonConvert.DeserializeObject<List<UsuarioClaimDto>>(rspUsuarioClaim.ResultData.ToJsonNoFormat());

            var rspRolClaim = await GetRolClaims(dto);

            var rspPaginaAccion = await _paginaAccionService.GetPaginaAccion();
            var paginaAccionIds = JsonConvert.DeserializeObject<List<PaginaAccionDto>>(rspPaginaAccion.ResultData.ToJsonNoFormat());

            List<AppClaimDto> listAppClaimDto = new List<AppClaimDto>();

            foreach (var paginaAccion in paginaAccionIds)
            {
                var appClaimDto = new AppClaimDto
                {
                    seccion = paginaAccion.nombreSeccion.ToUpper(),
                    nombrePaginaMenu = StringExtensions.FirstCharToUpper(paginaAccion.nombrePaginaMenu),
                    nombrePagina = StringExtensions.FirstCharToUpper(paginaAccion.nombrePagina),
                    nombreIcono = paginaAccion.nombreIcono,
                    nombreSubSeccion = paginaAccion.nombreSubSeccion,
                    nombreIconoSubSeccion = paginaAccion.nombreIconoSubSeccion,
                    urlPagina = paginaAccion.urlPagina.ToLower(),
                    claimType = $"{paginaAccion.nombrePagina.ToLower()}_{paginaAccion.nombreAccion.ToLower()}",
                    claimValue = "false"
                };

                if (usuarioClaimIds != null && (usuarioClaimIds.Any(c => c.codigoPagina == paginaAccion.codigoPagina && c.codigoAccion == paginaAccion.codigoAccion)))
                {
                    appClaimDto.claimValue = "true";
                }

                if (rspRolClaim != null && (rspRolClaim.Any(c => c.codigoPagina == paginaAccion.codigoPagina && c.codigoAccion == paginaAccion.codigoAccion)))
                {
                    appClaimDto.claimValue = "true";
                }

                listAppClaimDto.Add(appClaimDto);
            }

            return listAppClaimDto;
        }

        private async Task<List<RolClaimDto>> GetRolClaims(UsuarioDto dto)
        {
            var rspUsuarioRol = await _usuarioRolService.GetUsuarioRol(dto);

            var rolIds = JsonConvert.DeserializeObject<List<UsuarioRolDto>>(rspUsuarioRol.ResultData.ToJsonNoFormat()).Select(c => c.codigoRol).ToList();

            List<RolClaimDto> lstRolClaim = new List<RolClaimDto>();

            foreach (var roleId in rolIds)
            {
                var rspRolClaim = await _rolClaimService.GetRolClaim(roleId);

                var rolClaimIds = JsonConvert.DeserializeObject<List<RolClaimDto>>(rspRolClaim.ResultData.ToJsonNoFormat());

                foreach (var roleClaimId in rolClaimIds)
                {
                    if (!lstRolClaim.Any(c => c.codigoRolClaim == roleClaimId.codigoRolClaim && c.codigoAccion == roleClaimId.codigoAccion && c.codigoPagina == roleClaimId.codigoPagina && c.tipoClaim == roleClaimId.tipoClaim && c.valorClaim == roleClaimId.valorClaim))
                    {
                        lstRolClaim.Add(roleClaimId);
                    }
                }
            }
            return lstRolClaim;
        }

        protected string BuildJwtToken(UsuarioAuthDto usuarioAuthDto, IList<Claim> claims, int Id)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            claims.Add(new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub.ToString(), Id.ToString()));
            claims.Add(new Claim("email", usuarioAuthDto.email));
            // Create the JwtSecurityToken object
            var token = new JwtSecurityToken
            (
              issuer: _appSettings.Issuer,
              audience: _appSettings.Audience,
              claims: claims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddMinutes(_appSettings.DurationInMinutes),
              signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            // Create a string representation of the Jwt token
            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetPersonasSinUsuario(string vBusqueda)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@isBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vBusqueda},
                };

                List<DbContext.Entities.PersonasSinUsuario> personas = new List<DbContext.Entities.PersonasSinUsuario>();

                personas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.PersonasSinUsuario>("SPRMDS_LIST_PERSONAS_SIN_USUARIO", parametros);

                List<PersonasSinUsuarioDto> listPersonas = new List<PersonasSinUsuarioDto>();

                if (!personas.Any())
                    return ServiceResponse.ReturnResultWith204();

                listPersonas = personas.Select
                (
                    s => new PersonasSinUsuarioDto
                    {
                        id_persona = s.id_persona,
                        numero_documento = s.numero_documento,
                        nombres = s.nombres,
                        apellido_paterno = s.apellido_paterno,
                        apellido_materno = s.apellido_materno
                    }
                ).ToList();

                return ServiceResponse.ReturnResultWith200(listPersonas);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> ActivarUsuario(UsuarioDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ACTIVAR_USUARIO", parameters);

                dto.id_persona = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> DesactivarUsuario(UsuarioDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DESACTIVAR_USUARIO", parameters);

                dto.id_persona = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> ActivarDobleFactorUsuario(UsuarioDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_usuario },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DOBLE_FACTOR_USUARIO", parameters);

                dto.id_persona = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}
