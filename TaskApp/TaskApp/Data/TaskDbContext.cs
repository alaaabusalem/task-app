using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Data
{
    public class TaskDbContext : IdentityDbContext<ApplicationUser>
    {
        public TaskDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MyTask user relation
            modelBuilder.Entity<ApplicationUser>()
           .HasMany<MyTask>(user => user.Tasks)
           .WithOne(task => task.User)
           .HasForeignKey(task => task.UserId);

            modelBuilder.Entity<MyTaskStatus>().HasData(
             new MyTaskStatus {MyTaskStatusId=1, Name ="ToDo" },
             new MyTaskStatus { MyTaskStatusId = 2, Name = "Done" }



                );
        }
    }
}
