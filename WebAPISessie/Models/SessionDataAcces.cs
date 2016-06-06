using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPISessie.Models
{
    class SessionDataAcces : DbContext
    {
        public DbSet<Sessie> Sessies { get; set; }

        public SessionDataAcces()
        {
            Database.SetInitializer<SessionDataAcces>(new SessionInitializer());
        }
    }
}
