﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Repository.IRepository;

namespace P3.FundamentalData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockFundamentalsAnalysisController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;
        public StockFundamentalsAnalysisController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        //Annul Company Financial Ratio Data
        [HttpGet("financialratios/annual-company-financial-ratio/{symbol}")]
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
                    
                    var companyFinancialRatioList = JsonConvert.DeserializeObject<List<CompanyFinancialRatio>>(reponseData);

                    await _unitOfWork.CompanyFinancialRatioData.CreateAsync(companyFinancialRatioList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyFinancialRatio";
                    await _unitOfWork.CompanyFinancialRatioData.ExecuteSQLProcedureAsync(sqlQuery);
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
        [HttpGet("financialratios/quarter-company-financial-ratio/{symbol}")]
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
                    await _unitOfWork.CompanyFinancialRatioData.ExecuteSQLProcedureAsync(sqlQuery);
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
        [HttpGet("financialratios/company-financial-ratio-ttm/{symbol}")]
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
                    
                    var companyFinancialRatioTTMList = JsonConvert.DeserializeObject<List<CompanyFinancialRatiosTTM>>(reponseData);
                    foreach (CompanyFinancialRatiosTTM item in companyFinancialRatioTTMList)
                    {
                        if (item.Symbol == null)
                        {
                            item.Symbol = symbol;
                        }
                    }
                    await _unitOfWork.CompanyFinancialRatiosTTMData.CreateAsync(companyFinancialRatioTTMList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyFinancialRatioTTM";
                    await _unitOfWork.CompanyFinancialRatiosTTMData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Stock Financial Scores
        [HttpGet("stockFinancialScores/stock-financial-scores/{symbol}")]
        public async Task<IActionResult> GetStockFinancialScoresFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v4/score?symbol={symbol}&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var stockFInancialScoresList = JsonConvert.DeserializeObject<List<StockFInancialScores>>(reponseData);
                    //foreach (CompanyFinancialRatiosTTM item in companyFinancialRatioTTMList)
                    //{
                    //    if (item.Symbol == null)
                    //    {
                    //        item.Symbol = symbol;
                    //    }
                    //}
                    await _unitOfWork.StockFInancialScoresData.CreateAsync(stockFInancialScoresList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessStockFinancialScores";
                    await _unitOfWork.StockFInancialScoresData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Owner's Earnings Data
        [HttpGet("stockFinancialScores/owners-earnings/{symbol}")]
        public async Task<IActionResult> GetOwnersEarningsFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v4/owner_earnings?symbol={symbol}&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var ownersEarningList = JsonConvert.DeserializeObject<List<OwnersEarning>>(reponseData);
                    //foreach (CompanyFinancialRatiosTTM item in companyFinancialRatioTTMList)
                    //{
                    //    if (item.Symbol == null)
                    //    {
                    //        item.Symbol = symbol;
                    //    }
                    //}
                    await _unitOfWork.OwnersEarningData.CreateAsync(ownersEarningList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessOwnersEarnings";
                    await _unitOfWork.OwnersEarningData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Company Enterprise Value Annual Data 
        [HttpGet("company-enterprise-value/annual/{symbol}")]
        public async Task<IActionResult> GetAnnualCompanyEnterpriseValueFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/enterprise-values/{symbol}?limit=40&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var companyEnterpriseValueList = JsonConvert.DeserializeObject<List<CompanyEnterpriseValue>>(reponseData);
                    foreach (CompanyEnterpriseValue item in companyEnterpriseValueList)
                    {
                        if (item.Period == null)
                        {
                            item.Period = "FY";
                        }
                    }
                    await _unitOfWork.CompanyEnterpriseValueData.CreateAsync(companyEnterpriseValueList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyEnterpriseValue";
                    await _unitOfWork.CompanyEnterpriseValueData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Company Enterprise Value quarterly data
        [HttpGet("company-enterprise-value/quarter/{symbol}")]
        public async Task<IActionResult> GetQuarterCompanyEnterpriseValueFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/enterprise-values/{symbol}?period=quarter&limit=130&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var companyEnterpriseValueList = JsonConvert.DeserializeObject<List<CompanyEnterpriseValue>>(reponseData);
                    foreach (CompanyEnterpriseValue item in companyEnterpriseValueList)
                    {
                        if (item.Period == null)
                        {
                            item.Period = "Q";
                        }
                    }
                    await _unitOfWork.CompanyEnterpriseValueData.CreateAsync(companyEnterpriseValueList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyEnterpriseValue";
                    await _unitOfWork.CompanyEnterpriseValueData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Income Statement Growth data
        [HttpGet("financial-statement-growth/income-statement-growth/{symbol}")]
        public async Task<IActionResult> GetIncomeStatementGrowthFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/income-statement-growth/{symbol}?limit=40&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var incomeStatementGrowthList = JsonConvert.DeserializeObject<List<IncomeStatementsGrowth>>(reponseData);
                    foreach (IncomeStatementsGrowth item in incomeStatementGrowthList)
                    {
                        if (item.Period == null)
                        {
                            item.Period = "FY";
                        }
                    }
                    await _unitOfWork.IncomeStatementsGrowthData.CreateAsync(incomeStatementGrowthList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessIncomeStatementsGrowth";
                    await _unitOfWork.IncomeStatementsGrowthData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Balance Sheet Growth data
        [HttpGet("financial-statement-growth/balance-sheet-growth/{symbol}")]
        public async Task<IActionResult> GetBalanceSheetGrowthFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/balance-sheet-statement-growth/{symbol}?limit=40&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var balanceSheetGrowthList = JsonConvert.DeserializeObject<List<BalanceSheetGrowth>>(reponseData);
                    foreach (BalanceSheetGrowth item in balanceSheetGrowthList)
                    {
                        if (item.Period == null)
                        {
                            item.Period = "FY";
                        }
                    }
                    await _unitOfWork.BalanceSheetGrowthData.CreateAsync(balanceSheetGrowthList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessBalanceSheetGrowth";
                    await _unitOfWork.BalanceSheetGrowthData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //cash flow growth data
        [HttpGet("financial-statement-growth/cash-flow-growth/{symbol}")]
        public async Task<IActionResult> GetCashFlowGrowthFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"v3/cash-flow-statement-growth/{symbol}?limit=40&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var cashFlowStatementsGrowthList = JsonConvert.DeserializeObject<List<CashFlowStatementsGrowth>>(reponseData);
                    foreach (CashFlowStatementsGrowth item in cashFlowStatementsGrowthList)
                    {
                        if (item.Period == null)
                        {
                            item.Period = "FY";
                        }
                    }
                    await _unitOfWork.CashFlowStatementsGrowthData.CreateAsync(cashFlowStatementsGrowthList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessBalanceSheetGrowth";
                    //await _unitOfWork.CashFlowStatementsGrowthData.ExecuteSQLProcedureAsync(sqlQuery);
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
