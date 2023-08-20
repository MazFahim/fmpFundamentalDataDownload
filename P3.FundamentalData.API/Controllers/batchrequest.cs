using Microsoft.AspNetCore.Http;
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
	public class batchrequest : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;

		public batchrequest(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}

		[HttpGet("batchdata")]
		public async Task <IActionResult> GetBatchData()
		{   ///https://financialmodelingprep.com/api/v3/quote/AAPL?apikey=2b2bbacbc149bcba58903f591ae3d3c8
			var symbol = "AAPL,MSFT,AMZN,META,GOOG,SPY,QQQ,NVDA,TSLA,NFLX";
			try
			{
				string apiKey = _apiConnection.GetApiKey();
				HttpClient client = _apiConnection.CreateHttpClient();
				var response = await client.GetAsync($"/api/v3/quote/{symbol}?apikey={apiKey}");

				if (response.IsSuccessStatusCode)
				{
					try
					{
						var responseData = await response.Content.ReadAsStringAsync();
						//JArray jsonArray = JArray.Parse(responseData); // Parse the JSON array
						//List<TempBulkData> bulkdataList = new List<TempBulkData>();
						//foreach (JToken token in jsonArray)
						//{
						//	TempBulkData index = token.ToObject<TempBulkData>(); // Deserialize each JSON object
						//	bulkdataList.Add(index);
						//}
						var bulkdataList= JsonConvert.DeserializeObject<List<TempBulkData>>(responseData);
						Console.WriteLine(bulkdataList);
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
