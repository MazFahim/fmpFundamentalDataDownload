using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class IncomeStatementAsReported
    {
        [Key]
        [MaxLength(10)]
        public string SymName { get; set; }

        [Key]
        [Required]
        public DateTime DtDate { get; set; }

        [Key]
        [Required]
        [MaxLength(2)]
        public string Period { get; set; }

        public decimal? CostOfGoodsAndServicesSold { get; set; }
        public decimal? NetIncomeLoss { get; set; }
        public decimal? ResearchAndDevelopmentExpense { get; set; }
        public decimal? GrossProfit { get; set; }
        public decimal? OtherComprehensiveIncomeLossReclassificationAdjustmentFromAociForSaleOfSecuritiesNetOfTax { get; set; }
        public decimal? OtherComprehensiveIncomeLossAvailableForSaleSecuritiesAdjustmentNetOfTax { get; set; }
        public decimal? OtherComprehensiveIncomeLossDerivativeInstrumentGainLossBeforeReclassificationAfterTax { get; set; }
        public decimal? OtherComprehensiveIncomeLossForeignCurrencyTransactionAndTranslationAdjustmentNetOfTax { get; set; }
        public long? WeightedAverageNumberOfDilutedSharesOutstanding { get; set; }
        public decimal? WeightedAverageNumberOfSharesOutstandingBasic { get; set; }
        public decimal? OperatingIncomeLoss { get; set; }
        public decimal? NonOperatingIncomeExpense { get; set; }
        public decimal? IncomeLossFromContinuingOperationsBeforeIncomeTaxesExtraordinaryItemsNoncontrollingInterest { get; set; }
        public decimal? EarningsPerShareBasic { get; set; }
        public decimal? IncomeTaxExpenseBenefit { get; set; }
        public decimal? OtherComprehensiveIncomeUnrealizedHoldingGainLossOnSecuritiesArisingDuringPeriodNetOfTax { get; set; }
        public decimal? RevenueFromContractWithCustomerExcludingAssessedTax { get; set; }
        public decimal? EarningsPerShareDiluted { get; set; }
        public decimal? OperatingExpenses { get; set; }
        public decimal? OtherComprehensiveIncomeLossDerivativeInstrumentGainLossAfterReclassificationAndTax { get; set; }
        public decimal? SellingGeneralAndAdministrativeExpense { get; set; }
        public decimal? OtherComprehensiveIncomeLossDerivativeInstrumentGainLossReclassificationAfterTax { get; set; }
        public decimal? OtherComprehensiveIncomeLossNetOfTaxPortionAttributableToParent { get; set; }
        public decimal? ComprehensiveIncomeNetOfTax { get; set; }
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
