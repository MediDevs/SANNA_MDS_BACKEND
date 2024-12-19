using System.ComponentModel.DataAnnotations;

namespace MDS.DbContext.Entities
{
    public class SitedsCodigo
    {
        public string ID_CLIENTE { get; set; }

        public string NUMERO { get; set; }

        public string NOMBRE { get; set; }
    }
    public class SitedsLista
    {
        public long NUMERO { get; set; }
        public string PATERNO { get; set; }

        public string MATERNO { get; set; }

        public string NOMBRES { get; set; }

        public int EDAD { get; set; }

        public string FECHANACIMIENTO { get; set; }

        public string TIPODOCUMENTO { get; set; }

        public string NUMERODOCUMENTO { get; set; }

        public string GENERO { get; set; }

        public string PRODUCTO { get; set; }

        public string NUMEROAUTORIZACION { get; set; }

        public string NUMEROCONTRATO { get; set; }

        public string CODIGOAFILIADO { get; set; }

        public string NUMEROPOLIZA { get; set; }

        public string MONEDA { get; set; }

        public decimal COPAGOFIJO  { get; set; }

        public decimal COPAGOVARIABLE { get; set; }
    }
    public class Siteds
    {
        public long CSIT_ID { get; set; }
        public long CHIS_ID { get; set; }
        public string SSIT_DOCUMENTOAUTORIZACION { get; set; }
        public string SSIT_CODIGOAFILIADO { get; set; }
        public string SSIT_NUMEROPOLIZA { get; set; }
        public string SSIT_NUMEROCONTRATO { get; set; }
        public string SSIT_NUMEROCERTIFICADO { get; set; }
        public string SSIT_CODPRODUCTO { get; set; }
        public string SSIT_DESPRODUCTO { get; set; }
        public string SSIT_APELLIDOPATERNOAFILIADO { get; set; }
        public string SSIT_APELLIDOMATERNOAFILIADO { get; set; }
        public string SSIT_NOMBRESAFILIADO { get; set; }
        public string SSIT_CODGENERO { get; set; }
        public string SSIT_DESGENERO { get; set; }
        public string SSIT_CODFECHANACIMIENTO { get; set; }
        public string SSIT_FECHANACIMIENTO { get; set; }
        public string SSIT_CODPARENTESCO { get; set; }
        public string SSIT_DESPARENTESCO { get; set; }
        public string SSIT_CODTIPODOCUMENTOAFILIADO { get; set; }
        public string SSIT_DESTIPODOCUMENTOAFILIADO { get; set; }
        public string SSIT_NUMERODOCUMENTOAFILIADO { get; set; }
        public int NSIT_EDAD { get; set; }
        public string SSIT_CODFECHAINICIOVIGENCIA { get; set; }
        public string SSIT_FECHAINICIOVIGENCIA { get; set; }
        public string SSIT_CODFECHAFINVIGENCIA { get; set; }
        public string SSIT_FECHAFINVIGENCIA { get; set; }
        public string SSIT_CODESTADOCIVIL { get; set; }
        public string SSIT_DESESTADOCIVIL { get; set; }
        public int NSIT_CODTIPOPLAN { get; set; }
        public string SSIT_DESTIPOPLAN { get; set; }
        public int NSIT_NUMEROPLAN { get; set; }
        public string SSIT_CODESTADO { get; set; }
        public string SSIT_DESESTADO { get; set; }
        public string SSIT_CODFECHAACTUALIZACIONFOTO { get; set; }
        public string SSIT_FECHAACTUALIZACIONFOTO { get; set; }
        public string SSIT_APELLIDOPATERNOTITULAR { get; set; }
        public string SSIT_APELLIDOMATERNOTITULAR { get; set; }
        public string SSIT_NOMBRESTITULAR { get; set; }
        public string SSIT_CODIGOTITULAR { get; set; }
        public string SSIT_CODTIPODOCUMENTOTITULAR { get; set; }
        public string SSIT_DESTIPODOCUMENTOTITULAR { get; set; }
        public string SSIT_NUMERODOCUMENTOTITULAR { get; set; }
        public int NSIT_CODMONEDA { get; set; }
        public string SSIT_DESMONEDA { get; set; }
        public string SSIT_NOMBRECONTRATANTE { get; set; }
        public string SSIT_CODTIPODOCUMENTOCONTRATANTE { get; set; }
        public string SSIT_DESTIPODOCUMENTOCONTRATANTE { get; set; }
        public string SSIT_CODTIPOAFILIACION { get; set; }
        public string SSIT_DESTIPOAFILIACION { get; set; }
        public string SSIT_CODFECHAAFILIACION { get; set; }
        public string SSIT_FECHAAFILIACION { get; set; }      
        public string SSIT_NUMERODOCUMENTOCONTRATANTE { get; set; }
        public string SSIT_CODIGOTIPOCOBERTURA { get; set; }
        public string SSIT_CODIGOSUBTIPOCOBERTURA { get; set; }
        public string SSIT_CODIGOCOBERTURA { get; set; }
        public string SSIT_BENEFICIOS { get; set; }
        public string SSIT_CODINDICADORRESTRICCION { get; set; }
        public string SSIT_RESTRICCIONES { get; set; }
        public decimal NSIT_CODCOPAGOFIJO { get; set; }
        public string SSIT_DESCOPAGOFIJO { get; set; }
        public decimal NSIT_CODCOPAGOVARIABLE { get; set; }
        public string SSIT_DESCOPAGOVARIABLE { get; set; }
        public string SSIT_CODFECHAFINCARENCIA { get; set; }
        public string SSIT_FECHAFINCARENCIA { get; set; }
        public string SSIT_CONDICIONESESPECIALES { get; set; }
        public string SSIT_OBSERVACIONES { get; set; }
        public string SSIT_CODCALIFICACIONSERVICIO { get; set; }
        public string SSIT_DESCALIFICACIONSERVICIO { get; set; }
        public string SSIT_BENEFICIOMAXIMOINICIAL { get; set; }
        public string SSIT_NUMEROCOBERTURA { get; set; }
        public string SSIT_FECHA_CREACION_DOC_AUT { get; set; }
        public DateTime DSIT_HORA_CREACION_DOC_AUT { get; set; }
        public string SSIT_DESCRIPCION_PRODUCTO { get; set; }
        public int NSIT_USUARIO_CREACION { get; set; }
        public DateTime DSIT_FECHA_CREACION { get; set; }
        public int NSIT_USUARIO_MODIFICACION { get; set; }
        public DateTime DSIT_FECHA_MODIFICACION { get; set; }

    }

