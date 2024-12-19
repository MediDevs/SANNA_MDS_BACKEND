namespace MDS.Dto
{
    public class SitedsCodigoDto
    {
        public string id_cliente { get; set; }

        public string numero { get; set; }

        public string nombre { get; set; }
    }
    public class SitedsListaDto
    {

        public long numero { get; set; }
        public string paterno { get; set; }

        public string materno { get; set; }

        public string nombres { get; set; }

        public int edad { get; set; }

        public string fechanacimiento { get; set; }

        public string tipodocumento { get; set; }

        public string numerodocumento { get; set; }

        public string genero { get; set; }

        public string producto { get; set; }

        public string numeroautorizacion { get; set; }

        public string numerocontrato { get; set; }

        public string codigoafiliado { get; set; }

        public string numeropoliza { get; set; }

        public string moneda { get; set; }

        public decimal copagofijo { get; set; }

        public decimal copagovariable { get; set; }


    }

    public class SitedsMtoPruebaDto
    {
        public long csit_id { get; set; }

        public long chis_id { get; set; }

        public string ssit_documentoautorizacion { get; set; }

        public string ssit_codigoafiliado { get; set; }

        public int nsit_usuario_creacion { get; set; }

        public DateTime dsit_fecha_creacion { get; set; }

    }


    public class SitedsMtoDto
    {
        public long id_siteds { get; set; }

        public long id_historia { get; set; }


        public string documentoautorizacion { get; set; }

        public string codigoafiliado { get; set; }

        public string numeropoliza { get; set; }

        public string numerocontrato { get; set; }

        public string numerocertificado { get; set; }

        public string codproducto { get; set; }

        public string desproducto { get; set; }

        public string apellidopaternoafiliado { get; set; }

        public string apellidomaternoafiliado { get; set; }

        public string nombresafiliado { get; set; }

        public string codgenero { get; set; }

        public string desgenero { get; set; }

        public string codfechanacimiento { get; set; }

        public string fechanacimiento { get; set; }

        public string codparentesco { get; set; }

        public string desparentesco { get; set; }

        public string codtipodocumentoafiliado { get; set; }

        public string destipodocumentoafiliado { get; set; }

        public string numerodocumentoafiliado { get; set; }

        public int edad { get; set; }

        public string codfechainiciovigencia { get; set; }

        public string fechainiciovigencia { get; set; }

        public string codfechafinvigencia { get; set; }

        public string fechafinvigencia { get; set; }

        public string codestadocivil { get; set; }

        public string desestadocivil { get; set; }

        public int codtipoplan { get; set; }

        public string destipoplan { get; set; }

        public int numeroplan { get; set; }

        public string codestado { get; set; }

        public string desestado { get; set; }

        public string codfechaactualizacionfoto { get; set; }

        public string fechaactualizacionfoto { get; set; }

        public string apellidopaternotitular { get; set; }

        public string apellidomaternotitular { get; set; }

        public string nombrestitular { get; set; }

        public string codigotitular { get; set; }

        public string codtipodocumentotitular { get; set; }

        public string destipodocumentotitular { get; set; }

        public string numerodocumentotitular { get; set; }

        public int codmoneda { get; set; }

        public string desmoneda { get; set; }

        public string nombrecontratante { get; set; }

        public string codtipodocumentocontratante { get; set; }

        public string destipodocumentocontratante { get; set; }

        public string codtipoafiliacion { get; set; }


        public string destipoafiliacion { get; set; }

        public string codfechaafiliacion { get; set; }

        public string fechaafiliacion { get; set; }
        public string numerodocumentocontratante { get; set; }

        public string codigotipocobertura { get; set; }

        public string codigosubtipocobertura { get; set; }

        public string codigocobertura { get; set; }

        public string beneficios { get; set; }

        public string codindicadorrestriccion { get; set; }

        public string restricciones { get; set; }

        public decimal codcopagofijo { get; set; }

        public string descopagofijo { get; set; }

        public decimal codcopagovariable { get; set; }

        public string descopagovariable { get; set; }

        public string codfechafincarencia { get; set; }

        public string fechafincarencia { get; set; }

        public string condicionesespeciales { get; set; }

        public string observaciones { get; set; }

        public string codcalificacionservicio { get; set; }

        public string descalificacionservicio { get; set; }

        public string beneficiomaximoinicial { get; set; }

        public string numerocobertura { get; set; }

        public string fecha_creacion_doc_aut { get; set; }

        public DateTime hora_creacion_doc_aut { get; set; }

        public string descripcion_producto { get; set; }

        public int usuario_creacion { get; set; }

        public DateTime fecha_creacion { get; set; }

        public int usuario_modificacion { get; set; }

        public DateTime fecha_modificacion { get; set; }


    }
}