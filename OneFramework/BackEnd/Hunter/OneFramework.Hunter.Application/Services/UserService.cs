﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OneFramework.Hunter.Domain.Dtos;
using OneFramework.Hunter.Domain.Entities.User;
using OneFramework.Hunter.Domain.Repositories;
using OneFramework.Hunter.Domain.Services;

namespace OneFramework.Hunter.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IRepository<UserProfile, EntityEntry> _userProfileRepository;
        private readonly IRepository<Role, EntityEntry> _roleRepository;
        private readonly IRepository<User, EntityEntry> _useRepository;
        public UserService(
            IRepository<UserProfile, EntityEntry> userProfileRepository, 
            IRepository<Role, EntityEntry> roleRepository, 
            IRepository<User, EntityEntry> useRepository
            )
        {
            _userProfileRepository = userProfileRepository;
            _roleRepository = roleRepository;
            _useRepository = useRepository;
        }
        public UserProfileDto GetUserProfileByUserId(Guid userId)
        {
            var userProfile = _userProfileRepository.Get(u => u.UserId == userId);
            return Mapper.Map<UserProfileDto>(userProfile) ?? null;
        }

        public List<RoleDto> GetAllRole()
        {
            var roleList = _roleRepository.Get(u => u.Name != "Administrator");
            return Mapper.Map<List<RoleDto>>(roleList) ?? null;
        }

        public UserDto Register(UserDto userDto)
        {
            var roleUser = _roleRepository.Get(r => r.Name == "User").Id;
            var user = Mapper.Map<User>(userDto);
            user.RoleId = roleUser;
            user.Active = true;
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;
            var result = _useRepository.Insert(user);
            _roleRepository.SaveChanges();
            return Mapper.Map<UserDto>(result);
        }

        public UserDto Login(UserDto userDto)
        {
            var result = _useRepository.Get(u => u.Username == userDto.Username);
            return Mapper.Map<UserDto>(result) ?? null;
        }
    }
}
