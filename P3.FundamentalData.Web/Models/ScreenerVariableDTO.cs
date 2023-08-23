using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.Web.Models
{
    public class ScreenerVariableDTO
    {
        public string varType { get; set; }
        public string varName { get; set; }
        public string Category { get; set; }
    }
    //public enum CategoryOptions
    //{
    //    Descriptive,
    //    Fundamentals,
    //    Technical
    //}
}
