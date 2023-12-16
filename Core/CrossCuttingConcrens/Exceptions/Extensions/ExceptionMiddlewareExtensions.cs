using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcrens;

public static class ExceptionMiddlewareExtensions
{


    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
       => app.UseMiddleware<ExceptionMiddleware>();



}
