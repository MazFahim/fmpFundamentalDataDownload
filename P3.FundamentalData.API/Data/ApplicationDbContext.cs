﻿using Microsoft.EntityFrameworkCore;
using P3.FundamentalData.API.Models;

namespace P3.FundamentalData.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<IncomeStatement> Temp_IncomeStatement { get; set; }
        public DbSet<BalanceSheetStatement> Temp_BalanceSheetStatement { get; set; }
        public DbSet<CashFLowStatement> Temp_CashFlowStatement { get; set; }
        public DbSet<IncomeStatementAsReported> Temp_IncomeStatementsAsReported { get; set; }
        public DbSet<BalanceSheetStatementAsReported> Temp_BalanceSheetStatementsAsReported { get; set; }
        public DbSet<CashFlowStatementAsReported> Temp_CashFlowStatementAsReported { get; set; }
        public DbSet<FullFinancilalStatementAsReported> Temp_FullFinancialStatement { get; set; }
        public DbSet<InternationalFilings> Temp_InternationalFilings { get; set; }
        public DbSet<SharesFloat> Temp_SharesFloat { get; set; }
        public DbSet<CompanyNotesDue> Temp_CompanyNotesDue { get; set; }
        public DbSet<CompanyFinancialRatio> Temp_CompanyFinancialRatios { get; set; }
        public DbSet<CompanyFinancialRatiosTTM> Temp_CompanyFinancialRatiosTTM { get; set; }
    }
}