    //ConsultaAsegNom
    public class Request_Asegurado
    {
        public string? CodTipoDocumentoAfiliado { get; set; }
        public string? NumeroDocumentoAfiliado { get; set; }
        [Required]
        public string RUC { get; set; }
        [Required]
        public string SUNASA { get; set; }
        [Required]
        public string IAFAS { get; set; }
        public string? NombresAfiliado { get; set; }
        public string? ApellidoPaternoAfiliado { get; set; }
        public string? ApellidoMaternoAfiliado { get; set; }
        public string? CodEspecialidad { get; set; }
    }

    //"ConsultaAsegCod", "ConsultaObservacion", "ConsultaDatosAdicionales", "ConsultaCondicionMedica"
    public class Request_AsegCod_Obs_DatAdic_CondMed
    {
        public string? SUNASA { get; set; }
        public string? IAFAS { get; set; }
        public string? RUC { get; set; }
        public string? NombresAfiliado { get; set; }
        public string? ApellidoPaternoAfiliado { get; set; }
        public string? ApellidoMaternoAfiliado { get; set; }
        public string? CodigoAfiliado { get; set; }
        public string? CodTipoDocumentoAfiliado { get; set; }
        public string? NumeroDocumentoAfiliado { get; set; }
        public string? CodEspecialidad { get; set; }
        public string? CodProducto { get; set; }
        public string? DesProducto { get; set; }
        public string? NumeroPlan { get; set; }
        public string? CodTipoDocumentoContratante { get; set; }
        public string? NumeroDocumentoContratante { get; set; }
        public string? NombreContratante { get; set; }
        public string? CodParentesco { get; set; }
        public string? TipoCalificadorContratante { get; set; }
        public string? NumeroCobertura { get; set; }
        public string? BeneficioMaximoInicial { get; set; }
        public string? CodigoTipoCobertura { get; set; }
        public string? CodigoSubTipoCobertura { get; set; }
    }

