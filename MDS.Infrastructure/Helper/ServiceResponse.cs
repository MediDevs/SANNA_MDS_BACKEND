using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MDS.Infrastructure.Helper
{
    public class  ServiceResponse
    {

        public int StatusCode { get; set; } = 200;  
        public List<string> Errors { get; set; } = new List<string>();
        public string Datetime { get; set; } = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        public object ResultData { get; set; }

        private ServiceResponse(int statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        private ServiceResponse(Exception ex)
        {
            Errors = new List<string> { ex.Message.ToString() };
        }

        private ServiceResponse(int statusCode, object data)
        {
            StatusCode = statusCode;
            ResultData = data;
        }

        public bool Success
        {
            get
            {
                return Errors == null || Errors.Count == 0;
            }
        }

        public static ServiceResponse ReturnSuccess()
        {
            return new ServiceResponse(200, null);
        }

        public static ServiceResponse ReturnResultWith200(object data)
        {
            return new ServiceResponse(200, data);
        }

        public static ServiceResponse ReturnResultWith201(object data)
        {
            return new ServiceResponse(201, data);
        }

        public static ServiceResponse ReturnResultWith204()
        {
            return new ServiceResponse(204, null);
        }

        public static ServiceResponse ReturnUnauthorized()
        {
            return new ServiceResponse(401, null);
        }

        public static ServiceResponse Return404(string message)
        {
            return new ServiceResponse(404, new List<string> { message });
        }

        public static ServiceResponse Return404()
        {
            return new ServiceResponse(404, new List<string> { "Not Found" });
        }

        public static ServiceResponse Return409(string message)
        {
            return new ServiceResponse(409, new List<string> { message });
        }

        public static ServiceResponse return422(string message)
        {
            return new ServiceResponse(422, new List<string> { message });
        }

        public static ServiceResponse Return500(Exception ex)
        {
            return new ServiceResponse(500, new List<string> { ex.Message });
        }

        public static ServiceResponse Return500()
        {
            return new ServiceResponse(500, new List<string> { "An unexpected fault happened. Try again later." });
        }

        public static ServiceResponse ReturnFailed(int statusCode, List<string> errors)
        {
            return new ServiceResponse(statusCode, errors);
        }

        public static ServiceResponse ReturnFailed(int statusCode, string errorMessage)
        {
            return new ServiceResponse(statusCode, new List<string> { errorMessage });
        }

        public static ServiceResponse ReturnException(Exception ex)
        {
            return new ServiceResponse(ex);
        }
    }
}
