using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class ParkingConfiguration : IEntityTypeConfiguration<Parking>
{
    public void Configure(EntityTypeBuilder<Parking> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.HasMany(e => e.ParkingPlaces)
            .WithOne(e => e.Parking);
    }
}