using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.Cliente.Implementation
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _uow;

        public ClienteService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetClientes()
        {
            try
            {
                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE");

                List<ClienteDto> listCliente = new List<ClienteDto>();

                listCliente = clientes.Select(c => new ClienteDto { id_cliente = c.CCLT_ID, nombre = c.SCLT_NOMBRE, descripcion = c.SCLT_DESCRIPCION, direccion = c.SCLT_DIRECCION, ubigeo = c.CUBI_UBIGEO, ruc = c.SCLT_RUC, estado = c.FCLT_ESTADO }).ToList();

                if (!clientes.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetConsultaCliente(string vCondicion, string vBusqueda)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCondicion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vCondicion },

                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vBusqueda },
                };


                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE_BY_PARAM", parameters);

                List<ClienteDto> listCliente = new List<ClienteDto>();

                listCliente = clientes.Select(c => new ClienteDto { id_cliente = c.CCLT_ID, nombre = c.SCLT_NOMBRE, descripcion = c.SCLT_DESCRIPCION, direccion = c.SCLT_DIRECCION, ubigeo = c.CUBI_UBIGEO, ruc = c.SCLT_RUC, estado = c.FCLT_ESTADO }).ToList();

                if (!listCliente.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddCliente(MantenimientoClienteDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@FCLT_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@SCLT_NOMBRE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@SCLT_DESCRIPCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.descripcion },
                    new SqlParameter("@SCLT_DIRECCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@SCLT_DISTRITO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.distrito },
                    new SqlParameter("@SCLT_RUC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ruc},
                    new SqlParameter("@NCLT_DSCTO_PED", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.dscto_ped},
                    new SqlParameter("@NCLT_FACTOR_LAB", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.factor_lab},
                    new SqlParameter("@NCLT_DSCTO_LAB", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.dscto_lab},
                    new SqlParameter("@NCLT_COSTO", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.costo},
                    new SqlParameter("@CCLI_CONV_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.conv_emp},
                    new SqlParameter("@NCLT_COSTO_ALT", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.costo_alt},
                    new SqlParameter("@SCLT_FLAG_TIPO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.flag_tipo },
                    new SqlParameter("@FCLT_ACTIVI_OPERACIONES", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activi_operaciones },
                    new SqlParameter("@NCLT_FACTOR_LAB_PROV", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.factor_lab_prov },
                    new SqlParameter("@FCLT_ACTIVO_FACT", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activo_fact },
                    new SqlParameter("@NCLT_RELACIONADO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.relacionado },
                    new SqlParameter("@FCLT_ACTIVO_LAB", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activo_lab },
                    new SqlParameter("@FCLT_ACTIVO_AMB", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activo_amb },
                    new SqlParameter("@FCLT_CLIENTE_PLAYA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.cliente_playa },
                    new SqlParameter("@SCLT_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email },
                    new SqlParameter("@SCLT_URBANIZACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.urbanizacion },
                    new SqlParameter("@NCLT_DIAS_PLAZO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.dias_plazo },
                    new SqlParameter("@SCLT_COD_TIPO_DOC_ID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cod_tipo_doc_id },
                    new SqlParameter("@SCLT_EMAIL_CON_COPIA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email_con_copia },
                    new SqlParameter("@SCLT_PERSONAL_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.personal_contacto },
                    new SqlParameter("@SCLT_TLF_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.tlf_contacto },
                    new SqlParameter("@NCLT_ID_DOC_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_doc_id },
                    new SqlParameter("@FCLT_SAP_FLG_REGISTRADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.sap_flg_registrado },
                    new SqlParameter("@FCLT_ACTIVO_DRONLINE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activo_dronline },
                    new SqlParameter("@FCLT_FLG_CARGAR_BD", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_cargar_bd },
                    new SqlParameter("@SCLT_NOM_ASEG_ONBASE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nom_aseg_onbase },
                    new SqlParameter("@FCLT_VISIBLE_MELCHORITA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.visible_melchorita },
                    new SqlParameter("@FCLT_VISIBLE_CALLMEDICO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.visible_callmedico },
                    new SqlParameter("@NCLT_DIAS_CREDITO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.dias_credito },
                    new SqlParameter("@FCLT_FLG_CAPITADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_capitado },
                    new SqlParameter("@FCLT_VISIBLE_HOME_CARE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.visible_home_care },
                    new SqlParameter("@NCLT_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@DCLI_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@NCLT_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DCLI_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                var response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_CLIENTE", parameters);

                dto.id_cliente = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetClienteByRuc(string ruc)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isRuc", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = ruc },
                };

                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE_BY_RUC", parameters);

                List<ClienteDto> listClientes = new List<ClienteDto>();

                listClientes = clientes.Select(s => new ClienteDto { id_cliente = s.CCLT_ID, nombre = s.SCLT_NOMBRE, descripcion = s.SCLT_DESCRIPCION, direccion = s.SCLT_DIRECCION, ubigeo = s.CUBI_UBIGEO, ruc = s.SCLT_RUC, estado = s.FCLT_ESTADO }).ToList();

                /*if (!listClientes.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listClientes);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetClientesAmbulancia()
        {
            try
            {
                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE_AMBULANCIA");

                List<ClienteDto> listCliente = new List<ClienteDto>();

                listCliente = clientes.Select(c => new ClienteDto { id_cliente = c.CCLT_ID, nombre = c.SCLT_NOMBRE, descripcion = c.SCLT_DESCRIPCION, direccion = c.SCLT_DIRECCION, ubigeo = c.CUBI_UBIGEO, ruc = c.SCLT_RUC, estado = c.FCLT_ESTADO }).ToList();

                if (!clientes.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddClienteSctr(MantenimientoClienteDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SCLT_NOMBRE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@SCLT_RUC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ruc},
                    new SqlParameter("@NCLT_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                //int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_CLIENTE", parameters);
                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_CLIENTE_SCTR", parameters);

                dto.id_cliente = response;

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetClientesSiteds()
        {
            try
            {
                List<DbContext.Entities.ClientesSiteds> clientes = new List<DbContext.Entities.ClientesSiteds>();

                clientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.ClientesSiteds>("SPRMDS_LIST_CLIENTE_SITEDS");

                List<ClienteSitedsDto> listCliente = new List<ClienteSitedsDto>();

                listCliente = clientes.Select(c => new ClienteSitedsDto
                {
                    id_cliente = c.id,
                    codigo_financiamiento = c.codigo_financiamiento,
                    nombre = c.nombre
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

    }
}
