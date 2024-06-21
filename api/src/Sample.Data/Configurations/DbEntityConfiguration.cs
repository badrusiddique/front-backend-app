using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Configurations
{
    public class DbEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : DbEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .HasQueryFilter(p => p.IsInactive == false);
        }
    }
}