﻿using log4net;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADF.CoreApi.Extensions
{
    public static class SwaggerMidd
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SwaggerMidd));
        public static void UseSwaggerMildd(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //根据版本名称倒序 遍历展示
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ADFCore V1");

                c.OAuthClientId("ADFSwaggerui");


                // 路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });
        }
    }
}
