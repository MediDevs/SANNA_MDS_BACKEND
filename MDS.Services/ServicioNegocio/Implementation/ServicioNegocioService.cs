using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using MDS.DbContext.Entities;
using System;




namespace MDS.Services.ServicioNegocio.Implementation
{
    public class ServicioNegocioService : IServicioNegocio
    {

        private readonly IUnitOfWork _uow;

        public ServicioNegocioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetServicioNegocios()
        {
            try
            {
                List<DbContext.Entities.ServicioNegocio> servicio = new List<DbContext.Entities.ServicioNegocio>();

                servicio = await _uow.ExecuteStoredProcAll<DbContext.Entities.ServicioNegocio>("SPRMDS_LIST_SERVICIO_NEGOCIO");

                List<ServicioNegocioDto> listServicio = new List<ServicioNegocioDto>();

                listServicio = servicio.Select(s => new ServicioNegocioDto { id_servicio = s.CSER_ID, nombre = s.SSER_NOMBRE, grupo = s.SSER_GRUPO, estado = s.FSER_ESTADO }).ToList();

                if (!servicio.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listServicio);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetServicioNegocio(long servicioId)
        {
            try
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = servicioId },
                };

                List<DbContext.Entities.ServicioNegocio> servicio = new List<DbContext.Entities.ServicioNegocio>();

                servicio = await _uow.ExecuteStoredProcByParam<DbContext.Entities.ServicioNegocio>("SPRMDS_LIST_SERVICIO_NEGOCIO_BY_PARAM", parameters);

                List<ServicioNegocioDto> listServicio = new List<ServicioNegocioDto>();

                listServicio = servicio.Select(s => new ServicioNegocioDto { id_servicio = s.CSER_ID, nombre = s.SSER_NOMBRE, grupo = s.SSER_GRUPO, estado = s.FSER_ESTADO }).ToList();

                if (!listServicio.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listServicio);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddServicioNegocio(MantenimientoServicioNegocioDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SSER_NOMBRE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@SSER_GRUPO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.grupo },
                    new SqlParameter("@NSER_UNI_NEGOCIO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.uni_negocio },
                    new SqlParameter("@NSER_TIPO_OPERACION_PRECISA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.tipo_operacion_precisa },
                    new SqlParameter("@SSER_ONBASE_SUBTIPO_ATENCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.onbase_subtipo_atencion },
                    new SqlParameter("@NSER_UNCCSCL", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.unccscl },
                    new SqlParameter("@SSER_NEGOCIO_FACTURACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.negocio_facturacion },
                    new SqlParameter("@NSER_PROGRAMA_APP", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.programa_app },
                    new SqlParameter("@FSER_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@NSER_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@DSER_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@NSER_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DSER_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}

                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_SERVICIO_NEGOCIO", parameters);

                dto.id_servicio = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

    }
}
