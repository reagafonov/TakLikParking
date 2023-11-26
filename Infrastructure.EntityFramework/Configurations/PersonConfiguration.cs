﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.HasMany(e => e.Bookings)
            .WithOne(e => e.Person);
        builder.HasMany(e => e.Wallets)
            .WithOne(e => e.Person);
    }
}