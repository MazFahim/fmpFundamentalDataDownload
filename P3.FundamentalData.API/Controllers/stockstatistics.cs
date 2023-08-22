using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository.IRepository;
using P3.FundamentalData.API.Services;

namespace P3.FundamentalData.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class stockstatistics : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;

		public stockstatistics(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}
		[HttpGet("analystgrade/{symbol}")]
		public async Task<IActionResult> GetAnalystGrade(string symbol)
		{
			//https://financialmodelingprep.com/api/v3/grade/AAPL?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			//var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/grade/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_StockGradeFromAnalysts>>(responseData);
						if (bulkdataList.Count == 0)
						{
							return Ok(new
							{
								code = "200",
								Message = "Response data is empty."
							});
						}
						//foreach (var item in bulkdataList)
						//{
						//	item.SymName = symbol.ToUpper();
						//}

						await _unitOfWork.temp_StockGradeFromAnalysts.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_StockGradeFromAnalysts.ExecuteSQLProcedureAsync("EXEC prcProcessStockGradeFromAnalysts");
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

		[HttpGet("earnignsurprises/{symbol}")]
		public async Task<IActionResult> GetEaringsForASymbol(string symbol)
		{
			//https://financialmodelingprep.com/api/v3/earnings-surprises/AAPL?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/earnings-surprises/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_StockEarningsSurprisesForASymbol>>(responseData);
						if (bulkdataList.Count == 0)
						{
							return Ok(new
							{
								code = "200",
								Message = "Response data is empty."
							});
						}
						
						await _unitOfWork.temp_StockEarningsSurprisesForASymbol.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_StockEarningsSurprisesForASymbol.ExecuteSQLProcedureAsync("EXEC prcProcessStockEarningsSurprisesForASymbol");
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

		[HttpGet("analystestimateannualy/{symbol}")]
		public async Task<IActionResult> GetAnnualAnalystEstimation(string symbol)
		{
			//https://financialmodelingprep.com/api/v3/analyst-estimates/AAPL?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/analyst-estimates/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_StockAnalystEstimate>>(responseData);
						if (bulkdataList.Count == 0)
						{
							return Ok(new
							{
								code = "200",
								Message = "Response data is empty."
							});
						}

						await _unitOfWork.temp_StockAnalystEstimate.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_StockAnalystEstimate.ExecuteSQLProcedureAsync("EXEC prcProcessStockAnalystEstimate");
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

		[HttpGet("analystestimatequarterly/{symbol}")]
		public async Task<IActionResult> GetQuarterlyAnalystEstimation(string symbol)
		{
			//https://financialmodelingprep.com/api/v3/analyst-estimates/AAPL?period=quarter&limit=30&apikey=2b2bbacbc149bcba58903f591ae3d3c8
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/analyst-estimates/{symbol.ToUpper()}?period=quarter&apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_StockAnalystEstimate>>(responseData);
						if (bulkdataList.Count == 0)
						{
							return Ok(new
							{
								code = "200",
								Message = "Response data is empty."
							});
						}
						foreach (var item in bulkdataList)
						{
							item.Period = "Quarterly";
						}

						await _unitOfWork.temp_StockAnalystEstimate.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_StockAnalystEstimate.ExecuteSQLProcedureAsync("EXEC prcProcessStockAnalystEstimate");
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
