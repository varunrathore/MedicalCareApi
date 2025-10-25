using Microsoft.EntityFrameworkCore;
using MedicalCareApi.Models;

namespace MedicalCareApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
     }
}
