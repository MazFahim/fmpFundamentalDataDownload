using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P3.FundamentalData.Web.Models;

namespace P3.FundamentalData.Web.Data
{
    public class P3FundamentalDataWebContext : DbContext
    {
        public P3FundamentalDataWebContext (DbContextOptions<P3FundamentalDataWebContext> options)
            : base(options)
        {
        }

        public DbSet<P3.FundamentalData.Web.Models.ScreenerVariableDTO> ScreenerVariableDTO { get; set; } = default!;
    }
}
