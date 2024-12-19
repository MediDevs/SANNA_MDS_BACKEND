using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Dto
{
    public class AmbulanciaDto
    {
        public string cod_atencion { get; set; }
        public string codigo_siteds { get; set; }
        public string cotizado { get; set; }
        public string estado { get; set; }
        public string ambulancia_resp { get; set; }
        public string servicio { get; set; }
        public string paciente { get; set; }
        public string dni { get; set; }
        public string distrito { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        public string direccion { get; set; }
        public string cliente { get; set; }
        public string proveedor { get; set; }
        public string ambulancia { get; set; }
        public string tiempo { get; set; }
        public string fecha_estimada { get; set; }
        public string hora_estimada { get; set; }
        public string fecha_llegada { get; set; }
        public string hora_llegada { get; set; }
        public string fecha_fin_ate { get; set; }
        public string hora_fin_ate { get; set; }
        public string referencia { get; set; }
        public string tlf_celular { get; set; }
        public string usuario_creacion { get; set; }
        public string descripcion_motivo { get; set; }
        public string flg_fuera_cobertura { get; set; }
        public string flg_citrix { get; set; }
        public string estado_exp { get; set; }
        public string codigo_prov { get; set; }

    }

    public class TipoServicioAmbulanciaDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
    }
    
    public class PrioridadAmbulanciaDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
    }

    public class TipoAmbulanciaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class TipoTrasladoAmbulanciaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class TipoPolizaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class ValidarTipoPolizaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Boolean placa { get; set; }
        public Boolean poliza { get; set; }
        public Boolean siniestro { get; set; }
    }

    public class MotivoAtencionAmbulanciaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class ProductoAmbulanciaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class SedeTrasladoAmbulanciaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class ProveedorAmbulanciaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class TipoComprobanteDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}