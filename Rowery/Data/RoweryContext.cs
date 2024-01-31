using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rowery.Models;

namespace Rowery.Data
{
    public class RoweryContext : DbContext
    {
        public RoweryContext (DbContextOptions<RoweryContext> options)
            : base(options)
        {
        }

        public DbSet<Rowery.Models.Rower> Rower { get; set; } = default!;
    }
}
