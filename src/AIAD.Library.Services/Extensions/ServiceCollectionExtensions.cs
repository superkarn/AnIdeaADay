﻿using AIAD.Library.Services;
using AIAD.Library.Services.LookUp;
using AIAD.Library.Services.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServicesProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IIdeaService, IdeaService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ILookUpService, LookUpService>();
        }
    }
}
