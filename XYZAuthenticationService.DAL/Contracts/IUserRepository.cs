using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Models;

namespace XYZAuthenticationService.DAL.Contracts
{
  public interface IUserRepository
  {
    public User CreateUser(User user);
    public User GetUserById(int id);
    public User GetUserByUserIdAndPassWord(User user);
  }
}
