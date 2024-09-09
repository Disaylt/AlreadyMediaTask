using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NasaAsteroid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Infrastructure.EntityConfigurations
{
    internal class AsteroidEntityConfiguration : BaseEntityConfiguration<Asteroid>
    {
        public override void Configure(EntityTypeBuilder<Asteroid> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedNever();

            builder.OwnsOne(o => o.Coordinates);
            builder.OwnsOne(o => o.Mass);

            builder.HasIndex(o => o.Year);
            builder.HasIndex(o => o.Name);
            builder.HasIndex(o => o.ClassType);

            builder.Property(o => o.Name)
                .HasMaxLength(255);

            base.Configure(builder);
        }
    }
}
