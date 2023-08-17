using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Repository.IRepository;

namespace P3.FundamentalData.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class marketindexes : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IUnitOfWork _unitOfWork;

		public marketindexes(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		[HttpGet("majorindex")]
		public async Task<IActionResult> GetAnnualIncomeStatementFromFMP(string symbol)
		{
		//https://financialmodelingprep.com/api/v3/quotes/index?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			var apiKey = _configuration["APIInfo:Key"].ToString();
			var client = _httpClientFactory.CreateClient("baseurl");
			var response = await client.GetAsync($"/api/v3/quotes/index?apikey={apiKey}");

			if (response.IsSuccessStatusCode)
			{
				try
				{
					var reponseData = await response.Content.ReadAsStringAsync();
					if (reponseData == null)
					{
						return Ok("FMP didn't provide any data for this API");
					}
					//var incomeStatementList = JsonConvert.DeserializeObject<List<IncomeStatement>>(reponseData);
					//await _unitOfWork.incomeStatementData.CreateAsync(incomeStatementList);
					//await _unitOfWork.SaveAsync();

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
	}
}
