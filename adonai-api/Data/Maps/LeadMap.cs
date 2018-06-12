using AdonaiApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdonaiApi.Data.Maps
{
    public class LeadMap : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Lead");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.PhoneNumber).IsRequired().HasColumnType("varchar(20)");
            builder.Property(p => p.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Consorcio).IsRequired().HasColumnType("varchar(50)");

        }
    }
}