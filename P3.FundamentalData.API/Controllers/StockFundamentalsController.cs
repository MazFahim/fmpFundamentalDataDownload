using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        //Annually income statement data
        [HttpGet("financialstatment/annual-income-statement/{symbol}")]
        public async Task<IActionResult> GetAnnualIncomeStatementFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/income-statement/{symbol}?limit=120&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
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
            var response = await client.GetAsync($"v3/income-statement/{symbol}?period=quarter&limit=400&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
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
            var response = await client.GetAsync($"v3/balance-sheet-statement/{symbol}?limit=120&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
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
            var response = await client.GetAsync($"v3/balance-sheet-statement/{symbol}?period=quarter&limit=400&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
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
            var response = await client.GetAsync($"v3/cash-flow-statement/{symbol}?limit=120&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
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
            var response = await client.GetAsync($"v3/cash-flow-statement/{symbol}?period=quarter&limit=400&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
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
        //Annual Income statements as reported data
        [HttpGet("financialstatment/annual-incomestatement-asreported/{symbol}")]
        public async Task<IActionResult> GetAnnualIncomeStatementAsReportedFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/income-statement-as-reported/{symbol}?limit=10&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if(reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var incomeStatementAsReportedList = JsonConvert.DeserializeObject<List<IncomeStatementAsReported>>(reponseData);
                    
                    await _unitOfWork.IncomeStatementAsReportedData.CreateAsync(incomeStatementAsReportedList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessIncomeStatementAsReported";
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
        //Quarterly Income Statement As Reported data
        [HttpGet("financialstatment/quarterly-incomestatement-asreported/{symbol}")]
        public async Task<IActionResult> GetQuarterlyIncomeStatementAsReportedFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/income-statement-as-reported/{symbol}?period=quarter&limit=50&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var incomeStatementAsReportedList = JsonConvert.DeserializeObject<List<IncomeStatementAsReported>>(reponseData);

                    await _unitOfWork.IncomeStatementAsReportedData.CreateAsync(incomeStatementAsReportedList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessIncomeStatementAsReported";
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
        //annual Balance SHeet As Reported data
        [HttpGet("financialstatment/annually-BalanceSheetStatement-AsReported/{symbol}")]
        public async Task<IActionResult> GetAnnuallyBalanceSheetStatementAsReportedFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/balance-sheet-statement-as-reported/{symbol}?limit=10&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var balanceSheetAsRportedList = JsonConvert.DeserializeObject<List<BalanceSheetStatementAsReported>>(reponseData);

                    await _unitOfWork.BalanceSheetAsReportedData.CreateAsync(balanceSheetAsRportedList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessBalanceSheetStatementAsReported";
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
        //Quarter BalanceSheet As Reported data
        [HttpGet("financialstatment/quarter-BalanceSheet-AsReported/{symbol}")]
        public async Task<IActionResult> GetQuarterlyBalanceSheetAsReportedFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/balance-sheet-statement-as-reported/{symbol}?period=quarter&limit=50&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var balanceSheetAsRportedList = JsonConvert.DeserializeObject<List<BalanceSheetStatementAsReported>>(reponseData);
                    foreach (BalanceSheetStatementAsReported item in balanceSheetAsRportedList)
                    {
                        if (item.Period == "FY")
                        {
                            item.Period = "Q4";
                        }
                    }
                    await _unitOfWork.BalanceSheetAsReportedData.CreateAsync(balanceSheetAsRportedList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessBalanceSheetStatementAsReported";
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
        //annual Cash FLow As Reported data
        [HttpGet("financialstatment/annually-cashflowstatement-AsReported/{symbol}")]
        public async Task<IActionResult> GetAnnualCashFlowStatementAsReportedFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/cash-flow-statement-as-reported/{symbol}?limit=10&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var cashFlowAsRportedList = JsonConvert.DeserializeObject<List<CashFlowStatementAsReported>>(reponseData);

                    await _unitOfWork.CashFlowStatementAsReportedData.CreateAsync(cashFlowAsRportedList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCashFlowStatementAsReported";
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
        //Quarter BalanceSheet As Reported data
        [HttpGet("financialstatment/quarter-CashFLow-AsReported/{symbol}")]
        public async Task<IActionResult> GetQuarterCashFlowStatementAsReportedFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/cash-flow-statement-as-reported/{symbol}?period=quarter&limit=50&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var cashFlowAsRportedList = JsonConvert.DeserializeObject<List<CashFlowStatementAsReported>>(reponseData);
                    foreach (CashFlowStatementAsReported item in cashFlowAsRportedList)
                    {
                        if (item.Period == "FY")
                        {
                            item.Period = "Q4";
                        }
                    }
                    await _unitOfWork.CashFlowStatementAsReportedData.CreateAsync(cashFlowAsRportedList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCashFlowStatementAsReported";
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
        //annual Full Financial Statement As Reported data
        [HttpGet("financialstatment/annually-fullfinancialstatement-AsReported/{symbol}")]
        public async Task<IActionResult> GetAnnualFullFinancialStatementAsReportedFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/financial-statement-full-as-reported/{symbol}?apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var fullFinancilalStatementAsReportedList = JsonConvert.DeserializeObject<List<FullFinancilalStatementAsReported>>(reponseData);

                    await _unitOfWork.FullFinancilalStatementAsReportedData.CreateAsync(fullFinancilalStatementAsReportedList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessFullFinancialStatementAsReported";
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
        //quarterly Full Financial Statement As Reported data
        [HttpGet("financialstatment/quarterly-fullfinancialstatement-AsReported/{symbol}")]
        public async Task<IActionResult> GetQuarterlyFullFinancialStatementAsReportedFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/financial-statement-full-as-reported/{symbol}?period=quarter&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData.IsNullOrEmpty())
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var fullFinancilalStatementAsReportedList = JsonConvert.DeserializeObject<List<FullFinancilalStatementAsReported>>(reponseData);
                    foreach (FullFinancilalStatementAsReported item in fullFinancilalStatementAsReportedList)
                    {
                        if (item.Period == "FY")
                        {
                            item.Period = "Q4";
                        }
                    }
                    await _unitOfWork.FullFinancilalStatementAsReportedData.CreateAsync(fullFinancilalStatementAsReportedList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessFullFinancialStatementAsReported";
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
        //Shares Float data
        [HttpGet("financialstatment/shares-float/{symbol}")]
        public async Task<IActionResult> GetSharesFloatFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v4/shares_float?{symbol}&apikey={apiKey}");
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var sharesFloatList = JsonConvert.DeserializeObject<List<SharesFloat>>(reponseData);

                    await _unitOfWork.SharesFloatData.CreateAsync(sharesFloatList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessSharesFloat";
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
        //Company Notes Due data
        [HttpGet("financialstatment/company-notes-due/{symbol}")]
        public async Task<IActionResult> GetCompanyNotesDueFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v4/company-notes?{symbol}&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var companyNotesDueList = JsonConvert.DeserializeObject<List<CompanyNotesDue>>(reponseData);

                    await _unitOfWork.CompanyNotesDueData.CreateAsync(companyNotesDueList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyNotesDue";
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
        //Annul Company Financial Ratio Data
        [HttpGet("financialstatment/annual-company-financial-ratio/{symbol}")]
        public async Task<IActionResult> GetAnnualCompanyFinancialRatioFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/ratios/{symbol}?limit=40&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var companyFinancialRatioList = JsonConvert.DeserializeObject<List<CompanyFinancialRatio>>(reponseData);

                    await _unitOfWork.CompanyFinancialRatioData.CreateAsync(companyFinancialRatioList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyFinancialRatio";
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
        //Quarterly Company Financial Ratio Data
        [HttpGet("financialstatment/quarter-company-financial-ratio/{symbol}")]
        public async Task<IActionResult> GetQuarterCompanyFinancialRatioFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/ratios/{symbol}?period=quarter&limit=140&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var companyFinancialRatioList = JsonConvert.DeserializeObject<List<CompanyFinancialRatio>>(reponseData);
                    foreach (CompanyFinancialRatio item in companyFinancialRatioList)
                    {
                        if (item.period == "FY")
                        {
                            item.period = "Q4";
                        }
                    }
                    await _unitOfWork.CompanyFinancialRatioData.CreateAsync(companyFinancialRatioList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyFinancialRatio";
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
        //Company Financial Ratio TTM Data
        [HttpGet("financialstatment/company-financial-ratio-ttm/{symbol}")]
        public async Task<IActionResult> GetCompanyFinancialRatioTTMFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/ratios-ttm/{symbol}?apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();
                    if (reponseData == null)
                    {
                        return Ok("FMP didn't provide any data for this API");
                    }
                    var companyFinancialRatioTTMList = JsonConvert.DeserializeObject<List<CompanyFinancialRatiosTTM>>(reponseData);

                    await _unitOfWork.CompanyFinancialRatiosTTMData.CreateAsync(companyFinancialRatioTTMList);
                    await _unitOfWork.SaveAsync();
                    //string sqlQuery = "exec prcProcessCompanyFinancialRatio";
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

