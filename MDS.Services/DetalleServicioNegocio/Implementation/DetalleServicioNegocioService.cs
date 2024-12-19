using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using MDS.DbContext.Entities;

namespace MDS.Services.DetalleServicioNegocio.Implementation
{
    public class DetalleServicioNegocioService : IDetalleServicioNegocio
    {
        private readonly IUnitOfWork _uow;

        public DetalleServicioNegocioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetDetalleServicioNegocios()
        {
            try
            {
                List<DbContext.Entities.DetalleServicioNegocio> detservicio = new List<DbContext.Entities.DetalleServicioNegocio>();

                detservicio = await _uow.ExecuteStoredProcAll<DbContext.Entities.DetalleServicioNegocio>("SPRMDS_LIST_DETALLE_SERVICIO_NEGOCIO");

                List<DetalleServicioNegocioDto> listDetServicio = new List<DetalleServicioNegocioDto>();

                listDetServicio = detservicio.Select(s => new DetalleServicioNegocioDto { iddet_servicio = s.CDSN_IDDETSERVICIO, nombre = s.SDSN_NOMBRE, estado = s.FDSN_ESTADO }).ToList();

                if (!detservicio.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listDetServicio);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetDetalleServicioNegocio(long detservicioId)
        {
            try
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = detservicioId },
                };

                List<DbContext.Entities.DetalleServicioNegocio> detalles = new List<DbContext.Entities.DetalleServicioNegocio>();

                detalles = await _uow.ExecuteStoredProcByParam<DbContext.Entities.DetalleServicioNegocio>("SPRMDS_LIST_DETALLE_SERVICIO_BY_PARAM", parameters);

                List<DetalleServicioNegocioDto> listDetServicio = new List<DetalleServicioNegocioDto>();

                listDetServicio = detalles.Select(s => new DetalleServicioNegocioDto { iddet_servicio = s.CDSN_IDDETSERVICIO, nombre = s.SDSN_NOMBRE, estado = s.FDSN_ESTADO }).ToList();

                if (!detalles.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listDetServicio);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca

        public async Task<ServiceResponse> AddDetalleServicioNegocio(MantenimientoDetalleServicioNegocioDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CDSN_IDSERVICIO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_servicio },
                    new SqlParameter("@SDSN_NOMBRE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@FDSN_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@NDSN_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@DDSN_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@NDSN_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DDSN_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_DETALLE_SERVICIO", parameters);

                dto.iddet_servicio = Convert.ToInt64(response);

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
