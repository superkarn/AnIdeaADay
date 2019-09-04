using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIAD.Library.Data.Data;
using AIAD.Library.Global;
using AIAD.Library.Services;
using AIAD.Library.Services.Interfaces;
using AIAD.Library.Services.LookUp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace AIAD.Api
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
            // Set up some global configs
            Application.Api.BaseUrl = this.Configuration.GetSection("Applications")["Api:BaseUrl"];
            Application.Authentication.BaseUrl = this.Configuration.GetSection("Applications")["Authentication:BaseUrl"];
            Application.Web.BaseUrl = this.Configuration.GetSection("Applications")["Web:BaseUrl"];

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            #region JWT
            var jwtAppSettings = this.Configuration.GetSection("Jwt").Get<JwtAppSettings>();
            services.AddSingleton<JwtAppSettings>(jwtAppSettings);
            services.AddScoped<IJwtService, JwtService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtAppSettings.Issuer,
                        ValidAudience = jwtAppSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettings.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            // Needed so JWT can work
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin() // TODO replace this with WithOrigins()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .Build());
            });
            #endregion

            #region Database connection
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Dependency Injection
            services.AddScoped<IIdeaService, IdeaService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ILookUpService, LookUpService>();

            //services.AddScoped<IIdeaRepository, IdeaRepository>();
            //services.AddScoped<ICommentRepository, CommentRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.2#enabling-cors-with-middleware
            // CORS Middleware must precede any defined endpoints in your app where you want to support cross-origin requests 
            // (for example, before the call to UseMvc for MVC/Razor Pages Middleware).
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            // app.UseMvc() should be last in the MVC pipeline
            app.UseMvc();
        }
    }
}
