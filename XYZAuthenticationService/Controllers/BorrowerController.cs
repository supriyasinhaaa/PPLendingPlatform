using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPLendingAuthenticationService.BAL.Services;
using PPLendingAuthenticationService.DAL.Models;
using System.Numerics;
using XYZAuthenticationService.DAL.Models;

namespace PPLendingAuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        
        private readonly IServiceLoanRequest _serviceLoanRequest;

        public BorrowerController( IServiceLoanRequest serviceLoanRequest)
        {
            
            _serviceLoanRequest = serviceLoanRequest;
        }

        [HttpPost]
        [Route("Submit")]

        public async Task<LoanRequest> submit([FromBody]LoanRequest request)
        {

            LoanRequest userReturned = _serviceLoanRequest.UpdateLoanRequest(request);
            if (userReturned != null)
            {
                return userReturned;
            }
            return null;
        }

        [HttpGet]
        [Route("LoanRequest")]

        public async Task<IEnumerable<LoanRequest>> GetLoanRequest(int BorrowerId)
        {
            IEnumerable<LoanRequest> userReturned = this._serviceLoanRequest.GetLoanRequest(BorrowerId);
            if (userReturned != null)
            {
                return userReturned;
            }
            return null;
        }
          


    }
}
    

    

