using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository.IRepository;
using P3.FundamentalData.API.Services;

namespace P3.FundamentalData.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class insidertrading : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;

		public insidertrading(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}

		[HttpGet("transactiontypes")]
		public async Task<IActionResult> GetTransactionTypes()
		{
			//https://financialmodelingprep.com/api/v4/insider-trading-transaction-type?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			//var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v4/insider-trading-transaction-type?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						JArray jsonArray = JArray.Parse(responseData); // Parse the JSON array
						List<tblInsiderTradingTransactionType> bulkdataList = new List<tblInsiderTradingTransactionType>();
						foreach (JToken token in jsonArray)
						{
							//tblInsiderTradingTransactionType index = token.ToObject<tblInsiderTradingTransactionType>(); // Deserialize each JSON object
							tblInsiderTradingTransactionType index = new tblInsiderTradingTransactionType
																	{
																		Source = "FMP",
																		Type = token.ToString()
																	}; // Deserialize each JSON object
							bulkdataList.Add(index);
						}
						//var bulkdataList = JsonConvert.DeserializeObject<List<tblInsiderTradingTransactionType>>(responseData);
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

						await _unitOfWork.tblInsiderTradingTransactionType.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						//await _unitOfWork.tblInsiderTradingTransactionType.ExecuteSQLProcedureAsync("EXEC prcProcessSenateTradesForSpecificSymbol");
						//Console.WriteLine(bulkdataList);
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

		[HttpGet("specificsymbol/{symbol}")]
		public async Task <IActionResult> GetTradingForASymbol(string symbol)
		{
			//https://financialmodelingprep.com/api/v4/insider-trading?symbol=AAPL&page=0&apikey=2b2bbacbc149bcba58903f591ae3d3c8
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var count = 0;
				var response = await client.GetAsync($"/api/v4/insider-trading?symbol={symbol}&page={count}&apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var reponseData = await response.Content.ReadAsStringAsync();
						var singlePageData = JsonConvert.DeserializeObject<List<Temp_InsiderTradingForASpecificSymbol>>(reponseData);
						var bulkdataList = new List<Temp_InsiderTradingForASpecificSymbol>();

						while (singlePageData.Count != 0)
						{
							count++;
							bulkdataList.AddRange(singlePageData);
							response = await client.GetAsync($"/api/v4/insider-trading?symbol={symbol}&page={count}&apikey={apiKey}");
							reponseData = await response.Content.ReadAsStringAsync();
							singlePageData = JsonConvert.DeserializeObject<List<Temp_InsiderTradingForASpecificSymbol>>(reponseData);

						}

						await _unitOfWork.temp_InsiderTradingForASpecificSymbol.CreateAsync(bulkdataList);
						await _unitOfWork.SaveAsync();
						await _unitOfWork.temp_InsiderTradingForASpecificSymbol.ExecuteSQLProcedureAsync("EXEC prcProcessSenateTradesForSpecificSymbol");
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

