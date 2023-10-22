namespace BackTestTrial.Services
{
	public class ApiConnection
	{
		private readonly IConfiguration _configuration;
		private readonly IHttpClientFactory _httpClientFactory;

		public ApiConnection(IConfiguration configuration, IHttpClientFactory httpClientFactory)
		{
			_configuration = configuration;
			_httpClientFactory = httpClientFactory;
		}

		//public string GetApiKey()
		//{
		//	return _configuration["APIInfo:Key"].ToString();
		//}

		//public HttpClient CreateHttpClient()
		//{
		//	return _httpClientFactory.CreateClient("baseurl");
		//}
	}
}
