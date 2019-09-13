﻿using AIAD.Library.Services;
using AIAD.Library.Services.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServicesProject(this IServiceCollection services)
        {
            services.AddScoped<IIdeaService, IdeaService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ILookUpService, LookUpService>();
        }
    }
}