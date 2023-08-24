using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Repository;
using P3.FundamentalData.API.Repository.IRepository;
using System;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var screenerVariableJsonData = JsonConvert.SerializeObject(screenerVariables);
            return Ok(screenerVariableJsonData);
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
        //[HttpGet("{varType}/{varName}/{Category}")]
        //public async Task<IActionResult> GetByVariables(string varType, string varName, string Category)
        //{
        //    var screenerVariable = await _unitOfWork.ScreenerVariableData.GetFirstOrDefault(x =>
        //        x.varType == varType &&
        //        x.varName == varName &&
        //        x.Category == Category);

        //    if (screenerVariable == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(screenerVariable);
        //}

        //[HttpPut("{varType}/{varName}/{Category}")]
        //public async Task<IActionResult> Edit(string varType, string varName, string Category, ScreenerVariable model)
        //{
        //    if (model == null || varType != model.varType || varName != model.varName || Category != model.Category)
        //    {
        //        return BadRequest("Invalid data received");
        //    }
        //    else
        //    {
        //        var existingScreenerVariable = await _unitOfWork.ScreenerVariableData.GetFirstOrDefault(x =>
        //                x.varType == varType &&
        //                x.varName == varName &&
        //                x.Category == Category);

        //        if (existingScreenerVariable == null)
        //        {
        //            return NotFound();
        //        }
        //        // Update the properties 
        //        existingScreenerVariable.varName = model.varName;
        //        existingScreenerVariable.varType = model.varType;

        //        _unitOfWork.ScreenerVariableData.UpdateAsync(existingScreenerVariable);
        //        await _unitOfWork.SaveAsync();
        //        return Ok();
        //    }
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var screenerVariable = await _unitOfWork.ScreenerVariableData.GetFirstOrDefault(x=>x.Id==id);
            if (screenerVariable == null)
            {
                return NotFound();
            }

            return Ok(screenerVariable);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, ScreenerVariable model)
        {
            if (model == null || id != model.Id)
            {
                return BadRequest("Invalid data received");
            }

            var existingScreenerVariable = await _unitOfWork.ScreenerVariableData.GetFirstOrDefault(x => x.Id == id);

            if (existingScreenerVariable == null)
            {
                return NotFound();
            }

            // Update the properties
            existingScreenerVariable.varType = model.varType;
            existingScreenerVariable.varName = model.varName;
            existingScreenerVariable.Category = model.Category;

            _unitOfWork.ScreenerVariableData.UpdateAsync(existingScreenerVariable);
            await _unitOfWork.SaveAsync();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingScreenerVariable = await _unitOfWork.ScreenerVariableData.GetFirstOrDefault(x => x.Id == id);

            if (existingScreenerVariable == null)
            {
                return NotFound();
            }

            _unitOfWork.ScreenerVariableData.DeleteAsync(existingScreenerVariable);
            await _unitOfWork.SaveAsync();

            return NoContent(); // NoContent indicates successful deletion
        }

    }
}
