using IrongridC2SystemConsumer.Model;
using Microsoft.EntityFrameworkCore;
using System;
namespace IrongridC2SystemConsumer.Context
{
    public class AssetLiveDbContext : DbContext
    {
        public AssetLiveDbContext(DbContextOptions<AssetLiveDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AssetLiveStatus> AssetLiveStatuses { get; set; }
    }
}