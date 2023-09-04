using Backend.Entities;
using Microsoft.EntityFrameworkCore;


namespace Backend.Data
{
    public class AppAPIContext: DbContext
    {
        public AppAPIContext(DbContextOptions<AppAPIContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // this is for logging there 2 type log activities and AuthActivity
            modelBuilder.Entity<UserAuthActivity>().HasKey(am => new
            {
                am.UserId,
                am.AuthActivityId
            });

            modelBuilder.Entity<UserAuthActivity>().HasOne(m => m.User).WithMany(am => am.UserAuthActivity).HasForeignKey(am => am.UserId);
            modelBuilder.Entity<UserAuthActivity>().HasOne(m => m.AuthActivity).WithMany(am => am.UserAuthActivity).HasForeignKey(am => am.AuthActivityId);

            modelBuilder.UseSerialColumns();

            base.OnModelCreating(modelBuilder);

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<LogActivity> LogActivities { get; set; }
        public DbSet<AuthActivity> AuthActivities { get; set; }

        public DbSet<UserAuthActivity> User_Auth_Activities { get; set; }

    }
}
