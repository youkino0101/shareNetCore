using Microsoft.EntityFrameworkCore;
using NguyenThanhQuan_QLThongTin_MVC.Models;

namespace NguyenThanhQuan_QLThongTin_MVC.Data
{
    public class QLThongTinDbContext : DbContext
    {
        public QLThongTinDbContext(DbContextOptions<QLThongTinDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tinh> Tinhs { get; set; }
        public DbSet<Huyen> Huyens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Tinh>().ToTable("Tinh");
            modelBuilder.Entity<Huyen>().ToTable("Huyen");
            modelBuilder.Entity<Huyen>().HasOne(p => p.Tinh)
                .WithMany(c => c.Huyens)
                .HasForeignKey(p => p.IdTinh);

        }
    }
}
