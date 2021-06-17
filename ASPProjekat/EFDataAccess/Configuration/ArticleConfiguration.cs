using ASPProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.EFDataAccess.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Name).IsRequired();
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.OnSale).HasDefaultValue(false);
            builder.Property(a => a.OnStock).HasDefaultValue(0);
            builder.Property(a => a.Picture).HasDefaultValue("default_picture.jpg");

            builder.HasMany(a => a.OrderLines)
                .WithOne(ol => ol.Article)
                .HasForeignKey(ol => ol.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);//kad se obrise article zabranice se brisanje ol sa tim articlom

            builder.HasMany(a => a.CartLines)
               .WithOne(c => c.Article)
               .HasForeignKey(c => c.ArticleId);
        }
    }
}
