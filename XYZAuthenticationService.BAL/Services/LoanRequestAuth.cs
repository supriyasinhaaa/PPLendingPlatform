using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PPLendingAuthenticationService.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.BAL.Services;
using XYZAuthenticationService.DAL.Models;

namespace PPLendingAuthenticationService.BAL.Services
{
    public class LoanRequestAuth : ILoanRequestAuthService
    {
        private readonly IConfiguration configuration;
        private readonly IServiceLoanRequest _serviceLoanRequest;

        public LoanRequestAuth(IConfiguration configuration, IServiceLoanRequest serviceLoanRequest)
        {
            this.configuration = configuration;
            _serviceLoanRequest = serviceLoanRequest;
        }

        public LoanRequest Authenticate(LoanRequest loanRequest)
        {
            if (loanRequest != null)
            {
                var existingUser = _serviceLoanRequest.GetLoanRequest(loanRequest);
                if (existingUser != null)
                {

                    var issuer = configuration["Jwt:Issuer"];
                    var audience = configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                                            new SymmetricSecurityKey(key),
                                            SecurityAlgorithms.HmacSha512Signature
                                        );
                    var subject = new ClaimsIdentity(new[]
                    {
          new Claim(JwtRegisteredClaimNames.Sub, loanRequest.Status),
          new Claim(JwtRegisteredClaimNames.Email, loanRequest.Status),
          });
                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);
                    loanRequest.Token = jwtToken;
                    return (loanRequest);
                }
            }
            return null;
        }
    }

}

