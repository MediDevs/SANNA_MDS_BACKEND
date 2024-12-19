using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using System;

namespace MDS.Services.Persona.Implementation
{
    public class PersonaService : IPersonaService
    {

        private readonly IUnitOfWork _uow;

        public PersonaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetPersonas()
        {
            try
            {
                List<DbContext.Entities.Persona> personas = new List<DbContext.Entities.Persona>();

                personas = await _uow.ExecuteStoredProcAll<DbContext.Entities.Persona>("SPRMDS_LIST_PERSONA");

                List<PersonaDto> listPersona = new List<PersonaDto>();

                listPersona = personas.Select(p => new PersonaDto { id_persona = p.CPER_ID, paterno = p.SPER_APELLIDO_PATERNO, materno = p.SPER_APELLIDO_MATERNO, nombre = p.SPER_NOMBRES, dni = p.SPER_NUMERO_DOCUMENTO, genero = p.NPER_GENERO }).ToList();

                if (!personas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listPersona);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
        //By William Vilca
        public async Task<ServiceResponse> GetPersonaCodigo()
        {
            try
            {
                List<DbContext.Entities.PersonaCodigo> personas = new List<DbContext.Entities.PersonaCodigo>();

                personas = await _uow.ExecuteStoredProcAll<DbContext.Entities.PersonaCodigo>("SPRMDS_LIST_PERSONA_CODIGO");

                List<PersonaCodigoDto> listPersona = new List<PersonaCodigoDto>();

                listPersona = personas.Select(p => new PersonaCodigoDto 
                { 
                    id_persona = p.CPER_ID
                }).ToList();

                if (!personas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listPersona);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
        //By William Vilca
        public async Task<ServiceResponse> GetPersona(long personaId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = personaId },
                };


                List<DbContext.Entities.Persona> personas = new List<DbContext.Entities.Persona>();

                personas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Persona>("SPRMDS_LIST_PERSONA_BY_PARAM", parameters);

                List<PersonaDto> listPersona = new List<PersonaDto>();

                listPersona = personas.Select(p => new PersonaDto { id_persona = p.CPER_ID, paterno = p.SPER_APELLIDO_PATERNO, materno = p.SPER_APELLIDO_MATERNO, nombre = p.SPER_NOMBRES, dni = p.SPER_NUMERO_DOCUMENTO, genero = p.NPER_GENERO }).ToList();

                if (!listPersona.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listPersona);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetPersona_x_Dni(string vDni)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@DNI", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = vDni},
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_LIST_PERSONA_BY_DNI", parameters);

                int vRpta = 0;

                vRpta = response;

                return ServiceResponse.ReturnResultWith201(vRpta);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddPersonaSctr(MantenimientoPersonaDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SPER_NOMBRES", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@SPER_APELLIDO_PATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.paterno },
                    new SqlParameter("@SPER_APELLIDO_MATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.materno },
                    new SqlParameter("@CTDO_ID", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.tipo_documento },
                    new SqlParameter("@SPER_NUMERO_DOCUMENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numero_documento },
                    new SqlParameter("@DPER_FECHA_NACIMIENTO", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_naciemiento },
                    new SqlParameter("@NPER_GENERO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.genero },
                    new SqlParameter("@SPER_TELEFONO_CELULAR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefono_celular },
                    new SqlParameter("@NPER_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_PACIENTE_SCTR", parameters);

                dto.Id_persona = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
        //By William Vilca
        public async Task<ServiceResponse> AddPersonaMad(MantenimientoPersonaMadDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CTDO_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_documento },
                    new SqlParameter("@CPAI_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_pais },
                    new SqlParameter("@SPER_NUMERO_DOCUMENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numero_documento },
                    new SqlParameter("@SPER_NOMBRES", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombres },
                    new SqlParameter("@SPER_APELLIDO_PATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.apellido_paterno },
                    new SqlParameter("@SPER_APELLIDO_MATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.apellido_materno },
                    //new SqlParameter("@DPER_FECHA_NACIMIENTO", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_nacimiento },
                    new SqlParameter("@NPER_GENERO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.genero },
                    //new SqlParameter("@SDIR_DESCRIPCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.descripcion },
                    new SqlParameter("@SPER_TELEFONO_CELULAR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefono_celular },
                    new SqlParameter("@FPER_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@NPER_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    //new SqlParameter("@DPER_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };
                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_PERSONA_MAD", parameters);
                dto.id_persona = Convert.ToInt64(response);
                return ServiceResponse.ReturnResultWith201(dto);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }
        
        //By William Vilca
        public async Task<ServiceResponse> ActualizarPersonaMad(MantenimientoPersonaMadActualizarDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CPER_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@CTDO_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_documento },
                    new SqlParameter("@CPAI_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_pais },
                    new SqlParameter("@SPER_NUMERO_DOCUMENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numero_documento },
                    new SqlParameter("@SPER_NOMBRES", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombres },
                    new SqlParameter("@SPER_APELLIDO_PATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.apellido_paterno },
                    new SqlParameter("@SPER_APELLIDO_MATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.apellido_materno },
                    new SqlParameter("@DPER_FECHA_NACIMIENTO", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_nacimiento },
                    new SqlParameter("@SPER_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email },
                    new SqlParameter("@NPER_GENERO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.genero },
                    new SqlParameter("@SPER_TELEFONO_CELULAR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefono_celular },
                    new SqlParameter("@FPER_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@NPER_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DPER_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };
                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_PERSONA_MAD", parameters);
                dto.id_persona = Convert.ToInt64(response);
                return ServiceResponse.ReturnResultWith201(dto);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}