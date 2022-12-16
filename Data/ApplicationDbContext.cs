using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MainApp.Models;
using Microsoft.Extensions.Options;

namespace MainApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        {
        }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<SoilHealthParameters> SoilInfo { get; set; }
    }
}