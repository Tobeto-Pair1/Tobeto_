using Azure;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcrens.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcrens.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcrens.Exceptions;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;
    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }
    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    //protected override Task HandleException(ValidationException validationException)
    //{
    //    throw new NotImplementedException();
    //}

    //protected override Task HandleException(Exception exception)
    //{
    //    throw new NotImplementedException();
    //}
}
