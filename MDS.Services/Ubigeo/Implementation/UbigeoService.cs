using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.Blog.Implementation
{
    public class UbigeoService : IUbigeoService
    {
        private readonly IUnitOfWork _uow;

        public UbigeoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetUbigeos()
        {
            try
            {
                List<DbContext.Entities.Ubigeos> ubigeos = new List<DbContext.Entities.Ubigeos>();

                ubigeos = await _uow.ExecuteStoredProcAll<DbContext.Entities.Ubigeos>("SPRMDS_LIST_UBIGEO");

                List<UbigeoDto> listUbigeos = new List<UbigeoDto>();

                listUbigeos = ubigeos.Select(s => new UbigeoDto { codigo = s.CUBI_UBIGEO, id_departamento = s.SUBI_COD_DPTO, departamento = s.SUBI_DEPARTAMENTO, id_provincia = s.SUBI_COD_PROV, provincia = s.SUBI_PROVINCIA, id_distrito = s.SUBI_COD_DIST, distrito = s.SUBI_DISTRITO }).ToList();

                if (!ubigeos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listUbigeos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetDepartamentos()
        {
            try
            {
                List<DbContext.Entities.Departamento> ubigeos = new List<DbContext.Entities.Departamento>();

                ubigeos = await _uow.ExecuteStoredProcAll<DbContext.Entities.Departamento>("SPRMDS_LIST_UBIGEO_DEPARTAMENTO");

                List<DepartamentoDto> listUbigeos = new List<DepartamentoDto>();

                listUbigeos = ubigeos.Select(s => new DepartamentoDto { id = s.SUBI_COD_DPTO, nombre = s.SUBI_DEPARTAMENTO }).ToList();

                if (!ubigeos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listUbigeos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetProvincias(string SUBI_COD_DPTO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCodDepartamento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = SUBI_COD_DPTO },
                };

                List<DbContext.Entities.Provincia> ubigeos = new List<DbContext.Entities.Provincia>();

                ubigeos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Provincia>("SPRMDS_LIST_UBIGEO_PROVINCIA", parameters);

                List<ProvinciaDto> listUbigeos = new List<ProvinciaDto>();

                listUbigeos = ubigeos.Select(s => new ProvinciaDto { id = s.SUBI_COD_PROV, nombre = s.SUBI_PROVINCIA }).ToList();

                if (!listUbigeos.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listUbigeos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetDistritos(string SUBI_COD_DPTO, string SUBI_COD_PROV)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCodDepartamento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = SUBI_COD_DPTO },
                    new SqlParameter("@isCodProvincia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = SUBI_COD_PROV },
                };

                List<DbContext.Entities.Distrito> ubigeos = new List<DbContext.Entities.Distrito>();

                ubigeos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Distrito>("SPRMDS_LIST_UBIGEO_DISTRITO", parameters);

                List<DistritoDto> listUbigeos = new List<DistritoDto>();

                listUbigeos = ubigeos.Select(s => new DistritoDto { id = s.SUBI_COD_DIST, nombre = s.SUBI_DISTRITO }).ToList();

                if (!listUbigeos.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listUbigeos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetUbigeo_By_Codigo(string vCodigoUbigeo)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CODIGO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vCodigoUbigeo },
                };

                List<DbContext.Entities.UbigeoDatos> ubigeos = new List<DbContext.Entities.UbigeoDatos>();

                ubigeos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.UbigeoDatos>("SPRMDS_LIST_UBIGEO_BY_CODIGO", parameters);

                List<UbigeoDatosDto> listUbigeos = new List<UbigeoDatosDto>();

                listUbigeos = ubigeos.Select(u => new UbigeoDatosDto 
                { 
                    departamento = u.SUBI_DEPARTAMENTO,
                    provincia = u.SUBI_PROVINCIA,
                    distrito = u.SUBI_DISTRITO,
                }).ToList();

                if (!listUbigeos.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listUbigeos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}