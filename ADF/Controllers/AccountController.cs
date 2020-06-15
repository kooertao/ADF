using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        [Route("member/{name}")]
        public async Task<IActionResult> CreateMember([FromRoute]string name)
        {
            var current = DateTime.Now;
            var member = new Member()
            {
                Name = name,
                CreateTime = current,
                LastUpdated = current,
                IsEmployed = true,
                FamilyName = "Steve family",
                Age = 30,
                MemberGen = Core.Model.Enum.Gender.Man
            };

            var bSuccess = await _AccountService.CreateMember(member);
            if(bSuccess)
            {
                return Ok("Create member successfully.");
            }
            else
            {
                return Ok("failed to create member successfully.");
            }
            
        }

    }
}