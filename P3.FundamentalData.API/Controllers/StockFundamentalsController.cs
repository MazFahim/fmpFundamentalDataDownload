using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
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
        //Annually income statement data
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
        //Quarterly income statement data
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
        //Annually balance sheet data

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
                    string sqlQuery = "exec prcProcessBalanceSheetStatement";
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
        //Quarterly balance sheet data
        [HttpGet("financialstatment/quarterly-balancesheet-statement/{symbol}")]
        public async Task<IActionResult> GetQuarterlyBalanceSheetStatementFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"balance-sheet-statement/{symbol}?period=quarter&limit=400&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    var balanceSheetStatementList = JsonConvert.DeserializeObject<List<BalanceSheetStatement>>(reponseData);
                    foreach (BalanceSheetStatement item in balanceSheetStatementList)
                    {
                        if (item.Period == "FY")
                        {
                            item.Period = "Q4";
                        }
                    }
                    await _unitOfWork.balanceSheetStatementData.CreateAsync(balanceSheetStatementList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessBalanceSheetStatement";
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
        //annual Cash Flow data
        [HttpGet("financialstatment/annually-cashFLow-statement/{symbol}")]
        public async Task<IActionResult> GetAnnuallyCashFLowStatementFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"cash-flow-statement/{symbol}?limit=120&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    var cashFlowStatementList = JsonConvert.DeserializeObject<List<CashFLowStatement>>(reponseData);
                    
                    await _unitOfWork.CashFLowStatementData.CreateAsync(cashFlowStatementList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCashFlowStatement";
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
        //Quarter cash flow data
        [HttpGet("financialstatment/quarter-cashFLow-statement/{symbol}")]
        public async Task<IActionResult> GetQuarterlyCashFLowStatementFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"cash-flow-statement/{symbol}?period=quarter&limit=400&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    var cashFlowStatementList = JsonConvert.DeserializeObject<List<CashFLowStatement>>(reponseData);
                    foreach (CashFLowStatement item in cashFlowStatementList)
                    {
                        if (item.Period == "FY")
                        {
                            item.Period = "Q4";
                        }
                    }
                    await _unitOfWork.CashFLowStatementData.CreateAsync(cashFlowStatementList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCashFlowStatement";
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
    }
}
