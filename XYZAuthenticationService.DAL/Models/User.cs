using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZAuthenticationService.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNo { get; set; }
        public string? PassWord { get; set; }
        public string? UserRole { get; set; }
        public string? Token { get; set; }
  }
}
