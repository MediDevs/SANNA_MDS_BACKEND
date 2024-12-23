using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Dto.List;
using MDS.Dto.Resources;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Settings;
using MDS.Services.HistoriaClinica;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HistoriaClinicaController : BaseController
    {
        private readonly IAppSettings _appSettings;
        private readonly IHistoriaClinicaService _historiaClinicaService;
        private readonly WebServicePostgres _webServicePostgres;

        public HistoriaClinicaController(IAppSettings appSettings, IHistoriaClinicaService historiaClinicaService)
        {
            _appSettings = appSettings;
            _historiaClinicaService = historiaClinicaService;
            _webServicePostgres = new WebServicePostgres();
        }

        //////////////////          SERVICIO MAD          //////////////////

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Mad_Cliente")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Cliente(string vNumero)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Cliente_Codigo(vNumero);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetSiteds_Codigo")]
        public async Task<IActionResult> GetSiteds_Codigo(string vCodigo)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Siteds_Codigo(vCodigo);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetSiteds_Numero")]
        public async Task<IActionResult> GetSiteds_Numero(string vNumero)
        {
            var response = await _historiaClinicaService.GetSiteds_Numero(vNumero);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Mad_Filtro")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Filtro(string? vCampoBusqueda = null, string? vValorBusqueda = null, string? vFechaInicio = null, string? vFechaFinal = null)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasMadFiltro(vCampoBusqueda, vValorBusqueda, vFechaInicio, vFechaFinal);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Mad_Filtro_Rango_By_Fechas")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Filtro_Rango_By_Fechas(string? vFechaInicio = null, string? vFechaFinal = null)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasMadFiltro_Rango_By_Fechas(vFechaInicio, vFechaFinal);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Mad_Filtro_Campos")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Filtro_Campos(string? vCampoBusqueda = null, string? vValorBusqueda = null)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasMadFiltro_Campos(vCampoBusqueda, vValorBusqueda);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Paciente_x_Numero")]
        public async Task<IActionResult> GetHistoriaClinica_Paciente_x_Numero(string vNumero)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Paciente_Dni(vNumero);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Clientes_Siteds")]
        public async Task<IActionResult> GetHistoriaClinica_Clientes_Siteds()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Clientes_Siteds();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Clientes_Siteds_By_Nombre")]
        public async Task<IActionResult> GetHistoriaClinica_Clientes_Siteds_By_Nombre(string vCliente)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Clientes_Siteds_By_Nombre(vCliente);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Paciente_Distrito")]
        public async Task<IActionResult> GetHistoriaClinica_Paciente_Distrito(string vDistrito)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Paciente_Distrito(vDistrito);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Aseguradora")]
        public async Task<IActionResult> GetHistoriaClinica_Aseguradora(string vAseguradora)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Aseguradora(vAseguradora);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Aseguradora_Categoria")]
        public async Task<IActionResult> GetHistoriaClinica_Aseguradora_Categoria(string vAseguradora)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Aseguradora_Categoria(vAseguradora);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Genero")]
        public async Task<IActionResult> GetHistoriaClinica_Genero()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Genero();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_TipoDocumento")]
        public async Task<IActionResult> GetHistoriaClinica_TipoDocumento()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_TipoDocumento();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Vip")]
        public async Task<IActionResult> GetHistoriaClinica_Vip()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Vip();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Seguro")]
        public async Task<IActionResult> GetHistoriaClinica_Seguro()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Seguro();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Clasificacion")]
        public async Task<IActionResult> GetHistoriaClinica_Clasificacion()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Clasificacion();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Ubigeo_Codigo")]
        public async Task<IActionResult> GetHistoriaClinica_Ubigeo_Codigo(string vDepartamento, string vProvincia, string vDistrito)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Ubigeo_Codigo(vDepartamento, vProvincia, vDistrito);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Ubigeo")]
        public async Task<IActionResult> GetHistoriaClinica_Ubigeo(string vDistrito)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Ubigeo(vDistrito);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Dni")]
        public async Task<IActionResult> GetHistoriaClinica_Dni()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Dni();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Paciente_x_Dni")]
        public async Task<IActionResult> GetHistoriaClinica_Paciente_x_Dni(string vDni, string vNumero)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Paciente_x_Dni(vDni, vNumero);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica")]
        public async Task<IActionResult> GetHistoriaClinicas()
        {
            var response = await _historiaClinicaService.GetHistoriaClinicas();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriasClinicas")]
        public async Task<IActionResult> GetHistoriasClinicas(string vFechaIni, string vFechaFin, string vCondicion)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicas(vFechaFin, vFechaFin, vCondicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetHistoriaClinicaMadByCodigo")]
        public async Task<IActionResult> GetHistoriaClinicaMadByCodigo(int historiaClinicaId)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadByCodigo(historiaClinicaId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddHistoriaClinicaSiteds")]
        public async Task<IActionResult> AddHistoriaClinicaSiteds(CreateSitedsViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            SitedsMtoDto dto = new SitedsMtoDto
            {
                //csit_id = model.csit_id,
                id_historia = model.id_historia,
                documentoautorizacion = model.documentoautorizacion,
                codigoafiliado = model.codigoafiliado,
                numeropoliza = model.numeropoliza,
                numerocontrato = model.numerocontrato,
                numerocertificado = model.numerocertificado,
                codproducto = model.codproducto,
                desproducto = model.desproducto,
                apellidopaternoafiliado = model.apellidopaternoafiliado,
                apellidomaternoafiliado = model.apellidomaternoafiliado,
                nombresafiliado = model.nombresafiliado,
                codgenero = model.codgenero,
                desgenero = model.desgenero,
                codfechanacimiento = model.codfechanacimiento,
                fechanacimiento = model.fechanacimiento,
                codparentesco = model.codparentesco,
                desparentesco = model.codparentesco,
                codtipodocumentoafiliado = model.codtipodocumentoafiliado,
                destipodocumentoafiliado = model.destipodocumentoafiliado,
                numerodocumentoafiliado = model.numerodocumentoafiliado,
                edad = model.edad,
                codfechainiciovigencia = model.codfechafinvigencia,
                fechainiciovigencia = model.fechainiciovigencia,
                codfechafinvigencia = model.codfechafinvigencia,
                fechafinvigencia = model.fechafinvigencia,
                codestadocivil = model.codestadocivil,
                desestadocivil = model.desestadocivil,
                codtipoplan = model.codtipoplan,
                destipoplan = model.destipoplan,
                numeroplan = model.numeroplan,
                codestado = model.codestado,
                desestado = model.desestado,
                codfechaactualizacionfoto = model.codfechaactualizacionfoto,
                fechaactualizacionfoto = model.fechaactualizacionfoto,
                apellidopaternotitular = model.apellidopaternotitular,
                apellidomaternotitular = model.apellidomaternotitular,
                nombrestitular = model.nombrestitular,
                codigotitular = model.codigotitular,
                codtipodocumentotitular = model.codtipodocumentotitular,
                destipodocumentotitular = model.destipodocumentotitular,
                numerodocumentotitular = model.numerodocumentotitular,
                codmoneda = model.codmoneda,
                desmoneda = model.desmoneda,
                nombrecontratante = model.nombrecontratante,
                codtipodocumentocontratante = model.codtipodocumentocontratante,
                destipodocumentocontratante = model.destipodocumentocontratante,
                codtipoafiliacion = model.codtipoafiliacion,
                destipoafiliacion = model.destipoafiliacion,
                codfechaafiliacion = model.codfechaafiliacion,
                fechaafiliacion = model.fechaafiliacion,
                numerodocumentocontratante = model.numerodocumentocontratante,
                codigotipocobertura = model.codigosubtipocobertura,
                codigosubtipocobertura = model.codigosubtipocobertura,
                codigocobertura = model.codigocobertura,
                beneficios = model.beneficios,
                codindicadorrestriccion = model.codindicadorrestriccion,
                restricciones = model.restricciones,
                codcopagofijo = model.codcopagofijo,
                descopagofijo = model.descopagofijo,
                codcopagovariable = model.codcopagovariable,
                descopagovariable = model.descopagovariable,
                codfechafincarencia = model.codfechafincarencia,
                fechafincarencia = model.fechafincarencia,
                condicionesespeciales = model.condicionesespeciales,
                observaciones = model.observaciones,
                codcalificacionservicio = model.codcalificacionservicio,
                descalificacionservicio = model.descalificacionservicio,
                beneficiomaximoinicial = model.beneficiomaximoinicial,
                numerocobertura = model.numerocobertura,
                fecha_creacion_doc_aut = model.fecha_creacion_doc_aut,
                hora_creacion_doc_aut = model.hora_creacion_doc_aut,
                descripcion_producto = model.descripcion_producto,
                usuario_creacion = model.usuario_creacion,
                fecha_creacion = model.fecha_creacion,
                usuario_modificacion = model.usuario_modificacion,
                fecha_modificacion = model.fecha_modificacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaSiteds(dto);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddHistoriaClinicaMedioComunicacionMad")]
        public async Task<IActionResult> AddHistoriaClinicaMedioComunicacionMad(CreateHistoriaClinicaMedioComunicacionMadViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMedioComunicacionMtoMadDto dto = new HistoriaClinicaMedioComunicacionMtoMadDto
            {
                id_historiaclinica = model.id_historiaclinica,
                numero = model.numero,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaMedioComunicacionMad(dto);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("RegistrarHistoriaClinica")]
        public async Task<IActionResult> RegistrarHistoriaClinica(RegistrarHistoriaClinicaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            RegistrarHistoriaClinicaDto dto = new RegistrarHistoriaClinicaDto
            {
                e = model.e,
                prog = model.prog,
                codate = model.codate,
                clasif = model.clasif,
                e_tablet = model.e_tablet,
                codautorizacion = model.codautorizacion,
                feclla = model.feclla,
                hrlla = model.hrlla,
                tiempo = model.tiempo,
                fecate = model.fecate,
                hrxdefecto = model.hrxdefecto,
                hrestimada = model.hrestimada,
                hrllegada = model.hrllegada,
                provincia = model.provincia,
                distrito = model.distrito,
                paciente = model.paciente,
                fpago = model.fpago,
                vip = model.vip,
                grupo = model.grupo,
                periodo = model.periodo,
                cont = model.cont,
                perfil = model.perfil,
                espec = model.espec,
                doctor = model.doctor,
                grupos = model.grupos,
                empresa = model.empresa,
                usuario = model.usuario,
                cod_doc = model.cod_doc,
            };

            var response = await _historiaClinicaService.RegistrarHistoriaClinica(dto);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddHistoriaClinicaMad")]
        public async Task<IActionResult> AddHistoriaClinicaMad(CreateHistoriaClinicaMadViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoMadDto dto = new HistoriaClinicaMtoMadDto
            {
                cmed_id = model.cmed_id,

                cpac_id = model.cpac_id,

                cesp_id = model.cesp_id,

                cest_id = model.cest_id,

                cper_id = model.cper_id,

                cser_id = model.cser_id,

                cpai_id = model.cpai_id,

                cubi_id = model.cubi_id,

                cmep_id = model.cmep_id,

                ctdo_id = model.ctdo_id,

                cclt_id = model.cclt_id,

                cdsn_id = model.cdsn_id,

                estado = model.estado,

                prog = model.prog,

                codautorizacion = model.codautorizacion,

                feclla = model.feclla,

                horlla = model.horlla,

                tiempo = model.tiempo,

                fecate = model.fecate,

                horate = model.horate,

                hrlledr = model.hrlledr,

                horoplla = model.horoplla,

                fpago = model.fpago,

                vip = model.vip,

                grupo = model.grupo,

                cont = model.cont,

                perfil = model.perfil,

                empresa = model.empresa,

                //INICIO NUEVOS CAMPOS PARA REGISTRAR HC

                //cod_estado = model.cod_estado,

                //cm_orden = model.cm_orden,

                flg_cm_nueva = model.flg_cm_nueva,

                usulla_ate = model.usulla_ate,

                cod_emp = model.cod_emp,

                flag_programada = model.flag_programada,

                f_soldoct = model.f_soldoct,

                motivo_tipo_prog = model.motivo_tipo_prog,

                observacion = model.observacion,

                tar_ate = model.tar_ate,

                cambio = model.cambio,

                codtar_ate = model.codtar_ate,

                ntar_ate = model.ntar_ate,

                tarj_mc = model.tarj_mc,

                fvenc_ate = model.fvenc_ate,

                sin_ate = model.sin_ate,

                contacto_pac = model.contacto_pac,

                contacto_aseg = model.contacto_aseg,

                cod_aut_prestacion = model.cod_aut_prestacion,

                cod_asegurado = model.cod_asegurado,

                cod_solgen = model.cod_solgen,

                cm_aseg_producto = model.cm_aseg_producto,

                poliza_asegurado = model.poliza_asegurado,

                poliza_certificado = model.poliza_certificado,

                tipo_afiliacion = model.tipo_afiliacion,

                id_paquete = model.id_paquete,

                primera_consulta = model.primera_consulta,

                clasificacion_pac = model.clasificacion_pac,

                id_periodo_consulta = model.id_periodo_consulta,

                tipo_ate = model.tipo_ate,

                tipo_doc_pago = model.tipo_doc_pago,

                id_condicion_especial_pago = model.id_condicion_especial_pago,

                descrp_zona = model.descrp_zona,

                empresa_paciente = model.empresa_paciente,

                id_mrp = model.id_mrp,

                cod_categoria_serv_cliente = model.cod_categoria_serv_cliente,

                modo_atencion_medico = model.modo_atencion_medico,

                usuariocreacion = model.usuariocreacion,


                //fechacreacion = model.fechacreacion,

            };

            var response = await _historiaClinicaService.AddHistoriaClinicaMad(dto);

            return ReturnFormattedResponse(response);
        }
        //////////////////          FIN SERVICIO MAD          //////////////////

        //////////////////          SERVICIO SCTR          //////////////////

        //By Henrry Torres
        [HttpGet, Route("GetHistoriaClinicaSctrByCodigo")]
        public async Task<IActionResult> GetHistoriaClinicaSctrByCodigo(string cod_historia_clinica)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaSctrByCodigo(cod_historia_clinica);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetHistoriasClinicasSctrBandeja")]
        public async Task<IActionResult> GetHistoriasClinicasSctrBandeja(string fechaInicio, string fechaFin, string condicion)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasSctrBandeja(fechaInicio, fechaFin, condicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetHistoriasClinicasSctrFiltro")]
        public async Task<IActionResult> GetHistoriasClinicasSctrFiltro(string fechaInicio, string fechaFin, string? busqueda, string? condicion, int reporte)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasSctrFiltro(fechaInicio, fechaFin, busqueda, condicion, reporte);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinicaSctr")]
        public async Task<IActionResult> AddHistoriaClinicaSctr(CreateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                id_persona = model.id_persona,
                id_clinica = model.id_clinica,
                id_empresa = model.id_empresa,
                id_motivo = model.id_motivo,
                id_plan = model.id_plan,
                horario_trabajo = model.horario_trabajo,
                cargo = model.cargo,
                relato = model.relato,
                fecha_accidente = model.fecha_accidente,
                hora_accidente = model.hora_accidente,
                observacion = model.observacion,
                primera_atencion = model.primera_atencion,
                metodo_validacion = model.metodo_validacion,
                hoja_atencion = model.hoja_atencion,
                ubigeo = model.ubigeo,
                skill = model.skill,
                motivo_skill = model.motivo_skill,
                centro_clinico = model.centro_clinico,
                empresa = model.empresa,
                corredor_seguro = model.corredor_seguro,
                paciente_asegurado = model.paciente_asegurado,
                persona_reporta_clinica = model.persona_reporta_clinica,
                persona_reporta_asegurado = model.persona_reporta_asegurado,
                persona_reporta_empresa = model.persona_reporta_empresa,
                persona_reporta_seguro = model.persona_reporta_seguro,
                usuario_creacion = model.usuario_creacion,
                id_clinica_primera_atencion = model.id_clinica_primera_atencion,
                pase_atencion = model.pase_atencion,
                estado = model.estado,
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaSctr(dto);

            //REPLICA EN BD PG
            if (response.Success)
            {
                //Guardar en Postgres
                long pk_sql = Convert.ToInt64(response.ResultData.GetType().GetProperty("cod_historia_clinica").GetValue(response.ResultData, null));

                string uriWsPg;
                h_sctr_atencion dto_h_sctr_atencion = new h_sctr_atencion();
                string estadoWsPg = _appSettings.EstadoWsPostgres;

                bool _flg_centro_clinico = false;
                bool _flg_corredor_seguro = false;
                bool _flg_empresa = false;
                bool _flg_paciente_asegurado = false;
                bool _hoja_atencion = false;

                if (model.centro_clinico == 1)
                {
                    _flg_centro_clinico = true;
                }
                if (model.corredor_seguro == 1)
                {
                    _flg_corredor_seguro = true;
                }
                if (model.empresa == 1)
                {
                    _flg_empresa = true;
                }
                if (model.paciente_asegurado == 1)
                {
                    _flg_paciente_asegurado = true;
                }
                if (model.hoja_atencion == 1)
                {
                    _flg_paciente_asegurado = true;
                }

                if (model.motivo_skill == 20)
                {
                    //REGISTRAR ATENCION SCTR
                    dto_h_sctr_atencion = new h_sctr_atencion
                    {
                        PrimaryKey_SQL = pk_sql,
                        cod_paciente = model.id_persona.ToString(),
                        cod_cliente = model.id_empresa.ToString(),
                        cod_ipress = model.id_clinica.ToString(),
                        horario_trabajo = model.horario_trabajo,
                        puesto_cargo = model.cargo,
                        relato = model.relato,
                        fecha_accidente = model.fecha_accidente,
                        hora_accidente = model.hora_accidente,
                        id_tipo_atencion = Int32.Parse(model.primera_atencion),
                        tipo_pase_atencion = model.pase_atencion,
                        id_motivo = model.id_motivo,
                        observacion = model.observacion,
                        ipress_primera_ate = model.id_clinica_primera_atencion.ToString(),
                        Codigo_Usuario_PG = model.usuario_creacion_pg,
                        ubigeo_accidente = model.ubigeo,
                        metodo_validacion = model.metodo_validacion,
                        id_plan = model.id_plan,
                        hoja_atencion = _hoja_atencion,
                        id_skill = model.skill,
                        id_motivo_skill = model.motivo_skill,
                        ipress_persona_reporta = model.persona_reporta_clinica,
                        persona_reporta_asegurado = model.persona_reporta_asegurado,
                        persona_reporta_empresa = model.persona_reporta_empresa,
                        persona_reporta_corredor_seguro = model.persona_reporta_seguro,
                        flg_centro_clinico = _flg_centro_clinico,
                        flg_corredor_seguro = _flg_corredor_seguro,
                        flg_empresa = _flg_empresa,
                        flg_paciente_asegurado = _flg_paciente_asegurado,
                        estado = model.estado.ToString()
                    };

                    uriWsPg = _appSettings.WsPostgres + "api/h_sctr_atencion/AddAtencion";
                }
                else
                {
                    //REGISTRAR OTRO MOTIVO ATENCION SCTR
                    dto_h_sctr_atencion = new h_sctr_atencion
                    {
                        PrimaryKey_SQL = pk_sql,
                        cod_cliente = model.id_empresa.ToString(),
                        cod_ipress = model.id_clinica.ToString(),
                        id_motivo = model.id_motivo,
                        id_skill = model.skill,
                        id_motivo_skill = model.motivo_skill,
                        ipress_persona_reporta = model.persona_reporta_clinica,
                        observacion = model.observacion,
                        persona_reporta_empresa = model.persona_reporta_empresa,
                        persona_reporta_corredor_seguro = model.persona_reporta_seguro,
                        persona_reporta_asegurado = model.persona_reporta_asegurado,
                        flg_centro_clinico = _flg_centro_clinico,
                        flg_empresa = _flg_empresa,
                        flg_corredor_seguro = _flg_corredor_seguro,
                        flg_paciente_asegurado = _flg_paciente_asegurado,
                        estado = model.estado.ToString(),
                        Codigo_Usuario_PG = model.usuario_creacion_pg
                    };

                    uriWsPg = _appSettings.WsPostgres + "api/h_sctr_atencion/AddOtroMotivoAtencion";
                }

                var rptaWs = _webServicePostgres.Consumir(uriWsPg, dto_h_sctr_atencion, estadoWsPg);

                if (rptaWs.Success)
                {
                    //REGISTRAR SEGUIMIENTO ATENCION SCTR
                    m_segatenciones dto_m_segatenciones = new m_segatenciones
                    {
                        PrimaryKey_SQL = Convert.ToInt64(response.ResultData.GetType().GetProperty("cod_seguimiento").GetValue(response.ResultData, null)),
                        cod_ate = Convert.ToInt64(rptaWs.PrimaryKeyGenerado),
                        obs_ser = "HISTORIA CLINICA SCTR CREACIÓN",
                        des_ser = "CTR",
                        Codigo_Usuario_PG = model.usuario_creacion_pg
                    };

                    uriWsPg = _appSettings.WsPostgres + "api/m_segatenciones/Add";

                    _webServicePostgres.Consumir(uriWsPg, dto_m_segatenciones, estadoWsPg);
                }
            }

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut, Route("UpdateHistoriaClinicaSctr")]
        public async Task<IActionResult> UpdateHistoriaClinicaSctr(UpdateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                cod_historia_clinica = model.cod_historia_clinica,
                id_persona = model.id_persona,
                id_clinica = model.id_clinica,
                id_empresa = model.id_empresa,
                id_motivo = model.id_motivo,
                id_plan = model.id_plan,
                horario_trabajo = model.horario_trabajo,
                cargo = model.cargo,
                relato = model.relato,
                fecha_accidente = model.fecha_accidente,
                hora_accidente = model.hora_accidente,
                observacion = model.observacion,
                primera_atencion = model.primera_atencion,
                metodo_validacion = model.metodo_validacion,
                hoja_atencion = model.hoja_atencion,
                ubigeo = model.ubigeo,
                skill = model.skill,
                motivo_skill = model.motivo_skill,
                centro_clinico = model.centro_clinico,
                empresa = model.empresa,
                corredor_seguro = model.corredor_seguro,
                paciente_asegurado = model.paciente_asegurado,
                persona_reporta_clinica = model.persona_reporta_clinica,
                persona_reporta_asegurado = model.persona_reporta_asegurado,
                persona_reporta_empresa = model.persona_reporta_empresa,
                persona_reporta_seguro = model.persona_reporta_seguro,
                usuario_creacion = model.usuario_modificacion,
                id_clinica_primera_atencion = model.id_clinica_primera_atencion,
                pase_atencion = model.pase_atencion,
                estado = model.estado
            };

            var response = await _historiaClinicaService.UpdateHistoriaClinicaSctr(dto);

            //REPLICA EN BD PG
            if (response.Success)
            {
                //Actualizar en Postgres
                string uriWsPg = _appSettings.WsPostgres + "api/h_sctr_atencion/Update";
                string estadoWsPg = _appSettings.EstadoWsPostgres;

                h_sctr_atencion dto_h_sctr_atencion = new h_sctr_atencion();

                bool _flg_centro_clinico = false;
                bool _flg_corredor_seguro = false;
                bool _flg_empresa = false;
                bool _flg_paciente_asegurado = false;
                bool _hoja_atencion = false;

                if (model.centro_clinico == 1)
                {
                    _flg_centro_clinico = true;
                }
                if (model.corredor_seguro == 1)
                {
                    _flg_corredor_seguro = true;
                }
                if (model.empresa == 1)
                {
                    _flg_empresa = true;
                }
                if (model.paciente_asegurado == 1)
                {
                    _flg_paciente_asegurado = true;
                }
                if (model.hoja_atencion == 1)
                {
                    _flg_paciente_asegurado = true;
                }

                if (model.motivo_skill == 20)
                {
                    //ACTUALIZAR ATENCION SCTR
                    dto_h_sctr_atencion = new h_sctr_atencion
                    {
                        PrimaryKey_PG = model.pk_pg,
                        cod_atencion = model.cod_historia_clinica,
                        cod_paciente = model.id_persona.ToString(),
                        cod_cliente = model.id_empresa.ToString(),
                        cod_ipress = model.id_clinica.ToString(),
                        horario_trabajo = model.horario_trabajo,
                        puesto_cargo = model.cargo,
                        relato = model.relato,
                        fecha_accidente = model.fecha_accidente,
                        hora_accidente = model.hora_accidente,
                        id_tipo_atencion = Int32.Parse(model.primera_atencion),
                        tipo_pase_atencion = model.pase_atencion,
                        id_motivo = model.id_motivo,
                        observacion = model.observacion,
                        Codigo_Usuario_PG = model.usuario_modificacion_pg,
                        ipress_primera_ate = model.id_clinica_primera_atencion.ToString(),
                        ubigeo_accidente = model.ubigeo,
                        metodo_validacion = model.metodo_validacion,
                        id_plan = model.id_plan,
                        hoja_atencion = _hoja_atencion,
                        id_skill = model.skill,
                        id_motivo_skill = model.motivo_skill,
                        ipress_persona_reporta = model.persona_reporta_clinica,
                        persona_reporta_asegurado = model.persona_reporta_asegurado,
                        persona_reporta_empresa = model.persona_reporta_empresa,
                        persona_reporta_corredor_seguro = model.persona_reporta_seguro,
                        flg_centro_clinico = _flg_centro_clinico,
                        flg_corredor_seguro = _flg_corredor_seguro,
                        flg_empresa = _flg_empresa,
                        flg_paciente_asegurado = _flg_paciente_asegurado,
                        estado = model.estado.ToString()
                    };
                }

                var rptaWs = _webServicePostgres.Consumir(uriWsPg, dto_h_sctr_atencion, estadoWsPg);

                if (rptaWs.Success)
                {
                    //REGISTRAR SEGUIMIENTO ATENCION SCTR
                    m_segatenciones dto_m_segatenciones = new m_segatenciones
                    {
                        PrimaryKey_SQL = Convert.ToInt64(response.ResultData.GetType().GetProperty("cod_seguimiento").GetValue(response.ResultData, null)),
                        cod_ate = Convert.ToInt64(model.pk_pg),
                        obs_ser = "HISTORIA CLINICA SCTR ACTUALIZACIÓN",
                        des_ser = "CTR",
                        Codigo_Usuario_PG = model.usuario_modificacion_pg
                    };

                    uriWsPg = _appSettings.WsPostgres + "api/m_segatenciones/Add";

                    _webServicePostgres.Consumir(uriWsPg, dto_m_segatenciones, estadoWsPg);
                }
            }

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteHistoriaClinicaSctr")]
        public async Task<IActionResult> DeleteHistoriaClinicaSctr(DeleteHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                cod_historia_clinica = model.cod_historia_clinica,
                usuario_eliminacion = model.usuario_eliminacion
            };

            var response = await _historiaClinicaService.DeleteHistoriaClinicaSctr(dto);

            //REPLICA EN BD PG
            if (response.Success)
            {
                //Actualizar en Postgres
                string uriWsPg = _appSettings.WsPostgres + "api/h_sctr_atencion/Anular";
                string estadoWsPg = _appSettings.EstadoWsPostgres;

                h_sctr_atencion dto_h_sctr_atencion = new h_sctr_atencion();

                //ACTUALIZAR ATENCION SCTR
                dto_h_sctr_atencion = new h_sctr_atencion
                {
                    PrimaryKey_PG = model.pk_pg,
                    cod_atencion = model.cod_historia_clinica,
                    Codigo_Usuario_PG = model.usuario_eliminacion_pg
                };

                var rptaWs = _webServicePostgres.Consumir(uriWsPg, dto_h_sctr_atencion, estadoWsPg);

                if (rptaWs.Success)
                {
                    //REGISTRAR SEGUIMIENTO ATENCION SCTR
                    m_segatenciones dto_m_segatenciones = new m_segatenciones
                    {
                        PrimaryKey_SQL = Convert.ToInt64(response.ResultData.GetType().GetProperty("cod_seguimiento").GetValue(response.ResultData, null)),
                        cod_ate = Convert.ToInt64(model.pk_pg),
                        obs_ser = "HISTORIA CLINICA SCTR CANCELACION",
                        des_ser = "CTR",
                        Codigo_Usuario_PG = model.usuario_eliminacion_pg
                    };

                    uriWsPg = _appSettings.WsPostgres + "api/m_segatenciones/Add";

                    _webServicePostgres.Consumir(uriWsPg, dto_m_segatenciones, estadoWsPg);
                }
            }

            return ReturnFormattedResponse(response);
        }

        //////////////////          FIN SERVICIO SCTR          //////////////////

        //////////////////          SERVICIO AMBULANCIA          //////////////////

        //By Henrry Torres
        [HttpGet, Route("GetHistoriasClinicasAmbulanciaBandeja")]
        public async Task<IActionResult> GetHistoriasClinicasAmbulanciaBandeja([FromQuery] AmbulanciaResource ambulanciaResource)
        {
            var resultado = await _historiaClinicaService.GetHistoriasClinicasAmbulanciaBandeja(ambulanciaResource);

            var paginacion = JsonConvert.DeserializeObject<TablaPaginacionList>(resultado.ResultData.ToJsonNoFormat());

            var paginationMetadata = new
            {
                totalCount = paginacion.TotalCount,
                pageSize = paginacion.PageSize,
                skip = paginacion.Skip,
                totalPages = paginacion.TotalPages
            };

            Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return ReturnFormattedResponse(resultado);
        }

        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinicaAmbulanciaOrientacionMedica")]
        public async Task<IActionResult> AddHistoriaClinicaAmbulanciaOrientacionMedica(CreateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                id_empresa = model.id_empresa,
                id_persona = model.id_persona,
                CPAR_ID_MOTIVO_CALLMEDICO = model.CPAR_ID_MOTIVO_CALLMEDICO,
                CPAR_ID_REFERENCIA_AMBULANCIA = model.CPAR_ID_REFERENCIA_AMBULANCIA,
                CCEN_ID = model.CCEN_ID,
                CECM_ID = model.CECM_ID,
                CPAR_ID_SOLICITUD = model.CPAR_ID_SOLICITUD,
                estado = model.estado,
                SHIS_CM_ESTADO = model.SHIS_CM_ESTADO,
                NHIS_COD_ESTADO = model.NHIS_COD_ESTADO,
                FHIS_FLG_CM_NUEVA = model.FHIS_FLG_CM_NUEVA,
                NHIS_CM_ORDEN = model.NHIS_CM_ORDEN,
                SHIS_REF_DIR = model.SHIS_REF_DIR,
                SHIS_CM_REF_DIR = model.SHIS_CM_REF_DIR,
                FHIS_FLAG_PROGRAMADA = model.FHIS_FLAG_PROGRAMADA,
                SHIS_F_PROG = model.SHIS_F_PROG,
                SHIS_COD_TIPO_PROG = model.SHIS_COD_TIPO_PROG,
                SHIS_COD_DR_SOLICITADO = model.SHIS_COD_DR_SOLICITADO,
                SHIS_COD_DEP = model.SHIS_COD_DEP,
                FHIS_CM_DIRECTA = model.FHIS_CM_DIRECTA,
                SHIS_FLG_DIRECTO = model.SHIS_FLG_DIRECTO,
                FHIS_CM_DATOS_COMPLETOS = model.FHIS_CM_DATOS_COMPLETOS,
                NHIS_TAR_ATE = model.NHIS_TAR_ATE,
                SHIS_TIPO_SERVAMB_DRMAS = model.SHIS_TIPO_SERVAMB_DRMAS,
                SHIS_COD_AMB_TIPO_SERV = model.SHIS_COD_AMB_TIPO_SERV,
                NHIS_COASEGURO = model.NHIS_COASEGURO,
                SHIS_FLAGMONE = model.SHIS_FLAGMONE,
                NHIS_CAMBIO = model.NHIS_CAMBIO,
                SHIS_FOR_ATE = model.SHIS_FOR_ATE,
                SHIS_CM_MONEDA_DEN = model.SHIS_CM_MONEDA_DEN,
                NHIS_CM_DEN_CAMBIO = model.NHIS_CM_DEN_CAMBIO,
                SHIS_CM_DENOMINACION = model.SHIS_CM_DENOMINACION,
                SHIS_CONTACTO_PAC = model.SHIS_CONTACTO_PAC,
                SHIS_CONTACTO_ASEG = model.SHIS_CONTACTO_ASEG,
                SHIS_TIPO_SERVICIO = model.SHIS_TIPO_SERVICIO,
                NHIS_CLASIFICACION_PAC = model.NHIS_CLASIFICACION_PAC,
                SHIS_TIPO_DOC_PAGO = model.SHIS_TIPO_DOC_PAGO,
                SHIS_DESCRP_ZONA = model.SHIS_DESCRP_ZONA,
                SHIS_COD_EMP = model.SHIS_COD_EMP,
                SHIS_USULLA_ATE = model.SHIS_USULLA_ATE,
                CPAC_ID = model.CPAC_ID,
                CPER_ID = model.CPER_ID,
                CCLI_ID = model.CCLI_ID,
                observacion = model.observacion,
                NHIS_CLASIFICACION_PAC_CALLMED = model.NHIS_CLASIFICACION_PAC_CALLMED,
                SHIS_COD_AUT_PRESTACION = model.SHIS_COD_AUT_PRESTACION,
                SHIS_COD_ASEGURADO = model.SHIS_COD_ASEGURADO,
                SHIS_CM_ASEG_PRODUCTO = model.SHIS_CM_ASEG_PRODUCTO,
                SHIS_POLIZA_ASEGURADO = model.SHIS_POLIZA_ASEGURADO,
                SHIS_POLIZA_CERTIFICADO = model.SHIS_POLIZA_CERTIFICADO,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaAmbulanciaOrientacionMedica(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinicaAmbulancia")]
        public async Task<IActionResult> AddHistoriaClinicaAmbulancia(CreateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                id_empresa = model.id_empresa,
                SHIS_NOM_EMP = model.SHIS_NOM_EMP,
                id_persona = model.id_persona,
                NHIS_EDAD_ATE = model.NHIS_EDAD_ATE,
                SHIS_CEL_PAC = model.SHIS_CEL_PAC,
                SHIS_CM_REF_DIR = model.SHIS_CM_REF_DIR,
                NHIS_COD_TARIFA = model.NHIS_COD_TARIFA,
                SHIS_F_PROG = model.SHIS_F_PROG,
                SHIS_COD_AMB_TIPO_SERV = model.SHIS_COD_AMB_TIPO_SERV,
                FHIS_FLAG_PROGRAMADA = model.FHIS_FLAG_PROGRAMADA,
                DHIS_HOR_ATE = model.DHIS_HOR_ATE,
                SHIS_COD_EMP = model.SHIS_COD_EMP,
                SHIS_AMB_COD_DIS_ORIGEN = model.SHIS_AMB_COD_DIS_ORIGEN,
                SHIS_AMB_DES_DIS_ORIGEN = model.SHIS_AMB_DES_DIS_ORIGEN,
                SHIS_AMB_DIR_ORIGEN = model.SHIS_AMB_DIR_ORIGEN,
                SHIS_AMB_REF_DIR_ORIGEN = model.SHIS_AMB_REF_DIR_ORIGEN,
                DHIS_AMB_FECHA_INI = model.DHIS_AMB_FECHA_INI,
                DHIS_AMB_HORA_INI = model.DHIS_AMB_HORA_INI,
                DHIS_AMB_FECHA_FIN = model.DHIS_AMB_FECHA_FIN,
                DHIS_AMB_HORA_FIN = model.DHIS_AMB_HORA_FIN,
                SHIS_AMB_COD_DIS_DESTINO = model.SHIS_AMB_COD_DIS_DESTINO,
                SHIS_AMB_DES_DIS_DESTINO = model.SHIS_AMB_DES_DIS_DESTINO,
                SHIS_AMB_DIR_DESTINO = model.SHIS_AMB_DIR_DESTINO,
                SHIS_AMB_REF_DIR_DESTINO = model.SHIS_AMB_REF_DIR_DESTINO,
                SHIS_TIPO_SERVICIO = model.SHIS_TIPO_SERVICIO,
                NHIS_COD_PRIORIDAD_CALLMED = model.NHIS_COD_PRIORIDAD_CALLMED,
                NHIS_COD_MOTIVO_ATE_CALLMED = model.NHIS_COD_MOTIVO_ATE_CALLMED,
                NHIS_TAR_ATE = model.NHIS_TAR_ATE,
                NHIS_COASEGURO = model.NHIS_COASEGURO,
                SHIS_TIPO_DOC_PAGO = model.SHIS_TIPO_DOC_PAGO,
                observacion = model.observacion,
                SHIS_CM_DENOMINACION = model.SHIS_CM_DENOMINACION,
                SHIS_FOR_ATE = model.SHIS_FOR_ATE,
                NHIS_ID_TIPO_TRASLADO_CALLMED = model.NHIS_ID_TIPO_TRASLADO_CALLMED,
                SHIS_COD_AUT_PRESTACION = model.SHIS_COD_AUT_PRESTACION,
                SHIS_CONTRATANTE_CITRIX = model.SHIS_CONTRATANTE_CITRIX,
                SHIS_COD_ASEGURADO = model.SHIS_COD_ASEGURADO,
                SHIS_CM_ASEG_PRODUCTO = model.SHIS_CM_ASEG_PRODUCTO,
                SHIS_POLIZA_ASEGURADO = model.SHIS_POLIZA_ASEGURADO,
                SHIS_POLIZA_CERTIFICADO = model.SHIS_POLIZA_CERTIFICADO,
                FHIS_AMB_SERVICIO_PLAYA = model.FHIS_AMB_SERVICIO_PLAYA,
                estado = model.estado,
                SHIS_CM_ESTADO = model.SHIS_CM_ESTADO,
                NHIS_COD_ESTADO = model.NHIS_COD_ESTADO,
                NHIS_CM_ORDEN = model.NHIS_CM_ORDEN,
                FHIS_FLG_CM_NUEVA = model.FHIS_FLG_CM_NUEVA,
                SHIS_COD_TIPO_PROG = model.SHIS_COD_TIPO_PROG,
                SHIS_COD_DR_SOLICITADO = model.SHIS_COD_DR_SOLICITADO,
                FHIS_CM_DIRECTA = model.FHIS_CM_DIRECTA,
                SHIS_FLG_DIRECTO = model.SHIS_FLG_DIRECTO,
                FHIS_CM_DATOS_COMPLETOS = model.FHIS_CM_DATOS_COMPLETOS,
                SHIS_FLAGMONE = model.SHIS_FLAGMONE,
                NHIS_CAMBIO = model.NHIS_CAMBIO,
                SHIS_CM_MONEDA_DEN = model.SHIS_CM_MONEDA_DEN,
                NHIS_CM_DEN_CAMBIO = model.NHIS_CM_DEN_CAMBIO,
                SHIS_CONTACTO_PAC = model.SHIS_CONTACTO_PAC,
                SHIS_CONTACTO_ASEG = model.SHIS_CONTACTO_ASEG,
                NHIS_CLASIFICACION_PAC = model.NHIS_CLASIFICACION_PAC,
                SHIS_DESCRP_ZONA = model.SHIS_DESCRP_ZONA,
                SHIS_USULLA_ATE = model.SHIS_USULLA_ATE,
                NHIS_CLASIFICACION_PAC_CALLMED = model.NHIS_CLASIFICACION_PAC_CALLMED,
                DHIS_FEC_ATE = model.DHIS_FEC_ATE,
                SHIS_TIPO_SERVAMB_DRMAS = model.SHIS_TIPO_SERVAMB_DRMAS,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaAmbulanciaOrientacionMedica(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinicaAmbulanciaEvento")]
        public async Task<IActionResult> AddHistoriaClinicaAmbulanciaEvento(CreateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                id_empresa = model.id_empresa,
                SHIS_NOM_EMP = model.SHIS_NOM_EMP,
                id_persona = model.id_persona,
                NHIS_EDAD_ATE = model.NHIS_EDAD_ATE,
                SHIS_CEL_PAC = model.SHIS_CEL_PAC,
                SHIS_CM_REF_DIR = model.SHIS_CM_REF_DIR,
                NHIS_COD_TARIFA = model.NHIS_COD_TARIFA,
                SHIS_F_PROG = model.SHIS_F_PROG,
                SHIS_COD_AMB_TIPO_SERV = model.SHIS_COD_AMB_TIPO_SERV,
                FHIS_FLAG_PROGRAMADA = model.FHIS_FLAG_PROGRAMADA,//10
                DHIS_HOR_ATE = model.DHIS_HOR_ATE,
                SHIS_COD_EMP = model.SHIS_COD_EMP,
                SHIS_AMB_COD_DIS_ORIGEN = model.SHIS_AMB_COD_DIS_ORIGEN,
                SHIS_AMB_DES_DIS_ORIGEN = model.SHIS_AMB_DES_DIS_ORIGEN,
                SHIS_AMB_DIR_ORIGEN = model.SHIS_AMB_DIR_ORIGEN,
                SHIS_AMB_REF_DIR_ORIGEN = model.SHIS_AMB_REF_DIR_ORIGEN,
                DHIS_AMB_FECHA_INI = model.DHIS_AMB_FECHA_INI,
                DHIS_AMB_HORA_INI = model.DHIS_AMB_HORA_INI,
                DHIS_AMB_FECHA_FIN = model.DHIS_AMB_FECHA_FIN,
                DHIS_AMB_HORA_FIN = model.DHIS_AMB_HORA_FIN,//20
                SHIS_AMB_COD_DIS_DESTINO = model.SHIS_AMB_COD_DIS_DESTINO,
                SHIS_AMB_DES_DIS_DESTINO = model.SHIS_AMB_DES_DIS_DESTINO,
                SHIS_AMB_DIR_DESTINO = model.SHIS_AMB_DIR_DESTINO,
                SHIS_AMB_REF_DIR_DESTINO = model.SHIS_AMB_REF_DIR_DESTINO,
                SHIS_TIPO_SERVICIO = model.SHIS_TIPO_SERVICIO,
                NHIS_COD_PRIORIDAD_CALLMED = model.NHIS_COD_PRIORIDAD_CALLMED,
                NHIS_COD_MOTIVO_ATE_CALLMED = model.NHIS_COD_MOTIVO_ATE_CALLMED,
                NHIS_TAR_ATE = model.NHIS_TAR_ATE,
                NHIS_COASEGURO = model.NHIS_COASEGURO,
                SHIS_TIPO_DOC_PAGO = model.SHIS_TIPO_DOC_PAGO,//30
                observacion = model.observacion,
                SHIS_CM_DENOMINACION = model.SHIS_CM_DENOMINACION,
                SHIS_FOR_ATE = model.SHIS_FOR_ATE,
                NHIS_ID_TIPO_TRASLADO_CALLMED = model.NHIS_ID_TIPO_TRASLADO_CALLMED,
                SHIS_COD_AUT_PRESTACION = model.SHIS_COD_AUT_PRESTACION,
                SHIS_CONTRATANTE_CITRIX = model.SHIS_CONTRATANTE_CITRIX,
                SHIS_COD_ASEGURADO = model.SHIS_COD_ASEGURADO,
                SHIS_CM_ASEG_PRODUCTO = model.SHIS_CM_ASEG_PRODUCTO,
                SHIS_POLIZA_ASEGURADO = model.SHIS_POLIZA_ASEGURADO,
                SHIS_POLIZA_CERTIFICADO = model.SHIS_POLIZA_CERTIFICADO,//40
                FHIS_AMB_SERVICIO_PLAYA = model.FHIS_AMB_SERVICIO_PLAYA,
                estado = model.estado,
                SHIS_CM_ESTADO = model.SHIS_CM_ESTADO,
                NHIS_COD_ESTADO = model.NHIS_COD_ESTADO,
                NHIS_CM_ORDEN = model.NHIS_CM_ORDEN,
                FHIS_FLG_CM_NUEVA = model.FHIS_FLG_CM_NUEVA,
                SHIS_COD_TIPO_PROG = model.SHIS_COD_TIPO_PROG,
                SHIS_COD_DR_SOLICITADO = model.SHIS_COD_DR_SOLICITADO,
                FHIS_CM_DIRECTA = model.FHIS_CM_DIRECTA,
                SHIS_FLG_DIRECTO = model.SHIS_FLG_DIRECTO,//50
                FHIS_CM_DATOS_COMPLETOS = model.FHIS_CM_DATOS_COMPLETOS,
                SHIS_FLAGMONE = model.SHIS_FLAGMONE,
                NHIS_CAMBIO = model.NHIS_CAMBIO,
                SHIS_CM_MONEDA_DEN = model.SHIS_CM_MONEDA_DEN,
                NHIS_CM_DEN_CAMBIO = model.NHIS_CM_DEN_CAMBIO,
                SHIS_CONTACTO_PAC = model.SHIS_CONTACTO_PAC,
                SHIS_CONTACTO_ASEG = model.SHIS_CONTACTO_ASEG,
                NHIS_CLASIFICACION_PAC = model.NHIS_CLASIFICACION_PAC,
                SHIS_DESCRP_ZONA = model.SHIS_DESCRP_ZONA,
                SHIS_USULLA_ATE = model.SHIS_USULLA_ATE,//60
                NHIS_CLASIFICACION_PAC_CALLMED = model.NHIS_CLASIFICACION_PAC_CALLMED,
                DHIS_FEC_ATE = model.DHIS_FEC_ATE,
                SHIS_TIPO_SERVAMB_DRMAS = model.SHIS_TIPO_SERVAMB_DRMAS,
                FHIS_FUERA_COBERTURA = model.FHIS_FUERA_COBERTURA,
                SHIS_DIRECCION_ORIGEN = model.SHIS_DIRECCION_ORIGEN,
                SHIS_DIRECCION_DESTINO = model.SHIS_DIRECCION_DESTINO,
                CCLI_ID_ORIGEN = model.CCLI_ID_ORIGEN,
                CCLI_ID_DESTINO = model.CCLI_ID_DESTINO,
                SHIS_ALERGIA_MEDICA = model.SHIS_ALERGIA_MEDICA,
                SHIS_ATENCEDENTE = model.SHIS_ATENCEDENTE,//70
                CTAM_ID = model.CTAM_ID,
                SHIS_RUC_EVENTO = model.SHIS_RUC_EVENTO,
                SHIS_RAZON_SOCIAL_EVENTO = model.SHIS_RAZON_SOCIAL_EVENTO,
                SHIS_DIRECCION_FISCAL_EVENTO = model.SHIS_DIRECCION_FISCAL_EVENTO,
                CPOL_ID = model.CPOL_ID,
                SHIS_NRO_PLACA = model.SHIS_NRO_PLACA,
                SHIS_NRO_POLIZA = model.SHIS_NRO_POLIZA,
                SHIS_SINIESTRO = model.SHIS_SINIESTRO,
                SHIS_AHUTORIZA_CORTESIA = model.SHIS_AHUTORIZA_CORTESIA,
                SHIS_REGLA_ORO = model.SHIS_REGLA_ORO,//80
                FHIS_AMB_RESPIRATORIA = model.FHIS_AMB_RESPIRATORIA,
                CPAR_ID_SOLICITANTE = model.CPAR_ID_SOLICITANTE,
                SHIS_UBIC_DENTRO_CLINICA_ORIGEN = model.SHIS_UBIC_DENTRO_CLINICA_ORIGEN,
                SHIS_UBIC_DENTRO_CLINICA_DESTINO = model.SHIS_UBIC_DENTRO_CLINICA_DESTINO,
                NPRV_ID = model.NPRV_ID,
                DHIS_FECHA_EVENTO_ADVERSO = model.DHIS_FECHA_EVENTO_ADVERSO,
                CPAR_ID_SOLICITUD = model.CPAR_ID_SOLICITUD,
                FHIS_CITRIX = model.FHIS_CITRIX,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaAmbulanciaEvento(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteHistoriaClinicaAmbulancia")]
        public async Task<IActionResult> DeleteHistoriaClinicaAmbulancia(DeleteHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                cod_historia_clinica = model.cod_historia_clinica,
                id_motivo = model.id_motivo,
                usuario_eliminacion = model.usuario_eliminacion
            };

            var response = await _historiaClinicaService.DeleteHistoriaClinicaAmbulancia(dto);

            return ReturnFormattedResponse(response);
        }

        //////////////////          FIN SERVICIO AMBULANCIA          //////////////////

        #region "Estado 0 - 2 - 3"
        //By Julio Carrera
        [HttpGet, Route("GetHistoriaClinica_Mad_Asignacion_Tiempo_Doctor")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Asignacion_Tiempo_Doctor(int codHistoriaClinica)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Asignacion_Tiempo_Doctor(codHistoriaClinica);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpGet, Route("GetHistoriaClinica_Mad_Asignacion_By_Especialidad")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Asignacion_By_Especialidad(string nombreEspecialidad, int personaId)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Asignacion_By_Especialidad(nombreEspecialidad, personaId);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpGet, Route("GetHistoriaClinica_Mad_Asignacion_By_Medico")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Asignacion_By_Medico(/*string usuario, int clasificacion, int codigoEspecialidad, int personaId,*/ string nombreMedico)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Asignacion_By_Medico(/*usuario, clasificacion, codigoEspecialidad, personaId,*/ nombreMedico);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpGet, Route("GetHistoriaClinica_Mad_Asignacion_Especiliadad_Medico")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Asignacion_Especiliadad_Medico(int codigoMedico, int codigoEspecialidad)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Asignacion_Especiliadad_Medico(codigoMedico, codigoEspecialidad);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpPost, Route("AddHistoriaClinicaMadAuditoriaEstado")]
        public async Task<IActionResult> AddHistoriaClinicaMadAuditoriaEstado(AddHistoriaClinicaMadAuditoriaEstadoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMadAuditoriaEstadoDto dto = new HistoriaClinicaMadAuditoriaEstadoDto
            {
                ESTADO = model.ESTADO,
                USUARIO_CREACION = model.USUARIO_CREACION,
                CAMBIO = model.CAMBIO,
                OBSERVACION = model.OBSERVACION,
                NUMEROHISTORIA = model.NUMEROHISTORIA,
                USUARIO = model.USUARIO
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaMadAuditoriaEstado(dto);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpPut, Route("UpdateHistoriaClinicaMadEstado")]
        public async Task<IActionResult> UpdateHistoriaClinicaMadEstado(UpdateHistoriaClinicaAuditoriaEstado model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMadEstadoDto dto = new HistoriaClinicaMadEstadoDto
            {
                CESP_ID = model.CESP_ID,
                CHIS_ID = model.CHIS_ID,
                CMED_ID = model.CMED_ID,
                DHIS_FECASGDR_ATE = model.DHIS_FECASGDR_ATE,
                DHIS_FEC_ATE = model.DHIS_FEC_ATE,
                DHIS_HORASGDR_ATE = model.DHIS_HORASGDR_ATE,
                DHIS_HOR_ATE = model.DHIS_HOR_ATE,
                FHIS_FLAG_PROGRAMADA = model.FHIS_FLAG_PROGRAMADA,
                FHIS_FLG_VALIDACION_DIRECTA = model.FHIS_FLG_VALIDACION_DIRECTA,
                NHIS_CLASIFICACION_NEG_SOPORTE = model.NHIS_CLASIFICACION_NEG_SOPORTE,
                NHIS_CM_TIEMPO = model.NHIS_CM_TIEMPO,
                NHIS_COD_ESTADO = model.NHIS_COD_ESTADO,
                NHIS_MOTIVO_TIPO_PROG = model.NHIS_MOTIVO_TIPO_PROG,
                NHIS_ORDEN = model.NHIS_ORDEN,
                SHIS_CM_COD_DR_ANTERIOR = model.SHIS_CM_COD_DR_ANTERIOR,
                SHIS_CM_DR_ANTERIOR = model.SHIS_CM_DR_ANTERIOR,
                SHIS_CM_ESP_ANTERIOR = model.SHIS_CM_ESP_ANTERIOR,
                SHIS_CM_ESTADO = model.SHIS_CM_ESTADO,
                SHIS_COD_DR_SOLICITADO = model.SHIS_COD_DR_SOLICITADO,
                SHIS_COD_TIPO_DOCTOR = model.SHIS_COD_TIPO_DOCTOR,
                SHIS_F_PROG = model.SHIS_F_PROG,
                SHIS_F_SOLDOCT = model.SHIS_F_SOLDOCT,
                SHIS_TMP_COD_TIT = model.SHIS_TMP_COD_TIT,
                SHIS_USUASGDR_ATE = model.SHIS_USUASGDR_ATE
            };

            var response = await _historiaClinicaService.UpdateHistoriaClinicaMadEstado(dto);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpGet, Route("GetHistoria_Clinica_Mad_SubTipo_Programacion")]
        public async Task<IActionResult> GetHistoria_Clinica_Mad_SubTipo_Programacion()
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadSubTipoProgramacion();

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpGet, Route("GetHistoria_Clinica_Mad_Tipo_Programacion")]
        public async Task<IActionResult> GetHistoria_Clinica_Mad_Tipo_Programacion()
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadTipoProgramacion();

            return ReturnFormattedResponse(response);
        }
        #endregion

        #region "Estado 3 - 5"
        //By Julio Carrera
        [HttpGet, Route("GetHistoriaClinica_Mad_Validacion_Tiempo")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Validacion_Tiempo(int codigoHistoria)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadValidacionTiempo(codigoHistoria);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpPost, Route("AddHistoriaClinicaAuditoriaEstadoValidacionTiempo")]
        public async Task<IActionResult> AddHistoriaClinicaAuditoriaEstadoValidacionTiempo(AddHistoriaClinicaAuditoriaEstadoValidacionTiempoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaAuditoriaEstadoValidacionTiempoDto dto = new HistoriaClinicaAuditoriaEstadoValidacionTiempoDto
            {
                ESTADO = model.ESTADO,
                USUARIO_CREACION = model.USUARIO_CREACION,
                CAMBIO = model.CAMBIO,
                OBSERVACION = model.OBSERVACION,
                NUMEROHISTORIA = model.NUMEROHISTORIA,
                USUARIO = model.USUARIO
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaAuditoriaEstadoValidacionTiempo(dto);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpPut, Route("UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempo")]
        public async Task<IActionResult> UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempo(UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempoDto dto = new UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempoDto
            {
                dhiS_FECLLEDR = model.dhiS_FECLLEDR,
                dhiS_HRLLEDR = model.dhiS_HRLLEDR,
                fhiS_FLG_CM_NUEVA = model.fhiS_FLG_CM_NUEVA,
                numerO_HISTORIA = model.numerO_HISTORIA,
                shiS_CM_ESTADO = model.shiS_CM_ESTADO
            };

            var response = await _historiaClinicaService.UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempo(dto);

            return ReturnFormattedResponse(response);
        }
        #endregion

        #region "Estado 5 - 6"
        //By Julio Carrera
        [HttpGet, Route("GetHistoriaClinicaMadConfirmarRecepcionMensaje")]
        public async Task<IActionResult> GetHistoriaClinicaMadConfirmarRecepcionMensaje(int numeroHistoria)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadConfirmarRecepcionMensaje(numeroHistoria);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpPost, Route("AddHistoriaClinicaAuditoriaEstadoRecepcionMensaje")]
        public async Task<IActionResult> AddHistoriaClinicaAuditoriaEstadoRecepcionMensaje(AddHistoriaClinicaAuditoriaEstadoRecepcionMensajeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            AddHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto dto = new AddHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto
            {
                estado = model.estado,
                usuariO_CREACION = model.usuariO_CREACION,
                cambio = model.cambio,
                observacion = model.observacion,
                numerohistoria = model.numerohistoria,
                usuario = model.usuario
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaAuditoriaEstadoRecepcionMensaje(dto);

            return ReturnFormattedResponse(response);
        }

        //By Julio Carrera
        [HttpPut, Route("UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensaje")]
        public async Task<IActionResult> UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensaje(UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensajeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto dto = new UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto
            {
                NHIS_CM_ORDEN = model.NHIS_CM_ORDEN,
                NUMERO_HISTORIA = model.NUMERO_HISTORIA,
                SHIS_CM_ESTADO = model.SHIS_CM_ESTADO
            };

            var response = await _historiaClinicaService.UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensaje(dto);

            return ReturnFormattedResponse(response);
        }

        #endregion

        //ESTADO 6 - 7
        //By Henrry Torres
        //6 - 7 (API 1)
        [HttpGet, Route("GetHistoriaClinica_Mad_Confirmar_Llegada_Medico")]
        public async Task<IActionResult> GetHistoriaClinicaMadConfirmarLlegadaMedico(int codigoHistoria)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadConfirmarLlegadaMedico(codigoHistoria);

            return ReturnFormattedResponse(response);
        }

        //6 - 7 (API 2)
        //By Henrry Torres
        [HttpGet, Route("GetHistoriaClinica_Mad_Estado_7")]
        public async Task<IActionResult> GetHistoriaClinicaMadEstado7(int codigoMedico, DateTime fechaLlegada, DateTime horaLlegada)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadEstado7(codigoMedico, fechaLlegada, horaLlegada);

            return ReturnFormattedResponse(response);
        }

        //6 - 7 (API 3)
        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinica_Mad_Auditoria_Confirmar_Llegada_Medico")]
        public async Task<IActionResult> AddHistoriaClinicaMadAuditoriaConfirmarLlegadaMedico(AddHistoriaClinicaAuditoriaConfirmarLlegadaMedicoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMadAuditoriaEstadoDto dto = new HistoriaClinicaMadAuditoriaEstadoDto
            {
                ESTADO = model.estado,
                USUARIO_CREACION = model.usuariO_CREACION,
                CAMBIO = model.cambio,
                OBSERVACION = model.observacion,
                NUMEROHISTORIA = model.numerohistoria,
                USUARIO = model.usuario
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaMadAuditoriaConfirmarLlegadaMedico(dto);

            return ReturnFormattedResponse(response);
        }

        //6 - 7 (API 4)
        //By Henrry Torres
        [HttpPut, Route("UpdateHistoriaClinica_Mad_Auditoria_Confirmar_Llegada_Medico")]
        public async Task<IActionResult> UpdateHistoriaClinicaMadAuditoriaConfirmarLlegadaMedico(UpdateHistoriaClinicaAuditoriaConfirmarLlegadaMedicoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaAuditoriaConfirmarLlegadaMedicoDto dto = new HistoriaClinicaAuditoriaConfirmarLlegadaMedicoDto
            {
                numerohistoria = model.numerohistoria,
                cm_estado = model.cm_estado,
                asig = model.asig,
                orden = model.orden,
                usuoplla_ate = model.usuoplla_ate
            };

            var response = await _historiaClinicaService.UpdateHistoriaClinicaMadAuditoriaConfirmarLlegadaMedico(dto);

            return ReturnFormattedResponse(response);
        }

        //ESTADO 7 - 8
        //By Henrry Torres
        //7 - 8 (API 1)
        [HttpGet, Route("GetHistoriaClinica_Mad_Fin_Consulta_Medica")]
        public async Task<IActionResult> GetHistoriaClinicaMadFinConsultaMedica(int codigoHistoria, int codigoPaciente, int codigoDireccion)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadFinConsultaMedica(codigoHistoria, codigoPaciente, codigoDireccion);

            return ReturnFormattedResponse(response);
        }

        //7 - 8 (API 2)
        //By Henrry Torres
        [HttpPut, Route("UpdateHistoriaClinica_Estado_Mad_Fin_Consulta_Medica")]
        public async Task<IActionResult> UpdateHistoriaClinicaEstadoMadFinConsultaMedica(HistoriaClinicaMadAuditoriaEstadoFinConsultaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMadAuditoriaEstadoFinConsultaDto dto = new HistoriaClinicaMadAuditoriaEstadoFinConsultaDto
            {
                NUMERO_HISTORIA = model.numero_historia,
                FECDIA_ATE = model.fecdia_ate,
                HORDIA_ATE = model.hordia_ate,
                USUDIA_ATE = model.usudia_ate,
                ACCIDE = model.accide,
                ATENCION_REFERENCIAL = model.atencion_referencial
            };

            var response = await _historiaClinicaService.UpdateHistoriaClinicaEstadoMadFinConsultaMedica(dto);

            return ReturnFormattedResponse(response);
        }

        //7 - 8 (API 3)
        //By Henrry Torres
        [HttpPut, Route("UpdateHistoriaClinica_Otros_Servicios_Fin_Consulta_Medica")]
        public async Task<IActionResult> UpdateHistoriaClinicaOtrosServiciosFinConsultaMedica(HistoriaClinicaMadAuditoriaEstadoFinConsultaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMadAuditoriaEstadoFinConsultaDto dto = new HistoriaClinicaMadAuditoriaEstadoFinConsultaDto
            {
                NUMERO_HISTORIA = model.numero_historia,
                FECOPLLA_ATE = model.fecoplla_ate,
                HOROPLLA_ATE = model.horoplla_ate,
                FECDIA_ATE = model.fecdia_ate,
                HORDIA_ATE = model.hordia_ate,
                USUDIA_ATE = model.usudia_ate,
                ACCIDE = model.accide,
                ATENCION_REFERENCIAL = model.atencion_referencial,
            };

            var response = await _historiaClinicaService.UpdateHistoriaClinicaOtrosServiciosFinConsultaMedica(dto);

            return ReturnFormattedResponse(response);
        }

        //7 - 8 (API 4)
        //Aun esta en análisis

        //7 - 8 (API 5)
        //By Henrry Torres
        [HttpDelete, Route("DeleteHistoriaClinica_Otros_Servicios_Fin_Consulta_Medica")]
        public async Task<IActionResult> DeleteHistoriaClinicaOtrosServiciosFinConsultaMedica(HistoriaClinicaMadAuditoriaEstadoFinConsultaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMadAuditoriaEstadoFinConsultaDto dto = new HistoriaClinicaMadAuditoriaEstadoFinConsultaDto
            {
                NUMERO_HISTORIA = model.numero_historia
            };

            var response = await _historiaClinicaService.DeleteHistoriaClinicaOtrosServiciosFinConsultaMedica(dto);

            return ReturnFormattedResponse(response);
        }

        //7 - 8 (API 6)
        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinica_Mad_Estado_Fin_Consulta_Medica")]
        public async Task<IActionResult> AddHistoriaClinicaMadEstadoFinConsultaMedica(HistoriaClinicaEstadoFinConsultaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaEstadoFinConsultaDto dto = new HistoriaClinicaEstadoFinConsultaDto
            {
                CHIS_ID = model.chis_id,
                CHCP_COD_ASO = model.chcp_cod_aso,
                CPAC_ID = model.cpac_id,
                CESP_ID = model.cesp_id,
                CUBI_ID = model.cubi_id,
                CTDO_ID = model.ctdo_id,
                CEMP_ID = model.cemp_id,
                FHCP_EXP = model.fhcp_exp,
                FHCP_EXI_ATE = model.fhcp_exi_ate,
                NHCP_TAR_ATE = model.nhcp_tar_ate,
                NHCP_TAR_ATEOPE = model.nhcp_tar_ateope,
                SHCP_OBS_ATE = model.shcp_obs_ate,
                SHCP_COD_TIPO_DOCTOR = model.shcp_cod_tipo_doctor,
                FHCP_FLGVNR = model.fhcp_flgvnr,
                SHCP_ACCIDE = model.shcp_accide,
                SHCP_FOR_ATE = model.shcp_for_ate,
                SHCP_SIN_ATE = model.shcp_sin_ate,
                SHCP_CODTAR_ATE = model.shcp_codtar_ate,
                SHCP_NTAR_ATE = model.shcp_ntar_ate,
                DHCP_FVENC_ATE = model.dhcp_fvenc_ate,
                DHCP_FECLLA = model.dhcp_feclla,
                DHCP_HORLLA = model.dhcp_horlla,
                DHCP_FECFIN = model.dhcp_fecfin,
                DHCP_HORFIN = model.dhcp_horfin,
                FHCP_YO = model.fhcp_yo,
                SHCP_CANC_ATE = model.shcp_canc_ate,
                SHCP_POLIZA_ASEGURADO = model.shcp_poliza_asegurado,
                SHCP_COD_AUT_PRESTACION = model.shcp_cod_aut_prestacion,
                SHCP_COD_SOLGEN = model.shcp_cod_solgen,
                SHCP_CODAASEG_EPS = model.shcp_codaaseg_eps,
                NHCP_COASEGURO = model.nhcp_coaseguro,
                SHCP_COD_DENOMINACION = model.shcp_cod_denominacion,
                SHCP_F_SERV = model.shcp_f_serv,
                SHCP_CM_ASEG_PRODUCTO = model.shcp_cm_aseg_producto,
                SHCP_TIPO_SERVICIO = model.shcp_tipo_servicio,
                NHCP_USUARIO_CREACION = model.nhcp_usuario_creacion,
                DHCP_FECHA_CREACION = model.dhcp_fecha_creacion,
                NHCP_USUARIO_MODIFICACION = model.nhcp_usuario_modificacion,
                DHCP_FECHA_MODIFICACION = model.dhcp_fecha_modificacion,
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaMadEstadoFinConsultaMedica(dto);

            return ReturnFormattedResponse(response);
        }

        //7 - 8 (API 7)
        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinica_Mad_Auditoria_Estado_Fin_Consulta_Medica")]
        public async Task<IActionResult> AddHistoriaClinicaMadAuditoriaEstadoFinConsultaMedica(AddHistoriaClinicaMadAuditoriaEstadoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMadAuditoriaEstadoDto dto = new HistoriaClinicaMadAuditoriaEstadoDto
            {
                NUMEROHISTORIA = model.NUMEROHISTORIA,
                ESTADO = model.ESTADO,
                USUARIO = model.USUARIO,
                OBSERVACION = model.OBSERVACION,
                CAMBIO = model.CAMBIO,
                USUARIO_CREACION = model.USUARIO_CREACION,
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaMadAuditoriaEstadoFinConsultaMedica(dto);

            return ReturnFormattedResponse(response);
        }

    }
}