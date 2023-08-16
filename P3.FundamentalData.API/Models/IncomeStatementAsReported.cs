using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class IncomeStatementAsReported
    {
        public string SymName { get; set; }
        public DateTime DtDate { get; set; }
        public string Period { get; set; }
        public double? CostOfGoodsAndServicesSold { get; set; }
        public double? NetIncomeLoss { get; set; }
        public double? ResearchAndDevelopmentExpense { get; set; }
        public double? GrossProfit { get; set; }
        public double? OtherComprehensiveIncomeLossReclassificationAdjustmentFromAociForSaleOfSecuritiesNetOfTax { get; set; }
        public double? OtherComprehensiveIncomeLossAvailableForSaleSecuritiesAdjustmentNetOfTax { get; set; }
        public double? OtherComprehensiveIncomeLossDerivativeInstrumentGainLossBeforeReclassificationAfterTax { get; set; }
        public double? OtherComprehensiveIncomeLossForeignCurrencyTransactionAndTranslationAdjustmentNetOfTax { get; set; }
        public long? WeightedAverageNumberOfDilutedSharesOutstanding { get; set; }
        public double? WeightedAverageNumberOfSharesOutstandingBasic { get; set; }
        public double? OperatingIncomeLoss { get; set; }
        public double? NonOperatingIncomeExpense { get; set; }
        public double? IncomeLossFromContinuingOperationsBeforeIncomeTaxesExtraordinaryItemsNoncontrollingInterest { get; set; }
        public double? EarningsPerShareBasic { get; set; }
        public double? IncomeTaxExpenseBenefit { get; set; }
        public double? OtherComprehensiveIncomeUnrealizedHoldingGainLossOnSecuritiesArisingDuringPeriodNetOfTax { get; set; }
        public double? RevenueFromContractWithCustomerExcludingAssessedTax { get; set; }
        public double? EarningsPerShareDiluted { get; set; }
        public double? OperatingExpenses { get; set; }
        public double? OtherComprehensiveIncomeLossDerivativeInstrumentGainLossAfterReclassificationAndTax { get; set; }
        public double? SellingGeneralAndAdministrativeExpense { get; set; }
        public double? OtherComprehensiveIncomeLossDerivativeInstrumentGainLossReclassificationAfterTax { get; set; }
        public double? OtherComprehensiveIncomeLossNetOfTaxPortionAttributableToParent { get; set; }
        public double? ComprehensiveIncomeNetOfTax { get; set; }
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
