using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class ParkingPlaceConfiguration : IEntityTypeConfiguration<ParkingPlace>
{
    public void Configure(EntityTypeBuilder<ParkingPlace> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany(e => e.Bookings)
            .WithOne(e => e.ParkingPlace);
    }
}