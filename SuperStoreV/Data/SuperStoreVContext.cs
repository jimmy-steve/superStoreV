using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperStoreV.Entities;

namespace SuperStoreV.Data
{
    public class SuperStoreVContext : DbContext
    {
        public SuperStoreVContext (DbContextOptions<SuperStoreVContext> options)
            : base(options)
        {
        }

        public DbSet<SuperStoreV.Entities.Product> Product { get; set; } = default!;
    }
}
