using AdonaiApi.Data.Maps;
using AdonaiApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.SqlClient;
using System.Data;

namespace AdonaiApi.Data
{
    public class AdonaiDataContext : DbContext
    {
        public AdonaiDataContext(DbContextOptions<AdonaiDataContext> options)
            : base(options)
        {            
        }

        public DbSet<Lead> Lead { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString: @"Server=localhost,1433;Database=Adonai;User Id=sa;Password=1q2w3e#@!;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LeadMap());            
        }
    }
}