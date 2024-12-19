using MDS.Infrastructure.Settings;
using Newtonsoft.Json;
using RestSharp;

namespace MDS.Infrastructure.Helper
{
    public class WebServicePostgres
    {
        public WebServiceResponse Consumir(string uriWsPg, object dto, string estadoSincronizacion)
        {
            if (estadoSincronizacion.Equals("true"))
            {
                try
                {
                    var settings = new RestClientOptions(uriWsPg)
                    {
                        MaxTimeout = 400000
                    };

                    var httpClient = new RestClient(settings);

                    string BodyJSON = JsonConvert.SerializeObject(dto);

                    var Request = new RestRequest(uriWsPg, Method.Post);

                    Request.AddParameter("application/json", BodyJSON, ParameterType.RequestBody);

                    RestResponse Response = httpClient.Execute(Request);

                    var status = Response.IsSuccessful;

                    var dataResult = JsonConvert.DeserializeObject<WebServiceResponse>(Response.Content);

                    return dataResult;

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
    }
}