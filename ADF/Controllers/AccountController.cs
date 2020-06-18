using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADF.Core.Model.Contract;
using ADF.Core.Model.Contract.Request;
using ADF.Core.Model.Contract.Response;
using ADF.Core.Model.Entities;
using ADF.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADF.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _AccountService;

        public AccountController(IAccountService accountService)
        {
            _AccountService = accountService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetFamily(string name)
        {
            return Ok();
        }

        [HttpGet]
        [Route("family/{name}/members")]
        public async Task<MessageModel<List<MemberViewModel>>> GetMembers([FromRoute]string name)
        {
            var results =  await _AccountService.GetAllMembersAsync(name);
            return new MessageModel<List<MemberViewModel>>()
            {
                Success = true,
                Message = "Success",
                Response = results
            };
        }

        [HttpPost]
        [Route("member/{name}")]
        public async Task<MessageModel<string>> CreateMember([FromRoute]string name, [FromBody] CreateMemberRequest request)
        {
            var result = new MessageModel<string>();
            var bSuccess = await _AccountService.CreateMemberAsync(name, request);            
            if(bSuccess)
            {
                result.Response = $"Member:{name}";
                result.Message = "Success";
            }
            return result;
            
        }

    }
}