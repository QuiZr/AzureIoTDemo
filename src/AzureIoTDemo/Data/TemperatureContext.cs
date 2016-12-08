using AzureIoTDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureIoTDemo.Data
{
    public class TemperatureContext : DbContext
    {
        public DbSet<TemperatureRead> TemperatureReads { get; set; }

        public TemperatureContext(DbContextOptions<TemperatureContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
