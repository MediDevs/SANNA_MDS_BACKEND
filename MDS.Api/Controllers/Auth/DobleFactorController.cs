using Azure;
using Google.Authenticator;
using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Dto;
using MDS.Infrastructure.Settings;
using MDS.Services.DobleFactor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class DobleFactorController : BaseController
    {
        private readonly IDobleFactorService _dobleFactorService;
        private readonly IAppSettings _appSettings;

        public DobleFactorController(IDobleFactorService dobleFactorService, IAppSettings appSettings)
        {
            _dobleFactorService = dobleFactorService;
            _appSettings = appSettings;
        }

        //By Henrry Torres
        [HttpPost("GenerarDobleFactor")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerarDobleFactor(GeneraDobleFactorViewModel model)
        {
            DobleFactorDto dto = new DobleFactorDto
            {
                email = model.email
            };

            var response = await _dobleFactorService.GenerarDobleFactor(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost("ValidateDobleFactor")]
        public async Task<IActionResult> ValidateDobleFactor(ValidateDobleFactorViewModel model)
        {
            DobleFactorDto dto = new DobleFactorDto
            {
                email = model.email,
                key = model.key
            };

            var response = await _dobleFactorService.ValidateDobleFactor(dto);

            return ReturnFormattedResponse(response);
        }
    }
}
