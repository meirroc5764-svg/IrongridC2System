using IrongC2Systemapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
namespace IrongC2Systemapi.context
{
    public class IrongC2SystemapiDbContext : DbContext
    {
        public IrongC2SystemapiDbContext(DbContextOptions options)
            : base(options)
        {

        }

        

        public DbSet<Assets> Assets { get; set; }

        public DbSet<Unit> Unit { get; set; }

    }
}