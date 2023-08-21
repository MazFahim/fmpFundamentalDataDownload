using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository.IRepository;
using P3.FundamentalData.API.Services;

namespace P3.FundamentalData.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class economics : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;

		public economics(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}

		[HttpGet("marketriskpremium")]
		public async Task<IActionResult> GetEtfHolders()
		{
			///https://financialmodelingprep.com/api/v4/market_risk_premium?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			//var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v4/market_risk_premium?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_MarketRiskPremiumForEachCountry>>(responseData);
						if (bulkdataList.Count == 0)
						{
							return Ok(new
							{
								code = "200",
								Message = "Response data is empty."
							});
						}
						
						await _unitOfWork.temp_MarketRiskPremiumForEachCountry.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_MarketRiskPremiumForEachCountry.ExecuteSQLProcedureAsync("EXEC prcProcessMarketRiskPremiumForEachCountry");
						Console.WriteLine(bulkdataList);
						return Ok(new
						{
							code = "200",
							Message = "Data inserted successfully."
						});

					}
					catch (Exception ex)
					{
						return BadRequest(new
						{
							code = "400",
							Message = ex.Message
						});

					}

				}
				else
				{
					return BadRequest(new
					{
						code = "400",
						Message = "An error occurred while processing your request."
					});
				}
			}
			catch
			{
				return BadRequest(new
				{
					code = "400",
					Message = "An error occurred while connecting FMP api.."
				});
			}
		}
	}
}
