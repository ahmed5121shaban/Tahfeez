using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tahfeez.Domain.Entities.Atendences;
using Tahfeez.Domain.Entities.Classes;
using Tahfeez.Domain.Entities.Payments;
using Tahfeez.Domain.Entities.Roles;
using Tahfeez.Domain.Entities.Subscriptions;
using Tahfeez.Domain.Entities.Users;

namespace Tahfeez.Infrastracture.Persistence
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Atendence> Atendences { get; set; }
        DbSet<Class> Classes { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
