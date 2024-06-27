using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cust_crrud.Models;

namespace cust_crrud.Data
{
    public class cust_crrudContext : DbContext
    {
        public cust_crrudContext (DbContextOptions<cust_crrudContext> options)
            : base(options)
        {
        }

        public DbSet<cust_crrud.Models.Cust> Cust { get; set; } = default!;
    }
}
