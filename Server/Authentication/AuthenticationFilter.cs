namespace Server.Middlewares
{
    public class AuthenticationFilter : IEndpointFilter
    {
        private static string API_KEY_QUERY_PARAMETER = "key";

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            if (!context.HttpContext.Request.Query.TryGetValue(API_KEY_QUERY_PARAMETER, out var apiKeys) && apiKeys.Any())
                return Results.Unauthorized();



            return await next(context);
        }
    }
}
