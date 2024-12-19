using Azure;
using MDS.Api.Infrastructure;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Dto.List;
using MDS.Dto.Resources;
using MDS.Infrastructure.Helper;
using MDS.Services.AuditoriaLogin;
using MDS.Services.AuditoriaLogin.Implementation;
using MDS.Services.Usuario;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditoriaLoginController : BaseController
    {
        private readonly IAuditoriaLoginService _auditoriaLoginService;

        public AuditoriaLoginController(IAuditoriaLoginService auditoriaLoginService)
        {
            _auditoriaLoginService = auditoriaLoginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuditoriaLogin([FromQuery] AuditoriaLoginResource loginAuditResource)
        {
            var auditoriaLoginDto = new AuditoriaLoginDto
            {
                AuditoriaLoginResource = loginAuditResource,
            };

            var result = await _auditoriaLoginService.GetAuditoriaLogin(auditoriaLoginDto);
            var rstabla = JsonConvert.DeserializeObject<TablaPaginacionList>(result.ResultData.ToJsonNoFormat());
            var pl = JsonConvert.DeserializeObject<List<AuditoriaLogin>>(rstabla.Result.ToJsonNoFormat());

            var paginationMetadata = new
            {
                totalCount = rstabla.TotalCount,
                pageSize = rstabla.PageSize,
                skip = rstabla.Skip,
                totalPages = rstabla.TotalPages
            };

            var listBloga = pl.Select(s => new AuditoriaLoginDto 
            {
                codigoAuditoria = s.CAUD_ID,
                usuario = s.SUSR_NOMBRE, 
                latitud = s.SAUD_LATITUD,
                longitud = s.SAUD_LONGITUD,
                estado = s.SAUD_ESTADO,
                fecha = s.DAUD_FECHA,
                ip = s.SAUD_DIRECCION_IP,
                descripcion = s.SAUD_DESCRIPCION,
            }).ToList();


            //    //var result = await _mediator.Send(getAllLoginAuditQuery);

            //    //var paginationMetadata = new
            //    //{
            //    //    totalCount = result.TotalCount,
            //    //    pageSize = result.PageSize,
            //    //    skip = result.Skip,
            //    //    totalPages = result.TotalPages
            //    //};
            //    //Response.Headers.Add("X-Pagination",
            //    //    Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            Response.Headers.Add("X-Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return Ok(listBloga);
        }
    }    
}
