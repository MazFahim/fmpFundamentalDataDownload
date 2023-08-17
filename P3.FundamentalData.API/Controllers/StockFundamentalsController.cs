using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository;
using P3.FundamentalData.API.Repository.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P3.FundamentalData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockFundamentalsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public StockFundamentalsController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        [HttpGet("financialstatment/annual-income-statement/{symbol}")]
        public async Task<IActionResult> GetAnnualIncomeStatementFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"income-statement/{symbol}?limit=120&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    var incomeStatementList = JsonConvert.DeserializeObject<List<IncomeStatement>>(reponseData);
                    await _unitOfWork.incomeStatementData.CreateAsync(incomeStatementList);
                    await _unitOfWork.SaveAsync();

                    string sqlQuery = "exec prcProcessIncomeStatement";
                    await _unitOfWork.incomeStatementData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("financialstatment/quarter-income-statement/{symbol}")]
        public async Task<IActionResult> GetQuarterlyIncomeStatementFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"income-statement/{symbol}?period=quarter&limit=400&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    var incomeStatementList = JsonConvert.DeserializeObject<List<IncomeStatement>>(reponseData);
                    foreach (IncomeStatement item in incomeStatementList)
                    {
                        if(item.Period == "FY")
                        {
                            item.Period = "Q4";
                        }
                    }
                    await _unitOfWork.incomeStatementData.CreateAsync(incomeStatementList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessIncomeStatement";
                    await _unitOfWork.incomeStatementData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("financialstatment/annual-balancesheet-statement/{symbol}")]
        public async Task<IActionResult> GetAnnualBalanceSheetStatementFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"balance-sheet-statement/{symbol}?limit=120&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    var balanceSheetStatementList = JsonConvert.DeserializeObject<List<BalanceSheetStatement>>(reponseData);
                    
                    await _unitOfWork.balanceSheetStatementData.CreateAsync(balanceSheetStatementList);
                    await _unitOfWork.SaveAsync();
                    //string sqlQuery = "exec prcProcessIncomeStatement";
                    //await _unitOfWork.incomeStatementData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("financialstatment/secfillings/{symbol}")]
        public async Task GetSecFillings(string symbol)
        {
			var apiKey = _configuration["APIInfo:Key"].ToString();
			var client = _httpClientFactory.CreateClient("baseurl");
            var count = 0;
			// sec_filings / AAPL ? page = 25 & apikey = 2b2bbacbc149bcba58903f591ae3d3c8
			var response = await client.GetAsync($"sec_filings/{symbol.ToUpper()}?page={count}&apikey={apiKey}");
            if (response.IsSuccessStatusCode)
            {
			    var reponseData = await response.Content.ReadAsStringAsync();
				var sec_fills = JsonConvert.DeserializeObject<List<temp_secfilings>>(reponseData);
                var sec_fills_list= new List<temp_secfilings>();

				while (sec_fills.Count != 0)
                {
					count++;
                    sec_fills_list.AddRange(sec_fills);
					response = await client.GetAsync($"sec_filings/{symbol.ToUpper()}?page={count}&apikey={apiKey}");
					reponseData = await response.Content.ReadAsStringAsync();
					sec_fills = JsonConvert.DeserializeObject<List<temp_secfilings>>(reponseData);

				}
                await _unitOfWork.Temp_SecFilings.CreateAsync(sec_fills_list);
                await _unitOfWork.SaveAsync();
                Console.WriteLine(sec_fills);

			}


		}
    }
}
