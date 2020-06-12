using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADF.Core.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADF.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ADFDbContext context;

        public AccountController(ADFDbContext context)
        {
            this.context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetFamily(string name)
        {
            return Ok();
        }

        [HttpPost]
        [Route("family/{name}")]
        public async Task<IActionResult> CreateFamily([FromRoute]string name)
        {
            var current = DateTime.Now;
            var family = new Family()
            {
                Name = name,
                CreateTime = current,
                LastUpdated = current
            };
            context.Families.Add(family);
            await context.SaveChangesAsync();
            return Ok("Create family successfully.");
        }

    }
}