using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Repository.IRepository;

namespace P3.FundamentalData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionalStockOwnershipController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;
        public InstitutionalStockOwnershipController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        //Institutional Stock Ownership
        [HttpGet("iso/institutional-stock-ownership/{symbol}")]
        public async Task<IActionResult> GetInstitutionalStockOwnershipFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v4/institutional-ownership/symbol-ownership?symbol={symbol}&includeCurrentQuarter=false&apikey={apiKey}");
            
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var institutionalStockOwnershipList = JsonConvert.DeserializeObject<List<InstitutionalStockOwnership>>(reponseData);

                    await _unitOfWork.InstitutionalStockOwnershipData.CreateAsync(institutionalStockOwnershipList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyFinancialRatio";
                    //await _unitOfWork.InstitutionalStockOwnershipData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Stock Ownership by holders 
        [HttpGet("iso/stock-ownership-by-holders/{symbol}")]
        public async Task<IActionResult> GetStockOwnershipByHoldersFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v4/institutional-ownership/institutional-holders/symbol-ownership-percent?date=2021-09-30&symbol={symbol}&page=0&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var stockOwnershipByHoldersList = JsonConvert.DeserializeObject<List<StockOwnershipByHolders>>(reponseData);

                    await _unitOfWork.StockOwnershipByHoldersData.CreateAsync(stockOwnershipByHoldersList);
                    await _unitOfWork.SaveAsync();
                    string sqlQuery = "exec prcProcessCompanyFinancialRatio";
                    //await _unitOfWork.StockOwnershipByHoldersData.ExecuteSQLProcedureAsync(sqlQuery);
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
