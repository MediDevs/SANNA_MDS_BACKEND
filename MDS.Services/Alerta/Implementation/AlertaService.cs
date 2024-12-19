using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Services.AuditoriaLogin.Implementation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Alerta.Implementation
{
    public class AlertaService : IAlertaService
    {
        private readonly IUnitOfWork _uow;

        public AlertaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetAlertas()
        {
            try
            {
                List<DbContext.Entities.Alerta> alertas = new List<DbContext.Entities.Alerta>();

                alertas = await _uow.ExecuteStoredProcAll<DbContext.Entities.Alerta>("SPRMDS_LIST_ALERTAS");

                List<AlertaDto> listAlertas = new List<AlertaDto>();

                listAlertas = alertas.Select(s => new AlertaDto { codigoAlerta = s.CALT_ID, descripcion = s.SALT_DESCRIPCION }).ToList();

                if (!alertas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listAlertas);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
    }
}
