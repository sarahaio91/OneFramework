﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping
{
    public class UserProfileMapping : BaseMapping
    {
        public override void Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().ToTable("extendUserProfile").HasKey(x => x.Id);
        }
    }
}
