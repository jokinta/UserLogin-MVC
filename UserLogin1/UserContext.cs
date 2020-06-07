using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;


namespace UserLogin1
{
    public class UserContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Logs> Logs { get; set; }

        public UserContext() : base (Properties.Settings.Default.DbConnect)
        {
            
        }
    }
}
