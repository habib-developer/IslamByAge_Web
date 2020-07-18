using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IslamByAge.Core.Domain;
using IslamByAge.Core.Interfaces;
using IslamByAge.Infrastructure.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IslamByAge.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is ITrackable && (x.State == EntityState.Added || x.State == EntityState.Modified));

            //var currentUsername = !string.IsNullOrEmpty(Curren?.User?.Identity?.Name)
            //    ? HttpContext.Current.User.Identity.Name
            //    : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((ITrackable)entity.Entity).CreatedOn = DateTime.UtcNow;
                    //((ITrackable)entity.Entity).CreatedBy = currentUsername;
                }

                ((ITrackable)entity.Entity).UpdatedOn=DateTime.UtcNow;
                //((ITrackable)entity.Entity).UpdatedBy = currentUsername;
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TopicMap());
            builder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(builder);
        }
    }
}
