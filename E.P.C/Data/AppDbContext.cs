using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E.P.C.Models;

namespace E.P.C.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CPUFan> CPUFans { get; set; }
        public DbSet<AIO> AIOs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<PSU> PSUs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MotherBoard> MotherBoards { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Fan> Fans { get; set; }
        public DbSet<Case> Cases { get; set; }

    }
}
