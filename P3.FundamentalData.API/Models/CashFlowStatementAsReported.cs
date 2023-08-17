using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class CashFlowStatementAsReported
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        [Required]
        public string Period { get; set; }

        public double? PaymentsForRepurchaseOfCommonStock { get; set; }
        public double? ShareBasedCompensation { get; set; }
        public double? NetIncomeLoss { get; set; }
        public double? IncreaseDecreaseInAccountsPayable { get; set; }
        public double? ProceedsFromPaymentsForOtherFinancingActivities { get; set; }
        public double? PaymentsRelatedToTaxWithholdingForShareBasedCompensation { get; set; }
        public double? CashCashEquivalentsRestrictedCashAndRestrictedCashEquivalents { get; set; }
        public double? OtherNonCashIncomeExpense { get; set; }
        public double? PaymentsToAcquireBusinessesNetOfCashAcquired { get; set; }
        public double? DeferredIncomeTaxExpenseBenefit { get; set; }
        public double? IncreaseDecreaseInOtherOperatingLiabilities { get; set; }
        public double? CashCashEquivalentsRestrictedCashAndRestrictedCashEquivalentsPeriodIncreaseDecreaseIncludingExchangeRateEffect { get; set; }
        public double? NetCashProvidedByUsedInOperatingActivities { get; set; }
        public double? ProceedsFromSaleOfAvailableForSaleSecuritiesDebt { get; set; }
        public double? RepaymentsOfLongTermDebt { get; set; }
        public double? IncomeTaxesPaidNet { get; set; }
        public double? ProceedsFromIssuanceOfLongTermDebt { get; set; }
        public double? NetCashProvidedByUsedInInvestingActivities { get; set; }
        public double? IncreaseDecreaseInContractWithCustomerLiability { get; set; }
        public double? InterestPaidNet { get; set; }
        public double? NetCashProvidedByUsedInFinancingActivities { get; set; }
        public double? ProceedsFromRepaymentsOfCommercialPaper { get; set; }
        public double? PaymentsToAcquireAvailableForSaleSecuritiesDebt { get; set; }
        public double? PaymentsToAcquirePropertyPlantAndEquipment { get; set; }
        public double? PaymentsForProceedsFromOtherInvestingActivities { get; set; }
        public double? IncreaseDecreaseInOtherReceivables { get; set; }
        public double? PaymentsOfDividends { get; set; }
        public double? IncreaseDecreaseInInventories { get; set; }
        public double? IncreaseDecreaseInAccountsReceivable { get; set; }
        public double? DepreciationDepletionAndAmortization { get; set; }
        public double? ProceedsFromMaturitiesPrepaymentsAndCallsOfAvailableForSaleSecurities { get; set; }
        public double? IncreaseDecreaseInOtherOperatingAssets { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}

