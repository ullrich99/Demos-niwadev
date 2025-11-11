using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NiwadevApi.Models;

namespace NiwadevApi.Data
{
    public class NiwadevApiContext : DbContext
    {
        public NiwadevApiContext(DbContextOptions<NiwadevApiContext> options)
            : base(options)
        {
        }
      

        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Product> Products { get; set; }
    }
}
