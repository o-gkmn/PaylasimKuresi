using AuthenticationServiceApi.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServiceApi.Data.Context
{
    public class AuthContext : IdentityDbContext<UserEntity>
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
        }
    }
}
