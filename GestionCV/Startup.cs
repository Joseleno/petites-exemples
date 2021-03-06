﻿using GestionCV.Models;
using GestionCV.Oultils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;
using System;

namespace GestionCV
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
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("GestionCVCon")));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Utilisateurs/Login";
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Ajouter le DI
            services.AddSingleton<IMd5, MD5Hash>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Une autre maniere pour creer la base de donnes
            /*using (var scope =app.ApplicationServices.GetRequiredService<IServiceProvider>().CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<Context>();
            //    context.Database.EnsureCreated();
            }*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Utilisateurs}/{action=Enregistrer}/{id?}");
            });

            RotativaConfiguration.Setup(env);
        }

    }
}