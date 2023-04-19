namespace DrugManagementAPI
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;

        public CustomMiddleware(RequestDelegate nextMiddleware)
        {
            _nextMiddleware = nextMiddleware;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/api/Drug" && context.Request.Method.ToUpper() == "POST")
            {
                await _nextMiddleware(context);
                return;

            }
            else

            {
                context.Response.StatusCode = 200;
            }
            await _nextMiddleware(context);
        }
    }

}
