namespace ProductsService.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger
        )
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.GetType().ToString()} : {ex.Message}");
                if (ex.InnerException != null)
                    logger.LogError(
                        $"{ex.InnerException.GetType().ToString()} : {ex.InnerException.Message}"
                    );

                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(
                    new { Message = ex.Message, Type = ex.GetType().ToString() }
                );

                throw;
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(
            this IApplicationBuilder builder
        )
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
