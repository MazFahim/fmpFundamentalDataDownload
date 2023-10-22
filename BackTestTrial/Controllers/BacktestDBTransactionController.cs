using BackTestTrial.IRepository;
using BackTestTrial.Models;
using BackTestTrial.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackTestTrial.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BacktestDBTransactionController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApiConnection _apiConnection;
		public BacktestDBTransactionController(IUnitOfWork unitOfWork, ApiConnection apiConnection)
		{
			_unitOfWork = unitOfWork;
			_apiConnection = apiConnection;
		}

		[HttpGet("Backtest/{ConfigId}")]
		public async Task InsertDataIntoTable(int ConfigId)
		{
			//Fetch data from strategy configure table
			var configuratioResult = await _unitOfWork.StrategyConfigureData.GetFirstOrDefault(x => x.ConfigId == ConfigId);
			DateTime fromDate = configuratioResult.dtFrom;
			DateTime toDate = configuratioResult.dtTo;
			var strategy = configuratioResult.Strategy;
			var longLow = configuratioResult.LongLow;
			var longHigh = configuratioResult.LongHigh;
			var shortLow = configuratioResult.ShortLow;
			var shortHigh = configuratioResult.ShortHigh;

			//Fetch data from strategy template table
			var templateList = await _unitOfWork.StrategyTemplateData.GetAllAsync(x => x.ConfigId == ConfigId);
			//foreach (var item in templateList)
			//{

			//}
			var settingModels = new List<tblBacktestSetting>();
			for (var i=longLow; i<=longHigh; i++)
			{
				for(var j=shortLow; j<=shortHigh; j++)
				{
					var tempId = templateList.Where(x => x.Short == i &&
													x.Long == j).FirstOrDefault();
					var backtestMain = new tblBacktestMain
					{
						Strategy = strategy,
						dtFrom = fromDate,
						dtTo = toDate,
						IsExecuted = true,
						dtExecute = DateTime.Now,
						//TempId = (int)tempId,
						Status = "Done",
						IsPair = false
					};
					await _unitOfWork.backtestMainData.CreateAsync(backtestMain);
					await _unitOfWork.SaveAsync();
					var backtestSetting1 = new tblBacktestSetting
					{
						SName = strategy,
						SFlag = "Long",
						SValue = (int)i,
						RemarksCaption = "Activate"
					};
					settingModels.Add(backtestSetting1);
					var backtestSetting2 = new tblBacktestSetting
					{
						SName = strategy,
						SFlag = "Long",
						SValue = (int)i,
						Remarks = "SL-Percent",
						RemarksCaption = "Stop Loss (%)"
					};
					settingModels.Add(backtestSetting2);
					var backtestSetting3 = new tblBacktestSetting
					{
						SName = strategy,
						SFlag = "Short",
						SValue = (int)j,
						RemarksCaption = "Activate"
					};
					settingModels.Add(backtestSetting3);
					var backtestSetting4 = new tblBacktestSetting
					{
						SName = strategy,
						SFlag = "Short",
						SValue = (int)j,
						Remarks = "SL-Percent",
						RemarksCaption = "Stop Loss (%)"
					};
					settingModels.Add(backtestSetting4);
					foreach (var settingModel in settingModels)
					{
						_unitOfWork.backtestSettingData.CreateAsync(settingModel); // Use your specific repository method
					}
					await _unitOfWork.SaveAsync();
				}
			}
		}
	}
}
