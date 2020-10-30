using ADF.Core.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ADF.CoreApi.Extensions
{
    public class ApiResponseHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public ApiResponseHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        : base(options, logger, encoder, clock){ }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync() { throw new NotImplementedException(); }

        /// <summary>
        /// 401
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json";
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            var msgModel = new MessageModel<string>()
            {
                Status = 401,
                Msg = "Unauthorized",
                Success = false
            };
            await Response.WriteAsync(JsonConvert.SerializeObject(msgModel));
        }

        /// <summary>
        /// 403
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties) 
        {
            Response.ContentType = "application/json";
            Response.StatusCode = StatusCodes.Status403Forbidden;
            var msgModel = new MessageModel<string>()
            {
                Status = 403,
                Msg = "Forbidden",
                Success = false
            };
            await Response.WriteAsync(JsonConvert.SerializeObject(msgModel));
        }
    }
}
