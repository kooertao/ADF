using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryCalculateController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTotalSalary(int year)
        {
            return Ok($"{year} total income:100w");
        }
    }
}