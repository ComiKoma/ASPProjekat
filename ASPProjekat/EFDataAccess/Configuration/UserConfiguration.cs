using ASPProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.EFDataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(30);

            builder.HasAlternateKey(u => u.Username);
            builder.Property(u => u.Username).HasMaxLength(30);

            builder.Property(u => u.IsAdmin).IsRequired();

            builder.HasAlternateKey(u => u.Email);
            builder.Property(u => u.Username).HasMaxLength(70);

            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.UserUseCases)
               .WithOne(uu => uu.User)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
