using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Repository.IRepository;

namespace P3.FundamentalData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockLookUpToolController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public StockLookUpToolController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        //Stock Screener 
        [HttpGet("stock-look-up-tool/stock-screener/{exchange}")]
        public async Task<IActionResult> GetStockScreenerFromFMP(string exchange)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v3/stock-screener?marketCapMoreThan=1000000000&betaMoreThan=1&volumeMoreThan=10000&sector=Technology&exchange={exchange}&dividendMoreThan=0&limit=100&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var stockScreenerList = JsonConvert.DeserializeObject<List<StockScreener>>(reponseData);
                    await _unitOfWork.StockScreenerData.CreateAsync(stockScreenerList);
                    await _unitOfWork.SaveAsync();

                    string sqlQuery = "exec prcProcessStockScreener";
                    await _unitOfWork.StockScreenerData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Stock Screener Industry
        [HttpGet("stock-look-up-tool/stock-screener-industry/{exchange}")]
        public async Task<IActionResult> GetStockScreenerIndustryFromFMP(string exchange)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v3/stock-screener?marketCapMoreThan=1000000000&betaMoreThan=1&volumeMoreThan=10000&sector=Technology&industry=Software&exchange=NASDAQ&dividendMoreThan=0&limit=100&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var stockScreenerList = JsonConvert.DeserializeObject<List<StockScreener>>(reponseData);
                    await _unitOfWork.StockScreenerData.CreateAsync(stockScreenerList);
                    await _unitOfWork.SaveAsync();

                    string sqlQuery = "exec prcProcessStockScreener";
                    await _unitOfWork.StockScreenerData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Stock Screener Multiple Exchange
        [HttpGet("stock-look-up-tool/stock-screener-multiple-exchange/{exchange}")]
        public async Task<IActionResult> GetStockScreenerMultipleExchangeFromFMP(string exchange)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v3/stock-screener?marketCapLowerThan=10000000000000&betaMoreThan=1&volumeMoreThan=100&exchange=NYSE,NASDAQ&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var stockScreenerList = JsonConvert.DeserializeObject<List<StockScreener>>(reponseData);
                    foreach (StockScreener item in stockScreenerList)
                    {
                        if (item.Sector == null)
                        {
                            item.Sector = "No Data";
                        }
                    }
                    await _unitOfWork.StockScreenerData.CreateAsync(stockScreenerList);
                    await _unitOfWork.SaveAsync();

                    string sqlQuery = "exec prcProcessStockScreener";
                    await _unitOfWork.StockScreenerData.ExecuteSQLProcedureAsync(sqlQuery);
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
