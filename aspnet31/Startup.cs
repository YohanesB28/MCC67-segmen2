using aspnet31.Context;
using aspnet31.Repositories.Data;
using aspnet31.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace aspnet31
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
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            var dataSource = @"MSI\MSSQLSERVER1";
            services.AddDbContext<MyContext>(options => options.UseSqlServer("Data Source=" + dataSource + "; Initial Catalog=MCC67;Integrated Security=True"));

            services.AddScoped<SupplierRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<AccountRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAntiforgery(options =>
            {
                options.FormFieldName = "AntiForgeryFieldName";
                options.HeaderName = "AntiForgeryHeaderName";
                options.Cookie.Name = "AntiForgeryCookieName";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
    
            app.UseRouting();

            app.UseStatusCodePages(async context =>
            {
                var request = context.HttpContext.Request;
                var response = context.HttpContext.Response;

                if (response.StatusCode.Equals((int) HttpStatusCode.Unauthorized))
                {
                    response.Redirect("/Unauthorized");
                } else if (response.StatusCode.Equals((int)HttpStatusCode.NotFound))
                {
                    response.Redirect("/Notfound");
                }
            });

            app.UseSession();

            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");

                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }

                await next();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
