namespace MKopa.App.Extensions.ApplicationCollection
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System.Net;
    public static class ApplicationBuilderExtensions
    {
        public class ErrorDetails
        {
            public string Message { get; set; }
            public int StatusCode { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
        public static void UseErrorHandling(this IApplicationBuilder @this)
        {
            @this.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }

        public static void UseSwaggerWithUi(this IApplicationBuilder @this, IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopmentOrStaging())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                @this.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                @this.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MKopa APP API V1");
                });
            }

        }

    }
}
