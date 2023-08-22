using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Repository.IRepository;

namespace P3.FundamentalData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceTargetController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public PriceTargetController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        //Price Target Summary data
        [HttpGet("price-target/summary/{symbol}")]
        public async Task<IActionResult> GetPriceTargetSummaryFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v4/price-target-summary?symbol={symbol}?limit=120&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var priceTargetsSummaryForSymbolList = JsonConvert.DeserializeObject<List<PriceTargetsSummaryForSymbol>>(reponseData);
                    await _unitOfWork.PriceTargetsSummaryForSymbolData.CreateAsync(priceTargetsSummaryForSymbolList);
                    await _unitOfWork.SaveAsync();

                    string sqlQuery = "exec prcProcessIncomeStatement";
                    //await _unitOfWork.PriceTargetsSummaryForSymbolData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
    }
}
