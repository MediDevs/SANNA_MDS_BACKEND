using MDS.Api.Infrastructure;
using MDS.Services.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UbigeosController : BaseController
    {
        private readonly IUbigeoService _ubigeoService;

        public UbigeosController(IUbigeoService ubigeoService)
        {
            _ubigeoService = ubigeoService;
        }
        //By William Vilca
        [HttpGet, Route("GetUbigeo_Codigo")]
        public async Task<IActionResult> GetUbigeo_Codigo(string vCodigoUbigeo)
        {
            var response = await _ubigeoService.GetUbigeo_By_Codigo(vCodigoUbigeo);
            return ReturnFormattedResponse(response);
        }
        
        //By Henrry Torres
        [HttpGet, Route("GetUbigeos")]
        public async Task<IActionResult> GetUbigeos()
        {
            var response = await _ubigeoService.GetUbigeos();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetDepartamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            var response = await _ubigeoService.GetDepartamentos();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetProvincias")]
        public async Task<IActionResult> GetProvincias(string SUBI_COD_DPTO)
        {
            var response = await _ubigeoService.GetProvincias(SUBI_COD_DPTO);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetDistritos")]
        public async Task<IActionResult> GetDistritos(string SUBI_COD_DPTO, string SUBI_COD_PROV)
        {
            var response = await _ubigeoService.GetDistritos(SUBI_COD_DPTO, SUBI_COD_PROV);

            return ReturnFormattedResponse(response);
        }
    }
}
