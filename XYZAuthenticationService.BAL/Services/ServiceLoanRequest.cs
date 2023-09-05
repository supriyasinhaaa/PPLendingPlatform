using PPLendingAuthenticationService.DAL.Contracts;
using PPLendingAuthenticationService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Contracts;
using XYZAuthenticationService.DAL.Models;

namespace PPLendingAuthenticationService.BAL.Services
{
    public class ServiceLoanRequest : IServiceLoanRequest
    {
        public ILoanRequestRepository loanRequestRepository { get; set; }
        public ServiceLoanRequest(ILoanRequestRepository loanRequestRepository)
        {
            this.loanRequestRepository = loanRequestRepository;
        }
        public LoanRequest DeleteLoanRequest(LoanRequest loanRequest)
        {
            try
            {
                var userReturned = this.loanRequestRepository.DeleteLoanRequest(loanRequest);
                if (userReturned != null)
                {
                    return userReturned;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LoanRequest GetLoanRequest(LoanRequest loanRequest)
        {

            try
            {
                var userReturned = this.loanRequestRepository.GetLoanRequest(loanRequest);
                if (userReturned != null)
                {
                    return userReturned;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<LoanRequest> GetLoanRequest(int id)
        {
            try
            {
                IEnumerable<LoanRequest> userReturned = this.loanRequestRepository.GetLoanRequest(id);
                if (userReturned != null)
                {
                    return userReturned;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LoanRequest UpdateLoanRequest(LoanRequest loanRequest)
        {
            try
            {
                var userReturned = this.loanRequestRepository.UpdateLoanRequest(loanRequest);
                if (userReturned != null)
                {
                    return userReturned;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
