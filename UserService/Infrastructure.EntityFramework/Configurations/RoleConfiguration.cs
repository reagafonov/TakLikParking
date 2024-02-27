// using Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Infrastructure.EntityFramework.Configurations;
//
// public class RoleConfiguration : IEntityTypeConfiguration<Role>
// {
//     public void Configure(EntityTypeBuilder<Role> builder)
//     {
//         builder.HasKey(e => e.Id);
//         
//         builder.HasMany(e => e.Persons)
//             .WithOne(e => e.Role);
//        
//     }
// }