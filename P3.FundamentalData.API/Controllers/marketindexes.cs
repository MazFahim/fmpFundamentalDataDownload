using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository.IRepository;
using P3.FundamentalData.API.Services;

namespace P3.FundamentalData.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class marketindexes : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;

		public marketindexes(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}

		[HttpGet("majorindex")]
		public async Task <IActionResult> GetIndexes()
		{
			//	//https://financialmodelingprep.com/api/v3/quotes/index?apikey=2b2bbacbc149bcba58903f591ae3d3c8try
			try
			{
				var apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/quotes/index?apikey={apiKey}");
				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var majorIndexes = JsonConvert.DeserializeObject<List<MajorIndexes>>(responseData);
						if (majorIndexes.Count == 0)
						{
							return Ok(new
							{
								Code = "200",
								Message = "Response data is null."
							});
						}
						foreach (MajorIndexes index in majorIndexes)
						{
							index.dtDate = DateTimeOffset.FromUnixTimeSeconds((long)index.Timestamp).UtcDateTime;

						}
						await _unitOfWork.majorIndexesData.CreateAsync(majorIndexes);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.majorIndexesData.ExecuteSQLProcedureAsync("EXEC prcProcessMajorIndexes");
						return Ok(new
						{
							Code = "200",
							Message = "Data Successfully Inserted."
						});
					}
					catch (Exception ex)
					{
						return BadRequest(
							new
							{
								code="400",
								Message=ex.Message
							});
					}

				}
				else
				{
					return BadRequest(
						new
						{
							code="400",
							Message="Can not connect with FMP API."
						});
				}

			}
			catch
			{
				return BadRequest(new
				{
					code="400",
					Message="An error occured to connect FMP API."
				});
			}
		}
		

		[HttpGet("companylistofSP500")]
		public async Task<IActionResult> GetListOfSP500()
		{
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/sp500_constituent?apikey={apiKey}");
				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var listOfSp500 = JsonConvert.DeserializeObject<List<CompanyListSP500>>(responseData);
						if (listOfSp500.Count == 0)
						{
							return Ok(new
							{
								Code = "200",
								Message = "Response data is null."
							});
						}
						await _unitOfWork.temp_ListSandP.CreateAsync(listOfSp500);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_ListSandP.ExecuteSQLProcedureAsync("EXEC prcProcessCompanyListSP");
						return Ok(new
						{
							Code = "200",
							Message = "Data Successfully Inserted."
						});

					}
					catch(Exception ex)
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


		[HttpGet("historicalSP500")]
		public async Task<IActionResult> GetHisotricalSP500()
		{
			try
			{
				//https://financialmodelingprep.com/api/v3/historical/sp500_constituent?apikey=2b2bbacbc149bcba58903f591ae3d3c8
				string apiKey=_apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/historical/sp500_constituent?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData= await response.Content.ReadAsStringAsync();
						var historicalSP500= JsonConvert.DeserializeObject<List<TempHistoricalSP500>>(responseData);
						if (historicalSP500.Count == 0)
						{
							return Ok(new {
							code="200",
							Message="Response data is null"});
						}
						await _unitOfWork.temp_HistoricalSP500.CreateAsync(historicalSP500);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_HistoricalSP500.ExecuteSQLProcedureAsync("EXEC prcProcessHistoricalSP");
						return Ok();

					}
					catch(Exception ex)
					{
						return BadRequest(new {
							code="400",
							Message=ex.Message
						});

					}

				}
				else
				{
					return BadRequest(new { 
						code="400",
						Message= "An error occurred while processing your request."
					});
				}
			}
			catch
			{
				return BadRequest(new { 
					code="400",
					Message= "An error occurred while connecting FMP api.."
				});
			}
		}


		[HttpGet("nasdaq100companies")]
		public async Task<IActionResult> GetNasDaqCompniesList()
		{
			try
			{
				// https://financialmodelingprep.com/api/v3/nasdaq_constituent?apikey=2b2bbacbc149bcba58903f591ae3d3c8
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/nasdaq_constituent?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						var nasdaqLists= JsonConvert.DeserializeObject<List<CompanyListSP500>>(responseData);
						return Ok(responseData);

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
