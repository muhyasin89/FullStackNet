using Backend.Data.Model;
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
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<User_Auth_Activity>().HasOne(m => m.User).WithMany(am => am.Actors_Movie).HasForeignKey(am => am.UserId);
            modelBuilder.Entity<User_Auth_Activity>().HasOne(m => m.AuthActivity).WithMany(am => am.Actors_Movie).HasForeignKey(am => am.AuthActivity);

            base.OnModelCreating(modelBuilder);
        }
    }
}
