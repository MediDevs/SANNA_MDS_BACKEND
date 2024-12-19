using Azure;
using MDS.Api.Infrastructure;
using MDS.Dto;
using MDS.Dto.List;
using MDS.Dto.Resources;
using MDS.Services.Ambulancia;
using MDS.Services.AuditoriaLogin;
using MDS.Services.AuditoriaLogin.Implementation;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS.Api.Controllers.GestionPacientes
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbulanciaController : BaseController
    {
        private readonly IAmbulanciaService _ambulanciaService;

        public AmbulanciaController(IAmbulanciaService ambulanciaService)
        {
            _ambulanciaService = ambulanciaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAmbulancia([FromQuery] AmbulanciaResource ambulanciaResource)
        {
            var resultado = await _ambulanciaService.GetAmbulancia(ambulanciaResource);

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
        [HttpGet, Route("GetTipoServicioAmbulancia")]
        public async Task<IActionResult> GetTipoServicioAmbulancia(string tipoServicio)
        {
            var response = await _ambulanciaService.GetTipoServicioAmbulancia(tipoServicio);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetPrioridadAmbulancia")]
        public async Task<IActionResult> GetPrioridadAmbulancia(string tipoServicio)
        {
            var response = await _ambulanciaService.GetPrioridadAmbulancia(tipoServicio);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetTipoAmbulancia")]
        public async Task<IActionResult> GetTipoAmbulancia()
        {
            var response = await _ambulanciaService.GetTipoAmbulancia();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetTipoTrasladoAmbulancia")]
        public async Task<IActionResult> GetTipoTrasladoAmbulancia(int tipoAmbulancia)
        {
            var response = await _ambulanciaService.GetTipoTrasladoAmbulancia(tipoAmbulancia);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetTipoPoliza")]
        public async Task<IActionResult> GetTipoPoliza(int codigoCliente)
        {
            var response = await _ambulanciaService.GetTipoPoliza(codigoCliente);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetTipoPolizaByCodigo")]
        public async Task<IActionResult> GetTipoPolizaByCodigo(int codigo)
        {
            var response = await _ambulanciaService.GetTipoPolizaByCodigo(codigo);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetMotivoAtencionAmbulancia")]
        public async Task<IActionResult> GetMotivoAtencionAmbulancia(string busqueda)
        {
            var response = await _ambulanciaService.GetMotivoAtencionAmbulancia(busqueda);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetProductoAmbulancia")]
        public async Task<IActionResult> GetProductoAmbulancia(string busqueda, int codCliente)
        {
            var response = await _ambulanciaService.GetProductoAmbulancia(busqueda, codCliente);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetProveedorAmbulancia")]
        public async Task<IActionResult> GetProveedorAmbulancia()
        {
            var response = await _ambulanciaService.GetProveedorAmbulancia();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetTipoComprobante")]
        public async Task<IActionResult> GetTipoComprobante()
        {
            var response = await _ambulanciaService.GetTipoComprobante();

            return ReturnFormattedResponse(response);
        }
    }
}