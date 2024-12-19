namespace MDS.Api.Utility.Extensions
{
    public static class HttpContextExtensions
    {
        public static long GetCurrentUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return -1;
            }

            return Convert.ToInt64(httpContext.User.Claims.Single(claim => claim.Type == "uid").Value);
        }

        public static long GetCurrentSomethingId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return 0;
            }

            return Convert.ToInt64(httpContext.User.Claims.Single(claim => claim.Type == "gid").Value);
        }
    }
}
