using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Dto.Resources;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Settings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MDS.Services.Ambulancia.Implementation
{
    public class AmbulanciaService : IAmbulanciaService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAppSettings _appSettings;

        public AmbulanciaService
        (
            IUnitOfWork uow,
            IAppSettings appSettings
        )
        {
            _uow = uow;
            _appSettings = appSettings;
        }

        public async Task<ServiceResponse> GetAmbulancia(AmbulanciaResource dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCodigoAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoAtencion },
                    new SqlParameter("@isCodigoSited", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoSited },
                    new SqlParameter("@isCotizado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cotizado },
                    new SqlParameter("@isEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@isAmbulanciaRespuesta", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ambulanciaRespuesta },
                    new SqlParameter("@isServicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.servicio },
                    new SqlParameter("@isPaciente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.paciente },
                    new SqlParameter("@isNumeroDocumento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numeroDocumento },
                    new SqlParameter("@isDepartamento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.departamento },
                    new SqlParameter("@isProvincia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.provincia },
                    new SqlParameter("@isDistrito", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.distrito },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isReferencia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.referencia },
                    new SqlParameter("@isCliente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cliente },
                    new SqlParameter("@isProveedor", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.proveedor },
                    new SqlParameter("@isAmbulancia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ambulancia },
                    new SqlParameter("@isTiempo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.tiempo },
                    new SqlParameter("@isFechaEstimada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaEstimada },
                    new SqlParameter("@isHoraEstimada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaEstimada },
                    new SqlParameter("@isFechaLlegada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaLlegada },
                    new SqlParameter("@isHoraLlegada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaLlegada },
                    new SqlParameter("@isFechaFinAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaFinAtencion },
                    new SqlParameter("@isHoraFinAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaFinAtencion },
                    new SqlParameter("@isTelefonoCelular", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefonoCelular },
                    new SqlParameter("@isUsuarioCreacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usuarioCreacion },
                    new SqlParameter("@isFlagFueraCobertura", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.flagFueraCobertura },
                    new SqlParameter("@isFlagCitrix", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.flagCitrix },
                    new SqlParameter("@isCodigoProv", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoProv },

                    new SqlParameter("@inIndex", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.Skip },
                    new SqlParameter("@inTamanoPagina", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.PageSize },
                };

                var listaAmbulancia = await _uow.ExecuteStoredProcPagination<DbContext.Entities.Ambulancia>("SPRMDS_LIST_AMBULANCIA", parameters, dto.Skip, dto.PageSize);

                return ServiceResponse.ReturnResultWith200(listaAmbulancia);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetTipoServicioAmbulancia(string tipoServicio)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTipoServicio", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = tipoServicio },
                };

                List<DbContext.Entities.TipoServicioAmbulancia> datos = new List<DbContext.Entities.TipoServicioAmbulancia>();

                datos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.TipoServicioAmbulancia>("SPRMDS_LIST_TIPO_SERVICIO_AMBULANCIA", parameters);

                List<TipoServicioAmbulanciaDto> list = new List<TipoServicioAmbulanciaDto>();

                list = datos.Select(s => new TipoServicioAmbulanciaDto { id = s.id, nombre = s.nombre }).ToList();

                if (!datos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetPrioridadAmbulancia(string tipoServicio)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTipoServicio", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = tipoServicio },
                };

                List<DbContext.Entities.PrioridadAmbulancia> datos = new List<DbContext.Entities.PrioridadAmbulancia>();

                datos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.PrioridadAmbulancia>("SPRMDS_LIST_PRIORIDAD_AMBULANCIA", parameters);

                List<PrioridadAmbulanciaDto> list = new List<PrioridadAmbulanciaDto>();

                list = datos.Select(s => new PrioridadAmbulanciaDto { id = s.id, nombre = s.nombre }).ToList();

                if (!datos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetTipoAmbulancia()
        {
            try
            {
                List<DbContext.Entities.TipoAmbulancia> datos = new List<DbContext.Entities.TipoAmbulancia>();

                datos = await _uow.ExecuteStoredProcAll<DbContext.Entities.TipoAmbulancia>("SPRMDS_LIST_TIPO_AMBULANCIA");

                List<TipoAmbulanciaDto> list = new List<TipoAmbulanciaDto>();

                list = datos.Select(s => new TipoAmbulanciaDto { id = s.id, nombre = s.nombre }).ToList();

                if (!list.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetTipoTrasladoAmbulancia(int tipoAmbulancia)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTipoAmbulancia", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = tipoAmbulancia},
                };

                List<DbContext.Entities.TipoTrasladoAmbulancia> datos = new List<DbContext.Entities.TipoTrasladoAmbulancia>();

                datos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.TipoTrasladoAmbulancia>("SPRMDS_LIST_TIPO_TRASLADO_AMBULANCIA", parameters);

                List<TipoTrasladoAmbulanciaDto> list = new List<TipoTrasladoAmbulanciaDto>();

                list = datos.Select(s => new TipoTrasladoAmbulanciaDto { id = s.id, nombre = s.nombre }).ToList();

                if (!datos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetTipoPoliza(int codigoCliente)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoCliente", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoCliente},
                };

                List<DbContext.Entities.TipoPoliza> datos = new List<DbContext.Entities.TipoPoliza>();

                datos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.TipoPoliza>("SPRMDS_LIST_TIPO_POLIZA", parameters);

                List<TipoPolizaDto> list = new List<TipoPolizaDto>();

                list = datos.Select(s => new TipoPolizaDto { id = s.id, nombre = s.nombre }).ToList();

                if (!datos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetTipoPolizaByCodigo(int codigo)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPoliza", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigo},
                };

                List<DbContext.Entities.ValidarTipoPoliza> datos = new List<DbContext.Entities.ValidarTipoPoliza>();

                datos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.ValidarTipoPoliza>("SPRMDS_VALIDAR_POLIZA", parameters);

                List<ValidarTipoPolizaDto> list = new List<ValidarTipoPolizaDto>();

                list = datos.Select(s => new ValidarTipoPolizaDto { id = s.id, nombre = s.nombre, placa = s.placa, poliza = s.poliza, siniestro = s.siniestro }).ToList();

                if (!datos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetMotivoAtencionAmbulancia(string busqueda)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                };

                List<DbContext.Entities.MotivoAtencionAmbulancia> datos = new List<DbContext.Entities.MotivoAtencionAmbulancia>();

                datos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.MotivoAtencionAmbulancia>("SPRMDS_LIST_MOTIVO_ATENCION_AMBULANCIA", parameters);

                List<MotivoAtencionAmbulanciaDto> list = new List<MotivoAtencionAmbulanciaDto>();

                list = datos.Select(s => new MotivoAtencionAmbulanciaDto { id = s.id, nombre = s.nombre }).ToList();

                if (!datos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetProductoAmbulancia(string busqueda, int codCliente)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                    new SqlParameter("@inCodigoCliente", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codCliente }
                };

                List<DbContext.Entities.ProductoAmbulancia> datos = new List<DbContext.Entities.ProductoAmbulancia>();

                datos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.ProductoAmbulancia>("SPRMDS_LIST_PRODUCTO_AMBULANCIA", parameters);

                List<ProductoAmbulanciaDto> list = new List<ProductoAmbulanciaDto>();

                list = datos.Select(s => new ProductoAmbulanciaDto { id = s.id, nombre = s.nombre }).ToList();

                if (!datos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetProveedorAmbulancia()
        {
            try
            {
                List<DbContext.Entities.ProveedorAmbulancia> datos = new List<DbContext.Entities.ProveedorAmbulancia>();

                datos = await _uow.ExecuteStoredProcAll<DbContext.Entities.ProveedorAmbulancia>("SPRMDS_LIST_PROVEEDOR_AMBULANCIA");

                List<ProveedorAmbulanciaDto> list = new List<ProveedorAmbulanciaDto>();

                list = datos.Select(s => new ProveedorAmbulanciaDto { id = s.id, nombre = s.nombre }).ToList();

                if (!list.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetTipoComprobante()
        {
            try
            {
                List<DbContext.Entities.TipoComprobante> datos = new List<DbContext.Entities.TipoComprobante>();

                datos = await _uow.ExecuteStoredProcAll<DbContext.Entities.TipoComprobante>("SPRMDS_LIST_TIPO_COMPROBANTE");

                List<TipoComprobanteDto> list = new List<TipoComprobanteDto>();

                list = datos.Select(s => new TipoComprobanteDto { id = s.id, nombre = s.nombre }).ToList();

                if (!list.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }
    }
}