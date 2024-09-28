using Gateway.Data.Errors;
using Grpc.Core;
using Newtonsoft.Json;
using Serilog;

namespace Gateway.Middlewares;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleAsync(context, ex);
        }
    }

    private async Task HandleAsync(HttpContext context, Exception exception)
    {
        switch (exception)
        {
            case RpcException ex:
                switch (ex.Status.StatusCode)
                {
                    case StatusCode.NotFound:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsJsonAsync(ex.Status.Detail);
                        break;
                    case StatusCode.OutOfRange:
                        context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                        await context.Response.WriteAsJsonAsync(ex.Status.Detail);
                        break;
                    case StatusCode.InvalidArgument:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsJsonAsync(
                            JsonConvert.DeserializeObject<ValidationError>(ex.Status.Detail)
                        );
                        break;
                }
                break;

            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        Log.Error(exception.Message);
    }
}
