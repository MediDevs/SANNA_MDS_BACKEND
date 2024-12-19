using MDS.Infrastructure.DbUtility;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MDS.DbContext.Entities
{
    public class TipoDocumento
    {
        public long CTDO_ID { get; set; }
        public string STDO_DESCRIPCION { get; set; }
        public string STDO_SUNAT { get; set; }
        public string STDO_SUSALUD { get; set; }
        public Boolean FTDO_ESTADO { get; set; }
    }
}
