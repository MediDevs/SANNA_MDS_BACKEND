using MDS.Dto;
using MDS.Dto.Resources;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.HistoriaClinica
{
    public interface IHistoriaClinicaService : IService
    {
        //////////////////          SERVICIO SCTR          //////////////////
        //By Henrry Torres
        Task<ServiceResponse> GetHistoriasClinicasSctrBandeja(string fechaInicio, string fechaFin, string condicion);

        //By Henrry Torres
        Task<ServiceResponse> GetHistoriaClinicaSctrByCodigo(string cod_historia_clinica);

        //By Henrry Torres
        Task<ServiceResponse> GetHistoriasClinicasSctrFiltro(string fechaInicio, string fechaFin, string busqueda, string condicion, int reporte);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> UpdateHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);
        //////////////////          FIN SERVICIO SCTR          //////////////////

        //////////////////          SERVICIO AMBULANCIA          //////////////////

        //By Henrry Torres
        Task<ServiceResponse> GetHistoriasClinicasAmbulanciaBandeja(AmbulanciaResource dto);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaAmbulanciaOrientacionMedica(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaAmbulancia(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaAmbulanciaEvento(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteHistoriaClinicaAmbulancia(HistoriaClinicaMtoDto dto);

        //////////////////          FIN SERVICIO AMBULANCIA          //////////////////

        //////////////////          SERVICIO MAD          //////////////////

        //By William Vilca
        Task<ServiceResponse> GetHistoriasClinicasMadFiltro_Rango_By_Fechas(string? vFechaInicio = null, string? vFechaFinal = null);

        //By William Vilca
        Task<ServiceResponse> GetHistoriasClinicasMadFiltro_Campos(string? vCampoBusqueda = null, string? vValorBusqueda = null);

        //By William Vilca
        Task<ServiceResponse> GetHistoriasClinicasMadFiltro(string? vCampoBusqueda = null, string? vValorBusqueda = null, string? vFechaInicio = null, string? vFechaFinal = null);


        //By William Vilca
        Task<ServiceResponse> GetSiteds_Numero(string vNumero);

        //By Henrry Torres
        Task<ServiceResponse> GetHistoriaClinicaMadByCodigo(int historiaClinicaId);
                
        //William Vilca
        //Consulta Bandeja
        Task<ServiceResponse> GetHistoriasClinicas(string vFechaIni, string vFechaFin, string vCondicion);
        
        //William Vilca
        //Consulta Mostrar Todas las Historias Clinicas
        Task<ServiceResponse> GetHistoriaClinicas();
        
        // William Vilca
        //Consulta x DNI 
        Task<ServiceResponse> GetHistoriaClinica_Mad_Cliente_Codigo(string vNumero);
        
        // William Vilca
        //Consulta x DNI 
        Task<ServiceResponse> GetHistoriaClinica_Mad_Siteds_Codigo(string vCodigo);
        
        // William Vilca
        //Consulta x DNI 
        Task<ServiceResponse> GetHistoriaClinica_Mad_Paciente_Distrito(string vDistrito);
        
        // William Vilca
        //Consulta x DNI 
        Task<ServiceResponse> GetHistoriaClinica_Mad_Paciente_Dni(string vNumero);
        
        // William Vilca
        //Listado de Clientes x Siteds
        Task<ServiceResponse> GetHistoriaClinica_Mad_Clientes_Siteds();
        
        // William Vilca
        //Listado de Clientes x Siteds
        Task<ServiceResponse> GetHistoriaClinica_Mad_Clientes_Siteds_By_Nombre(string vCliente);

        // William Vilca
        //Consulta x Aseguradora Caja Texto
        Task<ServiceResponse> GetHistoriaClinica_Mad_Aseguradora(string vAseguradora);
        
        // William Vilca
        //Consulta x Aseguradora = (Listado Combo Categoria) = VB6
        Task<ServiceResponse> GetHistoriaClinica_Mad_Aseguradora_Categoria(string vAseguradora);
        
        // William Vilca
        //Consulta x Genero de Asegurado = (Listado Combo Genero) = VB6
        Task<ServiceResponse> GetHistoriaClinica_Mad_Genero();
        
        // William Vilca
        //Consulta x Genero de Asegurado = (Listado Combo Tipo Documento) = VB6
        Task<ServiceResponse> GetHistoriaClinica_Mad_TipoDocumento();
        
        // William Vilca
        //Consulta x Genero de Asegurado = (Listado Combo Vip) = VB6
        Task<ServiceResponse> GetHistoriaClinica_Mad_Vip();
        
        //William Vilca
        //Paciente Clave = Combo - VB6
        Task<ServiceResponse> GetHistoriaClinica_Mad_Seguro();
        
        //William Vilca
        //Clasificacion = Combo - VB6
        Task<ServiceResponse> GetHistoriaClinica_Mad_Clasificacion();
        
        //William Vilca
        //Ubigeo = Combo - VB6
        Task<ServiceResponse> GetHistoriaClinica_Mad_Ubigeo_Codigo(string vDepartamento, string vProvincia, string vDistrito);

        //By William Vilca
        Task<ServiceResponse> GetHistoriaClinica_Mad_Ubigeo(string vDistrito);

        //By William Vilca
        Task<ServiceResponse> GetHistoriaClinica_Mad_Dni();

        //William Vilca
        Task<ServiceResponse> GetHistoriaClinica_Paciente_x_Dni(string vDni, string vNumero);

        //By Willian Vilca
        Task<ServiceResponse> AddHistoriaClinicaSiteds(SitedsMtoDto dto);

        //By William Vilca
        Task<ServiceResponse> RegistrarHistoriaClinica(RegistrarHistoriaClinicaDto dto);

        //By William Vilca
        Task<ServiceResponse> AddHistoriaClinicaMad(HistoriaClinicaMtoMadDto dto);

        //By William Vilca
        Task<ServiceResponse> AddHistoriaClinicaMedioComunicacionMad(HistoriaClinicaMedioComunicacionMtoMadDto dto);

        //////////////////          FIN SERVICIO MAD          //////////////////
        ///

        #region "Estado 0 - 2 - 3"
        Task<ServiceResponse> GetHistoriaClinica_Mad_Asignacion_Tiempo_Doctor(int codHistoriaClinica);
        Task<ServiceResponse> GetHistoriaClinica_Mad_Asignacion_By_Especialidad(string nombreEspecialidad, int personaId);
        Task<ServiceResponse> GetHistoriaClinica_Mad_Asignacion_By_Medico(string usuario, int clasificacion, int codigoEspecialidad, int personaId, string nombreMedico);
        Task<ServiceResponse> GetHistoriaClinica_Mad_Asignacion_Especiliadad_Medico(int codigoMedico, int codigoEspecialidad);
        Task<ServiceResponse> AddHistoriaClinicaMadAuditoriaEstado(HistoriaClinicaMadAuditoriaEstadoDto dto);
        Task<ServiceResponse> UpdateHistoriaClinicaMadEstado(HistoriaClinicaMadEstadoDto dto);
        Task<ServiceResponse> GetHistoriaClinicaMadTipoProgramacion();
        Task<ServiceResponse> GetHistoriaClinicaMadSubTipoProgramacion();
        #endregion

        #region "Estado 3 - 5"
        Task<ServiceResponse> GetHistoriaClinicaMadValidacionTiempo(int codigoHistoria, int codigoMedico);
        Task<ServiceResponse> AddHistoriaClinicaAuditoriaEstadoValidacionTiempo(HistoriaClinicaAuditoriaEstadoValidacionTiempoDto dto);
        Task<ServiceResponse> UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempo(UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempoDto dto);
        #endregion

        #region "Estado 5 - 6"
        Task<ServiceResponse> GetHistoriaClinicaMadConfirmarRecepcionMensaje(int numeroHistoria);
        Task<ServiceResponse> AddHistoriaClinicaAuditoriaEstadoRecepcionMensaje(AddHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto dto);
        Task<ServiceResponse> UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensaje(UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto dto);

        #endregion
    }
}

