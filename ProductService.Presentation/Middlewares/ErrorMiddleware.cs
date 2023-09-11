using System.Text.Json;
using FluentValidation;

namespace ProductService.Presentation.Middlewares;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    
    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            ExceptionHandler(context, e);
        }
    }

    private static Task ExceptionHandler(HttpContext context, Exception e)
    {
        var statusCode = StatusCodes.Status500InternalServerError;
        var result = "Error";
        switch (e)
        {
            case ValidationException exception:
                statusCode = StatusCodes.Status400BadRequest;
                result = JsonSerializer.Serialize(exception.Errors);
                break;
        }

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(result);
    }
}