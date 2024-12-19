using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Clinica.Implementation
{
    public class ClinicaService : IClinicaService
    {
        private readonly IUnitOfWork _uow;

        public ClinicaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetClinicas()
        {
            try
            {
                List<DbContext.Entities.Clinica> clinicas = new List<DbContext.Entities.Clinica>();

                clinicas = await _uow.ExecuteStoredProcAll<DbContext.Entities.Clinica>("SPRMDS_LIST_CLINICA");

                List<ClinicaDto> listClinicas = new List<ClinicaDto>();

                listClinicas = clinicas.Select(s => new ClinicaDto { id_clinica = s.CCLI_ID, clinica = s.CCLI_DESCRIPCION, ubigeo = s.CUBI_UBIGEO, direccion = s.SCLI_DIRECCION, telefono = s.SCLI_TELEFONO, anexo = s.SCLI_ANEXO, afiliado = s.FCLI_AFILIADO, plan_huerfano_ilimitado = s.FCLI_PLAN_HUERFANO_ILIMITADO, estado = s.FCLI_ESTADO, departamento = s.SUBI_DEPARTAMENTO, provincia = s.SUBI_PROVINCIA, distrito = s.SUBI_DISTRITO, pk_pg = s.SCLI_PK_POSTGRES }).ToList();

                if (!clinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetClinicasFiltro(string busqueda, string condicion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                    new SqlParameter("@isCondicion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = condicion },
                };

                List<DbContext.Entities.ClinicaFiltro> clinicas = new List<DbContext.Entities.ClinicaFiltro>();

                clinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.ClinicaFiltro>("SPRMDS_LIST_CLINICA_FILTRO", parameters);

                List<ClinicaDto> listClinicas = new List<ClinicaDto>();

                listClinicas = clinicas.Select(s => new ClinicaDto { id_clinica = s.CCLI_ID, clinica = s.CCLI_DESCRIPCION, direccion = s.SCLI_DIRECCION, telefono = s.SCLI_TELEFONO, anexo = s.SCLI_ANEXO, ubigeo = s.CUBI_UBIGEO, departamento = s.SUBI_DEPARTAMENTO, provincia = s.SUBI_PROVINCIA, distrito = s.SUBI_DISTRITO, afiliado = s.FCLI_AFILIADO, plan_huerfano_ilimitado = s.FCLI_PLAN_HUERFANO_ILIMITADO, pk_pg = s.SCLI_PK_POSTGRES }).ToList();

                /*if (!listClinicas.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> GetHistoriaClinicaFiltro_x_Dni(string busqueda, string condicion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                    new SqlParameter("@isCondicion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = condicion },
                };

                List<DbContext.Entities.HistoriaClinicaFiltro_x_Dni> clinicas = new List<DbContext.Entities.HistoriaClinicaFiltro_x_Dni>();

                clinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaFiltro_x_Dni>("SPRMDS_LIST_HISTORIACLINICA_X_DNI_PRUEBA", parameters);

                List<HistoriaClinica_x_DniDto> listClinicas = new List<HistoriaClinica_x_DniDto>();

                listClinicas = clinicas.Select(d => new HistoriaClinica_x_DniDto
                {
                    codigo = d.CODIGO,
                    nombres = d.NOMBRES,
                    paterno = d.PATERNO,
                    materno = d.MATERNO,
                    dni = d.DNI,
                    email = d.EMAIL,
                    paciente = d.PACIENTE,
                    //codigo = d.CPER_ID,
                    //nombres = d.SPER_NOMBRES,
                    //paterno = d.SPER_APELLIDO_PATERNO,
                    //materno = d.SPER_APELLIDO_MATERNO,
                    //dni = d.SPER_NUMERO_DOCUMENTO,
                    //email = d.SPER_EMAIL,
                }).ToList();


                return ServiceResponse.ReturnResultWith200(listClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddClinica(ClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isDescripcion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.clinica },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ubigeo },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isTelefono", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.telefono },
                    new SqlParameter("@isAnexo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.anexo },
                    new SqlParameter("@isAfiliafo", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.afiliado },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_CLINICA", parameters);

                dto.id_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> UpdateClinica(ClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoClinica", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_clinica},
                    new SqlParameter("@isDescripcion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.clinica },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ubigeo },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isTelefono", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.telefono },
                    new SqlParameter("@isAnexo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.anexo },
                    new SqlParameter("@isAfiliafo", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.afiliado },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_CLINICA", parameters);

                dto.id_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> DeleteClinica(ClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoClinica", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_clinica},
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_CLINICA", parameters);

                dto.id_clinica = Convert.ToInt64(response);
                dto.clinica = "borrado";

                return ServiceResponse.ReturnSuccess();

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}