    //ConsultaNumeroAutorizacion
    public class Request_NumeroAutorizacion
    {
        public string? ApellidoMaternoAfiliado { get; set; }
        public string? ApellidoPaternoAfiliado { get; set; }
        public string? BeneficioMaximoInicial { get; set; }
        public string? CodigoAfiliado { get; set; }
        public string? CodigoTitular { get; set; }
        public string? CodCalificacionServicio { get; set; }
        public string? CodEstado { get; set; }
        public string? CodEspecialidad { get; set; }
        public string? CodMoneda { get; set; }
        public string? CodCopagoFijo { get; set; }
        public string? CodCopagoVariable { get; set; }
        public string? CodParentesco { get; set; }
        public string? CodProducto { get; set; }
        public string? NumeroDocumentoContratante { get; set; }
        public string? CodSubTipoCobertura { get; set; }
        public string? CodTipoCobertura { get; set; }
        public string? CodTipoAfiliacion { get; set; }
        public string? DesProducto { get; set; }
        public string? CodEstadoMarital { get; set; }
        public string? CodFechaFinCarencia { get; set; }
        public string? CodFechaAfiliacion { get; set; }
        public string? CodFechaInicioVigencia { get; set; }
        public string? CodFechaNacimiento { get; set; }
        public string? CodGenero { get; set; }
        public string? SUNASA { get; set; }
        public string? IAFAS { get; set; }
        public string? CondicionesEspeciales { get; set; }
        public string? ApellidoMaternoTitular { get; set; }
        public string? NombreContratante { get; set; }
        public string? ApellidoPaternoTitular { get; set; }
        public string? NombresAfiliado { get; set; }
        public string? NombresTitular { get; set; }
        public string? NumeroCertificado { get; set; }
        public string? NumeroContrato { get; set; }
        public string? NumeroDocumentoAfiliado { get; set; }
        public string? NumeroDocumentoTitular { get; set; }
        public string? NumeroPlan { get; set; }
        public string? NumeroPoliza { get; set; }
        public string? RUC { get; set; }
        public string? CodTipoDocumentoContratante { get; set; }
        public string? CodTipoDocumentoAfiliado { get; set; }
        public string? CodTipoDocumentoTitular { get; set; }
        public string? CodTipoPlan { get; set; }
        public string? CodIndicadorRestriccion { get; set; }
    }

    //"ObtenerFoto"
    public class Request_ObtenerFoto
    {
        public string Iafas { get; set; }
        public string CodigoAfiliado { get; set; }
        public string CodFechaActualizacionFoto { get; set; }
    }

    public class Response_Siteds
    {
        public DatosAfiliado DatosAfiliado { get; set; }
        public List<Coberturas> Coberturas { get; set; }
    }

    public class Coberturas
    {
        public string CodigoTipoCobertura { get; set; }
        public string CodigoSubTipoCobertura { get; set; }
        public string CodigoCobertura { get; set; }
        public string Beneficios { get; set; }
        public string CodIndicadorRestriccion { get; set; }
        public string Restricciones { get; set; }
        public string CodCopagoFijo { get; set; }
        public string DesCopagoFijo { get; set; }
        public string CodCopagoVariable { get; set; }
        public string DesCopagoVariable { get; set; }
        public string CodFechaFinCarencia { get; set; }
        public string FechaFinCarencia { get; set; }
        public string CondicionesEspeciales { get; set; }
        public string Observaciones { get; set; }
        public string CodCalificacionServicio { get; set; }
        public string DesCalificacionServicio { get; set; }
        public string BeneficioMaximoInicial { get; set; }
        public string NumeroCobertura { get; set; }
        public string CodTipoMoneda { get; set; }
        public string DesTipoMoneda { get; set; }
    }

