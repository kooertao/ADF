using ADF.App.Extensions;
using ADF.App.Filter;
using ADF.App.Middleware;
using ADF.Common.Helper;
using ADF.Core.Repository;
using ADF.Core.Services;
using ADF.Core.Services.Interface;
using ADF.CoreApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ADF
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Swagger
            services.AddSwaggerSetup();
            #endregion

            services.AddDbContext<ADFDbContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        providerOptions => providerOptions.EnableRetryOnFailure());//Connection Resiliency
                });
            services.AddSingleton(new Appsettings(Env.ContentRootPath));


            //ע��Uow����
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //ע�뷺�Ͳִ�
            services.AddTransient(typeof(IFamilyRepository), typeof(FamilyRepository));
            services.AddTransient(typeof(IMemberRepository), typeof(MemberRepository));

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IRoleModulePermissionService, RoleModulePermissionService>();
            services.AddAutoMapperSetup();
            services.AddCors(c => 
            {
                c.AddPolicy(Appsettings.app(new string[] { "Startup", "Cors", "PolicyName" }), policy =>
                {
                    policy
                    .SetIsOriginAllowed(host => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
            //Ids4 setup
            services.AddAuthorizationSetup();
            services.AddAuthenticationIds4Setup();

            services.AddControllers(o =>
            {
                //ȫ���쳣����
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            })
            //Json serialize/deserialize
            .AddNewtonsoftJson(options =>
            {
                //����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //��ʹ���շ���ʽ��key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //����ʱ���ʽ
                //options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                //����Model��Ϊnull������
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region Swagger
            app.UseSwaggerMildd();
            #endregion
            app.UseCors(Appsettings.app(new string[] { "Startup", "Cors", "PolicyName" }));
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseMiddleware<RequestResponseMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); 
        }
    }
}
