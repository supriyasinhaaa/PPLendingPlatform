using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Models;

namespace XYZAuthenticationService.BAL.Services
{
  public class AuthenticateService : IAuthenticateService
  {
    private readonly IConfiguration configuration;
    private readonly IServiceUser _serviceUser;
    public AuthenticateService(IConfiguration configuration, IServiceUser serviceUser)
    {
      this.configuration = configuration;
      this._serviceUser = serviceUser;
    }
    public User Authenticate(User user)
    {
      if (user != null)
      {
        //if(user.UserName.Equals("test@email.com") && user.PassWord.Equals("a"))
        //var existingUser = _serviceUser.GetUSerById(user.Id);
        var existingUser = _serviceUser.GetUserByUserIdAndPassWord(user);
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
          new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
          new Claim(JwtRegisteredClaimNames.Email, user.UserName),
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
          user.Token = jwtToken;
          return (user);
        }
      }
      return null;
    }
  }
}
