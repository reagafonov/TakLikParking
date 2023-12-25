using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany(e => e.Bookings)
            .WithOne(e => e.Car);
        builder.HasMany(e => e.Persons)
            .WithMany(e => e.Cars)
            .UsingEntity<CarToPerson>();
    }
}