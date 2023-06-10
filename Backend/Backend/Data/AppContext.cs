using Backend.Entities;
using Microsoft.EntityFrameworkCore;


namespace Backend.Data
{
    public class AppContext: DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
