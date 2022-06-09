namespace MKopa.ProcessSMS.Extensions
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public static class HostingEnvironmentExtensions
    {
        public static bool IsDevelopmentOrStaging(this IWebHostEnvironment env)
        {
            return env.IsDevelopment() || env.IsStaging();
        }
    }
}
