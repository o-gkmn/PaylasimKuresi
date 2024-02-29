using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext;

public class AuthContext(DbContextOptions options) : IdentityDbContext<UserEntity>(options);