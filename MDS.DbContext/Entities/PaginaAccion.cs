using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Entities
{
    public class PaginaAccion
    {
        public int CPAC_ID { get; set; }
        public string SSEC_NOMBRE { get; set; }
        public int CPAG_ID { get; set; }
        public string? SPAG_NOMBRE { get; set; }
        public string? SPAG_NOMBRE_MENU { get; set; }
        public string? SPAG_ICONO { get; set; }
        public string? SPAG_NOMBRE_SUB_SECCION { get; set; }
        public string? SPAG_ICONO_SUB_SECCION { get; set; }
        public string? SPAG_URL { get; set; }
        public int CACC_ID { get; set; }
        public string? SACC_NOMBRE { get; set; }
    }
}
