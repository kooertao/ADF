﻿using ADF.Common.DB;
using ADF.Common.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ADF.CoreApi.Extensions
{
    public static class AuthorizationSetup
    {
        public static void AddAuthorizationSetup(this IServiceCollection services)
        {
            if(services == null) throw new ArgumentNullException(nameof(services));
            //Authorize methods

            //Option1: [Authorize(Roles="Admin,System")]

            //Option2:[Authorize(Policy = "Admin")]
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
                options.AddPolicy("A_S_O", policy => policy.RequireRole("Admin", "Ssytem", "Others"));
            });

            //Option3:Based on permission
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSecretConfig.Audience_Secret_String));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var permission = new List<PermissionItem>();
            var permissionRequirement = new PermissionRequirement(
                "/api/denied",
                permission,
                ClaimTypes.Role,
                Appsettings.app(new string[] { "Audience", "Issuer" }),
                Appsettings.app(new string[] { "Audience", "Audience" }),
                signingCredentials,
                TimeSpan.FromSeconds(60 * 60)
                );

            services.AddAuthorization(option =>
            {
                option.AddPolicy("Permission", policy => policy.Requirements.Add(permissionRequirement));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddSingleton(permissionRequirement);
            
        }
    }
}
