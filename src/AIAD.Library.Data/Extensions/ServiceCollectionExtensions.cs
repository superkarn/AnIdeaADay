using AIAD.Library.Data;
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
        public static void AddDataProject(this IServiceCollection services, Action<DataOptions> dataOptions)
        {
            // TODO: Clean up
            DataOptions test = new DataOptions();
            dataOptions.Invoke(test);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(test.ApplicationDbConnectionString));
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(test.IdentityDbConnectionString));

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IIdeaRepository, IdeaRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
