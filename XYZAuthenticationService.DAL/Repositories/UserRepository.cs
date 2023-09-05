using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Contracts;
using XYZAuthenticationService.DAL.Data;
using XYZAuthenticationService.DAL.Models;

namespace XYZAuthenticationService.DAL.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly AppDbContext _appDbContext;
    public UserRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public User CreateUser(User user)
    {
      try
      {
        if (user != null)
        {
                    _appDbContext.Users.Update(user);
          var obj = _appDbContext.Users.Add(user);
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

    public User GetUserById(int id)
    {
      try
      {
        if (id != 0)
        {
          var obj = _appDbContext.Users.Where(x => x.Id ==
         id).FirstOrDefault();
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
    public User GetUserByUserIdAndPassWord(User user)
    {
      try
      {
        if (user != null)
        {
          var obj = _appDbContext.Users.Where(x => x.UserName ==user.UserName && x.PassWord==user.PassWord)
         .FirstOrDefault();
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
  }
}
