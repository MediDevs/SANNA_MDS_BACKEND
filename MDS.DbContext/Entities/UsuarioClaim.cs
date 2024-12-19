using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Entities
{
    public class UsuarioClaim
    {
        public int CUCL_ID { get; set; }
        public int CACC_ID { get; set; }
        public int CPAG_ID { get; set; }
        public int CUSR_ID { get; set; }
        public string? SUCL_TIPO_CLAIM { get; set; }
        public string? SUCL_VALOR_CLAIM { get; set; }
    }
}
