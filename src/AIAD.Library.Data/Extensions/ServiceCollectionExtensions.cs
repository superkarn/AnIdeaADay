using AIAD.Library.Data.Data;
using AIAD.Library.Data.Repositories.EntityFramework;
using AIAD.Library.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataProject(this IServiceCollection services, string applicationDbConnectionString, string identityDbConnectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(applicationDbConnectionString));
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(identityDbConnectionString));

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IIdeaRepository, IdeaRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
