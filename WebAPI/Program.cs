using Business;
using Core.CrossCuttingConcrens;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddBusinessServices();
            builder.Services.AddDataAccessServices(builder.Configuration);


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            const string tokenOptionsConfigurationSection = "TokenOptions";
            TokenOptions? tokenOptions = builder.Configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseAuthorization();


            app.MapControllers();


           // app.UseCors();

            app.Run();
        }
    }
}