using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.SedeTraslado.Implementation
{
    public class SedeTrasladoService : ISedeTrasladoService
    {
        private readonly IUnitOfWork _uow;

        public SedeTrasladoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetSedeTraslado()
        {
            try
            {
                List<DbContext.Entities.SedeTraslado> datos = new List<DbContext.Entities.SedeTraslado>();

                datos = await _uow.ExecuteStoredProcAll<DbContext.Entities.SedeTraslado>("SPRMDS_LIST_SEDE_TRASLADO_AMBULANCIA");

                List<SedeTrasladoDto> list = new List<SedeTrasladoDto>();

                list = datos.Select(s => new SedeTrasladoDto { id = s.id, ruc = s.ruc, nombre = s.nombre, cod_ubigeo = s.cod_ubigeo, ubigeo = s.ubigeo, departamento = s.departamento, provincia = s.provincia, distrito = s.distrito, direccion = s.direccion, referencia = s.referencia }).ToList();

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
        public async Task<ServiceResponse> GetSedesTrasladoFiltro(string busqueda, string condicion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                    new SqlParameter("@isCondicion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = condicion },
                };

                List<DbContext.Entities.SedeTrasladoFiltro> sedes = new List<DbContext.Entities.SedeTrasladoFiltro>();

                sedes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.SedeTrasladoFiltro>("SPRMDS_LIST_SEDE_TRASLADO_FILTRO", parameters);

                List<SedeTrasladoDto> listSedes = new List<SedeTrasladoDto>();

                listSedes = sedes.Select(s => new SedeTrasladoDto { id = s.id, ruc = s.ruc, nombre = s.nombre, cod_ubigeo = s.cod_ubigeo, ubigeo = s.ubigeo, departamento = s.departamento, provincia = s.provincia, distrito = s.distrito, direccion = s.direccion, referencia = s.referencia }).ToList();

                /*if (!listClinicas.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listSedes);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddSedeTraslado(SedeTrasladoMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isRuc", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ruc },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_ubigeo },
                    new SqlParameter("@isNombre", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isReferencia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.referencia },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_SEDE_TRASLADO", parameters);

                dto.id = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> UpdateSedeTraslado(SedeTrasladoMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoSede", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id},
                    new SqlParameter("@isNombre", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_ubigeo },
                    new SqlParameter("@isReferencia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.referencia },
                    new SqlParameter("@isRuc", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ruc },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_SEDE_TRASLADO", parameters);

                dto.id = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}