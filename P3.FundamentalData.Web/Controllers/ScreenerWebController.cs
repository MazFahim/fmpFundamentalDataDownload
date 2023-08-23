using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using P3.FundamentalData.Web.Models;
using System.Globalization;
using System.Text;

namespace P3.FundamentalData.Web.Controllers
{
    public class ScreenerWebController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ScreenerWebController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.CategoryOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Descriptive", Text = "Descriptive" },
                new SelectListItem { Value = "Fundamental", Text = "Fundamental" },
                new SelectListItem { Value = "Technical", Text = "Technical" }
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScreenerVariableDTO model)
        {
            if (ModelState.IsValid)
            {
                //var apiBaseUrl = _configuration["https://localhost:7258"]; 
                model.varType = new CultureInfo("en-US", false).TextInfo.ToTitleCase(model.varType);
                model.varName = new CultureInfo("en-US", false).TextInfo.ToTitleCase(model.varName);
                model.Category = new CultureInfo("en-US", false).TextInfo.ToTitleCase(model.Category);

                var client = _httpClientFactory.CreateClient("baseurl");
                //client.BaseAddress= new Uri("https://localhost:7258");
                //model.Category = model.Category.ToString();
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"/api/ScreenerVariable", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("", "Error while communicating with API");
                }
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var client = _httpClientFactory.CreateClient("baseurl");
            var response = await client.GetAsync("/api/ScreenerVariable");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var screenerVariables = JsonConvert.DeserializeObject<List<ScreenerVariableDTO>>(content);
                return View(screenerVariables);
            }
            else
            {
                return View(new List<ScreenerVariableDTO>());
            }
        }
    }
}
