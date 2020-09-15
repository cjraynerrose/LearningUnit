using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            new CreatePersonCommand("Gandelf", "Hogwarts").Execute(); // 1
            new CreatePersonCommand("Frodo", "Cider").Execute(); // 2
            new CreatePersonCommand("Legolas", "Tree").Execute(); // 3
            new CreatePersonCommand("Sauron", "Spicy Hill").Execute(); // 4
            new CreatePersonCommand("Bill", "The Pony").Execute(); // 5

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
