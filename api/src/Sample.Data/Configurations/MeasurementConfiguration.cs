using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Configurations
{
    public class MeasurementConfiguration : BaseEntityConfiguration<Measurement>
    {
        public override void Configure(EntityTypeBuilder<Measurement> builder)
        {
            try
            {
                base.Configure(builder);

                builder.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(10);

                builder.Property(e => e.Speed)
                    .IsRequired();

                builder.Property(e => e.Vibration)
                    .IsRequired();

                builder.Property(e => e.Temperature)
                    .IsRequired();

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                builder.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fail to configure Measurement: {ex.Message}");
                throw;
            }
        }
    }
}