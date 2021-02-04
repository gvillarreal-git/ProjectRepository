using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data;
using BooksApi.Models.Repositories;
using BooksApi.Models.Services;
using BooksApi.Services;
using AutoMapper;
using System.Reflection;


namespace BooksApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IAuthorsService, AuthorsService>();

            services.AddScoped<IPublishersRepository, PublishersRepository>();
            services.AddScoped<IPublishersService, PublisersService>();

            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IBooksService, BooksService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllers();
            services.AddDbContext<BooksContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BooksConection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
