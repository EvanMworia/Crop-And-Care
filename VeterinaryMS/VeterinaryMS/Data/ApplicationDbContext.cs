using Microsoft.EntityFrameworkCore;
using VeterinaryMS.Models;

namespace VeterinaryMS.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Veterinary> Veterinaries { get; set; }
    }
}
