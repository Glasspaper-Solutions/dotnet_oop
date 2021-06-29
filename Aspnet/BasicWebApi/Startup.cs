using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BasicWebApi.Data;
using BasicWebApi.Common;
using BasicWebApi.Contracts.V1;
using FluentValidation.AspNetCore;

namespace BasicWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<PersonCreateModelValidator>());
            services.AddDbContext<PersonDbContext>(opt => opt.UseInMemoryDatabase("PersonDb"));
            services.AddTransient<PersonService>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}