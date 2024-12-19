using MDS.Dto;
using MDS.Dto.List;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Services.Usuario.Implementation;
using MDS.Utility.Attributes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.AuditoriaLogin.Implementation
{
    public class AuditoriaLoginService:IAuditoriaLoginService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<AuditoriaLoginService> _logger;

        public AuditoriaLoginService(IUnitOfWork uow,ILogger<AuditoriaLoginService> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        public async Task<ServiceResponse> AddAuditoriaLogin(AuditoriaLoginDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isNombreUsuario", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = (dto.usuario == null) ? DBNull.Value : dto.usuario},
                    new SqlParameter("@isDireccionIp", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = (dto.ip == null) ? DBNull.Value : dto.ip},
                    new SqlParameter("@isOrigen", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = (dto.origen == null) ? DBNull.Value : dto.origen },
                    new SqlParameter("@isLatitud", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = (dto.latitud == null) ? DBNull.Value : dto.latitud },
                    new SqlParameter("@isLongitud", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = (dto.longitud == null) ? DBNull.Value : dto.longitud},
                    new SqlParameter("@isEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = (dto.estado == null) ? DBNull.Value : dto.estado},
                    new SqlParameter("@isDescripcion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = (dto.descripcion == null) ? DBNull.Value : dto.descripcion},
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = (dto.idUsuario == null) ? (int)ConstantsList.VALUES_DEFAULT_INT : dto.idUsuario },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int respuesta = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_AUDITORIA", parameters);

                if (respuesta == ConstantsList.STATUS_CODE_500)
                    return ServiceResponse.Return500();

                return ServiceResponse.ReturnResultWith200(dto);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> GetAuditoriaLogin(AuditoriaLoginDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.AuditoriaLoginResource.UserName },
                    new SqlParameter("@inIndex", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.AuditoriaLoginResource.Skip },
                    new SqlParameter("@inTamanoPagina", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.AuditoriaLoginResource.PageSize },
                    //new SqlParameter("@onTotal", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                //List<DbContext.Entities.AuditoriaLogin> auditoriaLogin = new List<DbContext.Entities.AuditoriaLogin>();

                var auditoriaLogin = await _uow.ExecuteStoredProcPagination<DbContext.Entities.AuditoriaLogin>("SPRMDS_LIST_AUDITORIA", parameters, dto.AuditoriaLoginResource.Skip, dto.AuditoriaLoginResource.PageSize);

                //List<AuditoriaLoginDto> listAuditoriaLoginDto = new List<AuditoriaLoginDto>();

                //if (!auditoriaLogin.Any())
                //    return ServiceResponse.ReturnResultWith204();

                //listAuditoriaLoginDto = auditoriaLogin.Select(s => new AuditoriaLoginDto 
                //{ 
                //    usuario = s.SAUD_NOMBRE_USUARIO, 
                //    ip = s.SAUD_DIRECCION_IP,
                //    fecha = s.DAUD_FECHA,
                //    origen = s.SAUD_ORIGEN, 
                //    latitud = s.SAUD_LATITUD,
                //    longitud = s.SAUD_LONGITUD,
                //    estado = s.SAUD_ESTADO,
                //    descripcion = s.SAUD_DESCRIPCION
                //}).ToList();

                //var loginAudits1 = new TablaPaginacionList();

                //var loginAudits = await loginAudits1.Create(
                //    listAuditoriaLoginDto.AsQueryable().BuildMock(),
                //    dto.AuditoriaLoginResource.Skip,
                //    dto.AuditoriaLoginResource.PageSize
                //    );

                return ServiceResponse.ReturnResultWith200(auditoriaLogin);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
    }
}
