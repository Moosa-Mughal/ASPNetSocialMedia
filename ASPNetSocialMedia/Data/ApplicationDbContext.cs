using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPNetSocialMedia.Models;

namespace ASPNetSocialMedia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ASPNetSocialMedia.Models.User> User { get; set; }
        public DbSet<ASPNetSocialMedia.Models.Friendship> Friendship { get; set; }
    }
}