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
	public class stocklist : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;

		public stocklist(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}

		[HttpGet("symbolslist")]
		public async Task <IActionResult> GetSymbolsList()
		{
			//https://financialmodelingprep.com/api/v3/stock/list?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/stock/list?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var symbolsList= JsonConvert.DeserializeObject<List<Temp_StockList>>(responseData);
						if (symbolsList.Count == 0)
						{
							return Ok(new{
								code="200",
								Message="Response data is null."
							});
						}
						await _unitOfWork.temp_StockList.CreateAsync(symbolsList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_StockList.ExecuteSQLProcedureAsync("EXEC prcProcessStockList");
						Console.WriteLine(symbolsList);
						return Ok(new
						{
							code="200",
							Message="Data Successfully inserted."
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
					Message = "An error occurred while connecting FMP api."
				});
			}
		}

		[HttpGet("availablelist")]
		public async Task<IActionResult> GetAvailableList()
		{   //https://financialmodelingprep.com/api/v3/available-traded/list?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/available-traded/list?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var symbolsList = JsonConvert.DeserializeObject<List<Temp_StockList>>(responseData);
						if (symbolsList.Count == 0)
						{
							return Ok(new
							{
								code = "200",
								Message = "Response data is null."
							});
						}
						foreach (Temp_StockList stockList in symbolsList)
						{
							stockList.Remark = "Available";
						}
						await _unitOfWork.temp_StockList.CreateAsync(symbolsList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_StockList.ExecuteSQLProcedureAsync("EXEC prcProcessStockList");
						return Ok(new
						{
							code = "200",
							Message = "Data Successfully inserted."
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
					Message = "An error occurred while connecting FMP api."
				});
			}
		}

		[HttpGet("etflist")]
		public async Task<IActionResult> GetEtfList()
		{//https://financialmodelingprep.com/api/v3/etf/list?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/etf/list?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						
						var responseData = await response.Content.ReadAsStringAsync();
						var symbolsList = JsonConvert.DeserializeObject<List<Temp_StockList>>(responseData);
						if (symbolsList.Count == 0)
						{
							return Ok(new
							{
								code = "200",
								Message = "Response data is null."
							});
						}
						foreach (Temp_StockList stockList in symbolsList)
						{
							stockList.Remark = "ETF";
						}

						await _unitOfWork.temp_StockList.CreateAsync(symbolsList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_StockList.ExecuteSQLProcedureAsync("EXEC prcProcessStockList");
						return Ok(new
						{
							code = "200",
							Message = "Data Successfully inserted."
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
					Message = "An error occurred while connecting FMP api."
				});
			}
		}

	}
}
