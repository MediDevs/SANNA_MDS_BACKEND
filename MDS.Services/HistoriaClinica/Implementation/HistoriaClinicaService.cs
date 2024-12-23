using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using MDS.Dto.Resources;
using MDS.DbContext.Entities;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace MDS.Services.HistoriaClinica.Implementation
{
    public class HistoriaClinicaService : IHistoriaClinicaService
    {
        private readonly IUnitOfWork _uow;

        public HistoriaClinicaService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        //////////////////          SERVICIO MAD          //////////////////

        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriaClinicaMadByCodigo(int historiaClinicaId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCodigoHistoriaClinica", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = historiaClinicaId },
                };

                List<DbContext.Entities.HistoriaClinicaMad> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMad>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMad>("SPRMDS_LIST_HISTORIA_CLINICA_BY_CODIGO_MAD", parameters);

                List<HistoriaClinicaDto> listHistoriasClinicas = new List<HistoriaClinicaDto>();

                listHistoriasClinicas = historiasClinicas.Select(p => new HistoriaClinicaDto
                {
                    cod_historia_clinica = p.cod_historia_clinica,
                    id_paciente = p.id_paciente,
                    id_medico = p.id_medico,
                    id_cliente = p.id_cliente,
                    vip = p.vip,
                    hora_atencion = p.hora_atencion,
                    fecha_creacion = p.fecha_creacion,
                    sintomas = p.sintomas,
                    tipo_atencion = p.tipo_atencion,
                    programacion = p.programacion,
                    nro_descanso_medico = p.nro_descanso_medico,
                    cambio_realizar = p.cambio_realizar,
                    moneda_deducible = p.moneda_deducible,
                    monto_deducible = p.monto_deducible,
                    coaseguro = p.coaseguro,
                    tipo_documento_pago = p.tipo_documento_pago,
                    numero_documento_pago = p.numero_documento_pago,
                    forma_pago = p.forma_pago,
                    moneda_denominacion = p.moneda_denominacion,
                    monto_denominacion = p.monto_denominacion,
                    fecha_nacimiento = p.fecha_nacimiento,
                    paciente = p.paciente,
                    medico = p.medico,
                    aseguradora = p.aseguradora,
                    especialidad = p.especialidad,
                    telefono = p.telefono,
                    celular = p.celular,
                    anexo = p.anexo,
                    referencia = p.referencia,
                    direccion = p.direccion,
                    provincia = p.provincia,
                    distrito = p.distrito
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Willian Vilca
        //CONSULTA POR ASEGURADORA = CAJA TEXTO
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Aseguradora(string vAseguradora)
        {
            try
            {

                SqlParameter[] parameters =
                {
            new SqlParameter("@isAseguradora", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vAseguradora },
        };

                List<DbContext.Entities.ClienteAseguradora> clientes = new List<DbContext.Entities.ClienteAseguradora>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.ClienteAseguradora>("SPRMDS_LIST_HISTORIACLINICA_MAD_ASEGURADORA", parameters);

                List<ClienteAseguradoraDto> listCliente = new List<ClienteAseguradoraDto>();

                listCliente = clientes.Select(c => new ClienteAseguradoraDto
                {
                    id_cliente = c.CCLT_ID,
                    //id_cliente = c.SIAF_FINANCIAMIENTO,
                    nombre = c.SCLT_NOMBRE
                }).ToList();


                /*if (!listCliente.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddHistoriaClinicaMedioComunicacionMad(HistoriaClinicaMedioComunicacionMtoMadDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@HISTORIA_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.id_historiaclinica },
                    new SqlParameter("@NUMERO",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.numero },
                    new SqlParameter("@USUARIO_CREACION",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIACLINICAMEDIOCOMUNICACION_MAD", parameters);

                dto.id_historiaclinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddHistoriaClinicaMad(HistoriaClinicaMtoMadDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CMED_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cmed_id },
                    new SqlParameter("@CPAC_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cpac_id },
                    new SqlParameter("@CESP_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cesp_id },
                    new SqlParameter("@CEST_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cest_id },
                    new SqlParameter("@CPER_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cper_id },
                    new SqlParameter("@CSER_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cser_id },
                    new SqlParameter("@CPAI_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cpai_id },
                    new SqlParameter("@CUBI_ID",SqlDbType.Char){Direction = ParameterDirection.Input, Value = dto.cubi_id },
                    new SqlParameter("@CMEP_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cmep_id },
                    new SqlParameter("@CTDO_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.ctdo_id },
                    new SqlParameter("@CCLT_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cclt_id },
                    new SqlParameter("@CDSN_ID",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cdsn_id },
                    new SqlParameter("@ESTADO",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@PROG",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.prog },
                    new SqlParameter("@CODAUTORIZACION", SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.codautorizacion },
                    new SqlParameter("@FECLLA",SqlDbType.DateTime){Direction = ParameterDirection.Input, Value = dto.feclla },
                    new SqlParameter("@HORLLA",SqlDbType.DateTime){Direction = ParameterDirection.Input, Value = dto.horlla },
                    new SqlParameter("@TIEMPO", SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.tiempo },
                    new SqlParameter("@FECATE",SqlDbType.DateTime){Direction = ParameterDirection.Input, Value = dto.fecate },
                    new SqlParameter("@HORATE",SqlDbType.DateTime){Direction = ParameterDirection.Input, Value = dto.horate },
                    new SqlParameter("@HRLLEDR",SqlDbType.DateTime){Direction = ParameterDirection.Input, Value = dto.hrlledr },
                    new SqlParameter("@HOROPLLA",SqlDbType.DateTime){Direction = ParameterDirection.Input, Value = dto.horoplla },
                    new SqlParameter("@FPAGO",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.fpago },
                    new SqlParameter("@VIP",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.vip },
                    new SqlParameter("@GRUPO",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.grupo },
                    new SqlParameter("@CONT",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cont },
                    new SqlParameter("@PERFIL",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.perfil },
                    new SqlParameter("@EMPRESA",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.empresa },


                    //INICIO DE NUEVOS CAMPOS

                    new SqlParameter("@FLG_CM_NUEVA",SqlDbType.Bit){Direction = ParameterDirection.Input, Value = dto.flg_cm_nueva },

                    new SqlParameter("@USULLA_ATE",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.usulla_ate },

                    new SqlParameter("@COD_EMP",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.cod_emp },

                    new SqlParameter("@FLAG_PROGRAMADA",SqlDbType.Bit){Direction = ParameterDirection.Input, Value = dto.flag_programada },

                    new SqlParameter("@F_SOLDOCT",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.f_soldoct },

                    new SqlParameter("@MOTIVO_TIPO_PROG",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.motivo_tipo_prog },

                    new SqlParameter("@OBSERVACION",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.observacion },

                    new SqlParameter("@TAR_ATE",SqlDbType.Decimal){Direction = ParameterDirection.Input, Value = dto.tar_ate },

                    new SqlParameter("@CAMBIO",SqlDbType.Decimal){Direction = ParameterDirection.Input, Value = dto.cambio },

                    new SqlParameter("@CODTAR_ATE",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.codtar_ate },

                    new SqlParameter("@NTAR_ATE",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.ntar_ate },

                    new SqlParameter("@TARJ_MC",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.tarj_mc },

                    new SqlParameter("@FVENC_ATE",SqlDbType.DateTime){Direction = ParameterDirection.Input, Value = dto.fvenc_ate },

                    new SqlParameter("@SIN_ATE",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.sin_ate },

                    new SqlParameter("@CONTACTO_PAC",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.contacto_pac },

                    new SqlParameter("@CONTACTO_ASEG",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.contacto_aseg },

                    new SqlParameter("@COD_AUT_PRESTACION",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.cod_aut_prestacion },

                    new SqlParameter("@COD_ASEGURADO",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.cod_asegurado },

                    new SqlParameter("@COD_SOLGEN",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.cod_solgen },

                    new SqlParameter("@CM_ASEG_PRODUCTO",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.cm_aseg_producto },

                    new SqlParameter("@POLIZA_ASEGURADO",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.poliza_asegurado },

                    new SqlParameter("@POLIZA_CERTIFICADO",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.poliza_certificado },

                    new SqlParameter("@TIPO_AFILIACION",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.tipo_afiliacion },

                    new SqlParameter("@ID_PAQUETE",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.id_paquete },

                    new SqlParameter("@PRIMERA_CONSULTA",SqlDbType.Bit){Direction = ParameterDirection.Input, Value = dto.primera_consulta },

                    new SqlParameter("@CLASIFICACION_PAC",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.clasificacion_pac },

                    new SqlParameter("@ID_PERIODO_CONSULTA",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.id_periodo_consulta },

                    new SqlParameter("@TIPO_ATE",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.tipo_ate },

                    new SqlParameter("@TIPO_DOC_PAGO",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.tipo_doc_pago },

                    new SqlParameter("@ID_CONDICION_ESPECIAL_PAGO",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.id_condicion_especial_pago },

                    new SqlParameter("@DESCRP_ZONA",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.descrp_zona },

                    new SqlParameter("@EMPRESA_PACIENTE",SqlDbType.VarChar){Direction = ParameterDirection.Input, Value = dto.empresa_paciente },

                    new SqlParameter("@ID_MRP",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.id_mrp },

                    new SqlParameter("@COD_CATEGORIA_SERV_CLIENTE",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.cod_categoria_serv_cliente },

                    new SqlParameter("@MODO_ATENCION_MEDICO",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.modo_atencion_medico },


                    new SqlParameter("@USUARIOCREACION",SqlDbType.Int){Direction = ParameterDirection.Input, Value = dto.usuariocreacion },

                    //new SqlParameter("@FECHACREACION",SqlDbType.DateTime){Direction = ParameterDirection.Input, Value = dto.fechacreacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIACLINICA_MAD", parameters);

                dto.id_historiaclinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Cliente_Codigo(string vNumero)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isNUMERO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vNumero },
                };
                List<DbContext.Entities.HistoriaClinicaCliente> clientes = new List<DbContext.Entities.HistoriaClinicaCliente>();
                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaCliente>("SPRMDS_LIST_HISTORIACLINICA_MAD_CLIENTE_BY_CODIGO", parameters);
                List<HistoriaClinicaClienteDto> listClientes = new List<HistoriaClinicaClienteDto>();
                listClientes = clientes.Select(c => new HistoriaClinicaClienteDto
                {
                    codigo = c.CODIGO,
                    numero = c.NUMERO,
                }).ToList();
                if (!listClientes.Any())
                    return ServiceResponse.Return404();
                return ServiceResponse.ReturnResultWith200(listClientes);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Siteds_Codigo(string vCodigo)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCODIGO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vCodigo },
                };
                List<DbContext.Entities.SitedsCodigo> siteds = new List<DbContext.Entities.SitedsCodigo>();
                siteds = await _uow.ExecuteStoredProcByParam<DbContext.Entities.SitedsCodigo>("SPRMDS_LIST_HISTORIACLINICA_MAD_CLIENTE_SITEDS_BY_CODIGO", parameters);
                List<SitedsCodigoDto> listSiteds = new List<SitedsCodigoDto>();
                listSiteds = siteds.Select(s => new SitedsCodigoDto
                {
                    id_cliente = s.ID_CLIENTE,
                    numero = s.NUMERO,
                    nombre = s.NOMBRE,
                }).ToList();
                if (!listSiteds.Any())
                    return ServiceResponse.Return404();
                return ServiceResponse.ReturnResultWith200(listSiteds);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetSiteds_Numero(string vNumero)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isNUMERO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vNumero },
                };
                List<DbContext.Entities.SitedsLista> siteds = new List<DbContext.Entities.SitedsLista>();
                siteds = await _uow.ExecuteStoredProcByParam<DbContext.Entities.SitedsLista>("SPRMDS_LIST_SITEDS_NUMERO", parameters);
                List<SitedsListaDto> listSiteds = new List<SitedsListaDto>();
                listSiteds = siteds.Select(s => new SitedsListaDto
                {
                    numero = s.NUMERO,
                    paterno = s.PATERNO,
                    materno = s.MATERNO,
                    nombres = s.NOMBRES,
                    edad = s.EDAD,
                    fechanacimiento = s.FECHANACIMIENTO,
                    tipodocumento = s.TIPODOCUMENTO,
                    numerodocumento = s.NUMERODOCUMENTO,
                    genero = s.GENERO,
                    producto = s.PRODUCTO,
                    numeroautorizacion = s.NUMEROAUTORIZACION,
                    numerocontrato = s.NUMEROCONTRATO,
                    codigoafiliado = s.CODIGOAFILIADO,
                    numeropoliza = s.NUMEROPOLIZA,
                    moneda = s.MONEDA,
                    copagofijo = s.COPAGOFIJO,
                    copagovariable = s.COPAGOVARIABLE,
                }).ToList();
                if (!listSiteds.Any())
                    return ServiceResponse.Return404();
                return ServiceResponse.ReturnResultWith200(listSiteds);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        //SERVICIO MAD - BANDEJA
        public async Task<ServiceResponse> GetHistoriasClinicasMadFiltro(string? vCampoBusqueda = null, string? vValorBusqueda = null, string? vFechaInicio = null, string? vFechaFinal = null)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CampoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vCampoBusqueda },
                    new SqlParameter("@ValorBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vValorBusqueda },
                    new SqlParameter("@FechaInicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vFechaInicio },
                    new SqlParameter("@FechaFinal", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vFechaFinal },
                };
                List<DbContext.Entities.HistoriaClinicas> HistoriasClinicasMad = new List<DbContext.Entities.HistoriaClinicas>();
                List<ListadoHistoriaClinicaDto> listHistoriasClinicas = new List<ListadoHistoriaClinicaDto>();
                HistoriasClinicasMad = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicas>("SPRMDS_LIST_HISTORIACLINICA_FILTRO_MAD", parameters);
                listHistoriasClinicas = HistoriasClinicasMad.Select(h => new ListadoHistoriaClinicaDto
                {
                    chis_id = h.CHIS_ID,
                    e = h.E,
                    prog = h.PROG,
                    codate = h.CODATE,
                    clasif = h.CLASIF,
                    e_tablet = h.E_TABLET,
                    codautorizacion = h.CODAUTORIZACION,
                    feclla = h.FECLLA,
                    hrlla = h.HRLLA,
                    tiempo = h.TIEMPO,
                    fecate = h.FECATE,
                    hrxdefecto = h.HRXDEFECTO,
                    hrestimada = h.HRESTIMADA,
                    hrllegada = h.HRLLEGADA,
                    provincia = h.PROVINCIA,
                    distrito = h.DISTRITO,
                    paciente = h.PACIENTE,
                    fpago = h.FPAGO,
                    vip = h.VIP,
                    grupo = h.GRUPO,
                    periodo = h.PERIODO,
                    cont = h.CONT,
                    perfil = h.PERFIL,
                    espec = h.ESPEC,
                    doctor = h.DOCTOR,
                    grupos = h.GRUPOS,
                    empresa = h.EMPRESA,
                    usuario = h.USUARIO,
                    cod_doc = h.COD_DOC
                }).ToList();
                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriasClinicasMadFiltro_Rango_By_Fechas(string? vFechaInicio = null, string? vFechaFinal = null)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@FechaInicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vFechaInicio },
                    new SqlParameter("@FechaFinal", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vFechaFinal },
                };
                List<DbContext.Entities.HistoriaClinicas> HistoriasClinicasMad = new List<DbContext.Entities.HistoriaClinicas>();
                List<ListadoHistoriaClinicaDto> listHistoriasClinicas = new List<ListadoHistoriaClinicaDto>();
                HistoriasClinicasMad = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicas>("SPRMDS_LIST_HISTORIACLINICA_FILTRO_MAD_RANGO_BY_FECHA", parameters);
                listHistoriasClinicas = HistoriasClinicasMad.Select(h => new ListadoHistoriaClinicaDto
                {
                    chis_id = h.CHIS_ID,
                    e = h.E,
                    prog = h.PROG,
                    codate = h.CODATE,
                    clasif = h.CLASIF,
                    e_tablet = h.E_TABLET,
                    codautorizacion = h.CODAUTORIZACION,
                    feclla = h.FECLLA,
                    hrlla = h.HRLLA,
                    tiempo = h.TIEMPO,
                    fecate = h.FECATE,
                    hrxdefecto = h.HRXDEFECTO,
                    hrestimada = h.HRESTIMADA,
                    hrllegada = h.HRLLEGADA,
                    provincia = h.PROVINCIA,
                    distrito = h.DISTRITO,
                    paciente = h.PACIENTE,
                    fpago = h.FPAGO,
                    vip = h.VIP,
                    grupo = h.GRUPO,
                    periodo = h.PERIODO,
                    cont = h.CONT,
                    perfil = h.PERFIL,
                    espec = h.ESPEC,
                    doctor = h.DOCTOR,
                    grupos = h.GRUPOS,
                    empresa = h.EMPRESA,
                    usuario = h.USUARIO,
                    cod_doc = h.COD_DOC
                }).ToList();
                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriasClinicasMadFiltro_Campos(string? vCampoBusqueda = null, string? vValorBusqueda = null)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CampoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vCampoBusqueda },
                    new SqlParameter("@ValorBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vValorBusqueda },
                };
                List<DbContext.Entities.HistoriaClinicas> HistoriasClinicasMad = new List<DbContext.Entities.HistoriaClinicas>();
                List<ListadoHistoriaClinicaDto> listHistoriasClinicas = new List<ListadoHistoriaClinicaDto>();
                HistoriasClinicasMad = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicas>("SPRMDS_LIST_HISTORIACLINICA_FILTRO_MAD_CAMPOS", parameters);
                listHistoriasClinicas = HistoriasClinicasMad.Select(h => new ListadoHistoriaClinicaDto
                {
                    chis_id = h.CHIS_ID,
                    e = h.E,
                    prog = h.PROG,
                    codate = h.CODATE,
                    clasif = h.CLASIF,
                    e_tablet = h.E_TABLET,
                    codautorizacion = h.CODAUTORIZACION,
                    feclla = h.FECLLA,
                    hrlla = h.HRLLA,
                    tiempo = h.TIEMPO,
                    fecate = h.FECATE,
                    hrxdefecto = h.HRXDEFECTO,
                    hrestimada = h.HRESTIMADA,
                    hrllegada = h.HRLLEGADA,
                    provincia = h.PROVINCIA,
                    distrito = h.DISTRITO,
                    paciente = h.PACIENTE,
                    fpago = h.FPAGO,
                    vip = h.VIP,
                    grupo = h.GRUPO,
                    periodo = h.PERIODO,
                    cont = h.CONT,
                    perfil = h.PERFIL,
                    espec = h.ESPEC,
                    doctor = h.DOCTOR,
                    grupos = h.GRUPOS,
                    empresa = h.EMPRESA,
                    usuario = h.USUARIO,
                    cod_doc = h.COD_DOC
                }).ToList();
                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        //CONSULTA DNI X PACIENTE
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Paciente_Dni(string vNumero)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isNumeroDni", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vNumero },
                };
                List<DbContext.Entities.HistoriaClinicaPaciente_x_Numero> pacientes = new List<DbContext.Entities.HistoriaClinicaPaciente_x_Numero>();
                pacientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaPaciente_x_Numero>("SPRMDS_LIST_HISTORIACLINICA_MAD_BY_PACIENTE", parameters);
                List<HistoriaClinicaPaciente_x_NumeroDto> listPaciente = new List<HistoriaClinicaPaciente_x_NumeroDto>();
                listPaciente = pacientes.Select(p => new HistoriaClinicaPaciente_x_NumeroDto
                {
                    codigo = p.CODIGO,
                    paterno = p.PATERNO,
                    materno = p.MATERNO,
                    nombres = p.NOMBRES,
                    tipodocumento = p.TIPODOCUMENTO,
                    dni = p.DNI,
                    fechanacimiento = p.FECHANACIMIENTO,
                    edad = p.EDAD,
                    genero = p.GENERO,
                    email = p.EMAIL,
                    celular = p.CELULAR,
                    departamento = p.DEPARTAMENTO,
                    provincia = p.PROVINCIA,
                    distrito = p.DISTRITO,
                    direccion = p.DIRECCION,
                    lote = p.LOTE,
                    interior = p.INTERIOR,
                    urbanizacion = p.URBANIZACION,
                    referencia = p.REFERENCIA,
                }).ToList();


                /*if (!listPaciente.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listPaciente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        //LISTADO CLIENTES PARA SITEDS
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Clientes_Siteds()
        {
            try
            {


                List<DbContext.Entities.ClienteSiteds> clientes = new List<DbContext.Entities.ClienteSiteds>();

                clientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.ClienteSiteds>("SPRMDS_LIST_HISTORIACLINICA_MAD_CLIENTE_SITEDS");

                List<ClienteSitedsDto> listCliente = new List<ClienteSitedsDto>();

                listCliente = clientes.Select(c => new ClienteSitedsDto
                {
                    id_cliente = c.CCLT_ID,
                    codigo_financiamiento = c.SIAF_FINANCIAMIENTO,
                    nombre = c.SCLT_NOMBRE,
                }).ToList();


                if (!listCliente.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        //CONSULTA POR CLIENTES = CLIENTES PARA SITEDS
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Clientes_Siteds_By_Nombre(string vCliente)
        {
            try
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCLIENTE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vCliente },
                };

                List<DbContext.Entities.ClienteSitedsAseguradora> clientes = new List<DbContext.Entities.ClienteSitedsAseguradora>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.ClienteSitedsAseguradora>("SPRMDS_LIST_HISTORIACLINICA_MAD_CLIENTE_SITEDS_BY_NOMBRE", parameters);

                List<ClienteSitedsAseguradoDto> listCliente = new List<ClienteSitedsAseguradoDto>();

                listCliente = clientes.Select(c => new ClienteSitedsAseguradoDto
                {
                    id_cliente = c.CCLT_ID,
                    id_financiamiento = c.SIAF_FINANCIAMIENTO,
                }).ToList();


                if (!listCliente.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        //CONSULTA POR ASEGURADORA = CAJA TEXTO
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Paciente_Distrito(string vDistrito)
        {
            try
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@isDistrito", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vDistrito },
                };

                List<DbContext.Entities.HistoriaClinicaUbigeo> ubigeos = new List<DbContext.Entities.HistoriaClinicaUbigeo>();

                ubigeos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaUbigeo>("SPRMDS_LIST_HISTORIACLINICA_MAD_UBIGEO", parameters);

                List<HistoriaClinicaUbigeoDto> listUbigeo = new List<HistoriaClinicaUbigeoDto>();

                listUbigeo = ubigeos.Select(u => new HistoriaClinicaUbigeoDto
                {
                    codigo = u.CODIGO,
                    departamento = u.DEPARTAMENTO,
                    provincia = u.PROVINCIA,
                    distrito = u.DISTRITO
                }).ToList();


                if (!listUbigeo.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listUbigeo);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        //CONSULTA POR ASEGURADORA = (COMBOBOX)
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Aseguradora_Categoria(string vAseguradora)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isAseguradora", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vAseguradora },
                };

                List<DbContext.Entities.Clientes> clientes = new List<DbContext.Entities.Clientes>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Clientes>("SPRMDS_LIST_HISTORIACLINICA_MAD_ASEGURADORA_CATEGORIA", parameters);

                List<ClientesDto> listCliente = new List<ClientesDto>();

                listCliente = clientes.Select(c => new ClientesDto
                {
                    id_cliente = c.CCLT_ID,
                    nombre = c.SCLT_NOMBRE,
                    descripcion = c.SSCE_DESCRIPCION
                }).ToList();


                /*if (!listCliente.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        //LISTADO DE GENERO = (COMBOBOX)
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Genero()
        {
            try
            {

                List<DbContext.Entities.Parametro> parametros = new List<DbContext.Entities.Parametro>();

                parametros = await _uow.ExecuteStoredProcAll<DbContext.Entities.Parametro>("SPRMDS_LIST_HISTORIACLINICA_MAD_GENERO");

                List<ParametroDto> listParametro = new List<ParametroDto>();

                listParametro = parametros.Select(g => new ParametroDto
                {
                    id = g.CPAR_ID,
                    descripcion = g.SPAR_NOMBRE
                }).ToList();


                if (!listParametro.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listParametro);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_TipoDocumento()
        {
            try
            {

                List<DbContext.Entities.TipoDocumento> documentos = new List<DbContext.Entities.TipoDocumento>();

                documentos = await _uow.ExecuteStoredProcAll<DbContext.Entities.TipoDocumento>("SPRMDS_LIST_HISTORIACLINICA_MAD_TIPODOCUMENTO");

                List<TipoDocumentoDto> listDocumento = new List<TipoDocumentoDto>();

                listDocumento = documentos.Select(d => new TipoDocumentoDto
                {
                    id = d.CTDO_ID,
                    descripcion = d.STDO_DESCRIPCION,
                    codigo_sunat = d.STDO_SUNAT,
                    codigo_susalud = d.STDO_SUSALUD,
                    estado = d.FTDO_ESTADO
                }).ToList();


                if (!listDocumento.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listDocumento);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Vip()
        {
            try
            {

                List<DbContext.Entities.Parametro> parametros = new List<DbContext.Entities.Parametro>();

                parametros = await _uow.ExecuteStoredProcAll<DbContext.Entities.Parametro>("SPRMDS_LIST_HISTORIACLINICA_MAD_VIP");

                List<ParametroDto> listParametro = new List<ParametroDto>();

                listParametro = parametros.Select(g => new ParametroDto
                {
                    id = g.CPAR_ID,
                    descripcion = g.SPAR_NOMBRE
                }).ToList();


                if (!listParametro.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listParametro);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Seguro()
        {
            try
            {

                List<DbContext.Entities.TipoSeguro> seguros = new List<DbContext.Entities.TipoSeguro>();

                seguros = await _uow.ExecuteStoredProcAll<DbContext.Entities.TipoSeguro>("SPRMDS_LIST_HISTORIACLINICA_MAD_SEGURO");

                List<TipoSeguroDto> listSeguro = new List<TipoSeguroDto>();

                listSeguro = seguros.Select(s => new TipoSeguroDto
                {
                    id = s.NSEG_ID,
                    nombre = s.SSEG_NOMBRE
                }).ToList();

                if (!listSeguro.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listSeguro);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Clasificacion()
        {
            try
            {

                List<DbContext.Entities.ServicioNegocio> negocios = new List<DbContext.Entities.ServicioNegocio>();

                negocios = await _uow.ExecuteStoredProcAll<DbContext.Entities.ServicioNegocio>("SPRMDS_LIST_HISTORIACLINICA_MAD_CLASIFICACION");

                List<ServicioNegocioDto> listNegocio = new List<ServicioNegocioDto>();

                listNegocio = negocios.Select(n => new ServicioNegocioDto
                {
                    id_servicio = n.CSER_ID,
                    nombre = n.SSER_NOMBRE
                }).ToList();


                if (!listNegocio.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listNegocio);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Ubigeo_Codigo(string vDepartamento, string vProvincia, string vDistrito)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@DEPARTAMENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vDepartamento },
                    new SqlParameter("@PROVINCIA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vProvincia },
                    new SqlParameter("@DISTRITO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vDistrito },
                };

                List<DbContext.Entities.UbigeoCodigo> ubigeos = new List<DbContext.Entities.UbigeoCodigo>();

                ubigeos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.UbigeoCodigo>("SPRMDS_LIST_HISTORIACLINICA_MAD_UBIGEO_CODIGO", parameters);

                List<UbigeoCodigoDto> listUbigeo = new List<UbigeoCodigoDto>();

                listUbigeo = ubigeos.Select(u => new UbigeoCodigoDto
                {
                    codigo_ubigeo = u.CUBI_ID
                }).ToList();


                if (!listUbigeo.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listUbigeo);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Ubigeo(string vDistrito)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isDistrito", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vDistrito },
                };

                List<DbContext.Entities.Ubigeo> ubigeos = new List<DbContext.Entities.Ubigeo>();

                ubigeos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Ubigeo>("SPRMDS_LIST_HISTORIACLINICA_MAD_UBIGEO", parameters);

                List<UbigeosDto> listUbigeo = new List<UbigeosDto>();

                listUbigeo = ubigeos.Select(u => new UbigeosDto
                {
                    codigo = u.CUBI_ID,
                    departamento = u.SUBI_DEPARTAMENTO,
                    provincia = u.SUBI_PROVINCIA,
                    distrito = u.SUBI_DISTRITO
                }).ToList();


                if (!listUbigeo.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listUbigeo);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Dni()
        {
            try
            {

                List<DbContext.Entities.PacienteFiltro> pacientes = new List<DbContext.Entities.PacienteFiltro>();

                pacientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.PacienteFiltro>("SPRMDS_LIST_HISTORIACLINICA_MAD_PACIENTE");

                List<PacienteDto> listPacientes = new List<PacienteDto>();

                //listPacientes = pacientes.Select(p => new PacienteDto { dni = p.DNI, nombres = p.NOMBRES }).ToList();


                return ServiceResponse.ReturnResultWith200(listPacientes);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriaClinica_Paciente_x_Dni(string vDni, string vNumero)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isDni", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vDni },
                    new SqlParameter("@isNumero", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vNumero },
                };

                List<DbContext.Entities.HistoriaClinicaPaciente_x_Dni> pacientes = new List<DbContext.Entities.HistoriaClinicaPaciente_x_Dni>();

                pacientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaPaciente_x_Dni>("SPRMDS_LIST_HISTORIACLINICA_PACIENTE_X_DNI", parameters);

                List<HistoriaClinicaPaciente_x_DniDto> listPacientes = new List<HistoriaClinicaPaciente_x_DniDto>();

                listPacientes = pacientes.Select(p => new HistoriaClinicaPaciente_x_DniDto
                {
                    dni = p.DNI,
                    nombres = p.NOMBRES,
                    codigo = p.CODIGO
                }

                    ).ToList();


                return ServiceResponse.ReturnResultWith200(listPacientes);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        //TODAS LAS HISTORIAS CLINICAS
        public async Task<ServiceResponse> GetHistoriaClinicas()
        {
            try
            {

                List<DbContext.Entities.HistoriaClinicas> historias = new List<DbContext.Entities.HistoriaClinicas>();

                historias = await _uow.ExecuteStoredProcAll<DbContext.Entities.HistoriaClinicas>("SPRMDS_LIST_HISTORIACLINICAS");

                List<ListadoHistoriaClinicaDto> listHistorias = new List<ListadoHistoriaClinicaDto>();

                listHistorias = historias.Select(h => new ListadoHistoriaClinicaDto
                {
                    chis_id = h.CHIS_ID,
                    e = h.E,
                    prog = h.PROG,
                    codate = h.CODATE,
                    clasif = h.CLASIF,
                    e_tablet = h.E_TABLET,
                    codautorizacion = h.CODAUTORIZACION,
                    feclla = h.FECLLA,
                    hrlla = h.HRLLA,
                    tiempo = h.TIEMPO,
                    fecate = h.FECATE,
                    hrxdefecto = h.HRXDEFECTO,
                    hrestimada = h.HRESTIMADA,
                    hrllegada = h.HRLLEGADA,
                    provincia = h.PROVINCIA,
                    distrito = h.DISTRITO,
                    paciente = h.PACIENTE,
                    fpago = h.FPAGO,
                    vip = h.VIP,
                    grupo = h.GRUPO,
                    periodo = h.PERIODO,
                    cont = h.CONT,
                    perfil = h.PERFIL,
                    espec = h.ESPEC,
                    doctor = h.DOCTOR,
                    grupos = h.GRUPOS,
                    empresa = h.EMPRESA,
                    usuario = h.USUARIO,
                    cod_doc = h.COD_DOC,
                    cm_estado = h.CM_ESTADO
                }).ToList();

                /*if (!listHistorias.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listHistorias);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetHistoriasClinicas(string vFechaIni, string vFechaFin, string vConsulta)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isFechaIni", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vFechaIni },
                    new SqlParameter("@isFechaFin", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vFechaFin },
                    new SqlParameter("@isCondicion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vConsulta },
                };

                int vOpcion = 0;
                List<DbContext.Entities.HistoriaClinicas> historias = new List<DbContext.Entities.HistoriaClinicas>();
                List<ListadoHistoriaClinicaDto> listHistorias = new List<ListadoHistoriaClinicaDto>();

                if (vConsulta.Equals("1"))
                {
                    vOpcion = 1;
                    historias = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicas>("SPRMDS_LIST_HISTORIA_CLINICAS", parameters);
                    listHistorias = historias.Select(h => new ListadoHistoriaClinicaDto
                    {
                        chis_id = h.CHIS_ID,
                        e = h.E,
                        prog = h.PROG,
                        codate = h.CODATE,
                        clasif = h.CLASIF,
                        e_tablet = h.E_TABLET,
                        codautorizacion = h.CODAUTORIZACION,
                        feclla = h.FECLLA,
                        hrlla = h.HRLLA,
                        tiempo = h.TIEMPO,
                        fecate = h.FECATE,
                        hrxdefecto = h.HRXDEFECTO,
                        hrestimada = h.HRESTIMADA,
                        hrllegada = h.HRLLEGADA,
                        provincia = h.PROVINCIA,
                        distrito = h.DISTRITO,
                        paciente = h.PACIENTE,
                        fpago = h.FPAGO,
                        vip = h.VIP,
                        grupo = h.GRUPO,
                        periodo = h.PERIODO,
                        cont = h.CONT,
                        perfil = h.PERFIL,
                        espec = h.ESPEC,
                        doctor = h.DOCTOR,
                        grupos = h.GRUPOS,
                        empresa = h.EMPRESA,
                        usuario = h.USUARIO,
                        cod_doc = h.COD_DOC
                    }).ToList();
                }
                else
                {
                    vOpcion = 2;
                    historias = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicas>("SPRMDS_LIST_HISTORIA_CLINICAS", parameters);
                    listHistorias = historias.Select(h => new ListadoHistoriaClinicaDto
                    {
                        chis_id = h.CHIS_ID,
                        e = h.E,
                        prog = h.PROG,
                        codate = h.CODATE,
                        clasif = h.CLASIF,
                        e_tablet = h.E_TABLET,
                        codautorizacion = h.CODAUTORIZACION,
                        feclla = h.FECLLA,
                        hrlla = h.HRLLA,
                        tiempo = h.TIEMPO,
                        fecate = h.FECATE,
                        hrxdefecto = h.HRXDEFECTO,
                        hrestimada = h.HRESTIMADA,
                        hrllegada = h.HRLLEGADA,
                        provincia = h.PROVINCIA,
                        distrito = h.DISTRITO,
                        paciente = h.PACIENTE,
                        fpago = h.FPAGO,
                        vip = h.VIP,
                        grupo = h.GRUPO,
                        periodo = h.PERIODO,
                        cont = h.CONT,
                        perfil = h.PERFIL,
                        espec = h.ESPEC,
                        doctor = h.DOCTOR,
                        grupos = h.GRUPOS,
                        empresa = h.EMPRESA,
                        usuario = h.USUARIO,
                        cod_doc = h.COD_DOC
                    }).ToList();
                }

                if (vOpcion == 0)
                    return ServiceResponse.ReturnResultWith204();


                return ServiceResponse.ReturnResultWith200(listHistorias);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> RegistrarHistoriaClinica(RegistrarHistoriaClinicaDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@E",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.e},
                    new SqlParameter("@PROG",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.prog},
                    new SqlParameter("@CODATE",SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.codate},
                    new SqlParameter("@CLASIF",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.clasif},
                    new SqlParameter("@E_TABLET",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.e_tablet},
                    new SqlParameter("@CODAUTORIZACION",SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.codautorizacion},
                    new SqlParameter("@FECLLA",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.feclla},
                    new SqlParameter("@HRLLA",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.hrlla},
                    new SqlParameter("@TIEMPO",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.tiempo},
                    new SqlParameter("@FECATE",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fecate},
                    new SqlParameter("@HRXDEFECTO",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.hrxdefecto},
                    new SqlParameter("@HRESTIMADA",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.hrestimada},
                    new SqlParameter("@HRLLEGADA",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.hrllegada},
                    new SqlParameter("@PROVINCIA",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.provincia},
                    new SqlParameter("@DISTRITO",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.distrito},
                    new SqlParameter("@PACIENTE",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.paciente},
                    new SqlParameter("@FPAGO",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fpago},
                    new SqlParameter("@VIP",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.vip},
                    new SqlParameter("@GRUPO",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.grupo},
                    new SqlParameter("@PERIODO",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.periodo},
                    new SqlParameter("@CONT",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cont},
                    new SqlParameter("@PERFIL",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.perfil},
                    new SqlParameter("@ESPEC",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.espec},
                    new SqlParameter("@DOCTOR",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.doctor},
                    new SqlParameter("@GRUPOS",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.grupos},
                    new SqlParameter("@EMPRESA",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.empresa},
                    new SqlParameter("@USUARIO",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usuario},
                    new SqlParameter("@COD_DOC",SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cod_doc},
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_REGISTRAR_HISTORIACLINICA", parameters);

                dto.numero_historia = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddHistoriaClinicaSiteds(SitedsMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {

                            new SqlParameter("@CHIS_ID"                             ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.id_historia },
                            new SqlParameter("@SSIT_DOCUMENTOAUTORIZACION"          ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.documentoautorizacion },
                            new SqlParameter("@SSIT_CODIGOAFILIADO"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigoafiliado },
                            new SqlParameter("@SSIT_NUMEROPOLIZA"                   ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numeropoliza },
                            new SqlParameter("@SSIT_NUMEROCONTRATO"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerocontrato },
                            new SqlParameter("@SSIT_NUMEROCERTIFICADO"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerocertificado },
                            new SqlParameter("@SSIT_CODPRODUCTO"                    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codproducto },
                            new SqlParameter("@SSIT_DESPRODUCTO"                    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desproducto },
                            new SqlParameter("@SSIT_APELLIDOPATERNOAFILIADO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.apellidopaternoafiliado },
                            new SqlParameter("@SSIT_APELLIDOMATERNOAFILIADO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.apellidomaternoafiliado },
                            new SqlParameter("@SSIT_NOMBRESAFILIADO"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.nombresafiliado },
                            new SqlParameter("@SSIT_CODGENERO"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codgenero },
                            new SqlParameter("@SSIT_DESGENERO"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desgenero },
                            new SqlParameter("@SSIT_CODFECHANACIMIENTO"             ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechanacimiento },
                            new SqlParameter("@SSIT_FECHANACIMIENTO"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechanacimiento },
                            new SqlParameter("@SSIT_CODPARENTESCO"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codparentesco },
                            new SqlParameter("@SSIT_DESPARENTESCO"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desparentesco },
                            new SqlParameter("@SSIT_CODTIPODOCUMENTOAFILIADO"       ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codtipodocumentoafiliado },
                            new SqlParameter("@SSIT_DESTIPODOCUMENTOAFILIADO"       ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipodocumentoafiliado },
                            new SqlParameter("@SSIT_NUMERODOCUMENTOAFILIADO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerodocumentoafiliado },
                            new SqlParameter("@NSIT_EDAD"                           ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value =     dto.edad },
                            new SqlParameter("@SSIT_CODFECHAINICIOVIGENCIA"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechainiciovigencia },
                            new SqlParameter("@SSIT_FECHAINICIOVIGENCIA"            ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechainiciovigencia },
                            new SqlParameter("@SSIT_CODFECHAFINVIGENCIA"            ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechafinvigencia },
                            new SqlParameter("@SSIT_FECHAFINVIGENCIA"               ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechafinvigencia },
                            new SqlParameter("@SSIT_CODESTADOCIVIL"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codestadocivil },
                            new SqlParameter("@SSIT_DESESTADOCIVIL"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desestadocivil },
                            new SqlParameter("@NSIT_CODTIPOPLAN"                    ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.codtipoplan },
                            new SqlParameter("@SSIT_DESTIPOPLAN"                    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipoplan },
                            new SqlParameter("@NSIT_NUMEROPLAN"                     ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.numeroplan },
                            new SqlParameter("@SSIT_CODESTADO"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codestado },
                            new SqlParameter("@SSIT_DESESTADO"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desestado },
                            new SqlParameter("@SSIT_CODFECHAACTUALIZACIONFOTO"      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechaactualizacionfoto },
                            new SqlParameter("@SSIT_FECHAACTUALIZACIONFOTO"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechaactualizacionfoto },
                            new SqlParameter("@SSIT_APELLIDOPATERNOTITULAR"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.apellidopaternotitular },
                            new SqlParameter("@SSIT_APELLIDOMATERNOTITULAR"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.apellidomaternotitular },
                            new SqlParameter("@SSIT_NOMBRESTITULAR"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.nombrestitular },
                            new SqlParameter("@SSIT_CODIGOTITULAR"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigotitular },
                            new SqlParameter("@SSIT_CODTIPODOCUMENTOTITULAR"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codtipodocumentotitular },
                            new SqlParameter("@SSIT_DESTIPODOCUMENTOTITULAR"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipodocumentotitular },
                            new SqlParameter("@SSIT_NUMERODOCUMENTOTITULAR"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerodocumentotitular },
                            new SqlParameter("@NSIT_CODMONEDA"                      ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value =     dto.codmoneda },
                            new SqlParameter("@SSIT_DESMONEDA"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desmoneda },
                            new SqlParameter("@SSIT_NOMBRECONTRATANTE"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.nombrecontratante },
                            new SqlParameter("@SSIT_CODTIPODOCUMENTOCONTRATANTE"    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codtipodocumentocontratante },
                            new SqlParameter("@SSIT_DESTIPODOCUMENTOCONTRATANTE"    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipodocumentocontratante },
                            new SqlParameter("@SSIT_CODTIPOAFILIACION"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codtipoafiliacion },
                            new SqlParameter("@SSIT_DESTIPOAFILIACION"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipoafiliacion },
                            new SqlParameter("@SSIT_CODFECHAAFILIACION"             ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechaafiliacion },
                            new SqlParameter("@SSIT_FECHAAFILIACION"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechaafiliacion },
                            new SqlParameter("@SSIT_NUMERODOCUMENTOCONTRATANTE"     ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerodocumentocontratante },
                            new SqlParameter("@SSIT_CODIGOTIPOCOBERTURA"            ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigotipocobertura },
                            new SqlParameter("@SSIT_CODIGOSUBTIPOCOBERTURA"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigosubtipocobertura },
                            new SqlParameter("@SSIT_CODIGOCOBERTURA"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigocobertura },
                            new SqlParameter("@SSIT_BENEFICIOS"                     ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.beneficios },
                            new SqlParameter("@SSIT_CODINDICADORRESTRICCION"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codindicadorrestriccion },
                            new SqlParameter("@SSIT_RESTRICCIONES"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.restricciones },
                            new SqlParameter("@NSIT_CODCOPAGOFIJO"                  ,SqlDbType.Decimal) {Direction = ParameterDirection.Input,Value = dto.codcopagofijo },
                            new SqlParameter("@SSIT_DESCOPAGOFIJO"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.descopagofijo },
                            new SqlParameter("@NSIT_CODCOPAGOVARIABLE"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codcopagovariable },
                            new SqlParameter("@SSIT_DESCOPAGOVARIABLE"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.descopagovariable },
                            new SqlParameter("@SSIT_CODFECHAFINCARENCIA"            ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechafincarencia },
                            new SqlParameter("@SSIT_FECHAFINCARENCIA"               ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechafincarencia },
                            new SqlParameter("@SSIT_CONDICIONESESPECIALES"          ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.condicionesespeciales },
                            new SqlParameter("@SSIT_OBSERVACIONES"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.observaciones },
                            new SqlParameter("@SSIT_CODCALIFICACIONSERVICIO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codcalificacionservicio },
                            new SqlParameter("@SSIT_DESCALIFICACIONSERVICIO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.descalificacionservicio },
                            new SqlParameter("@SSIT_BENEFICIOMAXIMOINICIAL"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.beneficiomaximoinicial },
                            new SqlParameter("@SSIT_NUMEROCOBERTURA"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerocobertura },
                            new SqlParameter("@SSIT_FECHA_CREACION_DOC_AUT"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fecha_creacion_doc_aut },
                            new SqlParameter("@DSIT_HORA_CREACION_DOC_AUT"          ,SqlDbType.DateTime) {Direction = ParameterDirection.Input,Value = dto.hora_creacion_doc_aut },
                            new SqlParameter("@SSIT_DESCRIPCION_PRODUCTO"           ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.descripcion_producto },
                            new SqlParameter("@NSIT_USUARIO_CREACION"               ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.usuario_creacion },
                            new SqlParameter("@DSIT_FECHA_CREACION"                 ,SqlDbType.DateTime) {Direction = ParameterDirection.Input,Value = dto.fecha_creacion },
                            new SqlParameter("@NSIT_USUARIO_MODIFICACION"           ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.usuario_modificacion },
                            new SqlParameter("@DSIT_FECHA_MODIFICACION"             ,SqlDbType.DateTime) {Direction = ParameterDirection.Input,Value = dto.fecha_modificacion },

                            new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}

                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_SITEDS", parameters);

                dto.id_siteds = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //////////////////          FIN SERVICIO MAD          //////////////////

        //////////////////          SERVICIO SCTR          //////////////////

        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriasClinicasSctrBandeja(string fechaInicio, string fechaFin, string condicion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isFechaInicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaInicio },
                    new SqlParameter("@isFechaFin", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaFin },
                    new SqlParameter("@isCondicion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = condicion },
                };

                int reporte = 0;
                List<DbContext.Entities.HistoriaClinicaBandejaSctr> HistoriasClinicasSctr = new List<DbContext.Entities.HistoriaClinicaBandejaSctr>();
                List<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas> HistoriasClinicasOtrasLlamadas = new List<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas>();

                List<HistoriaClinicaBandejaDto> listHistoriasClinicas = new List<HistoriaClinicaBandejaDto>();

                if (condicion.Equals("1"))
                {
                    reporte = 1;

                    HistoriasClinicasSctr = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaBandejaSctr>("SPRMDS_LIST_HISTORIA_CLINICA_SCTR", parameters);

                    listHistoriasClinicas = HistoriasClinicasSctr.Select(s => new HistoriaClinicaBandejaDto
                    {
                        cod_historia_clinica = s.cod_historia_clinica,
                        tipo_historia_clinica = s.tipo_historia_clinica,
                        estado = s.estado,
                        fecha_creacion = s.fecha_creacion,
                        hora_creacion = s.hora_creacion,
                        documento_identidad = s.documento_identidad,
                        numero = s.numero,
                        paciente = s.paciente,
                        fecha_nacimiento = s.fecha_nacimiento,
                        clinica = s.clinica,
                        departamento = s.departamento,
                        provincia = s.provincia,
                        distrito = s.distrito,
                        hoja_atencion = s.hoja_atencion,
                        medio_validacion = s.medio_validacion,
                        pase_atencion = s.pase_atencion,
                        observacion = s.observacion,
                        empresa = s.empresa,
                        empresa_ruc = s.empresa_ruc,
                        usuario_creacion = s.usuario_creacion,
                        motivo = s.motivo,
                        plan = s.plan,
                        skill = s.skill,
                        pk_pg = s.NHIS_PK_POSTGRES
                    }).ToList();
                }
                else
                {
                    reporte = 2;

                    HistoriasClinicasOtrasLlamadas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas>("SPRMDS_LIST_HISTORIA_CLINICA_SCTR", parameters);

                    listHistoriasClinicas = HistoriasClinicasOtrasLlamadas.Select(s => new HistoriaClinicaBandejaDto
                    {
                        cod_historia_clinica = s.cod_historia_clinica,
                        estado = s.estado,
                        fecha_creacion = s.fecha_creacion,
                        hora_creacion = s.hora_creacion,
                        motivo = s.motivo,
                        procedencia = s.procedencia,
                        clinica = s.clinica,
                        departamento = s.departamento,
                        provincia = s.provincia,
                        distrito = s.distrito,
                        persona_reporta = s.persona_reporta,
                        motivo_de_llamada = s.motivo_de_llamada,
                        usuario_creacion = s.usuario_creacion,
                        skill = s.skill
                    }).ToList();
                }

                if (reporte == 0)
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriaClinicaSctrByCodigo(string codHistoriaClinica)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoHistoriaClinica", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = codHistoriaClinica}
                };

                List<DbContext.Entities.HistoriaClinicaSctr> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaSctr>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaSctr>("SPRMDS_LIST_HISTORIA_CLINICA_BY_CODIGO_SCTR", parameters);

                List<HistoriaClinicaDto> listHistoriasClinicas = new List<HistoriaClinicaDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaDto
                {
                    cod_historia_clinica = s.cod_historia_clinica,
                    paciente = s.paciente,
                    fecha_nacimiento = s.fecha_nacimiento,
                    edad = s.edad,
                    sexo = s.sexo,
                    celular = s.celular,
                    pais = s.pais,
                    documento_identidad = s.documento_identidad,
                    numero_documento_id = s.numero_documento_id,
                    fecha_creacion = s.fecha_creacion,
                    hora_atencion = s.hora_atencion,
                    descripcion_ipress = s.descripcion_ipress,
                    ipress_telefono = s.ipress_telefono,
                    ipress_anexo = s.ipress_anexo,
                    empresa = s.empresa,
                    empresa_ruc = s.empresa_ruc,
                    horario_trabajo = s.horario_trabajo,
                    puesto_cargo = s.puesto_cargo,
                    relato = s.relato,
                    fecha_accidente = s.fecha_accidente,
                    hora_accidente = s.hora_accidente,
                    tipo_historia_clinica = s.tipo_historia_clinica,
                    pase_atencion = s.pase_atencion,
                    motivo = s.motivo,
                    observacion = s.observacion,
                    ipress_primera_ate = s.ipress_primera_ate,
                    id_clinica = s.id_clinica,
                    persona_reporta = s.persona_reporta,
                    id_cliente = s.id_cliente,
                    id_motivo = s.id_motivo,
                    numero_atencion = s.numero_atencion,
                    metodo_validacion = s.metodo_validacion,
                    hoja_atencion = s.hoja_atencion,
                    id_plan = s.id_plan,
                    skill = s.skill,
                    motivo_skill = s.motivo_skill,
                    id_clinica_primera_atencion = s.id_clinica_primera_atencion
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriasClinicasSctrFiltro(string fechaInicio, string fechaFin, string? busqueda = null, string? condicion = null, int reporte = 0)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isFechaInicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaInicio },
                    new SqlParameter("@isFechaFin", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaFin },
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                    new SqlParameter("@isCondicion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = condicion },
                    new SqlParameter("@isReporte", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = reporte },
                };

                List<DbContext.Entities.HistoriaClinicaBandejaSctr> HistoriasClinicasSctr = new List<DbContext.Entities.HistoriaClinicaBandejaSctr>();
                List<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas> HistoriasClinicasOtrasLlamadas = new List<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas>();

                List<HistoriaClinicaBandejaDto> listHistoriasClinicas = new List<HistoriaClinicaBandejaDto>();

                if (reporte == 1)
                {
                    HistoriasClinicasSctr = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaBandejaSctr>("SPRMDS_LIST_HISTORIA_CLINICA_FILTRO_SCTR", parameters);

                    listHistoriasClinicas = HistoriasClinicasSctr.Select(s => new HistoriaClinicaBandejaDto
                    {
                        cod_historia_clinica = s.cod_historia_clinica,
                        tipo_historia_clinica = s.tipo_historia_clinica,
                        estado = s.estado,
                        fecha_creacion = s.fecha_creacion,
                        hora_creacion = s.hora_creacion,
                        documento_identidad = s.documento_identidad,
                        numero = s.numero,
                        paciente = s.paciente,
                        fecha_nacimiento = s.fecha_nacimiento,
                        clinica = s.clinica,
                        departamento = s.departamento,
                        provincia = s.provincia,
                        distrito = s.distrito,
                        hoja_atencion = s.hoja_atencion,
                        medio_validacion = s.medio_validacion,
                        pase_atencion = s.pase_atencion,
                        observacion = s.observacion,
                        empresa = s.empresa,
                        empresa_ruc = s.empresa_ruc,
                        usuario_creacion = s.usuario_creacion,
                        motivo = s.motivo,
                        plan = s.plan,
                        skill = s.skill
                    }).ToList();
                }
                else
                {
                    HistoriasClinicasOtrasLlamadas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas>("SPRMDS_LIST_HISTORIA_CLINICA_FILTRO_SCTR", parameters);

                    listHistoriasClinicas = HistoriasClinicasOtrasLlamadas.Select(s => new HistoriaClinicaBandejaDto
                    {
                        cod_historia_clinica = s.cod_historia_clinica,
                        estado = s.estado,
                        fecha_creacion = s.fecha_creacion,
                        hora_creacion = s.hora_creacion,
                        motivo = s.motivo,
                        procedencia = s.procedencia,
                        clinica = s.clinica,
                        departamento = s.departamento,
                        provincia = s.provincia,
                        distrito = s.distrito,
                        persona_reporta = s.persona_reporta,
                        motivo_de_llamada = s.motivo_de_llamada,
                        usuario_creacion = s.usuario_creacion,
                        skill = s.skill
                    }).ToList();
                }

                if (reporte == 0)
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddHistoriaClinicaSctr(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoClinica", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_clinica },
                    new SqlParameter("@inCodigoMotivo", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_motivo },
                    new SqlParameter("@inCodigoPlan", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.id_plan },
                    new SqlParameter("@isHorarioTrabajo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horario_trabajo },
                    new SqlParameter("@isCargo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cargo },
                    new SqlParameter("@isRelato", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.relato },
                    new SqlParameter("@isFechaAccidente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fecha_accidente },
                    new SqlParameter("@isHoraAccidente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.hora_accidente },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@isPrimeraAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.primera_atencion },
                    new SqlParameter("@isMetodoValidacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.metodo_validacion },
                    new SqlParameter("@isHojaAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.hoja_atencion },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ubigeo },
                    new SqlParameter("@isSkill", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.skill },
                    new SqlParameter("@isMotivoSkill", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.motivo_skill },
                    new SqlParameter("@isCentroClinico", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.centro_clinico },
                    new SqlParameter("@isEmpresa", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.empresa },
                    new SqlParameter("@isCorredorSeguro", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.corredor_seguro },
                    new SqlParameter("@isPacienteAsegurado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.paciente_asegurado },
                    new SqlParameter("@isPersonaReportaClinica", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_clinica },
                    new SqlParameter("@isPersonaReportaEmpresa", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_empresa },
                    new SqlParameter("@isPersonaReportaSeguro", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_seguro },
                    new SqlParameter("@isPersonaReportaAsegurado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_asegurado },
                    new SqlParameter("@inPaseAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.pase_atencion },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@inCodigoClinicaPrimeraAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_clinica_primera_atencion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output},
                    new SqlParameter("@onRespuestaSeguimiento", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_SCTR", parameters);

                dto.cod_historia_clinica = (int)parameters.First(p => p.ParameterName == "@onRespuesta").Value;
                dto.cod_seguimiento = (int)parameters.First(p => p.ParameterName == "@onRespuestaSeguimiento").Value;

                //dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> UpdateHistoriaClinicaSctr(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoHistoriaClinica", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.cod_historia_clinica },
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoClinica", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_clinica },
                    new SqlParameter("@inCodigoMotivo", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_motivo },
                    new SqlParameter("@inCodigoPlan", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.id_plan },
                    new SqlParameter("@isHorarioTrabajo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horario_trabajo },
                    new SqlParameter("@isCargo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cargo },
                    new SqlParameter("@isRelato", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.relato },
                    new SqlParameter("@isFechaAccidente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fecha_accidente },
                    new SqlParameter("@isHoraAccidente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.hora_accidente },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@isPrimeraAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.primera_atencion },
                    new SqlParameter("@isMetodoValidacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.metodo_validacion },
                    new SqlParameter("@isHojaAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.hoja_atencion },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ubigeo },
                    new SqlParameter("@isSkill", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.skill },
                    new SqlParameter("@isMotivoSkill", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.motivo_skill },
                    new SqlParameter("@isCentroClinico", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.centro_clinico },
                    new SqlParameter("@isEmpresa", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.empresa },
                    new SqlParameter("@isCorredorSeguro", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.corredor_seguro },
                    new SqlParameter("@isPacienteAsegurado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.paciente_asegurado },
                    new SqlParameter("@isPersonaReportaClinica", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_clinica },
                    new SqlParameter("@isPersonaReportaEmpresa", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_empresa },
                    new SqlParameter("@isPersonaReportaSeguro", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_seguro },
                    new SqlParameter("@isPersonaReportaAsegurado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_asegurado },
                    new SqlParameter("@inPaseAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.pase_atencion },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@inCodigoClinicaPrimeraAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_clinica_primera_atencion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output},
                    new SqlParameter("@onRespuestaSeguimiento", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_HISTORIA_CLINICA_SCTR", parameters);

                dto.cod_historia_clinica = (int)parameters.First(p => p.ParameterName == "@onRespuesta").Value;
                dto.cod_seguimiento = (int)parameters.First(p => p.ParameterName == "@onRespuestaSeguimiento").Value;
                //dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> DeleteHistoriaClinicaSctr(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoHistoriaClinica", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.cod_historia_clinica },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_eliminacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output},
                    new SqlParameter("@onRespuestaSeguimiento", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_HISTORIA_CLINICA_SCTR", parameters);

                //dto.cod_historia_clinica = Convert.ToInt64(response);
                dto.observacion = "borrado";
                dto.cod_historia_clinica = (int)parameters.First(p => p.ParameterName == "@onRespuesta").Value;
                dto.cod_seguimiento = (int)parameters.First(p => p.ParameterName == "@onRespuestaSeguimiento").Value;

                return ServiceResponse.ReturnResultWith201(dto);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //////////////////          FIN SERVICIO SCTR          //////////////////

        //////////////////          SERVICIO AMBULANCIA          //////////////////

        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriasClinicasAmbulanciaBandeja(AmbulanciaResource dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    //new SqlParameter("@isCondicion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.condicion },
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.busqueda },
                    new SqlParameter("@isFechaInicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaDesde },
                    new SqlParameter("@isFechaFin", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaHasta },
                    new SqlParameter("@isUrgEmeTras", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagUrgEmeTras },
                    new SqlParameter("@isEventos", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagEventos },
                    new SqlParameter("@isOmedica", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagOmedica },
                    new SqlParameter("@isCanceladas", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagCanceladas },
                    new SqlParameter("@isFinalizadas", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagFinalizadas },

                    /*new SqlParameter("@isCodigoAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoAtencion },
                    new SqlParameter("@isCodigoSited", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoSited },
                    new SqlParameter("@isCotizado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cotizado },
                    new SqlParameter("@isEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@isAmbulanciaRespuesta", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ambulanciaRespuesta },
                    new SqlParameter("@isServicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.servicio },
                    new SqlParameter("@isPaciente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.paciente },
                    new SqlParameter("@isNumeroDocumento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numeroDocumento },
                    new SqlParameter("@isDepartamento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.departamento },
                    new SqlParameter("@isProvincia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.provincia },
                    new SqlParameter("@isDistrito", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.distrito },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isReferencia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.referencia },
                    new SqlParameter("@isCliente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cliente },
                    new SqlParameter("@isProveedor", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.proveedor },
                    new SqlParameter("@isAmbulancia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ambulancia },
                    new SqlParameter("@isTiempo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.tiempo },
                    new SqlParameter("@isFechaEstimada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaEstimada },
                    new SqlParameter("@isHoraEstimada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaEstimada },
                    new SqlParameter("@isFechaLlegada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaLlegada },
                    new SqlParameter("@isHoraLlegada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaLlegada },
                    new SqlParameter("@isFechaFinAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaFinAtencion },
                    new SqlParameter("@isHoraFinAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaFinAtencion },
                    new SqlParameter("@isTelefonoCelular", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefonoCelular },
                    new SqlParameter("@isUsuarioCreacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usuarioCreacion },
                    new SqlParameter("@isFlagFueraCobertura", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.flagFueraCobertura },
                    new SqlParameter("@isFlagCitrix", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.flagCitrix },
                    new SqlParameter("@isCodigoProv", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoProv },*/

                    new SqlParameter("@inIndex", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.Skip },
                    new SqlParameter("@inTamanoPagina", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.PageSize },
                };

                var listaAmbulancia = await _uow.ExecuteStoredProcPagination<DbContext.Entities.HistoriaClinicaBandejaAmbulancia>("SPRMDS_LIST_HISTORIA_CLINICA_AMBULANCIA", parameters, dto.Skip, dto.PageSize);

                return ServiceResponse.ReturnResultWith200(listaAmbulancia);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddHistoriaClinicaAmbulanciaOrientacionMedica(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    //TBLMDS_HISTORIA_CLINICA
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESTADO },
                    new SqlParameter("@NHIS_COD_ESTADO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_ESTADO },
                    new SqlParameter("@NHIS_CM_ORDEN", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_ORDEN },
                    new SqlParameter("@FHIS_FLG_CM_NUEVA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLG_CM_NUEVA },
                    new SqlParameter("@SHIS_REF_DIR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_REF_DIR },
                    new SqlParameter("@SHIS_CM_REF_DIR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_REF_DIR },
                    new SqlParameter("@FHIS_FLAG_PROGRAMADA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLAG_PROGRAMADA },
                    new SqlParameter("@SHIS_F_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_F_PROG },
                    new SqlParameter("@SHIS_COD_TIPO_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_TIPO_PROG },
                    new SqlParameter("@SHIS_COD_DR_SOLICITADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_DR_SOLICITADO },
                    new SqlParameter("@FHIS_CM_DIRECTA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DIRECTA },
                    new SqlParameter("@SHIS_FLG_DIRECTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLG_DIRECTO },
                    new SqlParameter("@FHIS_CM_DATOS_COMPLETOS", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DATOS_COMPLETOS },
                    new SqlParameter("@NHIS_TAR_ATE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_TAR_ATE },
                    new SqlParameter("@SHIS_TIPO_SERVAMB_DRMAS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVAMB_DRMAS },
                    new SqlParameter("@SHIS_COD_AMB_TIPO_SERV", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AMB_TIPO_SERV },
                    new SqlParameter("@NHIS_COASEGURO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_COASEGURO },
                    new SqlParameter("@SHIS_FLAGMONE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLAGMONE },
                    new SqlParameter("@NHIS_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CAMBIO },
                    new SqlParameter("@SHIS_FOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FOR_ATE },
                    new SqlParameter("@SHIS_CM_MONEDA_DEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_MONEDA_DEN },
                    new SqlParameter("@NHIS_CM_DEN_CAMBIO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_DEN_CAMBIO },
                    new SqlParameter("@SHIS_CM_DENOMINACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_DENOMINACION },
                    new SqlParameter("@SHIS_CONTACTO_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_PAC },
                    new SqlParameter("@SHIS_CONTACTO_ASEG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_ASEG },
                    new SqlParameter("@SHIS_TIPO_SERVICIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVICIO },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC },
                    new SqlParameter("@SHIS_TIPO_DOC_PAGO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_DOC_PAGO },
                    new SqlParameter("@SHIS_DESCRP_ZONA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DESCRP_ZONA },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC_CALLMED", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC_CALLMED },                    
                    //SITEDS
                    new SqlParameter("@SHIS_COD_AUT_PRESTACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AUT_PRESTACION },
                    new SqlParameter("@SHIS_COD_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_ASEGURADO },
                    new SqlParameter("@SHIS_CM_ASEG_PRODUCTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ASEG_PRODUCTO },
                    new SqlParameter("@SHIS_POLIZA_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_ASEGURADO },
                    new SqlParameter("@SHIS_POLIZA_CERTIFICADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_CERTIFICADO },
                    
                    //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
                    new SqlParameter("@CPAR_ID_SOLICITUD", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_SOLICITUD },
                    new SqlParameter("@inCodigoMotivo", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_MOTIVO_CALLMEDICO },
                    new SqlParameter("@CPAR_ID_REFERENCIA_AMBULANCIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_REFERENCIA_AMBULANCIA },
                    new SqlParameter("@CCEN_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CCEN_ID },
                    new SqlParameter("@CECM_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CECM_ID },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AMBULANCIA_ORIENTACION_MEDICA", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddHistoriaClinicaAmbulancia(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    //TBLMDS_HISTORIA_CLINICA
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@SHIS_NOM_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_NOM_EMP },
                    new SqlParameter("@NHIS_EDAD_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_EDAD_ATE },
                    new SqlParameter("@SHIS_CEL_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CEL_PAC },
                    new SqlParameter("@SHIS_CM_REF_DIR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_REF_DIR },
                    new SqlParameter("@NHIS_COD_TARIFA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_TARIFA },
                    new SqlParameter("@SHIS_F_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_F_PROG },
                    new SqlParameter("@SHIS_COD_AMB_TIPO_SERV", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AMB_TIPO_SERV },
                    new SqlParameter("@FHIS_FLAG_PROGRAMADA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLAG_PROGRAMADA },
                    new SqlParameter("@SHIS_PERSONAL_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_PERSONAL_CONTACTO },
                    new SqlParameter("@DHIS_HOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_HOR_ATE },
                    new SqlParameter("@SHIS_COD_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_EMP },
                    new SqlParameter("@SHIS_AMB_COD_DIS_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_COD_DIS_ORIGEN },
                    new SqlParameter("@SHIS_AMB_DES_DIS_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DES_DIS_ORIGEN },
                    new SqlParameter("@SHIS_AMB_DIR_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DIR_ORIGEN },
                    new SqlParameter("@SHIS_AMB_REF_DIR_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_REF_DIR_ORIGEN },
                    new SqlParameter("@DHIS_AMB_FECHA_INI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_FECHA_INI },
                    new SqlParameter("@DHIS_AMB_HORA_INI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_HORA_INI },
                    new SqlParameter("@DHIS_AMB_FECHA_FIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_FECHA_FIN },
                    new SqlParameter("@DHIS_AMB_HORA_FIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_HORA_FIN },
                    new SqlParameter("@SHIS_AMB_COD_DIS_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_COD_DIS_DESTINO },
                    new SqlParameter("@SHIS_AMB_DES_DIS_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DES_DIS_DESTINO },
                    new SqlParameter("@SHIS_AMB_DIR_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DIR_DESTINO },
                    new SqlParameter("@SHIS_AMB_REF_DIR_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_REF_DIR_DESTINO },
                    new SqlParameter("@SHIS_TIPO_SERVICIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVICIO },
                    new SqlParameter("@NHIS_COD_PRIORIDAD_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_PRIORIDAD_CALLMED },
                    new SqlParameter("@NHIS_COD_MOTIVO_ATE_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_MOTIVO_ATE_CALLMED },
                    new SqlParameter("@NHIS_TAR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_TAR_ATE },
                    new SqlParameter("@NHIS_COASEGURO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COASEGURO },
                    new SqlParameter("@SHIS_TIPO_DOC_PAGO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_DOC_PAGO },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@SHIS_CM_DENOMINACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_DENOMINACION },
                    new SqlParameter("@SHIS_FOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FOR_ATE },
                    new SqlParameter("@NHIS_ID_TIPO_TRASLADO_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_ID_TIPO_TRASLADO_CALLMED },
                    new SqlParameter("@SHIS_COD_AUT_PRESTACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AUT_PRESTACION },
                    new SqlParameter("@SHIS_CONTRATANTE_CITRIX", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTRATANTE_CITRIX },
                    new SqlParameter("@SHIS_COD_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_ASEGURADO },
                    new SqlParameter("@SHIS_CM_ASEG_PRODUCTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ASEG_PRODUCTO },
                    new SqlParameter("@SHIS_POLIZA_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_ASEGURADO },
                    new SqlParameter("@SHIS_POLIZA_CERTIFICADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_CERTIFICADO },
                    new SqlParameter("@FHIS_AMB_SERVICIO_PLAYA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_AMB_SERVICIO_PLAYA },
                    new SqlParameter("@inEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_ESTADO },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESTADO },
                    new SqlParameter("@NHIS_COD_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_ESTADO },
                    new SqlParameter("@NHIS_CM_ORDEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_ORDEN },
                    new SqlParameter("@FHIS_FLG_CM_NUEVA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLG_CM_NUEVA },
                    new SqlParameter("@SHIS_COD_TIPO_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_TIPO_PROG },
                    new SqlParameter("@SHIS_COD_DR_SOLICITADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_DR_SOLICITADO },
                    new SqlParameter("@FHIS_CM_DIRECTA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DIRECTA },
                    new SqlParameter("@SHIS_FLG_DIRECTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLG_DIRECTO },
                    new SqlParameter("@FHIS_CM_DATOS_COMPLETOS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DATOS_COMPLETOS },
                    new SqlParameter("@SHIS_FLAGMONE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLAGMONE },
                    new SqlParameter("@NHIS_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CAMBIO },
                    new SqlParameter("@SHIS_CM_MONEDA_DEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_MONEDA_DEN },
                    new SqlParameter("@NHIS_CM_DEN_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_DEN_CAMBIO },
                    new SqlParameter("@SHIS_CONTACTO_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_PAC },
                    new SqlParameter("@SHIS_CONTACTO_ASEG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_ASEG },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC },
                    new SqlParameter("@SHIS_DESCRP_ZONA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DESCRP_ZONA },
                    new SqlParameter("@SHIS_USULLA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_USULLA_ATE },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC_CALLMED },
                    new SqlParameter("@DHIS_FEC_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_FEC_ATE },
                    new SqlParameter("@SHIS_TIPO_SERVAMB_DRMAS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVAMB_DRMAS },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AMBULANCIA", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddHistoriaClinicaAmbulanciaEvento(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    //TBLMDS_HISTORIA_CLINICA
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@SHIS_NOM_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_NOM_EMP },
                    new SqlParameter("@NHIS_EDAD_ATE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_EDAD_ATE },
                    new SqlParameter("@SHIS_CEL_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CEL_PAC },
                    new SqlParameter("@SHIS_CM_REF_DIR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_REF_DIR },
                    new SqlParameter("@NHIS_COD_TARIFA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_TARIFA },
                    new SqlParameter("@SHIS_F_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_F_PROG },
                    new SqlParameter("@SHIS_COD_AMB_TIPO_SERV", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AMB_TIPO_SERV },//10
                    new SqlParameter("@SHIS_TIPO_SERVAMB_DRMAS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVAMB_DRMAS },
                    new SqlParameter("@FHIS_FLAG_PROGRAMADA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLAG_PROGRAMADA },
                    new SqlParameter("@SHIS_PERSONAL_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_PERSONAL_CONTACTO },
                    new SqlParameter("@DHIS_HOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_HOR_ATE },
                    new SqlParameter("@SHIS_COD_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_EMP },
                    new SqlParameter("@SHIS_AMB_COD_DIS_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_COD_DIS_ORIGEN },
                    new SqlParameter("@SHIS_AMB_DES_DIS_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DES_DIS_ORIGEN },
                    new SqlParameter("@SHIS_AMB_DIR_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DIR_ORIGEN },
                    new SqlParameter("@SHIS_AMB_REF_DIR_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_REF_DIR_ORIGEN },
                    new SqlParameter("@DHIS_AMB_FECHA_INI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_FECHA_INI },//20
                    new SqlParameter("@DHIS_AMB_HORA_INI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_HORA_INI },
                    new SqlParameter("@DHIS_AMB_FECHA_FIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_FECHA_FIN },
                    new SqlParameter("@DHIS_AMB_HORA_FIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_HORA_FIN },
                    new SqlParameter("@SHIS_AMB_COD_DIS_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_COD_DIS_DESTINO },
                    new SqlParameter("@SHIS_AMB_DES_DIS_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DES_DIS_DESTINO },
                    new SqlParameter("@SHIS_AMB_DIR_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DIR_DESTINO },
                    new SqlParameter("@SHIS_AMB_REF_DIR_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_REF_DIR_DESTINO },
                    new SqlParameter("@SHIS_TIPO_SERVICIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVICIO },
                    new SqlParameter("@NHIS_COD_PRIORIDAD_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_PRIORIDAD_CALLMED },
                    new SqlParameter("@NHIS_COD_MOTIVO_ATE_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_MOTIVO_ATE_CALLMED },//30
                    new SqlParameter("@NHIS_TAR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_TAR_ATE },
                    new SqlParameter("@NHIS_COASEGURO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COASEGURO },
                    new SqlParameter("@SHIS_TIPO_DOC_PAGO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_DOC_PAGO },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@SHIS_CM_DENOMINACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_DENOMINACION },
                    new SqlParameter("@SHIS_FOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FOR_ATE },
                    new SqlParameter("@NHIS_ID_TIPO_TRASLADO_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_ID_TIPO_TRASLADO_CALLMED },
                    new SqlParameter("@SHIS_COD_AUT_PRESTACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AUT_PRESTACION },
                    new SqlParameter("@SHIS_CONTRATANTE_CITRIX", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTRATANTE_CITRIX },
                    new SqlParameter("@SHIS_COD_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_ASEGURADO },//40
                    new SqlParameter("@SHIS_CM_ASEG_PRODUCTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ASEG_PRODUCTO },
                    new SqlParameter("@SHIS_POLIZA_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_ASEGURADO },
                    new SqlParameter("@SHIS_POLIZA_CERTIFICADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_CERTIFICADO },
                    new SqlParameter("@FHIS_AMB_SERVICIO_PLAYA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_AMB_SERVICIO_PLAYA },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESTADO },
                    new SqlParameter("@NHIS_COD_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_ESTADO },
                    new SqlParameter("@NHIS_CM_ORDEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_ORDEN },
                    new SqlParameter("@FHIS_FLG_CM_NUEVA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLG_CM_NUEVA },
                    new SqlParameter("@SHIS_COD_TIPO_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_TIPO_PROG },
                    new SqlParameter("@SHIS_COD_DR_SOLICITADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_DR_SOLICITADO },//50
                    new SqlParameter("@FHIS_CM_DIRECTA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DIRECTA },
                    new SqlParameter("@SHIS_FLG_DIRECTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLG_DIRECTO },
                    new SqlParameter("@FHIS_CM_DATOS_COMPLETOS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DATOS_COMPLETOS },
                    new SqlParameter("@SHIS_FLAGMONE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLAGMONE },
                    new SqlParameter("@NHIS_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CAMBIO },
                    new SqlParameter("@SHIS_CM_MONEDA_DEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_MONEDA_DEN },
                    new SqlParameter("@NHIS_CM_DEN_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_DEN_CAMBIO },
                    new SqlParameter("@SHIS_CONTACTO_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_PAC },
                    new SqlParameter("@SHIS_CONTACTO_ASEG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_ASEG },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC },//60
                    new SqlParameter("@SHIS_DESCRP_ZONA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DESCRP_ZONA },
                    new SqlParameter("@SHIS_USULLA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_USULLA_ATE },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC_CALLMED },
                    new SqlParameter("@DHIS_FEC_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_FEC_ATE },
                    new SqlParameter("@FPAC_FLG_CONFLICTIVO_CALLMED", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLG_CONFLICTIVO_CALLMED },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },

                    //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
                    new SqlParameter("@FHIS_FUERA_COBERTURA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_FUERA_COBERTURA },
                    new SqlParameter("@SHIS_DIRECCION_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DIRECCION_ORIGEN},
                    new SqlParameter("@SHIS_DIRECCION_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DIRECCION_DESTINO},
                    new SqlParameter("@CCLI_ID_ORIGEN", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CCLI_ID_ORIGEN},//70
                    new SqlParameter("@CCLI_ID_DESTINO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CCLI_ID_DESTINO},
                    new SqlParameter("@SHIS_ALERGIA_MEDICA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_ALERGIA_MEDICA},
                    new SqlParameter("@SHIS_ATENCEDENTE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_ATENCEDENTE},
                    new SqlParameter("@CTAM_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CTAM_ID,},
                    new SqlParameter("@SHIS_RUC_EVENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_RUC_EVENTO,},
                    new SqlParameter("@SHIS_RAZON_SOCIAL_EVENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_RAZON_SOCIAL_EVENTO,},
                    new SqlParameter("@SHIS_DIRECCION_FISCAL_EVENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DIRECCION_FISCAL_EVENTO,},
                    new SqlParameter("@CPOL_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPOL_ID,},
                    new SqlParameter("@SHIS_NRO_PLACA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_NRO_PLACA,},
                    new SqlParameter("@SHIS_NRO_POLIZA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_NRO_POLIZA,},//80
                    new SqlParameter("@SHIS_SINIESTRO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_SINIESTRO,},
                    new SqlParameter("@SHIS_AHUTORIZA_CORTESIA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AHUTORIZA_CORTESIA,},
                    new SqlParameter("@SHIS_REGLA_ORO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_REGLA_ORO,},
                    new SqlParameter("@FHIS_AMB_RESPIRATORIA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_AMB_RESPIRATORIA,},
                    new SqlParameter("@CPAR_ID_SOLICITANTE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_SOLICITANTE,},
                    new SqlParameter("@SHIS_UBIC_DENTRO_CLINICA_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_UBIC_DENTRO_CLINICA_ORIGEN,},
                    new SqlParameter("@SHIS_UBIC_DENTRO_CLINICA_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_UBIC_DENTRO_CLINICA_DESTINO,},
                    new SqlParameter("@NPRV_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPRV_ID,},
                    new SqlParameter("@DHIS_FECHA_EVENTO_ADVERSO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_FECHA_EVENTO_ADVERSO,},
                    new SqlParameter("@CPAR_ID_SOLICITUD", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_SOLICITUD,},//90
                    new SqlParameter("@FHIS_CITRIX", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_CITRIX,},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AMBULANCIA_EVENTO", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> DeleteHistoriaClinicaAmbulancia(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoHistoriaClinica", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.cod_historia_clinica },
                    new SqlParameter("@inCodigoMotivo", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_motivo },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_eliminacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_HISTORIA_CLINICA_AMBULANCIA", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);
                dto.observacion = "borrado";

                return ServiceResponse.ReturnSuccess();

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }
        //////////////////          FIN SERVICIO AMBULANCIA          //////////////////

        #region "Estado 0 - 2 - 3"

        //By Julio Carrera
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Asignacion_Tiempo_Doctor(int codHistoriaClinica)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CHIS_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codHistoriaClinica}
                };

                List<DbContext.Entities.HistoriaClinicaMadAsignacionTiempoDoctor> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadAsignacionTiempoDoctor>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadAsignacionTiempoDoctor>("SPRMDS_LIST_HISTORIA_CLINICA_MAD_ASIGNACION_TIEMPO_DOCTOR", parameters);

                List<HistoriaClinicaMadAsignacionTiempoDoctorDto> listHistoriasClinicas = new List<HistoriaClinicaMadAsignacionTiempoDoctorDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaMadAsignacionTiempoDoctorDto
                {
                    DEN = s.DEN,
                    DHIS_FEC_ATE = s.DHIS_FEC_ATE,
                    DHIS_HOR_ATE = s.DHIS_HOR_ATE,
                    EDAD = s.EDAD,
                    CESP_ID = s.CESP_ID,
                    ESPECIALIDAD = s.ESPECIALIDAD,
                    CMED_ID = s.CMED_ID,
                    MEDICO = s.MEDICO,
                    NHIS_CLASIFICACION_PAC = s.NHIS_CLASIFICACION_PAC,
                    NHIS_CM_COD_PAC_DESEA = s.NHIS_CM_COD_PAC_DESEA,
                    NHIS_MOTIVO_TIPO_PROG = s.NHIS_MOTIVO_TIPO_PROG,
                    PACIENTE = s.PACIENTE,
                    SHIS_CM_COD_DR_PAC_DESEA = s.SHIS_CM_COD_DR_PAC_DESEA,
                    SHIS_CM_DES_PAC_DESEA = s.SHIS_CM_DES_PAC_DESEA,
                    SHIS_CM_ESTADO = s.SHIS_CM_ESTADO,
                    SHIS_FORMAPAGO = s.SHIS_FORMAPAGO,
                    SHIS_F_PROG = s.SHIS_F_PROG,
                    SHIS_F_SOLDOCT = s.SHIS_F_SOLDOCT,
                    SHIS_OBSERVACION = s.SHIS_OBSERVACION,
                    SHIS_PAC_VIP = s.SHIS_PAC_VIP,
                    SHIS_TIPO_ATE = s.SHIS_TIPO_ATE,
                    SHIS_TMP_COD_TIT = s.SHIS_TMP_COD_TIT,
                    SPER_TELEFONO_CELULAR = s.SPER_TELEFONO_CELULAR,
                    IDCLIENTE = s.IDCLIENTE,
                    CPER_ID = s.CPER_ID,
                    DISTRITO = s.DISTRITO,
                    SDIR_DESCRIPCION = s.SDIR_DESCRIPCION,
                    SDIR_INTERIOR = s.SDIR_INTERIOR,
                    SDIR_NRO_LOTE = s.SDIR_NRO_LOTE,
                    SDIR_REFERENCIA = s.SDIR_REFERENCIA,
                    FHIS_CM_DATOS_COMPLETOS = s.FHIS_CM_DATOS_COMPLETOS,
                    SUBI_PROVINCIA = s.SUBI_PROVINCIA,
                    SHIS_TIPO_DOC_PAGO = s.SHIS_TIPO_DOC_PAGO

                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Asignacion_By_Especialidad(string nombreEspecialidad, int personaId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NOMBRE_ESP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = nombreEspecialidad},
                    new SqlParameter("@CPER_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = personaId}
                };

                List<DbContext.Entities.HistoriaClinicaMadAsignacionEspecialidad> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadAsignacionEspecialidad>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadAsignacionEspecialidad>("SPRMDS_LIST_HISTORIA_CLINICA_MAD_ASIGNACION_BY_ESPECIALIDAD", parameters);

                List<HistoriaClinicaMadAsignacionEspecialidadDto> listHistoriasClinicas = new List<HistoriaClinicaMadAsignacionEspecialidadDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaMadAsignacionEspecialidadDto
                {
                    CESP_ID = s.CESP_ID,
                    SESP_NOMBRE = s.SESP_NOMBRE

                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Asignacion_By_Medico(/*string usuario, int clasificacion, int codigoEspecialidad, int personaId,*/ string nombreMedico)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    /*new SqlParameter("@USUARIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = usuario},
                    new SqlParameter("@CLASIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = clasificacion},
                    new SqlParameter("@COD_ESP", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoEspecialidad},
                    new SqlParameter("@CPER_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = personaId},*/
                    new SqlParameter("@MEDICO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = nombreMedico}
                };

                List<DbContext.Entities.HistoriaClinicaMadAsignacionMedico> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadAsignacionMedico>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadAsignacionMedico>("SPRMDS_LIST_HISTORIA_CLINICA_MAD_ASIGNACION_BY_MEDICO", parameters);

                List<HistoriaClinicaMadAsignacionMedicoDto> listHistoriasClinicas = new List<HistoriaClinicaMadAsignacionMedicoDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaMadAsignacionMedicoDto
                {
                    /*CESP_ID = s.CESP_ID,
                    SMED_TIPO_DOCTOR = s.SMED_TIPO_DOCTOR,
                    SMEP_DESCRIPCION = s.SMEP_DESCRIPCION,*/
                    CMED_ID = s.CMED_ID,
                    MEDICO = s.MEDICO,
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Asignacion_Especiliadad_Medico(int codigoMedico, int codigoEspecialidad)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CESP_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoEspecialidad},
                    new SqlParameter("@CMED_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoMedico}
                };

                List<DbContext.Entities.HistoriaClinicaMadAsignacionEspecialidadMedico> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadAsignacionEspecialidadMedico>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadAsignacionEspecialidadMedico>("SPRMDS_LIST_HISTORIA_CLINICA_MAD_ASIGNACION_ESPECIALIDAD_MEDICO", parameters);

                List<HistoriaClinicaMadAsignacionEspecialidadMedicoDto> listHistoriasClinicas = new List<HistoriaClinicaMadAsignacionEspecialidadMedicoDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaMadAsignacionEspecialidadMedicoDto
                {
                    CMED_ID = s.CMED_ID,
                    MEDICO = s.MEDICO,
                    SMED_TIPO_DOCTOR = s.SMED_TIPO_DOCTOR
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> AddHistoriaClinicaMadAuditoriaEstado(HistoriaClinicaMadAuditoriaEstadoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMEROHISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NUMEROHISTORIA },
                    new SqlParameter("@ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ESTADO,},
                    new SqlParameter("@USUARIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.USUARIO,},
                    new SqlParameter("@OBSERVACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.OBSERVACION,},
                    new SqlParameter("@CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.CAMBIO,},
                    new SqlParameter("@USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.USUARIO_CREACION,},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AUDITORIA_ESTADO", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> UpdateHistoriaClinicaMadEstado(HistoriaClinicaMadEstadoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CHIS_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CHIS_ID },
                    new SqlParameter("@CMED_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CMED_ID },
                    new SqlParameter("@SHIS_COD_TIPO_DOCTOR", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_TIPO_DOCTOR },
                    new SqlParameter("@DHIS_HORASGDR_ATE", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DHIS_HORASGDR_ATE },
                    new SqlParameter("@DHIS_FECASGDR_ATE", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DHIS_FECASGDR_ATE },
                    new SqlParameter("@SHIS_USUASGDR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_USUASGDR_ATE },
                    new SqlParameter("@CESP_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CESP_ID },
                    new SqlParameter("@DHIS_FEC_ATE", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DHIS_FEC_ATE },
                    new SqlParameter("@DHIS_HOR_ATE", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DHIS_HOR_ATE },
                    new SqlParameter("@SHIS_TMP_COD_TIT", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TMP_COD_TIT },
                    new SqlParameter("@NHIS_CM_TIEMPO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_TIEMPO },
                    new SqlParameter("@SHIS_COD_DR_SOLICITADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_DR_SOLICITADO },
                    new SqlParameter("@FHIS_FLAG_PROGRAMADA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLAG_PROGRAMADA },
                    new SqlParameter("@SHIS_F_SOLDOCT", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.SHIS_F_SOLDOCT },
                    new SqlParameter("@SHIS_F_PROG", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.SHIS_F_PROG },
                    new SqlParameter("@NHIS_MOTIVO_TIPO_PROG", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_MOTIVO_TIPO_PROG },
                    new SqlParameter("@NHIS_CLASIFICACION_NEG_SOPORTE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_NEG_SOPORTE },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESTADO },
                    new SqlParameter("@NHIS_COD_ESTADO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_ESTADO },
                    new SqlParameter("@NHIS_ORDEN", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_ORDEN },
                    new SqlParameter("@SHIS_CM_ESP_ANTERIOR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESP_ANTERIOR },
                    new SqlParameter("@SHIS_CM_COD_DR_ANTERIOR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_COD_DR_ANTERIOR },
                    new SqlParameter("@SHIS_CM_DR_ANTERIOR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_DR_ANTERIOR },
                    new SqlParameter("@FHIS_FLG_VALIDACION_DIRECTA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLG_VALIDACION_DIRECTA },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_HISTORIA_CLINICA_AUDITORIA_ESTADO", parameters);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> GetHistoriaClinicaMadTipoProgramacion()
        {
            try
            {
                List<DbContext.Entities.HistoriaClinicaMadTipoProgramacion> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadTipoProgramacion>();

                historiasClinicas = await _uow.ExecuteStoredProcAll<DbContext.Entities.HistoriaClinicaMadTipoProgramacion>("SPRMDS_LIST_HISTORIACLINICA_MAD_TIPO_PROGRAMACION");

                List<HistoriaClinicaMadTipoProgramacionDto> listHistoriasClinicas = new List<HistoriaClinicaMadTipoProgramacionDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaMadTipoProgramacionDto
                {
                    CPAR_ID = s.CPAR_ID,
                    SPAR_NOMBRE = s.SPAR_NOMBRE

                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> GetHistoriaClinicaMadSubTipoProgramacion()
        {
            try
            {
                List<DbContext.Entities.HistoriaClinicaMadSubTipoProgramacion> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadSubTipoProgramacion>();

                historiasClinicas = await _uow.ExecuteStoredProcAll<DbContext.Entities.HistoriaClinicaMadSubTipoProgramacion>("SPRMDS_LIST_HISTORIACLINICA_MAD_SUBTIPO_PROGRAMACION");

                List<HistoriaClinicaMadSubTipoProgramacionDto> listHistoriasClinicas = new List<HistoriaClinicaMadSubTipoProgramacionDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaMadSubTipoProgramacionDto
                {
                    CPAR_ID = s.CPAR_ID,
                    SPAR_NOMBRE = s.SPAR_NOMBRE

                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }
        #endregion

        #region "Estado 3 - 5"
        //By Julio Carrera
        public async Task<ServiceResponse> GetHistoriaClinicaMadValidacionTiempo(int codigoHistoria)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoHistoria},
                    //new SqlParameter("@CODIGO_MEDICO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoMedico}
                };

                List<DbContext.Entities.HistoriaClinicaMadValidacionTiempo> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadValidacionTiempo>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadValidacionTiempo>("SPRMDS_LIST_HISTORIA_CLINICA_MAD_VALIDACION_TIEMPO", parameters);

                List<HistoriaClinicaMadValidacionTiempoDto> listHistoriasClinicas = new List<HistoriaClinicaMadValidacionTiempoDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaMadValidacionTiempoDto
                {

                    numero_historia = s.CHIS_ID,
                    estado = s.SHIS_CM_ESTADO,
                    clasificacion_pac = s.NHIS_CLASIFICACION_PAC,
                    paciente = s.PACIENTE,
                    distrito = s.DISTRITO,
                    direccion = s.DIRECCION,
                    numero_lote = s.SDIR_NRO_LOTE,
                    numero_interior = s.SDIR_INTERIOR,
                    urbanizacion = s.SDIR_URBANIZACION,
                    referencia = s.SDIR_REFERENCIA,
                    medico = s.MEDICO,
                    conductor = s.CONDUCTOR,
                    celular_medico = s.CELULAR_MEDICO,
                    celular_conductor = s.CELULAR_CONDUCTOR

                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> AddHistoriaClinicaAuditoriaEstadoValidacionTiempo(HistoriaClinicaAuditoriaEstadoValidacionTiempoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMEROHISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NUMEROHISTORIA },
                    new SqlParameter("@ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ESTADO,},
                    new SqlParameter("@USUARIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.USUARIO,},
                    new SqlParameter("@OBSERVACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.OBSERVACION,},
                    new SqlParameter("@CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.CAMBIO,},
                    new SqlParameter("@USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.USUARIO_CREACION,},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AUDITORIA_ESTADO_VALIDACION_TIEMPO", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempo(UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.numerO_HISTORIA },
                    new SqlParameter("@DHIS_HRLLEDR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.dhiS_HRLLEDR },
                    new SqlParameter("@DHIS_FECLLEDR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.dhiS_FECLLEDR },
                    new SqlParameter("@FHIS_FLG_CM_NUEVA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.fhiS_FLG_CM_NUEVA },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.shiS_CM_ESTADO },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_HISTORIA_CLINICA_AUDITORIA_ESTADO_VALIDACION_TIEMPO", parameters);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
        #endregion

        #region "Estado 5 - 6"
        //By Julio Carrera
        public async Task<ServiceResponse> GetHistoriaClinicaMadConfirmarRecepcionMensaje(int numeroHistoria)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = numeroHistoria},
                };

                List<DbContext.Entities.HistoriaClinicaMadConfirmarRecepcionMensaje> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadConfirmarRecepcionMensaje>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadConfirmarRecepcionMensaje>("SPRMDS_LIST_HISTORIA_CLINICA_MAD_CONFIRMAR_RECEPCION_MENSAJE", parameters);

                List<HistoriaClinicaMadConfirmarRecepcionMensajeDto> listHistoriasClinicas = new List<HistoriaClinicaMadConfirmarRecepcionMensajeDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaMadConfirmarRecepcionMensajeDto
                {
                    DHIS_HOR_ATE = s.DHIS_HOR_ATE,
                    CHIS_ID = s.CHIS_ID,
                    CONDUCTOR = s.CONDUCTOR,
                    DIRECCION = s.DIRECCION,
                    DISTRITO = s.DISTRITO,
                    FHIS_FLG_REPROGRAMADA = s.FHIS_FLG_REPROGRAMADA,
                    MEDICO = s.MEDICO,
                    PACIENTE = s.PACIENTE,
                    SHIS_CM_ESTADO = s.SHIS_CM_ESTADO,
                    SHIS_F_PROG = s.SHIS_F_PROG
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera
        public async Task<ServiceResponse> AddHistoriaClinicaAuditoriaEstadoRecepcionMensaje(AddHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMEROHISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.numerohistoria },
                    new SqlParameter("@ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado,},
                    new SqlParameter("@USUARIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usuario,},
                    new SqlParameter("@OBSERVACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion,},
                    new SqlParameter("@CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cambio,},
                    new SqlParameter("@USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuariO_CREACION,},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AUDITORIA_ESTADO_RECEPCION_MENSAJE", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Julio Carrera

        public async Task<ServiceResponse> UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensaje(UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NUMERO_HISTORIA },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESTADO },
                    new SqlParameter("@NHIS_CM_ORDEN", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_ORDEN },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_HISTORIA_CLINICA_AUDITORIA_ESTADO_RECEPCION_MENSAJE", parameters);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
        #endregion

        //ESTADO 6 - 7

        //By Henrry Torres
        //6 - 7 (API 1)
        public async Task<ServiceResponse> GetHistoriaClinicaMadConfirmarLlegadaMedico(int codigoHistoria)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoHistoria},
                };

                List<DbContext.Entities.HistoriaClinicaMadConfirmarLlegadaMedico> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadConfirmarLlegadaMedico>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadConfirmarLlegadaMedico>("SPRMDS_LIST_HISTORIA_CLINICA_MAD_CONFIRMAR_LLEGADA_MEDICO", parameters);

                List<HistoriaClinicaMadConfirmarLlegadaMedicoDto> list = new List<HistoriaClinicaMadConfirmarLlegadaMedicoDto>();

                list = historiasClinicas.Select(s => new HistoriaClinicaMadConfirmarLlegadaMedicoDto
                {
                    cod_historia_clinica = s.CHIS_ID,
                    cm_estado = s.SHIS_CM_ESTADO,
                    clasificacion_pac = s.NHIS_CLASIFICACION_PAC,
                    paciente = s.PACIENTE,
                    distrito = s.DISTRITO,
                    direccion = s.DIRECCION,
                    medico = s.MEDICO
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        //6 - 7 (API 2)
        public async Task<ServiceResponse> GetHistoriaClinicaMadEstado7(int codigoMedico, DateTime fechaLlegada, DateTime horaLlegada)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CODIGO_MEDICO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoMedico},
                    new SqlParameter("@FECHA_LLEGADA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaLlegada},
                    new SqlParameter("@HORA_LLEGADA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = horaLlegada},
                };

                List<DbContext.Entities.HistoriaClinicaMadEstado7> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadEstado7>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadEstado7>("SPRMDS_ESTADO_7_API2", parameters);

                List<HistoriaClinicaMadEstado7Dto> list = new List<HistoriaClinicaMadEstado7Dto>();

                list = historiasClinicas.Select(s => new HistoriaClinicaMadEstado7Dto
                {
                    cod_conductor = s.CMCH_ID,
                    conductor = s.CONDUCTOR,
                    fecha_inicio_asignado = s.DMCH_FEC_INI_ASIG,
                    hora_inicio_asignado = s.DMCH_HOR_INI_ASIG,
                    fecha_fin_asignado = s.DMCH_FEC_FIN_ASIG,
                    hora_fin_asignado = s.DMCH_HOR_FIN_ASIG
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        //6 - 7 (API 3)
        public async Task<ServiceResponse> AddHistoriaClinicaMadAuditoriaConfirmarLlegadaMedico(HistoriaClinicaMadAuditoriaEstadoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMEROHISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NUMEROHISTORIA },
                    new SqlParameter("@ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ESTADO,},
                    new SqlParameter("@USUARIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.USUARIO,},
                    new SqlParameter("@OBSERVACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.OBSERVACION,},
                    new SqlParameter("@CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.CAMBIO,},
                    new SqlParameter("@USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.USUARIO_CREACION,},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AUDITORIA_ESTADO_CONFIRMAR_LLEGADA_MEDICO", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        //6 - 7 (API 4)
        public async Task<ServiceResponse> UpdateHistoriaClinicaMadAuditoriaConfirmarLlegadaMedico(HistoriaClinicaAuditoriaConfirmarLlegadaMedicoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.numerohistoria },
                    new SqlParameter("SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cm_estado},
                    new SqlParameter("NHIS_COD_ASIG", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.asig},
                    new SqlParameter("NHIS_CM_ORDEN", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.orden},
                    new SqlParameter("SHIS_USUOPLLA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usuoplla_ate},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_HISTORIA_CLINICA_AUDITORIA_ESTADO_CONFIRMAR_LLEGADA_MEDICO", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //ESTADO 7 - 8

        //By Henrry Torres
        //7 - 8 (API 1)
        public async Task<ServiceResponse> GetHistoriaClinicaMadFinConsultaMedica(int codigoHistoria, int codigoPaciente, int codigoDireccion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoHistoria},
                    new SqlParameter("@CODIGO_PACIENTE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoPaciente},
                    new SqlParameter("@CODIGO_DIRECCION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoDireccion},
                };

                List<DbContext.Entities.HistoriaClinicaMadFinConsultaMedica> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMadFinConsultaMedica>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMadFinConsultaMedica>("SPRMDS_LIST_HISTORIA_CLINICA_MAD_CONFIRMAR_LLEGADA_MEDICO", parameters);

                List<HistoriaClinicaMadFinConsultaMedicaDto> list = new List<HistoriaClinicaMadFinConsultaMedicaDto>();

                list = historiasClinicas.Select(s => new HistoriaClinicaMadFinConsultaMedicaDto
                {
                    Hora = s.HORA,
                    cod_historia_clinica = s.CHIS_ID,
                    cm_estado = s.SHIS_CM_ESTADO,
                    estado = s.NHIS_COD_ESTADO,
                    clasificacion_pac = s.NHIS_CLASIFICACION_PAC,
                    fecoplla_ate = s.DHIS_FECOPLLA_ATE,
                    fecha_atencion = s.DHIS_FEC_ATE,
                    contador_periodo = s.NHIS_CONTADOR_PERIODO,
                    paciente = s.PACIENTE,
                    distrito = s.DISTRITO,
                    direccion = s.DIRECCION,
                    medico = s.MEDICO,
                    conductor = s.CONDUCTOR
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(list);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        //7 - 8 (API 2)
        public async Task<ServiceResponse> UpdateHistoriaClinicaEstadoMadFinConsultaMedica(HistoriaClinicaMadAuditoriaEstadoFinConsultaDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NUMERO_HISTORIA },
                    new SqlParameter("@FECDIA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FECDIA_ATE,},
                    new SqlParameter("@HORDIA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.HORDIA_ATE,},
                    new SqlParameter("@USUDIA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.USUDIA_ATE,},
                    new SqlParameter("@ACCIDE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ACCIDE,},
                    new SqlParameter("@ATENCION_REFERENCIAL", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.ATENCION_REFERENCIAL,},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_HISTORIA_CLINICA_AUDITORIA_ESTADO_MAD_FIN_CONSULTA_MEDICA", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        //7 - 8 (API 3)
        public async Task<ServiceResponse> UpdateHistoriaClinicaOtrosServiciosFinConsultaMedica(HistoriaClinicaMadAuditoriaEstadoFinConsultaDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NUMERO_HISTORIA },
                    new SqlParameter("@FECOPLLA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FECOPLLA_ATE,},
                    new SqlParameter("@HOROPLLA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.HOROPLLA_ATE,},
                    new SqlParameter("@FECDIA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FECDIA_ATE,},
                    new SqlParameter("@HORDIA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.HORDIA_ATE,},
                    new SqlParameter("@USUDIA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.USUDIA_ATE,},
                    new SqlParameter("@ACCIDE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ACCIDE,},
                    new SqlParameter("@ATENCION_REFERENCIAL", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.ATENCION_REFERENCIAL},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_HISTORIA_CLINICA_AUDITORIA_ESTADO_OTROS_SERVICIOS_FIN_CONSULTA_MEDICA", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //7 - 8 (API 4)
        //Aun esta en análisis

        //By Henrry Torres
        //7 - 8 (API 5)
        public async Task<ServiceResponse> DeleteHistoriaClinicaOtrosServiciosFinConsultaMedica(HistoriaClinicaMadAuditoriaEstadoFinConsultaDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMERO_HISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NUMERO_HISTORIA },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_HISTORIA_CLINICA_AUDITORIA_ESTADO_FIN_CONSULTA_MEDICA", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        //7 - 8 (API 6)
        public async Task<ServiceResponse> AddHistoriaClinicaMadEstadoFinConsultaMedica(HistoriaClinicaEstadoFinConsultaDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CHIS_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CHIS_ID },
                    new SqlParameter("@CHCP_COD_ASO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CHCP_COD_ASO },
                    new SqlParameter("@CPAC_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAC_ID },
                    new SqlParameter("@CESP_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CESP_ID },
                    new SqlParameter("@CUBI_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CUBI_ID },
                    new SqlParameter("@CTDO_ID", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.CTDO_ID },
                    new SqlParameter("@CEMP_ID", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.CEMP_ID },
                    new SqlParameter("@FHCP_EXP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHCP_EXP },
                    new SqlParameter("@FHCP_EXI_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHCP_EXI_ATE },
                    new SqlParameter("@NHCP_TAR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHCP_TAR_ATE },
                    new SqlParameter("@NHCP_TAR_ATEOPE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHCP_TAR_ATEOPE },
                    new SqlParameter("@SHCP_OBS_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_OBS_ATE },
                    new SqlParameter("@SHCP_COD_TIPO_DOCTOR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_COD_TIPO_DOCTOR },
                    new SqlParameter("@FHCP_FLGVNR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHCP_FLGVNR },
                    new SqlParameter("@SHCP_ACCIDE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_ACCIDE },
                    new SqlParameter("@SHCP_FOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_FOR_ATE },
                    new SqlParameter("@SHCP_SIN_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_SIN_ATE },
                    new SqlParameter("@SHCP_CODTAR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_CODTAR_ATE },
                    new SqlParameter("@SHCP_NTAR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_NTAR_ATE },
                    new SqlParameter("@DHCP_FVENC_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHCP_FVENC_ATE },
                    new SqlParameter("@DHCP_FECLLA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHCP_FECLLA },
                    new SqlParameter("@DHCP_HORLLA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHCP_HORLLA },
                    new SqlParameter("@DHCP_FECFIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHCP_FECFIN },
                    new SqlParameter("@DHCP_HORFIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHCP_HORFIN },
                    new SqlParameter("@FHCP_YO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHCP_YO },
                    new SqlParameter("@SHCP_CANC_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_CANC_ATE },
                    new SqlParameter("@SHCP_POLIZA_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_POLIZA_ASEGURADO },
                    new SqlParameter("@SHCP_COD_AUT_PRESTACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_COD_AUT_PRESTACION },
                    new SqlParameter("@SHCP_COD_SOLGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_COD_SOLGEN },
                    new SqlParameter("@SHCP_CODAASEG_EPS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_CODAASEG_EPS },
                    new SqlParameter("@NHCP_COASEGURO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHCP_COASEGURO },
                    new SqlParameter("@SHCP_COD_DENOMINACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_COD_DENOMINACION },
                    new SqlParameter("@SHCP_F_SERV", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_F_SERV },
                    new SqlParameter("@SHCP_CM_ASEG_PRODUCTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_CM_ASEG_PRODUCTO },
                    new SqlParameter("@SHCP_TIPO_SERVICIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHCP_TIPO_SERVICIO },
                    new SqlParameter("@NHCP_USUARIO_CREACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHCP_USUARIO_CREACION },
                    new SqlParameter("@DHCP_FECHA_CREACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHCP_FECHA_CREACION },
                    new SqlParameter("@NHCP_USUARIO_MODIFICACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHCP_USUARIO_MODIFICACION },
                    new SqlParameter("@DHCP_FECHA_MODIFICACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHCP_FECHA_MODIFICACION },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_ESTADO_FIN_CONSULTA_MEDICA", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        //7 - 8 (API 7)
        public async Task<ServiceResponse> AddHistoriaClinicaMadAuditoriaEstadoFinConsultaMedica(HistoriaClinicaMadAuditoriaEstadoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@NUMEROHISTORIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NUMEROHISTORIA },
                    new SqlParameter("@ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ESTADO,},
                    new SqlParameter("@USUARIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.USUARIO,},
                    new SqlParameter("@OBSERVACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.OBSERVACION,},
                    new SqlParameter("@CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.CAMBIO,},
                    new SqlParameter("@USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.USUARIO_CREACION,},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AUDITORIA_ESTADO_FIN_CONSULTA_MEDICA", parameters);

                dto.onRespuesta = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

    }
}