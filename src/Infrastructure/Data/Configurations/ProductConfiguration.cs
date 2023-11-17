using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LS.Store.Infrastructure.Data.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(500);
        
        builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId).IsRequired();

        builder.HasOne(p => p.ProductInventory).WithOne().HasForeignKey<ProductInventory>(i=> i.ProductId);
    }
}
