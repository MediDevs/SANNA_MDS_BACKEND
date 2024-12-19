using Google.Authenticator;
using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Settings;

namespace MDS.Services.DobleFactor.Implementation
{
    public class DobleFactorService : IDobleFactorService
    {
        private readonly IAppSettings _appSettings;

        public DobleFactorService(
            IAppSettings appSettings
            )
        {
            _appSettings = appSettings;
        }

        //public string GenerateQrCodeUri(string email, string secretKey)
        //{
        //    var tfa = new TwoFactorAuthenticator();
        //    return tfa.GenerateQrCodeUri(email, secretKey);
        //}

        //public bool ValidateTwoFactorPin(string secretKey, string twoFactorCode)
        //{
        //    var tfa = new TwoFactorAuthenticator();
        //    return tfa.ValidateTwoFactorPIN(secretKey, twoFactorCode);
        //}

        //public string GenerateNewSecretKey()
        //{
        //    var tfa = new TwoFactorAuthenticator();
        //    var setupCode = tfa.GenerateSetupCode("My App", "My User", "mysecretkey", 300, 300);
        //    return setupCode.Secret;
        //}

        //By Henrry Torres
        public async Task<ServiceResponse> GenerarDobleFactor(DobleFactorDto dto)
        {
            try
            {
                var secretKey = _appSettings.KeySecretGoAuth;

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                SetupCode setupInfo = tfa.GenerateSetupCode("DobleFactorMediSanna", dto.email, secretKey, false, 3);

                return ServiceResponse.ReturnResultWith200(setupInfo);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Return500(ex);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> ValidateDobleFactor(DobleFactorDto dto)
        {
            try
            {
                var secretKey = _appSettings.KeySecretGoAuth;

                var tfa = new TwoFactorAuthenticator();

                dto.status = tfa.ValidateTwoFactorPIN(secretKey, dto.key);

                return ServiceResponse.ReturnResultWith200(dto);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Return500(ex);
            }
        }
    }
}