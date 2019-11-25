using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SO58831661
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<PaymentQueueService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}