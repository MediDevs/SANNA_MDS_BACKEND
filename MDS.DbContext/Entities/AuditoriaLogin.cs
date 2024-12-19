using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Entities
{
    public class AuditoriaLogin 
    {
        public int CAUD_ID { get; set; }
        public string? SUSR_NOMBRE { get; set; }
        public string? SAUD_NOMBRE_USUARIO { get; set; }
        public long DAUD_FECHA { get; set; }
        public string SAUD_DIRECCION_IP { get; set; }
        public string SAUD_ORIGEN { get; set; }
        public string SAUD_LATITUD { get; set; }
        public string SAUD_LONGITUD { get; set; }
        public string SAUD_ESTADO { get; set; }
        public string SAUD_DESCRIPCION { get; set; }
    }
}
