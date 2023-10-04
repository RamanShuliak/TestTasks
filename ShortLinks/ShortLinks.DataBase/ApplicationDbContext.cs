using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinks.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.LongUrl).IsRequired();
                entity.Property(e => e.ShortUrl).IsRequired();
                entity.Property(e => e.DateOfCreation).IsRequired();
                entity.Property(e => e.NumberOfTransitions).IsRequired();
            });
        }
    }
}
