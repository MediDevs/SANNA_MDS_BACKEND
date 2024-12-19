using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.TipoDocumento.Implementation
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly IUnitOfWork _uow;

        public TipoDocumentoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetTipoDocumentos()
        {
            try
            {
                List<DbContext.Entities.TipoDocumento> tipoDocumentos = new List<DbContext.Entities.TipoDocumento>();

                tipoDocumentos = await _uow.ExecuteStoredProcAll<DbContext.Entities.TipoDocumento>("SPRMDS_LIST_TIPO_DOCUMENTO");

                List<TipoDocumentoDto> listTipoDocumentos = new List<TipoDocumentoDto>();

                listTipoDocumentos = tipoDocumentos.Select(s => new TipoDocumentoDto { id = s.CTDO_ID, descripcion = s.STDO_DESCRIPCION, codigo_sunat = s.STDO_SUNAT, codigo_susalud = s.STDO_SUSALUD, estado = s.FTDO_ESTADO }).ToList();

                if (!tipoDocumentos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listTipoDocumentos);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetTipoDocumentosSusalud()
        {
            try
            {
                List<DbContext.Entities.TipoDocumento> tipoDocumentos = new List<DbContext.Entities.TipoDocumento>();

                tipoDocumentos = await _uow.ExecuteStoredProcAll<DbContext.Entities.TipoDocumento>("SPRMDS_LIST_TIPO_DOCUMENTO_SUSALUD");

                List<TipoDocumentoDto> listTipoDocumentos = new List<TipoDocumentoDto>();

                listTipoDocumentos = tipoDocumentos.Select(s => new TipoDocumentoDto { id = s.CTDO_ID, descripcion = s.STDO_DESCRIPCION, codigo_sunat = s.STDO_SUNAT, codigo_susalud = s.STDO_SUSALUD, estado = s.FTDO_ESTADO }).ToList();

                if (!tipoDocumentos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listTipoDocumentos);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

    }
}
