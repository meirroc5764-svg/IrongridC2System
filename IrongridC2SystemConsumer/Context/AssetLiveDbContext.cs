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

        public DbSet<AssetLiveStatus> AssetLiveStatuses { get; set; }
    }
}