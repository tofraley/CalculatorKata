using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorKata.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Add(int a, int b)
        {
            return Ok(a + b);
        }

        [HttpPost]
        public async Task<ActionResult> Subtract(int first, int second)
        {
            return Ok(first - second);
        }

        [HttpPost]
        public async Task<ActionResult> Multiply(int first, int second)
        {
            return Ok(first * second);
        }

        [HttpPost]
        public async Task<ActionResult> Divide(int first, int second)
        {
            if (second == 0)
                return new BadRequestResult();

            return Ok(first / (double)second);
        }
    }
}