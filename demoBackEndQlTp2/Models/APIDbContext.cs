using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.Models
{
    public class APIDbContext :DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuanHuyen>()
                .HasOne(p => p.ThanhPho)
                .WithMany()
                .HasForeignKey(p => p.MaTp);
            modelBuilder.Entity<XaPhuong>()
                .HasOne(p => p.QuanHuyen)
                .WithMany()
                .HasForeignKey(p => p.MaQuanHuyen);
        }
        public DbSet<ThanhPho> thanhPhos { get; set; }
        public DbSet<QuanHuyen> quanHuyens { get; set; }
        public DbSet<XaPhuong> xaPhuongs { get; set; }
    }
}
