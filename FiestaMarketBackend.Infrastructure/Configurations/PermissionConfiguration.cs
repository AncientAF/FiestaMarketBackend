﻿using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Id);

            var permissions = Enum.GetValues<PermissionEnum>().Select(p => new Permission
            {
                Id = (int)p,
                Name = p.ToString()
            });

            builder.HasData(permissions);
        }
    }
}
