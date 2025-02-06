using Ardalis.Result;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;
using System.Net;

namespace Vanilla.API.Common;

public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var ex = exception.Demystify();
        logger.LogError(ex, "An error ocurred: {Message}", ex.Message);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var result = Result.Error(exception.ToStringDemystified());
        await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
        return true;
    }
}