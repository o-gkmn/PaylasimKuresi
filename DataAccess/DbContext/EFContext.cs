﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DbContext;

public class EFContext(DbContextOptions options) : IdentityDbContext<UserEntity, RoleEntity, Guid>(options);