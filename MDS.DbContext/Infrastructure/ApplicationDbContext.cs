using MDS.DbContext.Entities.Identity;
using MDS.DbContext.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MDS.Infrastructure.Settings;
using System.Diagnostics;

namespace MDS.DbContext.Infrastructure
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IAppSettings settings) : base(options)
        {

        }
        public static ApplicationDbContext Create(string connection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            //optionsBuilder.AddInterceptors(BloggingInterceptors.CreateInterceptors());
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
        public virtual DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Identity stuff
            #endregion
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
