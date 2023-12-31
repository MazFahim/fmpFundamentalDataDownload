﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository.IRepository;
using P3.FundamentalData.API.Services;

namespace P3.FundamentalData.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class senatetrading : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;

		public senatetrading(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}

		[HttpGet("forspecificsymbol/{symbol}")]
		public async Task<IActionResult> GetEtfHolders(string symbol)
		{
			///https://financialmodelingprep.com/api/v4/senate-trading?symbol=AAPL&apikey=2b2bbacbc149bcba58903f591ae3d3c8
			//var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v4/senate-trading?symbol={symbol.ToUpper()}&apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						//JArray jsonArray = JArray.Parse(responseData); // Parse the JSON array
						//List<Temp_SenateTradesForSpecificSymbol> bulkdataList = new List<Temp_SenateTradesForSpecificSymbol>();
						//foreach (JToken token in jsonArray)
						//{
						//	Temp_SenateTradesForSpecificSymbol index = token.ToObject<Temp_SenateTradesForSpecificSymbol>(); // Deserialize each JSON object
						//	bulkdataList.Add(index);
						//}
						var bulkdataList = JsonConvert.DeserializeObject<List<Temp_SenateTradesForSpecificSymbol>>(responseData);
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

						await _unitOfWork.temp_SenateTradesForSpecificSymbol.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_SenateTradesForSpecificSymbol.ExecuteSQLProcedureAsync("EXEC prcProcessSenateTradesForSpecificSymbol");
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
