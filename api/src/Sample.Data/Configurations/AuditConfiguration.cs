using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Configurations
{
    public class AuditConfiguration : DbEntityConfiguration<Audit>
    {
        public override void Configure(EntityTypeBuilder<Audit> builder)
        {
            try
            {
                base.Configure(builder);

                builder
                    .HasKey(t => t.Id);

                builder
                    .Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                builder
                    .Property(x => x.State)
                    .IsRequired()
                    .HasMaxLength(15);

                builder
                    .Property(x => x.TableName)
                    .IsRequired()
                    .HasMaxLength(50);

                builder
                    .Property(x => x.KeyValues)
                    .IsRequired()
                    .HasMaxLength(150);

                builder
                    .Property(p => p.RequestedBy);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"fail to configure Audit: {ex.Message}");
                throw;
            }
        }
    }
}