    public class DatosAfiliado
    {
        public string CodigoAfiliado { get; set; }
        public string NumeroPoliza { get; set; }
        public string NumeroContrato { get; set; }
        public string NumeroCertificado { get; set; }
        public string CodProducto { get; set; }
        public string DesProducto { get; set; }
        public string ApellidoPaternoAfiliado { get; set; }
        public string ApellidoMaternoAfiliado { get; set; }
        public string NombresAfiliado { get; set; }
        public string CodGenero { get; set; }
        public string DesGenero { get; set; }
        public string CodFechaNacimiento { get; set; }
        public string FechaNacimiento { get; set; }
        public string CodParentesco { get; set; }
        public string DesParentesco { get; set; }
        public string CodTipoDocumentoAfiliado { get; set; }
        public string DesTipoDocumentoAfiliado { get; set; }
        public string NumeroDocumentoAfiliado { get; set; }
        public string Edad { get; set; }
        public string CodFechaInicioVigencia { get; set; }
        public string FechaInicioVigencia { get; set; }
        public string CodFechaFinVigencia { get; set; }
        public string FechaFinVigencia { get; set; }
        public string CodEstadoCivil { get; set; }
        public string DesEstadoCivil { get; set; }
        public string CodTipoPlan { get; set; }
        public string DesTipoPlan { get; set; }
        public string NumeroPlan { get; set; }
        public string CodEstado { get; set; }
        public string DesEstado { get; set; }
        public string CodFechaActualizacionFoto { get; set; }
        public string FechaActualizacionFoto { get; set; }
        public string ApellidoPaternoTitular { get; set; }
        public string ApellidoMaternoTitular { get; set; }
        public string NombresTitular { get; set; }
        public string CodigoTitular { get; set; }
        public string CodTipoDocumentoTitular { get; set; }
        public string DesTipoDocumentoTitular { get; set; }
        public string NumeroDocumentoTitular { get; set; }
        public string CodMoneda { get; set; }
        public string DesMoneda { get; set; }
        public string NombreContratante { get; set; }
        public string CodTipoDocumentoContratante { get; set; }
        public string DesTipoDocumentoContratante { get; set; }
        public string CodTipoAfiliacion { get; set; }
        public string DesTipoAfiliacion { get; set; }
        public string CodFechaAfiliacion { get; set; }
        public string FechaAfiliacion { get; set; }
        public string NumeroDocumentoContratante { get; set; }
        public string NumeroContratoAfiliado { get; set; }
        public string TipoCalificadorContratante { get; set; }
        public string CodSubTipoCobertura { get; set; }
        public string CodTipoCobertura { get; set; }
        public string CodEstadoMarital { get; set; }
        public string NumeroSCTR { get; set; }
    }

    public class Response_cod_autorizacion
    {
        public string NumeroAutorizacion { get; set; }
        public string Documento { get; set; }
    }

    public class Response_observaciones
    {
        public string IndObservacionAsegurado { get; set; }
        public string IndObservacionesEspeciales { get; set; }
        public string Observaciones { get; set; }
    }

    public class Response_datos_adicionales
    {
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Ubigeo { get; set; }
        public string Contacto { get; set; }
        public string Calificador { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
    }

    public class Response_condicion_medica
    {
        public Preexistencia Preexistencia { get; set; }
        public Exclusiones Exclusiones { get; set; }
        public Carencia Carencia { get; set; }
        public Antecedentes Antecedentes { get; set; }
        public Enfermedad Enfermedad { get; set; }
    }

    public class Response_procedimientos_especiales
    {
        public Procedimiento Procedimiento { get; set; }
        public TiempoEspera TiempoEspera { get; set; }
        public ExcepcionCarencia ExcepcionCarencia { get; set; }
    }

    public class Procedimiento
    {
        public string Descripcion { get; set; }
        public Detalle Detalle { get; set; }
    }

    public class TiempoEspera
    {
        public string Descripcion { get; set; }
        public Detalle Detalle { get; set; }
    }

    public class ExcepcionCarencia
    {
        public string Descripcion { get; set; }
        public Detalle Detalle { get; set; }
    }

    public class Detalle
    {
        public string Codigo { get; set; }
        public string Procedimiento { get; set; }
        public string Genero { get; set; }
        public string CodCopagoFijo { get; set; }
        public string DesCopagoFijo { get; set; }
        public string CodCopagoVariable { get; set; }
        public string DesCopagoVariable { get; set; }
        public string Frecuencia { get; set; }
        public string Tiempo { get; set; }
        public string Observaciones { get; set; }
    }

    public class Response_ObtenerFoto
    {
        public string Foto { get; set; }
    }

    public class Preexistencia
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Exclusiones
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Carencia
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Antecedentes
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Enfermedad
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Condicion
    {
        public string Codigo { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }
    }

}