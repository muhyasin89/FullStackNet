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

            modelBuilder.Entity<User_Auth_Activity>().HasKey(am => new
            {
                am.UserId,
                am.AuthActivityId
            });

            modelBuilder.Entity<User_Auth_Activity>().HasOne(m => m.User).WithMany(am => am.User_Auth_Activity).HasForeignKey(am => am.UserId);
            modelBuilder.Entity<User_Auth_Activity>().HasOne(m => m.AuthActivity).WithMany(am => am.User_Auth_Activity).HasForeignKey(am => am.AuthActivityId);

            modelBuilder.UseSerialColumns();

            base.OnModelCreating(modelBuilder);

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<LogActivity> LogActivities { get; set; }
        public DbSet<AuthActivity> AuthActivities { get; set; }

        public DbSet<User_Auth_Activity> User_Auth_Activities { get; set; }

    }
}
