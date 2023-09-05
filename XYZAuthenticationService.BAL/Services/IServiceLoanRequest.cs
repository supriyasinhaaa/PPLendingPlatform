using PPLendingAuthenticationService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPLendingAuthenticationService.BAL.Services
{
    public interface IServiceLoanRequest
    {
        public LoanRequest GetLoanRequest(LoanRequest loanRequest);
        public LoanRequest UpdateLoanRequest(LoanRequest loanRequest);
        public LoanRequest DeleteLoanRequest(LoanRequest loanRequest);
        public IEnumerable<LoanRequest> GetLoanRequest(int id);

    }
}
