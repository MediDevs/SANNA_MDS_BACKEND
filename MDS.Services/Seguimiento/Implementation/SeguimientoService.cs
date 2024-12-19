using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Seguimiento.Implementation
{
    public class SeguimientoService : ISeguimientoService
    {
        private readonly IUnitOfWork _uow;

        public SeguimientoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetSeguimientoByHistoriaClinica(string codHistoriaClinica)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCodigoHistoriaClinica", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = codHistoriaClinica }
                };

                List<DbContext.Entities.SeguimientoList> seguimientos = new List<DbContext.Entities.SeguimientoList>();

                seguimientos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.SeguimientoList>("SPRMDS_LIST_SEGUIMIENTO_BY_HISTORIA_CLINICA", parameters);

                List<SeguimientoDto> listSeguimientos = new List<SeguimientoDto>();

                listSeguimientos = seguimientos.Select(s => new SeguimientoDto { cod_historia_clinica = s.cod_historia_clinica, fecha_creacion = s.fecha_creacion,hora_creacion=s.hora_creacion, observacion = s.observacion, usuario = s.usuario, servicio=s.servicio }).ToList();

                /*if (!listClinicas.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listSeguimientos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddSeguimientoSctr(SeguimientoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCodigoHistoriaClinica", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_historia_clinica },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@isCodigoServicio", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.cod_servicio },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_SEGUIMIENTO", parameters);

                dto.cod_seguimiento = response.ToString();

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}