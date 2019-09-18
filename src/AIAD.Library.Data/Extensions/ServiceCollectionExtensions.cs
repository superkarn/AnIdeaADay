using AIAD.Library.Data.Data;
using AIAD.Library.Data.Repositories.EntityFramework;
using AIAD.Library.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataProjectDependencies(this IServiceCollection services, Action<Options> options)
        {
            // TODO clean this up
            var temp = new Options();
            options.Invoke(temp);

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(temp.ApplicationDbConnectionString));
            services.AddDbContext<IdentityDbContext>(opt => opt.UseSqlServer(temp.IdentityDbConnectionString));

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IIdeaRepository, IdeaRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }

        public class Options
        {
            public string ApplicationDbConnectionString { get; set; }
            public string IdentityDbConnectionString { get; set; }
        }
    }
}
