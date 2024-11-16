using CropMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CropMS.Data
{
    public class CropDbContext:DbContext
    {
        public CropDbContext(DbContextOptions<CropDbContext> options) : base(options)
        {

        }
        public DbSet<Farmer> Farmers { get; set; }

    }
}
