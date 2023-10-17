namespace Server.Middlewares
{
    public class AuthenticationMiddleware : IEndpointFilter
    {
        private static string API_KEY_QUERY_PARAMETER = "key";
        private static string GENERIC_FAILURE_MESSAGE = "missing or invalid api key";

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            if (!context.HttpContext.Request.Query.TryGetValue(API_KEY_QUERY_PARAMETER, out var apiKeys) && apiKeys.Any())
                return Results.Unauthorized();

            return await next(context);
        }
    }
}
