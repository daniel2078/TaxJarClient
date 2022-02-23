using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TaxJarClient.Models;
using TaxJarClient.Services;

namespace TaxJarClient.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITaxService _taxService;

        public TaxController(IConfiguration configuration, ITaxService taxService)
        {
            _configuration = configuration;
            _taxService = taxService;
        }

        [HttpGet]
        [Route("rate/{postalcode}/{country?}/{city?}")]
        public async Task<IActionResult> GetRateAsync(string postalcode, string country = null, string city = null)
        {
            RateReq rate = new()
            {
                postalcode = postalcode,
                country = country,
                city = city
            };

            var res = await _taxService.GetRateAsync(rate);
            return Content(JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        [Route("ordertax")]
        public async Task<IActionResult> GetOrderTaxAsync(OrderTaxReq order)
        {
            var res = await _taxService.GetOrderTaxAsync(order);

            return Content(JsonConvert.SerializeObject(res));
        }
    }
}