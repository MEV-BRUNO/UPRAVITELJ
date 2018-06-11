using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upravitelj.Models;
using System.Data.Entity;

namespace Upravitelj.Models
{
    public class BazaDbContext : DbContext
    {
        public DbSet<Zgrada> PopisZgrada { get; set; }
    }
}
