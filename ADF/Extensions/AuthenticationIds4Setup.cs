using ADF.Common.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ADF.CoreApi.Extensions
{
    public static class AuthenticationIds4Setup
    {
        public static void AddAuthenticationIds4Setup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthentication(o => 
            {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = nameof(ApiResponseHandler);
                o.DefaultForbidScheme = nameof(ApiResponseHandler);
            })
            .AddJwtBearer(options => 
            {
                options.Authority = Appsettings.app(new string[] { "Startup", "IdentityServer4", "AuthorizationUrl"});
                options.RequireHttpsMetadata = false;
                options.Audience = Appsettings.app(new string[] { "Startup", "IdentityServer4", "ApiName" });
            })
            .AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o=>{ });
        }
    }
}
