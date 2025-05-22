using MediaLibrary.Application.Exceptions;
using MediaLibrary.Application.Exceptions.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace MediaLibrary.Application.Middleware;

public class CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exceptionObj)
        {
            await HandleExceptionAsync(context, exceptionObj, logger);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<CustomExceptionMiddleware> logger)
    {
        int code;
        var result = exception.Message;

        switch (exception)
        {
            case ValidationException validationException:
                code = (int)HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.Failures);
                break;
            case DataNotFoundException DataNotFound:
                code = (int)HttpStatusCode.NotFound;
                result = DataNotFound.Message;
                break;
            case UserAlreadyExistsException userAlreadyExistsException:
                code = (int)HttpStatusCode.Conflict;
                result = userAlreadyExistsException.Message;
                break;
            //case NotFoundException _:
            //    code = (int)HttpStatusCode.NotFound;
            //    break;
            default:
                code = (int)HttpStatusCode.InternalServerError;
                break;
        }

        logger.LogError(result);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;
        return context.Response.WriteAsync(JsonConvert.SerializeObject(new { StatusCode = code, ErrorMessage = exception.Message }));
    }
}