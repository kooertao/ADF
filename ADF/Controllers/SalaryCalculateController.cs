using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ADF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalaryCalculateController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTotalSalary(int year)
        {
            //throw new Exception("One error occurs here");
            return Ok($"{year} total income:100w");
        }
    }
}