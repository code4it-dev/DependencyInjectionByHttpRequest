using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DependencyInjectionByHttpRequest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DependencyInjectionByHttpRequest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddTransient<FakeFileSystemAccess>();
            services.AddTransient<RealFileSystemAccess>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DependencyInjectionByHttpRequest", Version = "v1" });
            });

            services.AddScoped<IFileSystemAccess>(provider =>
            {
                var context = provider.GetRequiredService<IHttpContextAccessor>();

                var useFakeFileSystemAccess = context.HttpContext?.Request?.Query?.ContainsKey("fake-fs") ?? false;

                if (useFakeFileSystemAccess)
                    return provider.GetRequiredService<FakeFileSystemAccess>();
                else
                    return provider.GetRequiredService<RealFileSystemAccess>();
            });
        }
    }
}