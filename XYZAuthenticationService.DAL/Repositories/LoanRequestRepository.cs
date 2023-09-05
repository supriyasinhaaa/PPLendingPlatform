using PPLendingAuthenticationService.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPLendingAuthenticationService.DAL.Models;
using XYZAuthenticationService.DAL.Data;
using XYZAuthenticationService.DAL.Models;

namespace PPLendingAuthenticationService.DAL.Repositories
{
    public class LoanRequestRepository : ILoanRequestRepository
    {
        private readonly AppDbContext _appDbContext;
        public LoanRequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public LoanRequest GetLoanRequest(LoanRequest loanRequest)
        {
            try
            {
                if (loanRequest != null)
                {
                    var obj = _appDbContext.LoanRequests.Add(loanRequest);
                    _appDbContext.SaveChanges();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        LoanRequest ILoanRequestRepository.DeleteLoanRequest(LoanRequest loanRequest)
        {
            try {
                if (loanRequest != null) 
                {
                    var obj = _appDbContext.LoanRequests.Add(loanRequest);
                    _appDbContext.SaveChanges();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        IEnumerable<LoanRequest> ILoanRequestRepository.GetLoanRequest(int borrowerId)
        {
            try
            {
                if (borrowerId != 0)
                {
                    IEnumerable<LoanRequest> obj = _appDbContext.LoanRequests.Where(x => x.BorrowerId == borrowerId);
                    if (obj != null)
                        return obj;

                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

        LoanRequest ILoanRequestRepository.UpdateLoanRequest(LoanRequest loanRequest)
        {
            try
            {
                if (loanRequest != null)
                {
                    var obj = _appDbContext.LoanRequests.Add(loanRequest);
                    _appDbContext.SaveChanges();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
           
    }
}

