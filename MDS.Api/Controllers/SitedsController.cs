using MDS.Api.Infrastructure;
using MDS.DbContext.Entities;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SitedsController : BaseController
    {
        private readonly IAppSettings _appSettings;

        public SitedsController(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        //By Henrry Torres -> ConsultaAsegNom
        [HttpPost, Route("GetByDni")]
        public async Task<ServiceResponse> GetByDni(Request_Asegurado request)
        {
            string uriWebAPI = _appSettings.Siteds + "ConsultaAsegNom";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_Asegurado dto_Asegurado = new Request_Asegurado
            {
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                RUC = request.RUC,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                NombresAfiliado = "",
                ApellidoPaternoAfiliado = "",
                ApellidoMaternoAfiliado = "",
                CodEspecialidad = request.CodEspecialidad
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody_Asegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_Asegurado.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response_Asegurado = httpClient.Execute(DataFormBody_Asegurado);

                if (response_Asegurado.IsSuccessful)
                {
                    var responseData_Asegurado = response_Asegurado.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<IEnumerable<DatosAfiliado>>(responseData_Asegurado);

                    return ServiceResponse.ReturnResultWith200(dataResult_Asegurado);
                }
                else
                {
                    return ServiceResponse.Return404(response_Asegurado.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres -> ConsultaAsegNom
        [HttpPost, Route("GetByNombresApellidos")]
        public async Task<ServiceResponse> GetByNombresApellidos(Request_Asegurado request)
        {
            string uriWebAPI = _appSettings.Siteds + "ConsultaAsegNom";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_Asegurado dto_Asegurado = new Request_Asegurado
            {
                CodTipoDocumentoAfiliado = "",
                NumeroDocumentoAfiliado = "",
                RUC = request.RUC,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                NombresAfiliado = request.NombresAfiliado.ToUpper(),
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado.ToUpper(),
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado.ToUpper(),
                CodEspecialidad = request.CodEspecialidad
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response = httpClient.Execute(DataFormBody);

                if (response.IsSuccessful)
                {
                    var responseData_Asegurado = response.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<IEnumerable<DatosAfiliado>>(responseData_Asegurado);

                    return ServiceResponse.ReturnResultWith200(dataResult_Asegurado);
                }
                else
                {
                    return ServiceResponse.Return404(response.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres -> ConsultaAsegCod
        [HttpPost, Route("TestGetByCodigo")]
        public async Task<ServiceResponse> TestGetByCodigo(Request_Asegurado request)
        {
            //PARTE ConsultaAsegNom
            string uriWebAPI = _appSettings.Siteds + "ConsultaAsegNom";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_Asegurado dto_Asegurado = new Request_Asegurado
            {
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                RUC = request.RUC,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                NombresAfiliado = request.NombresAfiliado,
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado,
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado,
                CodEspecialidad = request.CodEspecialidad
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody_Asegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_Asegurado.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response = httpClient.Execute(DataFormBody_Asegurado);

                if (response.IsSuccessful)
                {
                    var responseData_Asegurado = response.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<IEnumerable<DatosAfiliado>>(responseData_Asegurado);

                    var CodTipoDocumentoAfiliado = "";
                    var NumeroDocumentoAfiliado = "";
                    var NombresAfiliado = "";
                    var ApellidoPaternoAfiliado = "";
                    var ApellidoMaternoAfiliado = "";
                    var CodigoAfiliado = "";
                    var CodProducto = "";
                    var DesProducto = "";
                    var NumeroPlan = "";
                    var CodTipoDocumentoContratante = "";
                    var NumeroDocumentoContratante = "";
                    var NombreContratante = "";
                    var CodParentesco = "";
                    var TipoCalificadorContratante = "";

                    foreach (var item in dataResult_Asegurado)
                    {
                        CodTipoDocumentoAfiliado = item.CodTipoDocumentoAfiliado;
                        NumeroDocumentoAfiliado = item.NumeroDocumentoAfiliado;
                        NombresAfiliado = item.NombresAfiliado;
                        ApellidoPaternoAfiliado = item.ApellidoPaternoAfiliado;
                        ApellidoMaternoAfiliado = item.ApellidoMaternoAfiliado;
                        CodigoAfiliado = item.CodigoAfiliado;
                        CodProducto = item.CodProducto;
                        DesProducto = item.DesProducto;
                        NumeroPlan = item.NumeroPlan;
                        CodTipoDocumentoContratante = item.CodTipoDocumentoContratante;
                        NumeroDocumentoContratante = item.NumeroDocumentoContratante;
                        NombreContratante = item.NombreContratante;
                        CodParentesco = item.CodParentesco;
                        TipoCalificadorContratante = item.TipoCalificadorContratante;
                    }

                    //PARTE ConsultaAsegCod
                    uriWebAPI = _appSettings.Siteds + "ConsultaAsegCod";

                    setting = new RestClientOptions(uriWebAPI)
                    {
                        MaxTimeout = 400000
                    };

                    httpClient = new RestClient(setting);

                    Request_AsegCod_Obs_DatAdic_CondMed dto_CodigoAsegurado = new Request_AsegCod_Obs_DatAdic_CondMed
                    {
                        SUNASA = request.SUNASA,
                        IAFAS = request.IAFAS,
                        RUC = request.RUC,
                        CodEspecialidad = request.CodEspecialidad,
                        NombresAfiliado = NombresAfiliado,
                        ApellidoPaternoAfiliado = ApellidoPaternoAfiliado,
                        ApellidoMaternoAfiliado = ApellidoMaternoAfiliado,
                        CodigoAfiliado = CodigoAfiliado,
                        CodTipoDocumentoAfiliado = CodTipoDocumentoAfiliado,
                        NumeroDocumentoAfiliado = NumeroDocumentoAfiliado,
                        CodProducto = CodProducto,
                        DesProducto = DesProducto,
                        NumeroPlan = NumeroPlan,
                        CodTipoDocumentoContratante = CodTipoDocumentoContratante,
                        NumeroDocumentoContratante = NumeroDocumentoContratante,
                        NombreContratante = NombreContratante,
                        CodParentesco = CodParentesco,
                        TipoCalificadorContratante = TipoCalificadorContratante
                    };

                    try
                    {
                        string dataJSON_CodigoAsegurado = JsonConvert.SerializeObject(dto_CodigoAsegurado);

                        var DataFormBody_CodigoAsegurado = new RestRequest(uriWebAPI, Method.Post);
                        DataFormBody_CodigoAsegurado.AddParameter("application/json", dataJSON_CodigoAsegurado, ParameterType.RequestBody);

                        RestResponse response_CodigoAsegurado = httpClient.Execute(DataFormBody_CodigoAsegurado);

                        if (response_CodigoAsegurado.IsSuccessful)
                        {
                            var responseData_CodigoAsegurado = response_CodigoAsegurado.Content;

                            var dataResult_CodigoAsegurado = JsonConvert.DeserializeObject<Response_Siteds>(responseData_CodigoAsegurado);

                            return ServiceResponse.ReturnResultWith200(dataResult_CodigoAsegurado);
                        }
                        else
                        {
                            return ServiceResponse.Return404(response_CodigoAsegurado.Content);
                        }
                    }
                    catch (Exception e)
                    {
                        return ServiceResponse.Return500(e);
                    }
                }
                else
                {
                    return ServiceResponse.Return404(response.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

        //By Henrry Torres -> ConsultaAsegCod
        [HttpPost, Route("GetByCodigo")]
        public async Task<ServiceResponse> GetByCodigo(Request_AsegCod_Obs_DatAdic_CondMed request)
        {
            //PARTE ConsultaAsegCod
            var uriWebAPI = _appSettings.Siteds + "ConsultaAsegCod";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_AsegCod_Obs_DatAdic_CondMed dto_CodigoAsegurado = new Request_AsegCod_Obs_DatAdic_CondMed
            {
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                RUC = request.RUC,
                CodEspecialidad = request.CodEspecialidad,
                NombresAfiliado = request.NombresAfiliado,
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado,
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado,
                CodigoAfiliado = request.CodigoAfiliado,
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                CodProducto = request.CodProducto,
                DesProducto = request.DesProducto,
                NumeroPlan = request.NumeroPlan,
                CodTipoDocumentoContratante = request.CodTipoDocumentoContratante,
                NumeroDocumentoContratante = request.NumeroDocumentoContratante,
                NombreContratante = request.NombreContratante,
                CodParentesco = request.CodParentesco,
                TipoCalificadorContratante = request.TipoCalificadorContratante
            };

            try
            {
                string dataJSON_CodigoAsegurado = JsonConvert.SerializeObject(dto_CodigoAsegurado);

                var DataFormBody_CodigoAsegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_CodigoAsegurado.AddParameter("application/json", dataJSON_CodigoAsegurado, ParameterType.RequestBody);

                RestResponse response_CodigoAsegurado = httpClient.Execute(DataFormBody_CodigoAsegurado);

                if (response_CodigoAsegurado.IsSuccessful)
                {
                    var responseData_CodigoAsegurado = response_CodigoAsegurado.Content;

                    var dataResult_CodigoAsegurado = JsonConvert.DeserializeObject<Response_Siteds>(responseData_CodigoAsegurado);

                    return ServiceResponse.ReturnResultWith200(dataResult_CodigoAsegurado);
                }
                else
                {
                    return ServiceResponse.Return404(response_CodigoAsegurado.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

        //By Henrry Torres -> ConsultaObservacion
        [HttpPost, Route("GetObservacion")]
        public async Task<ServiceResponse> GetObservacion(Request_Asegurado request)
        {
            //PARTE ConsultaAsegNom
            string uriWebAPI = _appSettings.Siteds + "ConsultaAsegNom";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_Asegurado dto_Asegurado = new Request_Asegurado
            {
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                RUC = request.RUC,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                NombresAfiliado = request.NombresAfiliado,
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado,
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado,
                CodEspecialidad = request.CodEspecialidad
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody_Asegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_Asegurado.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response_Asegurado = httpClient.Execute(DataFormBody_Asegurado);

                if (response_Asegurado.IsSuccessful)
                {
                    var responseData_Asegurado = response_Asegurado.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<IEnumerable<DatosAfiliado>>(responseData_Asegurado);

                    var CodTipoDocumentoAfiliado = "";
                    var NumeroDocumentoAfiliado = "";
                    var NombresAfiliado = "";
                    var ApellidoPaternoAfiliado = "";
                    var ApellidoMaternoAfiliado = "";
                    var CodigoAfiliado = "";
                    var CodProducto = "";
                    var DesProducto = "";
                    var NumeroPlan = "";
                    var CodTipoDocumentoContratante = "";
                    var NumeroDocumentoContratante = "";
                    var NombreContratante = "";
                    var CodParentesco = "";
                    var TipoCalificadorContratante = "";

                    foreach (var item in dataResult_Asegurado)
                    {
                        CodTipoDocumentoAfiliado = item.CodTipoDocumentoAfiliado;
                        NumeroDocumentoAfiliado = item.NumeroDocumentoAfiliado;
                        NombresAfiliado = item.NombresAfiliado;
                        ApellidoPaternoAfiliado = item.ApellidoPaternoAfiliado;
                        ApellidoMaternoAfiliado = item.ApellidoMaternoAfiliado;
                        CodigoAfiliado = item.CodigoAfiliado;
                        CodProducto = item.CodProducto;
                        DesProducto = item.DesProducto;
                        NumeroPlan = item.NumeroPlan;
                        CodTipoDocumentoContratante = item.CodTipoDocumentoContratante;
                        NumeroDocumentoContratante = item.NumeroDocumentoContratante;
                        NombreContratante = item.NombreContratante;
                        CodParentesco = item.CodParentesco;
                        TipoCalificadorContratante = item.TipoCalificadorContratante;
                    }

                    //PARTE ConsultaObservacion
                    uriWebAPI = _appSettings.Siteds + "ConsultaObservacion";

                    setting = new RestClientOptions(uriWebAPI)
                    {
                        MaxTimeout = 400000
                    };

                    httpClient = new RestClient(setting);

                    Request_AsegCod_Obs_DatAdic_CondMed dto_Observacion = new Request_AsegCod_Obs_DatAdic_CondMed
                    {
                        SUNASA = request.SUNASA,
                        IAFAS = request.IAFAS,
                        RUC = request.RUC,
                        NombresAfiliado = NombresAfiliado,
                        ApellidoPaternoAfiliado = ApellidoPaternoAfiliado,
                        ApellidoMaternoAfiliado = ApellidoMaternoAfiliado,
                        CodigoAfiliado = CodigoAfiliado,
                        CodTipoDocumentoAfiliado = CodTipoDocumentoAfiliado,
                        NumeroDocumentoAfiliado = NumeroDocumentoAfiliado,
                        CodProducto = CodProducto,
                        DesProducto = DesProducto,
                        NumeroPlan = NumeroPlan,
                        CodTipoDocumentoContratante = CodTipoDocumentoContratante,
                        NumeroDocumentoContratante = NumeroDocumentoContratante,
                        NombreContratante = NombreContratante,
                        CodParentesco = CodParentesco,
                        TipoCalificadorContratante = TipoCalificadorContratante,
                        CodEspecialidad = request.CodEspecialidad
                    };

                    try
                    {
                        string dataJSON_Observacion = JsonConvert.SerializeObject(dto_Observacion);

                        var DataFormBody_Observacion = new RestRequest(uriWebAPI, Method.Post);
                        DataFormBody_Observacion.AddParameter("application/json", dataJSON_Observacion, ParameterType.RequestBody);

                        RestResponse response_Observacion = httpClient.Execute(DataFormBody_Observacion);

                        if (response_Observacion.IsSuccessful)
                        {
                            var responseData_Observacion = response_Observacion.Content;

                            var dataResult_Observacion = JsonConvert.DeserializeObject<Response_observaciones>(responseData_Observacion);

                            return ServiceResponse.ReturnResultWith200(dataResult_Observacion);
                        }
                        else
                        {
                            return ServiceResponse.Return404(response_Observacion.Content);
                        }
                    }
                    catch (Exception e)
                    {
                        return ServiceResponse.Return500(e);
                    }
                }
                else
                {
                    return ServiceResponse.Return404(response_Asegurado.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

        //By Henrry Torres -> ObtenerNumeroAutorizacion
        [HttpPost, Route("TestNumeroAutorizacion")]
        public async Task<ServiceResponse> TestNumeroAutorizacion(Request_Asegurado request)
        {
            //PARTE ConsultaAsegNom
            string uriWebAPI = _appSettings.Siteds + "ConsultaAsegNom";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_Asegurado dto_Asegurado = new Request_Asegurado
            {
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                RUC = request.RUC,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                NombresAfiliado = request.NombresAfiliado,
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado,
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado,
                CodEspecialidad = request.CodEspecialidad
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody_Asegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_Asegurado.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response_Asegurado = httpClient.Execute(DataFormBody_Asegurado);

                if (response_Asegurado.IsSuccessful)
                {
                    var responseData_Asegurado = response_Asegurado.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<IEnumerable<DatosAfiliado>>(responseData_Asegurado);

                    var CodTipoDocumentoAfiliado = "";
                    var NumeroDocumentoAfiliado = "";
                    var NombresAfiliado = "";
                    var ApellidoPaternoAfiliado = "";
                    var ApellidoMaternoAfiliado = "";
                    var CodigoAfiliado = "";
                    var CodProducto = "";
                    var DesProducto = "";
                    var NumeroPlan = "";
                    var CodTipoDocumentoContratante = "";
                    var NumeroDocumentoContratante = "";
                    var NombreContratante = "";
                    var CodParentesco = "";
                    var TipoCalificadorContratante = "";
                    var CodEstado = "";
                    var CodGenero = "";
                    var SUNASA = "";
                    var IAFAS = "";
                    var RUC = "";
                    var CodEspecialidad = "";
                    var CodEstadoCivil = "";
                    var NumeroSCTR = "";

                    foreach (var item in dataResult_Asegurado)
                    {
                        CodTipoDocumentoAfiliado = item.CodTipoDocumentoAfiliado;
                        NumeroDocumentoAfiliado = item.NumeroDocumentoAfiliado;
                        NombresAfiliado = item.NombresAfiliado;
                        ApellidoPaternoAfiliado = item.ApellidoPaternoAfiliado;
                        ApellidoMaternoAfiliado = item.ApellidoMaternoAfiliado;
                        CodigoAfiliado = item.CodigoAfiliado;
                        CodProducto = item.CodProducto;
                        DesProducto = item.DesProducto;
                        NumeroPlan = item.NumeroPlan;
                        CodTipoDocumentoContratante = item.CodTipoDocumentoContratante;
                        NumeroDocumentoContratante = item.NumeroDocumentoContratante;
                        NombreContratante = item.NombreContratante;
                        CodParentesco = item.CodParentesco;
                        TipoCalificadorContratante = item.TipoCalificadorContratante;
                        CodEstado = item.CodEstado;
                        CodGenero = item.CodGenero;
                        CodEstadoCivil = item.CodEstadoCivil;
                        SUNASA = request.SUNASA;
                        IAFAS = request.IAFAS;
                        RUC = request.RUC;
                        CodEspecialidad = request.CodEspecialidad;
                        NumeroSCTR = item.NumeroSCTR;
                    }

                    //PARTE ConsultaAsegCod
                    uriWebAPI = _appSettings.Siteds + "ConsultaAsegCod";

                    setting = new RestClientOptions(uriWebAPI)
                    {
                        MaxTimeout = 400000
                    };

                    httpClient = new RestClient(setting);

                    Request_AsegCod_Obs_DatAdic_CondMed dto_Codigo = new Request_AsegCod_Obs_DatAdic_CondMed
                    {
                        SUNASA = request.SUNASA,
                        IAFAS = request.IAFAS,
                        RUC = request.RUC,
                        NombresAfiliado = NombresAfiliado,
                        ApellidoPaternoAfiliado = ApellidoPaternoAfiliado,
                        ApellidoMaternoAfiliado = ApellidoMaternoAfiliado,
                        CodigoAfiliado = CodigoAfiliado,
                        CodTipoDocumentoAfiliado = CodTipoDocumentoAfiliado,
                        NumeroDocumentoAfiliado = NumeroDocumentoAfiliado,
                        CodProducto = CodProducto,
                        DesProducto = DesProducto,
                        NumeroPlan = NumeroPlan,
                        CodTipoDocumentoContratante = CodTipoDocumentoContratante,
                        NumeroDocumentoContratante = NumeroDocumentoContratante,
                        NombreContratante = NombreContratante,
                        CodParentesco = CodParentesco,
                        TipoCalificadorContratante = TipoCalificadorContratante,
                        CodEspecialidad = request.CodEspecialidad
                    };

                    try
                    {
                        string dataJSON_Codigo = JsonConvert.SerializeObject(dto_Codigo);

                        var DataFormBody_Codigo = new RestRequest(uriWebAPI, Method.Post);
                        DataFormBody_Codigo.AddParameter("application/json", dataJSON_Codigo, ParameterType.RequestBody);

                        RestResponse response_Codigo = httpClient.Execute(DataFormBody_Codigo);

                        if (response_Codigo.IsSuccessful)
                        {
                            var responseData_Codigo = response_Codigo.Content;

                            var dataResult_Codigo = JsonConvert.DeserializeObject<Response_Siteds>(responseData_Codigo);

                            var BeneficioMaximoInicial = "";
                            var CodCalificacionServicio = "";
                            var CodCopagoFijo = "";
                            var CodCopagoVariable = "";
                            var CodFechaFinCarencia = "";
                            var CondicionesEspeciales = "";
                            var CodIndicadorRestriccion = "";
                            var CodigoSubTipoCobertura = "";
                            var CodigoTipoCobertura = "";
                            var CodTipoMoneda = "";
                            var DesTipoMoneda = "";
                            var CodigoTitular = "";
                            var CodTipoAfiliacion = "";
                            var CodFechaAfiliacion = "";
                            var CodFechaInicioVigencia = "";
                            var CodFechaNacimiento = "";
                            var ApellidoMaternoTitular = "";
                            var ApellidoPaternoTitular = "";
                            var NombresTitular = "";
                            var NumeroCertificado = "";
                            var NumeroContrato = "";
                            var NumeroDocumentoTitular = "";
                            var NumeroPoliza = "";
                            var CodTipoDocumentoTitular = "";
                            var CodTipoPlan = "";

                            CodigoTitular = dataResult_Codigo.DatosAfiliado.CodigoTitular;
                            CodTipoAfiliacion = dataResult_Codigo.DatosAfiliado.CodTipoAfiliacion;
                            CodFechaAfiliacion = dataResult_Codigo.DatosAfiliado.CodFechaAfiliacion;
                            CodFechaInicioVigencia = dataResult_Codigo.DatosAfiliado.CodFechaInicioVigencia;
                            CodFechaNacimiento = dataResult_Codigo.DatosAfiliado.CodFechaNacimiento;
                            ApellidoPaternoTitular = dataResult_Codigo.DatosAfiliado.ApellidoPaternoTitular;
                            NombresTitular = dataResult_Codigo.DatosAfiliado.NombresTitular;
                            NumeroCertificado = dataResult_Codigo.DatosAfiliado.NumeroCertificado;
                            NumeroContrato = dataResult_Codigo.DatosAfiliado.NumeroContrato;
                            NumeroDocumentoTitular = dataResult_Codigo.DatosAfiliado.NumeroDocumentoTitular;
                            NumeroPoliza = dataResult_Codigo.DatosAfiliado.NumeroPoliza;
                            CodTipoDocumentoTitular = dataResult_Codigo.DatosAfiliado.CodTipoDocumentoTitular;
                            CodTipoPlan = dataResult_Codigo.DatosAfiliado.CodTipoPlan;
                            ApellidoMaternoTitular = dataResult_Codigo.DatosAfiliado.ApellidoMaternoTitular;

                            foreach (var item in dataResult_Codigo.Coberturas)
                            {
                                BeneficioMaximoInicial = item.BeneficioMaximoInicial;
                                CodCalificacionServicio = item.CodCalificacionServicio;
                                CodCopagoFijo = item.CodCopagoFijo;
                                CodCopagoVariable = item.CodCopagoVariable;
                                CodFechaFinCarencia = item.CodFechaFinCarencia;
                                CondicionesEspeciales = item.CondicionesEspeciales;
                                CodIndicadorRestriccion = item.CodIndicadorRestriccion;
                                CodigoSubTipoCobertura = item.CodigoSubTipoCobertura;
                                CodTipoMoneda = item.CodTipoMoneda;
                                DesTipoMoneda = item.DesTipoMoneda;
                                CodigoTipoCobertura = item.CodigoTipoCobertura;
                                break;
                            }

                            //PARTE ConsultaNumeroAutorizacion
                            uriWebAPI = _appSettings.Siteds + "ConsultaNumeroAutorizacion";

                            setting = new RestClientOptions(uriWebAPI)
                            {
                                MaxTimeout = 400000
                            };

                            httpClient = new RestClient(setting);

                            Request_NumeroAutorizacion dto_NumeroAutorizacion = new Request_NumeroAutorizacion
                            {
                                ApellidoMaternoAfiliado = ApellidoMaternoAfiliado,
                                ApellidoPaternoAfiliado = ApellidoPaternoAfiliado,
                                BeneficioMaximoInicial = BeneficioMaximoInicial,
                                CodigoAfiliado = CodigoAfiliado,
                                CodigoTitular = CodigoTitular,
                                CodCalificacionServicio = CodCalificacionServicio,
                                CodEstado = CodEstado,
                                CodEspecialidad = CodEspecialidad,
                                CodMoneda = CodTipoMoneda,
                                CodCopagoFijo = CodCopagoFijo,
                                CodCopagoVariable = CodCopagoVariable,
                                CodParentesco = CodParentesco,
                                CodProducto = CodProducto,
                                NumeroDocumentoContratante = NumeroDocumentoContratante,
                                CodSubTipoCobertura = CodigoSubTipoCobertura,
                                CodTipoCobertura = CodigoTipoCobertura,
                                CodTipoAfiliacion = CodTipoAfiliacion,
                                DesProducto = DesProducto,
                                CodEstadoMarital = CodEstadoCivil,
                                CodFechaFinCarencia = CodFechaFinCarencia,
                                CodFechaAfiliacion = CodFechaAfiliacion,
                                CodFechaInicioVigencia = CodFechaInicioVigencia,
                                CodFechaNacimiento = CodFechaNacimiento,
                                CodGenero = CodGenero,
                                SUNASA = SUNASA,
                                IAFAS = IAFAS,
                                CondicionesEspeciales = CondicionesEspeciales,
                                ApellidoMaternoTitular = ApellidoMaternoTitular,
                                NombreContratante = NombreContratante,
                                ApellidoPaternoTitular = ApellidoPaternoTitular,
                                NombresAfiliado = NombresAfiliado,
                                NombresTitular = NombresTitular,
                                NumeroCertificado = NumeroCertificado,
                                NumeroContrato = NumeroContrato,
                                NumeroDocumentoAfiliado = NumeroDocumentoAfiliado,
                                NumeroDocumentoTitular = NumeroDocumentoTitular,
                                NumeroPlan = NumeroPlan,
                                NumeroPoliza = NumeroPoliza,
                                RUC = RUC,
                                CodTipoDocumentoContratante = CodTipoDocumentoContratante,
                                CodTipoDocumentoAfiliado = CodTipoDocumentoAfiliado,
                                CodTipoDocumentoTitular = CodTipoDocumentoTitular,
                                CodTipoPlan = CodTipoPlan,
                                CodIndicadorRestriccion = CodIndicadorRestriccion
                            };

                            try
                            {
                                string dataJSON_NumeroAutorizacion = JsonConvert.SerializeObject(dto_NumeroAutorizacion);

                                var DataFormBody_NumeroAutorizacion = new RestRequest(uriWebAPI, Method.Post);
                                DataFormBody_NumeroAutorizacion.AddParameter("application/json", dataJSON_NumeroAutorizacion, ParameterType.RequestBody);

                                RestResponse response_NumeroAutorizacion = httpClient.Execute(DataFormBody_NumeroAutorizacion);

                                if (response_NumeroAutorizacion.IsSuccessful)
                                {
                                    var responseData_NumeroAutorizacion = response_NumeroAutorizacion.Content;

                                    var dataResult_NumeroAutorizacion = JsonConvert.DeserializeObject<Response_cod_autorizacion>(responseData_NumeroAutorizacion);

                                    return ServiceResponse.ReturnResultWith200(dataResult_NumeroAutorizacion);
                                }
                                else
                                {
                                    return ServiceResponse.Return404(response_NumeroAutorizacion.Content);
                                }
                            }
                            catch (Exception e)
                            {
                                return ServiceResponse.Return500(e);
                            }
                        }
                        else
                        {
                            return ServiceResponse.Return404(response_Codigo.Content);
                        }
                    }
                    catch (Exception e)
                    {
                        return ServiceResponse.Return500(e);
                    }
                }
                else
                {
                    return ServiceResponse.Return404(response_Asegurado.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

        //By Henrry Torres -> ObtenerNumeroAutorizacion
        [HttpPost, Route("GetNumeroAutorizacion")]
        public async Task<ServiceResponse> GetNumeroAutorizacion(Request_NumeroAutorizacion request)
        {
            //PARTE ConsultaNumeroAutorizacion
            var uriWebAPI = _appSettings.Siteds + "ConsultaNumeroAutorizacion";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_NumeroAutorizacion dto_NumeroAutorizacion = new Request_NumeroAutorizacion
            {
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado,
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado,
                BeneficioMaximoInicial = request.BeneficioMaximoInicial,
                CodigoAfiliado = request.CodigoAfiliado,
                CodigoTitular = request.CodigoTitular,
                CodCalificacionServicio = request.CodCalificacionServicio,
                CodEstado = request.CodEstado,
                CodEspecialidad = request.CodEspecialidad,
                CodCopagoFijo = request.CodCopagoFijo,
                CodCopagoVariable = request.CodCopagoVariable,
                CodParentesco = request.CodParentesco,
                CodProducto = request.CodProducto,
                NumeroDocumentoContratante = request.NumeroDocumentoContratante,
                CodTipoAfiliacion = request.CodTipoAfiliacion,
                DesProducto = request.DesProducto,
                CodFechaFinCarencia = request.CodFechaFinCarencia,
                CodFechaAfiliacion = request.CodFechaAfiliacion,
                CodFechaInicioVigencia = request.CodFechaInicioVigencia,
                CodFechaNacimiento = request.CodFechaNacimiento,
                CodGenero = request.CodGenero,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                CondicionesEspeciales = request.CondicionesEspeciales,
                ApellidoMaternoTitular = request.ApellidoMaternoTitular,
                NombreContratante = request.NombreContratante,
                ApellidoPaternoTitular = request.ApellidoPaternoTitular,
                NombresAfiliado = request.NombresAfiliado,
                NombresTitular = request.NombresTitular,
                NumeroCertificado = request.NumeroCertificado,
                NumeroContrato = request.NumeroContrato,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                NumeroDocumentoTitular = request.NumeroDocumentoTitular,
                NumeroPlan = request.NumeroPlan,
                NumeroPoliza = request.NumeroPoliza,
                RUC = request.RUC,
                CodTipoDocumentoContratante = request.CodTipoDocumentoContratante,
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                CodTipoDocumentoTitular = request.CodTipoDocumentoTitular,
                CodTipoPlan = request.CodTipoPlan,
                CodIndicadorRestriccion = request.CodIndicadorRestriccion,
                CodMoneda = request.CodMoneda,
                CodSubTipoCobertura = request.CodSubTipoCobertura,
                CodTipoCobertura = request.CodTipoCobertura,
                CodEstadoMarital = request.CodEstadoMarital
            };

            try
            {
                string dataJSON_NumeroAutorizacion = JsonConvert.SerializeObject(dto_NumeroAutorizacion);

                var DataFormBody_NumeroAutorizacion = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_NumeroAutorizacion.AddParameter("application/json", dataJSON_NumeroAutorizacion, ParameterType.RequestBody);

                RestResponse response_NumeroAutorizacion = httpClient.Execute(DataFormBody_NumeroAutorizacion);

                if (response_NumeroAutorizacion.IsSuccessful)
                {
                    var responseData_NumeroAutorizacion = response_NumeroAutorizacion.Content;

                    var dataResult_NumeroAutorizacion = JsonConvert.DeserializeObject<Response_cod_autorizacion>(responseData_NumeroAutorizacion);

                    return ServiceResponse.ReturnResultWith200(dataResult_NumeroAutorizacion);
                }
                else
                {
                    return ServiceResponse.Return404(response_NumeroAutorizacion.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

        //By Henrry Torres -> ConsultaDatosAdicionales
        [HttpPost, Route("GetDatosAdicionales")]
        public async Task<ServiceResponse> GetDatosAdicionales(Request_Asegurado request)
        {
            //PARTE ConsultaAsegNom
            string uriWebAPI = _appSettings.Siteds + "ConsultaAsegNom";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_Asegurado dto_Asegurado = new Request_Asegurado
            {
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                RUC = request.RUC,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                NombresAfiliado = request.NombresAfiliado,
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado,
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado,
                CodEspecialidad = request.CodEspecialidad
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody_Asegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_Asegurado.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response_Asegurado = httpClient.Execute(DataFormBody_Asegurado);

                if (response_Asegurado.IsSuccessful)
                {
                    var responseData_Asegurado = response_Asegurado.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<IEnumerable<DatosAfiliado>>(responseData_Asegurado);

                    var CodTipoDocumentoAfiliado = "";
                    var NumeroDocumentoAfiliado = "";
                    var NombresAfiliado = "";
                    var ApellidoPaternoAfiliado = "";
                    var ApellidoMaternoAfiliado = "";
                    var CodigoAfiliado = "";
                    var CodProducto = "";
                    var DesProducto = "";
                    var NumeroPlan = "";
                    var CodTipoDocumentoContratante = "";
                    var NumeroDocumentoContratante = "";
                    var NombreContratante = "";
                    var CodParentesco = "";
                    var TipoCalificadorContratante = "";

                    foreach (var item in dataResult_Asegurado)
                    {
                        CodTipoDocumentoAfiliado = item.CodTipoDocumentoAfiliado;
                        NumeroDocumentoAfiliado = item.NumeroDocumentoAfiliado;
                        NombresAfiliado = item.NombresAfiliado;
                        ApellidoPaternoAfiliado = item.ApellidoPaternoAfiliado;
                        ApellidoMaternoAfiliado = item.ApellidoMaternoAfiliado;
                        CodigoAfiliado = item.CodigoAfiliado;
                        CodProducto = item.CodProducto;
                        DesProducto = item.DesProducto;
                        NumeroPlan = item.NumeroPlan;
                        CodTipoDocumentoContratante = item.CodTipoDocumentoContratante;
                        NumeroDocumentoContratante = item.NumeroDocumentoContratante;
                        NombreContratante = item.NombreContratante;
                        CodParentesco = item.CodParentesco;
                        TipoCalificadorContratante = item.TipoCalificadorContratante;
                    }

                    //PARTE ConsultaObservacion
                    uriWebAPI = _appSettings.Siteds + "ConsultaDatosAdicionales";

                    setting = new RestClientOptions(uriWebAPI)
                    {
                        MaxTimeout = 400000
                    };

                    httpClient = new RestClient(setting);

                    Request_AsegCod_Obs_DatAdic_CondMed dto_DatosAdicionales = new Request_AsegCod_Obs_DatAdic_CondMed
                    {
                        SUNASA = request.SUNASA,
                        IAFAS = request.IAFAS,
                        RUC = request.RUC,
                        NombresAfiliado = NombresAfiliado,
                        ApellidoPaternoAfiliado = ApellidoPaternoAfiliado,
                        ApellidoMaternoAfiliado = ApellidoMaternoAfiliado,
                        CodigoAfiliado = CodigoAfiliado,
                        CodTipoDocumentoAfiliado = CodTipoDocumentoAfiliado,
                        NumeroDocumentoAfiliado = NumeroDocumentoAfiliado,
                        CodProducto = CodProducto,
                        DesProducto = DesProducto,
                        NumeroPlan = NumeroPlan,
                        CodTipoDocumentoContratante = CodTipoDocumentoContratante,
                        NumeroDocumentoContratante = NumeroDocumentoContratante,
                        NombreContratante = NombreContratante,
                        CodParentesco = CodParentesco,
                        TipoCalificadorContratante = TipoCalificadorContratante,
                        CodEspecialidad = request.CodEspecialidad
                    };

                    try
                    {
                        string dataJSON_DatosAdicionales = JsonConvert.SerializeObject(dto_DatosAdicionales);

                        var DataFormBody_DatosAdicionales = new RestRequest(uriWebAPI, Method.Post);
                        DataFormBody_DatosAdicionales.AddParameter("application/json", dataJSON_DatosAdicionales, ParameterType.RequestBody);

                        RestResponse response_DatosAdicionales = httpClient.Execute(DataFormBody_DatosAdicionales);

                        if (response_DatosAdicionales.IsSuccessful)
                        {
                            var responseData_DatosAdicionales = response_DatosAdicionales.Content;

                            var dataResult_DatosAdicionales = JsonConvert.DeserializeObject<Response_datos_adicionales>(responseData_DatosAdicionales);

                            return ServiceResponse.ReturnResultWith200(dataResult_DatosAdicionales);
                        }
                        else
                        {
                            return ServiceResponse.Return404(response_DatosAdicionales.Content);
                        }
                    }
                    catch (Exception e)
                    {
                        return ServiceResponse.Return500(e);
                    }
                }
                else
                {
                    return ServiceResponse.Return404(response_Asegurado.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

        //By Henrry Torres -> ConsultaCondicionMedica
        [HttpPost, Route("GetCondicionMedica")]
        public async Task<ServiceResponse> GetCondicionMedica(Request_Asegurado request)
        {
            //PARTE ConsultaAsegNom
            string uriWebAPI = _appSettings.Siteds + "ConsultaAsegNom";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_Asegurado dto_Asegurado = new Request_Asegurado
            {
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                RUC = request.RUC,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                NombresAfiliado = request.NombresAfiliado,
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado,
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado,
                CodEspecialidad = request.CodEspecialidad
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody_Asegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_Asegurado.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response_Asegurado = httpClient.Execute(DataFormBody_Asegurado);

                if (response_Asegurado.IsSuccessful)
                {
                    var responseData_Asegurado = response_Asegurado.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<IEnumerable<DatosAfiliado>>(responseData_Asegurado);

                    var CodTipoDocumentoAfiliado = "";
                    var NumeroDocumentoAfiliado = "";
                    var NombresAfiliado = "";
                    var ApellidoPaternoAfiliado = "";
                    var ApellidoMaternoAfiliado = "";
                    var CodigoAfiliado = "";
                    var CodProducto = "";
                    var DesProducto = "";
                    var NumeroPlan = "";
                    var CodTipoDocumentoContratante = "";
                    var NumeroDocumentoContratante = "";
                    var NombreContratante = "";
                    var CodParentesco = "";
                    var TipoCalificadorContratante = "";

                    foreach (var item in dataResult_Asegurado)
                    {
                        CodTipoDocumentoAfiliado = item.CodTipoDocumentoAfiliado;
                        NumeroDocumentoAfiliado = item.NumeroDocumentoAfiliado;
                        NombresAfiliado = item.NombresAfiliado;
                        ApellidoPaternoAfiliado = item.ApellidoPaternoAfiliado;
                        ApellidoMaternoAfiliado = item.ApellidoMaternoAfiliado;
                        CodigoAfiliado = item.CodigoAfiliado;
                        CodProducto = item.CodProducto;
                        DesProducto = item.DesProducto;
                        NumeroPlan = item.NumeroPlan;
                        CodTipoDocumentoContratante = item.CodTipoDocumentoContratante;
                        NumeroDocumentoContratante = item.NumeroDocumentoContratante;
                        NombreContratante = item.NombreContratante;
                        CodParentesco = item.CodParentesco;
                        TipoCalificadorContratante = item.TipoCalificadorContratante;
                    }

                    //PARTE ConsultaCondicionMedica
                    uriWebAPI = _appSettings.Siteds + "ConsultaCondicionMedica";

                    setting = new RestClientOptions(uriWebAPI)
                    {
                        MaxTimeout = 400000
                    };

                    httpClient = new RestClient(setting);

                    Request_AsegCod_Obs_DatAdic_CondMed dto_CondicionMedica = new Request_AsegCod_Obs_DatAdic_CondMed
                    {
                        SUNASA = request.SUNASA,
                        IAFAS = request.IAFAS,
                        RUC = request.RUC,
                        NombresAfiliado = NombresAfiliado,
                        ApellidoPaternoAfiliado = ApellidoPaternoAfiliado,
                        ApellidoMaternoAfiliado = ApellidoMaternoAfiliado,
                        CodigoAfiliado = CodigoAfiliado,
                        CodTipoDocumentoAfiliado = CodTipoDocumentoAfiliado,
                        NumeroDocumentoAfiliado = NumeroDocumentoAfiliado,
                        CodProducto = CodProducto,
                        DesProducto = DesProducto,
                        NumeroPlan = NumeroPlan,
                        CodTipoDocumentoContratante = CodTipoDocumentoContratante,
                        NumeroDocumentoContratante = NumeroDocumentoContratante,
                        NombreContratante = NombreContratante,
                        CodParentesco = CodParentesco,
                        TipoCalificadorContratante = TipoCalificadorContratante,
                        CodEspecialidad = request.CodEspecialidad
                    };

                    try
                    {
                        string dataJSON_CondicionMedica = JsonConvert.SerializeObject(dto_CondicionMedica);

                        var DataFormBody_CondicionMedica = new RestRequest(uriWebAPI, Method.Post);
                        DataFormBody_CondicionMedica.AddParameter("application/json", dataJSON_CondicionMedica, ParameterType.RequestBody);

                        RestResponse response_CondicionMedica = httpClient.Execute(DataFormBody_CondicionMedica);

                        if (response_CondicionMedica.IsSuccessful)
                        {
                            var responseData_CondicionMedica = response_CondicionMedica.Content;

                            var dataResult_CondicionMedica = JsonConvert.DeserializeObject<Response_condicion_medica>(responseData_CondicionMedica);

                            return ServiceResponse.ReturnResultWith200(dataResult_CondicionMedica);
                        }
                        else
                        {
                            return ServiceResponse.Return404(response_CondicionMedica.Content);
                        }
                    }
                    catch (Exception e)
                    {
                        return ServiceResponse.Return500(e);
                    }
                }
                else
                {
                    return ServiceResponse.Return404(response_Asegurado.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

        //By Henrry Torres -> ObtenerFoto
        [HttpPost, Route("GetFoto")]
        public async Task<ServiceResponse> GetFoto(Request_ObtenerFoto request)
        {
            string uriWebAPI = _appSettings.Siteds + "ObtenerFoto";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_ObtenerFoto dto_Asegurado = new Request_ObtenerFoto
            {
                Iafas = request.Iafas,
                CodigoAfiliado = request.CodigoAfiliado,
                CodFechaActualizacionFoto = request.CodFechaActualizacionFoto
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody_Asegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_Asegurado.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response_Asegurado = httpClient.Execute(DataFormBody_Asegurado);

                if (response_Asegurado.IsSuccessful)
                {
                    var responseData_Asegurado = response_Asegurado.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<Response_ObtenerFoto>(responseData_Asegurado);

                    return ServiceResponse.ReturnResultWith200(dataResult_Asegurado);
                }
                else
                {
                    return ServiceResponse.Return404(response_Asegurado.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres -> ConsultaProcedimientosEspeciales
        [HttpPost, Route("GetProcedimientosEspeciales")]
        public async Task<ServiceResponse> GetProcedimientosEspeciales(Request_Asegurado request)
        {
            //PARTE ConsultaAsegNom
            string uriWebAPI = _appSettings.Siteds + "ConsultaAsegNom";

            var setting = new RestClientOptions(uriWebAPI)
            {
                MaxTimeout = 400000
            };

            var httpClient = new RestClient(setting);

            Request_Asegurado dto_Asegurado = new Request_Asegurado
            {
                CodTipoDocumentoAfiliado = request.CodTipoDocumentoAfiliado,
                NumeroDocumentoAfiliado = request.NumeroDocumentoAfiliado,
                RUC = request.RUC,
                SUNASA = request.SUNASA,
                IAFAS = request.IAFAS,
                NombresAfiliado = request.NombresAfiliado,
                ApellidoPaternoAfiliado = request.ApellidoPaternoAfiliado,
                ApellidoMaternoAfiliado = request.ApellidoMaternoAfiliado,
                CodEspecialidad = request.CodEspecialidad
            };

            try
            {
                string dataJSON_Asegurado = JsonConvert.SerializeObject(dto_Asegurado);

                var DataFormBody_Asegurado = new RestRequest(uriWebAPI, Method.Post);
                DataFormBody_Asegurado.AddParameter("application/json", dataJSON_Asegurado, ParameterType.RequestBody);

                RestResponse response_Asegurado = httpClient.Execute(DataFormBody_Asegurado);

                if (response_Asegurado.IsSuccessful)
                {
                    var responseData_Asegurado = response_Asegurado.Content;

                    var dataResult_Asegurado = JsonConvert.DeserializeObject<IEnumerable<DatosAfiliado>>(responseData_Asegurado);

                    var CodTipoDocumentoAfiliado = "";
                    var NumeroDocumentoAfiliado = "";
                    var NombresAfiliado = "";
                    var ApellidoPaternoAfiliado = "";
                    var ApellidoMaternoAfiliado = "";
                    var CodigoAfiliado = "";
                    var CodProducto = "";
                    var DesProducto = "";
                    var NumeroPlan = "";
                    var CodTipoDocumentoContratante = "";
                    var NumeroDocumentoContratante = "";
                    var NombreContratante = "";
                    var CodParentesco = "";
                    var TipoCalificadorContratante = "";

                    foreach (var item in dataResult_Asegurado)
                    {
                        CodTipoDocumentoAfiliado = item.CodTipoDocumentoAfiliado;
                        NumeroDocumentoAfiliado = item.NumeroDocumentoAfiliado;
                        NombresAfiliado = item.NombresAfiliado;
                        ApellidoPaternoAfiliado = item.ApellidoPaternoAfiliado;
                        ApellidoMaternoAfiliado = item.ApellidoMaternoAfiliado;
                        CodigoAfiliado = item.CodigoAfiliado;
                        CodProducto = item.CodProducto;
                        DesProducto = item.DesProducto;
                        NumeroPlan = item.NumeroPlan;
                        CodTipoDocumentoContratante = item.CodTipoDocumentoContratante;
                        NumeroDocumentoContratante = item.NumeroDocumentoContratante;
                        NombreContratante = item.NombreContratante;
                        CodParentesco = item.CodParentesco;
                        TipoCalificadorContratante = item.TipoCalificadorContratante;
                    }

                    //PARTE ConsultaAsegCod
                    uriWebAPI = _appSettings.Siteds + "ConsultaAsegCod";

                    setting = new RestClientOptions(uriWebAPI)
                    {
                        MaxTimeout = 400000
                    };

                    httpClient = new RestClient(setting);

                    Request_AsegCod_Obs_DatAdic_CondMed dto_Codigo = new Request_AsegCod_Obs_DatAdic_CondMed
                    {
                        SUNASA = request.SUNASA,
                        IAFAS = request.IAFAS,
                        RUC = request.RUC,
                        NombresAfiliado = NombresAfiliado,
                        ApellidoPaternoAfiliado = ApellidoPaternoAfiliado,
                        ApellidoMaternoAfiliado = ApellidoMaternoAfiliado,
                        CodigoAfiliado = CodigoAfiliado,
                        CodTipoDocumentoAfiliado = CodTipoDocumentoAfiliado,
                        NumeroDocumentoAfiliado = NumeroDocumentoAfiliado,
                        CodProducto = CodProducto,
                        DesProducto = DesProducto,
                        NumeroPlan = NumeroPlan,
                        CodTipoDocumentoContratante = CodTipoDocumentoContratante,
                        NumeroDocumentoContratante = NumeroDocumentoContratante,
                        NombreContratante = NombreContratante,
                        CodParentesco = CodParentesco,
                        TipoCalificadorContratante = TipoCalificadorContratante,
                        CodEspecialidad = request.CodEspecialidad
                    };

                    try
                    {
                        string dataJSON_Codigo = JsonConvert.SerializeObject(dto_Codigo);

                        var DataFormBody_Codigo = new RestRequest(uriWebAPI, Method.Post);
                        DataFormBody_Codigo.AddParameter("application/json", dataJSON_Codigo, ParameterType.RequestBody);

                        RestResponse response_Codigo = httpClient.Execute(DataFormBody_Codigo);

                        if (response_Codigo.IsSuccessful)
                        {
                            var responseData_Codigo = response_Codigo.Content;

                            var dataResult_Codigo = JsonConvert.DeserializeObject<Response_Siteds>(responseData_Codigo);

                            var BeneficioMaximoInicial = "";
                            var CodigoSubTipoCobertura = "";
                            var CodigoTipoCobertura = "";
                            var NumeroCobertura = "";

                            foreach (var item in dataResult_Codigo.Coberturas)
                            {
                                NumeroCobertura = item.NumeroCobertura;
                                BeneficioMaximoInicial = item.BeneficioMaximoInicial;
                                CodigoTipoCobertura = item.CodigoTipoCobertura;
                                CodigoSubTipoCobertura = item.CodigoSubTipoCobertura;
                                break;
                            }

                            //PARTE ConsultaProcedimientosEspeciales
                            uriWebAPI = _appSettings.Siteds + "ConsultaProcedimientosEspeciales";

                            setting = new RestClientOptions(uriWebAPI)
                            {
                                MaxTimeout = 400000
                            };

                            httpClient = new RestClient(setting);

                            Request_AsegCod_Obs_DatAdic_CondMed dto_CondicionMedica = new Request_AsegCod_Obs_DatAdic_CondMed
                            {
                                SUNASA = request.SUNASA,
                                IAFAS = request.IAFAS,
                                RUC = request.RUC,
                                NombresAfiliado = NombresAfiliado,
                                ApellidoPaternoAfiliado = ApellidoPaternoAfiliado,
                                ApellidoMaternoAfiliado = ApellidoMaternoAfiliado,
                                CodigoAfiliado = CodigoAfiliado,
                                CodTipoDocumentoAfiliado = CodTipoDocumentoAfiliado,
                                NumeroDocumentoAfiliado = NumeroDocumentoAfiliado,
                                CodProducto = CodProducto,
                                DesProducto = DesProducto,
                                NumeroPlan = NumeroPlan,
                                CodTipoDocumentoContratante = CodTipoDocumentoContratante,
                                NumeroDocumentoContratante = NumeroDocumentoContratante,
                                NombreContratante = NombreContratante,
                                CodParentesco = CodParentesco,
                                NumeroCobertura = NumeroCobertura,
                                BeneficioMaximoInicial = BeneficioMaximoInicial,
                                CodigoTipoCobertura = CodigoTipoCobertura,
                                CodigoSubTipoCobertura = CodigoSubTipoCobertura,
                                CodEspecialidad = request.CodEspecialidad
                            };

                            try
                            {
                                string dataJSON_CondicionMedica = JsonConvert.SerializeObject(dto_CondicionMedica);

                                var DataFormBody_CondicionMedica = new RestRequest(uriWebAPI, Method.Post);
                                DataFormBody_CondicionMedica.AddParameter("application/json", dataJSON_CondicionMedica, ParameterType.RequestBody);

                                RestResponse response_CondicionMedica = httpClient.Execute(DataFormBody_CondicionMedica);

                                if (response_CondicionMedica.IsSuccessful)
                                {
                                    var responseData_CondicionMedica = response_CondicionMedica.Content;

                                    var dataResult_CondicionMedica = JsonConvert.DeserializeObject<Response_condicion_medica>(responseData_CondicionMedica);

                                    return ServiceResponse.ReturnResultWith200(dataResult_CondicionMedica);
                                }
                                else
                                {
                                    return ServiceResponse.Return404(response_CondicionMedica.Content);
                                }
                            }
                            catch (Exception e)
                            {
                                return ServiceResponse.Return500(e);
                            }
                        }
                        else
                        {
                            return ServiceResponse.Return404(response_Codigo.Content);
                        }
                    }
                    catch (Exception e)
                    {
                        return ServiceResponse.Return500(e);
                    }
                }
                else
                {
                    return ServiceResponse.Return404(response_Asegurado.Content);
                }
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }

        }

    }
}