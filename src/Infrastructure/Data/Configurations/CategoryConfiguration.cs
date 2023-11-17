﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LS.Store.Infrastructure.Data.Configurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
