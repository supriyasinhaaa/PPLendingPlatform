using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Models;

namespace PPLendingAuthenticationService.DAL.Models
{
    public class LoanRequest
    {
        public int LoanRequestId { get; set; }
        public int BorrowerId { get; set; }
        public decimal? LoanAmount { get; set; }
        public string? Purpose { get; set; }
        public string? Status { get; set; }
        public string? Token { get; set; }
    }
}
