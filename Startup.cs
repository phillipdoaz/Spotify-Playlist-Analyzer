using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PlaylistApi.Backend.Models;
using PlaylistApi.Backend.Services;

namespace PlaylistApi.Backend
{
    public class Startup
    {
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMusicInformationService, SpotifyService>();

            services.AddDbContext<PlaylistDataContext>(opt => opt.UseSqlServer(
                @"Server=tcp:phillipspotify.database.windows.net,1433;Initial Catalog=phillipspotify;Persist Security Info=False;User ID=rootuser;Password=l3SaQMq3NY3i4cWa5ejuqYPffvyp9pweVPM683gjlDggMUXT;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Playlist API",
                    Description = "A simple Playlist API",
                    TermsOfService = new Uri("https://phillipdo.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Phillip Do",
                        Email = string.Empty,
                        Url = new Uri("https://linkedin.com/in/ppkdo"),
                    },

                });
                //... and tell Swagger to use those XML comments.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        #endregion

        #region snippet_Configure
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Playlist API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute( "default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}
