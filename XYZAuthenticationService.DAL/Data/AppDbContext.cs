using Microsoft.EntityFrameworkCore;
using PPLendingAuthenticationService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZAuthenticationService.DAL.Models;

namespace XYZAuthenticationService.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<LoanRequest> LoanRequests { get; set; }
    }
}
