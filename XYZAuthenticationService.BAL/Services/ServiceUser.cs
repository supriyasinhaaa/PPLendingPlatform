using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Contracts;
using XYZAuthenticationService.DAL.Models;

namespace XYZAuthenticationService.BAL.Services
{
  public class ServiceUser : IServiceUser
  {
    public IUserRepository userRepository { get; set; }
    public ServiceUser(IUserRepository userRepository)
    {
      this.userRepository = userRepository;
    }

    //AddUSer
    public User AddUser(User user)
    {

      try
      {
        var userCreated = this.userRepository.CreateUser(user);
        if (userCreated != null)
        {
          return userCreated;
        }
        return null;
      }
      catch (Exception)
      {

        throw;
      }

    }
    public User GetUSerById(int id)
    {
      try
      {
        var userReturned = this.userRepository.GetUserById(id);
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
    public User GetUserByUserIdAndPassWord(User user)
    {
      try
      {
        var userReturned = this.userRepository.GetUserByUserIdAndPassWord(user);
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
