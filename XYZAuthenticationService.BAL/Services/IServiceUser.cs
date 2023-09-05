using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Models;

namespace XYZAuthenticationService.BAL.Services
{
  public interface IServiceUser
  {
    public User AddUser(User user);
    public User GetUSerById(int id);
    public User GetUserByUserIdAndPassWord(User user);
  }
}
