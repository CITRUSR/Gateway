using Grpc.Core;
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
                context.Response.StatusCode = ex.Status.StatusCode switch
                {
                    StatusCode.NotFound => StatusCodes.Status404NotFound,
                    StatusCode.OutOfRange => StatusCodes.Status422UnprocessableEntity,
                    StatusCode.InvalidArgument => StatusCodes.Status400BadRequest,
                };
                await context.Response.WriteAsJsonAsync(ex.Status.Detail);
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        Log.Error(exception.Message);
    }
}
