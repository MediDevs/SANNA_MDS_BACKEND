using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Blog
{
    public interface IUbigeoService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetUbigeos();

        //By Henrry Torres
        Task<ServiceResponse> GetDepartamentos();

        //By Henrry Torres
        Task<ServiceResponse> GetProvincias(string SUBI_COD_DPTO);

        //By Henrry Torres
        Task<ServiceResponse> GetDistritos(string SUBI_COD_DPTO, string SUBI_COD_PROV);

        //By William Vilca
        Task<ServiceResponse> GetUbigeo_By_Codigo(string vCodigo);

    }
}

