using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Models;

namespace XYZAuthenticationService.BAL.Services
{
  public interface IAuthenticateService
  {
    User Authenticate(User user);
  }
}
