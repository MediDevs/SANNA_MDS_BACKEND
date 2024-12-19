using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Entities
{
    public class RolClaim
    {
        public int CRCL_ID { get; set; }
        public int CACC_ID { get; set; }
        public int CPAG_ID { get; set; }
        public int CROL_ID { get; set; }
        public string? SRCL_TIPO_CLAIM { get; set; }
        public string? SRCL_VALOR_CLAIM { get; set; }
    }
}
