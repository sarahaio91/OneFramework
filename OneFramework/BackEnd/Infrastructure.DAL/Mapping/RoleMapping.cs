﻿using Contract.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Mapping
{
    public class RoleMapping : BaseMapping
    {
        public override void Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("extendRole").HasKey(x => x.Id);
        }
    }
}