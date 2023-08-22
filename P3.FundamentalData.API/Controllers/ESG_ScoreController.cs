using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Repository.IRepository;

namespace P3.FundamentalData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ESG_ScoreController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ESG_ScoreController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        //ESG Scores data
        [HttpGet("esg/esg-score/{symbol}")]
        public async Task<IActionResult> GetESGScoreFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v4/esg-environmental-social-governance-data?symbol={symbol}&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var esgScoreList = JsonConvert.DeserializeObject<List<ESG_Score>>(reponseData);
                    await _unitOfWork.ESG_ScoreData.CreateAsync(esgScoreList);
                    await _unitOfWork.SaveAsync();

                    string sqlQuery = "exec prcProcessEsgScore";
                    await _unitOfWork.ESG_ScoreData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //Company ESG Risk Rating data
        [HttpGet("esg/esg-risk-rating/{symbol}")]
        public async Task<IActionResult> GetESGRiskRatingFromFMP(string symbol)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v4/esg-environmental-social-governance-data-ratings?symbol={symbol}&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var esgRiskRatingList = JsonConvert.DeserializeObject<List<ESG_RiskRating>>(reponseData);
                    await _unitOfWork.ESG_RiskRatingData.CreateAsync(esgRiskRatingList);
                    await _unitOfWork.SaveAsync();

                    string sqlQuery = "exec prcProcessEsgRiskRating";
                    await _unitOfWork.ESG_RiskRatingData.ExecuteSQLProcedureAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return NotFound();
        }
        //ESG benchmarking by sector and year data
        [HttpGet("esg/esg-benchmarking-by-sector-year/{year}")]
        public async Task<IActionResult> GetESGBenchMarkingBySectorFromFMP(int year)
        {
            var apiKey = _configuration["APIInfo:Key"].ToString();
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync($"/api/v4/esg-environmental-social-governance-sector-benchmark?year={year}&apikey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var reponseData = await response.Content.ReadAsStringAsync();

                    var esgBenchmarkingBySectorYearList = JsonConvert.DeserializeObject<List<ESGBenchmarkingBySectorAndYear>>(reponseData);
                    await _unitOfWork.ESGBenchmarkingBySectorAndYearData.CreateAsync(esgBenchmarkingBySectorYearList);
                    await _unitOfWork.SaveAsync();

                    string sqlQuery = "exec prcProcessEsgBenchmarkingBySectorYear";
                    await _unitOfWork.ESGBenchmarkingBySectorAndYearData.ExecuteSQLProcedureAsync(sqlQuery);
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
