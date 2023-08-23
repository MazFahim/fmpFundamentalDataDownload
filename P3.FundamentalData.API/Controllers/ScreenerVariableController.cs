using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Repository.IRepository;
using System;

namespace P3.FundamentalData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenerVariableController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ScreenerVariableController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        //Screener Variable DATA
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var screenerVariables = await _unitOfWork.ScreenerVariableData.GetAllAsync();
            var abc = JsonConvert.SerializeObject(screenerVariables);
            return Ok(abc);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ScreenerVariable model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data received");
            }
            else
            {
                await _unitOfWork.ScreenerVariableData.CreateAsync(model);
                await _unitOfWork.SaveAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
