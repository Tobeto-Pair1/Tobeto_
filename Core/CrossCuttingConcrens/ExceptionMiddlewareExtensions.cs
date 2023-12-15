using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcrens;

public class ExceptionMiddlewareExtensions
{


    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
       => app.UseMiddleware<ExceptionMiddleware>();



}
