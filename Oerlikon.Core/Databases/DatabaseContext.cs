using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Oerlikon.Core.Databases
{
    public class DatabaseContext : DbContext
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
           
        }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
       
    }
}
