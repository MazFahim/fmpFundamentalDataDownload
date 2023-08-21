using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository.IRepository;
using P3.FundamentalData.API.Services;
using System.Runtime.CompilerServices;

namespace P3.FundamentalData.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class fundholdings : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;

		public fundholdings(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}
		[HttpGet("etfholders/{symbol}")]
		public async Task<IActionResult> GetEtfHolders(string symbol)
		{
			///https://financialmodelingprep.com/api/v3/etf-holder/SPY?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			//var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/etf-holder/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_EtfHolders>>(responseData);
						if (bulkdataList.Count == 0)
						{
							return Ok(new
							{
								code = "200",
								Message = "Response data is empty."
							});
						}
						foreach ( var item in bulkdataList )
						{
							item.ETFHolder=symbol.ToUpper();
						}
						await _unitOfWork.temp_EtfHolders.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_EtfHolders.ExecuteSQLProcedureAsync("EXEC prcProcessEtfHoldings");
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
		
		[HttpGet("institutionalholder/{symbol}")]
		public async Task <IActionResult> GetInstitutionalData(string symbol)
		{
			// https://financialmodelingprep.com/api/v3/institutional-holder/AAPL?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			//var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/institutional-holder/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_InstitutionalHoldersOfACompanay>>(responseData);
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
							item.SymName = symbol.ToUpper();
						}
						await _unitOfWork.temp_InstitutionalHoldersOfACompanay.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_InstitutionalHoldersOfACompanay.ExecuteSQLProcedureAsync("EXEC prcProcessInstitutionalHolders");
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

		
		[HttpGet("mutualfundholder/{symbol}")]
		public async Task <IActionResult> GetMutualFundHolder(string symbol)
		{
			//https://financialmodelingprep.com/api/v3/mutual-fund-holder/AAPL?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			//var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/mutual-fund-holder/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_MutualFundHoldersOfACompanay>>(responseData);
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
							item.SymName = symbol.ToUpper();
						}
						await _unitOfWork.temp_MutualFundHoldersOfACompanay.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_MutualFundHoldersOfACompanay.ExecuteSQLProcedureAsync("EXEC prcProcessMutualFundHolder");
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

		[HttpGet("etfsectorweightings/{symbol}")]
		public async Task <IActionResult> GetEtfSectorWeightings(string symbol)
		{
			//https://financialmodelingprep.com/api/v3/etf-sector-weightings/SPY?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			//var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/etf-sector-weightings/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_ETFSectorWeightings>>(responseData);
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
							item.IndexName = symbol.ToUpper();
						}
						await _unitOfWork.temp_ETFSectorWeightings.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_ETFSectorWeightings.ExecuteSQLProcedureAsync("EXEC prcProcessETFSectorWeightings");
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

		[HttpGet("etccountryweightings/{symbol}")]
		public async Task <IActionResult> GetETFCountryWeightings(string symbol)
		{
			try
			{
				//https://financialmodelingprep.com/api/v3/etf-country-weightings/SPY?apikey=2b2bbacbc149bcba58903f591ae3d3c8
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/etf-country-weightings/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_ETFCountryWeightings>>(responseData);
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
							item.IndexName = symbol.ToUpper();
						}
						await _unitOfWork.temp_ETFCountryWeightings.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_ETFCountryWeightings.ExecuteSQLProcedureAsync("EXEC prcProcessETFCountryWeightings");
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

		[HttpGet("etfstockexposureList/{symbol}")]
		public async Task<IActionResult> GetETFStockExposureList(string symbol)
		{
			try
			{
				//https://financialmodelingprep.com/api/v3/etf-stock-exposure/AAPL?apikey=2b2bbacbc149bcba58903f591ae3d3c8
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/etf-stock-exposure/{symbol.ToUpper()}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_ETFStockExposureList>>(responseData);
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
						//	item.IndexName = symbol.ToUpper();
						//}
						await _unitOfWork.temp_ETFStockExposureList.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_ETFStockExposureList.ExecuteSQLProcedureAsync("EXEC prcProcessETFStockExposureList");
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
